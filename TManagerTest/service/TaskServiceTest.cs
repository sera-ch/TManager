using Moq;
using NUnit.Framework.Internal;
using TManager.repository;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;
using User = TManager.entity.User;

namespace TManager.test
{
    [TestFixture]
    public class TaskServiceTest
    {
        private TaskService TaskService;
        private Mock<TaskRepository> TaskRepository;

        [SetUp]
        public void SetUp()
        {
            TaskRepository = new Mock<TaskRepository>();
            TaskService = new TaskServiceImpl(TaskRepository.Object);
        }

        [Test(Description = "GetAllByUserId not found should return empty list")]
        public void GetAllByUserId_NotFound_ShouldReturnEmptyList()
        {
            // Arrange
            int userId = 1;
            TaskRepository.Setup(taskRepository => taskRepository.GetAllByUserId(userId)).Returns(new List<Task>());

            // Act
            List<Task> actual = TaskService.GetAllTasksByUserId(userId);

            // Assert
            Assert.That(actual, Is.Empty);
            TaskRepository.Verify(TaskRepository => TaskRepository.GetAllByUserId(userId), Times.Once());
        }

        [Test(Description = "GetAllByUserId found should return list of tasks by user id")]
        public void GetAllByUserId_Found_ShouldReturnListOfTasksByUserId()
        {
            // Arrange
            int userId = 1;
            string username = "abc@gmail.com";
            string taskId = "test_id";
            string taskId2 = "test_id_2";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            User user = new User(userId, username);
            Task task = new Task(taskId, taskName, date, date, date, date, date, date, status, date, note);
            Task task2 = new Task(taskId2, taskName, date, date, date, date, date, date, status, date, note);
            task.User = user;
            task2.User = user;
            TaskRepository.Setup(taskRepository => taskRepository.GetAllByUserId(userId)).Returns(new List<Task> { task, task2 });

            // Act
            List<Task> actual = TaskService.GetAllTasksByUserId(userId);

            // Assert
            Assert.That(actual.Count, Is.EqualTo(2));
            TaskRepository.Verify(TaskRepository => TaskRepository.GetAllByUserId(userId), Times.Once());
        }

        [Test(Description = "SaveTask success should return task")]
        public void SaveTask_Success_ShouldReturnTask()
        {
            // Arrange
            int userId = 1;
            string username = "abc@gmail.com";
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            User user = new User(userId, username);
            Task task = new Task(taskId, taskName, date, date, date, date, date, date, status, date, note);
            task.User = user;
            TaskRepository.Setup(TaskRepository => TaskRepository.Save(task)).Returns(task);

            // Act
            Task actual = TaskService.SaveTask(task);

            // Assert
            Assert.That(actual, Is.EqualTo(task));
            TaskRepository.Verify(TaskRepository => TaskRepository.Save(task), Times.Once());
        }

        [Test(Description = "Update task success")]
        public void UpdateTask_Success()
        {
            // Arrange
            int userId = 1;
            string username = "abc@gmail.com";
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            User user = new User(userId, username);
            Task task = new Task(taskId, taskName, date, date, date, date, date, date, status, date, note);
            task.User = user;

            // Act
            TaskService.UpdateTask(taskId, task);

            // Assert
            TaskRepository.Verify(TaskRepository => TaskRepository.PartialUpdate(taskId, task), Times.Once());
        }

        [Test(Description = "DeleteTask success")]
        public void DeleteTask_Success()
        {
            // Arrange
            string taskId = "test_id";

            // Act
            TaskService.DeleteTask(taskId);

            // Assert
            TaskRepository.Verify(TaskRepository => TaskRepository.Delete(taskId), Times.Once());
        }
    }
}
