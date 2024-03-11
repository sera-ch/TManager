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
        public void SaveUser_Success_ShouldReturnUser()
        {
            // Arrange
            int userId = 1;
            string username = "e.kim.mai";
            User user = new User(userId, username);
            UserRepository.Setup(UserRepository => UserRepository.Save(user)).Returns(user);

            // Act
            User actual = UserService.SaveUser(user);

            // Assert
            Assert.That(actual, Is.EqualTo(user));
            UserRepository.Verify(UserRepository => UserRepository.Save(user), Times.Once());
        }
    }
}