using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace Commons
{
    /// <summary>
    /// A form for creating a new BorrowRecord by specifying the client CNP and book title.
    /// </summary>
    public partial class BorrowAddForm : Form
    {
        public BorrowRecord NewBorrowRecord { get; private set; }

        private readonly List<Client> _clients;
        private readonly List<Book> _books;

        public BorrowAddForm(List<Client> clients, List<Book> books)
        {
            InitializeComponent();
            _clients = clients;
            _books = books;
        }

        private void addBorrowButton_Click(object sender, EventArgs e)
        {
            string cnp = CNPTextBox.Text.Trim();
            string title = TitleTextBox.Text.Trim();

            if (string.IsNullOrWhiteSpace(cnp) || string.IsNullOrWhiteSpace(title))
            {
                MessageBox.Show("Introduceți atât CNP-ul cât și titlul cărții.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            var client = _clients.FirstOrDefault(c => c.CNP == cnp);
            var book = _books.FirstOrDefault(b => b.title.Equals(title, StringComparison.OrdinalIgnoreCase));

            if (client == null)
            {
                MessageBox.Show("Clientul nu a fost găsit.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (book == null)
            {
                MessageBox.Show("Cartea nu a fost găsită.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!book.IsAvailable)
            {
                MessageBox.Show("Cartea nu este disponibilă pentru împrumut.", "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            try
            {
                // Manually update availability and client list
                book.IsAvailable = false;
                client.BorrowedBooks.Add(book);

                // Create the borrow record (not added to history here)
                NewBorrowRecord = new BorrowRecord(client, book);

                DialogResult = DialogResult.OK;
                Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Eroare", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void cancelButton_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
