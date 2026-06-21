using System;
using System.Collections.Generic;

namespace Ex7_Observer
{
    // Observer Interface
    public interface IObserver
    {
        void Update(string stockSymbol, decimal price);
    }

    // Subject Interface
    public interface IStock
    {
        void RegisterObserver(IObserver observer);
        void DeregisterObserver(IObserver observer);
        void NotifyObservers();
    }

    // Concrete Subject
    public class StockMarket : IStock
    {
        private List<IObserver> _observers = new List<IObserver>();
        private string _stockSymbol;
        private decimal _price;

        public StockMarket(string symbol, decimal initialPrice)
        {
            _stockSymbol = symbol;
            _price = initialPrice;
        }

        public decimal Price
        {
            get => _price;
            set
            {
                if (_price != value)
                {
                    _price = value;
                    NotifyObservers();
                }
            }
        }

        public void RegisterObserver(IObserver observer)
        {
            if (!_observers.Contains(observer))
            {
                _observers.Add(observer);
            }
        }

        public void DeregisterObserver(IObserver observer)
        {
            _observers.Remove(observer);
        }

        public void NotifyObservers()
        {
            foreach (var observer in _observers)
            {
                observer.Update(_stockSymbol, _price);
            }
        }
    }

    // Concrete Observer 1
    public class MobileApp : IObserver
    {
        public void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"[Mobile App Alert]: {stockSymbol} is now ${price}");
        }
    }

    // Concrete Observer 2
    public class WebApp : IObserver
    {
        public void Update(string stockSymbol, decimal price)
        {
            Console.WriteLine($"[Web Dashboard Updated]: {stockSymbol} new price is ${price}");
        }
    }
}
