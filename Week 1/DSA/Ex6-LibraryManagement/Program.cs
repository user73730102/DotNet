using System;

namespace Ex6_LibraryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Library Management Search (Linear vs Binary)...\n");

            Book[] books = new Book[]
            {
                new Book(1, "The Great Gatsby", "F. Scott Fitzgerald"),
                new Book(2, "Moby Dick", "Herman Melville"),
                new Book(3, "1984", "George Orwell"),
                new Book(4, "To Kill a Mockingbird", "Harper Lee"),
                new Book(5, "Pride and Prejudice", "Jane Austen")
            };

            string targetTitle = "1984";

            // 1. Linear Search
            Console.WriteLine("--- Linear Search ---");
            Book? foundLinear = LibrarySearch.LinearSearchByTitle(books, targetTitle);
            Console.WriteLine(foundLinear != null ? $"Found: {foundLinear}" : "Book not found.");

            // 2. Binary Search
            Console.WriteLine("\n--- Binary Search ---");
            // Must sort first!
            Array.Sort(books); 
            
            Book? foundBinary = LibrarySearch.BinarySearchByTitle(books, targetTitle);
            Console.WriteLine(foundBinary != null ? $"Found: {foundBinary}" : "Book not found.");

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
