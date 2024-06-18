using Moq;
using NUnit.Framework.Internal;
using TManager.repository;
using TManager.service;
using TManager.service.dto;
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
            string newTaskId = "test_id_2";
            string taskName = "test_name";
            string newTaskName = "test_name_2";
            string date = DateUtil.Today().ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            User user = new User(userId, username);
            Task oldTask = new Task(taskId, taskName, date, date, date, date, date, date, status, date, note);
            Task task = new Task(newTaskId, newTaskName, date, date, date, date, date, date, status, date, note);
            task.User = user;

            // Act
            TaskService.UpdateTask(oldTask, task);

            // Assert
            TaskRepository.Verify(TaskRepository => TaskRepository.PartialUpdate(oldTask, task), Times.Once());
        }

        [Test(Description = "DeleteTask success")]
        public void DeleteTask_Success()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";

            // Act
            TaskService.DeleteTask(taskId, taskName);

            // Assert
            TaskRepository.Verify(TaskRepository => TaskRepository.Delete(taskId, taskName), Times.Once());
        }

        [Test(Description = "GetAllByUserIdPaged found should return page of tasks by user id")]
        public void GetAllByUserIdPaged_Found_ShouldReturnListOfTasksByUserId()
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
            List<Task> tasks = new List<Task>();
            for (int tid = 0; tid < 35; tid++)
            {
                Task task = new Task(taskId + tid, taskName, date, date, date, date, date, date, status, date, note);
                task.User = user;
                tasks.Add(task);
            }
            TaskRepository.Setup(taskRepository => taskRepository.GetAllByUserId(userId)).Returns(tasks);

            // Act
            Page<Task> actual = TaskService.GetAllTasksByUserIdPaged(userId, 1, 10);

            // Assert
            Assert.That(actual.PageSize, Is.EqualTo(10));
            Assert.That(actual.PageNumber, Is.EqualTo(1));
            Assert.That(actual.TotalCount, Is.EqualTo(35));
            for (int i = 0; i < 10; i++)
            {
                Assert.That(actual.Items[i].Id, Is.EqualTo(taskId + i));
            }
            TaskRepository.Verify(TaskRepository => TaskRepository.GetAllByUserId(userId), Times.Once());
        }

        [Test(Description = "GetAllByUserIdPaged found with page smaller than input size should return page of tasks by user id")]
        public void GetAllByUserIdPaged_Found_WithPageSmallerThanInputSize_ShouldReturnListOfTasksByUserId()
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
            List<Task> tasks = new List<Task>();
            for (int tid = 0; tid < 35; tid++)
            {
                Task task = new Task(taskId + tid, taskName, date, date, date, date, date, date, status, date, note);
                task.User = user;
                tasks.Add(task);
            }
            TaskRepository.Setup(taskRepository => taskRepository.GetAllByUserId(userId)).Returns(tasks);

            // Act
            Page<Task> actual = TaskService.GetAllTasksByUserIdPaged(userId, 4, 10);

            // Assert
            Assert.That(actual.PageSize, Is.EqualTo(5));
            Assert.That(actual.PageNumber, Is.EqualTo(4));
            Assert.That(actual.TotalCount, Is.EqualTo(35));
            for (int i = 30; i < 35; i++)
            {
                Assert.That(actual.Items[i - 30].Id, Is.EqualTo(taskId + i));
            }
            TaskRepository.Verify(TaskRepository => TaskRepository.GetAllByUserId(userId), Times.Once());
        }
    }
}
