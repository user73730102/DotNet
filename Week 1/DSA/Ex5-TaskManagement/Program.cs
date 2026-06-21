using System;

namespace Ex5_TaskManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Task Management (Linked List)...\n");

            TaskLinkedList list = new TaskLinkedList();

            // 1. Add
            list.AddTask(new Task(1, "Fix Login Bug", "In Progress"));
            list.AddTask(new Task(2, "Update Database", "Pending"));
            list.AddTask(new Task(3, "Deploy to Staging", "Not Started"));

            // 2. Traverse
            list.TraverseTasks();

            // 3. Search
            Console.WriteLine("--- Searching for Task ID 2 ---");
            Task? task = list.SearchTask(2);
            Console.WriteLine(task != null ? $"Found: {task.TaskName}" : "Not Found");

            // 4. Delete
            Console.WriteLine("\n--- Deleting Task ID 2 ---");
            list.DeleteTask(2);

            list.TraverseTasks();

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
