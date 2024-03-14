using TManager.entity;
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

        public User logIn(string username, string password)
        {
            byte[] key = encryptionUtil.CreateKey(password);
            string encryptedPassword = encryptionUtil.Encrypt(password, key);
            return UserService.LogIn(username, encryptedPassword);
        }
    }
}
