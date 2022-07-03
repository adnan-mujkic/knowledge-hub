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
   public partial class TopBestBooks : Form
   {
      public TopBestBooks() {
         InitializeComponent();

         FetchData();
      }

      public async void FetchData() {
         BindingSource mostSoldBooksSource = new BindingSource();
         var url = $"{Properties.Settings.Default.ApiUrl}/Review";
         var response = await url.GetJsonAsync<List<ReviewResponse>>();

         var urlBook = $"{Properties.Settings.Default.ApiUrl}/Book";
         var responseBook = await urlBook.GetJsonAsync<List<BookResponse>>();

         var groupingJoin = response.Join(
               responseBook,
               reviews => reviews.BookId,
               books => books.BookId,
               (reviews, books) => new {
                  bookId = reviews.BookId,
                  name = books.Name,
                  score = reviews.Rating
               }
            ).ToList();

         var bookIdGrouping = groupingJoin.GroupBy(x => x.bookId);
         var dataSource = new List<BookReview>();

         foreach (var grouping in bookIdGrouping)
         {
            var row = new BookReview();
            row.BookId = grouping.Key;
            row.bookName = grouping.First().name;
            row.score = grouping.Sum(x => x.score) / (double)grouping.Count();

            dataSource.Add(row);
         }

         dataSource = dataSource
            .OrderBy(x => x.score)
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
