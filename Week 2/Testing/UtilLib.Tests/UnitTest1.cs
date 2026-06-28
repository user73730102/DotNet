using NUnit.Framework;
using UtilLib;
using System;

namespace UtilLib.Tests
{
    [TestFixture]
    public class UrlHostNameParserTests
    {
        private UrlHostNameParser _parser;

        [SetUp]
        public void Setup()
        {
            _parser = new UrlHostNameParser();
        }

        [Test]
        [TestCase("http://www.google.com/search", ExpectedResult = "www.google.com")]
        [TestCase("https://github.com/dotnet", ExpectedResult = "github.com")]
        [TestCase("http://localhost:8080/api", ExpectedResult = "localhost")]
        public string ParseHostName_ValidUrl_ReturnsHostName(string url)
        {
            // Act
            return _parser.ParseHostName(url);
            
            // Note: Since we are using the ExpectedResult property of the [TestCase] attribute,
            // NUnit will automatically Assert that the returned value from this method matches the ExpectedResult!
            // We don't need a manual Assert.That() call here.
        }

        [Test]
        public void ParseHostName_InvalidProtocol_ThrowsFormatException()
        {
            // Arrange
            string invalidUrl = "ftp://fileserver.com/file.txt";

            // Act & Assert
            // We use a lambda expression "() =>" to pass the method call to Assert.Throws
            Assert.Throws<FormatException>(() => _parser.ParseHostName(invalidUrl));
        }
    }
}
