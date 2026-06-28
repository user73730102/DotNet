using NUnit.Framework;
using SeasonsLib;
using System.Collections.Generic;

namespace FourSeasonsLib.Tests
{
    [TestFixture]
    public class SeasonTellerTests
    {
        private SeasonTeller _teller;

        [SetUp]
        public void Setup()
        {
            _teller = new SeasonTeller();
        }

        public static IEnumerable<TestCaseData> SeasonTestCases()
        {
            yield return new TestCaseData("February").Returns("Spring");
            yield return new TestCaseData("March").Returns("Spring");
            yield return new TestCaseData("April").Returns("Summer");
            yield return new TestCaseData("May").Returns("Summer");
            yield return new TestCaseData("June").Returns("Summer");
            yield return new TestCaseData("July").Returns("Monsoon");
            yield return new TestCaseData("August").Returns("Monsoon");
            yield return new TestCaseData("September").Returns("Monsoon");
            yield return new TestCaseData("October").Returns("Autumn");
            yield return new TestCaseData("November").Returns("Autumn");
            yield return new TestCaseData("December").Returns("Winter");
            yield return new TestCaseData("January").Returns("Winter");
            yield return new TestCaseData("Unknown").Returns("Invalid Season");
        }

        [Test, TestCaseSource(nameof(SeasonTestCases))]
        public string DisplaySeasonBy_VariousMonths_ReturnsExpectedSeason(string monthName)
        {
            return _teller.DisplaySeasonBy(monthName);
        }
    }
}
