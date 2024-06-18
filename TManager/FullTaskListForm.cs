using TManager.business;
using TManager.entity;
using TManager.error;
using TManager.repository;
using TManager.service;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager
{
    public partial class FullTaskListForm : Form
    {
        public Task SelectedTask { get; set; }
        public List<Task> TaskList { get; set; }
        public List<Task> ShowedTasks { get; set; }

        private FullTaskListFormBusiness FullTaskListFormBusiness;
        private int UserId;
        public static int TotalCount { get; set; }
        public int PageNumber { get; set; }
        private const int DEFAULT_PAGE_SIZE = 20;
        public FullTaskListForm(int userId)
        {
            InitializeComponent();
            UserId = userId;
            FullTaskListFormBusiness = new FullTaskListFormBusiness(UserId, new TaskServiceImpl(new TaskRepository()),
                new UserServiceImpl(new UserRepository()));
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            ShowedTasks = TaskList;
            fullTaskListView.DataSource = ShowedTasks;
            SelectedTask = null;
            startWorkingButton.Enabled = false;
            codeReviewButton.Enabled = false;
            mergeButton.Enabled = false;
            closeButton.Enabled = false;
            doneButton.Enabled = false;
            taskDeleteButton.Enabled = false;
            TotalCount = TaskList.Count;
            PageNumber = 1;
            pageNumberTextBox.Value = PageNumber;
        }

        private void fullTaskListView_SelectionChanged(object sender, EventArgs e)
        {
            if (fullTaskListView.SelectedRows.Count == 0 || fullTaskListView.SelectedRows == null)
            {
                return;
            }
            SelectedTask = FullTaskListFormBusiness.selectTask(fullTaskListView);
            updateButtons();
        }
        private void updateButtons()
        {
            if (SelectedTask == null)
            {
                return;
            }
            taskDeleteButton.Enabled = true;
            TaskStatus taskStatus = SelectedTask.Status;
            if (taskStatus == TaskStatus.TODO)
            {
                startWorkingButton.Text = "Start";
                startWorkingButton.Enabled = true;
                codeReviewButton.Enabled = false;
                mergeButton.Enabled = false;
                closeButton.Enabled = false;
                doneButton.Enabled = false;
            }
            else if (taskStatus == TaskStatus.IN_PROGRESS)
            {
                startWorkingButton.Text = "Start";
                startWorkingButton.Enabled = false;
                codeReviewButton.Enabled = true;
                mergeButton.Enabled = false;
                closeButton.Enabled = true;
                doneButton.Enabled = false;
            }
            else if (taskStatus == TaskStatus.CODE_REVIEW)
            {
                startWorkingButton.Text = "Start";
                startWorkingButton.Enabled = false;
                codeReviewButton.Enabled = false;
                mergeButton.Enabled = true;
                closeButton.Enabled = true;
                doneButton.Enabled = false;
            }
            else if (taskStatus == TaskStatus.MERGED)
            {
                startWorkingButton.Text = "Start";
                startWorkingButton.Enabled = false;
                codeReviewButton.Enabled = true;
                mergeButton.Enabled = false;
                closeButton.Enabled = false;
                doneButton.Enabled = true;
            }
            else if (taskStatus == TaskStatus.CLOSED)
            {
                startWorkingButton.Text = "Reopen";
                startWorkingButton.Enabled = true;
                codeReviewButton.Enabled = false;
                mergeButton.Enabled = false;
                closeButton.Enabled = false;
                doneButton.Enabled = false;
            }
            else
            {
                startWorkingButton.Text = "Reopen";
                startWorkingButton.Enabled = true;
                codeReviewButton.Enabled = false;
                mergeButton.Enabled = false;
                closeButton.Enabled = false;
                doneButton.Enabled = false;
            }
        }

        private void updateContextMenuItems()
        {
            TaskStatus taskStatus = SelectedTask.Status;
            if (taskStatus == TaskStatus.TODO)
            {
                changeStatusToInProgressItem.Enabled = true;
                changeStatusToCodeReviewItem.Enabled = false;
                changeStatusToMergedItem.Enabled = false;
                changeStatusToClosedItem.Enabled = false;
                changeStatusToDoneItem.Enabled = false;
            }
            else if (taskStatus == TaskStatus.IN_PROGRESS)
            {
                changeStatusToInProgressItem.Enabled = false;
                changeStatusToCodeReviewItem.Enabled = true;
                changeStatusToMergedItem.Enabled = false;
                changeStatusToClosedItem.Enabled = true;
                changeStatusToDoneItem.Enabled = false;
            }
            else if (taskStatus == TaskStatus.CODE_REVIEW)
            {
                changeStatusToInProgressItem.Enabled = false;
                changeStatusToCodeReviewItem.Enabled = false;
                changeStatusToMergedItem.Enabled = true;
                changeStatusToClosedItem.Enabled = true;
                changeStatusToDoneItem.Enabled = false;
            }
            else if (taskStatus == TaskStatus.MERGED)
            {
                changeStatusToInProgressItem.Enabled = false;
                changeStatusToCodeReviewItem.Enabled = false;
                changeStatusToMergedItem.Enabled = false;
                changeStatusToClosedItem.Enabled = false;
                changeStatusToDoneItem.Enabled = true;
            }
            else if (taskStatus == TaskStatus.CLOSED)
            {
                changeStatusToInProgressItem.Enabled = true;
                changeStatusToCodeReviewItem.Enabled = false;
                changeStatusToMergedItem.Enabled = false;
                changeStatusToClosedItem.Enabled = false;
                changeStatusToDoneItem.Enabled = false;
            }
            else
            {
                changeStatusToInProgressItem.Enabled = true;
                changeStatusToCodeReviewItem.Enabled = false;
                changeStatusToMergedItem.Enabled = false;
                changeStatusToClosedItem.Enabled = false;
                changeStatusToDoneItem.Enabled = false;
            }
        }

        private void fullTaskListView_CellContentClick(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                var hitTest = fullTaskListView.HitTest(e.X, e.Y);
                if (hitTest.RowIndex == -1)
                {
                    changeTaskStatusMenuItem.Enabled = false;
                    updateTaskMenuItem.Enabled = false;
                    deleteTaskMenuItem.Enabled = false;
                    return;
                }
                changeTaskStatusMenuItem.Enabled = true;
                updateTaskMenuItem.Enabled = true;
                deleteTaskMenuItem.Enabled = true;
                fullTaskListView.Rows[hitTest.RowIndex].Selected = true;
                SelectedTask = FullTaskListFormBusiness.selectTask(fullTaskListView);
                updateContextMenuItems();
                updateButtons();
            }
        }

        private void changeStatusToInProgressItem_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.IN_PROGRESS, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void changeStatusToCodeReviewItem_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.CODE_REVIEW, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void changeStatusToMergedItem_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.MERGED, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void changeStatusToClosedItem_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.CLOSED, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void changeStatusToDoneItem_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.DONE, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void startWorkingButton_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.IN_PROGRESS, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void codeReviewButton_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.CODE_REVIEW, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void mergeButton_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.MERGED, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.CLOSED, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            ShowedTasks = FullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(this, SelectedTask, TaskStatus.DONE, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text);
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            MainWindow.TaskList = ShowedTasks;
        }

        private void taskDeleteButton_Click(object sender, EventArgs e)
        {
            ConfirmAndDelete();
        }

        private void deleteTaskMenuItem_Click(object sender, EventArgs e)
        {
            ConfirmAndDelete();
        }

        private void ConfirmAndDelete()
        {
            DialogResult result = MessageBox.Show("Task will be deleted permanently! Do you want to proceed?", "Confirm delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (result == DialogResult.Yes)
            {
                TaskList = FullTaskListFormBusiness.deleteTaskAndRefreshTaskList(this, TaskList, fullTaskListView, out fullTaskListView, SelectedTask.Id, SelectedTask.Name, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
                MainWindow.TaskList = TaskList;
            }
        }

        private void updateTaskMenuItem_Click(object sender, EventArgs e)
        {
            EditTaskForm editTaskForm = new EditTaskForm(SelectedTask, MainWindow.User);
            DialogResult result = editTaskForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Task oldTask = editTaskForm.Task;
                Task newTask = editTaskForm.NewTask;
                FullTaskListFormBusiness.updateTaskAndRefreshList(this, oldTask, newTask, TaskList, fullTaskListView, out fullTaskListView, SearchTextBox.Text, StatusComboBox.SelectedText, PageNumber);
                TaskList = FullTaskListFormBusiness.GetAllTasks();
            }
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new AddTasksForm(MainWindow.User).ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            TaskList = FullTaskListFormBusiness.GetAllTasks();
            FullTaskListFormBusiness.RefreshTaskList(this, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
            updateButtons();
        }

        private void FullTaskListForm_Load(object sender, EventArgs e)
        {
            List<string> statuses = [""];
            if (TaskList.Count > DEFAULT_PAGE_SIZE)
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
                pageNumberTextBox.Enabled = true;
            }
            PageNumber = 1;
            pageNumberTextBox.Value = PageNumber;
            statuses = statuses.Concat(Enum.GetNames(typeof(TaskStatus))).ToList();
            StatusComboBox.DataSource = statuses;
            List<User> users = FullTaskListFormBusiness.GetAllUsers().FindAll(user => user.Id != UserId).ToList();
            if (users.Count == 0)
            {
                reassignToolStripMenuItem.Enabled = false;
            }
            else
            {
                reassignToolStripMenuItem.Enabled = true;
                users.ForEach(user =>
                {
                    reassignToolStripMenuItem.DropDownItems.Add(user.Name);
                });
                ToolStripItemCollection dropDownItems = reassignToolStripMenuItem.DropDown.Items;
                foreach (ToolStripItem item in dropDownItems)
                {
                    item.Click += reassignToUser_Click;
                }
            }
            FullTaskListFormBusiness.UpdateDeadlineFormatting(fullTaskListView, out fullTaskListView);
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
        }

        private void reassignToUser_Click(object sender, EventArgs e)
        {
            string username = ((ToolStripItem)sender).Text;
            try
            {
                FullTaskListFormBusiness.updateTaskAssigneeAndRefreshList(this, SelectedTask, username, TaskList, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
            }
            catch (UserNotFoundException)
            {
                MessageBox.Show(ErrorConst.USER_NOT_FOUND_ERROR_MESSAGE, ErrorConst.USER_NOT_FOUND_ERROR_CODE,
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SearchTextBox_TextChanged(object sender, EventArgs e)
        {
            PageNumber = 1;
            pageNumberTextBox.Value = PageNumber;
            ShowedTasks = FullTaskListFormBusiness.RefreshTaskList(this,
                fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
        }

        private void StatusComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            PageNumber = 1;
            pageNumberTextBox.Value = PageNumber;
            ShowedTasks = FullTaskListFormBusiness.RefreshTaskList(this,
                fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            UpdateTotalCountLabel();
        }

        private void toPreviousPageButton_Click(object sender, EventArgs e)
        {
            PageNumber = FullTaskListFormBusiness.TurnTaskListViewPage(this, UserId, SearchTextBox.Text, StatusComboBox.Text, PageNumber - 1);
            pageNumberTextBox.Value = PageNumber;
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            FullTaskListFormBusiness.RefreshTaskList(this, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
            UpdateTotalCountLabel();
        }

        private void toNextPageButton_Click(object sender, EventArgs e)
        {
            PageNumber = FullTaskListFormBusiness.TurnTaskListViewPage(this, UserId, SearchTextBox.Text, StatusComboBox.Text, PageNumber + 1);
            pageNumberTextBox.Value = PageNumber;
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            FullTaskListFormBusiness.RefreshTaskList(this, fullTaskListView, out fullTaskListView, StatusComboBox.Text, SearchTextBox.Text, PageNumber);
            totalCountLabel.Text = string.Format("Total count: {0}", TotalCount);
        }

        private void ToFirstPageButton_Click(object sender, EventArgs e)
        {

            PageNumber = FullTaskListFormBusiness.TurnTaskListViewPage(this, UserId, SearchTextBox.Text, StatusComboBox.Text, 1);
            pageNumberTextBox.Value = PageNumber;
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            FullTaskListFormBusiness.RefreshTaskList(this, fullTaskListView, out fullTaskListView, StatusComboBox.Text,
                SearchTextBox.Text, PageNumber);
            totalCountLabel.Text = string.Format("Total count: {0}", TotalCount);
        }

        private void toLastPageButton_Click(object sender, EventArgs e)
        {
            PageNumber = FullTaskListFormBusiness.TurnTaskListViewPage(this, UserId, SearchTextBox.Text, StatusComboBox.Text, TotalCount / DEFAULT_PAGE_SIZE + 1);
            pageNumberTextBox.Value = PageNumber;
            if (PageNumber * DEFAULT_PAGE_SIZE >= TotalCount)
            {
                toNextPageButton.Enabled = false;
                toLastPageButton.Enabled = false;
            }
            else
            {
                toNextPageButton.Enabled = true;
                toLastPageButton.Enabled = true;
            }
            if (PageNumber > 1)
            {
                toPreviousPageButton.Enabled = true;
                ToFirstPageButton.Enabled = true;
            }
            else
            {
                toPreviousPageButton.Enabled = false;
                ToFirstPageButton.Enabled = false;
            }
            FullTaskListFormBusiness.RefreshTaskList(this, fullTaskListView, out fullTaskListView, StatusComboBox.Text,
                SearchTextBox.Text, PageNumber);
            totalCountLabel.Text = string.Format("Total count: {0}", TotalCount);
        }

        private void UpdateTotalCountLabel()
        {
            totalCountLabel.Text = string.Format("Total count: {0}", TotalCount);
        }
    }
}
