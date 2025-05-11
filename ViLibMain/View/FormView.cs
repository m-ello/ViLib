using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Commons;
using static View.Menus;

namespace View
{
    public partial class FormView : Form, IView
    {
        private IPresenter _presenter;
        public IModel _model;
        public List<MenuOption> _menuOptions;

        // Track the current menu state and user choice
        private MenuState _currentMenuState = MenuState.Main;
        private UserChoice _currentChoice = UserChoice.Undefined;

        // Random generator for creating random books
        private Random _random = new Random();

        public FormView(IModel model)
        {
            _model = model;
            InitializeComponent();

            // Subscribe to the FormClosing event
            this.FormClosing += FormView_FormClosing;

            // Subscribe to form events
            AdminModeButton.Click += AdminModeButton_Click;
            ActionComboBox.SelectedIndexChanged += ActionComboBox_SelectedIndexChanged;
            ExecuteButton.Click += ExecuteButton_Click;

            // Initialize menu state
            UpdateMenuState(MenuState.Main);
        }

        // Handle the form closing event
        private void FormView_FormClosing(object sender, FormClosingEventArgs e)
        {
            // Cancel the default closing behavior
            e.Cancel = true;

            // Use the presenter to handle the exit logic instead
            if (_presenter != null)
            {
                _presenter.Exit();
            }
            else
            {
                // If presenter is not available, still allow the form to close
                Environment.Exit(0);
            }
        }

        private void AdminModeButton_Click(object sender, EventArgs e)
        {
            if (_currentMenuState == MenuState.Main)
            {
                UpdateMenuState(MenuState.Administrator);

                // Disable the button to prevent re-entering admin mode
                AdminModeButton.Enabled = false;
            }
        }

        private void UpdateMenuState(MenuState menuState)
        {
            _currentMenuState = menuState;
            string action = "";

            // Update menu options based on current state
            switch (menuState)
            {
                case MenuState.Main:
                    Menus.MainMenu(out _menuOptions, out action);
                    groupBox1.Visible = false; // Hide admin options
                    AdminModeButton.Text = "Administrator Mode";
                    break;

                case MenuState.Administrator:
                    Menus.AdminMenu(out _menuOptions, out action);
                    groupBox1.Visible = true; // Show admin options

                    // Populate action combo box with admin options
                    ActionComboBox.Items.Clear();
                    foreach (var option in _menuOptions)
                    {
                        if (option.Choice != UserChoice.Exit) // Skip Exit option in combobox
                        {
                            // Add each menu option to the combobox
                            ActionComboBox.Items.Add(new ComboBoxItem { Text = option.Text, Value = option.Choice });
                        }
                    }

                    // Select first item by default
                    if (ActionComboBox.Items.Count > 0)
                        ActionComboBox.SelectedIndex = 0;
                    break;
            }

            Display($"Mode changed to {menuState}", "blue");
        }

        private void ActionComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ActionComboBox.SelectedItem != null)
            {
                ComboBoxItem item = (ComboBoxItem)ActionComboBox.SelectedItem;
                _currentChoice = (UserChoice)item.Value;
            }
        }

        private void ExecuteButton_Click(object sender, EventArgs e)
        {
            // Execute the selected action
            switch (_currentChoice)
            {
                case UserChoice.Info:
                    Display("Not implemented yet", "red");
                    break;


                case UserChoice.AddBook:
                    // Create book with random data
                    string title = "Book_" + GenerateRandomString(5);
                    string author = "Author_" + GenerateRandomString(8);
                    string publisher = "Publisher_" + GenerateRandomString(6);

                    Book newBook = new Book(title, author, publisher);
                    _presenter.AddBook(newBook);
                    Display($"Created random book: {title} by {author}", "green");
                    break;

                case UserChoice.RemoveBook:
                    string bookTitle = Prompt.ShowDialog("Enter the title of the book to remove:", "Remove Book");

                    if (!string.IsNullOrWhiteSpace(bookTitle))
                    {
                        _presenter.RemoveBook(bookTitle);
                    }
                    else
                    {
                        Display("Book title cannot be empty.", "red");
                    }
                    break;

                case UserChoice.List:
                default:
                    // List all books using model
                    string bookList = _model.ListAllBooks();
                    Display("Book List:\n" + bookList, "blue");
                    break;

            }
        }

        // Helper method to generate random strings
        private string GenerateRandomString(int length)
        {
            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz0123456789";
            return new string(Enumerable.Repeat(chars, length)
                .Select(s => s[_random.Next(s.Length)]).ToArray());
        }

        public void Display(string text, string color)
        {
            // Map the color string to a System.Drawing.Color
            Color textColor = Color.Black;
            switch (color.ToLower())
            {
                case "red":
                    textColor = Color.Red;
                    break;
                case "blue":
                    textColor = Color.Blue;
                    break;
                case "magenta":
                    textColor = Color.Magenta;
                    break;
                case "green":
                    textColor = Color.Green;
                    break;
                case "default":
                    textColor = Color.Black;
                    break;
            }

            // Set the text color and append to the StatusBox
            StatusBox.SelectionStart = StatusBox.TextLength;
            StatusBox.SelectionLength = 0;
            StatusBox.SelectionColor = textColor;
            StatusBox.AppendText(text + Environment.NewLine);
            StatusBox.ScrollToCaret();
        }

        public void SetPresenter(IPresenter presenter)
        {
            _presenter = presenter;
            _presenter?.Init();
        }

        private void FormView_Load(object sender, EventArgs e)
        {
            // No need for this since Init is called in SetPresenter
        }

        private void ActionComboBox_SelectedIndexChanged_1(object sender, EventArgs e)
        {

        }
    }

    // Helper class for combo box items
    public class ComboBoxItem
    {
        public string Text { get; set; }
        public object Value { get; set; }

        public override string ToString()
        {
            return Text;
        }
    }
}
