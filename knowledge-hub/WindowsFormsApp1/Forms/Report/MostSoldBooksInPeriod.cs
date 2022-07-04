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
   public partial class MostSoldBooksInPeriod : Form
   {
      public MostSoldBooksInPeriod() {
         InitializeComponent();


         FetchData();
      }

      public async void FetchData() {
         BindingSource mostSoldBooksSource = new BindingSource();
         var url = $"{Properties.Settings.Default.ApiUrl}/Transaction";
         var response = await url.GetJsonAsync<List<TransactionResponse>>();
         response = response.Where(x => dateIsInLastYear(x.transactionDate)).ToList();
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

         bindingSource1.DataSource = dataSource;
         reportViewer1.RefreshReport();
      }

      private bool dateIsInLastYear(string date) {
         DateTime transactionTime = DateTime.Parse(date);
         DateTime yearBefore = DateTime.UtcNow.AddMonths(-12);

         return transactionTime >= yearBefore;
      }

      private void button1_Click(object sender, EventArgs e) {
         this.Hide();
      }

      private void MostSoldBooksInPeriod_Load(object sender, EventArgs e) {

         this.reportViewer1.RefreshReport();
      }
   }
}
