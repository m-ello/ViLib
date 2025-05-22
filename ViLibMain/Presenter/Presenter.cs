using System;
using System.Collections.Generic;
using System.Diagnostics.Eventing.Reader;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Commons;
using System.Windows.Forms;
using Timer = System.Windows.Forms.Timer;
using System.Xml.Linq;

namespace PresenterNamespace
{
    /// <summary>
    /// The Presenter class acts as the mediator between the View and Model,
    /// handling all business logic and user interaction flow.
    /// Implements the IPresenter interface to provide concrete functionality.
    /// </summary>
    public class Presenter : IPresenter
    {
        private readonly IModel _model;  // Reference to the data/model layer
        private readonly IView _view;    // Reference to the view/UI layer

        /// <summary>
        /// Initializes a new instance of the Presenter class
        /// </summary>
        /// <param name="view">The view interface implementation</param>
        /// <param name="model">The model interface implementation</param>
        public Presenter(IView view, IModel model)
        {
            _model = model;
            _view = view;
        }

        /// <summary>
        /// Initializes the application by loading data and setting up the initial state
        /// </summary>
        void IPresenter.Init()
        {
            // Check and report missing data files
            if (!_model.BookDataExists())
            {
                _view.LogStatus("Fisierul cu carti nu exista." + Environment.NewLine, "red");
            }

            if (!_model.ClientDataExists())
            {
                _view.LogStatus("Fisierul cu clienti nu exista." + Environment.NewLine, "red");
            }

            if (!_model.BorrowHistoryDataExists())
            {
                _view.LogStatus("Fișierul cu istoricul împrumuturilor nu există." + Environment.NewLine, "red");
            }

            // Load data from model
            _model.InitializeData();

            // Report loaded data statistics
            _view.LogStatus("Fisier incarcat: " + _model.BookCount + " carti.", "magenta");
            _view.LogStatus("Fisier incarcat: " + _model.ClientCount + " clienti.", "magenta");
            _view.LogStatus($"Istoric încărcat: {_model.GetBorrowHistory().Count} înregistrări.", "magenta");

            // Display all books in the view
            ((IPresenter)this).ShowAllBooks();
        }

        /// <summary>
        /// Handles application exit procedure with data saving and cleanup
        /// </summary>
        void IPresenter.Exit()
        {
            // Attempt to save data
            if (_model.SaveData())
                _view.LogStatus("Fisierul a fost salvat." + Environment.NewLine, "magenta");

            _view.LogStatus("La revedere.", "default");

            // Determine if we're running in a Windows Forms context
            bool isWindowsFormsView =
                Application.OpenForms.Count > 0 ||
                _view is Control;

            // Handle exit differently based on application type
            if (isWindowsFormsView)
            {
                // Use timer for graceful exit in WinForms
                Timer exitTimer = new Timer
                {
                    Interval = 1000 // 1 second delay
                };
                exitTimer.Tick += (sender, e) =>
                {
                    exitTimer.Stop();
                    Environment.Exit(0);
                };
                exitTimer.Start();

                Application.DoEvents();
            }
            else
            {
                // Simple exit for non-WinForms applications
                Thread.Sleep(1000);
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Checks if a book with the specified title exists
        /// </summary>
        /// <param name="name">Title of the book to check</param>
        /// <returns>True if book exists, false otherwise</returns>
        bool IPresenter.BookExists(string name)
        {
            return _model.BookExists(name);
        }

        /// <summary>
        /// Retrieves a book by its title
        /// </summary>
        /// <param name="name">Title of the book to retrieve</param>
        /// <returns>The Book object if found, null otherwise</returns>
        Book IPresenter.GetBook(string name)
        {
            return _model.SearchBook(name);
        }

        /// <summary>
        /// Displays all books in the view
        /// </summary>
        void IPresenter.ShowAllBooks()
        {
            _view.ShowBooks(_model.GetAllBooks());
        }

        /// <summary>
        /// Removes a book from the library
        /// </summary>
        /// <param name="name">Title of the book to remove</param>
        void IPresenter.RemoveBook(string name)
        {
            if (_model.DeleteBook(name))
            {
                _view.LogStatus($"Cartea a fost stearsa.", "blue");
            }
            else
            {
                _view.LogStatus($"Cartea nu a fost gasita in lista.", "red");
            }
        }

        /// <summary>
        /// Checks if a client with the specified CNP exists
        /// </summary>
        /// <param name="CNP">Client's Personal Numeric Code</param>
        /// <returns>True if client exists, false otherwise</returns>
        bool IPresenter.ClientExists(string CNP)
        {
            return _model.ClientExists(CNP);
        }

        /// <summary>
        /// Adds a new client to the system
        /// </summary>
        /// <param name="c">Client object to add</param>
        void IPresenter.AddClient(Client c)
        {
            if (!_model.AddClient(c))
            {
                _view.LogStatus($"Clientul {c.familyName} {c.firstName} a fost suprascris", "red");
            }
            else
            {
                _view.LogStatus($"Clientul {c.familyName} {c.firstName} a fost adaugat", "blue");
            }
        }

        /// <summary>
        /// Removes a client from the system
        /// </summary>
        /// <param name="cnp">Personal Numeric Code of the client to remove</param>
        void IPresenter.RemoveClient(string cnp)
        {
            if (_model.DeleteClient(cnp))
            {
                _view.LogStatus($"Clientul a fost sters.", "blue");
            }
            else
            {
                _view.LogStatus($"Clientul nu a fost gasit in lista.", "red");
            }
        }

        /// <summary>
        /// Retrieves a client by CNP
        /// </summary>
        /// <param name="cnp">Personal Numeric Code of the client to retrieve</param>
        /// <returns>The Client object if found, null otherwise</returns>
        Client IPresenter.GetClient(string cnp)
        {
            return _model.SearchClient(cnp);
        }

        /// <summary>
        /// Handles the book borrowing process
        /// </summary>
        /// <param name="bookTitle">Title of the book to borrow</param>
        /// <param name="clientCNP">Personal Numeric Code of the borrowing client</param>
        /// <returns>True if borrowing was successful, false otherwise</returns>
        bool IPresenter.BorrowBook(string bookTitle, string clientCNP)
        {
            bool success = _model.BorrowBook(bookTitle, clientCNP);
            if (success)
            {
                _view.LogStatus($"Cartea '{bookTitle}' a fost împrumutată cu succes.", "blue");
            }
            else
            {
                _view.LogStatus($"Nu s-a putut împrumuta cartea '{bookTitle}'. Verificați disponibilitatea sau datele clientului.", "red");
            }
            return success;
        }

        /// <summary>
        /// Handles the book return process
        /// </summary>
        /// <param name="bookTitle">Title of the book being returned</param>
        /// <returns>True if return was successful, false otherwise</returns>
        bool IPresenter.ReturnBook(string bookTitle)
        {
            bool success = _model.ReturnBook(bookTitle);
            if (success)
            {
                _view.LogStatus($"Cartea '{bookTitle}' a fost returnată cu succes.", "blue");
            }
            else
            {
                _view.LogStatus($"Nu s-a putut returna cartea '{bookTitle}'. Verificați dacă este împrumutată.", "red");
            }
            return success;
        }

        /// <summary>
        /// Retrieves and formats borrowing history with optional filters
        /// </summary>
        /// <param name="bookTitle">Optional filter by book title</param>
        /// <param name="clientCNP">Optional filter by client CNP</param>
        /// <returns>Formatted string containing the filtered borrowing history</returns>
        string IPresenter.GetBorrowHistory(string bookTitle, string clientCNP)
        {
            var history = _model.GetBorrowHistory(bookTitle, clientCNP);
            if (history.Count == 0)
                return "Nu există istoric pentru criteriile specificate.";

            var sb = new StringBuilder();
            foreach (var record in history)
            {
                sb.AppendLine($"ID: {record.Id}");
                sb.AppendLine($"Carte: {record.Book.title}");
                sb.AppendLine($"Client: {record.Client.firstName} {record.Client.familyName}");
                sb.AppendLine($"CNP Client: {record.Client.CNP}");
                sb.AppendLine($"Data împrumut: {record.BorrowDate}");
                sb.AppendLine($"Data returnare: {(record.ReturnDate.HasValue ? record.ReturnDate.ToString() : "Încă împrumutată")}");
                sb.AppendLine("---------------------");
            }
            return sb.ToString();
        }

        /// <summary>
        /// Displays detailed information about a specific book
        /// </summary>
        /// <param name="book">Book object to display</param>
        void IPresenter.ShowBookDetails(Book book)
        {
            _view.ShowBookDetails(book);
        }

        /// <summary>
        /// Adds a new book to the library
        /// </summary>
        /// <param name="b">Book object to add</param>
        void IPresenter.AddBook(Book b)
        {
            bool success = _model.AddBook(b);

            if (success)
            {
                _view.LogStatus($"Cartea \"{b.title}\" a fost adaugata.", "green");
                ((IPresenter)this).ShowAllBooks();
            }
            else
            {
                _view.LogStatus($"Cartea \"{b.title}\" exista deja.", "red");
            }
        }

        /// <summary>
        /// Updates an existing book's information
        /// </summary>
        /// <param name="oldTitle">Current title of the book to update</param>
        /// <param name="updatedBook">Updated Book object with new information</param>
        void IPresenter.EditBook(string oldTitle, Book updatedBook)
        {
            // Check if the book exists
            if (!_model.BookExists(oldTitle))
            {
                _view.LogStatus($"Cartea \"{oldTitle}\" nu exista.", "red");
                return;
            }

            // Update the book in the model
            _model.DeleteBook(oldTitle); // Remove the old book
            bool success = _model.AddBook(updatedBook); // Add the updated book

            // Notify the user of the result
            if (success)
            {
                _view.LogStatus($"Cartea \"{oldTitle}\" a fost actualizata.", "green");
                ((IPresenter)this).ShowAllBooks();
            }
            else
            {
                _view.LogStatus($"Eroare la actualizarea cartii \"{oldTitle}\".", "red");
            }
        }
    }
}