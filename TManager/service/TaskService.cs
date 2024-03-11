using Task = TManager.entity.Task;

namespace TManager.service
{
    public interface TaskService
    {
        List<Task> GetAllTasksByUserId(int userId);
        Task SaveTask(Task task);
        void UpdateTask(string oldTaskId, Task newTask);
        void DeleteTask(string taskId);
<<<<<<< HEAD
        bool ExistsByIdAndName(string taskId, string name);
=======
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
    }
}
