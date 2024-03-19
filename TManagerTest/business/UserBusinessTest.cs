using Moq;
using TManager.business;
using TManager.entity;
using TManager.error;
using TManager.service;
using TManager.util;

namespace TManagerTest.business
{
    [TestFixture]
    public class UserBusinessTest
    {
        private UserBusiness userBusiness;
        private Mock<UserService> userService;
        private EncryptionUtil encryptionUtil;

        [SetUp]
        public void setUp()
        {
            userService = new Mock<UserService>();
            userBusiness = new UserBusiness(userService.Object);
            encryptionUtil = new EncryptionUtil();
        }

        [Test(Description = "Register when username is empty should throw invalid username exception")]
        public void Register_WhenUsernameIsEmpty_ShouldThrowInvalidUsernameException()
        {
            // Arrange
            string username = "";
            string password = "123456";

            // Act and Assert
            Assert.Throws(typeof(InvalidUsernameException), () => userBusiness.registerUser(username, password, password));
            userService.VerifyNoOtherCalls();
        }

        [Test(Description = "Register when password is too short should throw invalid password exception")]
        public void Register_WhenPasswordIsTooShort_ShouldThrowInvalidPasswordException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123";

            // Act and Assert
            Assert.Throws(typeof(InvalidPasswordException), () => userBusiness.registerUser(username, password, password));
            userService.VerifyNoOtherCalls();
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
            userService.VerifyNoOtherCalls();
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
            userService.Verify(userService => userService.GetUserByUsername(username), Times.Once());
            userService.VerifyNoOtherCalls();
        }

        [Test(Description = "Register success should return new user")]
        public void Register_Success_ShouldReturnNewUser()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            User user = new User(username, password);
            userService.Setup(userService => userService.GetUserByUsername(username)).Returns((User)null);
            userService.Setup(userService => userService.Register(It.IsAny<User>())).Returns(user);

            // Act
            User actual = userBusiness.registerUser(username, password, password);

            // Assert
            Assert.That(actual, Is.EqualTo(user));
            userService.Verify(userService => userService.GetUserByUsername(username), Times.Once);
            userService.Verify(userService => userService.Register(It.IsAny<User>()), Times.Once);
        }

        [Test(Description = "LogIn when username is empty should throw invalid username exception")]
        public void LogIn_WhenUsernameIsEmpty_ShouldThrowInvalidUsernameException()
        {
            // Arrange
            string username = "e.kim.m";
            string password = "123456";
            User currentUser = new User(username, password);

            // Act and Assert
            Assert.Throws(typeof(InvalidUsernameException), () => userBusiness.logIn("", password, currentUser));
            userService.VerifyNoOtherCalls();
        }

        [Test(Description = "LogIn when user not found should throw UserNotFoundException")]
        public void LogIn_WhenUserNotFound_ShouldThrowUserNotFoundException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            User currentUser = new User(username, password);
            userService.Setup(userService => userService.GetUserByUsername(username)).Returns((User)null);

            // Act and Assert
            Assert.Throws(typeof(UserNotFoundException), () => userBusiness.logIn(username, password, currentUser));
            userService.Verify(userService => userService.GetUserByUsername(username), Times.Once);
            userService.VerifyNoOtherCalls();
        }

        [Test(Description = "LogIn when password is incorrect should throw IncorrectPasswordException")]
        public void LogIn_WhenPasswordIsIncorrect_ShouldThrowIncorrectPasswordException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            string wrongPassword = "654321";
            string loggedInUsername = "e.quyen.hoang";
            User currentUser = new User(loggedInUsername, password);
            byte[] key = encryptionUtil.CreateKey(password);
            string encryptedPassword = encryptionUtil.Encrypt(password, key);
            User user = new User(username, encryptedPassword);
            userService.Setup(userService => userService.GetUserByUsername(username)).Returns(user);

            // Act and Assert
            Assert.Throws(typeof(IncorrectPasswordException), () => userBusiness.logIn(username, wrongPassword, currentUser));
            userService.Verify(userService => userService.GetUserByUsername(username), Times.Once);
            userService.VerifyNoOtherCalls();
        }

        [Test(Description = "LogIn success should return user")]
        public void LogIn_Success_ShouldReturnUser()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            byte[] key = encryptionUtil.CreateKey(password);
            string encryptedPassword = encryptionUtil.Encrypt(password, key);
            User user = new User(username, encryptedPassword);
            userService.Setup(userService => userService.GetUserByUsername(username)).Returns(user);
            userService.Setup(userService => userService.LogIn(username, encryptedPassword)).Returns(user);

            // Act
            User actual = userBusiness.logIn(username, password, null);

            // Assert
            Assert.That(actual, Is.EqualTo(user));
            userService.Verify(userService => userService.GetUserByUsername(username), Times.Once);
            userService.Verify(userService => userService.LogIn(username, encryptedPassword), Times.Once);
        }
    }
}
