using NUnit.Framework;
using CalcLibrary;
using System;

namespace CalcLibrary.Tests
{
    [TestFixture] // This attribute designates this class as a test fixture (contains tests)
    public class SimpleCalculatorTests
    {
        private SimpleCalculator _calculator;

        [SetUp] // This method runs before each test. It is part of the "Arrange" phase.
        public void Setup()
        {
            // Arrange: We initialize the object under test so it's fresh for every test method.
            _calculator = new SimpleCalculator();
        }

        [Test] // This attribute flags the method as an executable test case
        public void Addition_ValidNumbers_ReturnsCorrectSum()
        {
            // Arrange: Setup the inputs and the expected outcome
            double a = 5.0;
            double b = 10.0;
            double expected = 15.0;

            // Act: Call the method we are testing
            double actual = _calculator.Addition(a, b);

            // Assert: Verify that the actual result matches our expected result
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Subtraction_ValidNumbers_ReturnsCorrectDifference()
        {
            // Arrange
            double a = 10.0;
            double b = 4.0;
            double expected = 6.0;

            // Act
            double actual = _calculator.Subtraction(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Multiplication_ValidNumbers_ReturnsCorrectProduct()
        {
            // Arrange
            double a = 3.0;
            double b = 4.0;
            double expected = 12.0;

            // Act
            double actual = _calculator.Multiplication(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ValidNumbers_ReturnsCorrectQuotient()
        {
            // Arrange
            double a = 20.0;
            double b = 4.0;
            double expected = 5.0;

            // Act
            double actual = _calculator.Division(a, b);

            // Assert
            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void Division_ByZero_ThrowsArgumentException()
        {
            // Arrange
            double a = 10.0;
            double b = 0.0;

            // Act & Assert: When testing exceptions, we use Assert.Throws which executes the action 
            // inside a lambda expression and asserts that the specific Exception is thrown.
            Assert.Throws<ArgumentException>(() => _calculator.Division(a, b));
        }
    }
}
