namespace TManager.entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Password { get; set; }

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }

        public override string ToString()
        {
            return Name;
        }
    }
}
