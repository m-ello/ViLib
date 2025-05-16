using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;

namespace View
{
    public partial class FormView : Form, IView
    {
        private IPresenter _presenter;
        private List<Book> _books = new List<Book>(); // Store the books displayed in the list box


        // Random generator for creating random books
        private Random _random = new Random();

        public FormView()
        {
            InitializeComponent();

            // Subscribe to the FormClosing event
            this.FormClosing += FormView_FormClosing;
        }

        // Handle the form closing event
        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the default closing behavior
            e.Cancel = true;

            // Use the presenter to handle the exit logic instead
            if (_presenter != null)
            {
                _presenter.Exit();
            }
            else
            {
                // If presenter is not available, still allow the form to close
                Environment.Exit(0);
            }
        }

        // Helper method to generate random strings
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

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

            // Set the text color and append to the StatusBox
            StatusBox.SelectionStart = StatusBox.TextLength;
            StatusBox.SelectionLength = 0;
            StatusBox.SelectionColor = textColor;
            StatusBox.AppendText(text + Environment.NewLine);
            StatusBox.ScrollToCaret();
        }

        public void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
            _presenter?.Init();
        }

        void IView.ShowBooks(List<Book> books)
        {
            _books = books; // Store the books for later reference
            bookListBox.Items.Clear();
            foreach (var book in books)
            {
                string bookDetails = $"\"{book.title}\" de {book.author}, publicat de {book.publisher}";
                bookListBox.Items.Add(bookDetails);
            }
        }

        void IView.ShowClients(List<Client> clients)
        {
            throw new NotImplementedException();
        }

        void IView.ShowBorrowHistory(List<BorrowRecord> borrowRecords)
        {
            throw new NotImplementedException();
        }

        void IView.ShowBookDetails(Book book)
        {
            using (var bookDetailsForm = new BookDetailsForm())
            {
                bookDetailsForm.SetBookDetails(book);
                bookDetailsForm.ShowDialog();
            }
        }

        void IView.ShowClientDetails(Client client)
        {
            throw new NotImplementedException();
        }

        void IView.ShowBorrowRecordDetails(BorrowRecord record)
        {
            throw new NotImplementedException();
        }

        private void detailsBookButton_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (bookListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza o carte, te rog.", "Nicio selectie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected book
            var selectedBook = _books[bookListBox.SelectedIndex];

            // Ask the presenter to show the book details
            _presenter.ShowBookDetails(selectedBook);
        }

        private void deleteBookButton_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (bookListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza o carte, te rog.", "Nicio selectie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected book
            var selectedBook = _books[bookListBox.SelectedIndex];

            // Confirm deletion
            var result = MessageBox.Show($"Esti sigur ca vrei sa stergi cartea \"{selectedBook.title}\"?",
                                          "Confirmare stergere",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                // Ask the presenter to delete the book
                _presenter.RemoveBook(selectedBook.title);

                // Refresh the book list
                _presenter.ShowAllBooks();
            }
        }

        private void addBookButton_Click(object sender, EventArgs e)
        {
            using (var bookAddForm = new BookAddForm())
            {
                // Show the form as a dialog
                if (bookAddForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the new book from the form
                    var newBook = bookAddForm.NewBook;

                   _presenter.AddBook(newBook);
                }
            }
        }

        private void editBookButton_Click(object sender, EventArgs e)
        {
            // Check if an item is selected
            if (bookListBox.SelectedIndex == -1)
            {
                MessageBox.Show("Selecteaza o carte, te rog.", "Nicio selectie", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Get the selected book
            var selectedBook = _books[bookListBox.SelectedIndex];

            // Open the BookEditForm with the selected book's details
            using (var bookEditForm = new BookEditForm())
            {
                bookEditForm.SetBookDetails(selectedBook); // Pre-fill the form with the book's details

                if (bookEditForm.ShowDialog() == DialogResult.OK)
                {
                    // Get the updated book details from the form
                    var updatedBook = bookEditForm.UpdatedBook;

                    // Delegate the update to the presenter
                    _presenter.EditBook(selectedBook.title, updatedBook);
                }
            }
        }
    }
}
