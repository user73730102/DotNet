using System;

namespace Ex6_Proxy
{
    // Subject Interface
    public interface IImage
    {
        void Display();
    }

    // Real Subject
    public class RealImage : IImage
    {
        private string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk(filename);
        }

        private void LoadFromDisk(string filename)
        {
            Console.WriteLine($"[Heavy Operation] Loading {filename} from remote server...");
            // Simulate heavy loading process
            System.Threading.Thread.Sleep(500); 
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {_filename}");
        }
    }

    // Proxy
    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private string _filename;

        public ProxyImage(string filename)
        {
            _filename = filename;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                // Lazy initialization: only load the real image if it's actually requested
                _realImage = new RealImage(_filename);
            }
            _realImage.Display();
        }
    }
}
