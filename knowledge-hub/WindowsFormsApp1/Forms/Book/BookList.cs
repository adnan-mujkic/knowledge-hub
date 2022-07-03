using Flurl.Http;
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

namespace WindowsFormsApp1.Forms.Book
{
   public partial class BookList : UserControl
   {
      public BookList() {
         InitializeComponent();
         LoadBookList();
      }

      private async void LoadBookList(string search = "") {
         RefreshButton.Enabled = false;
         Cursor = System.Windows.Forms.Cursors.WaitCursor;

         string url;
         List<BookResponse> response;
         if (!string.IsNullOrWhiteSpace(search))
         {
            url = $"{Properties.Settings.Default.ApiUrl}/Book/Search?search={UserSearchBox.Text}";
            response = await url.GetJsonAsync<List<BookResponse>>();
         }
         else
         {
            url = $"{Properties.Settings.Default.ApiUrl}/Book/";
            response = await url.GetJsonAsync<List<BookResponse>>();
         }

         dataGridView1.AutoGenerateColumns = false;
         dataGridView1.ReadOnly = true;
         dataGridView1.DataSource = response;

         RefreshButton.Enabled = true;
         Cursor = System.Windows.Forms.Cursors.Default;
      }

      private void SearchButton_Click(object sender, EventArgs e) {
         LoadBookList(UserSearchBox.Text);
      }

      private void AddButton_Click(object sender, EventArgs e) {
         PanelHelper.SwapPanel(this.Parent, this, new BookAdd());
      }

      private async void EditButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BookID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/Book/{ID}";

         var response = await url.GetJsonAsync<BookResponse>();
         if (response == null)
         {
            MessageBox.Show("Book getting error");
            return;
         }

         PanelHelper.SwapPanel(this.Parent, this, new BookEdit(response));
      }

      private void DeleteButton_Click(object sender, EventArgs e) {
         if (dataGridView1.CurrentRow == null)
         {
            MessageBox.Show("Please select a book");
            return;
         }
         RemoveBook();
      }
      private async void RemoveBook() {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["BookID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/Book?ID={ID}";
         var result = await url.DeleteAsync();

         if (result.StatusCode == 200)
         {
            MessageBox.Show("Book removed");
            LoadBookList();
         }
      }

      private void RefreshButton_Click(object sender, EventArgs e) {
         LoadBookList();
      }
   }
}
