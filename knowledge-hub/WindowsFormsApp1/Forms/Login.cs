using knowledge_hub.Models.Model.Requests;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1;

namespace knowledge_hub.Desktop.Forms
{
   public partial class Login : Form
   {
      public Login() {
         InitializeComponent();
      }

      private async void AuthenticateAndLoadPanel() {
         //Auth
         AuthenticationRequest authRequest = new AuthenticationRequest()
         {
            Email = usernameField.Text,
            Password = passwordField.Text
         };

         var user = await APIService.Authenticate(authRequest);

         if (user == null || user.authData == null)
         {
            MessageBox.Show("Wrong email or password");
            return;
         }

         //Initialize
         if (user != null && user.userData != null && user.userData.UserRole == "Admin")
         {
            var dashboard = new AdminDashboard(user);
            dashboard.Show();
            this.Hide();
         }
         else
         {
            MessageBox.Show("Not amin user!");
         }

         PersistentData.userData = user;
      }

      private async void button1_Click(object sender, EventArgs e) {
         AuthenticateAndLoadPanel();
      }

      private void CloseAppButton_Click(object sender, EventArgs e) {
         Application.Exit();
      }

      private void MinimizeAppButton_Click(object sender, EventArgs e) {
         this.WindowState = FormWindowState.Minimized;
      }
   }
}
