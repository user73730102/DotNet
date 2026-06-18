using System;

namespace Ex9_Command
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Command Pattern...\n");

            // Receiver
            Light livingRoomLight = new Light();

            // Commands
            ICommand lightOn = new LightOnCommand(livingRoomLight);
            ICommand lightOff = new LightOffCommand(livingRoomLight);

            // Invoker
            RemoteControl remote = new RemoteControl();

            // Turn light on
            Console.WriteLine("Pressing ON button...");
            remote.SetCommand(lightOn);
            remote.PressButton();

            // Turn light off
            Console.WriteLine("\nPressing OFF button...");
            remote.SetCommand(lightOff);
            remote.PressButton();

            Console.WriteLine("\nCommand pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
