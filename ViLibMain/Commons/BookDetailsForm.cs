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
    public partial class BookDetailsForm : Form
    {
        public BookDetailsForm()
        {
            InitializeComponent();
        }

        public void SetBookDetails(Book book)
        {
            TitleTextBox.Text = book.title;
            AuthorTextBox.Text = book.author;
            PublisherTextBox.Text = book.publisher;
        }
    }
}
