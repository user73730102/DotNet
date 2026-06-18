using System;

namespace Ex9_Command
{
    // The Receiver Class
    public class Light
    {
        public void TurnOn()
        {
            Console.WriteLine("The light is ON.");
        }

        public void TurnOff()
        {
            Console.WriteLine("The light is OFF.");
        }
    }

    // Concrete Command to turn on the light
    public class LightOnCommand : ICommand
    {
        private Light _light;

        public LightOnCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOn();
        }
    }

    // Concrete Command to turn off the light
    public class LightOffCommand : ICommand
    {
        private Light _light;

        public LightOffCommand(Light light)
        {
            _light = light;
        }

        public void Execute()
        {
            _light.TurnOff();
        }
    }
}
