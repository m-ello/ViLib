namespace Commons
{
    partial class BorrowDetailsForm
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
            this.NumeLabel = new System.Windows.Forms.Label();
            this.PrenumeLabel = new System.Windows.Forms.Label();
            this.bookTitleLabel = new System.Windows.Forms.Label();
            this.borrowDateLabel = new System.Windows.Forms.Label();
            this.returnDateLabel = new System.Windows.Forms.Label();
            this.FamilyNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.BookTitleTextBox = new System.Windows.Forms.TextBox();
            this.BorrowDateTextBox = new System.Windows.Forms.TextBox();
            this.ReturnDateTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // NumeLabel
            // 
            this.NumeLabel.AutoSize = true;
            this.NumeLabel.Location = new System.Drawing.Point(69, 30);
            this.NumeLabel.Name = "NumeLabel";
            this.NumeLabel.Size = new System.Drawing.Size(43, 16);
            this.NumeLabel.TabIndex = 0;
            this.NumeLabel.Text = "Nume";
            // 
            // PrenumeLabel
            // 
            this.PrenumeLabel.AutoSize = true;
            this.PrenumeLabel.Location = new System.Drawing.Point(60, 62);
            this.PrenumeLabel.Name = "PrenumeLabel";
            this.PrenumeLabel.Size = new System.Drawing.Size(61, 16);
            this.PrenumeLabel.TabIndex = 1;
            this.PrenumeLabel.Text = "Prenume";
            // 
            // bookTitleLabel
            // 
            this.bookTitleLabel.AutoSize = true;
            this.bookTitleLabel.Location = new System.Drawing.Point(53, 104);
            this.bookTitleLabel.Name = "bookTitleLabel";
            this.bookTitleLabel.Size = new System.Drawing.Size(68, 16);
            this.bookTitleLabel.TabIndex = 2;
            this.bookTitleLabel.Text = "Titlul Cartii";
            // 
            // borrowDateLabel
            // 
            this.borrowDateLabel.AutoSize = true;
            this.borrowDateLabel.Location = new System.Drawing.Point(33, 140);
            this.borrowDateLabel.Name = "borrowDateLabel";
            this.borrowDateLabel.Size = new System.Drawing.Size(112, 16);
            this.borrowDateLabel.TabIndex = 3;
            this.borrowDateLabel.Text = "Data de imprumut";
            // 
            // returnDateLabel
            // 
            this.returnDateLabel.AutoSize = true;
            this.returnDateLabel.Location = new System.Drawing.Point(33, 177);
            this.returnDateLabel.Name = "returnDateLabel";
            this.returnDateLabel.Size = new System.Drawing.Size(111, 16);
            this.returnDateLabel.TabIndex = 4;
            this.returnDateLabel.Text = "Data de returnare";
            // 
            // FamilyNameTextBox
            // 
            this.FamilyNameTextBox.Location = new System.Drawing.Point(160, 27);
            this.FamilyNameTextBox.Name = "FamilyNameTextBox";
            this.FamilyNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.FamilyNameTextBox.TabIndex = 5;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(160, 59);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(200, 22);
            this.FirstNameTextBox.TabIndex = 6;
            // 
            // BookTitleTextBox
            // 
            this.BookTitleTextBox.Location = new System.Drawing.Point(160, 101);
            this.BookTitleTextBox.Name = "BookTitleTextBox";
            this.BookTitleTextBox.Size = new System.Drawing.Size(200, 22);
            this.BookTitleTextBox.TabIndex = 7;
            // 
            // BorrowDateTextBox
            // 
            this.BorrowDateTextBox.Location = new System.Drawing.Point(160, 137);
            this.BorrowDateTextBox.Name = "BorrowDateTextBox";
            this.BorrowDateTextBox.Size = new System.Drawing.Size(200, 22);
            this.BorrowDateTextBox.TabIndex = 8;
            // 
            // ReturnDateTextBox
            // 
            this.ReturnDateTextBox.Location = new System.Drawing.Point(160, 174);
            this.ReturnDateTextBox.Name = "ReturnDateTextBox";
            this.ReturnDateTextBox.Size = new System.Drawing.Size(200, 22);
            this.ReturnDateTextBox.TabIndex = 9;
            // 
            // BorrowDetailsForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(420, 225);
            this.Controls.Add(this.ReturnDateTextBox);
            this.Controls.Add(this.BorrowDateTextBox);
            this.Controls.Add(this.BookTitleTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.FamilyNameTextBox);
            this.Controls.Add(this.returnDateLabel);
            this.Controls.Add(this.borrowDateLabel);
            this.Controls.Add(this.bookTitleLabel);
            this.Controls.Add(this.PrenumeLabel);
            this.Controls.Add(this.NumeLabel);
            this.Name = "BorrowDetailsForm";
            this.Text = "BorrowDetailsForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label NumeLabel;
        private System.Windows.Forms.Label PrenumeLabel;
        private System.Windows.Forms.Label bookTitleLabel;
        private System.Windows.Forms.Label borrowDateLabel;
        private System.Windows.Forms.Label returnDateLabel;
        private System.Windows.Forms.TextBox FamilyNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox BookTitleTextBox;
        private System.Windows.Forms.TextBox BorrowDateTextBox;
        private System.Windows.Forms.TextBox ReturnDateTextBox;
    }
}