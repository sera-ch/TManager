using Moq;
using NUnit.Framework.Internal;
using TManager.entity;
using TManager.error;
using TManager.repository;
using TManager.service;

namespace TManager.test
{
    [TestFixture]
    public class UserServiceTest
    {
        private UserService UserService;
        private Mock<UserRepository> UserRepository;

        [SetUp]
        public void SetUp()
        {
            UserRepository = new Mock<UserRepository>();
            UserService = new UserServiceImpl(UserRepository.Object);
        }

        [Test(Description = "GetUser not found should throw UserNotFoundException")]
        public void GetUser_NotFound_ShouldThrowUserNotFoundException()
        {
            // Arrange
            int userId = 1;
            UserRepository.Setup(UserRepository => UserRepository.GetUser(userId)).Returns((User?)null);

            // Act and Assert
            UserNotFoundException thrown = Assert.Throws<UserNotFoundException>(() => UserService.GetUser(userId));
            Assert.That(thrown.UserId, Is.EqualTo(userId));
            UserRepository.Verify(UserRepository => UserRepository.GetUser(userId), Times.Once());
        }

        [Test(Description = "GetUser found should return user")]
        public void GetUser_Found_ShouldReturnUser()
        {
            // Arrange
            int userId = 1;
            string username = "e.kim.mai";
            User user = new User(userId, username);
            UserRepository.Setup(UserRepository => UserRepository.GetUser(userId)).Returns(user);

            // Act
            User actual = UserService.GetUser(userId);

            // Assert
            Assert.That(actual, Is.EqualTo(user));
            UserRepository.Verify(UserRepository => UserRepository.GetUser(userId), Times.Once());
        }

        [Test(Description = "SaveUser success should return user")]
        public void Register_Success_ShouldReturnUser()
        {
            // Arrange
            int userId = 1;
            string username = "e.kim.mai";
            User user = new User(userId, username);
            UserRepository.Setup(UserRepository => UserRepository.Save(user)).Returns(user);

            // Act
            User actual = UserService.Register(user);

            // Assert
            Assert.That(actual, Is.EqualTo(user));
            UserRepository.Verify(UserRepository => UserRepository.Save(user), Times.Once());
        }

        [Test(Description = "GetUserByUsername when not found should return null")]
        public void GetUserByUsername_WhenNotFound_ShouldReturnNull()
        {
            // Arrange
            string username = "e.kim.mai";

            // Act
            User? actual = UserService.GetUserByUsername(username);

            // Assert
            Assert.That(actual, Is.Null);
            UserRepository.Verify(UserRepository => UserRepository.GetByUserName(username), Times.Once());
        }

        [Test(Description = "GetUserByUsername when found should return user")]
        public void GetUserByUsername_WhenFound_ShouldReturnUser()
        {
            // Arrange
            int userId = 1;
            string username = "e.kim.mai";
            User user = new User(userId, username);
            UserRepository.Setup(UserRepository => UserRepository.GetByUserName(username)).Returns(user);

            // Act
            User? actual = UserService.GetUserByUsername(username);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(user));
            UserRepository.Verify(UserRepository => UserRepository.GetByUserName(username), Times.Once());
        }

        [Test(Description = "LogIn when user is not found should throw UserNotFoundException")]
        public void LogIn_WhenUserIsNotFound_ShouldThrowUserNotFoundException()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            UserRepository.Setup(UserRepository => UserRepository.GetByUserName(username)).Returns((User)null);

            // Act and Assert
            Assert.Throws(typeof(UserNotFoundException), () => UserService.LogIn(username, password));
            UserRepository.Verify(UserRepository => UserRepository.GetByUserName(username), Times.Once());
        }

        [Test(Description = "LogIn when found should return user")]
        public void LogIn_WhenFound_ShouldReturnUser()
        {
            // Arrange
            string username = "e.kim.mai";
            string password = "123456";
            User user = new User(username, password);
            UserRepository.Setup(UserRepository => UserRepository.GetByUserName(username)).Returns(user);

            // Act
            User? actual = UserService.LogIn(username, password);

            // Assert
            Assert.That(actual, Is.Not.Null);
            Assert.That(actual, Is.EqualTo(user));
            UserRepository.Verify(UserRepository => UserRepository.GetByUserName(username), Times.Once());
        }

        [Test(Description = "GetAllUsers when not found should return empty list")]
        public void GetAllUsers_WhenNotFound_ShouldReturnEmptyList()
        {
            // Arrange
            UserRepository.Setup(UserRepository => UserRepository.GetAll()).Returns(new List<User>());

            // Act
            List<User> actual = UserService.GetAllUsers();

            // Assert
            Assert.That(actual, Is.Empty);
            UserRepository.Verify(UserRepository => UserRepository.GetAll(), Times.Once());
        }

        [Test(Description = "GetAllUsers when found should return users")]
        public void GetAllUsers_WhenFound_ShouldReturnUsers()
        {
            // Arrange
            int userId = 1;
            string username = "e.kim.mai";
            User user = new User(userId, username);
            UserRepository.Setup(UserRepository => UserRepository.GetAll()).Returns(new List<User> { user });

            // Act
            List<User> actual = UserService.GetAllUsers();

            // Assert
            Assert.That(actual, Is.Not.Empty);
            Assert.That(actual.Count, Is.EqualTo(1));
            Assert.That(actual[0], Is.EqualTo(user));
            UserRepository.Verify(UserRepository => UserRepository.GetAll(), Times.Once());
        }
    }
}