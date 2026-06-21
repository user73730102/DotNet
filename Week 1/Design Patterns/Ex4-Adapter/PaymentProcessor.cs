using System;

namespace Ex4_Adapter
{
    // The Target Interface that our application expects to use
    public interface IPaymentProcessor
    {
        void ProcessPayment(decimal amount);
    }

    // Adaptee 1: A third-party payment gateway with a different interface
    public class LegacyStripeGateway
    {
        public void MakePaymentInCents(int cents)
        {
            Console.WriteLine($"Stripe processed payment of {cents} cents.");
        }
    }

    // Adaptee 2: Another third-party gateway with a different interface
    public class PayPalGateway
    {
        public void SendPayment(double amountDollars)
        {
            Console.WriteLine($"PayPal processed payment of ${amountDollars}.");
        }
    }

    // Adapter for Stripe
    public class StripeAdapter : IPaymentProcessor
    {
        private readonly LegacyStripeGateway _stripeGateway;

        public StripeAdapter(LegacyStripeGateway stripeGateway)
        {
            _stripeGateway = stripeGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            // Convert dollars to cents
            int cents = (int)(amount * 100);
            _stripeGateway.MakePaymentInCents(cents);
        }
    }

    // Adapter for PayPal
    public class PayPalAdapter : IPaymentProcessor
    {
        private readonly PayPalGateway _payPalGateway;

        public PayPalAdapter(PayPalGateway payPalGateway)
        {
            _payPalGateway = payPalGateway;
        }

        public void ProcessPayment(decimal amount)
        {
            // Convert decimal to double
            double dollars = (double)amount;
            _payPalGateway.SendPayment(dollars);
        }
    }
}
