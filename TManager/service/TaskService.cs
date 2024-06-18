using TManager.service.dto;
using Task = TManager.entity.Task;

namespace TManager.service
{
    public interface TaskService
    {
        List<Task> GetAllTasksByUserId(int userId);
        Page<Task> GetAllTasksByUserIdPaged(int userId, int pageNumber, int pageSize);
        Page<Task> GetAllTasksByUserIdAndStringAndStatus(int userId, string status, string query, int pageNumber, int pageSize);
        Task SaveTask(Task task);
        void UpdateTask(Task oldTask, Task newTask);
        void DeleteTask(string taskId, string taskName);
        bool ExistsByIdAndName(string taskId, string name);
    }
}
