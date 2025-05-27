namespace Commons
{
    partial class EditBorrowForm
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
            this.userCNPLabel = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.CNPTextBox = new System.Windows.Forms.TextBox();
            this.TitleTextBox = new System.Windows.Forms.TextBox();
            this.editBorrowButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // userCNPLabel
            // 
            this.userCNPLabel.AutoSize = true;
            this.userCNPLabel.Location = new System.Drawing.Point(15, 17);
            this.userCNPLabel.Name = "userCNPLabel";
            this.userCNPLabel.Size = new System.Drawing.Size(67, 16);
            this.userCNPLabel.TabIndex = 0;
            this.userCNPLabel.Text = "User CNP";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 48);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(66, 16);
            this.label2.TabIndex = 1;
            this.label2.Text = "Titlul cărții";
            // 
            // CNPTextBox
            // 
            this.CNPTextBox.Location = new System.Drawing.Point(101, 14);
            this.CNPTextBox.Name = "CNPTextBox";
            this.CNPTextBox.Size = new System.Drawing.Size(300, 22);
            this.CNPTextBox.TabIndex = 2;
            // 
            // TitleTextBox
            // 
            this.TitleTextBox.Location = new System.Drawing.Point(101, 44);
            this.TitleTextBox.Name = "TitleTextBox";
            this.TitleTextBox.Size = new System.Drawing.Size(300, 22);
            this.TitleTextBox.TabIndex = 3;
            // 
            // editBorrowButton
            // 
            this.editBorrowButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.editBorrowButton.Location = new System.Drawing.Point(101, 78);
            this.editBorrowButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.editBorrowButton.Name = "editBorrowButton";
            this.editBorrowButton.Size = new System.Drawing.Size(100, 28);
            this.editBorrowButton.TabIndex = 12;
            this.editBorrowButton.Text = "Editează";
            this.editBorrowButton.UseVisualStyleBackColor = true;
            // 
            // EditBorrowForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(428, 117);
            this.Controls.Add(this.editBorrowButton);
            this.Controls.Add(this.TitleTextBox);
            this.Controls.Add(this.CNPTextBox);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.userCNPLabel);
            this.Name = "EditBorrowForm";
            this.Text = "EditBorrowForm";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label userCNPLabel;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox CNPTextBox;
        private System.Windows.Forms.TextBox TitleTextBox;
        private System.Windows.Forms.Button editBorrowButton;
    }
}