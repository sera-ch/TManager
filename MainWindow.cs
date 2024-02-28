using TManager.entity;
using TManager.util;
using Task = TManager.entity.Task;

namespace TManager
{
    public partial class MainWindow : Form
    {
        public static List<Task> TaskList { get; set; }
        public MainWindow()
        {
            TaskList = new List<Task>();
            InitializeComponent();
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            TaskList = FileUtil.ReadFileToTaskList("tasks")
                .FindAll(task => !task.IsDone());
            taskListView.DataSource = TaskList.Select(TaskView.From).ToList();
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            AddTasksForm addTasksForm = new AddTasksForm();
            DialogResult result = addTasksForm.ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            taskListView.DataSource = TaskList.Select(TaskView.From).ToList();
            taskListView.Refresh();
        }
    }
}
