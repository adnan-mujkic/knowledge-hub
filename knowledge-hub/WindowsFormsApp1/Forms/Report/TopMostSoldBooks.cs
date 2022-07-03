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
   public partial class TopMostSoldBooks : Form
   {
      public TopMostSoldBooks() {
         InitializeComponent();

         FetchData();
      }

      public async void FetchData() {
         BindingSource mostSoldBooksSource = new BindingSource();
         var url = $"{Properties.Settings.Default.ApiUrl}/Transaction";
         var response = await url.GetJsonAsync<List<TransactionResponse>>();
         var bookIdGrouping = response.GroupBy(x => x.order.BookId);
         var dataSource = new List<MostSoldBooksDate>();

         foreach (var grouping in bookIdGrouping)
         {
            var row = new MostSoldBooksDate();
            row.BookId = grouping.Key;
            row.BookName = grouping.First().bookName;
            row.Sold = grouping.Count();
            dataSource.Add(row);
         }

         dataSource = dataSource
            .OrderBy(x => x.Sold)
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
