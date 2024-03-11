namespace TManager.error
{
    internal class TaskNotFoundException : Exception
    {
        public string TaskId { get; set; }
        public TaskNotFoundException(string taskId)
        {
            TaskId = taskId;
        }
    }
}
