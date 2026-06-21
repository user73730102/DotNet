using System;

namespace Ex2_EcommerceSearch
{
    public class SearchAlgorithms
    {
        // Linear Search: O(N) Time Complexity
        public static Product? LinearSearch(Product[] products, int targetId)
        {
            foreach (var product in products)
            {
                if (product.ProductId == targetId)
                {
                    return product;
                }
            }
            return null; // Not found
        }

        // Binary Search: O(log N) Time Complexity
        // Array MUST be sorted by ProductId beforehand!
        public static Product? BinarySearch(Product[] products, int targetId)
        {
            int left = 0;
            int right = products.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                int midId = products[mid].ProductId;

                if (midId == targetId)
                {
                    return products[mid];
                }

                if (midId < targetId)
                {
                    left = mid + 1; // Search right half
                }
                else
                {
                    right = mid - 1; // Search left half
                }
            }

            return null; // Not found
        }
    }
}
