using System;

namespace Ex1_InventoryManagement
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Testing Inventory Management System...\n");

            Inventory inventory = new Inventory();

            // 1. Add Products
            Product p1 = new Product(101, "Laptop", 10, 999.99m);
            Product p2 = new Product(102, "Smartphone", 25, 499.50m);
            Product p3 = new Product(103, "Headphones", 50, 89.99m);

            inventory.AddProduct(p1);
            inventory.AddProduct(p2);
            inventory.AddProduct(p3);

            inventory.DisplayInventory();

            // 2. Update a Product
            p2.Price = 449.99m; // Discounting smartphone
            p2.Quantity = 20;   // Sold 5
            inventory.UpdateProduct(p2);

            inventory.DisplayInventory();

            // 3. Delete a Product
            inventory.DeleteProduct(101);

            inventory.DisplayInventory();

            Console.WriteLine("Press Enter to exit...");
            Console.ReadLine();
        }
    }
}
