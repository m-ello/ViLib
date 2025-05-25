namespace View
{
    partial class FormView
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.StatusBox = new System.Windows.Forms.RichTextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.helpButton = new System.Windows.Forms.Button();
            this.borrowTab = new System.Windows.Forms.TabPage();
            this.deleteBorrowButton = new System.Windows.Forms.Button();
            this.editBorrowButton = new System.Windows.Forms.Button();
            this.detailsBorrowButton = new System.Windows.Forms.Button();
            this.addBorrowButton = new System.Windows.Forms.Button();
            this.borrowHistoryBox = new System.Windows.Forms.ListBox();
            this.label4 = new System.Windows.Forms.Label();
            this.ClientsPage = new System.Windows.Forms.TabPage();
            this.deleteClientButton = new System.Windows.Forms.Button();
            this.detailsClientButton = new System.Windows.Forms.Button();
            this.editClientButton = new System.Windows.Forms.Button();
            this.addClientButton = new System.Windows.Forms.Button();
            this.clientListBox = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.booksTab = new System.Windows.Forms.TabPage();
            this.bookListBox = new System.Windows.Forms.ListBox();
            this.deleteBookButton = new System.Windows.Forms.Button();
            this.detailsBookButton = new System.Windows.Forms.Button();
            this.editBookButton = new System.Windows.Forms.Button();
            this.addBookButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.OptionsTabControl = new System.Windows.Forms.TabControl();
            this.borrowTab.SuspendLayout();
            this.ClientsPage.SuspendLayout();
            this.booksTab.SuspendLayout();
            this.OptionsTabControl.SuspendLayout();
            this.SuspendLayout();
            // 
            // StatusBox
            // 
            this.StatusBox.Location = new System.Drawing.Point(16, 434);
            this.StatusBox.Margin = new System.Windows.Forms.Padding(4);
            this.StatusBox.Name = "StatusBox";
            this.StatusBox.ReadOnly = true;
            this.StatusBox.Size = new System.Drawing.Size(491, 85);
            this.StatusBox.TabIndex = 1;
            this.StatusBox.Text = "";
            // 
            // titleLabel
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 415);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "titleLabel";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(403, 5);
            this.helpButton.Margin = new System.Windows.Forms.Padding(4);
            this.helpButton.Name = "helpButton";
            this.helpButton.Size = new System.Drawing.Size(101, 31);
            this.helpButton.TabIndex = 6;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            this.helpButton.Click += new System.EventHandler(this.helpButton_Click);
            // 
            // borrowTab
            // 
            this.borrowTab.Controls.Add(this.deleteBorrowButton);
            this.borrowTab.Controls.Add(this.editBorrowButton);
            this.borrowTab.Controls.Add(this.detailsBorrowButton);
            this.borrowTab.Controls.Add(this.addBorrowButton);
            this.borrowTab.Controls.Add(this.borrowHistoryBox);
            this.borrowTab.Controls.Add(this.label4);
            this.borrowTab.Location = new System.Drawing.Point(4, 25);
            this.borrowTab.Margin = new System.Windows.Forms.Padding(4);
            this.borrowTab.Name = "borrowTab";
            this.borrowTab.Padding = new System.Windows.Forms.Padding(4);
            this.borrowTab.Size = new System.Drawing.Size(483, 366);
            this.borrowTab.TabIndex = 3;
            this.borrowTab.Text = "Împrumuturi";
            this.borrowTab.UseVisualStyleBackColor = true;
            // 
            // deleteBorrowButton
            // 
            this.deleteBorrowButton.Location = new System.Drawing.Point(376, 330);
            this.deleteBorrowButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBorrowButton.Name = "deleteBorrowButton";
            this.deleteBorrowButton.Size = new System.Drawing.Size(100, 30);
            this.deleteBorrowButton.TabIndex = 11;
            this.deleteBorrowButton.Text = "Șterge";
            this.deleteBorrowButton.UseVisualStyleBackColor = true;
            this.deleteBorrowButton.Click += new System.EventHandler(this.deleteBorrowButton_Click);
            // 
            // editBorrowButton
            // 
            this.editBorrowButton.Location = new System.Drawing.Point(108, 330);
            this.editBorrowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editBorrowButton.Name = "editBorrowButton";
            this.editBorrowButton.Size = new System.Drawing.Size(100, 30);
            this.editBorrowButton.TabIndex = 10;
            this.editBorrowButton.Text = "Editează";
            this.editBorrowButton.UseVisualStyleBackColor = true;
            this.editBorrowButton.Click += new System.EventHandler(this.editBorrowButton_Click);
            // 
            // detailsBorrowButton
            // 
            this.detailsBorrowButton.Location = new System.Drawing.Point(268, 330);
            this.detailsBorrowButton.Margin = new System.Windows.Forms.Padding(4);
            this.detailsBorrowButton.Name = "detailsBorrowButton";
            this.detailsBorrowButton.Size = new System.Drawing.Size(100, 30);
            this.detailsBorrowButton.TabIndex = 9;
            this.detailsBorrowButton.Text = "Detalii";
            this.detailsBorrowButton.UseVisualStyleBackColor = true;
            this.detailsBorrowButton.Click += new System.EventHandler(this.detailsBorrowButton_Click);
            // 
            // addBorrowButton
            // 
            this.addBorrowButton.Location = new System.Drawing.Point(0, 330);
            this.addBorrowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addBorrowButton.Name = "addBorrowButton";
            this.addBorrowButton.Size = new System.Drawing.Size(100, 30);
            this.addBorrowButton.TabIndex = 8;
            this.addBorrowButton.Text = "Adaugă";
            this.addBorrowButton.UseVisualStyleBackColor = true;
            this.addBorrowButton.Click += new System.EventHandler(this.addBorrowButton_Click);
            // 
            // borrowHistoryBox
            // 
            this.borrowHistoryBox.FormattingEnabled = true;
            this.borrowHistoryBox.ItemHeight = 16;
            this.borrowHistoryBox.Location = new System.Drawing.Point(0, 34);
            this.borrowHistoryBox.Margin = new System.Windows.Forms.Padding(4);
            this.borrowHistoryBox.Name = "borrowHistoryBox";
            this.borrowHistoryBox.Size = new System.Drawing.Size(479, 292);
            this.borrowHistoryBox.TabIndex = 7;
            this.borrowHistoryBox.SelectedIndexChanged += new System.EventHandler(this.borrowHistoryBox_SelectedIndexChanged);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(4, 12);
            this.label4.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(45, 16);
            this.label4.TabIndex = 2;
            this.label4.Text = "Istoric ";
            this.label4.Click += new System.EventHandler(this.label4_Click);
            // 
            // ClientsPage
            // 
            this.ClientsPage.Controls.Add(this.deleteClientButton);
            this.ClientsPage.Controls.Add(this.detailsClientButton);
            this.ClientsPage.Controls.Add(this.editClientButton);
            this.ClientsPage.Controls.Add(this.addClientButton);
            this.ClientsPage.Controls.Add(this.clientListBox);
            this.ClientsPage.Controls.Add(this.label3);
            this.ClientsPage.Location = new System.Drawing.Point(4, 25);
            this.ClientsPage.Margin = new System.Windows.Forms.Padding(4);
            this.ClientsPage.Name = "ClientsPage";
            this.ClientsPage.Padding = new System.Windows.Forms.Padding(4);
            this.ClientsPage.Size = new System.Drawing.Size(483, 366);
            this.ClientsPage.TabIndex = 2;
            this.ClientsPage.Text = "Clienți";
            this.ClientsPage.UseVisualStyleBackColor = true;
            this.ClientsPage.Click += new System.EventHandler(this.ClientsPage_Click);
            // 
            // deleteClientButton
            // 
            this.deleteClientButton.Location = new System.Drawing.Point(376, 330);
            this.deleteClientButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteClientButton.Name = "deleteClientButton";
            this.deleteClientButton.Size = new System.Drawing.Size(100, 30);
            this.deleteClientButton.TabIndex = 6;
            this.deleteClientButton.Text = "Șterge";
            this.deleteClientButton.UseVisualStyleBackColor = true;
            this.deleteClientButton.Click += new System.EventHandler(this.deleteClientButton_Click);
            // 
            // detailsClientButton
            // 
            this.detailsClientButton.Location = new System.Drawing.Point(268, 330);
            this.detailsClientButton.Margin = new System.Windows.Forms.Padding(4);
            this.detailsClientButton.Name = "detailsClientButton";
            this.detailsClientButton.Size = new System.Drawing.Size(100, 30);
            this.detailsClientButton.TabIndex = 5;
            this.detailsClientButton.Text = "Detalii";
            this.detailsClientButton.UseVisualStyleBackColor = true;
            this.detailsClientButton.Click += new System.EventHandler(this.detailsClientButton_Click);
            // 
            // editClientButton
            // 
            this.editClientButton.Location = new System.Drawing.Point(108, 330);
            this.editClientButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editClientButton.Name = "editClientButton";
            this.editClientButton.Size = new System.Drawing.Size(100, 30);
            this.editClientButton.TabIndex = 3;
            this.editClientButton.Text = "Editează";
            this.editClientButton.UseVisualStyleBackColor = true;
            this.editClientButton.Click += new System.EventHandler(this.editClientButton_Click);
            // 
            // addClientButton
            // 
            this.addClientButton.Location = new System.Drawing.Point(0, 330);
            this.addClientButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Size = new System.Drawing.Size(100, 30);
            this.addClientButton.TabIndex = 2;
            this.addClientButton.Text = "Adaugă";
            this.addClientButton.UseVisualStyleBackColor = true;
            this.addClientButton.Click += new System.EventHandler(this.addClientButton_Click);
            // 
            // clientListBox
            // 
            this.clientListBox.FormattingEnabled = true;
            this.clientListBox.ItemHeight = 16;
            this.clientListBox.Location = new System.Drawing.Point(0, 34);
            this.clientListBox.Margin = new System.Windows.Forms.Padding(4);
            this.clientListBox.Name = "clientListBox";
            this.clientListBox.Size = new System.Drawing.Size(479, 292);
            this.clientListBox.TabIndex = 1;
            this.clientListBox.SelectedIndexChanged += new System.EventHandler(this.clientListBox_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(4, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 16);
            this.label3.TabIndex = 0;
            this.label3.Text = "Clienții curenți";
            // 
            // booksTab
            // 
            this.booksTab.Controls.Add(this.bookListBox);
            this.booksTab.Controls.Add(this.deleteBookButton);
            this.booksTab.Controls.Add(this.detailsBookButton);
            this.booksTab.Controls.Add(this.editBookButton);
            this.booksTab.Controls.Add(this.addBookButton);
            this.booksTab.Controls.Add(this.label1);
            this.booksTab.Location = new System.Drawing.Point(4, 25);
            this.booksTab.Margin = new System.Windows.Forms.Padding(4);
            this.booksTab.Name = "booksTab";
            this.booksTab.Padding = new System.Windows.Forms.Padding(4);
            this.booksTab.Size = new System.Drawing.Size(483, 366);
            this.booksTab.TabIndex = 1;
            this.booksTab.Text = "Cărți";
            this.booksTab.UseVisualStyleBackColor = true;
            // 
            // bookListBox
            // 
            this.bookListBox.FormattingEnabled = true;
            this.bookListBox.ItemHeight = 16;
            this.bookListBox.Location = new System.Drawing.Point(0, 34);
            this.bookListBox.Margin = new System.Windows.Forms.Padding(4);
            this.bookListBox.Name = "bookListBox";
            this.bookListBox.Size = new System.Drawing.Size(479, 292);
            this.bookListBox.TabIndex = 6;
            // 
            // deleteBookButton
            // 
            this.deleteBookButton.Location = new System.Drawing.Point(376, 330);
            this.deleteBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.deleteBookButton.Name = "deleteBookButton";
            this.deleteBookButton.Size = new System.Drawing.Size(100, 30);
            this.deleteBookButton.TabIndex = 5;
            this.deleteBookButton.Text = "Șterge";
            this.deleteBookButton.UseVisualStyleBackColor = true;
            this.deleteBookButton.Click += new System.EventHandler(this.deleteBookButton_Click);
            // 
            // detailsBookButton
            // 
            this.detailsBookButton.Location = new System.Drawing.Point(268, 330);
            this.detailsBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.detailsBookButton.Name = "detailsBookButton";
            this.detailsBookButton.Size = new System.Drawing.Size(100, 30);
            this.detailsBookButton.TabIndex = 4;
            this.detailsBookButton.Text = "Detalii";
            this.detailsBookButton.UseVisualStyleBackColor = true;
            this.detailsBookButton.Click += new System.EventHandler(this.detailsBookButton_Click);
            // 
            // editBookButton
            // 
            this.editBookButton.Location = new System.Drawing.Point(108, 330);
            this.editBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.editBookButton.Name = "editBookButton";
            this.editBookButton.Size = new System.Drawing.Size(100, 30);
            this.editBookButton.TabIndex = 3;
            this.editBookButton.Text = "Editează";
            this.editBookButton.UseVisualStyleBackColor = true;
            this.editBookButton.Click += new System.EventHandler(this.editBookButton_Click);
            // 
            // addBookButton
            // 
            this.addBookButton.Location = new System.Drawing.Point(0, 330);
            this.addBookButton.Margin = new System.Windows.Forms.Padding(4);
            this.addBookButton.Name = "addBookButton";
            this.addBookButton.Size = new System.Drawing.Size(100, 30);
            this.addBookButton.TabIndex = 2;
            this.addBookButton.Text = "Adaugă";
            this.addBookButton.UseVisualStyleBackColor = true;
            this.addBookButton.Click += new System.EventHandler(this.addBookButton_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(4, 12);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(92, 16);
            this.label1.TabIndex = 1;
            this.label1.Text = "Cărțile curente";
            // 
            // OptionsTabControl
            // 
            this.OptionsTabControl.Controls.Add(this.booksTab);
            this.OptionsTabControl.Controls.Add(this.ClientsPage);
            this.OptionsTabControl.Controls.Add(this.borrowTab);
            this.OptionsTabControl.Location = new System.Drawing.Point(19, 16);
            this.OptionsTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.OptionsTabControl.Name = "OptionsTabControl";
            this.OptionsTabControl.SelectedIndex = 0;
            this.OptionsTabControl.Size = new System.Drawing.Size(491, 395);
            this.OptionsTabControl.TabIndex = 5;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(520, 524);
            this.Controls.Add(this.helpButton);
            this.Controls.Add(this.OptionsTabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(538, 571);
            this.MinimumSize = new System.Drawing.Size(538, 571);
            this.Name = "FormView";
            this.Text = "Gestionare Librărie";
            this.borrowTab.ResumeLayout(false);
            this.borrowTab.PerformLayout();
            this.ClientsPage.ResumeLayout(false);
            this.ClientsPage.PerformLayout();
            this.booksTab.ResumeLayout(false);
            this.booksTab.PerformLayout();
            this.OptionsTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox StatusBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button helpButton;
        private System.Windows.Forms.TabPage borrowTab;
        private System.Windows.Forms.TabPage ClientsPage;
        private System.Windows.Forms.Button deleteClientButton;
        private System.Windows.Forms.Button detailsClientButton;
        private System.Windows.Forms.Button editClientButton;
        private System.Windows.Forms.Button addClientButton;
        private System.Windows.Forms.ListBox clientListBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TabPage booksTab;
        private System.Windows.Forms.ListBox bookListBox;
        private System.Windows.Forms.Button deleteBookButton;
        private System.Windows.Forms.Button detailsBookButton;
        private System.Windows.Forms.Button editBookButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TabControl OptionsTabControl;
        private System.Windows.Forms.ListBox borrowHistoryBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button detailsBorrowButton;
        private System.Windows.Forms.Button addBorrowButton;
        private System.Windows.Forms.Button deleteBorrowButton;
        private System.Windows.Forms.Button editBorrowButton;
    }
}