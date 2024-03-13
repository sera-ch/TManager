using TManager.entity;
using TManager.service;
using TManager.service.dto;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager.business
{
    public class MainWindowBusiness
    {
        public UserService UserService { get; set; }

        public TaskService TaskService { get; set; }
        public FileUtil FileUtil { get; set; }

        public MainWindowBusiness(UserService userService, TaskService taskService, FileUtil fileUtil)
        {
            UserService = userService;
            TaskService = taskService;
            FileUtil = fileUtil;
        }

        public User GetCurrentUser()
        {
            Configuration config = FileUtil.ReadConfigurationFromFile();
            return UserService.GetUser(config.UserId);
        }

        public void InitiateTaskListView(int userId, DataGridView taskListView, out List<Task> taskList, out DataGridView outTaskListView)
        {
            outTaskListView = taskListView;
            taskList = TaskService.GetAllTasksByUserId(userId)
                .FindAll(task => !task.IsDone()).ToList();
            List<TaskView> taskViewList = taskList
                .Select(TaskView.From)
                .ToList();
            taskListView.DataSource = taskViewList;
        }

        public void UpdateDeadlineFormatting(DataGridView taskListView, out DataGridView outTaskListView)
        {
            outTaskListView = taskListView;
            foreach (DataGridViewRow row in outTaskListView.Rows)
            {
                if (row.Cells[1].Value == null || row.Cells[2].Value == null)
                {
                    continue;
                }
                DateOnly deadline = (DateOnly)row.Cells[2].Value;
                TaskStatus status = (TaskStatus)row.Cells[1].Value;
                if (deadline == DateUtil.Tomorrow() && status != TaskStatus.CODE_REVIEW)
                {
                    row.Cells[2].Style.BackColor = Color.Orange;
                    continue;
                }
                if (deadline <= DateUtil.Today() && status != TaskStatus.CODE_REVIEW)
                {
                    row.Cells[2].Style.BackColor = Color.Red;
                    row.Cells[2].Style.ForeColor = Color.White;
                }
            }
        }

        public string WelcomeMessage(List<Task> TaskList)
        {
            int tasksInReview = TaskList.FindAll(task => task.Status == TaskStatus.CODE_REVIEW).Count();
            int tasksDueToday = TaskList.FindAll(task => task.Deadline == DateUtil.Today() && task.IsWip()).Count();
            int tasksDueTomorrow = TaskList.FindAll(task => task.Deadline == DateUtil.Tomorrow() && task.IsWip()).Count();
            int tasksOverdue = TaskList.FindAll(task => task.Deadline < DateUtil.Today() && task.IsWip()).Count();
            string welcomeMessage = string.Format("Welcome! Today is {0}.\n" +
                "You have {1} task(s) due today\n" +
                "You have {2} task(s) due tomorrow\n" +
                "You have {3} task(s) overdue\n" +
                "You have {4} task(s) in review.",
                DateUtil.Today().ToString(),
                tasksDueToday,
                tasksDueTomorrow,
                tasksOverdue,
                tasksInReview);
            return welcomeMessage;
        }

        public void RefreshTaskListView(List<Task> taskList, DataGridView taskListView, out DataGridView outTaskListView)
        {
            List<Task> tasksInProgress = taskList.FindAll(task => !task.IsDone());
            outTaskListView = taskListView;
            outTaskListView.DataSource = tasksInProgress.Select(TaskView.From).ToList();
            UpdateDeadlineFormatting(taskListView, out taskListView);
        }
    }
}
