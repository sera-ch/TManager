using TManager.repository;
using TManager.service.dto;
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

        public virtual void UpdateTask(Task oldTask, Task newTask)
        {
            TaskRepository.PartialUpdate(oldTask, newTask);
        }

        public virtual void DeleteTask(string taskId, string taskName)
        {
            TaskRepository.Delete(taskId, taskName);
        }

        public bool ExistsByIdAndName(string taskId, string name)
        {
            return TaskRepository.ExistsByIdAndName(taskId, name);
        }
        public virtual Page<Task> GetAllTasksByUserIdPaged(int userId, int pageNumber, int pageSize)
        {
            List<Task> tasks = TaskRepository.GetAllByUserId(userId);
            int total = tasks.Count;
            int index = (pageNumber - 1) * pageSize;
            int size = Math.Min(pageSize, total - (pageNumber - 1) * pageSize);
            if (size < 0)
            {
                return Page<Task>.of(new List<Task>(), pageNumber, total);
            }
            List<Task> tasksSublist = tasks
                .OrderByDescending(task => task.Assigned)
                .ToList()
                .GetRange(index, size);
            return Page<Task>.of(tasksSublist, pageNumber, total);
        }
    }
}
