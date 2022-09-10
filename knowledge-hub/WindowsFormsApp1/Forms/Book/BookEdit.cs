﻿using Flurl.Http;
using knowledge_hub.Desktop.Helpers;
using knowledge_hub.Models.Model.Requests;
using knowledge_hub.Models.Model.Responses;
using knowledge_hub.Desktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.Book
{
   public partial class BookEdit : UserControl
   {
      List<string> errorMessages;
      BookResponse data;
      byte[] bookFile;

      public BookEdit(BookResponse _data) {
         InitializeComponent();
         bookFile = new byte[0];
         errorMessages = new List<string>();
         Cursor = Cursors.WaitCursor;
         data = _data;
         NameInput.Text = data.Name;
         AuthorInput.Text = data.Author;
         DescriptionInput.Text = data.Description;
         PricePhysicalInput.Text = data.PricePhysical.ToString();
         PriceDigitalInput.Text = data.PriceDigital.ToString();
         LoadAdditionalData(data.Language, data.Category);
      }

      private async void LoadAdditionalData(string languageName, string categoryName) {
         var languageData = await APIService.GetFromUrlWithAuth<List<LanguageResponse>>("Language");
         List<KeyValuePair<int, string>> languagePairs = new List<KeyValuePair<int, string>>();
         foreach (var language in languageData)
         {
            languagePairs.Add(new KeyValuePair<int, string>(language.LanguageId, language.Name));
         }
         var bsLanguage = new BindingSource(languagePairs, null);
         LanguageSelect.DataSource = bsLanguage;
         LanguageSelect.DisplayMember = "Value";
         LanguageSelect.ValueMember = "Key";
         for (int i = 0; i < languagePairs.Count; i++)
         {
            if (languagePairs[i].Value == languageName)
            {
               LanguageSelect.SelectedIndex = i;
               break;
            }
         }

         var categoryData = await APIService.GetFromUrlWithAuth<List<CategoryResponse>>("Category");
         List<KeyValuePair<int, string>> categoryPairs = new List<KeyValuePair<int, string>>();
         foreach (var category in categoryData)
         {
            categoryPairs.Add(new KeyValuePair<int, string>(category.CategoryId, category.Name));
         }
         var bsCategory = new BindingSource(categoryPairs, null);
         CategorySelect.DataSource = bsCategory;
         CategorySelect.DisplayMember = "Value";
         CategorySelect.ValueMember = "Key";
         for (int i = 0; i < categoryData.Count; i++)
         {
            if (categoryData[i].Name == categoryName)
            {
               CategorySelect.SelectedIndex = i;
               break;
            }
         }

         pictureBox1.Image = await DownloadImage(data.ImagePath);

         Cursor = Cursors.Default;
      }

      public async Task<Bitmap> DownloadImage(string path) {
         try
         {
            byte[] imageData = null;
            WebClient client = new WebClient();
            Stream stream = client.OpenRead(data.ImagePath);
            Bitmap image = new Bitmap(stream);
            stream.Flush();
            stream.Close();
            client.Dispose();
            return image;
         }
         catch (Exception e)
         {
            MessageBox.Show(e.Message);
            return new Bitmap(0, 0);
         }
      }

      private void SelectPictureButton_Click(object sender, EventArgs e) {
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

      private void BackButton_Click(object sender, EventArgs e) {
         PanelHelper.SwapPanel(this.Parent, this, new BookList());
      }

      private async void UpdateButton_Click(object sender, EventArgs e) {
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

         var dataToSend = new BookInsertRequest
         {
            Name = NameInput.Text,
            Author = AuthorInput.Text,
            Description = DescriptionInput.Text,
            ImagePath = ImageHelper.SystemDrawingToByteArray(pictureBox1.Image),
            PriceDigital = Convert.ToDouble(PriceDigitalInput.Text),
            PricePhysical = Convert.ToDouble(PricePhysicalInput.Text),
            LanguageId = ((KeyValuePair<int, string>)LanguageSelect.SelectedItem).Key,
            CategoryId = ((KeyValuePair<int, string>)CategorySelect.SelectedItem).Key,
            BookFile = bookFile,
            Score = data.Score
         };

         var response = await APIService.PutFromUrlWithAuth<BookResponse>($"Book?ID={data.BookId}", dataToSend);

         if (response == null || response.BookId == 0)
         {
            MessageBox.Show("Error updating book");
            return;
         }
         else
         {
            MessageBox.Show("Book sucessfully updated");
            return;
         }
      }

      private void PricePhysicalInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Price physical must be a number!");
         try
         {
            Convert.ToDouble(PricePhysicalInput.Text);
         }
         catch (Exception err)
         {
            errorMessages.Add("Price physical must be a number!");
            e.Cancel = false;
            return;
         }
      }

      private void PriceDigitalInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Price digital must be a number!");
         try
         {
            Convert.ToDouble(PriceDigitalInput.Text);
         }
         catch (Exception err)
         {
            errorMessages.Add("Price digital must be a number!");
            e.Cancel = false;
            return;
         }
      }

      private void button1_Click(object sender, EventArgs e) {
         OpenFileDialog openfd = new OpenFileDialog
         {
            Filter = "Files (*.pdf;*)|*.pdf;*"
         };
         if (openfd.ShowDialog() == DialogResult.OK)
         {
            Cursor.Current = Cursors.WaitCursor;
            label9.Text = "Book: " + openfd.FileName;
            bookFile = File.ReadAllBytes(openfd.FileName);
            Cursor.Current = Cursors.Default;
         }
      }

      private void NameInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Book name cannot be empty!");
         if (string.IsNullOrWhiteSpace(NameInput.Text))
         {
            errorMessages.Add("Book name cannot be empty!");
            e.Cancel = false;
            return;
         }
      }

      private void AuthorInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Author name cannot be empty!");
         if (string.IsNullOrWhiteSpace(AuthorInput.Text))
         {
            errorMessages.Add("Author name cannot be empty!");
            e.Cancel = false;
            return;
         }
      }

      private void DescriptionInput_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Book description cannot be empty!");
         if (string.IsNullOrWhiteSpace(DescriptionInput.Text))
         {
            errorMessages.Add("Book description name cannot be empty!");
            e.Cancel = false;
            return;
         }
      }
   }
}
