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

namespace WindowsFormsApp1.Forms.City
{
   public partial class CityList : UserControl
   {
      public CityList() {
         InitializeComponent();
         FetchCityList();
      }

      private async void FetchCityList() {
         RefreshButton.Enabled = false;
         Cursor = Cursors.WaitCursor;

         var url = $"{Properties.Settings.Default.ApiUrl}/City";
         var response = await url.GetJsonAsync<List<CityResponse>>();
         dataGridView1.AutoGenerateColumns = false;
         dataGridView1.ReadOnly = true;
         dataGridView1.DataSource = response;

         RefreshButton.Enabled = true;
         Cursor = Cursors.Default;
      }

      private void AddButton_Click(object sender, EventArgs e) {
         PanelHelper.SwapPanel(this.Parent, this, new CityAdd());
      }

      private async void EditButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CityID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/City/{ID}";

         var response = await url.GetJsonAsync<CityResponse>();
         if (response == null)
         {
            MessageBox.Show("User getting error");
            return;
         }

         PanelHelper.SwapPanel(this.Parent, this, new CityEdit(response));
      }

      private async void DeleteButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["CityID"].Value);
         var url = $"{Properties.Settings.Default.ApiUrl}/City?ID={ID}";
         var response = await url.DeleteAsync().ReceiveJson<bool>();
         FetchCityList();
         MessageBox.Show(response ? "City deleted" : "City cannot be deleted!");
      }

      private void RefreshButton_Click(object sender, EventArgs e) {
         FetchCityList();
      }
   }
}
