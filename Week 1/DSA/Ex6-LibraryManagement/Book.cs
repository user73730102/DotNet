using System;

namespace Ex6_LibraryManagement
{
    public class Book : IComparable<Book>
    {
        public int BookId { get; set; }
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(int bookId, string title, string author)
        {
            BookId = bookId;
            Title = title;
            Author = author;
        }

        public override string ToString()
        {
            return $"[{BookId}] {Title} by {Author}";
        }

        // We implement IComparable to allow sorting by Title, which is required for Binary Search
        public int CompareTo(Book? other)
        {
            if (other == null) return 1;
            // Sorting alphabetically by Title
            return string.Compare(this.Title, other.Title, StringComparison.OrdinalIgnoreCase);
        }
    }
}
