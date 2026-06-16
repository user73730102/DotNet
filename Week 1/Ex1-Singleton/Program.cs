using System;

namespace Ex1_Singleton
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Singleton Pattern...");

            // Try to get multiple instances of the Logger
            Logger logger1 = Logger.Instance;
            Logger logger2 = Logger.Instance;

            logger1.Log("This is a message from logger1.");
            logger2.Log("This is a message from logger2.");

            // Verify if both references point to the exact same instance
            if (ReferenceEquals(logger1, logger2))
            {
                Console.WriteLine("Singleton test passed: Both logger1 and logger2 are the same instance.");
            }
            else
            {
                Console.WriteLine("Singleton test failed: Different instances created.");
            }

            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
