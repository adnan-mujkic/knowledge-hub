using System.Windows.Forms;

namespace WindowsFormsApp1.Forms.City
{
   partial class CityEdit
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
         this.cancelButton = new System.Windows.Forms.Button();
         this.label5 = new System.Windows.Forms.Label();
         this.CityCountryInput = new System.Windows.Forms.TextBox();
         this.label4 = new System.Windows.Forms.Label();
         this.CityZipInput = new System.Windows.Forms.TextBox();
         this.label3 = new System.Windows.Forms.Label();
         this.label2 = new System.Windows.Forms.Label();
         this.CityNameInput = new System.Windows.Forms.TextBox();
         this.SaveButton = new System.Windows.Forms.Button();
         this.SuspendLayout();
         // 
         // cancelButton
         // 
         this.cancelButton.BackColor = System.Drawing.Color.BurlyWood;
         this.cancelButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.cancelButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.cancelButton.FlatAppearance.BorderSize = 0;
         this.cancelButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.cancelButton.Location = new System.Drawing.Point(375, 413);
         this.cancelButton.Name = "cancelButton";
         this.cancelButton.Size = new System.Drawing.Size(77, 38);
         this.cancelButton.TabIndex = 52;
         this.cancelButton.Text = "Cancel";
         this.cancelButton.UseVisualStyleBackColor = true;
         this.cancelButton.Click += new System.EventHandler(this.cancelButton_Click);
         // 
         // label5
         // 
         this.label5.AutoSize = true;
         this.label5.Location = new System.Drawing.Point(312, 282);
         this.label5.Name = "label5";
         this.label5.Size = new System.Drawing.Size(63, 20);
         this.label5.TabIndex = 51;
         this.label5.Text = "Country:";
         // 
         // CityCountryInput
         // 
         this.CityCountryInput.Location = new System.Drawing.Point(312, 305);
         this.CityCountryInput.Name = "CityCountryInput";
         this.CityCountryInput.Size = new System.Drawing.Size(189, 27);
         this.CityCountryInput.TabIndex = 50;
         // 
         // label4
         // 
         this.label4.AutoSize = true;
         this.label4.Location = new System.Drawing.Point(312, 206);
         this.label4.Name = "label4";
         this.label4.Size = new System.Drawing.Size(67, 20);
         this.label4.TabIndex = 49;
         this.label4.Text = "Zipcode:";
         // 
         // CityZipInput
         // 
         this.CityZipInput.Location = new System.Drawing.Point(312, 229);
         this.CityZipInput.Name = "CityZipInput";
         this.CityZipInput.Size = new System.Drawing.Size(189, 27);
         this.CityZipInput.TabIndex = 48;
         this.CityZipInput.Validating += new System.ComponentModel.CancelEventHandler(this.CityZipInput_Validating);
         // 
         // label3
         // 
         this.label3.AutoSize = true;
         this.label3.Location = new System.Drawing.Point(312, 134);
         this.label3.Name = "label3";
         this.label3.Size = new System.Drawing.Size(52, 20);
         this.label3.TabIndex = 47;
         this.label3.Text = "Name:";
         // 
         // label2
         // 
         this.label2.AutoSize = true;
         this.label2.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
         this.label2.Location = new System.Drawing.Point(341, 79);
         this.label2.Name = "label2";
         this.label2.Size = new System.Drawing.Size(97, 28);
         this.label2.TabIndex = 46;
         this.label2.Text = "Edit City:";
         // 
         // CityNameInput
         // 
         this.CityNameInput.Location = new System.Drawing.Point(312, 157);
         this.CityNameInput.Name = "CityNameInput";
         this.CityNameInput.Size = new System.Drawing.Size(189, 27);
         this.CityNameInput.TabIndex = 45;
         // 
         // SaveButton
         // 
         this.SaveButton.BackColor = System.Drawing.Color.BurlyWood;
         this.SaveButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
         this.SaveButton.Cursor = System.Windows.Forms.Cursors.Hand;
         this.SaveButton.FlatAppearance.BorderSize = 0;
         this.SaveButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
         this.SaveButton.Location = new System.Drawing.Point(375, 357);
         this.SaveButton.Name = "SaveButton";
         this.SaveButton.Size = new System.Drawing.Size(77, 38);
         this.SaveButton.TabIndex = 44;
         this.SaveButton.Text = "Save";
         this.SaveButton.UseVisualStyleBackColor = true;
         this.SaveButton.Click += new System.EventHandler(this.SaveButton_Click);
         // 
         // CityEdit
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
         this.Controls.Add(this.SaveButton);
         this.Name = "CityEdit";
         this.Size = new System.Drawing.Size(864, 514);
         this.ResumeLayout(false);
         this.PerformLayout();

      }

      #endregion

      private Button cancelButton;
      private Label label5;
      private TextBox CityCountryInput;
      private Label label4;
      private TextBox CityZipInput;
      private Label label3;
      private Label label2;
      private TextBox CityNameInput;
      private Button SaveButton;
   }
}
