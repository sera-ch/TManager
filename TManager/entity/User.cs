namespace TManager.entity
{
    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
<<<<<<< HEAD
        public string Password { get; set; }
=======
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9

        public User(int id, string name)
        {
            Id = id;
            Name = name;
        }
<<<<<<< HEAD

        public User(string name, string password)
        {
            Name = name;
            Password = password;
        }
=======
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
    }
}
