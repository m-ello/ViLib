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
    /// A dialog form that displays detailed information about a book in read-only mode.
    /// Shows the book's title, author, and publisher information.
    /// </summary>
    public partial class BookDetailsForm : Form
    {
        /// <summary>
        /// Initializes a new instance of the BookDetailsForm class.
        /// Sets up the form components through the auto-generated InitializeComponent() method.
        /// </summary>
        public BookDetailsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the form fields with the details of the specified book.
        /// </summary>
        /// <param name="book">The Book object containing the details to display</param>
        public void SetBookDetails(Book book)
        {
            TitleTextBox.Text = book.title;
            AuthorTextBox.Text = book.author;
            PublisherTextBox.Text = book.publisher;
        }

        private void BookDetailsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
