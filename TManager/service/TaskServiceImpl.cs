using TManager.repository;
using Task = TManager.entity.Task;

namespace TManager.service
{
    public class TaskServiceImpl : TaskService
    {
        public TaskRepository TaskRepository { get; }
        public TaskServiceImpl(TaskRepository taskRepository)
        {
            this.TaskRepository = taskRepository;
        }
        public virtual List<Task> GetAllTasksByUserId(int userId)
        {
            return TaskRepository.GetAllByUserId(userId);
        }

        public virtual Task SaveTask(Task task)
        {
            return TaskRepository.Save(task);
        }

        public virtual void UpdateTask(string oldTaskId, Task newTask)
        {
            TaskRepository.PartialUpdate(oldTaskId, newTask);
        }

        public virtual void DeleteTask(string taskId)
        {
            TaskRepository.Delete(taskId);
        }

<<<<<<< HEAD
        public bool ExistsByIdAndName(string taskId, string name)
        {
            return TaskRepository.ExistsByIdAndName(taskId, name);
        }
=======
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
    }
}
