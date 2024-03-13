namespace TManager.error
{
<<<<<<< HEAD
    public class TaskNotFoundException : Exception
=======
    internal class TaskNotFoundException : Exception
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
    {
        public string TaskId { get; set; }
        public TaskNotFoundException(string taskId)
        {
            TaskId = taskId;
        }
    }
}
