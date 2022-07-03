using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.City
{
   partial class CityAdd
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

      #region Component Designer generated code

      /// <summary> 
      /// Required method for Designer support - do not modify 
      /// the contents of this method with the code editor.
      /// </summary>
      private void InitializeComponent() {
         this.label5 = new System.Windows.Forms.Label();
         this.CityCountryInput = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.CityZipInput = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.CityNameInput = new System.Windows.Forms.TextBox();
         this.AddButton = new System.Windows.Forms.Button();
         this.cancelButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(320, 290);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(63, 20);
         this.label5.TabIndex = 42;
         this.label5.Text = "Country:";
         // 
         // CityCountryInput
         // 
         this.CityCountryInput.Location = new System.Drawing.Point(320, 313);
         this.CityCountryInput.Name = "CityCountryInput";
         this.CityCountryInput.Size = new System.Drawing.Size(189, 27);
         this.CityCountryInput.TabIndex = 41;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(320, 214);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(67, 20);
         this.label4.TabIndex = 40;
         this.label4.Text = "Zipcode:";
         // 
         // CityZipInput
         // 
         this.CityZipInput.Location = new System.Drawing.Point(320, 237);
         this.CityZipInput.Name = "CityZipInput";
         this.CityZipInput.Size = new System.Drawing.Size(189, 27);
         this.CityZipInput.TabIndex = 39;
         this.CityZipInput.Validating += new System.ComponentModel.CancelEventHandler(this.CityZipInput_Validating);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(320, 142);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(52, 20);
         this.label3.TabIndex = 38;
         this.label3.Text = "Name:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.label2.Location = new System.Drawing.Point(349, 87);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(141, 28);
         this.label2.TabIndex = 37;
         this.label2.Text = "Add new city:";
         // 
         // CityNameInput
         // 
         this.CityNameInput.Location = new System.Drawing.Point(320, 165);
         this.CityNameInput.Name = "CityNameInput";
         this.CityNameInput.Size = new System.Drawing.Size(189, 27);
         this.CityNameInput.TabIndex = 36;
         // 
         // AddButton
         // 
         this.AddButton.BackColor = System.Drawing.Color.BurlyWood;
         this.AddButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.AddButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.AddButton.FlatAppearance.BorderSize = 0;
         this.AddButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.AddButton.Location = new System.Drawing.Point(383, 365);
         this.AddButton.Name = "AddButton";
         this.AddButton.Size = new System.Drawing.Size(77, 38);
         this.AddButton.TabIndex = 35;
         this.AddButton.Text = "Add";
         this.AddButton.UseVisualStyleBackColor = true;
         this.AddButton.Click += new System.EventHandler(this.AddButton_Click);
         // 
         // cancelButton
         // 
         this.cancelButton.BackColor = System.Drawing.Color.BurlyWood;
         this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.cancelButton.FlatAppearance.BorderSize = 0;
         this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.cancelButton.Location = new System.Drawing.Point(383, 421);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(77, 38);
         this.cancelButton.TabIndex = 43;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // CityAdd
         // 
         this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
         this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
         this.Controls.Add(this.cancelButton);
         this.Controls.Add(this.label5);
         this.Controls.Add(this.CityCountryInput);
         this.Controls.Add(this.label4);
         this.Controls.Add(this.CityZipInput);
         this.Controls.Add(this.label3);
         this.Controls.Add(this.label2);
         this.Controls.Add(this.CityNameInput);
         this.Controls.Add(this.AddButton);
         this.Name = "CityAdd";
         this.Size = new System.Drawing.Size(864, 514);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Label label5;
      private TextBox CityCountryInput;
      private Label label4;
      private TextBox CityZipInput;
      private Label label3;
      private Label label2;
      private TextBox CityNameInput;
      private Button AddButton;
      private Button cancelButton;
   }
}
