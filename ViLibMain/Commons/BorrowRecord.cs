using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Represents a record of a book being borrowed from the library
    /// </summary>
    public class BorrowRecord
    {
        /// <summary>
        /// Unique identifier for the borrow record
        /// </summary>
        public int Id { get; set; }

        /// <summary>
        /// The book that was borrowed
        /// </summary>
        public Book Book { get; set; }

        /// <summary>
        /// The client who borrowed the book
        /// </summary>
        public Client Client { get; set; }

        /// <summary>
        /// Date and time when the book was borrowed
        /// </summary>
        public DateTime BorrowDate { get; set; }

        /// <summary>
        /// Date and time when the book was returned (null if not yet returned)
        /// </summary>
        public DateTime? ReturnDate { get; set; }

        /// <summary>
        /// Indicates whether the book is currently borrowed (not yet returned)
        /// </summary>
        public bool IsActive => ReturnDate == null;

        /// <summary>
        /// Convenience property to access the book's title
        /// Returns null if Book is null
        /// </summary>
        public string BookTitle => Book?.title;

        /// <summary>
        /// Convenience property to access the client's CNP (Personal Numeric Code)
        /// Returns null if Client is null
        /// </summary>
        public string ClientCNP => Client?.CNP;
    }
}
