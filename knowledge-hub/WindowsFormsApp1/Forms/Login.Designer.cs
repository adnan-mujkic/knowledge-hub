using System.Windows.Forms;

namespace knowledge_hub.Desktop.Forms
{
   partial class Login
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

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.usernameField = new System.Windows.Forms.TextBox();
         this.passwordField = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.CloseAppButton = new System.Windows.Forms.Button();
         this.MinimizeAppButton = new System.Windows.Forms.Button();
         this.pictureBox3 = new System.Windows.Forms.PictureBox();
         this.pictureBox2 = new System.Windows.Forms.PictureBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         this.SuspendLayout();
         // 
         // usernameField
         // 
         this.usernameField.Location = new System.Drawing.Point(198, 169);
         this.usernameField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.usernameField.Name = "usernameField";
         this.usernameField.Size = new System.Drawing.Size(300, 22);
         this.usernameField.TabIndex = 1;
         // 
         // passwordField
         // 
         this.passwordField.Location = new System.Drawing.Point(195, 242);
         this.passwordField.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.passwordField.Name = "passwordField";
         this.passwordField.PasswordChar = '*';
         this.passwordField.Size = new System.Drawing.Size(300, 22);
         this.passwordField.TabIndex = 2;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(195, 142);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(44, 16);
         this.label1.TabIndex = 3;
         this.label1.Text = "Email:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(195, 216);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(70, 16);
         this.label2.TabIndex = 4;
         this.label2.Text = "Password:";
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(277, 312);
         this.button1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(130, 40);
         this.button1.TabIndex = 5;
         this.button1.Text = "Login";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // CloseAppButton
         // 
         this.CloseAppButton.BackColor = System.Drawing.Color.DarkRed;
         this.CloseAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.CloseAppButton.FlatAppearance.BorderSize = 0;
         this.CloseAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CloseAppButton.ForeColor = System.Drawing.Color.White;
         this.CloseAppButton.Location = new System.Drawing.Point(648, 6);
         this.CloseAppButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CloseAppButton.Name = "CloseAppButton";
         this.CloseAppButton.Size = new System.Drawing.Size(32, 26);
         this.CloseAppButton.TabIndex = 8;
         this.CloseAppButton.Text = "X";
         this.CloseAppButton.UseVisualStyleBackColor = false;
         this.CloseAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
         // 
         // MinimizeAppButton
         // 
         this.MinimizeAppButton.BackColor = System.Drawing.Color.DarkCyan;
         this.MinimizeAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.MinimizeAppButton.FlatAppearance.BorderSize = 0;
         this.MinimizeAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.MinimizeAppButton.ForeColor = System.Drawing.Color.White;
         this.MinimizeAppButton.Location = new System.Drawing.Point(610, 6);
         this.MinimizeAppButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MinimizeAppButton.Name = "MinimizeAppButton";
         this.MinimizeAppButton.Size = new System.Drawing.Size(32, 26);
         this.MinimizeAppButton.TabIndex = 9;
         this.MinimizeAppButton.Text = "_";
         this.MinimizeAppButton.UseVisualStyleBackColor = false;
         this.MinimizeAppButton.Click += new System.EventHandler(this.MinimizeAppButton_Click);
         // 
         // pictureBox3
         // 
         this.pictureBox3.BackColor = System.Drawing.Color.BurlyWood;
         this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.LogoWhite;
         this.pictureBox3.Location = new System.Drawing.Point(12, 10);
         this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox3.Name = "pictureBox3";
         this.pictureBox3.Size = new System.Drawing.Size(27, 21);
         this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox3.TabIndex = 7;
         this.pictureBox3.TabStop = false;
         // 
         // pictureBox2
         // 
         this.pictureBox2.BackColor = System.Drawing.Color.BurlyWood;
         this.pictureBox2.Location = new System.Drawing.Point(0, 0);
         this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox2.Name = "pictureBox2";
         this.pictureBox2.Size = new System.Drawing.Size(700, 38);
         this.pictureBox2.TabIndex = 6;
         this.pictureBox2.TabStop = false;
         // 
         // pictureBox1
         // 
         this.pictureBox1.Image = global::WindowsFormsApp1.Properties.Resources.user;
         this.pictureBox1.Location = new System.Drawing.Point(302, 55);
         this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(80, 64);
         this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox1.TabIndex = 0;
         this.pictureBox1.TabStop = false;
         // 
         // Login
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(700, 374);
         this.ControlBox = false;
         this.Controls.Add(this.MinimizeAppButton);
         this.Controls.Add(this.CloseAppButton);
         this.Controls.Add(this.pictureBox3);
         this.Controls.Add(this.pictureBox2);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.label1);
         this.Controls.Add(this.passwordField);
         this.Controls.Add(this.usernameField);
         this.Controls.Add(this.pictureBox1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MaximizeBox = false;
         this.Name = "Login";
         this.ShowIcon = false;
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "Login";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private PictureBox pictureBox1;
      private TextBox usernameField;
      private TextBox passwordField;
      private Label label1;
      private Label label2;
      private Button button1;
      private PictureBox pictureBox2;
      private PictureBox pictureBox3;
      private Button CloseAppButton;
      private Button MinimizeAppButton;
   }
}