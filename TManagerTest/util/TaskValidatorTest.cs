using Moq;
using TManager.error;
using TManager.service;
using TManager.util;

namespace TManagerTest.util
{
    [TestFixture]
    public class TaskValidatorTest
    {
        private TaskValidator taskValidator;
        private Mock<TaskService> taskService;

        [SetUp]
        public void setUp()
        {
            taskService = new Mock<TaskService>();
            taskValidator = new TaskValidator(taskService.Object);
        }

        [Test(Description = "ValidateIdAndName when id is empty should throw InvalidIdOrNameException")]
        public void ValidateIdAndName_WhenIdIsEmpty_ShouldThrowInvalidIdOrNameException()
        {
            // Arrange
            string id = "";
            string name = "test_name";

            // Act and Assert
            Assert.Throws(typeof(InvalidIdOrNameException), () => taskValidator.ValidateIdAndName(id, name));
        }

        [Test(Description = "ValidateIdAndName when name is empty should throw InvalidIdOrNameException")]
        public void ValidateIdAndName_WhenNameIsEmpty_ShouldThrowInvalidIdOrNameException()
        {
            // Arrange
            string id = "test_id";
            string name = "";

            // Act and Assert
            Assert.Throws(typeof(InvalidIdOrNameException), () => taskValidator.ValidateIdAndName(id, name));
        }

        [Test(Description = "ValidateIdAndName when id and name are not empty should not throw InvalidIdOrNameException")]
        public void ValidateIdAndName_WhenIdAndNameAreNotEmpty_ShouldNotThrowInvalidIdOrNameException()
        {
            // Arrange
            string id = "test_id";
            string name = "test_name";

            // Act and Assert
            Assert.DoesNotThrow(() => taskValidator.ValidateIdAndName(id, name));
        }

        [Test(Description = "ValidateDeadline when deadline is before today should throw InvalidDeadlineException")]
        public void ValidateDeadline_WhenDeadlineIsBeforeToday_ShouldThrowInvalidDeadlineException()
        {
            // Arrange
            string deadline = DateUtil.Yesterday().ToString();

            // Act and Assert
            Assert.Throws(typeof(InvalidDeadlineException), () => taskValidator.ValidateDeadline(deadline));
        }

        [Test(Description = "ValidateDeadline when deadline is after today should not throw InvalidDeadlineException")]
        public void ValidateDeadline_WhenDeadlineIsAfterToday_ShouldNotThrowInvalidDeadlineException()
        {
            // Arrange
            string deadline = DateUtil.Tomorrow().ToString();

            // Act and Assert
            Assert.DoesNotThrow(() => taskValidator.ValidateDeadline(deadline));
        }

        [Test(Description = "ValidateExistingTask when task already exists should throw DupliateTaskException")]
        public void ValidateExistingTask_WhenTaskAlreadyExists_ShouldThrowDuplicateTaskException()
        {
            // Arrange
            string id = "test_id";
            string name = "test_name";
            taskService.Setup(taskService => taskService.ExistsByIdAndName(id, name)).Returns(true);

            // Act and assert 
            Assert.Throws(typeof(DuplicateTaskException), () => taskValidator.ValidateExistingTask(id, name));
        }

        [Test(Description = "ValidateExistingTask when task not exists should not throw DupliateTaskException")]
        public void ValidateExistingTask_WhenTaskNotAlreadyExists_ShouldNotThrowDuplicateTaskException()
        {
            // Arrange
            string id = "test_id";
            string name = "test_name";
            taskService.Setup(taskService => taskService.ExistsByIdAndName(id, name)).Returns(false);

            // Act and assert 
            Assert.DoesNotThrow(() => taskValidator.ValidateExistingTask(id, name));
        }
    }
}
