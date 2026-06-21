using System;

namespace Ex2_EcommerceSearch
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing E-Commerce Search (Linear vs Binary)...\n");

            Product[] products = new Product[]
            {
                new Product(501, "Gaming Mouse", "Electronics"),
                new Product(202, "Mechanical Keyboard", "Electronics"),
                new Product(105, "Coffee Mug", "Home"),
                new Product(308, "Desk Chair", "Furniture"),
                new Product(404, "Monitor Stand", "Accessories")
            };

            int targetId = 308;

            // 1. Linear Search (Unsorted Array)
            Console.WriteLine("--- Linear Search ---");
            Product? foundLinear = SearchAlgorithms.LinearSearch(products, targetId);
            Console.WriteLine(foundLinear != null ? $"Found: {foundLinear}" : "Product not found.");

            // 2. Binary Search (Requires Sorted Array)
            Console.WriteLine("\n--- Binary Search ---");
            Array.Sort(products); // Sorting takes O(N log N), but future binary searches are O(log N)
            
            Product? foundBinary = SearchAlgorithms.BinarySearch(products, targetId);
            Console.WriteLine(foundBinary != null ? $"Found: {foundBinary}" : "Product not found.");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
