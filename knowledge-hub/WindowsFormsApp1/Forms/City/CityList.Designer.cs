using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.City
{
   partial class CityList
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
         this.RefreshButton = new System.Windows.Forms.Button();
         this.dataGridView1 = new System.Windows.Forms.DataGridView();
         this.CityID = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.CityName = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Zipcode = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.Country = new System.Windows.Forms.DataGridViewTextBoxColumn();
         this.label1 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.DeleteButton = new System.Windows.Forms.Button();
         this.AddButton = new System.Windows.Forms.Button();
         this.EditButton = new System.Windows.Forms.Button();
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
         this.SuspendLayout();
         // 
         // RefreshButton
         // 
         this.RefreshButton.BackColor = System.Drawing.Color.BurlyWood;
         this.RefreshButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.RefreshButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.RefreshButton.FlatAppearance.BorderSize = 0;
         this.RefreshButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.RefreshButton.Location = new System.Drawing.Point(55, 334);
         this.RefreshButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.RefreshButton.Name = "RefreshButton";
         this.RefreshButton.Size = new System.Drawing.Size(132, 30);
         this.RefreshButton.TabIndex = 25;
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
            this.CityID,
            this.CityName,
            this.Zipcode,
            this.Country});
         this.dataGridView1.Location = new System.Drawing.Point(55, 66);
         this.dataGridView1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.dataGridView1.Name = "dataGridView1";
         this.dataGridView1.ReadOnly = true;
         this.dataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
         this.dataGridView1.RowTemplate.Height = 29;
         this.dataGridView1.Size = new System.Drawing.Size(741, 263);
         this.dataGridView1.TabIndex = 24;
         // 
         // CityID
         // 
         this.CityID.DataPropertyName = "CityID";
         this.CityID.HeaderText = "CityID";
         this.CityID.MinimumWidth = 6;
         this.CityID.Name = "CityID";
         this.CityID.ReadOnly = true;
         this.CityID.Visible = false;
         this.CityID.Width = 125;
         // 
         // CityName
         // 
         this.CityName.DataPropertyName = "Name";
         this.CityName.HeaderText = "City Name";
         this.CityName.MinimumWidth = 6;
         this.CityName.Name = "CityName";
         this.CityName.ReadOnly = true;
         this.CityName.Width = 180;
         // 
         // Zipcode
         // 
         this.Zipcode.DataPropertyName = "ZipCode";
         this.Zipcode.HeaderText = "Zipcode";
         this.Zipcode.MinimumWidth = 6;
         this.Zipcode.Name = "Zipcode";
         this.Zipcode.ReadOnly = true;
         this.Zipcode.Width = 125;
         // 
         // Country
         // 
         this.Country.DataPropertyName = "Country";
         this.Country.HeaderText = "Country";
         this.Country.MinimumWidth = 6;
         this.Country.Name = "Country";
         this.Country.ReadOnly = true;
         this.Country.Width = 250;
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
         this.label1.Location = new System.Drawing.Point(24, 13);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(76, 32);
         this.label1.TabIndex = 23;
         this.label1.Text = "Cities";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Segoe UI", 9F, System.Drawing.FontStyle.Bold);
         this.label2.ForeColor = System.Drawing.Color.Maroon;
         this.label2.Location = new System.Drawing.Point(55, 386);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(669, 20);
         this.label2.TabIndex = 28;
         this.label2.Text = "If there are user saved addresses or orders registered to a city, you will not be" +
    " able to delete it!";
         // 
         // DeleteButton
         // 
         this.DeleteButton.BackColor = System.Drawing.Color.BurlyWood;
         this.DeleteButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.DeleteButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.DeleteButton.FlatAppearance.BorderSize = 0;
         this.DeleteButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.DeleteButton.Image = global::WindowsFormsApp1.Properties.Resources.bin16x;
         this.DeleteButton.Location = new System.Drawing.Point(759, 30);
         this.DeleteButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.DeleteButton.Name = "DeleteButton";
         this.DeleteButton.Size = new System.Drawing.Size(37, 30);
         this.DeleteButton.TabIndex = 30;
         this.DeleteButton.UseVisualStyleBackColor = true;
         this.DeleteButton.Click += new System.EventHandler(this.DeleteButton_Click);
         // 
         // AddButton
         // 
         this.AddButton.BackColor = System.Drawing.Color.BurlyWood;
         this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.AddButton.FlatAppearance.BorderSize = 0;
         this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.AddButton.Image = global::WindowsFormsApp1.Properties.Resources.plus16x;
         this.AddButton.Location = new System.Drawing.Point(673, 30);
         this.AddButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.AddButton.Name = "AddButton";
         this.AddButton.Size = new System.Drawing.Size(37, 30);
         this.AddButton.TabIndex = 29;
         this.AddButton.UseVisualStyleBackColor = true;
         this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
         // 
         // EditButton
         // 
         this.EditButton.BackColor = System.Drawing.Color.BurlyWood;
         this.EditButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.EditButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.EditButton.FlatAppearance.BorderSize = 0;
         this.EditButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.EditButton.Image = global::WindowsFormsApp1.Properties.Resources.editing16x;
         this.EditButton.Location = new System.Drawing.Point(716, 30);
         this.EditButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.EditButton.Name = "EditButton";
         this.EditButton.Size = new System.Drawing.Size(37, 30);
         this.EditButton.TabIndex = 27;
         this.EditButton.UseVisualStyleBackColor = true;
         this.EditButton.Click += new System.EventHandler(this.EditButton_Click);
         // 
         // CityList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.DeleteButton);
         this.Controls.Add(this.AddButton);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.EditButton);
         this.Controls.Add(this.RefreshButton);
         this.Controls.Add(this.dataGridView1);
         this.Controls.Add(this.label1);
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "CityList";
         this.Size = new System.Drawing.Size(864, 411);
         ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion
      private Button EditButton;
      private Button RefreshButton;
      private DataGridView dataGridView1;
      private Label label1;
      private Label label2;
      private Button DeleteButton;
      private Button AddButton;
      private DataGridViewTextBoxColumn CityID;
      private DataGridViewTextBoxColumn CityName;
      private DataGridViewTextBoxColumn Zipcode;
      private DataGridViewTextBoxColumn Country;
   }
}
