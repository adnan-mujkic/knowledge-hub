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
         this.components = new System.ComponentModel.Container();
         Microsoft.Reporting.WinForms.ReportDataSource reportDataSource1 = new Microsoft.Reporting.WinForms.ReportDataSource();
         this.bindingSource1 = new System.Windows.Forms.BindingSource(this.components);
         this.button1 = new System.Windows.Forms.Button();
         this.reportViewer1 = new Microsoft.Reporting.WinForms.ReportViewer();
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).BeginInit();
         this.SuspendLayout();
         // 
         // button1
         // 
         this.button1.BackColor = System.Drawing.Color.BurlyWood;
         this.button1.FlatAppearance.BorderSize = 0;
         this.button1.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.button1.Location = new System.Drawing.Point(626, 729);
         this.button1.Name = "button1";
         this.button1.Size = new System.Drawing.Size(95, 38);
         this.button1.TabIndex = 5;
         this.button1.Text = "Back";
         this.button1.UseVisualStyleBackColor = false;
         this.button1.Click += new System.EventHandler(this.button1_Click);
         // 
         // reportViewer1
         // 
         reportDataSource1.Name = "MostSoldBooksDataset";
         reportDataSource1.Value = this.bindingSource1;
         this.reportViewer1.LocalReport.DataSources.Add(reportDataSource1);
         this.reportViewer1.LocalReport.ReportEmbeddedResource = "WindowsFormsApp1.Forms.Report.Data.MostSoldBooks.rdlc";
         this.reportViewer1.Location = new System.Drawing.Point(12, 12);
         this.reportViewer1.Name = "reportViewer1";
         this.reportViewer1.ServerReport.BearerToken = null;
         this.reportViewer1.Size = new System.Drawing.Size(1326, 701);
         this.reportViewer1.TabIndex = 6;
         // 
         // TopMostSoldBooks
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.BackColor = System.Drawing.Color.White;
         this.ClientSize = new System.Drawing.Size(1350, 779);
         this.Controls.Add(this.reportViewer1);
         this.Controls.Add(this.button1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
         this.Name = "TopMostSoldBooks";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "TopMostSoldBooks";
         this.Load += new System.EventHandler(this.TopMostSoldBooks_Load);
         ((System.ComponentModel.ISupportInitialize)(this.bindingSource1)).EndInit();
         this.ResumeLayout(false);

      }

      #endregion

      private System.Windows.Forms.Button button1;
      private Microsoft.Reporting.WinForms.ReportViewer reportViewer1;
      private System.Windows.Forms.BindingSource bindingSource1;
   }
}