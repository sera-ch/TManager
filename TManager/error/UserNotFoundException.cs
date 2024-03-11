namespace TManager.error
{
    public class UserNotFoundException : Exception
    {
        public int UserId { get; set; }

        public UserNotFoundException(int userId)
        {
            UserId = userId;
        }
    }
}
