using TManager.entity;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

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
            UpdateDeadlineFormatting();
            ShowWelcomeMessage();
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
            UpdateDeadlineFormatting();
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
            UpdateDeadlineFormatting();
            taskListView.Refresh();
        }

        private void UpdateDeadlineFormatting()
        {
            if (taskListView.Rows.Count == 0)
            {
                return;
            }
            foreach (DataGridViewRow row in taskListView.Rows)
            {
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

        private void ShowWelcomeMessage()
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
            MessageBox.Show(welcomeMessage, "Welcome", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}
