namespace ReactServerSide.Models
{
    public class Children
    {
        int id;
        Parent parentid = null!; // Foreign key to Parent
        string firstname = string.Empty;
        string lastname = string.Empty;
        DateTime dateofbirth;
        int groupid; // Foreign key to Group
        bool isactive;
        DateTime createdat;

        public int Id { get => id; set => id = value; }
        public Parent Parentid { get => parentid; set => parentid = value; }
        public string Firstname { get => firstname; set => firstname = value; }
        public string Lastname { get => lastname; set => lastname = value; }
        public DateTime Dateofbirth { get => dateofbirth; set => dateofbirth = value; }
        public int Groupid { get => groupid; set => groupid = value; }
        public bool Isactive { get => isactive; set => isactive = value; }
        public DateTime Createdat { get => createdat; set => createdat = value; }
    }
}
