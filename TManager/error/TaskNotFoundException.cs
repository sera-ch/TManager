namespace TManager.error
{
    public class TaskNotFoundException : Exception
    {
        public string TaskId { get; set; }
        public TaskNotFoundException(string taskId)
        {
            TaskId = taskId;
        }
    }
}
