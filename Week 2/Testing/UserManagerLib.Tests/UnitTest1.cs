using NUnit.Framework;
using UserManagerLib;
using System;

namespace UserManagerLib.Tests
{
    [TestFixture]
    public class UserTests
    {
        private User _user;

        [SetUp]
        public void Setup()
        {
            _user = new User();
        }

        [Test]
        public void CreateUser_ValidPan_ReturnsTrue()
        {
            var testUser = new User { PANCardNo = "ABCDE1234F" };
            Assert.DoesNotThrow(() => _user.CreateUser(testUser));
        }

        [Test]
        public void CreateUser_NullPan_ThrowsNullReferenceException()
        {
            var testUser = new User { PANCardNo = null };
            Assert.Throws<NullReferenceException>(() => _user.CreateUser(testUser));
        }

        [Test]
        public void CreateUser_EmptyPan_ThrowsNullReferenceException()
        {
            var testUser = new User { PANCardNo = string.Empty };
            Assert.Throws<NullReferenceException>(() => _user.CreateUser(testUser));
        }

        [Test]
        public void CreateUser_InvalidLengthPan_ThrowsFormatException()
        {
            var testUser = new User { PANCardNo = "ABC" };
            Assert.Throws<FormatException>(() => _user.CreateUser(testUser));
        }
    }
}
