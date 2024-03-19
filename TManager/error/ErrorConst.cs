namespace TManager.error
{
    public class ErrorConst
    {
        public const string INVALID_ID_NAME_ERROR_CODE = "000001";
        public const string INVALID_ID_NAME_ERROR_MESSAGE = "Task ID and name cannot be empty";

        public const string INVALID_DEADLINE_NAME_ERROR_CODE = "000002";
        public const string INVALID_DEADLINE_ERROR_MESSAGE = "Deadline cannot be before today";

        public const string DUPLICATE_TASK_ERROR_CODE = "000003";
        public const string DUPLICATE_TASK_ERROR_MESSAGE = "There is already a task with that ID and name";

        public const string INVALID_TASK_STATUS_ERROR_CODE = "000004";
        public const string INVALID_TASK_STATUS_ERROR_MESSAGE = "Invalid task status";

        public const string DUPLICATE_USER_ERROR_CODE = "000005";
        public const string DUPLICATE_USER_ERROR_MESSAGE = "There is already an user with that name";

        public const string INVALID_PASSWORD_ERROR_CODE = "000006";
        public const string INVALID_PASSWORD_ERROR_MESSAGE = "Password is too short";

        public const string PASSWORD_NOT_MATCH_ERROR_CODE = "000007";
        public const string PASSWORD_NOT_MATCH_ERROR_MESSAGE = "Password is not match";

        public const string INCORRECT_PASSWORD_ERROR_CODE = "000008";
        public const string INCORRECT_PASSWORD_ERROR_MESSAGE = "Incorrect password";

        public const string INVALID_USERNAME_ERROR_CODE = "000009";
        public const string INVALID_USERNAME_ERROR_MESSAGE = "Username cannot be empty";

        public const string USER_NOT_FOUND_ERROR_CODE = "100000";
        public const string USER_NOT_FOUND_ERROR_MESSAGE = "User not found";

        public const string ALREADY_LOGGED_IN_USER_ERROR_CODE = "100001";
        public const string ALREADY_LOGGED_IN_USER_ERROR_MESSAGE = "User is already logged in";
    }
}
