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
    /// A dialog form for editing existing client information in the library system.
    /// Provides fields to modify a client's first name, last name, CNP and address information.
    /// </summary>
    public partial class ClientEditForm : Form
    {
        /// <summary>
        /// Gets the updated Book object containing the modified information.
        /// This property is set when the user confirms the edit with valid data.
        /// </summary>
        public Client UpdatedClient { get; private set; }

        /// <summary>
        /// Initializes a new instance of the ClientEditForm class.
        /// Sets up the form components through the auto-generated InitializeComponent() method.
        /// </summary>
        public ClientEditForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Pre-populates the form fields with the current client's information.
        /// </summary>
        /// <param name="client">The Client object containing the current details to be edited</param>
        public void SetClientDetails(Client client)
        {
            // Populate form controls with existing client data
            FamilyNameTextBox.Text = client.familyName;
            FirstNameTextBox.Text = client.firstName;
            CNPTextBox.Text = client.CNP;
            AddressTextBox.Text = client.address;
        }

        /// <summary>
        /// Handles the Click event of the Edit button.
        /// Validates user input and creates an updated Client object if validation passes.
        /// </summary>
        /// <param name="sender">The source of the event (Edit button)</param>
        /// <param name="e">Event arguments</param>
        private void buttonEditClient_Click(object sender, EventArgs e)
        {
            // Validate that all required fields contain non-whitespace text
            if (string.IsNullOrWhiteSpace(FamilyNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(FirstNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(CNPTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text))
            {
                MessageBox.Show("Toate campurile sunt obligatorii.",
                    "Eroare de validare",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return;
            }

            // Create new Client object with the modified details
            UpdatedClient = new Client(
                FamilyNameTextBox.Text.Trim(),
                FirstNameTextBox.Text.Trim(),
                CNPTextBox.Text.Trim(),
                AddressTextBox.Text.Trim());

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
    }
}