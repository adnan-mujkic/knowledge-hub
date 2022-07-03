using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Report
{
   public partial class ReportList : UserControl
   {
      public ReportList() {
         InitializeComponent();
      }

      private void Top10BooksLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         var topBooksForm = new TopMostSoldBooks();
         topBooksForm.Show();
      }

      private void Top10UsersLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         var topUsersForm = new TopUsersWithMostPurchases();
         topUsersForm.Show();
      }

      private void BooksWithBestRatingLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         var topBooks = new TopBestBooks();
         topBooks.Show();
      }

      private void BooksWithWorstRatingsLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         var worstBooks = new TopWorstBooks();
         worstBooks.Show();
      }

      private void MostSoldBooksLabel_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         var mostSold = new MostSoldBooksInPeriod();
         mostSold.Show();
      }
   }
}
