using System;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Window;

namespace View
{
    /// <summary>
    /// The main form view for the library application that implements IView interface.
    /// Handles all user interactions and displays data from the presenter.
    /// </summary>
    public partial class FormView : Form, IView
    {
        private IPresenter _presenter; // Reference to the presenter for business logic
        private List<Book> _books = new List<Book>(); // Local cache of books displayed in the list
        private List<Client> _clients = new List<Client>(); // Local cache of clients displayed in the list
        private List<BorrowRecord> _borrowRecords = new List<BorrowRecord>(); // Local cache of borrow records displayed in the list
        private Library _library = new Library();

        // Random generator for creating random books (used in potential test scenarios)
        private Random _random = new Random();

        /// <summary>
        /// Initializes a new instance of the FormView class
        /// </summary>
        public FormView()
        {
            InitializeComponent();

            // Subscribe to the FormClosing event to handle custom exit logic
            this.FormClosing += FormView_FormClosing;
        }

        /// <summary>
        /// Handles the form closing event to ensure proper cleanup
        /// </summary>
        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the default closing behavior to allow custom exit handling
            e.Cancel = true;

            // Use the presenter to handle the exit logic if available
            if (_presenter != null)
            {
                _presenter.Exit();
            }
            else
            {
                // Fallback exit if presenter isn't available
                Environment.Exit(0);
            }
        }

        /// <summary>
        /// Generates a random string of specified length (for testing/demo purposes)
        /// </summary>
        /// <param name="length">Length of the string to generate</param>
        /// <returns>Randomly generated string</returns>
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        /// <summary>
        /// Logs status messages to the status box with specified color coding
        /// </summary>
        /// <param name="text">The message text to display</param>
        /// <param name="color">Color identifier for the message</param>
        public void LogStatus(string text, string color)
        {
            // Map the color string to a System.Drawing.Color
            Color textColor = Color.Black;
            switch (color.ToLower())
            {
                case "red":
                    textColor = Color.Red;
                    break;
                case "blue":
                    textColor = Color.Blue;
                    break;
                case "magenta":
                    textColor = Color.Magenta;
                    break;
                case "green":
                    textColor = Color.Green;
                    break;
                case "default":
                    textColor = Color.Black;
                    break;
            }

            // Set the text color and append to the StatusBox with proper formatting
            StatusBox.SelectionStart = StatusBox.TextLength;
            StatusBox.SelectionLength = 0;
            StatusBox.SelectionColor = textColor;
            StatusBox.AppendText(text + Environment.NewLine);
            StatusBox.ScrollToCaret(); // Auto-scroll to the newest message
        }

        /// <summary>
        /// Sets the presenter for this view and initializes the application
        /// </summary>
        /// <param name="presenter">The presenter instance to use</param>
        public void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
            _presenter?.Init(); // Initialize if presenter is not null
        }

        /// <summary>
        /// Displays a list of books in the book list box
        /// </summary>
        /// <param name="books">List of books to display</param>
        void IView.ShowBooks(List<Book> books)
        {
            _books = books; // Update local book cache
            bookListBox.Items.Clear(); // Clear existing items

            // Add formatted book details for each book
            foreach (var book in books)
            {
                string bookDetails = $"\"{book.title}\" de {book.author}, publicat de {book.publisher}";
                bookListBox.Items.Add(bookDetails);
            }
        }

        /// <summary>
        /// Displays a list of clients in the book list box
        /// </summary>
        /// <param name="clients">List of clients to display</param>
        void IView.ShowClients(List<Client> clients)
        {
            _clients = clients; // Update local client cache
            clientListBox.Items.Clear(); // Clear existing items

            // Add formatted book details for each book
            foreach (var client in clients)
            {
                string clientDetails = $"NP: {client.familyName} {client.firstName}, CNP: {client.CNP}, Adresa: {client.address}";
                clientListBox.Items.Add(clientDetails);
            }
        }

        /// <summary>
        /// Displays the borrow records in the borrow history box
        /// </summary>
        /// <param name="borrowRecords">List of borrow records to display</param>
        void IView.ShowBorrowHistory(List<BorrowRecord> borrowRecords)
        {
            _borrowRecords = borrowRecords; // Update local borrow record cache
            borrowHistoryBox.Items.Clear(); // Clear existing items

            // Add formatted book details for each book
            foreach (var borrowRecord in borrowRecords)
            {
                string borrowDetails = $"Carte: {borrowRecord.BookTitle}, Client: {borrowRecord.Client.firstName}, Data: {borrowRecord.BorrowDate}";
                borrowHistoryBox.Items.Add(borrowDetails);
            }
        }

        /// <summary>
        /// Shows detailed information about a specific book in a dialog
        /// </summary>
        /// <param name="book">The book to display</param>
        void IView.ShowBookDetails(Book book)
        {
            using (var bookDetailsForm = new BookDetailsForm())
            {
                bookDetailsForm.SetBookDetails(book);
                bookDetailsForm.ShowDialog(); // Show as modal dialog
            }
        }

        /// <summary>
        /// Handles click event for the book details button
        /// </summary>
        private void detailsBookButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (bookListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza o carte, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected book from local cache
            var selectedBook = _books[bookListBox.SelectedIndex];

            // Delegate to presenter to show details
            _presenter.ShowBookDetails(selectedBook);
        }

        /// <summary>
        /// Handles click event for the delete book button
        /// </summary>
        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (bookListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza o carte, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Get selected book from local cache
            var selectedBook = _books[bookListBox.SelectedIndex];

            // Confirm deletion with user
            var result = MessageBox.Show($"Esti sigur ca vrei sa stergi cartea \"{selectedBook.title}\"?",
                                      "Confirmare stergere",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delegate to presenter for deletion
                _presenter.RemoveBook(selectedBook.title);

                // Refresh the book list
                _presenter.ShowAllBooks();
            }
        }

        /// <summary>
        /// Handles click event for the add book button
        /// </summary>
        private void addBookButton_Click(object sender, EventArgs e)
        {
            using (var bookAddForm = new BookAddForm())
            {
                // Show the add form and process if user accepted
                if (bookAddForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the new book from the form and delegate to presenter
                    var newBook = bookAddForm.NewBook;
                    _presenter.AddBook(newBook);
                }
            }
        }

        /// <summary>
        /// Handles click event for the edit book button
        /// </summary>
        private void editBookButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (bookListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza o carte, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected book from local cache
            var selectedBook = _books[bookListBox.SelectedIndex];

            using (var bookEditForm = new BookEditForm())
            {
                // Pre-fill form with current book details
                bookEditForm.SetBookDetails(selectedBook);

                // Process if user submitted changes
                if (bookEditForm.ShowDialog() == DialogResult.OK)
                {
                    // Get updated book and delegate to presenter
                    var updatedBook = bookEditForm.UpdatedBook;
                    _presenter.EditBook(selectedBook.title, updatedBook);
                }
            }
        }

        //---------------------------------------------------------------------
        //-------------------- Client Management Tab Control -------------------
        //---------------------------------------------------------------------

        /// <summary>
        /// Shows detailed information about a specific client in a dialog
        /// </summary>
        /// <param name="client">The client to display</param>
        void IView.ShowClientDetails(Client client)
        {
            using (var clientDetailsForm = new ClientDetailsForm())
            {
                clientDetailsForm.SetClientDetails(client);
                clientDetailsForm.ShowDialog(); // Show as modal dialog
            }
        }

        /// <summary>
        /// Handles click event for the add book button
        /// </summary>
        private void addClientButton_Click(object sender, EventArgs e)
        {
            using (var clientAddForm = new ClientAddForm())
            {
                // Show the add form and process if user accepted
                if (clientAddForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the new client from the form and delegate to presenter
                    var newClient = clientAddForm.NewClient;
                    _presenter.AddClient(newClient);
                }
            }
        }

        /// <summary>
        /// Handles click event for the edit client button
        /// </summary>
        private void editClientButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (clientListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un client, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected client from local cache
            var selectedClient = _clients[clientListBox.SelectedIndex];

            using (var clientEditForm = new ClientEditForm())
            {
                // Pre-fill form with current client details
                clientEditForm.SetClientDetails(selectedClient);

                // Process if user submitted changes
                if (clientEditForm.ShowDialog() == DialogResult.OK)
                {
                    // Get updated client and delegate to presenter
                    var updatedClient = clientEditForm.UpdatedClient;
                    _presenter.EditClient(selectedClient.CNP, updatedClient);
                }
            }
        }

        /// <summary>
        /// Handles click event for the client details button
        /// </summary>
        private void detailsClientButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (clientListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un client, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected client from local cache
            var selectedClient = _clients[clientListBox.SelectedIndex];

            // Delegate to presenter to show details
            _presenter.ShowClientDetails(selectedClient);
        }

        /// <summary>
        /// Handles click event for the delete client button
        /// </summary>
        private void deleteClientButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (clientListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un client, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Get selected client from local cache
            var selectedClient = _clients[clientListBox.SelectedIndex];

            // Confirm deletion with user
            var result = MessageBox.Show($"Esti sigur ca vrei sa stergi clientul \"{selectedClient.firstName}\"?",
                                      "Confirmare stergere",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delegate to presenter for deletion
                _presenter.RemoveClient(selectedClient.CNP);

                // Refresh the client list
                _presenter.ShowAllClients();
            }
        }

        //---------------------------------------------------------------------
        //-------------------------------- Help -------------------------------
        //---------------------------------------------------------------------

        private void helpButton_Click(object sender, EventArgs e)
        {
            string helpFilePath = System.IO.Path.Combine(Application.StartupPath, "help.chm");

            if (File.Exists(helpFilePath))
            {
                Help.ShowHelp(this, helpFilePath);
            }
            else
            {
                MessageBox.Show("Nu se poate deschide fisierul help!");
            }
        }


        //---------------------------------------------------------------------
        //------------------------  Borrow Records ----------------------------
        //---------------------------------------------------------------------


        void IView.ShowBorrowRecordDetails(BorrowRecord borrowRecord)
        {
            using (var borrowRecordDetailsForm = new BorrowDetailsForm())
            {
                borrowRecordDetailsForm.SetBorrowRecordDetails(borrowRecord);
                borrowRecordDetailsForm.ShowDialog(); // Show as modal dialog
            }
        }

        /// <summary>
        /// Handles click event for the add borrow button
        /// </summary>
        private void addBorrowButton_Click(object sender, EventArgs e)
        {
            using (var borrowAddForm = new BorrowAddForm(_clients, _books))
            {
                if (borrowAddForm.ShowDialog() == DialogResult.OK)
                {
                    var newBorrowRecord = borrowAddForm.NewBorrowRecord;

                    // Optionally update UI or notify presenter that data changed
                    MessageBox.Show($"Împrumut adăugat:\n{newBorrowRecord.Client.firstName} a împrumutat '{newBorrowRecord.Book.title}'",
                                    "Succes", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Delegate to presenter to handle the new borrow record
                    _presenter.AddBorrowRecord(newBorrowRecord);

                    // Refresh the borrow history
                    _presenter.ShowAllBorrowRecords();

                }
            }
        }


        /// <summary>
        /// Handles click event for the edit borrow record button
        /// </summary>
        private void deleteBorrowButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (borrowHistoryBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un imprumut, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Get selected borrow record from local cache
            var selectedBorrowRecord = _borrowRecords[borrowHistoryBox.SelectedIndex];

            // Confirm deletion with user
            var result = MessageBox.Show($"Sigur vrei sa stergi imprumutul \"{selectedBorrowRecord.Client.firstName}\" cu cartea {selectedBorrowRecord.BookTitle} ?",
                                      "Confirmare stergere",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delegate to presenter for returning, if we delete a record, we have to make a returning operation
                _presenter.ReturnBook(selectedBorrowRecord.BookTitle, selectedBorrowRecord.Client.firstName);

                // Delegate to presenter for deletion
                _presenter.RemoveBorrowRecord(selectedBorrowRecord.BookTitle);

                // Refresh the client list
                _presenter.ShowAllBorrowRecords();
            }
        }

        private void detailsBorrowButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (borrowHistoryBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un imprumut, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get selected borrow from local cache
            var selectedBorrow = _borrowRecords[borrowHistoryBox.SelectedIndex];

            // Delegate to presenter to show details
            _presenter.ShowBorrowRecordDetails(selectedBorrow);
        }

        private void returnBorrowButton_Click(object sender, EventArgs e)
        {
            // Validate selection
            if (borrowHistoryBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza un imprumut, te rog.", "Nicio selectie",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            // Get selected borrow from local cache
            var selectedBorrow = _borrowRecords[borrowHistoryBox.SelectedIndex];

            // Confirm deletion with user
            var result = MessageBox.Show($"Esti sigur ca vrei sa returnezi cartea \"{selectedBorrow.BookTitle}\"?",
                                      "Confirmare stergere",
                                      MessageBoxButtons.YesNo,
                                      MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Delegate to presenter for deletion
                _presenter.ReturnBook(selectedBorrow.BookTitle, selectedBorrow.Client.firstName);

                // Refresh the client list
                _presenter.ShowAllBorrowRecords();
            }
        }
    }
}