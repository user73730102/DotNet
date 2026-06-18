using System;

namespace Ex10_MVC
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing MVC Pattern...\n");

            // Fetch student record based on his roll no from the database
            Student model = RetrieveStudentFromDatabase();

            // Create a view : to write student details on console
            StudentView view = new StudentView();

            // Create a controller
            StudentController controller = new StudentController(model, view);

            // Display initial details
            controller.UpdateView();

            // Update model data
            Console.WriteLine("\nUpdating Student Name...");
            controller.SetStudentName("John Doe");

            // Display updated details
            controller.UpdateView();

            Console.WriteLine("\nMVC pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }

        private static Student RetrieveStudentFromDatabase()
        {
            Student student = new Student("10", "Robert");
            return student;
        }
    }
}
