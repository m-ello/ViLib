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
            this.borrowTab = new System.Windows.Forms.TabPage();
            this.ClientsPage = new System.Windows.Forms.TabPage();
            this.booksTab = new System.Windows.Forms.TabPage();
            this.deleteBookButton = new System.Windows.Forms.Button();
            this.detailsBookButton = new System.Windows.Forms.Button();
            this.editBookButton = new System.Windows.Forms.Button();
            this.addBookButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.bookListBox = new System.Windows.Forms.ListBox();
            this.OptionsTabControl = new System.Windows.Forms.TabControl();
            this.helpButton = new System.Windows.Forms.TabPage();
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
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 415);
            this.label2.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 16);
            this.label2.TabIndex = 4;
            this.label2.Text = "Status";
            // 
            // borrowTab
            // 
            this.borrowTab.Location = new System.Drawing.Point(4, 25);
            this.borrowTab.Margin = new System.Windows.Forms.Padding(4);
            this.borrowTab.Name = "borrowTab";
            this.borrowTab.Padding = new System.Windows.Forms.Padding(4);
            this.borrowTab.Size = new System.Drawing.Size(483, 366);
            this.borrowTab.TabIndex = 3;
            this.borrowTab.Text = "Împrumuturi";
            this.borrowTab.UseVisualStyleBackColor = true;
            // 
            // ClientsPage
            // 
            this.ClientsPage.Location = new System.Drawing.Point(4, 25);
            this.ClientsPage.Margin = new System.Windows.Forms.Padding(4);
            this.ClientsPage.Name = "ClientsPage";
            this.ClientsPage.Padding = new System.Windows.Forms.Padding(4);
            this.ClientsPage.Size = new System.Drawing.Size(483, 366);
            this.ClientsPage.TabIndex = 2;
            this.ClientsPage.Text = "Clienți";
            this.ClientsPage.UseVisualStyleBackColor = true;
            // 
            // booksTab
            // 
            this.booksTab.Controls.Add(this.deleteBookButton);
            this.booksTab.Controls.Add(this.detailsBookButton);
            this.booksTab.Controls.Add(this.editBookButton);
            this.booksTab.Controls.Add(this.addBookButton);
            this.booksTab.Controls.Add(this.label1);
            this.booksTab.Controls.Add(this.bookListBox);
            this.booksTab.Location = new System.Drawing.Point(4, 25);
            this.booksTab.Margin = new System.Windows.Forms.Padding(4);
            this.booksTab.Name = "booksTab";
            this.booksTab.Padding = new System.Windows.Forms.Padding(4);
            this.booksTab.Size = new System.Drawing.Size(483, 366);
            this.booksTab.TabIndex = 1;
            this.booksTab.Text = "Cărți";
            this.booksTab.UseVisualStyleBackColor = true;
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
            // bookListBox
            // 
            this.bookListBox.FormattingEnabled = true;
            this.bookListBox.ItemHeight = 16;
            this.bookListBox.Location = new System.Drawing.Point(0, 32);
            this.bookListBox.Margin = new System.Windows.Forms.Padding(4);
            this.bookListBox.Name = "bookListBox";
            this.bookListBox.Size = new System.Drawing.Size(479, 292);
            this.bookListBox.TabIndex = 0;
            // 
            // OptionsTabControl
            // 
            this.OptionsTabControl.Controls.Add(this.booksTab);
            this.OptionsTabControl.Controls.Add(this.ClientsPage);
            this.OptionsTabControl.Controls.Add(this.borrowTab);
            this.OptionsTabControl.Controls.Add(this.helpButton);
            this.OptionsTabControl.Location = new System.Drawing.Point(19, 16);
            this.OptionsTabControl.Margin = new System.Windows.Forms.Padding(4);
            this.OptionsTabControl.Name = "OptionsTabControl";
            this.OptionsTabControl.SelectedIndex = 0;
            this.OptionsTabControl.Size = new System.Drawing.Size(491, 395);
            this.OptionsTabControl.TabIndex = 5;
            this.OptionsTabControl.Click += new System.EventHandler(this.help_Click);
            // 
            // helpButton
            // 
            this.helpButton.Location = new System.Drawing.Point(4, 25);
            this.helpButton.Name = "helpButton";
            this.helpButton.Padding = new System.Windows.Forms.Padding(3);
            this.helpButton.Size = new System.Drawing.Size(483, 366);
            this.helpButton.TabIndex = 4;
            this.helpButton.Text = "Help";
            this.helpButton.UseVisualStyleBackColor = true;
            // 
            // FormView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(521, 526);
            this.Controls.Add(this.OptionsTabControl);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.StatusBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(539, 573);
            this.MinimumSize = new System.Drawing.Size(539, 573);
            this.Name = "FormView";
            this.Text = "Gestionare Librărie";
            this.booksTab.ResumeLayout(false);
            this.booksTab.PerformLayout();
            this.OptionsTabControl.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox StatusBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TabPage borrowTab;
        private System.Windows.Forms.TabPage ClientsPage;
        private System.Windows.Forms.TabPage booksTab;
        private System.Windows.Forms.Button deleteBookButton;
        private System.Windows.Forms.Button detailsBookButton;
        private System.Windows.Forms.Button editBookButton;
        private System.Windows.Forms.Button addBookButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox bookListBox;
        private System.Windows.Forms.TabControl OptionsTabControl;
        private System.Windows.Forms.TabPage helpButton;
    }
}