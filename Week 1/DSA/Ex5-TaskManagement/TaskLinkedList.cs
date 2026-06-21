using System;

namespace Ex5_TaskManagement
{
    public class Node
    {
        public Task TaskData { get; set; }
        public Node? Next { get; set; }

        public Node(Task task)
        {
            TaskData = task;
            Next = null;
        }
    }

    public class TaskLinkedList
    {
        private Node? _head;

        // Add Task: O(N) because we append to the end
        // (Could be O(1) if we kept a _tail reference, but this is a standard singly linked list)
        public void AddTask(Task task)
        {
            Node newNode = new Node(task);
            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                current.Next = newNode;
            }
            Console.WriteLine($"Added: {task.TaskName}");
        }

        // Search Task: O(N)
        public Task? SearchTask(int taskId)
        {
            Node? current = _head;
            while (current != null)
            {
                if (current.TaskData.TaskId == taskId)
                {
                    return current.TaskData;
                }
                current = current.Next;
            }
            return null;
        }

        // Traverse Tasks: O(N)
        public void TraverseTasks()
        {
            Console.WriteLine("\n--- Task List ---");
            Node? current = _head;
            while (current != null)
            {
                Console.WriteLine(current.TaskData);
                current = current.Next;
            }
            Console.WriteLine("-----------------\n");
        }

        // Delete Task: O(N)
        public void DeleteTask(int taskId)
        {
            if (_head == null) return;

            // If head is the one to delete
            if (_head.TaskData.TaskId == taskId)
            {
                _head = _head.Next;
                Console.WriteLine($"Deleted Task ID: {taskId}");
                return;
            }

            Node current = _head;
            while (current.Next != null)
            {
                if (current.Next.TaskData.TaskId == taskId)
                {
                    // Skip the deleted node
                    current.Next = current.Next.Next;
                    Console.WriteLine($"Deleted Task ID: {taskId}");
                    return;
                }
                current = current.Next;
            }

            Console.WriteLine($"Task ID {taskId} not found.");
        }
    }
}
