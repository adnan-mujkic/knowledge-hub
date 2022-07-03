using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Book
{
   partial class BookList
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
         this.EditButton = new System.Windows.Forms.Button();
         this.RefreshButton = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.BookID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Author = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Description = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.PhysicalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.DigitalPrice = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.UserScore = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Language = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Category = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.UserSearchBox = new System.Windows.Forms.TextBox();
         this.label1 = new System.Windows.Forms.Label();
         this.AddButton = new System.Windows.Forms.Button();
         this.SearchButton = new System.Windows.Forms.Button();
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
         this.DeleteButton.Location = new System.Drawing.Point(743, 53);
         this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.DeleteButton.Name = "DeleteButton";
         this.DeleteButton.Size = new System.Drawing.Size(37, 30);
         this.DeleteButton.TabIndex = 15;
         this.DeleteButton.UseVisualStyleBackColor = true;
         this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
         // 
         // EditButton
         // 
         this.EditButton.BackColor = System.Drawing.Color.BurlyWood;
         this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.EditButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.EditButton.FlatAppearance.BorderSize = 0;
         this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.EditButton.Image = global::WindowsFormsApp1.Properties.Resources.editing16x;
         this.EditButton.Location = new System.Drawing.Point(700, 53);
         this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.EditButton.Name = "EditButton";
         this.EditButton.Size = new System.Drawing.Size(37, 30);
         this.EditButton.TabIndex = 14;
         this.EditButton.UseVisualStyleBackColor = true;
         this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
         // 
         // RefreshButton
         // 
         this.RefreshButton.BackColor = System.Drawing.Color.BurlyWood;
         this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.RefreshButton.FlatAppearance.BorderSize = 0;
         this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.RefreshButton.Location = new System.Drawing.Point(681, 363);
         this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.RefreshButton.Name = "RefreshButton";
         this.RefreshButton.Size = new System.Drawing.Size(132, 30);
         this.RefreshButton.TabIndex = 12;
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
            this.BookID,
            this.BookName,
            this.Author,
            this.Description,
            this.PhysicalPrice,
            this.DigitalPrice,
            this.UserScore,
            this.Language,
            this.Category});
         this.dataGridView1.Location = new System.Drawing.Point(64, 95);
         this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         this.dataGridView1.RowTemplate.Height = 29;
         this.dataGridView1.Size = new System.Drawing.Size(749, 263);
         this.dataGridView1.TabIndex = 11;
         // 
         // BookID
         // 
         this.BookID.DataPropertyName = "BookID";
         this.BookID.HeaderText = "BookID";
         this.BookID.MinimumWidth = 6;
         this.BookID.Name = "BookID";
         this.BookID.ReadOnly = true;
         this.BookID.Visible = false;
         this.BookID.Width = 125;
         // 
         // BookName
         // 
         this.BookName.DataPropertyName = "Name";
         this.BookName.HeaderText = "Book Name";
         this.BookName.MinimumWidth = 6;
         this.BookName.Name = "BookName";
         this.BookName.ReadOnly = true;
         this.BookName.Width = 300;
         // 
         // Author
         // 
         this.Author.DataPropertyName = "Author";
         this.Author.HeaderText = "Author";
         this.Author.MinimumWidth = 50;
         this.Author.Name = "Author";
         this.Author.ReadOnly = true;
         this.Author.Width = 150;
         // 
         // Description
         // 
         this.Description.DataPropertyName = "Description";
         this.Description.HeaderText = "Description";
         this.Description.MinimumWidth = 100;
         this.Description.Name = "Description";
         this.Description.ReadOnly = true;
         this.Description.Width = 200;
         // 
         // PhysicalPrice
         // 
         this.PhysicalPrice.DataPropertyName = "PricePhysical";
         this.PhysicalPrice.HeaderText = "Physical Price";
         this.PhysicalPrice.MinimumWidth = 6;
         this.PhysicalPrice.Name = "PhysicalPrice";
         this.PhysicalPrice.ReadOnly = true;
         this.PhysicalPrice.Width = 125;
         // 
         // DigitalPrice
         // 
         this.DigitalPrice.DataPropertyName = "PriceDigital";
         this.DigitalPrice.HeaderText = "Digital Price";
         this.DigitalPrice.MinimumWidth = 6;
         this.DigitalPrice.Name = "DigitalPrice";
         this.DigitalPrice.ReadOnly = true;
         this.DigitalPrice.Width = 125;
         // 
         // UserScore
         // 
         this.UserScore.DataPropertyName = "Score";
         this.UserScore.HeaderText = "User Score";
         this.UserScore.MinimumWidth = 6;
         this.UserScore.Name = "UserScore";
         this.UserScore.ReadOnly = true;
         this.UserScore.Width = 125;
         // 
         // Language
         // 
         this.Language.DataPropertyName = "Language";
         this.Language.HeaderText = "Language";
         this.Language.MinimumWidth = 6;
         this.Language.Name = "Language";
         this.Language.ReadOnly = true;
         this.Language.Width = 125;
         // 
         // Category
         // 
         this.Category.DataPropertyName = "Category";
         this.Category.HeaderText = "Category";
         this.Category.MinimumWidth = 6;
         this.Category.Name = "Category";
         this.Category.ReadOnly = true;
         this.Category.Width = 125;
         // 
         // UserSearchBox
         // 
         this.UserSearchBox.Location = new System.Drawing.Point(64, 58);
         this.UserSearchBox.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.UserSearchBox.Name = "UserSearchBox";
         this.UserSearchBox.Size = new System.Drawing.Size(270, 22);
         this.UserSearchBox.TabIndex = 9;
         this.UserSearchBox.Text = "Enter book name";
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
         this.label1.Location = new System.Drawing.Point(51, 18);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(83, 32);
         this.label1.TabIndex = 8;
         this.label1.Text = "Books";
         // 
         // AddButton
         // 
         this.AddButton.BackColor = System.Drawing.Color.BurlyWood;
         this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.AddButton.FlatAppearance.BorderSize = 0;
         this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.AddButton.Image = global::WindowsFormsApp1.Properties.Resources.plus16x;
         this.AddButton.Location = new System.Drawing.Point(657, 53);
         this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.AddButton.Name = "AddButton";
         this.AddButton.Size = new System.Drawing.Size(37, 30);
         this.AddButton.TabIndex = 13;
         this.AddButton.UseVisualStyleBackColor = true;
         this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
         // 
         // SearchButton
         // 
         this.SearchButton.BackColor = System.Drawing.Color.BurlyWood;
         this.SearchButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.SearchButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.SearchButton.FlatAppearance.BorderSize = 0;
         this.SearchButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.SearchButton.Image = global::WindowsFormsApp1.Properties.Resources.search16x;
         this.SearchButton.Location = new System.Drawing.Point(340, 53);
         this.SearchButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.SearchButton.Name = "SearchButton";
         this.SearchButton.Size = new System.Drawing.Size(37, 30);
         this.SearchButton.TabIndex = 10;
         this.SearchButton.UseVisualStyleBackColor = true;
         this.SearchButton.Click += new System.EventHandler(this.SearchButton_Click);
         // 
         // BookList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.DeleteButton);
         this.Controls.Add(this.EditButton);
         this.Controls.Add(this.AddButton);
         this.Controls.Add(this.RefreshButton);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.SearchButton);
         this.Controls.Add(this.UserSearchBox);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "BookList";
         this.Size = new System.Drawing.Size(864, 411);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Button DeleteButton;
      private Button EditButton;
      private Button AddButton;
      private Button RefreshButton;
      private DataGridView dataGridView1;
      private DataGridViewTextBoxColumn BookID;
      private DataGridViewTextBoxColumn BookName;
      private DataGridViewTextBoxColumn Author;
      private DataGridViewTextBoxColumn Description;
      private DataGridViewTextBoxColumn PhysicalPrice;
      private DataGridViewTextBoxColumn DigitalPrice;
      private DataGridViewTextBoxColumn UserScore;
      private DataGridViewTextBoxColumn Language;
      private DataGridViewTextBoxColumn Category;
      private Button SearchButton;
      private TextBox UserSearchBox;
      private Label label1;
   }
}
