using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Defines the contract for the Model component in the MVC architecture.
    /// Contains all data operations for books, clients, and borrowing records.
    /// </summary>
    public interface IModel
    {
        // Book-related operations

        /// <summary>Adds a new book to the library collection</summary>
        /// <param name="book">Book object to add</param>
        /// <returns>True if book was added successfully, false if it already existed</returns>
        bool AddBook(Book book);

        /// <summary>Gets the total count of books in the library</summary>
        int BookCount { get; }

        /// <summary>Checks if the book data file exists</summary>
        /// <returns>True if book data file exists, false otherwise</returns>
        bool BookDataExists();

        /// <summary>Deletes a book from the library</summary>
        /// <param name="title">Title of the book to delete</param>
        /// <returns>True if book was found and deleted, false otherwise</returns>
        bool DeleteBook(string title);

        /// <summary>Checks if a book exists in the library</summary>
        /// <param name="title">Title of the book to check</param>
        /// <returns>True if book exists, false otherwise</returns>
        bool BookExists(string title);

        /// <summary>Initializes and loads all data from persistent storage</summary>
        void InitializeData();

        /// <summary>Gets a formatted string listing all books</summary>
        /// <returns>String containing all book titles with availability status</returns>
        string ListAllBooks();

        /// <summary>Saves all modified data to persistent storage</summary>
        /// <returns>True if data was saved successfully, false otherwise</returns>
        bool SaveData();

        /// <summary>Searches for a book by title</summary>
        /// <param name="title">Title of the book to find</param>
        /// <returns>Book object if found, null otherwise</returns>
        Book SearchBook(string title);

        // Client-related operations

        /// <summary>Adds a new client to the system</summary>
        /// <param name="client">Client object to add</param>
        /// <returns>True if client was added successfully, false if CNP already existed</returns>
        bool AddClient(Client client);

        /// <summary>Gets the total count of registered clients</summary>
        int ClientCount { get; }

        /// <summary>Checks if the client data file exists</summary>
        /// <returns>True if client data file exists, false otherwise</returns>
        bool ClientDataExists();

        /// <summary>Deletes a client from the system</summary>
        /// <param name="cnp">CNP (Personal Numeric Code) of client to delete</param>
        /// <returns>True if client was found and deleted, false otherwise</returns>
        bool DeleteClient(string cnp);

        /// <summary>Checks if a client exists in the system</summary>
        /// <param name="cnp">CNP (Personal Numeric Code) to check</param>
        /// <returns>True if client exists, false otherwise</returns>
        bool ClientExists(string cnp);

        /// <summary>Gets a formatted string listing all clients</summary>
        /// <returns>String containing all client names</returns>
        string ListAllClients();

        /// <summary>Searches for a client by CNP</summary>
        /// <param name="cnp">CNP (Personal Numeric Code) to search for</param>
        /// <returns>Client object if found, null otherwise</returns>
        Client SearchClient(string cnp);

        // Borrowing operations

        /// <summary>Checks if the borrowing history data file exists</summary>
        /// <returns>True if borrowing history file exists, false otherwise</returns>
        bool BorrowHistoryDataExists();

        /// <summary>Processes a book borrowing operation</summary>
        /// <param name="bookTitle">Title of book to borrow</param>
        /// <param name="clientCNP">CNP of client borrowing the book</param>
        /// <returns>True if borrow was successful, false otherwise</returns>
        bool BorrowBook(string bookTitle, string clientCNP);

        /// <summary>Processes a book return operation</summary>
        /// <param name="bookTitle">Title of book being returned</param>
        /// <returns>True if return was successful, false otherwise</returns>
        bool ReturnBook(string bookTitle);

        /// <summary>Gets borrowing history with optional filters</summary>
        /// <param name="bookTitle">Optional filter by book title</param>
        /// <param name="clientCNP">Optional filter by client CNP</param>
        /// <returns>List of borrow records matching filters</returns>
        List<BorrowRecord> GetBorrowHistory(string bookTitle = null, string clientCNP = null);

        /// <summary>Gets all books in the library</summary>
        /// <returns>Complete list of all books</returns>
        List<Book> GetAllBooks();
    }
}