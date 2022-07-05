using Flurl.Http;
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

namespace WindowsFormsApp1.Forms.Transactions
{
   public partial class TransactionList : UserControl
   {
      List<TransactionResponse> data;
      public TransactionList() {
         InitializeComponent();
         LoadTransactionList();
      }

      private async void LoadTransactionList(string usernameSearch = "") {
         RefreshButton.Enabled = false;
         Cursor = System.Windows.Forms.Cursors.WaitCursor;

         string url;
         if (!string.IsNullOrWhiteSpace(usernameSearch))
         {
            data = await APIService.GetFromUrlWithAuth<List<TransactionResponse>>($"Transaction/Search?username={usernameSearch}");
         }
         else
         {
            data = await APIService.GetFromUrlWithAuth<List<TransactionResponse>>("Transaction");
         }

         var viewOrderButton = new DataGridViewButtonColumn();
         viewOrderButton.Name = "Action";
         viewOrderButton.Text = "View Order";
         viewOrderButton.UseColumnTextForButtonValue = true;
         if (dataGridView1.Columns["Action"] == null)
         {
            dataGridView1.Columns.Insert(7, viewOrderButton);
         }

         dataGridView1.AutoGenerateColumns = false;
         dataGridView1.ReadOnly = true;
         dataGridView1.DataSource = data;
         dataGridView1.CellClick += DataGridView1_CellClick1; ;

         RefreshButton.Enabled = true;
         Cursor = System.Windows.Forms.Cursors.Default;
      }

      private void DataGridView1_CellClick1(object sender, DataGridViewCellEventArgs e) {
         if (e.ColumnIndex == dataGridView1.Columns["Action"].Index)
         {
            DisplayOrder();
         }
      }

      async void DisplayOrder() {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["OrderID"].Value);
         var result = await APIService.GetFromUrlWithAuth<OrderResponse>($"Order/{ID}");
         var orderStatusForm = new OrderPreview(result);
         orderStatusForm.Show();
      }

      private void SearchButton_Click(object sender, EventArgs e) {
         LoadTransactionList(UserSearchBox.Text);
      }

      private void DeleteButton_Click(object sender, EventArgs e) {
         if (dataGridView1.CurrentRow == null)
         {
            MessageBox.Show("Please select a transaction");
            return;
         }
         RemoveTransaction();
      }
      public async void RemoveTransaction() {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["TransactionID"].Value);
         var result = await APIService.DeleteFromUrlWithAuth("Transaction", ID);

         if (result)
         {
            MessageBox.Show("Transaction removed");
            LoadTransactionList();
         }
      }

      private void RefreshButton_Click(object sender, EventArgs e) {
         LoadTransactionList();
      }
   }
}
