using Flurl.Http;
using knowledge_hub.Desktop.Helpers;
using knowledge_hub.Forms.User;
using knowledge_hub.Models.Model.Responses;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.User
{
   public partial class UserEdit : UserControl
   {
      List<string> errorMessages;
      string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";
      UserResponse data;

      public UserEdit(UserResponse _data) {
         data = _data;
         InitializeComponent();
         RoleSelect.DropDownStyle = ComboBoxStyle.DropDownList;
         errorMessages = new List<string>();

         EmailInput.Text = data.Email;
         UsernameInput.Text = data.Username;
         BiographyInput.Text = data.Biography;
         RoleSelect.SelectedIndex = GetIndexOfRole(data.UserRole);
      }

      private int GetIndexOfRole(string roleName) {
         switch (roleName)
         {
            case "Admin":
               return 1;
            case "User":
               return 2;
            case "Delivery":
               return 3;
            default:
               return 0;
         }
      }

      private void BackButton_Click(object sender, EventArgs e) {
         PanelHelper.SwapPanel(this.Parent, this, new UserList());
      }

      private void EmailInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Email cannot be empty!");
         if (string.IsNullOrWhiteSpace(EmailInput.Text))
         {
            errorMessages.Add("Email cannot be empty!");
            e.Cancel = false;
            return;
         }

         errorMessages.Remove("Email not correct format");
         if (!Regex.IsMatch(EmailInput.Text, emailPattern))
         {
            errorMessages.Add("Email not correct format");
            e.Cancel = false;
            return;
         }
      }
      private void UsernameInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Username cannot be empty!");
         if (string.IsNullOrWhiteSpace(UsernameInput.Text))
         {
            errorMessages.Add("Username cannot be empty!");
            e.Cancel = false;
            return;
         }
      }

      private void RoleSelect_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Role not selected!");
         if (RoleSelect.SelectedItem == null)
         {
            errorMessages.Add("Role not selected!");
            return;
         }
      }

      private async void SubmitButton_Click(object sender, EventArgs e) {
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

         data.Email = EmailInput.Text;
         data.Biography = BiographyInput.Text;
         data.Username = UsernameInput.Text;
         data.UserRole = RoleSelect.SelectedItem.ToString();

         var response = await APIService.PutFromUrlWithAuth<bool>("User/UserUpdateInfo", data);

         if (!response)
         {
            MessageBox.Show("Error updating user");
            PanelHelper.SwapPanel(this.Parent, this, new UserList());
            return;
         }

         MessageBox.Show("User sucessfully updated");
         PanelHelper.SwapPanel(this.Parent, this, new UserList());
      }
   }
}
