using Flurl.Http;
using knowledge_hub.Models.Model.Report;
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

namespace WindowsFormsApp1.Forms.Report
{
   public partial class TopUsersWithMostPurchases : Form
   {
      public TopUsersWithMostPurchases() {
         InitializeComponent();

         FetchData();
      }

      public async void FetchData() {
         var response = await APIService.GetFromUrlWithAuth<List<OrderResponse>>("Order");

         var urlUser = $"{Properties.Settings.Default.ApiUrl}/User";
         var responseUser = await urlUser.GetJsonAsync<List<UserResponse>>();

         var groupingJoin = response.Join(
               responseUser,
               orders => orders.UserId,
               users => users.UserId,
               (orders, users) => new {
                  userId = users.UserId,
                  username = users.Username,
               }
            ).ToList();

         var userGrouping = groupingJoin.GroupBy(x => x.userId);
         var dataSource = new List<UserPurchases>();

         foreach (var grouping in userGrouping)
         {
            var row = new UserPurchases();
            row.userId = grouping.Key;
            row.username = grouping.First().username;
            row.purchases = grouping.Count();

            dataSource.Add(row);
         }

         dataSource = dataSource
            .OrderBy(x => x.purchases)
            .Reverse()
            .Take(10)
            .ToList();

         dataGridView1.DataSource = dataSource;
      }

      private void button1_Click(object sender, EventArgs e) {
         this.Hide();
      }
   }
}
