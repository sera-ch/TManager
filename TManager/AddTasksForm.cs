using TManager.business;
using TManager.error;
using TManager.repository;
using TManager.service;
using Task = TManager.entity.Task;
using User = TManager.entity.User;

namespace TManager
{
    public partial class AddTasksForm : Form
    {

        private AddTaskFormBusiness addTaskFormBusiness;
        public User User { get; set; }
        public Task Response { get; set; }
        public AddTasksForm(User user)
        {
            this.User = user;
            addTaskFormBusiness = new AddTaskFormBusiness(new TaskServiceImpl(new TaskRepository()), User);
            InitializeComponent();
        }

        private void deadlineDatePicker_ValueChanged(object sender, EventArgs e)
        {

        }

        private void addTaskButton_Click(object sender, EventArgs e)
        {
            Task? newTask = null;
            try
            {
                newTask = addTaskFormBusiness.AddTask(taskIdTextBox.Text, taskNameTextBox.Text, deadlineDatePicker.Text, noteTextBox.Text);
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
            this.Response = newTask;
            this.Close();
        }
    }
}
