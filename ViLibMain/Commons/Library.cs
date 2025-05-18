using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Commons
{
    /// <summary>
    /// a library system that manages books,clients and borrowing operations
    /// </summary>
    public class Library
    {
        /// <summary> 
        /// Collection of all books in the library
        /// </summary>
        public List<Book> Books { get; set; } = new List<Book>();
        
        /// <summary>
        /// Collection of all registered clients
        /// </summary>
        public List<Client> Clients { get; set; } = new List<Client>();

        /// <summary>
        /// Colletion of all borrowing records (both active and historical)
        /// </summary>
        public List<BorrowRecord> AllBorrowRecords { get; set; } = new List<BorrowRecord>();

        /// <summary>
        /// Handles the process of a client borrowing a book
        /// </summary>
        /// <param name="client">The client who wants to borrow the book</param>
        /// <param name="book">The book to be borrowed</param>
        /// <exception cref="InvalidOperationException">Thrown when the book is not available</exception>
        public void BorrowBook(Client client, Book book)
        {
            if (!book.IsAvailable)
                throw new InvalidOperationException("Book is not available");

            // Update book status
            book.IsAvailable = false;

            // Add to client's current borrowings
            client.BorrowedBooks.Add(book);

            // Create new borrow record
            var record = new BorrowRecord
            {
                Book = book,
                Client = client,
                BorrowDate = DateTime.Now
            };

            // Add to all tracking collections
            client.BorrowHistory.Add(record);
            book.BorrowHistory.Add(record);
            AllBorrowRecords.Add(record);
        }

        /// <summary>
        /// Handles the process of a client returning a book
        /// </summary>
        /// <param name="client">The client returning the book</param>
        /// <param name="book">The book being returned</param>
        /// <exception cref="InvalidOperationException">Thrown when the client didn't borrow this book</exception>
        public void ReturnBook(Client client, Book book)
        {
            if (!client.BorrowedBooks.Contains(book))
                throw new InvalidOperationException("Client didn't borrow this book");

            // Update book status
            book.IsAvailable = true;

            // Remove from client's current borrowings
            client.BorrowedBooks.Remove(book);

            // Find and update the borrow record
            var record = AllBorrowRecords.Find(r =>
                r.Book == book &&
                r.Client == client &&
                r.IsActive);

            if (record != null)
            {
                record.ReturnDate = DateTime.Now;
            }
        }

        /// <summary>
        /// Gets all currently active borrow records (books not yet returned)
        /// </summary>
        /// <returns>List of active borrow records</returns>
        public List<BorrowRecord> GetActiveBorrows()
        {
            return AllBorrowRecords.FindAll(r => r.IsActive);
        }

        /// <summary>
        /// Gets all books currently available for borrowing
        /// </summary>
        /// <returns>List of available books</returns>
        public List<Book> GetAvailableBooks()
        {
            return Books.FindAll(b => b.IsAvailable);
        }
    }
}
