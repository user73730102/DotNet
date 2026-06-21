using System;

namespace Ex8_Strategy
{
    // Strategy Interface
    public interface IPaymentStrategy
    {
        void Pay(decimal amount);
    }

    // Concrete Strategy 1
    public class CreditCardPayment : IPaymentStrategy
    {
        private string _cardNumber;
        private string _name;

        public CreditCardPayment(string name, string cardNumber)
        {
            _name = name;
            _cardNumber = cardNumber;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using Credit Card ending in {_cardNumber.Substring(_cardNumber.Length - 4)}");
        }
    }

    // Concrete Strategy 2
    public class PayPalPayment : IPaymentStrategy
    {
        private string _email;

        public PayPalPayment(string email)
        {
            _email = email;
        }

        public void Pay(decimal amount)
        {
            Console.WriteLine($"Paid ${amount} using PayPal account '{_email}'");
        }
    }

    // Context
    public class ShoppingCart
    {
        private decimal _totalAmount = 0;

        public void AddItemPrice(decimal price)
        {
            _totalAmount += price;
        }

        public void Checkout(IPaymentStrategy paymentStrategy)
        {
            // The context delegates the payment behavior to the strategy object
            paymentStrategy.Pay(_totalAmount);
            _totalAmount = 0; // Reset cart after checkout
        }
    }
}
