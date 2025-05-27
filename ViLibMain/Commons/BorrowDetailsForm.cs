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
    public partial class BorrowDetailsForm: Form
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="BorrowDetailsForm"/> class.
        /// This sets up the form and its components.
        /// </summary>
        public BorrowDetailsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sets the borrow details in the form using the given BorrowRecord object
        /// </summary>
        /// <param name="record">The borrow record to extract data from</param>
        public void SetBorrowRecordDetails(BorrowRecord record)
        {
            // Assuming you already have these controls in your form
            FamilyNameTextBox.Text = record.Client.familyName;
            FirstNameTextBox.Text = record.Client.firstName;
            BookTitleTextBox.Text = record.Book.title;
            BorrowDateTextBox.Text = record.BorrowDate.ToString("yyyy-MM-dd");
            ReturnDateTextBox.Text = record.ReturnDate?.ToString("yyyy-MM-dd") ?? "";
        }
    }
}
