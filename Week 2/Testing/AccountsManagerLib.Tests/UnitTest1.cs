using NUnit.Framework;
using AccountsManagerLib;
using System;

namespace AccountsManagerLib.Tests
{
    [TestFixture] // Marks this class as a test container for NUnit
    public class AccountsManagerTests
    {
        private AccountsManager _manager;

        [SetUp] // Runs before each test method to initialize objects (Arrange Phase)
        public void Setup()
        {
            // Arrange: We prepare the required object for our tests
            _manager = new AccountsManager();
        }

        [Test] // Marks this method as an individual unit test
        [TestCase("user_11", "secret@user11")] // Provides parameterized inputs to the test
        [TestCase("user_22", "secret@user22")]
        public void ValidateUser_ValidCredentials_ReturnsWelcomeMessage(string userId, string password)
        {
            // Arrange
            string expectedMessage = $"Welcome {userId}!!!";

            // Act: We execute the method we want to test
            string actualMessage = _manager.ValidateUser(userId, password);

            // Assert: We verify the result matches our expectations
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        [TestCase("user_11", "wrong_password")]
        [TestCase("unknown_user", "secret@user11")]
        public void ValidateUser_InvalidCredentials_ReturnsInvalidMessage(string userId, string password)
        {
            // Arrange
            string expectedMessage = "Invalid user id/password";

            // Act
            string actualMessage = _manager.ValidateUser(userId, password);

            // Assert
            Assert.That(actualMessage, Is.EqualTo(expectedMessage));
        }

        [Test]
        [TestCase("", "password")]
        [TestCase("user", "")]
        public void ValidateUser_NullOrEmptyCredentials_ThrowsFormatException(string userId, string password)
        {
            // Arrange (Nothing specific to arrange here other than passing the inputs to Act)
            
            // Act & Assert: We expect an exception to be thrown
            Assert.Throws<FormatException>(() => _manager.ValidateUser(userId, password));
        }
    }
}
