using System;

namespace Ex4_Adapter
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Adapter Pattern...");

            // Our application wants to process payments using the IPaymentProcessor interface
            // We use the Stripe adapter
            LegacyStripeGateway stripeGateway = new LegacyStripeGateway();
            IPaymentProcessor stripeProcessor = new StripeAdapter(stripeGateway);
            
            Console.WriteLine("Initiating Stripe payment:");
            stripeProcessor.ProcessPayment(50.25m); // Pay $50.25

            Console.WriteLine();

            // We use the PayPal adapter
            PayPalGateway payPalGateway = new PayPalGateway();
            IPaymentProcessor payPalProcessor = new PayPalAdapter(payPalGateway);

            Console.WriteLine("Initiating PayPal payment:");
            payPalProcessor.ProcessPayment(99.99m); // Pay $99.99

            Console.WriteLine("\nAdapter pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
