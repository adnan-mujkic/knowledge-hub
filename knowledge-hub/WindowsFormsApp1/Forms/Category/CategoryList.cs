using Flurl.Http;
using knowledge_hub.Models.Model.Requests;
using knowledge_hub.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Category
{
   public partial class CategoryList : UserControl
   {
      SingleTextInputForm inputPanel;

      public CategoryList() {
         InitializeComponent();
         FetchCategoryList();
      }

      private async void FetchCategoryList() {
         RefreshButton.Enabled = false;
         Cursor = System.Windows.Forms.Cursors.WaitCursor;

         var url = $"{Properties.Settings.Default.ApiUrl}/Category";
         var response = await url.GetJsonAsync<List<CategoryResponse>>();
         dataGridView1.AutoGenerateColumns = false;
         dataGridView1.ReadOnly = true;
         dataGridView1.DataSource = response;

         RefreshButton.Enabled = true;
         Cursor = System.Windows.Forms.Cursors.Default;
      }

      private void RefreshButton_Click(object sender, EventArgs e) {
         FetchCategoryList();
      }

      private void EditButton_Click(object sender, EventArgs e) {
         inputPanel = new SingleTextInputForm("Enter new category name", dataGridView1.CurrentRow.Cells["CategoryName"].Value.ToString());
         inputPanel.inputSubmitDelegate += UpdateName;
         inputPanel.ShowDialog();
      }

      public async void UpdateName(string value) {
         if (string.IsNullOrWhiteSpace(value) ||
            dataGridView1.CurrentRow.Cells["CategoryName"].Value.ToString() == value)
         {
            inputPanel.inputSubmitDelegate -= UpdateName;
            return;
         }

         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/Category?ID={ID}";
         var data = new CategoryInsertRequest { Name = value };
         var response = await url.PutJsonAsync(data).ReceiveJson<CategoryResponse>();
         FetchCategoryList();
         inputPanel.inputSubmitDelegate -= UpdateName;
         MessageBox.Show("Category name changed");
      }

      private async void AddButton_Click(object sender, EventArgs e) {
         var url = $"{Properties.Settings.Default.ApiUrl}/Category";
         var data = new CategoryInsertRequest { Name = textBox1.Text };
         await url.PostJsonAsync(data).ReceiveJson<CategoryResponse>();
         FetchCategoryList();
         textBox1.Text = "";
         MessageBox.Show("Category added");
      }

      private async void DeleteButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CategoryID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/Category?ID={ID}";
         var response = await url.DeleteAsync().ReceiveJson<bool>();
         FetchCategoryList();
         MessageBox.Show(response ? "Category deleted" : "Error deleting category");
      }
   }
}
