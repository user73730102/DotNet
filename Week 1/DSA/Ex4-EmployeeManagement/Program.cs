using System;

namespace Ex4_EmployeeManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Employee Management (Array-based)...\n");

            EmployeeManager manager = new EmployeeManager(5);

            // 1. Add Employees
            manager.AddEmployee(new Employee(1, "Alice Smith", "Developer", 85000));
            manager.AddEmployee(new Employee(2, "Bob Jones", "Manager", 95000));
            manager.AddEmployee(new Employee(3, "Charlie Brown", "Analyst", 75000));

            // 2. Traverse
            manager.TraverseEmployees();

            // 3. Search
            Console.WriteLine("--- Searching for Employee ID 2 ---");
            Employee? emp = manager.SearchEmployee(2);
            Console.WriteLine(emp != null ? $"Found: {emp.Name}" : "Not Found");

            // 4. Delete
            Console.WriteLine("\n--- Deleting Employee ID 2 ---");
            manager.DeleteEmployee(2);

            manager.TraverseEmployees();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
