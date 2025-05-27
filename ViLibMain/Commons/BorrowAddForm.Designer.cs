namespace Commons
{
    partial class BorrowAddForm
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
            this.addBorrowButton = new System.Windows.Forms.Button();
            this.CNPTextBox = new System.Windows.Forms.TextBox();
            this.CNP = new System.Windows.Forms.Label();
            this.titleLabel = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addBorrowButton
            // 
            this.addBorrowButton.Location = new System.Drawing.Point(101, 78);
            this.addBorrowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.addBorrowButton.Name = "addBorrowButton";
            this.addBorrowButton.Size = new System.Drawing.Size(100, 28);
            this.addBorrowButton.TabIndex = 11;
            this.addBorrowButton.Text = "Adaugă";
            this.addBorrowButton.UseVisualStyleBackColor = true;
            this.addBorrowButton.Click += new System.EventHandler(this.addBorrowButton_Click);
            // 
            // CNPTextBox
            // 
            this.CNPTextBox.Location = new System.Drawing.Point(101, 14);
            this.CNPTextBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.CNPTextBox.Name = "CNPTextBox";
            this.CNPTextBox.Size = new System.Drawing.Size(300, 22);
            this.CNPTextBox.TabIndex = 10;
            // 
            // CNP
            // 
            this.CNP.AutoSize = true;
            this.CNP.Location = new System.Drawing.Point(15, 17);
            this.CNP.Name = "CNP";
            this.CNP.Size = new System.Drawing.Size(67, 16);
            this.CNP.TabIndex = 9;
            this.CNP.Text = "User CNP";
            // 
            // titleLabel
            // 
            this.titleLabel.AutoSize = true;
            this.titleLabel.Location = new System.Drawing.Point(15, 48);
            this.titleLabel.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.titleLabel.Name = "titleLabel";
            this.titleLabel.Size = new System.Drawing.Size(66, 16);
            this.titleLabel.TabIndex = 13;
            this.titleLabel.Text = "Titlul cartii";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(101, 44);
            this.TitleTextBox.Margin = new System.Windows.Forms.Padding(4);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(300, 22);
            this.TitleTextBox.TabIndex = 12;
            // 
            // BorrowAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 117);
            this.Controls.Add(this.titleLabel);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.addBorrowButton);
            this.Controls.Add(this.CNPTextBox);
            this.Controls.Add(this.CNP);
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "BorrowAddForm";
            this.Text = "BorrowAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addBorrowButton;
        private System.Windows.Forms.TextBox CNPTextBox;
        private System.Windows.Forms.Label CNP;
        private System.Windows.Forms.Label titleLabel;
        private System.Windows.Forms.TextBox TitleTextBox;
    }
}