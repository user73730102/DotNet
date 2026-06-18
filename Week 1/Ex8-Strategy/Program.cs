using System;

namespace Ex8_Strategy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Strategy Pattern...\n");

            ShoppingCart cart = new ShoppingCart();
            cart.AddItemPrice(45.50m);
            cart.AddItemPrice(20.00m);

            Console.WriteLine("--- Checkout with Credit Card ---");
            IPaymentStrategy creditCard = new CreditCardPayment("John Doe", "1234567890123456");
            cart.Checkout(creditCard);

            Console.WriteLine();

            cart.AddItemPrice(150.99m);
            
            Console.WriteLine("--- Checkout with PayPal ---");
            IPaymentStrategy payPal = new PayPalPayment("john.doe@example.com");
            cart.Checkout(payPal);

            Console.WriteLine("\nStrategy pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
