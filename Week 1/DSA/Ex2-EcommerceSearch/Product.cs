using System;

namespace Ex2_EcommerceSearch
{
    public class Product : IComparable<Product>
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string Category { get; set; }

        public Product(int productId, string productName, string category)
        {
            ProductId = productId;
            ProductName = productName;
            Category = category;
        }

        public override string ToString()
        {
            return $"[{ProductId}] {ProductName} ({Category})";
        }

        // Needed for sorting before Binary Search
        public int CompareTo(Product? other)
        {
            if (other == null) return 1;
            return ProductId.CompareTo(other.ProductId);
        }
    }
}
