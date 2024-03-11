using TManager.entity;

namespace TManager.service
{
    public interface UserService
    {
        User GetUser(int id);
        User SaveUser(User user);
    }
}
