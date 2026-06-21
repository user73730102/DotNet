namespace Ex3_SortingOrders
{
    public class SortingAlgorithms
    {
        // Bubble Sort: O(N^2) Time Complexity
        public static void BubbleSort(Order[] orders)
        {
            int n = orders.Length;
            for (int i = 0; i < n - 1; i++)
            {
                for (int j = 0; j < n - i - 1; j++)
                {
                    // Sorting by TotalPrice descending
                    if (orders[j].TotalPrice < orders[j + 1].TotalPrice)
                    {
                        // Swap
                        Order temp = orders[j];
                        orders[j] = orders[j + 1];
                        orders[j + 1] = temp;
                    }
                }
            }
        }

        // Quick Sort: O(N log N) Time Complexity
        public static void QuickSort(Order[] orders, int low, int high)
        {
            if (low < high)
            {
                int pivotIndex = Partition(orders, low, high);

                QuickSort(orders, low, pivotIndex - 1);
                QuickSort(orders, pivotIndex + 1, high);
            }
        }

        private static int Partition(Order[] orders, int low, int high)
        {
            decimal pivotValue = orders[high].TotalPrice;
            int i = (low - 1);

            for (int j = low; j < high; j++)
            {
                // Sorting by TotalPrice descending
                if (orders[j].TotalPrice >= pivotValue)
                {
                    i++;
                    // Swap
                    Order temp = orders[i];
                    orders[i] = orders[j];
                    orders[j] = temp;
                }
            }

            // Swap the pivot
            Order temp1 = orders[i + 1];
            orders[i + 1] = orders[high];
            orders[high] = temp1;

            return i + 1;
        }
    }
}
