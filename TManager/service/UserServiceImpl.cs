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

        public virtual User SaveUser(User user)
        {
            return userRepository.Save(user);
        }
    }
}
