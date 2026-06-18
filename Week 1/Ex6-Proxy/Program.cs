using System;

namespace Ex6_Proxy
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Proxy Pattern...\n");

            // We want to display two images, but loading them from disk is heavy.
            // Using a Proxy, we can delay loading until we actually need to display them.
            IImage image1 = new ProxyImage("high_res_photo_1.jpg");
            IImage image2 = new ProxyImage("high_res_photo_2.jpg");

            Console.WriteLine("Images created. Note that no loading from disk has happened yet.\n");

            Console.WriteLine("--- First call to display image1 ---");
            // The image will be loaded from disk here
            image1.Display();

            Console.WriteLine("\n--- Second call to display image1 ---");
            // The image is already loaded, so it won't load from disk again
            image1.Display();

            Console.WriteLine("\nProxy pattern test completed.");
            
            Console.WriteLine("\nPress Enter to exit...");
            Console.ReadLine();
        }
    }
}
