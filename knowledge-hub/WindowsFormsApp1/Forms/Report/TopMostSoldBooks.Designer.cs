namespace WindowsFormsApp1.Forms.Report
{
   partial class TopMostSoldBooks
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
         this.button1 = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.BookId = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.BookName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Sold = new System.Windows.Forms.DataGridViewTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(316, 660);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(95, 38);
         this.button1.TabIndex = 5;
         this.button1.Text = "Back";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.BookId,
            this.BookName,
            this.Sold});
         this.dataGridView1.Location = new System.Drawing.Point(12, 12);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidth = 51;
         this.dataGridView1.RowTemplate.Height = 24;
         this.dataGridView1.Size = new System.Drawing.Size(711, 623);
         this.dataGridView1.TabIndex = 6;
         // 
         // BookId
         // 
         this.BookId.DataPropertyName = "BookId";
         this.BookId.HeaderText = "BookId";
         this.BookId.MinimumWidth = 6;
         this.BookId.Name = "BookId";
         this.BookId.ReadOnly = true;
         this.BookId.Visible = false;
         this.BookId.Width = 125;
         // 
         // BookName
         // 
         this.BookName.DataPropertyName = "BookName";
         this.BookName.HeaderText = "Book Name";
         this.BookName.MinimumWidth = 6;
         this.BookName.Name = "BookName";
         this.BookName.ReadOnly = true;
         this.BookName.Width = 300;
         // 
         // Sold
         // 
         this.Sold.DataPropertyName = "Sold";
         this.Sold.HeaderText = "Sold";
         this.Sold.MinimumWidth = 6;
         this.Sold.Name = "Sold";
         this.Sold.ReadOnly = true;
         this.Sold.Width = 125;
         // 
         // TopMostSoldBooks
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Gainsboro;
         this.ClientSize = new System.Drawing.Size(735, 710);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.button1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "TopMostSoldBooks";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "TopMostSoldBooks";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.DataGridViewTextBoxColumn BookId;
      private System.Windows.Forms.DataGridViewTextBoxColumn BookName;
      private System.Windows.Forms.DataGridViewTextBoxColumn Sold;
   }
}