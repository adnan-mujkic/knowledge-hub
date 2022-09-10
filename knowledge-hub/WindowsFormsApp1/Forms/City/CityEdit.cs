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
   public partial class CityEdit : UserControl
   {
      List<string> errorMessages;
      CityResponse data;

      public CityEdit(CityResponse _data) {
         InitializeComponent();

         data = _data;
         errorMessages = new List<string>();
         CityNameInput.Text = data.Name;
         CityZipInput.Text = data.ZipCode;
         CityCountryInput.Text = data.Country;
      }

      private void cancelButton_Click(object sender, EventArgs e) {
         PanelHelper.SwapPanel(this.Parent, this, new CityList());
      }

      private void CityZipInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Zipcode must be numbers only");
         if (!IsDigitsOnly(CityZipInput.Text))
         {
            errorMessages.Add("Zipcode must be numbers only");
            e.Cancel = false;
            return;
         }
      }
      bool IsDigitsOnly(string str) {
         foreach (char c in str)
         {
            if (c < '0' || c > '9')
               return false;
         }

         return true;
      }

      private async void SaveButton_Click(object sender, EventArgs e) {
         ValidateChildren();
         if (errorMessages.Count > 0)
         {
            string finalErrors = "";
            foreach (var errMsg in errorMessages)
            {
               finalErrors += errMsg + "\n";
            }
            MessageBox.Show(finalErrors);
            return;
         }

         data.Name = CityNameInput.Text;
         data.ZipCode = CityZipInput.Text;
         data.Country = CityCountryInput.Text;
         var response = await APIService.PutFromUrlWithAuth<CityResponse>($"City?ID={data.CityId}", data);

         if (response == null || response.CityId == 0)
         {
            MessageBox.Show("Error updating city");
            PanelHelper.SwapPanel(this.Parent, this, new CityList());
            return;
         }

         MessageBox.Show("City sucessfully updated");
         PanelHelper.SwapPanel(this.Parent, this, new CityList());
      }

      private void CityNameInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("City name cannot be empty");
         if (!string.IsNullOrWhiteSpace(CityNameInput.Text))
         {
            errorMessages.Add("City name cannot be empty");
            e.Cancel = false;
            return;
         }
      }

      private void CityCountryInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Country name cannot be empty");
         if (!string.IsNullOrWhiteSpace(CityCountryInput.Text))
         {
            errorMessages.Add("Country name cannot be empty");
            e.Cancel = false;
            return;
         }
      }
   }
}
