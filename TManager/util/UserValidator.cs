using TManager.entity;
using TManager.error;
using TManager.service;

namespace TManager.util
{
    public class UserValidator
    {
        private const int MIN_PASSWORD_LENGTH = 6;

        private UserService userService;
        public UserValidator(UserService userService)
        {
            this.userService = userService;
        }

        public void validatePassword(string password, string repeatPassword)
        {
            if (password.Length < MIN_PASSWORD_LENGTH)
            {
                throw new InvalidPasswordException();
            }
            if (!password.Equals(repeatPassword))
            {
                throw new PasswordNotMatchException();
            }
        }

        public void validateUsername(string username)
        {
            if ("".Equals(username))
            {
                throw new InvalidUsernameException();
            }
        }

        public void validateExistUser(string username)
        {
            User? existingUser = userService.GetUserByUsername(username);
            if (existingUser != null)
            {
                throw new DuplicateUserException();
            }
        }
    }
}
