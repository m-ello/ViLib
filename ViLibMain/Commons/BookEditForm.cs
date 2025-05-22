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
    /// <summary>
    /// A dialog form for editing existing book information in the library system.
    /// Provides fields to modify a book's title, author, and publisher information.
    /// </summary>
    public partial class BookEditForm : Form
    {
        /// <summary>
        /// Gets the updated Book object containing the modified information.
        /// This property is set when the user confirms the edit with valid data.
        /// </summary>
        public Book UpdatedBook { get; private set; }

        /// <summary>
        /// Initializes a new instance of the BookEditForm class.
        /// Sets up the form components through the auto-generated InitializeComponent() method.
        /// </summary>
        public BookEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pre-populates the form fields with the current book information.
        /// </summary>
        /// <param name="book">The Book object containing the current details to be edited</param>
        public void SetBookDetails(Book book)
        {
            // Populate form controls with existing book data
            TitleTextBox.Text = book.title;
            AuthorTextBox.Text = book.author;
            PublisherTextBox.Text = book.publisher;
        }

        /// <summary>
        /// Handles the Click event of the Edit button.
        /// Validates user input and creates an updated Book object if validation passes.
        /// </summary>
        /// <param name="sender">The source of the event (Edit button)</param>
        /// <param name="e">Event arguments</param>
        private void buttonEdit_Click(object sender, EventArgs e)
        {
            // Validate that all required fields contain non-whitespace text
            if (string.IsNullOrWhiteSpace(TitleTextBox.Text) ||
                string.IsNullOrWhiteSpace(AuthorTextBox.Text) ||
                string.IsNullOrWhiteSpace(PublisherTextBox.Text))
            {
                MessageBox.Show("Toate campurile sunt obligatorii.",
                    "Eroare de validare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create new Book object with the modified details
            UpdatedBook = new Book(
                TitleTextBox.Text.Trim(),
                AuthorTextBox.Text.Trim(),
                PublisherTextBox.Text.Trim());

            // Set dialog result to indicate successful edit
            this.DialogResult = DialogResult.OK;
            this.Close(); // Close the form
        }

        /// <summary>
        /// Handles the Load event of the form.
        /// Currently contains no implementation but can be used for additional form initialization.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event arguments</param>
        private void BookEditForm_Load(object sender, EventArgs e)
        {
            // Potential future implementation for additional form setup
            // could be added here
        }
    }
}