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
            this.addClientButton = new System.Windows.Forms.Button();
            this.CNPTextBox = new System.Windows.Forms.TextBox();
            this.CNP = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // addClientButton
            // 
            this.addClientButton.Location = new System.Drawing.Point(76, 61);
            this.addClientButton.Margin = new System.Windows.Forms.Padding(2);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Size = new System.Drawing.Size(75, 23);
            this.addClientButton.TabIndex = 11;
            this.addClientButton.Text = "Adaugă";
            this.addClientButton.UseVisualStyleBackColor = true;
            this.addClientButton.Click += new System.EventHandler(this.addClientButton_Click);
            // 
            // CNPTextBox
            // 
            this.CNPTextBox.Location = new System.Drawing.Point(76, 11);
            this.CNPTextBox.Margin = new System.Windows.Forms.Padding(2);
            this.CNPTextBox.Name = "CNPTextBox";
            this.CNPTextBox.Size = new System.Drawing.Size(222, 20);
            this.CNPTextBox.TabIndex = 10;
            this.CNPTextBox.TextChanged += new System.EventHandler(this.CNPTextBox_TextChanged);
            // 
            // CNP
            // 
            this.CNP.AutoSize = true;
            this.CNP.Location = new System.Drawing.Point(11, 14);
            this.CNP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CNP.Name = "CNP";
            this.CNP.Size = new System.Drawing.Size(54, 13);
            this.CNP.TabIndex = 9;
            this.CNP.Text = "User CNP";
            this.CNP.Click += new System.EventHandler(this.CNP_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(11, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(54, 13);
            this.label2.TabIndex = 13;
            this.label2.Text = "Titlul cartii";
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(76, 36);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(222, 20);
            this.TitleTextBox.TabIndex = 12;
            // 
            // BorrowAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(321, 95);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.addClientButton);
            this.Controls.Add(this.CNPTextBox);
            this.Controls.Add(this.CNP);
            this.Name = "BorrowAddForm";
            this.Text = "BorrowAddForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button addClientButton;
        private System.Windows.Forms.TextBox CNPTextBox;
        private System.Windows.Forms.Label CNP;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TitleTextBox;
    }
}