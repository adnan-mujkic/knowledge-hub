using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.User
{
   partial class UserEdit
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
         this.BiographyInput = new System.Windows.Forms.TextBox();
         this.label5 = new System.Windows.Forms.Label();
         this.UsernameInput = new System.Windows.Forms.TextBox();
         this.label6 = new System.Windows.Forms.Label();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.button1 = new System.Windows.Forms.Button();
         this.RoleSelect = new System.Windows.Forms.ComboBox();
         this.label4 = new System.Windows.Forms.Label();
         this.BackButton = new System.Windows.Forms.Button();
         this.SubmitButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(64, 92);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(49, 20);
         this.label1.TabIndex = 0;
         this.label1.Text = "Email:";
         // 
         // EmailInput
         // 
         this.EmailInput.Location = new System.Drawing.Point(68, 121);
         this.EmailInput.Name = "EmailInput";
         this.EmailInput.Size = new System.Drawing.Size(311, 27);
         this.EmailInput.TabIndex = 1;
         this.EmailInput.Validating += new System.ComponentModel.CancelEventHandler(this.EmailInput_Validating);
         // 
         // BiographyInput
         // 
         this.BiographyInput.Location = new System.Drawing.Point(64, 276);
         this.BiographyInput.Multiline = true;
         this.BiographyInput.Name = "BiographyInput";
         this.BiographyInput.Size = new System.Drawing.Size(311, 116);
         this.BiographyInput.TabIndex = 9;
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(60, 247);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(80, 20);
         this.label5.TabIndex = 8;
         this.label5.Text = "Biography:";
         // 
         // UsernameInput
         // 
         this.UsernameInput.Location = new System.Drawing.Point(64, 204);
         this.UsernameInput.Name = "UsernameInput";
         this.UsernameInput.Size = new System.Drawing.Size(311, 27);
         this.UsernameInput.TabIndex = 7;
         this.UsernameInput.Validating += new System.ComponentModel.CancelEventHandler(this.UsernameInput_Validating);
         // 
         // label6
         // 
         this.label6.AutoSize = true;
         this.label6.Location = new System.Drawing.Point(60, 175);
         this.label6.Name = "label6";
         this.label6.Size = new System.Drawing.Size(78, 20);
         this.label6.TabIndex = 6;
         this.label6.Text = "Username:";
         // 
         // pictureBox1
         // 
         this.pictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
         this.pictureBox1.Location = new System.Drawing.Point(530, 11);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(200, 200);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 10;
         this.pictureBox1.TabStop = false;
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.Cursor = System.Windows.Forms.Cursors.Hand;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(530, 224);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(200, 39);
         this.button1.TabIndex = 11;
         this.button1.Text = "Select Picture";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // RoleSelect
         // 
         this.RoleSelect.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.RoleSelect.FormattingEnabled = true;
         this.RoleSelect.Items.AddRange(new object[] {
            "Admin",
            "Delivery",
            "User"});
         this.RoleSelect.Location = new System.Drawing.Point(530, 333);
         this.RoleSelect.Name = "RoleSelect";
         this.RoleSelect.Size = new System.Drawing.Size(200, 28);
         this.RoleSelect.TabIndex = 12;
         this.RoleSelect.Validating += new System.ComponentModel.CancelEventHandler(this.RoleSelect_Validating);
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(530, 304);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(86, 20);
         this.label4.TabIndex = 13;
         this.label4.Text = "Select Role:";
         // 
         // BackButton
         // 
         this.BackButton.BackColor = System.Drawing.Color.BurlyWood;
         this.BackButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.BackButton.FlatAppearance.BorderSize = 0;
         this.BackButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.BackButton.Location = new System.Drawing.Point(522, 469);
         this.BackButton.Name = "BackButton";
         this.BackButton.Size = new System.Drawing.Size(101, 39);
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
         this.SubmitButton.Location = new System.Drawing.Point(629, 469);
         this.SubmitButton.Name = "SubmitButton";
         this.SubmitButton.Size = new System.Drawing.Size(101, 39);
         this.SubmitButton.TabIndex = 15;
         this.SubmitButton.Text = "Update";
         this.SubmitButton.UseVisualStyleBackColor = false;
         this.SubmitButton.Click += new System.EventHandler(this.SubmitButton_Click);
         // 
         // UserEdit
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.SubmitButton);
         this.Controls.Add(this.BackButton);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.RoleSelect);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.BiographyInput);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.UsernameInput);
         this.Controls.Add(this.label6);
         this.Controls.Add(this.EmailInput);
         this.Controls.Add(this.label1);
         this.Name = "UserEdit";
         this.Size = new System.Drawing.Size(766, 533);
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private TextBox EmailInput;
      private TextBox BiographyInput;
      private Label label5;
      private TextBox UsernameInput;
      private Label label6;
      private PictureBox pictureBox1;
      private Button button1;
      private ComboBox RoleSelect;
      private Label label4;
      private Button BackButton;
      private Button SubmitButton;
   }
}
