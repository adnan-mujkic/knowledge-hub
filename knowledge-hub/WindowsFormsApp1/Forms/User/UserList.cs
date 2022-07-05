using Flurl.Http;
using knowledge_hub.Desktop.Helpers;
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
using WindowsFormsApp1.Forms.User;
using WindowsFormsApp1;

namespace knowledge_hub.Forms.User
{
   public partial class UserList : UserControl
   {
      public UserList() {
         InitializeComponent();
         LoadUserList();
      }

      private async void LoadUserList(string search = "") {
         button2.Enabled = false;
         Cursor = System.Windows.Forms.Cursors.WaitCursor;

         string url;
         List<UserResponse> response;
         if (!string.IsNullOrWhiteSpace(search))
         {
            response = await APIService.GetFromUrlWithAuth<List<UserResponse>>($"User/Search?search={UserSearchBox.Text}");
         }
         else
         {
            response = await APIService.GetFromUrlWithAuth<List<UserResponse>>("User");
         }

         dataGridView1.AutoGenerateColumns = false;
         dataGridView1.ReadOnly = true;
         dataGridView1.DataSource = response;

         button2.Enabled = true;
         Cursor = System.Windows.Forms.Cursors.Default;
      }

      private void button2_Click(object sender, EventArgs e) {
         LoadUserList();
      }

      private void AddUserButton_Click(object sender, EventArgs e) {
         PanelHelper.SwapPanel(this.Parent, this, new UserAdd());
      }

      private void DeleteUserButton_Click(object sender, EventArgs e) {
         if (dataGridView1.CurrentRow == null)
         {
            MessageBox.Show("Please select a user");
            return;
         }
         RemoveUser();
      }

      private async void RemoveUser() {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);
         bool result = await APIService.DeleteFromUrlWithAuth("User", ID);

         if (result)
         {
            MessageBox.Show("User removed");
            LoadUserList();
         }
      }

      private async void EditUserButton_Click(object sender, EventArgs e) {
         int ID = Convert.ToInt32(dataGridView1.CurrentRow.Cells["UserID"].Value);

         var response = await APIService.GetFromUrlWithAuth<UserDataResponse>($"User/GetDetailedUserInfo?ID={ID}");
         if (response == null)
         {
            MessageBox.Show("User getting error");
            return;
         }

         PanelHelper.SwapPanel(this.Parent, this, new UserEdit(response));
      }

      private async void SearchUsersButton_Click(object sender, EventArgs e) {
         LoadUserList(UserSearchBox.Text);
      }
   }
}
