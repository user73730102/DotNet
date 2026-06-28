using NUnit.Framework;
using LeapYearCalculatorLib;

namespace LeapYearCalculatorLib.Tests
{
    [TestFixture]
    public class LeapYearCalculatorTests
    {
        private LeapYearCalculator _calculator;

        [SetUp]
        public void Setup()
        {
            _calculator = new LeapYearCalculator();
        }

        [Test]
        [TestCase(2000, ExpectedResult = 1)]
        [TestCase(2024, ExpectedResult = 1)]
        public int IsLeapYear_ValidLeapYear_Returns1(int year)
        {
            return _calculator.IsLeapYear(year);
        }

        [Test]
        [TestCase(2023, ExpectedResult = 0)]
        [TestCase(1900, ExpectedResult = 0)]
        public int IsLeapYear_ValidNonLeapYear_Returns0(int year)
        {
            return _calculator.IsLeapYear(year);
        }

        [Test]
        [TestCase(1752, ExpectedResult = -1)]
        [TestCase(10000, ExpectedResult = -1)]
        public int IsLeapYear_InvalidYear_ReturnsMinus1(int year)
        {
            return _calculator.IsLeapYear(year);
        }
    }
}
