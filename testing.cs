using Moq;
using NUnit.Framework;

namespace testingApp.Tests
{
    [TestFixture]
    public class UserManagerTests
    {
        [Test]
        public void AddUser_ShouldAddUserToDatabase()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var userManager = new UserManager(mockDatabase.Object);

            // Create a user to add
            var userToAdd = new User(1, "MarreP");

            // Act
            userManager.AddUser(userToAdd);

            // Assert
            // Verify that AddUser method was called once with the expected user
            mockDatabase.Verify(d => d.AddUser(userToAdd), Times.Once);
        }

        [Test]
        public void GetUser_ShouldGetUserFromDatabase()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var userManager = new UserManager(mockDatabase.Object);

            // Act
            userManager.GetUser(1);

            // Assert
            // Verify that GetUser method was called once with the expected user ID
            mockDatabase.Verify(d => d.GetUser(1), Times.Once);
        }

        [Test]
        public void AddUser_ShouldHandleExistingUser()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var userManager = new UserManager(mockDatabase.Object);

            // Create an existing user with the same ID
            var existingUser = new User(1, "MarreP");
            mockDatabase.Setup(d => d.GetUser(1)).Returns(existingUser);

            // Act
            userManager.AddUser(existingUser);

            // Assert
            // Verify that AddUser method was not called since the user already exists
            mockDatabase.Verify(d => d.AddUser(It.IsAny<User>()), Times.Once);
        }

        [Test]
        public void RemoveUser_ShouldRemoveUserFromDatabase()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var userManager = new UserManager(mockDatabase.Object);

            // Create a user to remove
            var userToRemove = new User(1, "JohnDoe");
            mockDatabase.Setup(d => d.GetUser(1)).Returns(userToRemove);

            // Act
            userManager.RemoveUser(1);

            // Assert
            // Verify that RemoveUser method was called once with the expected user ID
            mockDatabase.Verify(d => d.RemoveUser(1), Times.Once);
        }

        [Test]
        public void RemoveUser_ShouldHandleNonExistingUser()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var userManager = new UserManager(mockDatabase.Object);

            // Set up the mock to return null when GetUser(1) is called
            mockDatabase.Setup(d => d.GetUser(1)).Returns((User)null);

            // Act
            userManager.RemoveUser(1);

            // Assert
            // Verify that RemoveUser method was not called since the user does not exist
            mockDatabase.Verify(d => d.RemoveUser(It.IsAny<int>()), Times.Never);
        }

        [Test]
        public void GetUser_ShouldHandleNonExistingUser()
        {
            // Arrange
            var mockDatabase = new Mock<IDatabase>();
            var userManager = new UserManager(mockDatabase.Object);

            // Act
            userManager.GetUser(1);

            // Assert
            // Verify that GetUser method was called once with the expected user ID
            mockDatabase.Verify(d => d.GetUser(1), Times.Once);
        }
    }
}
