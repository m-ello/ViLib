using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Commons
{
    public partial class BookEditForm : Form
    {
        public Book UpdatedBook { get; private set; } // Property to hold the updated book

        public BookEditForm()
        {
            InitializeComponent();
        }

        public void SetBookDetails(Book book)
        {
            // Pre-fill the form with the book's details
            TitleTextBox.Text = book.title;
            AuthorTextBox.Text = book.author;
            PublisherTextBox.Text = book.publisher;
        }

        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(AuthorTextBox.Text) ||
                string.IsNullOrWhiteSpace(PublisherTextBox.Text))
            {
                MessageBox.Show("Toate campurile sunt obligatorii.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new Book object with the updated details
            UpdatedBook = new Book(TitleTextBox.Text.Trim(), AuthorTextBox.Text.Trim(), PublisherTextBox.Text.Trim());

            // Set the dialog result to OK and close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
