using TManager.entity;
using TManager.error;
using TManager.service;
using TManager.service.dto;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager.business
{
    public class FullTaskListFormBusiness
    {
        private TaskService TaskService;
        private UserService UserService;
        private int UserId;
        private const int DEFAULT_PAGE_SIZE = 20;

        public FullTaskListFormBusiness(int userId, TaskService taskService, UserService userService)
        {
            TaskService = taskService;
            UserId = userId;
            UserService = userService;
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

        public virtual List<Task> updateTaskStatusAndRefreshTaskList(FullTaskListForm fullTaskListForm, Task task, TaskStatus newStatus, List<Task> TaskList, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName)
        {
            outTaskListView = taskListView;
            Task? updatedTask = TaskList.Find(t => t.Id == task.Id && t.Name == task.Name);
            if (updatedTask == null)
            {
                return TaskList;
            }
            updatedTask.Status = newStatus;
            switch (newStatus)
            {
                case TaskStatus.IN_PROGRESS: updatedTask.Started = DateUtil.Today(); break;
                case TaskStatus.CODE_REVIEW: updatedTask.PrSent = DateUtil.Today(); break;
                case TaskStatus.CLOSED: updatedTask.Closed = DateUtil.Today(); break;
                case TaskStatus.MERGED: updatedTask.Merged = DateUtil.Today(); break;
                case TaskStatus.DONE: updatedTask.Done = DateUtil.Today(); break;
            }
            TaskService.UpdateTask(updatedTask, updatedTask);
            RefreshTaskList(fullTaskListForm, outTaskListView, out outTaskListView, status, idOrName, fullTaskListForm.PageNumber);
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
            return TaskList;
        }

        public virtual List<Task> RefreshTaskList(FullTaskListForm fullTaskListForm, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName, int pageNumber)
        {
            outTaskListView = taskListView;
            Page<Task> taskList = TaskService.GetAllTasksByUserIdAndStringAndStatus(UserId, status, idOrName, pageNumber, DEFAULT_PAGE_SIZE);
            outTaskListView.DataSource = taskList.Items;
            outTaskListView.Refresh();
            FullTaskListForm.TotalCount = taskList.TotalCount;
            return taskList.Items;
        }

        public virtual void RefreshTaskList(FullTaskListForm fullTaskListForm, List<Task> newTaskList, DataGridView taskListView, out DataGridView outTaskListView)
        {
            outTaskListView = taskListView;
            outTaskListView.DataSource = newTaskList;
            outTaskListView.Refresh();
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
        }
        public virtual void updateTaskAndRefreshList(FullTaskListForm fullTaskListForm, Task oldTask, Task newTask, List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName, int pageNumber)
        {
            outTaskListView = taskListView;
            TaskService.UpdateTask(oldTask, newTask);
            RefreshTaskList(fullTaskListForm, outTaskListView, out outTaskListView, status, idOrName, pageNumber);
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

        public virtual List<Task> deleteTaskAndRefreshTaskList(FullTaskListForm fullTaskListForm, List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView, string taskId, string taskName, string status, string idOrName, int pageNumber)
        {
            TaskService.DeleteTask(taskId, taskName);
            return RefreshTaskList(fullTaskListForm, taskListView, out outTaskListView, status, idOrName, pageNumber);

        }

        public virtual List<User> GetAllUsers()
        {
            return UserService.GetAllUsers();
        }

        public virtual void updateTaskAssigneeAndRefreshList(FullTaskListForm fullTaskListForm, Task task, string newUserName, List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView, string status, string idOrName, int pageNumber)
        {
            outTaskListView = taskListView;
            User? newUser = UserService.GetUserByUsername(newUserName);
            if (newUser == null)
            {
                throw new UserNotFoundException(newUserName);
            }
            task.User = newUser;
            TaskService.UpdateTask(task, task);
            RefreshTaskList(fullTaskListForm, outTaskListView, out outTaskListView, status, idOrName, pageNumber);
            UpdateDeadlineFormatting(outTaskListView, out outTaskListView);
        }

        public int TurnTaskListViewPage(FullTaskListForm fullTaskListForm, int userId, string query, string status, int nextPageNumber)
        {
            Page<Task> tasks = TaskService.GetAllTasksByUserIdAndStringAndStatus(userId, status, query, nextPageNumber, DEFAULT_PAGE_SIZE);
            if (tasks.PageSize < 1)
            {
                return fullTaskListForm.PageNumber;
            }
            fullTaskListForm.TaskList = tasks.Items;
            FullTaskListForm.TotalCount = tasks.TotalCount;
            return nextPageNumber;
        }
    }
}
