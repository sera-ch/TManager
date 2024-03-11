using TManager.business;
using TManager.entity;
using TManager.error;
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
        public MainWindow()
        {
            TaskService taskService = new TaskServiceImpl(new TaskRepository());
            UserService userService = new UserServiceImpl(new UserRepository());
            FileUtil fileUtil = new FileUtil();
            MainWindowBusiness = new MainWindowBusiness(userService, taskService, fileUtil);
            try
            {
                User = MainWindowBusiness.GetCurrentUser();
            }
            catch (UserNotFoundException e)
            {
                // TODO: Make user select an user or input new user to continue
                MessageBox.Show(ErrorConst.USER_NOT_FOUND_ERROR_MESSAGE, ErrorConst.USER_NOT_FOUND_ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            List<Task> tasks;
            MainWindowBusiness.InitiateTaskListView(User.Id, taskListView, out tasks, out taskListView);
            TaskList = tasks;
            MainWindowBusiness.UpdateDeadlineFormatting(taskListView, out taskListView);
            MessageBox.Show(MainWindowBusiness.WelcomeMessage(TaskList), "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new AddTasksForm().ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            MainWindowBusiness.RefreshTaskListView(TaskList, out taskListView);
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GenerateDailyReportForm().ShowDialog();
        }

        private void taskListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FullTaskListForm().ShowDialog();
            MainWindowBusiness.RefreshTaskListView(TaskList, out taskListView);
        }
    }
}
