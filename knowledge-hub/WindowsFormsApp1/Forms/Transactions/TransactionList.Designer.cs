using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Transactions
{
   partial class TransactionList
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
         this.DeleteButton = new System.Windows.Forms.Button();
         this.RefreshButton = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.TransactionID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.OrderID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CardLastDigits = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.userFullName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.bookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.TransactionDate = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Price = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.SearchButton = new System.Windows.Forms.Button();
         this.UserSearchBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // DeleteButton
         // 
         this.DeleteButton.BackColor = System.Drawing.Color.BurlyWood;
         this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.DeleteButton.FlatAppearance.BorderSize = 0;
         this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.DeleteButton.Image = global::WindowsFormsApp1.Properties.Resources.bin16x;
         this.DeleteButton.Location = new System.Drawing.Point(767, 49);
         this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.DeleteButton.Name = "DeleteButton";
         this.DeleteButton.Size = new System.Drawing.Size(37, 30);
         this.DeleteButton.TabIndex = 21;
         this.DeleteButton.UseVisualStyleBackColor = true;
         this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
         // 
         // RefreshButton
         // 
         this.RefreshButton.BackColor = System.Drawing.Color.BurlyWood;
         this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.RefreshButton.FlatAppearance.BorderSize = 0;
         this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.RefreshButton.Location = new System.Drawing.Point(672, 359);
         this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.RefreshButton.Name = "RefreshButton";
         this.RefreshButton.Size = new System.Drawing.Size(132, 30);
         this.RefreshButton.TabIndex = 20;
         this.RefreshButton.Text = "Refresh";
         this.RefreshButton.UseVisualStyleBackColor = true;
         this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.BackgroundColor = System.Drawing.Color.Gainsboro;
         this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.TransactionID,
            this.OrderID,
            this.CardLastDigits,
            this.userFullName,
            this.bookName,
            this.TransactionDate,
            this.Price});
         this.dataGridView1.Location = new System.Drawing.Point(19, 91);
         this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         this.dataGridView1.RowTemplate.Height = 29;
         this.dataGridView1.Size = new System.Drawing.Size(785, 263);
         this.dataGridView1.TabIndex = 19;
         // 
         // TransactionID
         // 
         this.TransactionID.DataPropertyName = "TransactionID";
         this.TransactionID.HeaderText = "TransactionID";
         this.TransactionID.MinimumWidth = 6;
         this.TransactionID.Name = "TransactionID";
         this.TransactionID.ReadOnly = true;
         this.TransactionID.Visible = false;
         this.TransactionID.Width = 125;
         // 
         // OrderID
         // 
         this.OrderID.DataPropertyName = "OrderID";
         this.OrderID.HeaderText = "ID";
         this.OrderID.MinimumWidth = 6;
         this.OrderID.Name = "OrderID";
         this.OrderID.ReadOnly = true;
         this.OrderID.Width = 50;
         // 
         // CardLastDigits
         // 
         this.CardLastDigits.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None;
         this.CardLastDigits.DataPropertyName = "CardLastDigits";
         this.CardLastDigits.HeaderText = "Card Number";
         this.CardLastDigits.MinimumWidth = 6;
         this.CardLastDigits.Name = "CardLastDigits";
         this.CardLastDigits.ReadOnly = true;
         this.CardLastDigits.Width = 130;
         // 
         // userFullName
         // 
         this.userFullName.DataPropertyName = "userFullName";
         this.userFullName.HeaderText = "Full Name";
         this.userFullName.MinimumWidth = 6;
         this.userFullName.Name = "userFullName";
         this.userFullName.ReadOnly = true;
         this.userFullName.Width = 125;
         // 
         // bookName
         // 
         this.bookName.DataPropertyName = "bookName";
         this.bookName.HeaderText = "Book Name";
         this.bookName.MinimumWidth = 6;
         this.bookName.Name = "bookName";
         this.bookName.ReadOnly = true;
         this.bookName.Width = 125;
         // 
         // TransactionDate
         // 
         this.TransactionDate.DataPropertyName = "transactionDate";
         this.TransactionDate.HeaderText = "Date";
         this.TransactionDate.MinimumWidth = 50;
         this.TransactionDate.Name = "TransactionDate";
         this.TransactionDate.ReadOnly = true;
         this.TransactionDate.Width = 125;
         // 
         // Price
         // 
         this.Price.DataPropertyName = "Price";
         this.Price.HeaderText = "Price";
         this.Price.MinimumWidth = 50;
         this.Price.Name = "Price";
         this.Price.ReadOnly = true;
         this.Price.Width = 60;
         // 
         // SearchButton
         // 
         this.SearchButton.BackColor = System.Drawing.Color.BurlyWood;
         this.SearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.SearchButton.FlatAppearance.BorderSize = 0;
         this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.SearchButton.Image = global::WindowsFormsApp1.Properties.Resources.search16x;
         this.SearchButton.Location = new System.Drawing.Point(295, 49);
         this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SearchButton.Name = "SearchButton";
         this.SearchButton.Size = new System.Drawing.Size(37, 30);
         this.SearchButton.TabIndex = 18;
         this.SearchButton.UseVisualStyleBackColor = true;
         this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
         // 
         // UserSearchBox
         // 
         this.UserSearchBox.Location = new System.Drawing.Point(19, 54);
         this.UserSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.UserSearchBox.Name = "UserSearchBox";
         this.UserSearchBox.Size = new System.Drawing.Size(270, 22);
         this.UserSearchBox.TabIndex = 17;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
         this.label1.Location = new System.Drawing.Point(6, 14);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(157, 32);
         this.label1.TabIndex = 16;
         this.label1.Text = "Transactions";
         // 
         // TransactionList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.DeleteButton);
         this.Controls.Add(this.RefreshButton);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.SearchButton);
         this.Controls.Add(this.UserSearchBox);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "TransactionList";
         this.Size = new System.Drawing.Size(864, 411);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Button DeleteButton;
      private Button RefreshButton;
      private DataGridView dataGridView1;
      private Button SearchButton;
      private TextBox UserSearchBox;
      private Label label1;
      private DataGridViewTextBoxColumn TransactionID;
      private DataGridViewTextBoxColumn OrderID;
      private DataGridViewTextBoxColumn CardLastDigits;
      private DataGridViewTextBoxColumn userFullName;
      private DataGridViewTextBoxColumn bookName;
      private DataGridViewTextBoxColumn TransactionDate;
      private DataGridViewTextBoxColumn Price;
   }
}
