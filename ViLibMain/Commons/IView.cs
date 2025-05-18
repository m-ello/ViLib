using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Commons
{
    /// <summary>
    /// Defines the contract for the View component in the MVC architecture.
    /// Contains all UI display operations and presenter communication methods.
    /// </summary>
    public interface IView
    {
        /// <summary>
        /// Logs a status message to the view with specified color coding
        /// </summary>
        /// <param name="text">The message text to display</param>
        /// <param name="color">Color identifier ("red", "blue", etc.)</param>
        void LogStatus(string text, string color);

        /// <summary>
        /// Displays a list of books in the view
        /// </summary>
        /// <param name="books">List of Book objects to display</param>
        void ShowBooks(List<Book> books);

        /// <summary>
        /// Displays a list of clients in the view
        /// </summary>
        /// <param name="clients">List of Client objects to display</param>
        void ShowClients(List<Client> clients);

        /// <summary>
        /// Displays borrowing history records in the view
        /// </summary>
        /// <param name="borrowRecords">List of BorrowRecord objects to display</param>
        void ShowBorrowHistory(List<BorrowRecord> borrowRecords);

        /// <summary>
        /// Shows detailed information about a specific book
        /// </summary>
        /// <param name="book">Book object containing details to display</param>
        void ShowBookDetails(Book book);

        /// <summary>
        /// Shows detailed information about a specific client
        /// </summary>
        /// <param name="client">Client object containing details to display</param>
        void ShowClientDetails(Client client);

        /// <summary>
        /// Shows detailed information about a specific borrowing record
        /// </summary>
        /// <param name="record">BorrowRecord object containing details to display</param>
        void ShowBorrowRecordDetails(BorrowRecord record);

        /// <summary>
        /// Sets the presenter that will handle this view's events
        /// </summary>
        /// <param name="presenter">Presenter instance to register</param>
        void SetPresenter(IPresenter presenter);
    }
}