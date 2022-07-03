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

namespace WindowsFormsApp1.Forms.Language
{
   public partial class LanguageList : UserControl
   {
      SingleTextInputForm inputPanel;

      public LanguageList() {
         InitializeComponent();
         FetchLanguageList();
      }

      private async void FetchLanguageList() {
         RefreshButton.Enabled = false;
         Cursor = Cursors.WaitCursor;

         var url = $"{Properties.Settings.Default.ApiUrl}/Language";
         var response = await url.GetJsonAsync<List<LanguageResponse>>();
         dataGridView1.AutoGenerateColumns = false;
         dataGridView1.ReadOnly = true;
         dataGridView1.DataSource = response;

         RefreshButton.Enabled = true;
         Cursor = Cursors.Default;
      }

      private void RefreshButton_Click(object sender, EventArgs e) {
         FetchLanguageList();
      }

      private void EditButton_Click(object sender, EventArgs e) {
         inputPanel = new SingleTextInputForm("Enter new language name", dataGridView1.CurrentRow.Cells["LanguageName"].Value.ToString());
         inputPanel.inputSubmitDelegate += UpdateName;
         inputPanel.ShowDialog();
      }

      public async void UpdateName(string value) {
         if (string.IsNullOrWhiteSpace(value) ||
            dataGridView1.CurrentRow.Cells["LanguageName"].Value.ToString() == value)
         {
            inputPanel.inputSubmitDelegate -= UpdateName;
            return;
         }

         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LanguageID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/Language?ID={ID}";
         var data = new LanguageInsertRequest { Name = value };
         var response = await url.PutJsonAsync(data).ReceiveJson<LanguageResponse>();
         FetchLanguageList();
         inputPanel.inputSubmitDelegate -= UpdateName;
         MessageBox.Show("Language name changed");
      }

      private async void AddButton_Click(object sender, EventArgs e) {
         var url = $"{Properties.Settings.Default.ApiUrl}/Language";
         var data = new LanguageInsertRequest { Name = textBox1.Text };
         await url.PostJsonAsync(data).ReceiveJson<LanguageResponse>();
         FetchLanguageList();
         textBox1.Text = "";
         MessageBox.Show("Language added");
      }

      private async void DeleteButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LanguageID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/Language?ID={ID}";
         var response = await url.DeleteAsync().ReceiveJson<bool>();
         FetchLanguageList();
         MessageBox.Show(response ? "Language deleted" : "Language cannot be deleted!");
      }
   }
}
