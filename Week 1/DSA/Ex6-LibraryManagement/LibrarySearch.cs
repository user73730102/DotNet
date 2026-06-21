using System;

namespace Ex6_LibraryManagement
{
    public class LibrarySearch
    {
        // Linear Search: O(N) Time Complexity
        public static Book? LinearSearchByTitle(Book[] books, string title)
        {
            foreach (var book in books)
            {
                if (book.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    return book;
                }
            }
            return null;
        }

        // Binary Search: O(log N) Time Complexity
        // Pre-condition: The 'books' array MUST be sorted alphabetically by Title!
        public static Book? BinarySearchByTitle(Book[] books, string title)
        {
            int left = 0;
            int right = books.Length - 1;

            while (left <= right)
            {
                int mid = left + (right - left) / 2;
                
                int comparisonResult = string.Compare(books[mid].Title, title, StringComparison.OrdinalIgnoreCase);

                if (comparisonResult == 0)
                {
                    // Found
                    return books[mid];
                }
                
                if (comparisonResult < 0)
                {
                    // Mid title comes alphabetically BEFORE the target title, so search the right half
                    left = mid + 1;
                }
                else
                {
                    // Mid title comes alphabetically AFTER the target title, so search the left half
                    right = mid - 1;
                }
            }

            return null; // Not found
        }
    }
}
