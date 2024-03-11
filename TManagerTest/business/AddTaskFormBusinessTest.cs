using Moq;
using TManager.business;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using User = TManager.entity.User;

namespace TManagerTest.business
{
    [TestFixture]
    public class AddTaskFormBusinessTest
    {
        private const int USER_ID = 1;
        private const string USER_NAME = "kim.mai";

        private AddTaskFormBusiness addTaskFormBusiness;
        private Mock<TaskService> taskService;
        private User User;

        [SetUp]
        public void setUp()
        {
            taskService = new Mock<TaskService>();
            User = new User(USER_ID, USER_NAME);
            addTaskFormBusiness = new AddTaskFormBusiness(taskService.Object, User);
        }

        [Test(Description = "AddTask success should save task")]
        public void AddTask_Success_ShouldSaveTask()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string deadline = DateUtil.Today().ToString();
            string note = "test_note";

            // Act
            addTaskFormBusiness.AddTask(taskId, taskName, deadline, note);

            // Assert
            taskService.Verify(taskService => taskService.SaveTask(It.Is<Task>(task =>
            task.Id == taskId &&
            task.Name == taskName &&
            task.Deadline.ToString() == deadline &&
            task.Note == note)));
        }

    }
}
