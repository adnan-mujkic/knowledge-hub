using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Report
{
   partial class ReportList
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
         this.Top10UsersLabel = new System.Windows.Forms.LinkLabel();
         this.Top10BooksLabel = new System.Windows.Forms.LinkLabel();
         this.BooksWithBestRatingLabel = new System.Windows.Forms.LinkLabel();
         this.BooksWithWorstRatingsLabel = new System.Windows.Forms.LinkLabel();
         this.MostSoldBooksLabel = new System.Windows.Forms.LinkLabel();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoSize = true;
         this.label1.Font = new System.Drawing.Font("Segoe UI", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.label1.Location = new System.Drawing.Point(45, 35);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(114, 35);
         this.label1.TabIndex = 0;
         this.label1.Text = "Reports:";
         // 
         // Top10UsersLabel
         // 
         this.Top10UsersLabel.AutoSize = true;
         this.Top10UsersLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.Top10UsersLabel.Location = new System.Drawing.Point(53, 104);
         this.Top10UsersLabel.Name = "Top10UsersLabel";
         this.Top10UsersLabel.Size = new System.Drawing.Size(302, 28);
         this.Top10UsersLabel.TabIndex = 1;
         this.Top10UsersLabel.TabStop = true;
         this.Top10UsersLabel.Text = "Top 10 users with most purchases";
         this.Top10UsersLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Top10UsersLabel_LinkClicked);
         // 
         // Top10BooksLabel
         // 
         this.Top10BooksLabel.AutoSize = true;
         this.Top10BooksLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.Top10BooksLabel.Location = new System.Drawing.Point(53, 159);
         this.Top10BooksLabel.Name = "Top10BooksLabel";
         this.Top10BooksLabel.Size = new System.Drawing.Size(221, 28);
         this.Top10BooksLabel.TabIndex = 2;
         this.Top10BooksLabel.TabStop = true;
         this.Top10BooksLabel.Text = "Top 10 most sold books";
         this.Top10BooksLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.Top10BooksLabel_LinkClicked);
         // 
         // BooksWithBestRatingLabel
         // 
         this.BooksWithBestRatingLabel.AutoSize = true;
         this.BooksWithBestRatingLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.BooksWithBestRatingLabel.Location = new System.Drawing.Point(53, 210);
         this.BooksWithBestRatingLabel.Name = "BooksWithBestRatingLabel";
         this.BooksWithBestRatingLabel.Size = new System.Drawing.Size(268, 28);
         this.BooksWithBestRatingLabel.TabIndex = 3;
         this.BooksWithBestRatingLabel.TabStop = true;
         this.BooksWithBestRatingLabel.Text = "Top 5 books with best ratings";
         this.BooksWithBestRatingLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BooksWithBestRatingLabel_LinkClicked);
         // 
         // BooksWithWorstRatingsLabel
         // 
         this.BooksWithWorstRatingsLabel.AutoSize = true;
         this.BooksWithWorstRatingsLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.BooksWithWorstRatingsLabel.Location = new System.Drawing.Point(53, 262);
         this.BooksWithWorstRatingsLabel.Name = "BooksWithWorstRatingsLabel";
         this.BooksWithWorstRatingsLabel.Size = new System.Drawing.Size(279, 28);
         this.BooksWithWorstRatingsLabel.TabIndex = 4;
         this.BooksWithWorstRatingsLabel.TabStop = true;
         this.BooksWithWorstRatingsLabel.Text = "Top 5 books with worst ratings";
         this.BooksWithWorstRatingsLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.BooksWithWorstRatingsLabel_LinkClicked);
         // 
         // MostSoldBooksLabel
         // 
         this.MostSoldBooksLabel.AutoSize = true;
         this.MostSoldBooksLabel.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
         this.MostSoldBooksLabel.Location = new System.Drawing.Point(53, 320);
         this.MostSoldBooksLabel.Name = "MostSoldBooksLabel";
         this.MostSoldBooksLabel.Size = new System.Drawing.Size(310, 28);
         this.MostSoldBooksLabel.TabIndex = 5;
         this.MostSoldBooksLabel.TabStop = true;
         this.MostSoldBooksLabel.Text = "Most sold books in the last month";
         this.MostSoldBooksLabel.LinkClicked += new System.Windows.Forms.LinkLabelLinkClickedEventHandler(this.MostSoldBooksLabel_LinkClicked);
         // 
         // ReportList
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.MostSoldBooksLabel);
         this.Controls.Add(this.BooksWithWorstRatingsLabel);
         this.Controls.Add(this.BooksWithBestRatingLabel);
         this.Controls.Add(this.Top10BooksLabel);
         this.Controls.Add(this.Top10UsersLabel);
         this.Controls.Add(this.label1);
         this.Name = "ReportList";
         this.Size = new System.Drawing.Size(864, 514);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private LinkLabel Top10UsersLabel;
      private LinkLabel Top10BooksLabel;
      private LinkLabel BooksWithBestRatingLabel;
      private LinkLabel BooksWithWorstRatingsLabel;
      private LinkLabel MostSoldBooksLabel;
   }
}
