using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager.business
{
    public class FullTaskListFormBusiness
    {
        private TaskService TaskService;
        private int UserId;

        public FullTaskListFormBusiness(int userId, TaskService taskService)
        {
            TaskService = taskService;
            UserId = userId;
        }

        public virtual List<Task> GetAllTasks()
        {
            return TaskService.GetAllTasksByUserId(UserId);
        }

        public virtual Task selectTask(DataGridView fullTaskListView)
        {
            string? id = (string)fullTaskListView.SelectedRows[0].Cells[0].Value;
            string? name = (string)fullTaskListView.SelectedRows[0].Cells[1].Value;
            DateOnly? assigned = (DateOnly?)fullTaskListView.SelectedRows[0].Cells[2].Value;
            DateOnly? started = (DateOnly?)fullTaskListView.SelectedRows[0].Cells[3].Value;
            DateOnly? prSent = (DateOnly?)fullTaskListView.SelectedRows[0].Cells[4].Value;
            DateOnly? merged = (DateOnly?)fullTaskListView.SelectedRows[0].Cells[5].Value;
            DateOnly? closed = (DateOnly?)fullTaskListView.SelectedRows[0].Cells[6].Value;
            DateOnly? done = (DateOnly?)fullTaskListView.SelectedRows[0].Cells[7].Value;
            TaskStatus status = (TaskStatus)fullTaskListView.SelectedRows[0].Cells[8].Value;
            DateOnly deadline = (DateOnly)fullTaskListView.SelectedRows[0].Cells[9].Value;
            string note = (string)fullTaskListView.SelectedRows[0].Cells[10].Value;
            Task selectedTask = new Task(id, name,
                assigned == null ? "" : assigned.Value.ToString(),
                started == null ? "" : started.Value.ToString(),
                prSent == null ? "" : prSent.Value.ToString(),
                merged == null ? "" : merged.Value.ToString(),
                closed == null ? "" : closed.Value.ToString(),
                done == null ? "" : done.Value.ToString(),
                status.ToString(),
                deadline.ToString(),
                note);
            return selectedTask;
        }

        public virtual List<Task> updateTaskStatusAndRefreshTaskList(Task task, TaskStatus newStatus, List<Task> TaskList, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName)
        {
            outTaskListView = taskListView;
            Task? updatedTask = TaskList.Find(t => t.Id == task.Id && t.Name == task.Name);
            updatedTask.Status = newStatus;
            switch (newStatus)
            {
                case TaskStatus.IN_PROGRESS: updatedTask.Started = DateUtil.Today(); break;
                case TaskStatus.CODE_REVIEW: updatedTask.PrSent = DateUtil.Today(); break;
                case TaskStatus.CLOSED: updatedTask.Closed = DateUtil.Today(); break;
                case TaskStatus.MERGED: updatedTask.Merged = DateUtil.Today(); break;
                case TaskStatus.DONE: updatedTask.Done = DateUtil.Today(); break;
            }
            TaskService.UpdateTask(updatedTask.Id, updatedTask);
            RefreshTaskList(outTaskListView, out outTaskListView, status, idOrName);
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
            return TaskList;
        }

        public virtual List<Task> RefreshTaskList(DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName)
        {
            outTaskListView = taskListView;
            List<Task> taskList = TaskService.GetAllTasksByUserId(UserId);
            List<Task> selectedTasks = QueryTasks(taskList, outTaskListView, out outTaskListView, status, idOrName);
            outTaskListView.Refresh();
            return selectedTasks;
        }

        public virtual void RefreshTaskList(List<Task> newTaskList, DataGridView taskListView, out DataGridView outTaskListView)
        {
            outTaskListView = taskListView;
            outTaskListView.DataSource = newTaskList;
            outTaskListView.Refresh();
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
        }
        public virtual void updateTaskAndRefreshList(Task oldTask, Task newTask, List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName)
        {
            outTaskListView = taskListView;
            TaskService.UpdateTask(oldTask.Id, newTask);
            RefreshTaskList(outTaskListView, out outTaskListView, status, idOrName);
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
        }

        public virtual void UpdateDeadlineFormatting(DataGridView fullTaskListView, out DataGridView outFullTaskListView)
        {
            outFullTaskListView = fullTaskListView;
            foreach (DataGridViewRow row in fullTaskListView.Rows)
            {
                TaskStatus status = (TaskStatus)row.Cells[8].Value;
                if (status != TaskStatus.TODO && status != TaskStatus.IN_PROGRESS)
                {
                    continue;
                }
                DateOnly deadline = (DateOnly)row.Cells[9].Value;
                if (deadline == DateUtil.Tomorrow())
                {
                    row.Cells[9].Style.BackColor = Color.Orange;
                    continue;
                }
                if (deadline <= DateUtil.Today())
                {
                    row.Cells[9].Style.BackColor = Color.Red;
                    row.Cells[9].Style.ForeColor = Color.White;
                }
            }
        }

        public virtual List<Task> QueryTasks(List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName)
        {
            outTaskListView = taskListView;
            if (taskList == null || taskList.Count == 0)
            {
                return new List<Task>();
            }
            List<Task> showedTasks = taskList.FindAll(task => task.IsMatch(status, idOrName));
            RefreshTaskList(showedTasks, outTaskListView, out outTaskListView);
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
            return showedTasks;
        }

        public virtual List<Task> deleteTaskAndRefreshTaskList(List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView, string taskId, string status, string idOrName)
        {
            TaskService.DeleteTask(taskId);
            return RefreshTaskList(taskListView, out outTaskListView, status, idOrName);

        }

        public virtual void updateTask(string taskId, Task task)
        {
            TaskService.UpdateTask(taskId, task);
        }
    }
}
