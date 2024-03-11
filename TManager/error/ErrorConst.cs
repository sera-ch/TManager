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

        public const string USER_NOT_FOUND_ERROR_CODE = "100000";
        public const string USER_NOT_FOUND_ERROR_MESSAGE = "User not found";
    }
}
