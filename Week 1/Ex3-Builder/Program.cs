using System;

namespace Ex3_Builder
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Builder Pattern...");

            // Create a basic computer
            Computer basicComputer = new Computer.ComputerBuilder("Intel i5", "8GB")
                                        .SetStorage("256GB SSD")
                                        .Build();
            
            Console.WriteLine(basicComputer);

            // Create a gaming computer
            Computer gamingComputer = new Computer.ComputerBuilder("AMD Ryzen 9", "32GB")
                                        .SetStorage("2TB NVMe SSD")
                                        .SetGPU("NVIDIA RTX 4090")
                                        .Build();
            
            Console.WriteLine(gamingComputer);

            Console.WriteLine("\nBuilder pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
