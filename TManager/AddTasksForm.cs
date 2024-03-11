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

<<<<<<< HEAD
        private AddTaskFormBusiness addTaskFormBusiness;
        public User User { get; set; }
        public Task Response { get; set; }
        public AddTasksForm(User user)
=======
        private TaskService taskService = new TaskServiceImpl(new TaskRepository());
        public AddTasksForm()
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
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
<<<<<<< HEAD
                newTask = addTaskFormBusiness.AddTask(taskIdTextBox.Text, taskNameTextBox.Text, deadlineDatePicker.Text, noteTextBox.Text);
=======
                string id = taskIdTextBox.Text;
                string name = taskNameTextBox.Text;
                TaskValidator.ValidateIdAndName(id, name);
                TaskValidator.ValidateExistingTask(id, name);
                string deadline = deadlineDatePicker.Text;
                TaskValidator.ValidateDeadline(deadline);
                string assigned = DateUtil.Today().ToString();
                string note = noteTextBox.Text;
                Task newTask = new Task(id, name, assigned, "", "", "", "", "", TaskStatus.TODO.ToString(), deadline, note);
                newTask.User = MainWindow.User;
                MainWindow.TaskList.Add(newTask);
                taskService.SaveTask(newTask);
>>>>>>> 0e502141f256c07c2be5b5ff8b667f906c62e2c9
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
