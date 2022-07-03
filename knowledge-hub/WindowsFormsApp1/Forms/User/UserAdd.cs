using Flurl.Http;
using knowledge_hub.Desktop.Helpers;
using knowledge_hub.Models.Model.Requests;
using knowledge_hub.Models.Model.Responses;
using knowledge_hub.WebAPI.Model.Requests;
using knowledge_hub.Desktop.Helpers;
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
using knowledge_hub.Forms.User;

namespace WindowsFormsApp1.Forms.User
{
   public partial class UserAdd : UserControl
   {
      List<string> errorMessages;
      Regex hasNumber = new Regex(@"[0-9]+");
      Regex hasUpperChar = new Regex(@"[A-Z]+");
      Regex hasMinimum8Chars = new Regex(@".{8,}");
      string emailPattern = @"^\w+@[a-zA-Z_]+?\.[a-zA-Z]{2,3}$";

      public UserAdd() {
         InitializeComponent();
         RoleSelect.DropDownStyle = ComboBoxStyle.DropDownList;
         errorMessages = new List<string>();
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

      private void PasswordInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Password cannot be empty!");
         if (string.IsNullOrWhiteSpace(PasswordInput.Text))
         {
            errorMessages.Add("Password cannot be empty!");
            e.Cancel = false;
            return;
         }

         errorMessages.Remove("Password needs to have a number, an upper character and a minimum of 8 characters!");
         if (!hasNumber.IsMatch(PasswordInput.Text) ||
            !hasUpperChar.IsMatch(PasswordInput.Text) ||
            !hasMinimum8Chars.IsMatch(PasswordInput.Text))
         {
            errorMessages.Add("Password needs to have a number, an upper character and a minimum of 8 characters!");
            e.Cancel = false;
            return;
         }
      }

      private void PasswordConfirmInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Password confirm cannot be empty!");
         if (string.IsNullOrWhiteSpace(PasswordConfirmInput.Text))
         {
            errorMessages.Add("Password confirm cannot be empty!");
            e.Cancel = false;
            return;
         }

         errorMessages.Remove("Passwords need to match");
         if (PasswordConfirmInput.Text != PasswordInput.Text)
         {
            errorMessages.Add("Passwords need to match");
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

      private void SubmitButton_Click(object sender, EventArgs e) {
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
         RegisterUser();
      }

      private async void RegisterUser() {
         LoginRegisterRequest loginRegisterRequest = new LoginRegisterRequest()
         {
            Email = EmailInput.Text,
            Password = PasswordInput.Text,
            ConfirmPassword = PasswordConfirmInput.Text
         };

         var url = $"{Properties.Settings.Default.ApiUrl}/User/Register";
         var result = await url.PostJsonAsync(loginRegisterRequest).ReceiveJson<RegisterResponse>();
         if (result.LoginId == 0)
         {
            MessageBox.Show($"Registration failed\n{result.Message}");
         }

         UserRegisterRequest userRegisterRequest = new UserRegisterRequest()
         {
            LoginId = result.LoginId,
            Username = UsernameInput.Text,
            Biography = BiographyInput.Text,
            Image = pictureBox1.Image != null ? ImageHelper.SystemDrawingToByteArray(pictureBox1.Image) : null
         };
         url = $"{Properties.Settings.Default.ApiUrl}/User/RegisterUser";
         var inertResult = await url.PostJsonAsync(userRegisterRequest).ReceiveJson<UserResponse>();

         MessageBox.Show("User registered");
         PanelHelper.SwapPanel(this.Parent, this, new UserList());
      }
   }
}
