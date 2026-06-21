using System;
using System.Collections.Generic;

namespace Ex1_InventoryManagement
{
    public class Inventory
    {
        // Using Dictionary for O(1) time complexity on additions, updates, and deletions by ProductId
        private Dictionary<int, Product> _products = new Dictionary<int, Product>();

        public void AddProduct(Product product)
        {
            if (!_products.ContainsKey(product.ProductId))
            {
                _products.Add(product.ProductId, product);
                Console.WriteLine($"Added: {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"Product with ID {product.ProductId} already exists.");
            }
        }

        public void UpdateProduct(Product product)
        {
            if (_products.ContainsKey(product.ProductId))
            {
                _products[product.ProductId] = product;
                Console.WriteLine($"Updated: {product.ProductName}");
            }
            else
            {
                Console.WriteLine($"Product with ID {product.ProductId} not found.");
            }
        }

        public void DeleteProduct(int productId)
        {
            if (_products.Remove(productId))
            {
                Console.WriteLine($"Deleted Product ID: {productId}");
            }
            else
            {
                Console.WriteLine($"Product with ID {productId} not found.");
            }
        }

        public void DisplayInventory()
        {
            Console.WriteLine("\n--- Current Inventory ---");
            foreach (var product in _products.Values)
            {
                Console.WriteLine(product);
            }
            Console.WriteLine("-------------------------\n");
        }
    }
}
