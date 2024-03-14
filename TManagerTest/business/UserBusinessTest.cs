using Moq;
using TManager.business;
using TManager.entity;
using TManager.error;
using TManager.service;

namespace TManagerTest.business
{
    [TestFixture]
    public class UserBusinessTest
    {
        private UserBusiness userBusiness;
        private Mock<UserService> userService;

        [SetUp]
        public void setUp()
        {
            userService = new Mock<UserService>();
            userBusiness = new UserBusiness(userService.Object);
        }

        [Test(Description = "Register when username is empty should throw invalid username exception")]
        public void Register_WhenUsernameIsEmpty_ShouldThrowInvalidUsernameException()
        {
            // Arrange
            string username = "";
            string password = "123456";

            // Act and Assert
            Assert.Throws(typeof(InvalidUsernameException), () => userBusiness.registerUser(username, password, password));
        }

        [Test(Description = "Register when password is too short should throw invalid password exception")]
        public void Register_WhenPasswordIsTooShort_ShouldThrowInvalidPasswordException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123";

            // Act and Assert
            Assert.Throws(typeof(InvalidPasswordException), () => userBusiness.registerUser(username, password, password));
        }

        [Test(Description = "Register when password is not match should throw password not match exception")]
        public void Register_WhenPasswordIsNotMatch_ShouldThrowPasswordNotMatchException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            string wrongPassword = "456789";

            // Act and Assert
            Assert.Throws(typeof(PasswordNotMatchException), () => userBusiness.registerUser(username, password, wrongPassword));
        }

        [Test(Description = "Register when user already exists should throw duplicate user exception")]
        public void Register_WhenUserAlreadyExists_ShouldThrowDuplicateUserException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            User user = new User(username, password);
            userService.Setup(userService => userService.GetUserByUsername(username)).Returns(user);

            // Act and Assert
            Assert.Throws(typeof(DuplicateUserException), () => userBusiness.registerUser(username, password, password));
        }

        [Test(Description = "Register success should return new user")]
        public void Register_Success_ShouldReturnNewUser()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            User user = new User(username, password);
            userService.Setup(userService => userService.Register(It.IsAny<User>())).Returns(user);

            // Act
            User actual = userBusiness.registerUser(username, password, password);

            // Assert
            Assert.That(actual, Is.EqualTo(user));
            userService.Verify(userService => userService.Register(It.IsAny<User>()), Times.Once);
        }
    }
}
