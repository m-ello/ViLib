using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        /// <summary>
        /// Initializes a new BorrowRecord instance with the specified client and book.
        /// Sets the borrow date to the current time and leaves return date as null.
        /// </summary>
        /// <param name="client">The client who borrows the book</param>
        /// <param name="book">The book being borrowed</param>
        public BorrowRecord(Client client, Book book)
        {
            Client = client;
            Book = book;
            BorrowDate = DateTime.Now;
            ReturnDate = null;
        }

        /// <summary>
        /// Initializes a new BorrowRecord instance.
        /// Sets the borrow date to the current time and leaves return date as null.
        /// </summary>
        public BorrowRecord() {}
    }
}
