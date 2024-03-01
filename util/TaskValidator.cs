using TManager.error;

namespace TManager.util
{
    public class TaskValidator
    {
        public static void ValidateIdAndName(string id, string name)
        {
            if (id == "" || name == "")
            {
                throw new InvalidIdOrNameException();
            }
        }

        public static void ValidateDeadline(string deadline)
        {
            DateOnly deadlineDate = DateOnly.Parse(deadline);
            if (deadlineDate < DateUtil.Today())
            {
                throw new InvalidDeadlineException();
            }
        }

        public static void ValidateExistingTask(string id, string name)
        {
            if (MainWindow.TaskList.Exists(task => task.Id == id && task.Name == name))
            {
                throw new DuplicateTaskException();
            }
        }
    }
}
