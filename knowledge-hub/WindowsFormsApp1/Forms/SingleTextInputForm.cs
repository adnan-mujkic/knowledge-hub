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

      public SingleTextInputForm(string label, string textPlaceholder = "") {
         InitializeComponent();
         label1.Text = label;
         textBox1.Text = textPlaceholder;
      }

      private void OkButton_Click(object sender, EventArgs e) {
         if (inputSubmitDelegate != null)
            inputSubmitDelegate.Invoke(textBox1.Text);
         this.Hide();
      }

      private void CancelButton_Click(object sender, EventArgs e) {
         if (inputSubmitDelegate != null)
            inputSubmitDelegate.Invoke("");
         this.Hide();
      }
   }
}
