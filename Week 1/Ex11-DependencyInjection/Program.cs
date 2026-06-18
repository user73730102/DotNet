using System;

namespace Ex11_DependencyInjection
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Dependency Injection...\n");

            // 1. Create the Dependency (Repository)
            ICustomerRepository repository = new CustomerRepositoryImpl();

            // 2. Inject the Dependency into the Service
            CustomerService service = new CustomerService(repository);

            // 3. Use the Service
            Console.WriteLine("Fetching Customer 101:");
            service.DisplayCustomerInfo(101);

            Console.WriteLine("\nDependency Injection test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
