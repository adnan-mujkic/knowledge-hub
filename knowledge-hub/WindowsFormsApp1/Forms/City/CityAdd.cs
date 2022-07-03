﻿using Flurl.Http;
using knowledge_hub.Models.Model.Requests;
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
   public partial class CityAdd : UserControl
   {
      List<string> errorMessages;

      public CityAdd() {
         InitializeComponent();
         errorMessages = new List<string>();
      }

      private void AddButton_Click(object sender, EventArgs e) {
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
         AddCity();
      }

      public async void AddCity() {
         var cityAddRequest = new CityInsertRequest
         {
            Name = CityNameInput.Text,
            ZipCode = CityZipInput.Text,
            Country = CityCountryInput.Text
         };

         var url = $"{Properties.Settings.Default.ApiUrl}/City";
         var result = await url.PostJsonAsync(cityAddRequest).ReceiveJson<CityResponse>();

         if (result == null || result.CityId == 0)
         {
            MessageBox.Show("Registration failed");
         }
         else
         {
            MessageBox.Show("City added");
         }

         PanelHelper.SwapPanel(this.Parent, this, new CityList());
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
   }
}
