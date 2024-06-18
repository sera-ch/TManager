using TManager.business;
using TManager.entity;
using TManager.repository;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;

namespace TManager
{
    public partial class MainWindow : Form
    {
        public static List<Task> TaskList { get; set; }
        private MainWindowBusiness MainWindowBusiness { get; set; }
        public static User User { get; set; }
        private const int DEFAULT_PAGE_SIZE = 20;
        public static int pageNumber { get; set; }
        public static int totalCount { get; set; }
        public MainWindow()
        {
            TaskService taskService = new TaskServiceImpl(new TaskRepository());
            UserService userService = new UserServiceImpl(new UserRepository());
            FileUtil fileUtil = new FileUtil();
            MainWindowBusiness = new MainWindowBusiness(userService, taskService, fileUtil);
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            List<Task> tasks;
            showLogInForm();
            MainWindowBusiness.InitiateTaskListView(User.Id, taskListView, out tasks, out taskListView);
            TaskList = tasks;
            MainWindowBusiness.UpdateDeadlineFormatting(taskListView, out taskListView);
            pageNumberTextBox.Value = 1;
            pageNumberTextBox.Enabled = false;
            toPreviousPageButton.Enabled = false;
            ToFirstPageButton.Enabled = false;
            if (tasks.Count > DEFAULT_PAGE_SIZE)
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
                pageNumberTextBox.Enabled = true;
            }
            pageNumber = 1;
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTasksForm addTaskForm = new AddTasksForm(User);
            DialogResult result = addTaskForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            if (addTaskForm.Response != null)
            {
                TaskList.Add(addTaskForm.Response);
            }
            MainWindowBusiness.RefreshTaskListView(User.Id, taskListView, out taskListView, pageNumber);
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GenerateDailyReportForm(new GenerateDailyReportFormBusiness(new TaskServiceImpl(new TaskRepository()))).ShowDialog();
        }

        private void taskListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FullTaskListForm(User.Id).ShowDialog();
            MainWindowBusiness.RefreshTaskListView(User.Id, taskListView, out taskListView, pageNumber);
        }

        private void registerToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new RegisterForm().ShowDialog();
        }

        private void switchUserToolStripMenuItem_Click(object sender, EventArgs e)
        {
            showLogInForm();
        }

        private void showLogInForm()
        {

            LogInForm logInForm = new LogInForm(User);
            DialogResult result = logInForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                User = logInForm.Response;
                List<Task> tasks = TaskList;
                MainWindowBusiness.InitiateTaskListView(User.Id, taskListView, out tasks, out taskListView);
                TaskList = tasks;
                showWelcomeMessage();
            }
            if (User == null)
            {
                Environment.Exit(0);
            }
        }

        private void showWelcomeMessage()
        {
            MessageBox.Show(MainWindowBusiness.WelcomeMessage(TaskList, User.Name), "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void toPreviousPageButton_Click(object sender, EventArgs e)
        {
            pageNumber = MainWindowBusiness.TurnTaskListViewPage(User.Id, pageNumber - 1);
            pageNumberTextBox.Value = pageNumber;
            if (pageNumber == 1)
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            if (pageNumber * DEFAULT_PAGE_SIZE < totalCount)
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            MainWindowBusiness.RefreshTaskListView(User.Id, taskListView, out taskListView, pageNumber);
        }

        private void toNextPageButton_Click(object sender, EventArgs e)
        {
            pageNumber = MainWindowBusiness.TurnTaskListViewPage(User.Id, pageNumber + 1);
            pageNumberTextBox.Value = pageNumber;
            if (pageNumber * DEFAULT_PAGE_SIZE >= totalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            if (pageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            MainWindowBusiness.RefreshTaskListView(User.Id, taskListView, out taskListView, pageNumber);
        }

        private void ToFirstPageButton_Click(object sender, EventArgs e)
        {

            pageNumber = MainWindowBusiness.TurnTaskListViewPage(User.Id, 1);
            pageNumberTextBox.Value = pageNumber;
            if (pageNumber == 1)
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            if (pageNumber * DEFAULT_PAGE_SIZE < totalCount)
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            MainWindowBusiness.RefreshTaskListView(User.Id, taskListView, out taskListView, pageNumber);
        }

        private void toLastPageButton_Click(object sender, EventArgs e)
        {
            pageNumber = MainWindowBusiness.TurnTaskListViewPage(User.Id, totalCount / DEFAULT_PAGE_SIZE + 1);
            pageNumberTextBox.Value = pageNumber;
            if (pageNumber * DEFAULT_PAGE_SIZE >= totalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            if (pageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            MainWindowBusiness.RefreshTaskListView(User.Id, taskListView, out taskListView, pageNumber);
        }
    }
}
