namespace WindowsFormsApp1.Forms.Report
{
   partial class TopUsersWithMostPurchases
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
         this.UserId = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Username = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Purchases = new System.Windows.Forms.DataGridViewTextBoxColumn();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(331, 654);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(95, 38);
         this.button1.TabIndex = 3;
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
            this.UserId,
            this.Username,
            this.Purchases});
         this.dataGridView1.Location = new System.Drawing.Point(12, 12);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidth = 51;
         this.dataGridView1.RowTemplate.Height = 24;
         this.dataGridView1.Size = new System.Drawing.Size(729, 623);
         this.dataGridView1.TabIndex = 2;
         // 
         // UserId
         // 
         this.UserId.DataPropertyName = "UserId";
         this.UserId.HeaderText = "UserId";
         this.UserId.MinimumWidth = 6;
         this.UserId.Name = "UserId";
         this.UserId.ReadOnly = true;
         this.UserId.Visible = false;
         this.UserId.Width = 125;
         // 
         // Username
         // 
         this.Username.DataPropertyName = "Username";
         this.Username.HeaderText = "Username";
         this.Username.MinimumWidth = 6;
         this.Username.Name = "Username";
         this.Username.ReadOnly = true;
         this.Username.Width = 300;
         // 
         // Purchases
         // 
         this.Purchases.DataPropertyName = "Purchases";
         this.Purchases.HeaderText = "Purchases";
         this.Purchases.MinimumWidth = 6;
         this.Purchases.Name = "Purchases";
         this.Purchases.ReadOnly = true;
         this.Purchases.Width = 125;
         // 
         // TopUsersWithMostPurchases
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(753, 704);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.dataGridView1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "TopUsersWithMostPurchases";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "TopUsersWithMostPurchases";
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private System.Windows.Forms.DataGridView dataGridView1;
      private System.Windows.Forms.DataGridViewTextBoxColumn UserId;
      private System.Windows.Forms.DataGridViewTextBoxColumn Username;
      private System.Windows.Forms.DataGridViewTextBoxColumn Purchases;
   }
}