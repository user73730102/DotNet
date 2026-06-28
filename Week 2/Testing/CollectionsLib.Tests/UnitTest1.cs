using NUnit.Framework;
using CollectionsLib;
using System.Collections.Generic;

namespace CollectionsLib.Tests
{
    [TestFixture]
    public class EmployeeManagerTests
    {
        private EmployeeManager _manager;

        [SetUp]
        public void Setup()
        {
            _manager = new EmployeeManager();
        }

        [Test]
        public void GetEmployees_And_GetEmployeesWhoJoinedInPreviousYears_AreEquivalent()
        {
            // Arrange
            // We get both lists of employees. Because all the hardcoded employees in EmployeeManager
            // have a Date of Joining (DOJ) from years ago, both lists should conceptually be the same.
            
            // Act
            List<Employee> allEmployees = _manager.GetEmployees();
            List<Employee> previousYearEmployees = _manager.GetEmployeesWhoJoinedInPreviousYears();

            // Assert
            // Assert.That(... Is.EquivalentTo(...)) verifies that both collections contain the same items, 
            // even if they might be in a different order (though here they are in the same order).
            Assert.That(allEmployees, Is.EquivalentTo(previousYearEmployees));
        }
    }
}
