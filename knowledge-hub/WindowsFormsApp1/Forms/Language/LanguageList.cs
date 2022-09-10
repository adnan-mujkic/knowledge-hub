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
      List<string> errorMessages;


      public LanguageList() {
         InitializeComponent();
         FetchLanguageList();
         errorMessages = new List<string>();
      }

      private async void FetchLanguageList() {
         RefreshButton.Enabled = false;
         Cursor = Cursors.WaitCursor;

         var response = await APIService.GetFromUrlWithAuth<List<LanguageResponse>>("Language");
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
         var data = new LanguageInsertRequest { Name = value };
         var response = await APIService.PutFromUrlWithAuth<LanguageResponse>($"Language?ID={ID}", data);
         FetchLanguageList();
         inputPanel.inputSubmitDelegate -= UpdateName;
         MessageBox.Show("Language name changed");
      }

      private async void AddButton_Click(object sender, EventArgs e) {
         var data = new LanguageInsertRequest { Name = textBox1.Text };
         await APIService.PostFromUrlWithAuth<LanguageResponse>("Language", data);
         FetchLanguageList();
         textBox1.Text = "";
         MessageBox.Show("Language added");
      }

      private async void DeleteButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["LanguageID"].Value);
         var response = await APIService.DeleteFromUrlWithAuth("Language", ID);
         FetchLanguageList();
         MessageBox.Show(response ? "Language deleted" : "Language cannot be deleted!");
      }

      private void textBox1_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Language name cannot be empty!");
         if (string.IsNullOrWhiteSpace(textBox1.Text))
         {
            errorMessages.Add("Language name cannot be empty!");
            e.Cancel = false;
            return;
         }
      }
   }
}
