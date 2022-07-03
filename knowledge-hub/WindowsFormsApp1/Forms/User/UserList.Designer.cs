using System.Windows.Forms;

namespace knowledge_hub.Forms.User
{
   partial class UserList
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
         this.UserSearchBox = new System.Windows.Forms.TextBox();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.UserID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Email = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Role = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.button2 = new System.Windows.Forms.Button();
         this.EditUserButton = new System.Windows.Forms.Button();
         this.DeleteUserButton = new System.Windows.Forms.Button();
         this.AddUserButton = new System.Windows.Forms.Button();
         this.SearchUsersButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
         this.label1.Location = new System.Drawing.Point(43, 25);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(76, 32);
         this.label1.TabIndex = 0;
         this.label1.Text = "Users";
         // 
         // UserSearchBox
         // 
         this.UserSearchBox.Location = new System.Drawing.Point(56, 64);
         this.UserSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.UserSearchBox.Name = "UserSearchBox";
         this.UserSearchBox.Size = new System.Drawing.Size(270, 22);
         this.UserSearchBox.TabIndex = 1;
         this.UserSearchBox.Text = "Enter Username";
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
         this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.UserID,
            this.Username,
            this.Email,
            this.Role});
         this.dataGridView1.Location = new System.Drawing.Point(56, 102);
         this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         this.dataGridView1.RowTemplate.Height = 29;
         this.dataGridView1.Size = new System.Drawing.Size(749, 263);
         this.dataGridView1.TabIndex = 3;
         // 
         // UserID
         // 
         this.UserID.DataPropertyName = "UserID";
         this.UserID.HeaderText = "UserID";
         this.UserID.MinimumWidth = 6;
         this.UserID.Name = "UserID";
         this.UserID.ReadOnly = true;
         this.UserID.Visible = false;
         this.UserID.Width = 125;
         // 
         // Username
         // 
         this.Username.DataPropertyName = "Username";
         this.Username.HeaderText = "Username";
         this.Username.MinimumWidth = 6;
         this.Username.Name = "Username";
         this.Username.ReadOnly = true;
         this.Username.Width = 125;
         // 
         // Email
         // 
         this.Email.DataPropertyName = "Email";
         this.Email.HeaderText = "Email";
         this.Email.MinimumWidth = 50;
         this.Email.Name = "Email";
         this.Email.ReadOnly = true;
         this.Email.Width = 300;
         // 
         // Role
         // 
         this.Role.DataPropertyName = "UserRole";
         this.Role.HeaderText = "Role";
         this.Role.MinimumWidth = 100;
         this.Role.Name = "Role";
         this.Role.ReadOnly = true;
         this.Role.Width = 125;
         // 
         // button2
         // 
         this.button2.BackColor = System.Drawing.Color.BurlyWood;
         this.button2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.button2.Cursor = System.Windows.Forms.Cursors.Hand;
         this.button2.FlatAppearance.BorderSize = 0;
         this.button2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button2.Location = new System.Drawing.Point(673, 370);
         this.button2.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.button2.Name = "button2";
         this.button2.Size = new System.Drawing.Size(132, 30);
         this.button2.TabIndex = 4;
         this.button2.Text = "Refresh";
         this.button2.UseVisualStyleBackColor = true;
         this.button2.Click += new System.EventHandler(this.button2_Click);
         // 
         // EditUserButton
         // 
         this.EditUserButton.BackColor = System.Drawing.Color.BurlyWood;
         this.EditUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.EditUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.EditUserButton.FlatAppearance.BorderSize = 0;
         this.EditUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.EditUserButton.Image = global::WindowsFormsApp1.Properties.Resources.editing16x;
         this.EditUserButton.Location = new System.Drawing.Point(692, 59);
         this.EditUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.EditUserButton.Name = "EditUserButton";
         this.EditUserButton.Size = new System.Drawing.Size(37, 30);
         this.EditUserButton.TabIndex = 6;
         this.EditUserButton.UseVisualStyleBackColor = true;
         this.EditUserButton.Click += new System.EventHandler(this.EditUserButton_Click);
         // 
         // DeleteUserButton
         // 
         this.DeleteUserButton.BackColor = System.Drawing.Color.BurlyWood;
         this.DeleteUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.DeleteUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.DeleteUserButton.FlatAppearance.BorderSize = 0;
         this.DeleteUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.DeleteUserButton.Image = global::WindowsFormsApp1.Properties.Resources.bin16x;
         this.DeleteUserButton.Location = new System.Drawing.Point(735, 59);
         this.DeleteUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.DeleteUserButton.Name = "DeleteUserButton";
         this.DeleteUserButton.Size = new System.Drawing.Size(37, 30);
         this.DeleteUserButton.TabIndex = 7;
         this.DeleteUserButton.UseVisualStyleBackColor = true;
         this.DeleteUserButton.Click += new System.EventHandler(this.DeleteUserButton_Click);
         // 
         // AddUserButton
         // 
         this.AddUserButton.BackColor = System.Drawing.Color.BurlyWood;
         this.AddUserButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.AddUserButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.AddUserButton.FlatAppearance.BorderSize = 0;
         this.AddUserButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.AddUserButton.Image = global::WindowsFormsApp1.Properties.Resources.plus16x;
         this.AddUserButton.Location = new System.Drawing.Point(649, 59);
         this.AddUserButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.AddUserButton.Name = "AddUserButton";
         this.AddUserButton.Size = new System.Drawing.Size(37, 30);
         this.AddUserButton.TabIndex = 5;
         this.AddUserButton.UseVisualStyleBackColor = true;
         this.AddUserButton.Click += new System.EventHandler(this.AddUserButton_Click);
         // 
         // SearchUsersButton
         // 
         this.SearchUsersButton.BackColor = System.Drawing.Color.BurlyWood;
         this.SearchUsersButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.SearchUsersButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.SearchUsersButton.FlatAppearance.BorderSize = 0;
         this.SearchUsersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.SearchUsersButton.Image = global::WindowsFormsApp1.Properties.Resources.search16x;
         this.SearchUsersButton.Location = new System.Drawing.Point(332, 59);
         this.SearchUsersButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SearchUsersButton.Name = "SearchUsersButton";
         this.SearchUsersButton.Size = new System.Drawing.Size(37, 30);
         this.SearchUsersButton.TabIndex = 2;
         this.SearchUsersButton.UseVisualStyleBackColor = true;
         this.SearchUsersButton.Click += new System.EventHandler(this.SearchUsersButton_Click);
         // 
         // UserList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.DeleteUserButton);
         this.Controls.Add(this.EditUserButton);
         this.Controls.Add(this.AddUserButton);
         this.Controls.Add(this.button2);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.SearchUsersButton);
         this.Controls.Add(this.UserSearchBox);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "UserList";
         this.Size = new System.Drawing.Size(864, 411);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private TextBox UserSearchBox;
      private Button SearchUsersButton;
      private DataGridView dataGridView1;
      private Button button2;
      private Button AddUserButton;
      private Button EditUserButton;
      private Button DeleteUserButton;
      private DataGridViewTextBoxColumn UserID;
      private DataGridViewTextBoxColumn Username;
      private DataGridViewTextBoxColumn Email;
      private DataGridViewTextBoxColumn Role;
   }
}
