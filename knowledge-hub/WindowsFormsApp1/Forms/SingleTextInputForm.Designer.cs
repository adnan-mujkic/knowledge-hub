using System.Windows.Forms;

namespace WindowsFormsApp1.Forms
{
   partial class SingleTextInputForm
   {
      /// <summary>
      /// Required designer variable.
      /// </summary>
      private System.ComponentModel.IContainer components = null;

      /// <summary>
      /// Clean up any resources being used.
      /// </summary>
      /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
      protected override void Dispose(bool disposing) {
         if (disposing && (components != null))
         {
            components.Dispose();
         }
         base.Dispose(disposing);
      }

      #region Windows Form Designer generated code

      /// <summary>
      /// Required method for Designer support - do not modify
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.label1 = new System.Windows.Forms.Label();
         this.OkButton = new System.Windows.Forms.Button();
         this.textBox1 = new System.Windows.Forms.TextBox();
         this.CancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label1
         // 
         this.label1.AutoEllipsis = true;
         this.label1.AutoSize = true;
         this.label1.Location = new System.Drawing.Point(47, 20);
         this.label1.MaximumSize = new System.Drawing.Size(400, 16);
         this.label1.Name = "label1";
         this.label1.Size = new System.Drawing.Size(117, 16);
         this.label1.TabIndex = 0;
         this.label1.Text = "labelaaaaaaaaaa";
         this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
         // 
         // OkButton
         // 
         this.OkButton.BackColor = System.Drawing.Color.BurlyWood;
         this.OkButton.FlatAppearance.BorderSize = 0;
         this.OkButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.OkButton.Location = new System.Drawing.Point(110, 118);
         this.OkButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.OkButton.Name = "OkButton";
         this.OkButton.Size = new System.Drawing.Size(106, 35);
         this.OkButton.TabIndex = 1;
         this.OkButton.Text = "OK";
         this.OkButton.UseVisualStyleBackColor = false;
         this.OkButton.Click += new System.EventHandler(this.OkButton_Click);
         // 
         // textBox1
         // 
         this.textBox1.Location = new System.Drawing.Point(47, 64);
         this.textBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.textBox1.Name = "textBox1";
         this.textBox1.Size = new System.Drawing.Size(388, 22);
         this.textBox1.TabIndex = 3;
         this.textBox1.Validating += new System.ComponentModel.CancelEventHandler(this.textBox1_Validating);
         // 
         // CancelButton
         // 
         this.CancelButton.BackColor = System.Drawing.Color.BurlyWood;
         this.CancelButton.FlatAppearance.BorderSize = 0;
         this.CancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.CancelButton.Location = new System.Drawing.Point(273, 118);
         this.CancelButton.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.CancelButton.Name = "CancelButton";
         this.CancelButton.Size = new System.Drawing.Size(106, 35);
         this.CancelButton.TabIndex = 4;
         this.CancelButton.Text = "Cancel";
         this.CancelButton.UseVisualStyleBackColor = false;
         this.CancelButton.Click += new System.EventHandler(this.CancelButton_Click);
         // 
         // SingleTextInputForm
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.ClientSize = new System.Drawing.Size(498, 179);
         this.ControlBox = false;
         this.Controls.Add(this.CancelButton);
         this.Controls.Add(this.textBox1);
         this.Controls.Add(this.OkButton);
         this.Controls.Add(this.label1);
         this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
         this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
         this.Name = "SingleTextInputForm";
         this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
         this.Text = "SingleTextInputForm";
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label1;
      private Button OkButton;
      private TextBox textBox1;
      private Button CancelButton;
   }
}