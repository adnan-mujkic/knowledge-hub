using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.User
{
   partial class UserAdd
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
         this.label1 = new System.Windows.Forms.Label();
         this.EmailInput = new System.Windows.Forms.TextBox();
         this.PasswordInput = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.PasswordConfirmInput = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.BiographyInput = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.UsernameInput = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.RoleSelect = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.BackButton = new System.Windows.Forms.Button();
         this.SubmitButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(31, 52);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "Email:";
         // 
         // EmailInput
         // 
         this.EmailInput.Location = new System.Drawing.Point(35, 75);
         this.EmailInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.EmailInput.Name = "EmailInput";
         this.EmailInput.Size = new System.Drawing.Size(311, 22);
         this.EmailInput.TabIndex = 1;
         this.EmailInput.Validating += new System.ComponentModel.CancelEventHandler(this.EmailInput_Validating);
         // 
         // PasswordInput
         // 
         this.PasswordInput.Location = new System.Drawing.Point(35, 146);
         this.PasswordInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.PasswordInput.Name = "PasswordInput";
         this.PasswordInput.PasswordChar = '*';
         this.PasswordInput.Size = new System.Drawing.Size(311, 22);
         this.PasswordInput.TabIndex = 3;
         this.PasswordInput.Validating += new System.ComponentModel.CancelEventHandler(this.PasswordInput_Validating);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(31, 123);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(70, 16);
         this.label2.TabIndex = 2;
         this.label2.Text = "Password:";
         // 
         // PasswordConfirmInput
         // 
         this.PasswordConfirmInput.Location = new System.Drawing.Point(36, 216);
         this.PasswordConfirmInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.PasswordConfirmInput.Name = "PasswordConfirmInput";
         this.PasswordConfirmInput.PasswordChar = '*';
         this.PasswordConfirmInput.Size = new System.Drawing.Size(311, 22);
         this.PasswordConfirmInput.TabIndex = 5;
         this.PasswordConfirmInput.Validating += new System.ComponentModel.CancelEventHandler(this.PasswordConfirmInput_Validating);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(32, 193);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(118, 16);
         this.label3.TabIndex = 4;
         this.label3.Text = "Confirm Password:";
         // 
         // BiographyInput
         // 
         this.BiographyInput.Location = new System.Drawing.Point(419, 74);
         this.BiographyInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.BiographyInput.Multiline = true;
         this.BiographyInput.Name = "BiographyInput";
         this.BiographyInput.Size = new System.Drawing.Size(311, 164);
         this.BiographyInput.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(415, 51);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(72, 16);
         this.label5.TabIndex = 8;
         this.label5.Text = "Biography:";
         // 
         // UsernameInput
         // 
         this.UsernameInput.Location = new System.Drawing.Point(36, 286);
         this.UsernameInput.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.UsernameInput.Name = "UsernameInput";
         this.UsernameInput.Size = new System.Drawing.Size(311, 22);
         this.UsernameInput.TabIndex = 7;
         this.UsernameInput.Validating += new System.ComponentModel.CancelEventHandler(this.UsernameInput_Validating);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(32, 263);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(73, 16);
         this.label6.TabIndex = 6;
         this.label6.Text = "Username:";
         // 
         // RoleSelect
         // 
         this.RoleSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.RoleSelect.FormattingEnabled = true;
         this.RoleSelect.Items.AddRange(new object[] {
            "Admin",
            "Delivery",
            "User"});
         this.RoleSelect.Location = new System.Drawing.Point(419, 284);
         this.RoleSelect.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.RoleSelect.Name = "RoleSelect";
         this.RoleSelect.Size = new System.Drawing.Size(200, 24);
         this.RoleSelect.TabIndex = 12;
         this.RoleSelect.Validating += new System.ComponentModel.CancelEventHandler(this.RoleSelect_Validating);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(419, 261);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(80, 16);
         this.label4.TabIndex = 13;
         this.label4.Text = "Select Role:";
         // 
         // BackButton
         // 
         this.BackButton.BackColor = System.Drawing.Color.BurlyWood;
         this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.BackButton.FlatAppearance.BorderSize = 0;
         this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.BackButton.Location = new System.Drawing.Point(522, 375);
         this.BackButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.BackButton.Name = "BackButton";
         this.BackButton.Size = new System.Drawing.Size(101, 31);
         this.BackButton.TabIndex = 14;
         this.BackButton.Text = "Back";
         this.BackButton.UseVisualStyleBackColor = false;
         this.BackButton.Click += new System.EventHandler(this.BackButton_Click);
         // 
         // SubmitButton
         // 
         this.SubmitButton.BackColor = System.Drawing.Color.BurlyWood;
         this.SubmitButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.SubmitButton.FlatAppearance.BorderSize = 0;
         this.SubmitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.SubmitButton.Location = new System.Drawing.Point(629, 375);
         this.SubmitButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SubmitButton.Name = "SubmitButton";
         this.SubmitButton.Size = new System.Drawing.Size(101, 31);
         this.SubmitButton.TabIndex = 15;
         this.SubmitButton.Text = "Submit";
         this.SubmitButton.UseVisualStyleBackColor = false;
         this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
         // 
         // UserAdd
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.SubmitButton);
         this.Controls.Add(this.BackButton);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.RoleSelect);
         this.Controls.Add(this.BiographyInput);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.UsernameInput);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.PasswordConfirmInput);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.PasswordInput);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.EmailInput);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "UserAdd";
         this.Size = new System.Drawing.Size(766, 426);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private TextBox EmailInput;
      private TextBox PasswordInput;
      private Label label2;
      private TextBox PasswordConfirmInput;
      private Label label3;
      private TextBox BiographyInput;
      private Label label5;
      private TextBox UsernameInput;
      private Label label6;
      private ComboBox RoleSelect;
      private Label label4;
      private Button BackButton;
      private Button SubmitButton;
   }
}
