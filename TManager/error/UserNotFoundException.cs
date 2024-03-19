namespace TManager.error
{
    public class UserNotFoundException : Exception
    {
        public string? Username { get; set; }
        public int? UserId { get; set; }

        public UserNotFoundException(string username)
        {
            Username = username;
        }

        public UserNotFoundException(int userId)
        {
            UserId = userId;
        }
    }
}
