using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager.service.dto
{
    public class TaskView
    {
        public string Task { get; set; }
        public TaskStatus Status { get; set; }
        public DateOnly Deadline { get; set; }
        public string Note { get; set; }

        public static TaskView From(Task task)
        {
            return new TaskView { Task = task.ToString(), Status = task.Status, Deadline = task.Deadline, Note = task.Note };
        }
    }
}
