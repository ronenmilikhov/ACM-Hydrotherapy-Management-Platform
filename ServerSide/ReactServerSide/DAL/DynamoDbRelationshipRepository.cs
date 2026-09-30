using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace ReactServerSide.DAL;

public interface IDynamoDbRelationshipRepository
{
    Task<HashSet<int>> GetInstructorIdsForChildAsync(int parentId, int childId);
}

public sealed class DynamoDbRelationshipRepository : IDynamoDbRelationshipRepository
{
    private readonly IAmazonDynamoDB _client;

    public DynamoDbRelationshipRepository(IAmazonDynamoDB client)
    {
        _client = client;
    }

    public async Task<HashSet<int>> GetInstructorIdsForChildAsync(int parentId, int childId)
    {
        var instructorIds = new HashSet<int>();

        ScanResponse groupChildrenScan = await _client.ScanAsync(new ScanRequest
        {
            TableName = "GroupChildren",
            FilterExpression = "ChildId = :cid AND IsActive = :active",
            ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                [":cid"] = new AttributeValue { N = childId.ToString() },
                [":active"] = new AttributeValue { BOOL = true }
            }
        });

        var activeGroupIds = groupChildrenScan.Items
            .Where(item => item.TryGetValue("GroupId", out AttributeValue? groupIdValue)
                && int.TryParse(groupIdValue.N, out _))
            .Select(item => int.Parse(item["GroupId"].N!))
            .ToHashSet();

        if (activeGroupIds.Count > 0)
        {
            ScanResponse groupsScan = await _client.ScanAsync(new ScanRequest
            {
                TableName = "Groups"
            });

            var activeGroupIdsInStore = groupsScan.Items
                .Where(group => group.TryGetValue("Id", out AttributeValue? groupIdValue)
                    && int.TryParse(groupIdValue.N, out int groupId)
                    && group.TryGetValue("IsActive", out AttributeValue? activeValue)
                    && activeValue.BOOL == true
                    && activeGroupIds.Contains(groupId))
                .Select(group => int.Parse(group["Id"].N!))
                .ToHashSet();

            if (activeGroupIdsInStore.Count > 0)
            {
                ScanResponse instructorGroupsScan = await _client.ScanAsync(new ScanRequest
                {
                    TableName = "InstructorGroups",
                    FilterExpression = "IsActive = :active",
                    ExpressionAttributeValues = new Dictionary<string, AttributeValue>
                    {
                        [":active"] = new AttributeValue { BOOL = true }
                    }
                });

                foreach (Dictionary<string, AttributeValue> instructorGroup in instructorGroupsScan.Items)
                {
                    if (instructorGroup.TryGetValue("GroupId", out AttributeValue? groupIdValue)
                        && instructorGroup.TryGetValue("InstructorId", out AttributeValue? instructorIdValue)
                        && int.TryParse(groupIdValue.N, out int groupId)
                        && int.TryParse(instructorIdValue.N, out int instructorId)
                        && activeGroupIdsInStore.Contains(groupId))
                    {
                        instructorIds.Add(instructorId);
                    }
                }
            }
        }

        ScanResponse trainingSessionsScan = await _client.ScanAsync(new ScanRequest
        {
            TableName = "TrainingSessions",
            FilterExpression = "ChildId = :cid AND #stat <> :canc",
            ExpressionAttributeNames = new Dictionary<string, string>
            {
                ["#stat"] = "Status"
            },
            ExpressionAttributeValues = new Dictionary<string, AttributeValue>
            {
                [":cid"] = new AttributeValue { N = childId.ToString() },
                [":canc"] = new AttributeValue { S = "Cancelled" }
            }
        });

        foreach (Dictionary<string, AttributeValue> session in trainingSessionsScan.Items)
        {
            if (session.TryGetValue("InstructorId", out AttributeValue? instructorIdValue)
                && int.TryParse(instructorIdValue.N, out int instructorId))
            {
                instructorIds.Add(instructorId);
            }
        }

        return instructorIds;
    }
}
