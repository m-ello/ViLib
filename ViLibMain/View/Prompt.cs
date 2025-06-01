using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace View
{
    /// <summary>
    /// Provides a static method to show a simple input dialog to the user.
    /// </summary>
    public static class Prompt
    {
        /// <summary>
        /// Displays a modal dialog box with a message and a textbox for user input.
        /// </summary>
        /// <param name="text">The message to display to the user.</param>
        /// <param name="caption">The caption of the dialog window.</param>
        /// <returns>The text entered by the user if "OK" is clicked; otherwise, an empty string.</returns>
        public static string ShowDialog(string text, string caption)
        {
            // Create a new form instance
            Form prompt = new Form()
            {
                Width = 400, // Set the width of the dialog
                Height = 150, // Set the height of the dialog
                FormBorderStyle = FormBorderStyle.FixedDialog, // Prevent resizing
                Text = caption, // Set the title/caption of the window
                StartPosition = FormStartPosition.CenterScreen // Center on screen
            };

            // Create a label to show the message
            Label textLabel = new Label()
            {
                Left = 20,
                Top = 20,
                Text = text,
                Width = 340
            };

            // Create a textbox for user input
            TextBox textBox = new TextBox()
            {
                Left = 20,
                Top = 50,
                Width = 340
            };

            // Create an OK button to confirm input
            Button confirmation = new Button()
            {
                Text = "OK",
                Left = 280,
                Width = 80,
                Top = 80,
                DialogResult = DialogResult.OK // Set the result to OK when clicked
            };

            // Close the form when the OK button is clicked
            confirmation.Click += (sender, e) => { prompt.Close(); };

            // Add controls to the form
            prompt.Controls.Add(textBox);
            prompt.Controls.Add(confirmation);
            prompt.Controls.Add(textLabel);

            // Make the OK button the default action when Enter is pressed
            prompt.AcceptButton = confirmation;

            // Show the dialog and return the input if OK was clicked; otherwise, return an empty string
            return prompt.ShowDialog() == DialogResult.OK ? textBox.Text : "";
        }
    }
}
