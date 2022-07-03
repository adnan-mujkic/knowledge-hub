using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Transactions
{
   partial class OrderPreview
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
         this.OrderNumberLabel = new System.Windows.Forms.Label();
         this.UserFullnameLabel = new System.Windows.Forms.Label();
         this.BookNameLabel = new System.Windows.Forms.Label();
         this.OrderDateLabel = new System.Windows.Forms.Label();
         this.ShippingDateLabel = new System.Windows.Forms.Label();
         this.OrderStatusLabel = new System.Windows.Forms.Label();
         this.CommentLabel = new System.Windows.Forms.Label();
         this.AddressLabel = new System.Windows.Forms.Label();
         this.CityLabel = new System.Windows.Forms.Label();
         this.button1 = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // OrderNumberLabel
         // 
         this.OrderNumberLabel.AutoSize = true;
         this.OrderNumberLabel.Location = new System.Drawing.Point(40, 40);
         this.OrderNumberLabel.Name = "OrderNumberLabel";
         this.OrderNumberLabel.Size = new System.Drawing.Size(105, 20);
         this.OrderNumberLabel.TabIndex = 0;
         this.OrderNumberLabel.Text = "Order number:";
         // 
         // UserFullnameLabel
         // 
         this.UserFullnameLabel.AutoSize = true;
         this.UserFullnameLabel.Location = new System.Drawing.Point(40, 80);
         this.UserFullnameLabel.Name = "UserFullnameLabel";
         this.UserFullnameLabel.Size = new System.Drawing.Size(105, 20);
         this.UserFullnameLabel.TabIndex = 1;
         this.UserFullnameLabel.Text = "Order number:";
         // 
         // BookNameLabel
         // 
         this.BookNameLabel.AutoEllipsis = true;
         this.BookNameLabel.AutoSize = true;
         this.BookNameLabel.Location = new System.Drawing.Point(40, 120);
         this.BookNameLabel.MaximumSize = new System.Drawing.Size(440, 50);
         this.BookNameLabel.Name = "BookNameLabel";
         this.BookNameLabel.Size = new System.Drawing.Size(433, 50);
         this.BookNameLabel.TabIndex = 2;
         this.BookNameLabel.Text = "Order number: aaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaaa" +
    "aaaaaaa";
         // 
         // OrderDateLabel
         // 
         this.OrderDateLabel.AutoSize = true;
         this.OrderDateLabel.Location = new System.Drawing.Point(40, 179);
         this.OrderDateLabel.Name = "OrderDateLabel";
         this.OrderDateLabel.Size = new System.Drawing.Size(105, 20);
         this.OrderDateLabel.TabIndex = 3;
         this.OrderDateLabel.Text = "Order number:";
         // 
         // ShippingDateLabel
         // 
         this.ShippingDateLabel.AutoSize = true;
         this.ShippingDateLabel.Location = new System.Drawing.Point(40, 219);
         this.ShippingDateLabel.Name = "ShippingDateLabel";
         this.ShippingDateLabel.Size = new System.Drawing.Size(105, 20);
         this.ShippingDateLabel.TabIndex = 4;
         this.ShippingDateLabel.Text = "Order number:";
         // 
         // OrderStatusLabel
         // 
         this.OrderStatusLabel.AutoSize = true;
         this.OrderStatusLabel.Location = new System.Drawing.Point(40, 259);
         this.OrderStatusLabel.Name = "OrderStatusLabel";
         this.OrderStatusLabel.Size = new System.Drawing.Size(105, 20);
         this.OrderStatusLabel.TabIndex = 5;
         this.OrderStatusLabel.Text = "Order number:";
         // 
         // CommentLabel
         // 
         this.CommentLabel.AutoSize = true;
         this.CommentLabel.Location = new System.Drawing.Point(40, 299);
         this.CommentLabel.MaximumSize = new System.Drawing.Size(440, 50);
         this.CommentLabel.Name = "CommentLabel";
         this.CommentLabel.Size = new System.Drawing.Size(105, 20);
         this.CommentLabel.TabIndex = 6;
         this.CommentLabel.Text = "Order number:";
         // 
         // AddressLabel
         // 
         this.AddressLabel.AutoSize = true;
         this.AddressLabel.Location = new System.Drawing.Point(40, 350);
         this.AddressLabel.Name = "AddressLabel";
         this.AddressLabel.Size = new System.Drawing.Size(105, 20);
         this.AddressLabel.TabIndex = 7;
         this.AddressLabel.Text = "Order number:";
         // 
         // CityLabel
         // 
         this.CityLabel.AutoSize = true;
         this.CityLabel.Location = new System.Drawing.Point(40, 390);
         this.CityLabel.Name = "CityLabel";
         this.CityLabel.Size = new System.Drawing.Size(105, 20);
         this.CityLabel.TabIndex = 8;
         this.CityLabel.Text = "Order number:";
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(189, 446);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(94, 29);
         this.button1.TabIndex = 9;
         this.button1.Text = "Back";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // OrderPreview
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.Silver;
         this.ClientSize = new System.Drawing.Size(493, 513);
         this.Controls.Add(this.button1);
         this.Controls.Add(this.CityLabel);
         this.Controls.Add(this.AddressLabel);
         this.Controls.Add(this.CommentLabel);
         this.Controls.Add(this.OrderStatusLabel);
         this.Controls.Add(this.ShippingDateLabel);
         this.Controls.Add(this.OrderDateLabel);
         this.Controls.Add(this.BookNameLabel);
         this.Controls.Add(this.UserFullnameLabel);
         this.Controls.Add(this.OrderNumberLabel);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "OrderPreview";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "OrderPreview";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label OrderNumberLabel;
      private Label UserFullnameLabel;
      private Label BookNameLabel;
      private Label OrderDateLabel;
      private Label ShippingDateLabel;
      private Label OrderStatusLabel;
      private Label CommentLabel;
      private Label AddressLabel;
      private Label CityLabel;
      private Button button1;
   }
}