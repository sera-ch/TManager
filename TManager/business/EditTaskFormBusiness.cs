using TManager.repository;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using User = TManager.entity.User;

namespace TManager.business
{
    public class EditTaskFormBusiness
    {
        private TaskService taskService = new TaskServiceImpl(new TaskRepository());
        private User User;
        private TaskValidator TaskValidator;
        private Task Task;

        public EditTaskFormBusiness(TaskService taskservice, User user, Task task)
        {
            this.taskService = taskservice;
            this.User = user;
            this.Task = task;
            TaskValidator = new TaskValidator(taskservice);
        }

        public Task EditTask(string id, string name, string deadline, string note)
        {
            TaskValidator.ValidateIdAndName(id, name);
            if (id != Task.Id || name != Task.Name)
            {
                TaskValidator.ValidateExistingTask(id, name);
            }
            TaskValidator.ValidateDeadline(deadline);
            string? assigned = Task.Assigned == null ? String.Empty : Task.Assigned.ToString();
            string? started = Task.Started == null ? String.Empty : Task.Started.ToString();
            string? prSent = Task.PrSent == null ? String.Empty : Task.PrSent.ToString();
            string? merged = Task.Merged == null ? String.Empty : Task.Merged.ToString();
            string? closed = Task.Closed == null ? String.Empty : Task.Closed.ToString();
            string? done = Task.Done == null ? String.Empty : Task.Done.ToString();
            string? status = Task.Status.ToString();
            Task newTask = new Task(id,
                name,
                assigned!,
                started!,
                prSent!,
                merged!,
                closed!,
                done!,
                status!,
                deadline!,
                note!);
            newTask.User = User;
            taskService.UpdateTask(Task, newTask);
            return newTask;
        }
    }
}
