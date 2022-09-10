using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
   public partial class SingleTextInputForm : Form
   {
      public delegate void InputSubmitDelegate(string value);
      public event InputSubmitDelegate inputSubmitDelegate;

      List<string> errorMessages;

      public SingleTextInputForm(string label, string textPlaceholder = "") {
         InitializeComponent();
         label1.Text = label;
         textBox1.Text = textPlaceholder;
         errorMessages = new List<string>();
      }

      private void OkButton_Click(object sender, EventArgs e) {
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
         if (inputSubmitDelegate != null)
            inputSubmitDelegate.Invoke(textBox1.Text);
         this.Hide();
      }

      private void CancelButton_Click(object sender, EventArgs e) {
         if (inputSubmitDelegate != null)
            inputSubmitDelegate.Invoke("");
         this.Hide();
      }

        private void textBox1_Validating(object sender, CancelEventArgs e) {
         errorMessages.Remove("Text cannot be empty!");
         if (string.IsNullOrWhiteSpace(textBox1.Text))
         {
            errorMessages.Add("Text cannot be empty!");
            e.Cancel = false;
            return;
         }
      }
    }
}
