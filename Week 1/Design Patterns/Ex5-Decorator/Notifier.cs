using System;

namespace Ex5_Decorator
{
    // The Base Interface
    public interface INotifier
    {
        void Send(string message);
    }

    // Concrete Component
    public class EmailNotifier : INotifier
    {
        public void Send(string message)
        {
            Console.WriteLine($"Sending Email: {message}");
        }
    }

    // Base Decorator
    public abstract class NotifierDecorator : INotifier
    {
        protected INotifier _wrappee;

        public NotifierDecorator(INotifier wrappee)
        {
            _wrappee = wrappee;
        }

        public virtual void Send(string message)
        {
            _wrappee.Send(message);
        }
    }

    // Concrete Decorator 1
    public class SMSNotifierDecorator : NotifierDecorator
    {
        public SMSNotifierDecorator(INotifier wrappee) : base(wrappee)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending SMS: {message}");
        }
    }

    // Concrete Decorator 2
    public class SlackNotifierDecorator : NotifierDecorator
    {
        public SlackNotifierDecorator(INotifier wrappee) : base(wrappee)
        {
        }

        public override void Send(string message)
        {
            base.Send(message);
            Console.WriteLine($"Sending Slack message: {message}");
        }
    }
}
