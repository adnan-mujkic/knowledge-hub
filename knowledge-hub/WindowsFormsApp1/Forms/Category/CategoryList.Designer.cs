using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Category
{
   partial class CategoryList
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
         this.EditButton = new System.Windows.Forms.Button();
         this.AddButton = new System.Windows.Forms.Button();
         this.RefreshButton = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.CategoryID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CategoryName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.label1 = new System.Windows.Forms.Label();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.label2 = new System.Windows.Forms.Label();
         this.label3 = new System.Windows.Forms.Label();
         this.DeleteButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // EditButton
         // 
         this.EditButton.BackColor = System.Drawing.Color.BurlyWood;
         this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.EditButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.EditButton.FlatAppearance.BorderSize = 0;
         this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.EditButton.Image = global::WindowsFormsApp1.Properties.Resources.editing16x;
         this.EditButton.Location = new System.Drawing.Point(351, 333);
         this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.EditButton.Name = "EditButton";
         this.EditButton.Size = new System.Drawing.Size(37, 30);
         this.EditButton.TabIndex = 12;
         this.EditButton.UseVisualStyleBackColor = true;
         this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
         // 
         // AddButton
         // 
         this.AddButton.BackColor = System.Drawing.Color.BurlyWood;
         this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.AddButton.FlatAppearance.BorderSize = 0;
         this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.AddButton.Location = new System.Drawing.Point(620, 229);
         this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.AddButton.Name = "AddButton";
         this.AddButton.Size = new System.Drawing.Size(77, 30);
         this.AddButton.TabIndex = 11;
         this.AddButton.Text = "Add";
         this.AddButton.UseVisualStyleBackColor = true;
         this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
         // 
         // RefreshButton
         // 
         this.RefreshButton.BackColor = System.Drawing.Color.BurlyWood;
         this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.RefreshButton.FlatAppearance.BorderSize = 0;
         this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.RefreshButton.Location = new System.Drawing.Point(50, 333);
         this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.RefreshButton.Name = "RefreshButton";
         this.RefreshButton.Size = new System.Drawing.Size(132, 30);
         this.RefreshButton.TabIndex = 10;
         this.RefreshButton.Text = "Refresh";
         this.RefreshButton.UseVisualStyleBackColor = true;
         this.RefreshButton.Click += new System.EventHandler(this.RefreshButton_Click);
         // 
         // dataGridView1
         // 
         this.dataGridView1.AllowUserToAddRows = false;
         this.dataGridView1.AllowUserToDeleteRows = false;
         this.dataGridView1.BackgroundColor = System.Drawing.Color.White;
         this.dataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.Single;
         this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
         this.dataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.CategoryID,
            this.CategoryName});
         this.dataGridView1.Location = new System.Drawing.Point(50, 65);
         this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         this.dataGridView1.RowTemplate.Height = 29;
         this.dataGridView1.Size = new System.Drawing.Size(381, 263);
         this.dataGridView1.TabIndex = 9;
         // 
         // CategoryID
         // 
         this.CategoryID.DataPropertyName = "CategoryID";
         this.CategoryID.HeaderText = "CategoryID";
         this.CategoryID.MinimumWidth = 6;
         this.CategoryID.Name = "CategoryID";
         this.CategoryID.ReadOnly = true;
         this.CategoryID.Visible = false;
         this.CategoryID.Width = 125;
         // 
         // CategoryName
         // 
         this.CategoryName.DataPropertyName = "Name";
         this.CategoryName.HeaderText = "Category Name";
         this.CategoryName.MinimumWidth = 6;
         this.CategoryName.Name = "CategoryName";
         this.CategoryName.ReadOnly = true;
         this.CategoryName.Width = 300;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
         this.label1.Location = new System.Drawing.Point(50, 21);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(135, 32);
         this.label1.TabIndex = 8;
         this.label1.Text = "Categories";
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(562, 195);
         this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(189, 22);
         this.textBox1.TabIndex = 14;
         this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Location = new System.Drawing.Point(592, 168);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(115, 16);
         this.label2.TabIndex = 15;
         this.label2.Text = "Add new category";
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.label3.ForeColor = System.Drawing.Color.Maroon;
         this.label3.Location = new System.Drawing.Point(50, 384);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(625, 20);
         this.label3.TabIndex = 29;
         this.label3.Text = "If there are books registered with the selected category, you will not be able to" +
    " delete it!";
         // 
         // DeleteButton
         // 
         this.DeleteButton.BackColor = System.Drawing.Color.BurlyWood;
         this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.DeleteButton.FlatAppearance.BorderSize = 0;
         this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.DeleteButton.Image = global::WindowsFormsApp1.Properties.Resources.bin16x;
         this.DeleteButton.Location = new System.Drawing.Point(394, 333);
         this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.DeleteButton.Name = "DeleteButton";
         this.DeleteButton.Size = new System.Drawing.Size(37, 30);
         this.DeleteButton.TabIndex = 31;
         this.DeleteButton.UseVisualStyleBackColor = true;
         this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
         // 
         // CategoryList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.DeleteButton);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.EditButton);
         this.Controls.Add(this.AddButton);
         this.Controls.Add(this.RefreshButton);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "CategoryList";
         this.Size = new System.Drawing.Size(864, 411);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private Button EditButton;
      private Button AddButton;
      private Button RefreshButton;
      private DataGridView dataGridView1;
      private Label label1;
      private TextBox textBox1;
      private Label label2;
      private DataGridViewTextBoxColumn CategoryID;
      private DataGridViewTextBoxColumn CategoryName;
      private Label label3;
      private Button DeleteButton;
   }
}
