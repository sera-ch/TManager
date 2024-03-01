﻿using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager
{
    public partial class FullTaskListForm : Form
    {
        public Task SelectedTask { get; set; }
        public List<Task> TaskList { get; set; }
        public FullTaskListForm()
        {
            InitializeComponent();
            List<Task> tasks = FileUtil.ReadFileToTaskList(MainWindow.SaveFile);
            TaskList = tasks;
            fullTaskListView.DataSource = TaskList;
            SelectedTask = null;
            startWorkingButton.Enabled = false;
            codeReviewButton.Enabled = false;
            mergeButton.Enabled = false;
            closeButton.Enabled = false;
            doneButton.Enabled = false;
            taskDeleteButton.Enabled = false;
        }

        private void fullTaskListView_SelectionChanged(object sender, EventArgs e)
        {
            if (fullTaskListView.SelectedRows.Count == 0 || fullTaskListView.SelectedRows == null)
            {
                return;
            }
            selectTask();
            updateButtons();
        }

        private void updateTaskStatusAndRefreshTaskList(TaskStatus newStatus)
        {
            SelectedTask.Status = newStatus;
            Task? updatedTask = TaskList.Find(task => task.Id == SelectedTask.Id && task.Name == SelectedTask.Name);
            if (updatedTask == null)
            {
                return;
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
            string updatedTaskStr = updatedTask.ToDataString();
            FileUtil.EditLine(MainWindow.SaveFile, updatedTask.GetSearchKey(), updatedTaskStr);
            RefreshTaskList();
            updateButtons();
        }

        private void selectTask()
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
            SelectedTask = new Task(id, name,
                assigned == null ? "" : assigned.Value.ToString(),
                started == null ? "" : started.Value.ToString(),
                prSent == null ? "" : prSent.Value.ToString(),
                merged == null ? "" : merged.Value.ToString(),
                closed == null ? "" : closed.Value.ToString(),
                done == null ? "" : done.Value.ToString(),
                status.ToString(),
                deadline.ToString(),
                note);
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
                selectTask();
                updateContextMenuItems();
            }
        }

        private void changeStatusToInProgressItem_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.IN_PROGRESS);
        }

        private void changeStatusToCodeReviewItem_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.CODE_REVIEW);
        }

        private void changeStatusToMergedItem_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.MERGED);
        }

        private void changeStatusToClosedItem_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.CLOSED);
        }

        private void changeStatusToDoneItem_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.DONE);
        }

        private void startWorkingButton_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.IN_PROGRESS);
        }

        private void codeReviewButton_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.CODE_REVIEW);
        }

        private void mergeButton_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.MERGED);
        }

        private void closeButton_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.CLOSED);
        }

        private void doneButton_Click(object sender, EventArgs e)
        {
            updateTaskStatusAndRefreshTaskList(TaskStatus.DONE);
        }

        private void taskDeleteButton_Click(object sender, EventArgs e)
        {
            ConfirmAndDelete();
        }

        private void deleteTaskAndRefreshTaskList(Task selectedTask)
        {
            FileUtil.DeleteLine(MainWindow.SaveFile, selectedTask.GetSearchKey());
            RefreshTaskList();
        }

        private void RefreshTaskList()
        {
            TaskList = FileUtil.ReadFileToTaskList(MainWindow.SaveFile);
            fullTaskListView.DataSource = TaskList;
            fullTaskListView.Refresh();
            MainWindow.TaskList = TaskList;
            if (TaskList.Count > 0)
            {
                SelectedTask = TaskList[0];
            }
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
                deleteTaskAndRefreshTaskList(SelectedTask);
            }
        }

        private void updateTaskMenuItem_Click(object sender, EventArgs e)
        {
            EditTaskForm editTaskForm = new EditTaskForm(SelectedTask);
            DialogResult result = editTaskForm.ShowDialog();
            if (result == DialogResult.OK)
            {
                Task oldTask = editTaskForm.Task;
                Task newTask = editTaskForm.NewTask;
                updateTaskAndRefreshList(oldTask, newTask);
            }
        }

        private void updateTaskAndRefreshList(Task oldTask, Task newTask)
        {
            string updatedTaskStr = newTask.ToDataString();
            FileUtil.EditLine(MainWindow.SaveFile, oldTask.GetSearchKey(), updatedTaskStr);
            RefreshTaskList();
            updateButtons();
        }

        private void addToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = new AddTasksForm().ShowDialog();
            if (result == DialogResult.Cancel)
            {
                return;
            }
            RefreshTaskList();
        }
    }
}