﻿using TManager.error;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManager
{
    public partial class AddTasksForm : Form
    {
        public AddTasksForm()
        {
            InitializeComponent();
        }

        private void deadlineDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            try
            {
                string id = taskIdTextBox.Text;
                string name = taskNameTextBox.Text;
                TaskValidator.ValidateIdAndName(id, name);
                TaskValidator.ValidateExistingTask(id, name);
                string deadline = deadlineDatePicker.Text;
                TaskValidator.ValidateDeadline(deadline);
                string assigned = DateUtil.Today().ToString();
                string note = noteTextBox.Text;
                Task newTask = new Task(id, name, assigned, "", "", "", "", "", TaskStatus.TODO.ToString(), deadline, note);
                MainWindow.TaskList.Add(newTask);
                FileUtil.WriteTaskToFile(MainWindow.SaveFile, newTask);
            }
            catch (InvalidIdOrNameException)
            {
                MessageBox.Show(ErrorConst.INVALID_ID_NAME_ERROR_MESSAGE, ErrorConst.INVALID_ID_NAME_ERROR_CODE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (DuplicateTaskException)
            {
                MessageBox.Show(ErrorConst.DUPLICATE_TASK_ERROR_MESSAGE, ErrorConst.DUPLICATE_TASK_ERROR_CODE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (InvalidDeadlineException)
            {
                MessageBox.Show(ErrorConst.INVALID_DEADLINE_ERROR_MESSAGE, ErrorConst.INVALID_DEADLINE_ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
