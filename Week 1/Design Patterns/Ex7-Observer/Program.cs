using System;

namespace Ex7_Observer
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Observer Pattern...\n");

            StockMarket appleStock = new StockMarket("AAPL", 150.00m);

            IObserver mobileApp = new MobileApp();
            IObserver webApp = new WebApp();

            // Register observers
            appleStock.RegisterObserver(mobileApp);
            appleStock.RegisterObserver(webApp);

            // Change price, observers should be notified
            Console.WriteLine("Changing price to $155.00...");
            appleStock.Price = 155.00m;

            Console.WriteLine("\nChanging price to $152.50...");
            appleStock.Price = 152.50m;

            // Deregister one observer
            Console.WriteLine("\nDeregistering WebApp...");
            appleStock.DeregisterObserver(webApp);

            Console.WriteLine("Changing price to $160.00...");
            appleStock.Price = 160.00m; // Only MobileApp should be notified

            Console.WriteLine("\nObserver pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
