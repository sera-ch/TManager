using TManager.error;
using TManager.util;
using Task = TManager.entity.Task;

namespace TManager
{
    public partial class EditTaskForm : Form
    {
        public Task Task { get; set; }
        public Task NewTask { get; set; }
        public EditTaskForm(Task SelectedTask)
        {
            Task = SelectedTask;
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
            try
            {
                string id = taskIdTextBox.Text;
                string name = taskNameTextBox.Text;
                TaskValidator.ValidateIdAndName(id, name);
                if (id != Task.Id || name != Task.Name)
                {
                    TaskValidator.ValidateExistingTask(id, name);
                }
                string? deadline = deadlineDatePicker.Text;
                TaskValidator.ValidateDeadline(deadline);
                string? assigned = Task.Assigned == null ? String.Empty : Task.Assigned.ToString();
                string? started = Task.Started == null ? String.Empty : Task.Started.ToString();
                string? prSent = Task.PrSent == null ? String.Empty : Task.PrSent.ToString();
                string? merged = Task.Merged == null ? String.Empty : Task.Merged.ToString();
                string? closed = Task.Closed == null ? String.Empty : Task.Closed.ToString();
                string? done = Task.Done == null ? String.Empty : Task.Done.ToString();
                string? status = Task.Status.ToString();
                string? note = noteTextBox.Text;
                NewTask = new Task(id,
                    name,
                    assigned!,
                    started!,
                    prSent!,
                    merged!,
                    closed!,
                    done!,
                    status!,
                    deadline!,
                    note!);
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
            Close();
        }
    }
}
