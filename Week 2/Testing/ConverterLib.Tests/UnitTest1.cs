using NUnit.Framework;
using Moq;
using ConverterLib;
using CurrencyConverterApp;

namespace ConverterLib.Tests
{
    [TestFixture]
    public class ConverterTests
    {
        private Mock<IDollarToEuroExchangeRateFeed> _mockExchangeRateFeed;
        private Converter _converter;

        [SetUp]
        public void Setup()
        {
            _mockExchangeRateFeed = new Mock<IDollarToEuroExchangeRateFeed>();
            _converter = new Converter(_mockExchangeRateFeed.Object);
        }

        [Test]
        public void USDToEuro_ValidDollarAmount_ReturnsConvertedEuro()
        {
            // Arrange
            double expectedExchangeRate = 0.92;
            _mockExchangeRateFeed.Setup(x => x.GetActualUSDollarValue()).Returns(expectedExchangeRate);
            
            double inputDollar = 100.0;
            double expectedEuro = inputDollar * expectedExchangeRate;

            // Act
            double actualEuro = _converter.USDToEuro(inputDollar);

            // Assert
            Assert.That(actualEuro, Is.EqualTo(expectedEuro));
            _mockExchangeRateFeed.Verify(x => x.GetActualUSDollarValue(), Times.Once);
        }
    }
}
