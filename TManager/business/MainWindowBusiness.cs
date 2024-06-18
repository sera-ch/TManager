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
        private const int DEFAULT_PAGE_SIZE = 20;

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
            Page<Task> taskPage = TaskService.GetAllTasksByUserIdPaged(userId, 1, DEFAULT_PAGE_SIZE);
            taskList = taskPage.Items;
            List<TaskView> taskViewList = taskList
                .Select(TaskView.From)
                .ToList();
            taskListView.DataSource = taskViewList;
            MainWindow.totalCount = taskPage.TotalCount;
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

        public string WelcomeMessage(List<Task> TaskList, string username)
        {
            int tasksInReview = TaskList.FindAll(task => task.Status == TaskStatus.CODE_REVIEW).Count();
            int tasksDueToday = TaskList.FindAll(task => task.Deadline == DateUtil.Today() && task.IsWip()).Count();
            int tasksDueTomorrow = TaskList.FindAll(task => task.Deadline == DateUtil.Tomorrow() && task.IsWip()).Count();
            int tasksOverdue = TaskList.FindAll(task => task.Deadline < DateUtil.Today() && task.IsWip()).Count();
            string welcomeMessage = string.Format("Welcome {0}! Today is {1}.\n" +
                "You have {2} task(s) due today\n" +
                "You have {3} task(s) due tomorrow\n" +
                "You have {4} task(s) overdue\n" +
                "You have {5} task(s) in review.",
                username,
                DateUtil.Today().ToString(),
                tasksDueToday,
                tasksDueTomorrow,
                tasksOverdue,
                tasksInReview);
            return welcomeMessage;
        }

        public void RefreshTaskListView(int userId, DataGridView taskListView, out DataGridView outTaskListView, int pageNumber)
        {
            Page<Task> tasks = TaskService.GetAllTasksByUserIdPaged(userId, pageNumber, DEFAULT_PAGE_SIZE);
            outTaskListView = taskListView;
            outTaskListView.DataSource = tasks.Items.Select(TaskView.From).ToList();
            UpdateDeadlineFormatting(taskListView, out taskListView);
        }

        public int TurnTaskListViewPage(int userId, int nextPageNumber)
        {
            Page<Task> tasks = TaskService.GetAllTasksByUserIdPaged(userId, nextPageNumber, DEFAULT_PAGE_SIZE);
            if (tasks.PageSize < 1)
            {
                return MainWindow.pageNumber;
            }
            MainWindow.TaskList = tasks.Items;
            MainWindow.totalCount = tasks.TotalCount;
            return nextPageNumber;
        }

    }
}
