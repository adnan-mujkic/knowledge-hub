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
      UserDataResponse data;

      public UserEdit(UserDataResponse _data) {
         data = _data;
         InitializeComponent();
         RoleSelect.DropDownStyle = ComboBoxStyle.DropDownList;
         errorMessages = new List<string>();

         EmailInput.Text = data.authData.email;
         UsernameInput.Text = data.userData.Username;
         BiographyInput.Text = data.userData.Biography;
         RoleSelect.SelectedIndex = GetIndexOfRole(data.userData.UserRole);
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

      private void button1_Click(object sender, EventArgs e) {
         OpenFileDialog openfd = new OpenFileDialog
         {
            Filter = "Image Files (*.jpg;*.jpeg;*.gif;*.png;)|*.jpg;*.jpeg;*.gif;*.png;"
         };
         if (openfd.ShowDialog() == DialogResult.OK)
         {
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.Image = new Bitmap(openfd.FileName);
         }
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
         }

         data.authData.email = EmailInput.Text;
         data.userData.Email = EmailInput.Text;
         data.userData.Biography = BiographyInput.Text;
         data.userData.Username = UsernameInput.Text;
         data.userData.UserRole = RoleSelect.SelectedItem.ToString();

         var url = $"{Properties.Settings.Default.ApiUrl}/User/UserUpdateInfo";
         data.myBooks = new List<BookResponse>();
         var jsonData = Newtonsoft.Json.JsonConvert.SerializeObject(data);
         var response = await url.PutJsonAsync(data).ReceiveJson<bool>();

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
