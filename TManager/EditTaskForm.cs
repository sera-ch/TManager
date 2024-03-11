using TManager.business;
using TManager.error;
using TManager.repository;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using User = TManager.entity.User;

namespace TManager
{
    public partial class EditTaskForm : Form
    {
        public Task Task { get; set; }
        public Task NewTask { get; set; }
        public User User { get; set; }
        private EditTaskFormBusiness editTaskFormBusiness;
        public EditTaskForm(Task SelectedTask, User user)
        {
            Task = SelectedTask;
            User = user;
            editTaskFormBusiness = new EditTaskFormBusiness(new TaskServiceImpl(new TaskRepository()), User, SelectedTask);
            InitializeComponent();
            GetTaskAttributes();
        }

        private void GetTaskAttributes()
        {
            taskIdTextBox.Text = Task.Id;
            taskNameTextBox.Text = Task.Name;
            deadlineDatePicker.Value = DateUtil.ToEndOfDay(Task.Deadline);
            noteTextBox.Text = Task.Note;
        }

        private void saveTaskButton_Click(object sender, EventArgs e)
        {
            Task? newTask = null;
            try
            {
                newTask = editTaskFormBusiness.EditTask(taskIdTextBox.Text, taskNameTextBox.Text, deadlineDatePicker.Text, noteTextBox.Text);
            }
            catch (InvalidIdOrNameException)
            {
                MessageBox.Show(ErrorConst.INVALID_ID_NAME_ERROR_MESSAGE, ErrorConst.INVALID_ID_NAME_ERROR_CODE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (InvalidDeadlineException)
            {
                MessageBox.Show(ErrorConst.INVALID_DEADLINE_ERROR_MESSAGE, ErrorConst.INVALID_DEADLINE_ERROR_MESSAGE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            catch (DuplicateTaskException)
            {
                MessageBox.Show(ErrorConst.DUPLICATE_TASK_ERROR_MESSAGE, ErrorConst.DUPLICATE_TASK_ERROR_CODE, MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            DialogResult = DialogResult.OK;
            NewTask = newTask;
            Close();
        }
    }
}
