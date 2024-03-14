using TManager.entity;
using TManager.error;
using TManager.repository;

namespace TManager.service
{
    public class UserServiceImpl : UserService
    {
        private UserRepository userRepository;

        public UserServiceImpl(UserRepository userRepository)
        {
            this.userRepository = userRepository;
        }
        public virtual User GetUser(int id)
        {
            return userRepository.GetUser(id) ?? throw new UserNotFoundException(id);
        }

        public User Register(User user)
        {
            return userRepository.Save(user);
        }

        public User LogIn(string username, string password)
        {
            return null;
        }

        public virtual User? GetUserByUsername(string username)
        {
            return userRepository.GetByUserName(username);
        }
    }
}
