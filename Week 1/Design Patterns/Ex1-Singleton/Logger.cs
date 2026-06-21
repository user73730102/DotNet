using System;

namespace Ex1_Singleton
{
    public sealed class Logger
    {
        // Private static instance initialized lazily and thread-safe
        private static readonly Lazy<Logger> _instance = new Lazy<Logger>(() => new Logger());

        // Public property to access the single instance
        public static Logger Instance => _instance.Value;

        // Private constructor ensures no other instances can be created
        private Logger()
        {
            Console.WriteLine("Logger instance created.");
        }

        public void Log(string message)
        {
            Console.WriteLine($"[LOG]: {message}");
        }
    }
}
