using knowledge_hub.Desktop.Forms;
using knowledge_hub.Models.Model.Responses;
using knowledge_hub.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using knowledge_hub.Forms.User;
using WindowsFormsApp1.Forms.Category;
using WindowsFormsApp1.Forms.Language;
using WindowsFormsApp1.Forms.Report;
using WindowsFormsApp1.Forms.Transactions;
using WindowsFormsApp1.Forms.Book;
using WindowsFormsApp1.Forms.City;

namespace WindowsFormsApp1
{
   public partial class AdminDashboard : Form
   {
      public AdminDashboard(UserDataResponse userData) {
         InitializeComponent();
         UserName.Text = userData.userData.Username;
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new UserList());
      }

      private void CloseAppButton_Click(object sender, EventArgs e) {
         Application.Exit();
      }

      private void MinimizeAppButton_Click(object sender, EventArgs e) {
         this.WindowState = FormWindowState.Minimized;
      }

      private void LogOutLink_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e) {
         PersistentData.userData = null;
         var login = new Login();
         login.Show();
         this.Hide();
      }

      private void CategoriesTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new CategoryList());
      }

      private void UsersTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new UserList());
      }

      private void LanguagesTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new LanguageList());
      }

      private void CitiesTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new CityList());
      }

      private void BooksTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new BookList());
      }

      private void TransactionsTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new TransactionList());
      }

      private void ReportsTabButton_Click(object sender, EventArgs e) {
         PanelHelper.ClearPanels(ContentPanel);
         PanelHelper.AddPanel(ContentPanel, new ReportList());
      }
   }
}
