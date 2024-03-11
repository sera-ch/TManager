using TManager.repository;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;
using User = TManager.entity.User;

namespace TManager.business
{
    public class AddTaskFormBusiness
    {
        private TaskService taskService = new TaskServiceImpl(new TaskRepository());
        private User User;
        private TaskValidator TaskValidator;

        public AddTaskFormBusiness(TaskService taskService, User user)
        {
            this.taskService = taskService;
            this.User = user;
            this.TaskValidator = new TaskValidator(taskService);
        }

        public Task AddTask(string id, string name, string deadline, string note)
        {
            TaskValidator.ValidateIdAndName(id, name);
            TaskValidator.ValidateExistingTask(id, name);
            TaskValidator.ValidateDeadline(deadline);
            string assigned = DateUtil.Today().ToString();
            Task newTask = new Task(id, name, assigned, "", "", "", "", "", TaskStatus.TODO.ToString(), deadline, note);
            newTask.User = MainWindow.User;
            taskService.SaveTask(newTask);
            return newTask;
        }

    }
}
