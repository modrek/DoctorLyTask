namespace DoctorLyApp.UserControls
{
    partial class ExcelUserControl
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
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
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.btnBrows = new System.Windows.Forms.Button();
            this.txtFile = new System.Windows.Forms.TextBox();
            this.SheetName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(17, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(54, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "File Path :";
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.Filter = "excel files (*.xls)|(*.xlsx)";
            // 
            // btnBrows
            // 
            this.btnBrows.Location = new System.Drawing.Point(359, 18);
            this.btnBrows.Name = "btnBrows";
            this.btnBrows.Size = new System.Drawing.Size(103, 23);
            this.btnBrows.TabIndex = 1;
            this.btnBrows.Text = "Brows File";
            this.btnBrows.UseVisualStyleBackColor = true;
            this.btnBrows.Click += new System.EventHandler(this.btnBrows_Click);
            // 
            // txtFile
            // 
            this.txtFile.Location = new System.Drawing.Point(89, 18);
            this.txtFile.Name = "txtFile";
            this.txtFile.Size = new System.Drawing.Size(264, 20);
            this.txtFile.TabIndex = 2;
            // 
            // SheetName
            // 
            this.SheetName.Location = new System.Drawing.Point(89, 54);
            this.SheetName.Name = "SheetName";
            this.SheetName.Size = new System.Drawing.Size(264, 20);
            this.SheetName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(17, 57);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(72, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Sheet Name :";
            // 
            // ExcelUserControl
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.label2);
            this.Controls.Add(this.SheetName);
            this.Controls.Add(this.txtFile);
            this.Controls.Add(this.btnBrows);
            this.Controls.Add(this.label1);
            this.Name = "ExcelUserControl";
            this.Size = new System.Drawing.Size(503, 151);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private System.Windows.Forms.Button btnBrows;
        private System.Windows.Forms.TextBox txtFile;
        private System.Windows.Forms.TextBox SheetName;
        private System.Windows.Forms.Label label2;
    }
}
