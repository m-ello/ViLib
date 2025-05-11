using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
namespace Commons
{
    public class Library
    {
        public List<Book> Books { get; set; } = new List<Book>();
        public List<Client> Clients { get; set; } = new List<Client>();
        public List<BorrowRecord> AllBorrowRecords { get; set; } = new List<BorrowRecord>();

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

        public List<BorrowRecord> GetActiveBorrows()
        {
            return AllBorrowRecords.FindAll(r => r.IsActive);
        }

        public List<Book> GetAvailableBooks()
        {
            return Books.FindAll(b => b.IsAvailable);
        }
    }
}
