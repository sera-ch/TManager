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
            AddTasksForm addTaskForm = new AddTasksForm(User);
            DialogResult result = addTaskForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
<<<<<<< HEAD
            if (addTaskForm.Response != null)
            {
                TaskList.Add(addTaskForm.Response);
            }
            MainWindowBusiness.RefreshTaskListView(TaskList, taskListView, out taskListView);
=======
            MainWindowBusiness.RefreshTaskListView(TaskList, out taskListView);
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GenerateDailyReportForm(new GenerateDailyReportFormBusiness()).ShowDialog();
        }

        private void taskListToolStripMenuItem_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
            new FullTaskListForm(User.Id).ShowDialog();
            MainWindowBusiness.RefreshTaskListView(TaskList, taskListView, out taskListView);
=======
            new FullTaskListForm().ShowDialog();
            MainWindowBusiness.RefreshTaskListView(TaskList, out taskListView);
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
        }
    }
}
