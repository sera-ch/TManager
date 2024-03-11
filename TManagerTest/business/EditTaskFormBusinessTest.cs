using Moq;
using TManager.business;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;
using User = TManager.entity.User;

namespace TManagerTest.business
{
    [TestFixture]
    public class EditTaskFormBusinessTest
    {
        private EditTaskFormBusiness editTaskFormBusiness;
        private Mock<TaskService> taskService;
        private User user;
        private Task task;

        [SetUp]
        public void setUp()
        {
            int userId = 1;
            string userName = "test_user_name";
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            taskService = new Mock<TaskService>();
            user = new User(userId, userName);
            task = new Task(taskId, taskName, date, date, date, date, date, date, status, date, note);
            editTaskFormBusiness = new EditTaskFormBusiness(taskService.Object, user, task);
        }

        [Test(Description = "EditTask when id changed should edit task")]
        public void EditTask_WhenIdChanged_ShouldEditTask()
        {
            // Arrange
            string newId = "test_id_2";
            string newName = "test_name_2";
            string newDate = DateUtil.Tomorrow().ToString();
            string newNote = "test_note_2";

            // Act
            Task actual = editTaskFormBusiness.EditTask(newId, newName, newDate, newNote);

            // Assert
            Assert.That(actual.Id, Is.EqualTo(newId));
            Assert.That(actual.Name, Is.EqualTo(newName));
            Assert.That(actual.Deadline.ToString(), Is.EqualTo(newDate));
            Assert.That(actual.Note, Is.EqualTo(newNote));
            taskService.Verify(taskService => taskService.UpdateTask(task.Id, It.Is<Task>(t =>
            t.Id == newId &&
            t.Name == newName &&
            t.Deadline.ToString() == newDate &&
            t.Note == newNote)));
        }

        [Test(Description = "EditTask when name changed should edit task")]
        public void EditTask_WhenNameChanged_ShouldEditTask()
        {
            // Arrange
            string newName = "test_name_2";
            string newDate = DateUtil.Tomorrow().ToString();
            string newNote = "test_note_2";

            // Act
            Task actual = editTaskFormBusiness.EditTask(task.Id, newName, newDate, newNote);

            // Assert
            Assert.That(actual.Id, Is.EqualTo(task.Id));
            Assert.That(actual.Name, Is.EqualTo(newName));
            Assert.That(actual.Deadline.ToString(), Is.EqualTo(newDate));
            Assert.That(actual.Note, Is.EqualTo(newNote));
            taskService.Verify(taskService => taskService.UpdateTask(task.Id, It.Is<Task>(t =>
            t.Id == task.Id &&
            t.Name == newName &&
            t.Deadline.ToString() == newDate &&
            t.Note == newNote)));
        }

        [Test(Description = "EditTask when id and name not changed should edit task")]
        public void EditTask_WhenIdAndNameNotChanged_ShouldEditTask()
        {
            // Arrange
            string newDate = DateUtil.Tomorrow().ToString();
            string newNote = "test_note_2";

            // Act
            Task actual = editTaskFormBusiness.EditTask(task.Id, task.Name, newDate, newNote);

            // Assert
            Assert.That(actual.Id, Is.EqualTo(task.Id));
            Assert.That(actual.Name, Is.EqualTo(task.Name));
            Assert.That(actual.Deadline.ToString(), Is.EqualTo(newDate));
            Assert.That(actual.Note, Is.EqualTo(newNote));
            taskService.Verify(taskService => taskService.UpdateTask(task.Id, It.Is<Task>(t =>
            t.Id == task.Id &&
            t.Name == task.Name &&
            t.Deadline.ToString() == newDate &&
            t.Note == newNote)));
        }

    }
}
