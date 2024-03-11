namespace TManager.util
{
    public class UserValidator
    {
        private const int MIN_PASSWORD_LENGTH = 6;
        public UserValidator() { }

        public void validatePassword(string password, string repeatPassword)
        {
            if (password.Length < MIN_PASSWORD_LENGTH)
            {
                // TODO: Throw password too short error
            }
            if (!password.Equals(repeatPassword))
            {
                // TODO: Throw password not match error
            }
        }

        public void validateUsername(string username)
        {
            if ("".Equals(username))
            {
                // TODO: Throw invalid username
            }
        }
    }
}
