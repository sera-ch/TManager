using Task = TManager.entity.Task;

namespace TManager.service
{
    public interface TaskService
    {
        List<Task> GetAllTasksByUserId(int userId);
        Task SaveTask(Task task);
        void UpdateTask(string oldTaskId, Task newTask);
        void DeleteTask(string taskId);
    }
}
