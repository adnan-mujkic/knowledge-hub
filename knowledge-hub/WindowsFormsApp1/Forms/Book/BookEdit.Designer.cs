using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Book
{
   partial class BookEdit
   {
      /// <summary> 
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary> 
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.UpdateButton = new System.Windows.Forms.Button();
         this.BackButton = new System.Windows.Forms.Button();
         this.label4 = new System.Windows.Forms.Label();
         this.LanguageSelect = new System.Windows.Forms.ComboBox();
         this.SelectPictureButton = new System.Windows.Forms.Button();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.DescriptionInput = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.AuthorInput = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.NameInput = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.CategorySelect = new System.Windows.Forms.ComboBox();
         this.PriceDigitalInput = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.PricePhysicalInput = new System.Windows.Forms.TextBox();
         this.label7 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.label9 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // UpdateButton
         // 
         this.UpdateButton.BackColor = System.Drawing.Color.BurlyWood;
         this.UpdateButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.UpdateButton.FlatAppearance.BorderSize = 0;
         this.UpdateButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.UpdateButton.Location = new System.Drawing.Point(617, 381);
         this.UpdateButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.UpdateButton.Name = "UpdateButton";
         this.UpdateButton.Size = new System.Drawing.Size(101, 31);
         this.UpdateButton.TabIndex = 27;
         this.UpdateButton.Text = "Update";
         this.UpdateButton.UseVisualStyleBackColor = false;
         this.UpdateButton.Click += new System.EventHandler(this.UpdateButton_Click);
         // 
         // BackButton
         // 
         this.BackButton.BackColor = System.Drawing.Color.BurlyWood;
         this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.BackButton.FlatAppearance.BorderSize = 0;
         this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.BackButton.Location = new System.Drawing.Point(510, 381);
         this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.BackButton.Name = "BackButton";
         this.BackButton.Size = new System.Drawing.Size(101, 31);
         this.BackButton.TabIndex = 26;
         this.BackButton.Text = "Back";
         this.BackButton.UseVisualStyleBackColor = false;
         this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(518, 262);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(71, 16);
         this.label4.TabIndex = 25;
         this.label4.Text = "Language:";
         // 
         // LanguageSelect
         // 
         this.LanguageSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.LanguageSelect.FormattingEnabled = true;
         this.LanguageSelect.Items.AddRange(new object[] {
            "Admin",
            "Delivery",
            "User"});
         this.LanguageSelect.Location = new System.Drawing.Point(518, 285);
         this.LanguageSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.LanguageSelect.Name = "LanguageSelect";
         this.LanguageSelect.Size = new System.Drawing.Size(200, 24);
         this.LanguageSelect.TabIndex = 24;
         // 
         // SelectPictureButton
         // 
         this.SelectPictureButton.BackColor = System.Drawing.Color.BurlyWood;
         this.SelectPictureButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.SelectPictureButton.FlatAppearance.BorderSize = 0;
         this.SelectPictureButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.SelectPictureButton.Location = new System.Drawing.Point(518, 149);
         this.SelectPictureButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SelectPictureButton.Name = "SelectPictureButton";
         this.SelectPictureButton.Size = new System.Drawing.Size(200, 31);
         this.SelectPictureButton.TabIndex = 23;
         this.SelectPictureButton.Text = "Select Picture";
         this.SelectPictureButton.UseVisualStyleBackColor = false;
         this.SelectPictureButton.Click += new System.EventHandler(this.SelectPictureButton_Click);
         // 
         // pictureBox1
         // 
         this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pictureBox1.Location = new System.Drawing.Point(545, 20);
         this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(143, 113);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 22;
         this.pictureBox1.TabStop = false;
         // 
         // DescriptionInput
         // 
         this.DescriptionInput.Location = new System.Drawing.Point(61, 198);
         this.DescriptionInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.DescriptionInput.Multiline = true;
         this.DescriptionInput.Name = "DescriptionInput";
         this.DescriptionInput.Size = new System.Drawing.Size(311, 143);
         this.DescriptionInput.TabIndex = 21;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(57, 174);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(78, 16);
         this.label5.TabIndex = 20;
         this.label5.Text = "Description:";
         // 
         // AuthorInput
         // 
         this.AuthorInput.Location = new System.Drawing.Point(61, 140);
         this.AuthorInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.AuthorInput.Name = "AuthorInput";
         this.AuthorInput.Size = new System.Drawing.Size(311, 22);
         this.AuthorInput.TabIndex = 19;
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(57, 117);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(48, 16);
         this.label6.TabIndex = 18;
         this.label6.Text = "Author:";
         // 
         // NameInput
         // 
         this.NameInput.Location = new System.Drawing.Point(61, 53);
         this.NameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.NameInput.Multiline = true;
         this.NameInput.Name = "NameInput";
         this.NameInput.Size = new System.Drawing.Size(311, 41);
         this.NameInput.TabIndex = 17;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(57, 30);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(47, 16);
         this.label1.TabIndex = 16;
         this.label1.Text = "Name:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(518, 315);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(65, 16);
         this.label2.TabIndex = 29;
         this.label2.Text = "Category:";
         // 
         // CategorySelect
         // 
         this.CategorySelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CategorySelect.FormattingEnabled = true;
         this.CategorySelect.Items.AddRange(new object[] {
            "Admin",
            "Delivery",
            "User"});
         this.CategorySelect.Location = new System.Drawing.Point(518, 339);
         this.CategorySelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CategorySelect.Name = "CategorySelect";
         this.CategorySelect.Size = new System.Drawing.Size(200, 24);
         this.CategorySelect.TabIndex = 28;
         // 
         // PriceDigitalInput
         // 
         this.PriceDigitalInput.Location = new System.Drawing.Point(231, 375);
         this.PriceDigitalInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.PriceDigitalInput.Name = "PriceDigitalInput";
         this.PriceDigitalInput.Size = new System.Drawing.Size(132, 22);
         this.PriceDigitalInput.TabIndex = 33;
         this.PriceDigitalInput.Validating += new System.ComponentModel.CancelEventHandler(this.PriceDigitalInput_Validating);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(227, 352);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(80, 16);
         this.label3.TabIndex = 32;
         this.label3.Text = "Price digital:";
         // 
         // PricePhysicalInput
         // 
         this.PricePhysicalInput.Location = new System.Drawing.Point(61, 375);
         this.PricePhysicalInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.PricePhysicalInput.Name = "PricePhysicalInput";
         this.PricePhysicalInput.Size = new System.Drawing.Size(128, 22);
         this.PricePhysicalInput.TabIndex = 31;
         this.PricePhysicalInput.Validating += new System.ComponentModel.CancelEventHandler(this.PricePhysicalInput_Validating);
         // 
         // label7
         // 
         this.label7.AutoSize = true;
         this.label7.Location = new System.Drawing.Point(57, 352);
         this.label7.Name = "label7";
         this.label7.Size = new System.Drawing.Size(94, 16);
         this.label7.TabIndex = 30;
         this.label7.Text = "Price physical:";
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(518, 214);
         this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(200, 31);
         this.button1.TabIndex = 56;
         this.button1.Text = "Select File";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // label9
         // 
         this.label9.AutoSize = true;
         this.label9.Location = new System.Drawing.Point(515, 196);
         this.label9.Name = "label9";
         this.label9.Size = new System.Drawing.Size(42, 16);
         this.label9.TabIndex = 55;
         this.label9.Text = "Book:";
         // 
         // BookEdit
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label9);
         this.Controls.Add(this.PriceDigitalInput);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.PricePhysicalInput);
         this.Controls.Add(this.label7);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.CategorySelect);
         this.Controls.Add(this.UpdateButton);
         this.Controls.Add(this.BackButton);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.LanguageSelect);
         this.Controls.Add(this.SelectPictureButton);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.DescriptionInput);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.AuthorInput);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.NameInput);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "BookEdit";
         this.Size = new System.Drawing.Size(766, 426);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Button UpdateButton;
      private Button BackButton;
      private Label label4;
      private ComboBox LanguageSelect;
      private Button SelectPictureButton;
      private PictureBox pictureBox1;
      private TextBox DescriptionInput;
      private Label label5;
      private TextBox AuthorInput;
      private Label label6;
      private TextBox NameInput;
      private Label label1;
      private Label label2;
      private ComboBox CategorySelect;
      private TextBox PriceDigitalInput;
      private Label label3;
      private TextBox PricePhysicalInput;
      private Label label7;
      private Button button1;
      private Label label9;
   }
}
