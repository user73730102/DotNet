using System;

namespace Ex3_SortingOrders
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Bubble Sort vs Quick Sort...\n");

            Order[] ordersForBubble = new Order[]
            {
                new Order(1, "Alice", 250.50m),
                new Order(2, "Bob", 50.00m),
                new Order(3, "Charlie", 999.99m),
                new Order(4, "Diana", 120.25m)
            };

            Order[] ordersForQuick = new Order[]
            {
                new Order(1, "Alice", 250.50m),
                new Order(2, "Bob", 50.00m),
                new Order(3, "Charlie", 999.99m),
                new Order(4, "Diana", 120.25m)
            };

            Console.WriteLine("--- Bubble Sort Result ---");
            SortingAlgorithms.BubbleSort(ordersForBubble);
            foreach (var order in ordersForBubble)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("\n--- Quick Sort Result ---");
            SortingAlgorithms.QuickSort(ordersForQuick, 0, ordersForQuick.Length - 1);
            foreach (var order in ordersForQuick)
            {
                Console.WriteLine(order);
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
