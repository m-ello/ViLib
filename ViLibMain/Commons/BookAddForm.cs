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
    public partial class BookAddForm : Form
    {
        public Book NewBook { get; private set; } // Property to hold the new book

        public BookAddForm()
        {
            InitializeComponent();
        }

        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Validate input fields
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(AuthorTextBox.Text) ||
                string.IsNullOrWhiteSpace(PublisherTextBox.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate.", "Eroare de validare", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Create a new Book object
            NewBook = new Book(TitleTextBox.Text.Trim(), AuthorTextBox.Text.Trim(), PublisherTextBox.Text.Trim());

            // Set the dialog result to OK and close the form
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
