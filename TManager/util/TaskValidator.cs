using TManager.error;
using TManager.service;

namespace TManager.util
{
    public class TaskValidator
    {
        private TaskService taskService;
        public TaskValidator(TaskService taskService)
        {
            this.taskService = taskService;
        }
        public void ValidateIdAndName(string id, string name)
        {
            if (id == "" || name == "")
            {
                throw new InvalidIdOrNameException();
            }
        }

        public void ValidateDeadline(string deadline)
        {
            DateOnly deadlineDate = DateOnly.Parse(deadline);
            if (deadlineDate < DateUtil.Today())
            {
                throw new InvalidDeadlineException();
            }
        }

        public void ValidateExistingTask(string id, string name)
        {
            if (taskService.ExistsByIdAndName(id, name))
            {
                throw new DuplicateTaskException();
            }
        }
    }
}
