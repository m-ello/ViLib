using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Represents a book in the library system with its metadata and borrowing status.
    /// </summary>
    public class Book
    {
        /// <summary>
        /// The author of the book
        /// </summary>
        public readonly string author;

        /// <summary>
        /// The title of the book
        /// </summary>
        public readonly string title;

        /// <summary>
        /// The publisher of the book
        /// </summary>
        public readonly string publisher;

        /// <summary>
        /// Indicates whether the book is currently available for borrowing
        /// </summary>
        public bool IsAvailable;

        /// <summary>
        /// The history of all borrow records for this book
        /// </summary>
        public List<BorrowRecord> BorrowHistory { get; set; } = new List<BorrowRecord>();

        /// <summary>
        /// Initializes a new instance of the Book class
        /// </summary>
        /// <param name="_title">The title of the book</param>
        /// <param name="_author">The author of the book</param>
        /// <param name="_publisher">The publisher of the book</param>
        public Book(string _title, string _author, string _publisher)
        {
            title = _title;
            author = _author;
            publisher = _publisher;
            IsAvailable = true; // New books are available by default
        }
    }
}