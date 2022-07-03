using System.Windows.Forms;

namespace WindowsFormsApp1
{
   partial class AdminDashboard
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
         this.MinimizeAppButton = new System.Windows.Forms.Button();
         this.CloseAppButton = new System.Windows.Forms.Button();
         this.UserName = new System.Windows.Forms.Label();
         this.LogOutLink = new System.Windows.Forms.LinkLabel();
         this.UsersTabButton = new System.Windows.Forms.Button();
         this.ContentPanel = new System.Windows.Forms.Panel();
         this.CategoriesTabButton = new System.Windows.Forms.Button();
         this.CitiesTabButton = new System.Windows.Forms.Button();
         this.LanguagesTabButton = new System.Windows.Forms.Button();
         this.BooksTabButton = new System.Windows.Forms.Button();
         this.TransactionsTabButton = new System.Windows.Forms.Button();
         this.ReportsTabButton = new System.Windows.Forms.Button();
         this.pictureBox5 = new System.Windows.Forms.PictureBox();
         this.pictureBox4 = new System.Windows.Forms.PictureBox();
         this.pictureBox1 = new System.Windows.Forms.PictureBox();
         this.pictureBox3 = new System.Windows.Forms.PictureBox();
         this.pictureBox2 = new System.Windows.Forms.PictureBox();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
         this.SuspendLayout();
         // 
         // MinimizeAppButton
         // 
         this.MinimizeAppButton.BackColor = System.Drawing.Color.DarkCyan;
         this.MinimizeAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.MinimizeAppButton.FlatAppearance.BorderSize = 0;
         this.MinimizeAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.MinimizeAppButton.ForeColor = System.Drawing.Color.White;
         this.MinimizeAppButton.Location = new System.Drawing.Point(900, 5);
         this.MinimizeAppButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.MinimizeAppButton.Name = "MinimizeAppButton";
         this.MinimizeAppButton.Size = new System.Drawing.Size(32, 26);
         this.MinimizeAppButton.TabIndex = 13;
         this.MinimizeAppButton.Text = "_";
         this.MinimizeAppButton.UseVisualStyleBackColor = false;
         this.MinimizeAppButton.Click += new System.EventHandler(this.MinimizeAppButton_Click);
         // 
         // CloseAppButton
         // 
         this.CloseAppButton.BackColor = System.Drawing.Color.DarkRed;
         this.CloseAppButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.CloseAppButton.FlatAppearance.BorderSize = 0;
         this.CloseAppButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CloseAppButton.ForeColor = System.Drawing.Color.White;
         this.CloseAppButton.Location = new System.Drawing.Point(938, 5);
         this.CloseAppButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CloseAppButton.Name = "CloseAppButton";
         this.CloseAppButton.Size = new System.Drawing.Size(32, 26);
         this.CloseAppButton.TabIndex = 12;
         this.CloseAppButton.Text = "X";
         this.CloseAppButton.UseVisualStyleBackColor = false;
         this.CloseAppButton.Click += new System.EventHandler(this.CloseAppButton_Click);
         // 
         // UserName
         // 
         this.UserName.AutoSize = true;
         this.UserName.BackColor = System.Drawing.Color.Gainsboro;
         this.UserName.Location = new System.Drawing.Point(57, 48);
         this.UserName.Name = "UserName";
         this.UserName.Size = new System.Drawing.Size(0, 16);
         this.UserName.TabIndex = 16;
         // 
         // LogOutLink
         // 
         this.LogOutLink.ActiveLinkColor = System.Drawing.Color.Firebrick;
         this.LogOutLink.AutoSize = true;
         this.LogOutLink.BackColor = System.Drawing.Color.Gainsboro;
         this.LogOutLink.LinkColor = System.Drawing.Color.SteelBlue;
         this.LogOutLink.Location = new System.Drawing.Point(900, 48);
         this.LogOutLink.Name = "LogOutLink";
         this.LogOutLink.Size = new System.Drawing.Size(53, 16);
         this.LogOutLink.TabIndex = 17;
         this.LogOutLink.TabStop = true;
         this.LogOutLink.Text = "Log Out";
         this.LogOutLink.VisitedLinkColor = System.Drawing.Color.DarkViolet;
         this.LogOutLink.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.LogOutLink_LinkClicked);
         // 
         // UsersTabButton
         // 
         this.UsersTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.UsersTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.UsersTabButton.FlatAppearance.BorderSize = 0;
         this.UsersTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.UsersTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.UsersTabButton.Location = new System.Drawing.Point(0, 80);
         this.UsersTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.UsersTabButton.Name = "UsersTabButton";
         this.UsersTabButton.Size = new System.Drawing.Size(144, 48);
         this.UsersTabButton.TabIndex = 19;
         this.UsersTabButton.Text = "Users";
         this.UsersTabButton.UseVisualStyleBackColor = false;
         this.UsersTabButton.Click += new System.EventHandler(this.UsersTabButton_Click);
         // 
         // ContentPanel
         // 
         this.ContentPanel.Location = new System.Drawing.Point(150, 78);
         this.ContentPanel.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ContentPanel.Name = "ContentPanel";
         this.ContentPanel.Size = new System.Drawing.Size(820, 435);
         this.ContentPanel.TabIndex = 20;
         // 
         // CategoriesTabButton
         // 
         this.CategoriesTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.CategoriesTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.CategoriesTabButton.FlatAppearance.BorderSize = 0;
         this.CategoriesTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CategoriesTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.CategoriesTabButton.Location = new System.Drawing.Point(0, 128);
         this.CategoriesTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CategoriesTabButton.Name = "CategoriesTabButton";
         this.CategoriesTabButton.Size = new System.Drawing.Size(144, 48);
         this.CategoriesTabButton.TabIndex = 21;
         this.CategoriesTabButton.Text = "Categories";
         this.CategoriesTabButton.UseVisualStyleBackColor = false;
         this.CategoriesTabButton.Click += new System.EventHandler(this.CategoriesTabButton_Click);
         // 
         // CitiesTabButton
         // 
         this.CitiesTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.CitiesTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.CitiesTabButton.FlatAppearance.BorderSize = 0;
         this.CitiesTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CitiesTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.CitiesTabButton.Location = new System.Drawing.Point(0, 176);
         this.CitiesTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CitiesTabButton.Name = "CitiesTabButton";
         this.CitiesTabButton.Size = new System.Drawing.Size(144, 48);
         this.CitiesTabButton.TabIndex = 22;
         this.CitiesTabButton.Text = "Cities";
         this.CitiesTabButton.UseVisualStyleBackColor = false;
         this.CitiesTabButton.Click += new System.EventHandler(this.CitiesTabButton_Click);
         // 
         // LanguagesTabButton
         // 
         this.LanguagesTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.LanguagesTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.LanguagesTabButton.FlatAppearance.BorderSize = 0;
         this.LanguagesTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.LanguagesTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.LanguagesTabButton.Location = new System.Drawing.Point(0, 224);
         this.LanguagesTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.LanguagesTabButton.Name = "LanguagesTabButton";
         this.LanguagesTabButton.Size = new System.Drawing.Size(144, 48);
         this.LanguagesTabButton.TabIndex = 23;
         this.LanguagesTabButton.Text = "Languages";
         this.LanguagesTabButton.UseVisualStyleBackColor = false;
         this.LanguagesTabButton.Click += new System.EventHandler(this.LanguagesTabButton_Click);
         // 
         // BooksTabButton
         // 
         this.BooksTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.BooksTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.BooksTabButton.FlatAppearance.BorderSize = 0;
         this.BooksTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.BooksTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.BooksTabButton.Location = new System.Drawing.Point(0, 272);
         this.BooksTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.BooksTabButton.Name = "BooksTabButton";
         this.BooksTabButton.Size = new System.Drawing.Size(144, 48);
         this.BooksTabButton.TabIndex = 24;
         this.BooksTabButton.Text = "Books";
         this.BooksTabButton.UseVisualStyleBackColor = false;
         this.BooksTabButton.Click += new System.EventHandler(this.BooksTabButton_Click);
         // 
         // TransactionsTabButton
         // 
         this.TransactionsTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.TransactionsTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.TransactionsTabButton.FlatAppearance.BorderSize = 0;
         this.TransactionsTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.TransactionsTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.TransactionsTabButton.Location = new System.Drawing.Point(0, 320);
         this.TransactionsTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.TransactionsTabButton.Name = "TransactionsTabButton";
         this.TransactionsTabButton.Size = new System.Drawing.Size(144, 48);
         this.TransactionsTabButton.TabIndex = 25;
         this.TransactionsTabButton.Text = "Transactions";
         this.TransactionsTabButton.UseVisualStyleBackColor = false;
         this.TransactionsTabButton.Click += new System.EventHandler(this.TransactionsTabButton_Click);
         // 
         // ReportsTabButton
         // 
         this.ReportsTabButton.BackColor = System.Drawing.Color.BurlyWood;
         this.ReportsTabButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.ReportsTabButton.FlatAppearance.BorderSize = 0;
         this.ReportsTabButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.ReportsTabButton.Font = new System.Drawing.Font("Segoe UI", 11F, System.Drawing.FontStyle.Bold);
         this.ReportsTabButton.Location = new System.Drawing.Point(0, 368);
         this.ReportsTabButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.ReportsTabButton.Name = "ReportsTabButton";
         this.ReportsTabButton.Size = new System.Drawing.Size(144, 48);
         this.ReportsTabButton.TabIndex = 26;
         this.ReportsTabButton.Text = "Reports";
         this.ReportsTabButton.UseVisualStyleBackColor = false;
         this.ReportsTabButton.Click += new System.EventHandler(this.ReportsTabButton_Click);
         // 
         // pictureBox5
         // 
         this.pictureBox5.BackColor = System.Drawing.Color.BurlyWood;
         this.pictureBox5.Location = new System.Drawing.Point(0, 72);
         this.pictureBox5.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox5.Name = "pictureBox5";
         this.pictureBox5.Size = new System.Drawing.Size(144, 455);
         this.pictureBox5.TabIndex = 18;
         this.pictureBox5.TabStop = false;
         // 
         // pictureBox4
         // 
         this.pictureBox4.BackColor = System.Drawing.Color.Gainsboro;
         this.pictureBox4.Image = global::WindowsFormsApp1.Properties.Resources.user;
         this.pictureBox4.Location = new System.Drawing.Point(12, 42);
         this.pictureBox4.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox4.Name = "pictureBox4";
         this.pictureBox4.Size = new System.Drawing.Size(37, 27);
         this.pictureBox4.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox4.TabIndex = 15;
         this.pictureBox4.TabStop = false;
         // 
         // pictureBox1
         // 
         this.pictureBox1.BackColor = System.Drawing.Color.Gainsboro;
         this.pictureBox1.Location = new System.Drawing.Point(-9, 35);
         this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox1.Name = "pictureBox1";
         this.pictureBox1.Size = new System.Drawing.Size(1000, 38);
         this.pictureBox1.TabIndex = 14;
         this.pictureBox1.TabStop = false;
         // 
         // pictureBox3
         // 
         this.pictureBox3.BackColor = System.Drawing.Color.BurlyWood;
         this.pictureBox3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
         this.pictureBox3.Image = global::WindowsFormsApp1.Properties.Resources.LogoWhite;
         this.pictureBox3.Location = new System.Drawing.Point(20, 10);
         this.pictureBox3.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox3.Name = "pictureBox3";
         this.pictureBox3.Size = new System.Drawing.Size(27, 21);
         this.pictureBox3.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
         this.pictureBox3.TabIndex = 11;
         this.pictureBox3.TabStop = false;
         // 
         // pictureBox2
         // 
         this.pictureBox2.BackColor = System.Drawing.Color.BurlyWood;
         this.pictureBox2.Location = new System.Drawing.Point(0, 0);
         this.pictureBox2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.pictureBox2.Name = "pictureBox2";
         this.pictureBox2.Size = new System.Drawing.Size(1000, 38);
         this.pictureBox2.TabIndex = 10;
         this.pictureBox2.TabStop = false;
         // 
         // AdminDashboard
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(982, 522);
         this.Controls.Add(this.ReportsTabButton);
         this.Controls.Add(this.TransactionsTabButton);
         this.Controls.Add(this.BooksTabButton);
         this.Controls.Add(this.LanguagesTabButton);
         this.Controls.Add(this.CitiesTabButton);
         this.Controls.Add(this.CategoriesTabButton);
         this.Controls.Add(this.ContentPanel);
         this.Controls.Add(this.UsersTabButton);
         this.Controls.Add(this.pictureBox5);
         this.Controls.Add(this.LogOutLink);
         this.Controls.Add(this.UserName);
         this.Controls.Add(this.pictureBox4);
         this.Controls.Add(this.pictureBox1);
         this.Controls.Add(this.MinimizeAppButton);
         this.Controls.Add(this.CloseAppButton);
         this.Controls.Add(this.pictureBox3);
         this.Controls.Add(this.pictureBox2);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "AdminDashboard";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "AdminDashboard";
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox5)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
         ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Button MinimizeAppButton;
      private Button CloseAppButton;
      private PictureBox pictureBox3;
      private PictureBox pictureBox2;
      private PictureBox pictureBox1;
      private PictureBox pictureBox4;
      private Label UserName;
      private LinkLabel LogOutLink;
      private PictureBox pictureBox5;
      private Button UsersTabButton;
      private Panel ContentPanel;
      private Button CategoriesTabButton;
      private Button CitiesTabButton;
      private Button LanguagesTabButton;
      private Button BooksTabButton;
      private Button TransactionsTabButton;
      private Button ReportsTabButton;
   }
}