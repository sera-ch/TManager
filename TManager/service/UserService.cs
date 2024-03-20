using TManager.entity;

namespace TManager.service
{
    public interface UserService
    {
        User GetUser(int id);
        User Register(User user);
        User LogIn(string username, string password);
        User? GetUserByUsername(string username);
        List<User> GetAllUsers();
    }
}
