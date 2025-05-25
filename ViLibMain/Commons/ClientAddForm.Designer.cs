namespace Commons
{
    partial class ClientAddForm
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
            this.nume = new System.Windows.Forms.Label();
            this.prenume = new System.Windows.Forms.Label();
            this.CNP = new System.Windows.Forms.Label();
            this.FamilyNameTextBox = new System.Windows.Forms.TextBox();
            this.FirstNameTextBox = new System.Windows.Forms.TextBox();
            this.CNPTextBox = new System.Windows.Forms.TextBox();
            this.adresa = new System.Windows.Forms.Label();
            this.AddressTextBox = new System.Windows.Forms.TextBox();
            this.addClientButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // nume
            // 
            this.nume.AutoSize = true;
            this.nume.Location = new System.Drawing.Point(29, 11);
            this.nume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.nume.Name = "nume";
            this.nume.Size = new System.Drawing.Size(35, 13);
            this.nume.TabIndex = 0;
            this.nume.Text = "Nume";
            // 
            // prenume
            // 
            this.prenume.AutoSize = true;
            this.prenume.Location = new System.Drawing.Point(16, 36);
            this.prenume.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.prenume.Name = "prenume";
            this.prenume.Size = new System.Drawing.Size(49, 13);
            this.prenume.TabIndex = 1;
            this.prenume.Text = "Prenume";
            // 
            // CNP
            // 
            this.CNP.AutoSize = true;
            this.CNP.Location = new System.Drawing.Point(35, 60);
            this.CNP.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.CNP.Name = "CNP";
            this.CNP.Size = new System.Drawing.Size(29, 13);
            this.CNP.TabIndex = 2;
            this.CNP.Text = "CNP";
            // 
            // FamilyNameTextBox
            // 
            this.FamilyNameTextBox.Location = new System.Drawing.Point(69, 11);
            this.FamilyNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FamilyNameTextBox.Name = "FamilyNameTextBox";
            this.FamilyNameTextBox.Size = new System.Drawing.Size(234, 20);
            this.FamilyNameTextBox.TabIndex = 3;
            // 
            // FirstNameTextBox
            // 
            this.FirstNameTextBox.Location = new System.Drawing.Point(69, 36);
            this.FirstNameTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.FirstNameTextBox.Name = "FirstNameTextBox";
            this.FirstNameTextBox.Size = new System.Drawing.Size(234, 20);
            this.FirstNameTextBox.TabIndex = 4;
            // 
            // CNPTextBox
            // 
            this.CNPTextBox.Location = new System.Drawing.Point(69, 58);
            this.CNPTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.CNPTextBox.Name = "CNPTextBox";
            this.CNPTextBox.Size = new System.Drawing.Size(234, 20);
            this.CNPTextBox.TabIndex = 5;
            // 
            // adresa
            // 
            this.adresa.AutoSize = true;
            this.adresa.Location = new System.Drawing.Point(23, 84);
            this.adresa.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.adresa.Name = "adresa";
            this.adresa.Size = new System.Drawing.Size(40, 13);
            this.adresa.TabIndex = 6;
            this.adresa.Text = "Adresă";
            // 
            // AddressTextBox
            // 
            this.AddressTextBox.Location = new System.Drawing.Point(69, 82);
            this.AddressTextBox.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.AddressTextBox.Name = "AddressTextBox";
            this.AddressTextBox.Size = new System.Drawing.Size(234, 20);
            this.AddressTextBox.TabIndex = 7;
            // 
            // addClientButton
            // 
            this.addClientButton.Location = new System.Drawing.Point(69, 114);
            this.addClientButton.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.addClientButton.Name = "addClientButton";
            this.addClientButton.Size = new System.Drawing.Size(75, 23);
            this.addClientButton.TabIndex = 8;
            this.addClientButton.Text = "Adaugă";
            this.addClientButton.UseVisualStyleBackColor = true;
            this.addClientButton.Click += new System.EventHandler(this.buttonAdd_Click);
            // 
            // ClientAddForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(315, 146);
            this.Controls.Add(this.addClientButton);
            this.Controls.Add(this.AddressTextBox);
            this.Controls.Add(this.adresa);
            this.Controls.Add(this.CNPTextBox);
            this.Controls.Add(this.FirstNameTextBox);
            this.Controls.Add(this.FamilyNameTextBox);
            this.Controls.Add(this.CNP);
            this.Controls.Add(this.prenume);
            this.Controls.Add(this.nume);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "ClientAddForm";
            this.Text = "ClientAddForm";
            this.Load += new System.EventHandler(this.ClientAddForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label nume;
        private System.Windows.Forms.Label prenume;
        private System.Windows.Forms.Label CNP;
        private System.Windows.Forms.TextBox FamilyNameTextBox;
        private System.Windows.Forms.TextBox FirstNameTextBox;
        private System.Windows.Forms.TextBox CNPTextBox;
        private System.Windows.Forms.Label adresa;
        private System.Windows.Forms.TextBox AddressTextBox;
        private System.Windows.Forms.Button addClientButton;
    }
}