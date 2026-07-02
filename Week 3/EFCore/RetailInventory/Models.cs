using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace RetailInventory
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        // Lab 8: New field
        public int StockQuantity { get; set; }
        
        // Lab 15: Concurrency Token
        [Timestamp]
        public byte[] RowVersion { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        // Lab 11: Relationships
        public ProductDetail ProductDetail { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }

    // Lab 11: One-to-One
    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public string WarrantyInfo { get; set; }
        
        public int ProductId { get; set; }
        public Product Product { get; set; }
    }

    // Lab 11: Many-to-Many
    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Product> Products { get; set; } = new List<Product>();
    }

    // Lab 12: DTOs
    public class ProductDTO
    {
        public string Name { get; set; }
        public string CategoryName { get; set; }
    }
}
