using Moq;
using TManager.business;
using TManager.service;
using TManager.util;
using Task = TManager.entity.Task;
using TaskStatus = TManager.entity.TaskStatus;

namespace TManagerTest.business
{
    [TestFixture]
    public class GenerateDailyReportFormBusinessTest
    {

        private GenerateDailyReportFormBusiness GenerateDailyReportFormBusiness;
        private Mock<TaskService> TaskService;

        [SetUp]
        public void SetUp()
        {
            TaskService = new Mock<TaskService>();
            GenerateDailyReportFormBusiness = new GenerateDailyReportFormBusiness(TaskService.Object);
        }

        [Test(Description = "GenerateDailyReport success should return daily report")]
        public void GenerateDailyReport_Success_ShouldReturnDailyReport()
        {
            // Arrange
            string taskId1 = "test_id_1";
            string taskId2 = "test_id_2";
            string taskId3 = "test_id_3";
            string taskId4 = "test_id_4";
            string taskId5 = "test_id_5";
            string taskId6 = "test_id_6";
            string taskName = "test_name";
            string dateYesterday = DateUtil.Yesterday().ToString();
            string dateToday = DateUtil.Today().ToString();
            string deadline = DateUtil.Today().AddDays(7).ToString();
            string note = "test_note";
            int userId = 1;
            // PR sent yesterday, not merged yet
            Task prSentTask1 = new Task(taskId1, taskName, dateYesterday, dateYesterday, dateYesterday, "", "", "", TaskStatus.CODE_REVIEW.ToString(), deadline, note);
            // PR sent yesterday, merged today
            Task prSentTask2 = new Task(taskId2, taskName, dateYesterday, dateYesterday, dateYesterday, dateToday, "", "", TaskStatus.MERGED.ToString(), deadline, note);
            // Merged yesterday
            Task mergedTask = new Task(taskId3, taskName, dateYesterday, dateYesterday, dateYesterday, dateYesterday, "", "", TaskStatus.MERGED.ToString(), deadline, note);
            // Started yesterday and not PR sent yet
            Task inProgressTask1 = new Task(taskId3, taskName, dateYesterday, dateYesterday, "", "", "", "", TaskStatus.IN_PROGRESS.ToString(), deadline, note);
            // Started yesterday and PR sent today
            Task inProgressTask2 = new Task(taskId4, taskName, dateYesterday, dateYesterday, dateToday, "", "", "", TaskStatus.CODE_REVIEW.ToString(), deadline, note);
            // Status TODO
            Task todoTask1 = new Task(taskId5, taskName, dateYesterday, "", "", "", "", "", TaskStatus.TODO.ToString(), deadline, note);
            // Started today
            Task todoTask2 = new Task(taskId6, taskName, dateYesterday, dateToday, "", "", "", "", TaskStatus.IN_PROGRESS.ToString(), deadline, note);
            List<Task> tasks = new List<Task> { prSentTask1, prSentTask2, mergedTask, inProgressTask1, inProgressTask2, todoTask1, todoTask2 };
            string expected = "DONE:\n" +
                "• test_id_1 test_name (PR sent)\n" +
                "• test_id_2 test_name (PR sent)\n" +
                "• test_id_3 test_name (Merged)\n" +
                "IN PROGRESS:\n" +
                "• test_id_3 test_name\n" +
                "• test_id_4 test_name\n" +
                "• test_id_1 test_name (Fix comments)\n" +
                "• test_id_2 test_name (Fix comments)\n" +
                "TODO:\n" +
                "• test_id_5 test_name\n" +
                "• test_id_6 test_name";
            TaskService.Setup(taskService => taskService.GetAllTasksByUserId(userId)).Returns(tasks);

            // Act
            string actual = GenerateDailyReportFormBusiness.GenerateDailyReport(userId, DateUtil.Today());

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
