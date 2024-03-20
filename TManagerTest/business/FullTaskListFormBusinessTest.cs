using Moq;
using System.Windows.Forms;
using TManager.business;
using TManager.error;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;
using User = TManager.entity.User;

namespace TManagerTest.business
{
    [TestFixture]
    public class FullTaskListFormBusinessTest
    {
        private FullTaskListFormBusiness fullTaskListFormBusiness;
        private Mock<TaskService> taskService;
        private Mock<UserService> userService;
        private int userId = 1;

        [SetUp]
        public void setUp()
        {
            taskService = new Mock<TaskService>();
            userService = new Mock<UserService>();
            fullTaskListFormBusiness = new FullTaskListFormBusiness(userId, taskService.Object, userService.Object);
        }

        [Test(Description = "GetAllTasks not found should return empty list")]
        public void GetAllTasks_NotFound_ShouldReturnEmptyList()
        {
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(new List<Task>());

            // Act
            List<Task> actual = fullTaskListFormBusiness.GetAllTasks();

            // Assert
            Assert.That(actual, Is.Empty);
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "GetAllTasks found should return task list")]
        public void GetAllTasks_Found_ShouldReturnTaskList()
        {
            // Arrange
            Task task = createTask();
            List<Task> expected = new List<Task>() { task };
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(expected);

            // Act
            List<Task> actual = fullTaskListFormBusiness.GetAllTasks();

            // Assert
            Assert.That(actual, Is.EquivalentTo(expected));
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "SelectTask success should return selected task")]
        public void SelectTask_Success_ShouldReturnSelectedTask()
        {
            // Arrange
            Task expected = createTask();
            DataGridView taskListView = createTaskListView(new List<Task>() { expected });
            taskListView.Rows[0].Selected = true;

            // Act
            Task actual = fullTaskListFormBusiness.selectTask(taskListView);

            // Assert
            Assert.That(actual.Id, Is.EqualTo(expected.Id));
            Assert.That(actual.Name, Is.EqualTo(expected.Name));
            Assert.That(actual.Assigned, Is.EqualTo(expected.Assigned));
            Assert.That(actual.Started, Is.EqualTo(expected.Started));
            Assert.That(actual.PrSent, Is.EqualTo(expected.PrSent));
            Assert.That(actual.Merged, Is.EqualTo(expected.Merged));
            Assert.That(actual.Closed, Is.EqualTo(expected.Closed));
            Assert.That(actual.Done, Is.EqualTo(expected.Done));
            Assert.That(actual.Status, Is.EqualTo(expected.Status));
            Assert.That(actual.Deadline, Is.EqualTo(expected.Deadline));
            Assert.That(actual.Note, Is.EqualTo(expected.Note));
        }

        [Test(Description = "updateTaskStatusAndRefreshTaskList when task status is in progress should update task status and refresh task list")]
        public void updateTaskStatusAndRefreshTaskList_TaskStatusIsInProgress_ShouldUpdateTaskStatusAndRefreshTaskList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string note = "test_note";
            TaskStatus oldTaskStatus = TaskStatus.TODO;
            TaskStatus newTaskStatus = TaskStatus.IN_PROGRESS;
            Task task = new Task(taskId, taskName, date, "", "", "", "", "", oldTaskStatus.ToString(), date, note);
            DataGridView taskListView = createTaskListView(new List<Task>() { task });
            List<Task> taskList = new List<Task> { task };
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            List<Task> actual = fullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(task, newTaskStatus, new List<Task> { task }, taskListView, out taskListView, "", "");

            // Assert
            Assert.That(actual[0].Status, Is.EqualTo(newTaskStatus));
            Assert.That(actual[0].Started, Is.EqualTo(DateUtil.Today()));
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.Verify(taskService => taskService.UpdateTask(task, task));
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "updateTaskStatusAndRefreshTaskList when task status is code review should update task status and refresh task list")]
        public void updateTaskStatusAndRefreshTaskList_TaskStatusIsCodeReview_ShouldUpdateTaskStatusAndRefreshTaskList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string note = "test_note";
            TaskStatus oldTaskStatus = TaskStatus.IN_PROGRESS;
            TaskStatus newTaskStatus = TaskStatus.CODE_REVIEW;
            Task task = new Task(taskId, taskName, date, date, "", "", "", "", oldTaskStatus.ToString(), date, note);
            DataGridView taskListView = createTaskListView(new List<Task>() { task });
            List<Task> taskList = new List<Task> { task };
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            List<Task> actual = fullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(task, newTaskStatus, new List<Task> { task }, taskListView, out taskListView, "", "");

            // Assert
            Assert.That(actual[0].Status, Is.EqualTo(newTaskStatus));
            Assert.That(actual[0].PrSent, Is.EqualTo(DateUtil.Today()));
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.Verify(taskService => taskService.UpdateTask(task, task));
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "updateTaskStatusAndRefreshTaskList when task status is closed should update task status and refresh task list")]
        public void updateTaskStatusAndRefreshTaskList_TaskStatusIsClosed_ShouldUpdateTaskStatusAndRefreshTaskList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string note = "test_note";
            TaskStatus oldTaskStatus = TaskStatus.CODE_REVIEW;
            TaskStatus newTaskStatus = TaskStatus.CLOSED;
            Task task = new Task(taskId, taskName, date, date, date, "", "", "", oldTaskStatus.ToString(), date, note);
            DataGridView taskListView = createTaskListView(new List<Task>() { task });
            List<Task> taskList = new List<Task> { task };
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            List<Task> actual = fullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(task, newTaskStatus, new List<Task> { task }, taskListView, out taskListView, "", "");

            // Assert
            Assert.That(actual[0].Status, Is.EqualTo(newTaskStatus));
            Assert.That(actual[0].Closed, Is.EqualTo(DateUtil.Today()));
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.Verify(taskService => taskService.UpdateTask(task, task));
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "updateTaskStatusAndRefreshTaskList when task status is merged should update task status and refresh task list")]
        public void updateTaskStatusAndRefreshTaskList_TaskStatusIsMerged_ShouldUpdateTaskStatusAndRefreshTaskList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string note = "test_note";
            TaskStatus oldTaskStatus = TaskStatus.CODE_REVIEW;
            TaskStatus newTaskStatus = TaskStatus.MERGED;
            Task task = new Task(taskId, taskName, date, date, date, "", "", "", oldTaskStatus.ToString(), date, note);
            DataGridView taskListView = createTaskListView(new List<Task>() { task });
            List<Task> taskList = new List<Task> { task };
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            List<Task> actual = fullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(task, newTaskStatus, new List<Task> { task }, taskListView, out taskListView, "", "");

            // Assert
            Assert.That(actual[0].Status, Is.EqualTo(newTaskStatus));
            Assert.That(actual[0].Merged, Is.EqualTo(DateUtil.Today()));
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.Verify(taskService => taskService.UpdateTask(task, task));
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "updateTaskStatusAndRefreshTaskList when task status is done should update task status and refresh task list")]
        public void updateTaskStatusAndRefreshTaskList_TaskStatusIsDone_ShouldUpdateTaskStatusAndRefreshTaskList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string note = "test_note";
            TaskStatus oldTaskStatus = TaskStatus.CODE_REVIEW;
            TaskStatus newTaskStatus = TaskStatus.DONE;
            Task task = new Task(taskId, taskName, date, date, date, "", "", "", oldTaskStatus.ToString(), date, note);
            DataGridView taskListView = createTaskListView(new List<Task>() { task });
            List<Task> taskList = new List<Task> { task };
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            List<Task> actual = fullTaskListFormBusiness.updateTaskStatusAndRefreshTaskList(task, newTaskStatus, new List<Task> { task }, taskListView, out taskListView, "", "");

            // Assert
            Assert.That(actual[0].Status, Is.EqualTo(newTaskStatus));
            Assert.That(actual[0].Done, Is.EqualTo(DateUtil.Today()));
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once());
            taskService.Verify(taskService => taskService.UpdateTask(task, task));
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "Update task and refresh list success should update task and refresh list")]
        public void UpdateTaskAndRefreshList_Success_ShouldUpdateTaskAndRefreshList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string newTaskName = "test_name_2";
            string date = DateUtil.Yesterday().ToString();
            string newDate = DateUtil.Today().ToString();
            string note = "test_note";
            string newNote = "test_note_2";
            string oldTaskStatus = TaskStatus.TODO.ToString();
            string newTaskStatus = TaskStatus.IN_PROGRESS.ToString();
            Task oldTask = new Task(taskId, taskName, date, date, date, date, date, date, oldTaskStatus, date, note);
            Task newTask = new Task(taskId, newTaskName, newDate, newDate, newDate, newDate, newDate, newDate, newTaskStatus, newDate, newNote);
            List<Task> taskList = new List<Task> { oldTask };
            DataGridView taskListView = createTaskListView(taskList);
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            fullTaskListFormBusiness.updateTaskAndRefreshList(oldTask, newTask, taskList, taskListView, out taskListView, "", "");

            // Assert
            taskService.Verify(taskService => taskService.UpdateTask(oldTask, newTask), Times.Once);
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once);
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "updateTaskStatusAndRefreshTaskList success should delete task and refresh task list")]
        public void deleteAndRefreshTaskList_TaskStatusIsDone_ShouldDeleteTaskAndRefreshTaskList()
        {
            // Arrange
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string note = "test_note";
            string taskStatus = TaskStatus.CODE_REVIEW.ToString();
            Task task = new Task(taskId, taskName, date, date, date, date, date, date, taskStatus, date, note);
            DataGridView taskListView = createTaskListView(new List<Task>() { task });
            List<Task> taskList = new List<Task> { task };

            // Act
            List<Task> actual = fullTaskListFormBusiness.deleteTaskAndRefreshTaskList(taskList, taskListView, out taskListView, taskId, "", "");

            // Assert
            Assert.That(actual, Is.Empty);
            taskService.Verify(taskService => taskService.DeleteTask(taskId), Times.Once);
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once);
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "getAllUsers when not found should return empty list")]
        public void GetAllUsers_WhenNotFound_ShouldReturnEmptyList()
        {
            // Arrange
            userService.Setup(UserService => UserService.GetAllUsers()).Returns(new List<User>());

            // Act
            List<User> actual = fullTaskListFormBusiness.GetAllUsers();

            // Assert
            Assert.That(actual, Is.Empty);
            userService.Verify(UserService => UserService.GetAllUsers(), Times.Once());
        }

        [Test(Description = "getAllUsers when not found should return empty list")]
        public void GetAllUsers_WhenFound_ShouldReturnUsers()
        {
            // Arrange
            int userId = 1;
            string username = "e.kim.mai";
            User user = new User(userId, username);
            userService.Setup(UserService => UserService.GetAllUsers()).Returns(new List<User>() { user });

            // Act
            List<User> actual = fullTaskListFormBusiness.GetAllUsers();

            // Assert
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual[0], Is.EqualTo(user));
            userService.Verify(UserService => UserService.GetAllUsers(), Times.Once());
        }

        [Test(Description = "Update task asignee and refresh list when user is not found should throw UserNotFoundException")]
        public void UpdateTaskAssigneeAndRefreshList_WhenUserIsNotFound_ShouldThrowUserNotFoundException()
        {
            // Arrange
            string newUsername = "e.quyen.hoang";
            string taskId = "test_id";
            string taskName = "test_name";
            string newTaskName = "test_name_2";
            string date = DateUtil.Yesterday().ToString();
            string newDate = DateUtil.Today().ToString();
            string note = "test_note";
            string newNote = "test_note_2";
            string taskStatus = TaskStatus.TODO.ToString();
            Task task1 = new Task(taskId, taskName, date, date, date, date, date, date, taskStatus, date, note);
            Task task2 = new Task(taskId, newTaskName, newDate, newDate, newDate, newDate, newDate, newDate, taskStatus, newDate, newNote);
            List<Task> taskList = new List<Task> { task1, task2 };
            DataGridView taskListView = createTaskListView(taskList);
            userService.Setup(userService => userService.GetUserByUsername(newUsername)).Returns((User)null);
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act and Assert
            Assert.Throws(typeof(UserNotFoundException), () => fullTaskListFormBusiness.updateTaskAssigneeAndRefreshList(task1, newUsername, taskList, taskListView, out taskListView, "", ""));
            userService.Verify(UserService => UserService.GetUserByUsername(newUsername), Times.Once());
            taskService.VerifyNoOtherCalls();
        }

        [Test(Description = "Update task asignee and refresh list success should update task assignee and refresh list")]
        public void UpdateTaskAssigneeAndRefreshList_Success_ShouldUpdateTaskAssigneeAndRefreshList()
        {
            // Arrange
            int newUserId = 1;
            string newUsername = "e.quyen.hoang";
            User newUser = new User(newUserId, newUsername);
            string taskId = "test_id";
            string taskName = "test_name";
            string newTaskName = "test_name_2";
            string date = DateUtil.Yesterday().ToString();
            string newDate = DateUtil.Today().ToString();
            string note = "test_note";
            string newNote = "test_note_2";
            string taskStatus = TaskStatus.TODO.ToString();
            Task task1 = new Task(taskId, taskName, date, date, date, date, date, date, taskStatus, date, note);
            Task task2 = new Task(taskId, newTaskName, newDate, newDate, newDate, newDate, newDate, newDate, taskStatus, newDate, newNote);
            List<Task> taskList = new List<Task> { task1, task2 };
            DataGridView taskListView = createTaskListView(taskList);
            userService.Setup(userService => userService.GetUserByUsername(newUsername)).Returns(newUser);
            taskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(taskList);

            // Act
            fullTaskListFormBusiness.updateTaskAssigneeAndRefreshList(task1, newUsername, taskList, taskListView, out taskListView, "", "");

            // Assert
            userService.Verify(UserService => UserService.GetUserByUsername(newUsername), Times.Once());
            taskService.Verify(taskService => taskService.UpdateTask(It.IsAny<Task>(), It.IsAny<Task>()), Times.Once);
            taskService.Verify(taskService => taskService.GetAllTasksByUserId(userId), Times.Once);
            taskService.VerifyNoOtherCalls();
        }

        private Task createTask()
        {
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
            return task;
        }

        private DataGridView createTaskListView(List<Task> tasks)
        {
            DataGridView taskListView = new DataGridView();
            taskListView.Columns.Add("Id", "Id");
            taskListView.Columns.Add("Name", "Name");
            taskListView.Columns.Add("Assigned", "Assigned");
            taskListView.Columns.Add("Started", "Started");
            taskListView.Columns.Add("PrSent", "PrSent");
            taskListView.Columns.Add("Merged", "Merged");
            taskListView.Columns.Add("Closed", "Closed");
            taskListView.Columns.Add("Done", "Done");
            taskListView.Columns.Add("Status", "Status");
            taskListView.Columns.Add("Deadline", "Deadline");
            taskListView.Columns.Add("Note", "Note");
            tasks.ForEach(task =>
            taskListView.Rows.Add(task.Id,
                task.Name,
                task.Assigned,
                task.Started,
                task.PrSent,
                task.Merged,
                task.Closed,
                task.Done,
                task.Status,
                task.Deadline,
                task.Note)
            );
            return taskListView;
        }
    }
}
