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
            throw new NotImplementedException();
        }

        void IView.ShowClientDetails(Client client)
        {
            throw new NotImplementedException();
        }

        void IView.ShowBorrowRecordDetails(BorrowRecord record)
        {
            throw new NotImplementedException();
        }
    }
}
