using TManager.entity;
using TManager.error;
using TManager.service;
using TManager.util;

namespace TManager.business
{
    public class UserBusiness
    {
        private UserService UserService;
        private EncryptionUtil encryptionUtil;
        private UserValidator userValidator;

        public UserBusiness(UserService userService)
        {
            UserService = userService;
            encryptionUtil = new EncryptionUtil();
            userValidator = new UserValidator(userService);
        }

        public User registerUser(string username, string password, string repeatPassword)
        {
            userValidator.validateUsername(username);
            userValidator.validatePassword(password, repeatPassword);
            userValidator.validateExistUser(username);
            byte[] key = encryptionUtil.CreateKey(password);
            string encryptedPassword = encryptionUtil.Encrypt(password, key);
            User user = new User(username, encryptedPassword);
            return UserService.Register(user);
        }

        public User logIn(string username, string password, User? currentLoggedInUser)
        {
            userValidator.validateUsername(username);
            if (currentLoggedInUser != null && username == currentLoggedInUser.Name)
            {
                throw new AlreadyLoggedInUserException();
            }
            User? existingUser = UserService.GetUserByUsername(username);
            if (existingUser == null)
            {
                throw new UserNotFoundException(username);
            }
            byte[] key = encryptionUtil.CreateKey(password);
            string encryptedPassword = encryptionUtil.Encrypt(password, key);
            if (encryptedPassword != existingUser.Password)
            {
                throw new IncorrectPasswordException();
            }
            return UserService.LogIn(username, encryptedPassword);
        }
    }
}
