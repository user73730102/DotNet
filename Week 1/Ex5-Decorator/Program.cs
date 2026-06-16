using System;

namespace Ex5_Decorator
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Decorator Pattern...\n");

            // 1. Just Email
            INotifier notifier = new EmailNotifier();
            Console.WriteLine("--- Basic Notifier ---");
            notifier.Send("System update completed.");

            Console.WriteLine();

            // 2. Email + SMS
            INotifier smsNotifier = new SMSNotifierDecorator(new EmailNotifier());
            Console.WriteLine("--- SMS + Email Notifier ---");
            smsNotifier.Send("Server is down!");

            Console.WriteLine();

            // 3. Email + SMS + Slack
            INotifier allNotifier = new SlackNotifierDecorator(new SMSNotifierDecorator(new EmailNotifier()));
            Console.WriteLine("--- All Channels Notifier ---");
            allNotifier.Send("Critical Security Breach!");

            Console.WriteLine("\nDecorator pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
