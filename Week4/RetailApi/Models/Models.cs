using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace RetailApi.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore] // Prevent circular reference during JSON serialization
        public List<Product> Products { get; set; }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Price { get; set; }
        
        public int StockQuantity { get; set; }
        
        [Timestamp]
        [JsonIgnore]
        public byte[] RowVersion { get; set; }

        public int CategoryId { get; set; }
        public Category Category { get; set; }

        public ProductDetail ProductDetail { get; set; }
        public List<Tag> Tags { get; set; } = new List<Tag>();
    }

    public class ProductDetail
    {
        public int ProductDetailId { get; set; }
        public string WarrantyInfo { get; set; }
        
        public int ProductId { get; set; }
        
        [JsonIgnore]
        public Product Product { get; set; }
    }

    public class Tag
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [JsonIgnore]
        public List<Product> Products { get; set; } = new List<Product>();
    }
}
