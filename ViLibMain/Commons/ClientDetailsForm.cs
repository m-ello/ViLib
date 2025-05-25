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
    public partial class ClientDetailsForm: Form
    {
        /// <summary>
        /// Initializes a new instance of the ClientDetailsForm class.
        /// Sets up the form components through the auto-generated InitializeComponent() method.
        /// </summary>
        public ClientDetailsForm()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Populates the form fields with the details of the specified book.
        /// </summary>
        /// <param name="book">The Book object containing the details to display</param>
        public void SetClientDetails(Client client)
        {
            FamilyNameTextBox.Text = client.familyName;
            FirstNameTextBox.Text = client.firstName;
            CNPTextBox.Text = client.CNP;
            AddressTextBox.Text = client.address;
        }
    }
}
