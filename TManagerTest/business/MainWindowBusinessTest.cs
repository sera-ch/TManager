﻿using Moq;
using System.Drawing;
using System.Windows.Forms;
using TManager.business;
using TManager.entity;
using TManager.service;
using TManager.service.dto;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManagerTest.business
{
    [TestFixture]
    public class MainWindowBusinessTest
    {
        private Mock<UserService> UserService;
        private Mock<TaskService> TaskService;
        private Mock<FileUtil> FileUtil;
        private MainWindowBusiness MainWindowBusiness;

        [SetUp]
        public void SetUp()
        {
            UserService = new Mock<UserService>();
            TaskService = new Mock<TaskService>();
            FileUtil = new Mock<FileUtil>();
            MainWindowBusiness = new MainWindowBusiness(UserService.Object, TaskService.Object, FileUtil.Object);
        }

        [Test(Description = "InitiateTaskListView success should output taskListView")]
        public void InitializeTaskListView_Success_ShouldOutputTaskListView()
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
            DataGridView taskListView = new DataGridView();
            List<Task> oldTaskList = new List<Task>();
            taskListView.DataSource = oldTaskList;
            List<Task> newTaskList = new List<Task> { task, task2 };
            TaskService.Setup(TaskService => TaskService.GetAllTasksByUserIdPaged(userId, 1, 20))
                .Returns(Page<Task>.of(newTaskList, 1, 20));

            // Act
            MainWindowBusiness.InitiateTaskListView(userId, taskListView, out oldTaskList, out taskListView);

            // Assert
            Assert.That(oldTaskList.Count, Is.EqualTo(2));
            Assert.That(((List<TaskView>)taskListView.DataSource).Count, Is.EqualTo(newTaskList.Count));
        }

        [Test(Description = "UpdateDeadlineFormatting success should update deadline formatting")]
        public void UpdateDeadlineFormatting_Success_ShouldUpdateDeadlineFormatting()
        {
            // Arrange
            string taskId = "test_id";
            string taskId2 = "test_id_2";
            string taskName = "test_name";
            string dateYesterday = DateUtil.Yesterday().ToString();
            string dateToday = DateUtil.Today().ToString();
            string dateTomorrow = DateUtil.Tomorrow().ToString();
            string dateAfterTomorrow = DateUtil.Today().AddDays(7).ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            DataGridView taskListView = new DataGridView();
            taskListView.Columns.Add("Task", "Task");
            taskListView.Columns.Add("Status", "Status");
            taskListView.Columns.Add("Deadline", "Deadline");
            taskListView.Columns.Add("Note", "Note");
            Task overdueTask = new Task(taskId, taskName, dateYesterday, dateYesterday, dateYesterday, dateYesterday, dateYesterday, dateYesterday, status, dateYesterday, note);
            Task dueTodayTask = new Task(taskId, taskName, dateToday, dateToday, dateToday, dateToday, dateToday, dateToday, status, dateToday, note);
            Task dueTomorrowTask = new Task(taskId2, taskName, dateTomorrow, dateTomorrow, dateTomorrow, dateTomorrow, dateTomorrow, dateTomorrow, status, dateTomorrow, note);
            Task dueAfterTomorrowTask = new Task(taskId, taskName, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, status, dateAfterTomorrow, note);
            Task inReviewTask = new Task(taskId, taskName, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, TaskStatus.CODE_REVIEW.ToString(), dateAfterTomorrow, note);
            List<TaskView> taskViews = new List<Task> { dueTodayTask, dueTomorrowTask, dueAfterTomorrowTask, overdueTask, inReviewTask }
                .Select(TaskView.From)
                .ToList();
            taskViews.ForEach(view => taskListView.Rows.Add(view.Task, view.Status, view.Deadline, view.Note));

            // Act
            MainWindowBusiness.UpdateDeadlineFormatting(taskListView, out taskListView);

            // Assert
            Assert.That(taskListView.Rows[0].Cells[2].Style.BackColor, Is.EqualTo(Color.Red));
            Assert.That(taskListView.Rows[0].Cells[2].Style.ForeColor, Is.EqualTo(Color.White));
            Assert.That(taskListView.Rows[1].Cells[2].Style.BackColor, Is.EqualTo(Color.Orange));
            Assert.That(taskListView.Rows[2].Cells[2].Style.BackColor, Is.EqualTo(Color.Empty));
            Assert.That(taskListView.Rows[3].Cells[2].Style.BackColor, Is.EqualTo(Color.Red));
            Assert.That(taskListView.Rows[3].Cells[2].Style.ForeColor, Is.EqualTo(Color.White));
            Assert.That(taskListView.Rows[4].Cells[2].Style.BackColor, Is.EqualTo(Color.Empty));
        }

        [Test(Description = "WelcomeMessage success should return welcome message")]
        public void WelcomeMessage_Success_ShouldReturnWelcomeMessage()
        {
            // Arrange
            string username = "e.kim.m";
            string taskId = "test_id";
            string taskId2 = "test_id_2";
            string taskName = "test_name";
            string dateYesterday = DateUtil.Yesterday().ToString();
            string dateToday = DateUtil.Today().ToString();
            string dateTomorrow = DateUtil.Tomorrow().ToString();
            string dateAfterTomorrow = DateUtil.Today().AddDays(7).ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            Task overdueTask = new Task(taskId, taskName, dateYesterday, dateYesterday, dateYesterday, dateYesterday, dateYesterday, dateYesterday, status, dateYesterday, note);
            Task dueTodayTask = new Task(taskId, taskName, dateToday, dateToday, dateToday, dateToday, dateToday, dateToday, status, dateToday, note);
            Task dueTomorrowTask = new Task(taskId2, taskName, dateTomorrow, dateTomorrow, dateTomorrow, dateTomorrow, dateTomorrow, dateTomorrow, status, dateTomorrow, note);
            Task dueAfterTomorrowTask = new Task(taskId, taskName, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, status, dateAfterTomorrow, note);
            Task inReviewTask = new Task(taskId, taskName, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, dateAfterTomorrow, TaskStatus.CODE_REVIEW.ToString(), dateAfterTomorrow, note);
            List<Task> tasks = new List<Task> { dueTodayTask, dueTomorrowTask, dueAfterTomorrowTask, overdueTask, inReviewTask };
            string welcomeMessage = "Welcome " + username + "! Today is " +
                DateUtil.Today().ToString() + ".\n" +
                "You have 1 task(s) due today\n" +
                "You have 1 task(s) due tomorrow\n" +
                "You have 1 task(s) overdue\n" +
                "You have 1 task(s) in review.";

            // Act
            string actual = MainWindowBusiness.WelcomeMessage(tasks, username);

            // Assert
            Assert.That(actual, Is.EqualTo(welcomeMessage));
        }

        [Test(Description = "RefreshTaskListView success should update data source")]
        public void RefreshTaskListView_Success_ShouldUpdateDataSource()
        {
            // Arrange
            int userId = 1;
            string username = "abc@gmail.com";
            string taskId = "test_id";
            string taskName = "test_name";
            string date = DateUtil.Today().ToString();
            string status = TaskStatus.IN_PROGRESS.ToString();
            string note = "test_note";
            int pageNumber = 1;
            User user = new User(userId, username);
            Task task = new Task(taskId, taskName, date, date, date, date, date, date, status, date, note);
            task.User = user;
            List<Task> taskList = new List<Task> { task };
            DataGridView taskListView = new DataGridView();
            TaskService.Setup(TaskService => TaskService.GetAllTasksByUserIdPaged(userId, 1, 20))
                .Returns(Page<Task>.of(taskList, 1, 20));

            // Act
            MainWindowBusiness.RefreshTaskListView(userId, taskListView, out taskListView, pageNumber);

            // Assert
            Assert.That(taskListView.DataSource, Is.Not.Null);
            TaskService.Verify(TaskService => TaskService.GetAllTasksByUserIdPaged(userId, 1, 20), Times.Once());
        }
    }
}
