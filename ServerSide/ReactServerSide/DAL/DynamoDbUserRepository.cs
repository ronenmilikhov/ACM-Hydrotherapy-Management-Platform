using Amazon.DynamoDBv2;
using Amazon.DynamoDBv2.Model;

namespace ReactServerSide.DAL;

public interface IDynamoDbUserRepository
{
    Task<Dictionary<string, AttributeValue>?> GetByEmailAsync(string tableName, string email);
    Task UpdatePasswordHashAsync(string tableName, string email, string passwordHash);
}

public sealed class DynamoDbUserRepository : IDynamoDbUserRepository
{
    private readonly IAmazonDynamoDB _client;

    public DynamoDbUserRepository(IAmazonDynamoDB client)
    {
        _client = client;
    }

    public async Task<Dictionary<string, AttributeValue>?> GetByEmailAsync(string tableName, string email)
    {
        GetItemResponse response = await _client.GetItemAsync(new GetItemRequest
        {
            TableName = tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                ["Email"] = new AttributeValue { S = email }
            }
        });

        return response.Item is { Count: > 0 } ? response.Item : null;
    }

    public Task UpdatePasswordHashAsync(string tableName, string email, string passwordHash)
    {
        return _client.UpdateItemAsync(new UpdateItemRequest
        {
            TableName = tableName,
            Key = new Dictionary<string, AttributeValue>
            {
                ["Email"] = new AttributeValue { S = email }
            },
            AttributeUpdates = new Dictionary<string, AttributeValueUpdate>
            {
                ["PasswordHash"] = new AttributeValueUpdate
                {
                    Action = AttributeAction.PUT,
                    Value = new AttributeValue { S = passwordHash }
                }
            }
        });
    }
}
