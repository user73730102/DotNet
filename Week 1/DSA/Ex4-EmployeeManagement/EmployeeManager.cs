using System;

namespace Ex4_EmployeeManagement
{
    public class EmployeeManager
    {
        private Employee[] _employees;
        private int _count;

        public EmployeeManager(int capacity)
        {
            _employees = new Employee[capacity];
            _count = 0;
        }

        // Add Employee: O(1) Time Complexity (if not full)
        public void AddEmployee(Employee employee)
        {
            if (_count < _employees.Length)
            {
                _employees[_count] = employee;
                _count++;
                Console.WriteLine($"Added: {employee.Name}");
            }
            else
            {
                Console.WriteLine("Error: Employee array is full!");
            }
        }

        // Search Employee: O(N) Time Complexity
        public Employee? SearchEmployee(int employeeId)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == employeeId)
                {
                    return _employees[i];
                }
            }
            return null;
        }

        // Traverse Employees: O(N) Time Complexity
        public void TraverseEmployees()
        {
            Console.WriteLine("\n--- Employee List ---");
            for (int i = 0; i < _count; i++)
            {
                Console.WriteLine(_employees[i]);
            }
            Console.WriteLine("---------------------\n");
        }

        // Delete Employee: O(N) Time Complexity (need to shift elements)
        public void DeleteEmployee(int employeeId)
        {
            for (int i = 0; i < _count; i++)
            {
                if (_employees[i].EmployeeId == employeeId)
                {
                    // Shift elements to the left to fill the gap
                    for (int j = i; j < _count - 1; j++)
                    {
                        _employees[j] = _employees[j + 1];
                    }
                    _employees[_count - 1] = null!; // Clear the last element
                    _count--;
                    Console.WriteLine($"Deleted Employee ID: {employeeId}");
                    return;
                }
            }
            Console.WriteLine($"Employee ID {employeeId} not found.");
        }
    }
}
