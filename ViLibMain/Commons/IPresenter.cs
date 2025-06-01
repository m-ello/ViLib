using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Defines the contract for a presenter that mediates between the library system
    /// and the user interface, handling all library operations.
    /// </summary>
    public interface IPresenter
    {
        //---------------------------------------------------------------------
        //-------------------------  book operations ------------------------
        //---------------------------------------------------------------------

        /// <summary>
        /// Adds a new book to the library collection
        /// </summary>
        /// <param name="b">Book object to add</param>
        void AddBook(Book b);

        /// <summary>
        /// Checks if a book with the given title exists in the library
        /// </summary>
        /// <param name="title">Title of the book to check</param>
        /// <returns>True if book exists, false otherwise</returns>
        bool BookExists(string title);

        /// <summary>
        /// Performs cleanup operations and exits the application
        /// </summary>
        void Exit();

        /// <summary>
        /// Retrieves a book by its title
        /// </summary>
        /// <param name="title">Title of the book to retrieve</param>
        /// <returns>The Book object if found, null otherwise</returns>
        Book GetBook(string title);

        /// <summary>
        /// Initializes the presenter and loads necessary data
        /// </summary>
        void Init();

        /// <summary>
        /// Removes a book from the library collection by title
        /// </summary>
        /// <param name="title">Title of the book to remove</param>
        void RemoveBook(string title);

        /// <summary>
        /// Displays information about all books in the library
        /// </summary>
        void ShowAllBooks();

        /// <summary>
        /// Displays detailed information about a specific book
        /// </summary>
        /// <param name="book">Book object to display</param>
        void ShowBookDetails(Book book);

        /// <summary>
        /// Updates an existing book's information
        /// </summary>
        /// <param name="title">Current title of the book to edit</param>
        /// <param name="b">Updated Book object</param>
        void EditBook(string title, Book b);

        //---------------------------------------------------------------------
        //-------------------------  client operations ------------------------
        //---------------------------------------------------------------------

        /// <summary>
        /// Adds a new client to the library system
        /// </summary>
        /// <param name="c">Client object to add</param>
        void AddClient(Client c);

        /// <summary>
        /// Updates an existing client's information
        /// </summary>
        /// <param name="CNP">Current CNP of the client to edit</param>
        /// <param name="c">Updated Client object</param>
        void EditClient(string CNP, Client c);

        /// <summary>
        /// Checks if a client with the given CNP exists in the system
        /// </summary>
        /// <param name="cnp">Client's Personal Numeric Code to check</param>
        /// <returns>True if client exists, false otherwise</returns>
        bool ClientExists(string cnp);

        /// <summary>
        /// Removes a client from the system by CNP
        /// </summary>
        /// <param name="cnp">Personal Numeric Code of the client to remove</param>
        void RemoveClient(string cnp);

        /// <summary>
        /// Retrieves a client by their CNP
        /// </summary>
        /// <param name="cnp">Personal Numeric Code of the client to retrieve</param>
        /// <returns>The Client object if found, null otherwise</returns>
        Client GetClient(string cnp);

        /// <summary>
        /// Displays detailed information about a specific client
        /// </summary>
        /// <param name="client">Client object to display</param>
        void ShowClientDetails(Client client);

        /// <summary>
        /// Displays information about all clients in the library
        /// </summary>
        void ShowAllClients();
        //---------------------------------------------------------------------
        //-------------------------  borrow operations ------------------------
        //---------------------------------------------------------------------


        /// <summary>
        /// Processes the return of a borrowed book
        /// </summary>
        /// <param name="bookTitle">Title of the book being returned</param>
        /// <returns>True if return was successful, false otherwise</returns>
        bool ReturnBook(string bookTitle, string clientFirstName);

        /// <summary>
        /// Retrieves borrowing history with optional filters
        /// </summary>
        /// <param name="bookTitle">Optional filter by book title</param>
        /// <param name="clientCNP">Optional filter by client CNP</param>
        /// <returns>Formatted string containing the borrowing history</returns>
        string GetBorrowHistory(string bookTitle = null, string clientCNP = null);

        /// <summary>
        /// Processes a book borrowing request
        /// </summary>
        /// <param name="bookTitle">Title of the book to borrow</param>
        /// <param name="clientCNP">Personal Numeric Code of the borrowing client</param>
        /// <returns>True if borrowing was successful, false otherwise</returns>
        bool BorrowBook(string bookTitle, string clientCNP);

        /// <summary>
        /// Adds a new borrow record to the library collection
        /// </summary>
        /// <param name="br">Borrow record object to add</param>
        void AddBorrowRecord(BorrowRecord br);

        /// <summary>
        /// Updates an existing client's information
        /// </summary>
        /// <param name="CNP">Current CNP of the client to edit</param>
        ///<param name="bookTitle">Current bookTitleto edit</param>
        /// <param name="br">Updated BorrowRecord object</param>
        void EditBorrowRecord(string CNP, string bookTitle, BorrowRecord br);

        /// <summary>
        /// Processes the borrow history
        /// </summary>
        void ShowAllBorrowRecords();

        /// <summary>
        /// Shows the borrow record details
        /// /// <param name="br">Borrow record object to show</param>
        /// </summary>
        void ShowBorrowRecordDetails(BorrowRecord br);

        /// <summary>
        /// Removes a borrow record from the system by title of the book
        /// </summary>
        /// <param name="bookTitle">Book title of the borrow record to remove</param>
        void RemoveBorrowRecord(string bookTitle);
    }
}
