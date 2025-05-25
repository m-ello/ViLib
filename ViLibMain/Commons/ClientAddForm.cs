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
    /// A dialog form for adding new clients to the library system.
    /// Implements the standard Windows Form for data entry.
    /// </summary>
    public partial class ClientAddForm : Form
    {
        /// <summary>
        /// Gets the newly created Client object after successful form submission.
        /// This property is populated when the user clicks the Add button with valid data.
        /// </summary>
        public Client NewClient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ClientAddForm class.
        /// Sets up the form components through the auto-generated InitializeComponent() method.
        /// </summary>
        public ClientAddForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Handles the Click event of the Add button.
        /// Validates input fields and creates a new Client object if validation passes.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event arguments</param>
        private void buttonAdd_Click(object sender, EventArgs e)
        {
            // Validate that all required fields contain non-whitespace text
            if (string.IsNullOrWhiteSpace(FamilyNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(CNPTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Toate campurile trebuie completate.",
                    "Eroare de validare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create a new Client object with trimmed input values
            NewClient = new Client(
                FamilyNameTextBox.Text.Trim(),
                FirstNameTextBox.Text.Trim(),
                CNPTextBox.Text.Trim(),
                AddressTextBox.Text = AddressTextBox.Text.Trim()
            );


            // Set dialog result to OK to indicate successful submission
            this.DialogResult = DialogResult.OK;
            this.Close(); // Close the form
        }

        private void ClientAddForm_Load(object sender, EventArgs e)
        {

        }

        /// <summary>
        /// Handles the TextChanged event of the AuthorTextBox.
        /// Currently contains no implementation but provides a hook for future validation logic.
        /// </summary>
        /// <param name="sender">The source of the event</param>
        /// <param name="e">Event arguments</param>
    }
}