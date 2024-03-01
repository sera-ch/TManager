using TManager.entity;
using TManager.util;
using Task = TManager.entity.Task;

namespace TManager
{
    public partial class MainWindow : Form
    {
        public static List<Task> TaskList { get; set; }
        public static Configuration Config { get; set; }
        public static string SaveFile { get; set; }
        public MainWindow()
        {
            TaskList = new List<Task>();
            Config = FileUtil.ReadConfigurationFromFile();
            SaveFile = Config.SaveSlot.ToString();
            InitializeComponent();
            UpdateFileItems(Config.SaveSlot);
        }

        private void MainWindow_Load(object sender, EventArgs e)
        {
            TaskList = FileUtil.ReadFileToTaskList(SaveFile);
            List<Task> tasksInProgress = TaskList.FindAll(task => !task.IsDone());
            taskListView.DataSource = tasksInProgress.Select(TaskView.From).ToList();
        }

        private void addTaskToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new AddTasksForm().ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            List<Task> tasksInProgress = TaskList.FindAll(task => !task.IsDone());
            taskListView.DataSource = tasksInProgress.Select(TaskView.From).ToList();
            taskListView.Refresh();
        }

        private void dailyReportToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new GenerateDailyReportForm().ShowDialog();
        }

        private void taskListToolStripMenuItem_Click(object sender, EventArgs e)
        {
            new FullTaskListForm().ShowDialog();
            RefreshTaskList();
        }

        private void aToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSaveFileConfig(SaveSlot.A);
            UpdateFileItems(SaveSlot.A);
        }

        private void bToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSaveFileConfig(SaveSlot.B);
            UpdateFileItems(SaveSlot.B);
        }

        private void cToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSaveFileConfig(SaveSlot.C);
            UpdateFileItems(SaveSlot.C);
        }

        private void dToolStripMenuItem_Click(object sender, EventArgs e)
        {
            UpdateSaveFileConfig(SaveSlot.D);
            UpdateFileItems(SaveSlot.D);
        }

        private void UpdateSaveFileConfig(SaveSlot saveSlot)
        {
            SaveFile = saveSlot.ToString();
            Config.SaveSlot = saveSlot;
            FileUtil.WriteConfigurationToFile(Config);
            TaskList = FileUtil.ReadFileToTaskList(saveSlot.ToString());
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            List<Task> tasksInProgress = TaskList.FindAll(task => !task.IsDone());
            taskListView.DataSource = tasksInProgress.Select(TaskView.From).ToList();
            taskListView.Refresh();
        }

        private void UpdateFileItems(SaveSlot saveSlot)
        {
            switch (saveSlot)
            {
                case SaveSlot.A:
                    {
                        aToolStripMenuItem.Checked = true;
                        bToolStripMenuItem.Checked = false;
                        cToolStripMenuItem.Checked = false;
                        dToolStripMenuItem.Checked = false;
                        break;
                    }
                case SaveSlot.B:
                    {
                        aToolStripMenuItem.Checked = false;
                        bToolStripMenuItem.Checked = true;
                        cToolStripMenuItem.Checked = false;
                        dToolStripMenuItem.Checked = false;
                        break;
                    }
                case SaveSlot.C:
                    {
                        aToolStripMenuItem.Checked = false;
                        bToolStripMenuItem.Checked = false;
                        cToolStripMenuItem.Checked = true;
                        dToolStripMenuItem.Checked = false;
                        break;
                    }
                case SaveSlot.D:
                    {
                        aToolStripMenuItem.Checked = false;
                        bToolStripMenuItem.Checked = false;
                        cToolStripMenuItem.Checked = false;
                        dToolStripMenuItem.Checked = true;
                        break;
                    }
            }
        }
    }
}
