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
    public partial class EditBorrowForm: Form

    {
        /// <summary>
        /// Gets the updated BorrowRecord object containing the modified information.
        /// This property is set when the user confirms the edit with valid data.
        /// </summary>
        public BorrowRecord UpdatedBorrowRecord { get; private set; }

        /// <summary>
        /// Initializes a new instance of the EditBorrowForm class.
        /// Sets up the form components through the auto-generated InitializeComponent() method.
        /// </summary>
        public EditBorrowForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pre-populates the form fields with the current borrowRecord's information.
        /// </summary>
        /// <param name="br">The BorrowRecord object containing the current details to be edited</param>
        public void SetBorrowDetails(BorrowRecord br)
        {
            // Populate form controls with existing BorrowRecord data
            CNPTextBox.Text = br.Client.CNP;
            TitleTextBox.Text = br.BookTitle;
        }

        /// <summary>
        /// Handles the Click event of the Edit button.
        /// Validates user input and creates an updated BorrowRecord object if validation passes.
        /// </summary>
        /// <param name="sender">The source of the event (Edit button)</param>
        /// <param name="e">Event arguments</param>
        private void editBorrowButton_Click(object sender, EventArgs e)
        {
            // Validate that all required fields contain non-whitespace text
            if (string.IsNullOrWhiteSpace(CNPTextBox.Text) ||
                string.IsNullOrWhiteSpace(TitleTextBox.Text))
            {
                MessageBox.Show("Toate campurile sunt obligatorii.",
                    "Eroare de validare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            /*// Create new BorrowRecord object with the modified details
            UpdatedBorrowRecord = new BorrowRecord(
                CNPTextBox.Text.Trim(),
                TitleTextBox.Text.Trim(), library);*/

            // Set dialog result to indicate successful edit
            this.DialogResult = DialogResult.OK;
            this.Close(); // Close the form
        }
    }
}
