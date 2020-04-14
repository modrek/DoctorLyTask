namespace DoctorLyApp
{
    partial class frmMain
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.BtnStartMigrate = new System.Windows.Forms.Button();
            this.btnPreview = new System.Windows.Forms.Button();
            this.grdPreview = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.drpSourceType = new System.Windows.Forms.ComboBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).BeginInit();
            this.SuspendLayout();
            // 
            // BtnStartMigrate
            // 
            this.BtnStartMigrate.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.BtnStartMigrate.Location = new System.Drawing.Point(345, 63);
            this.BtnStartMigrate.Name = "BtnStartMigrate";
            this.BtnStartMigrate.Size = new System.Drawing.Size(213, 48);
            this.BtnStartMigrate.TabIndex = 0;
            this.BtnStartMigrate.Text = "Start Migration";
            this.BtnStartMigrate.UseVisualStyleBackColor = true;
            this.BtnStartMigrate.Click += new System.EventHandler(this.BtnStartMigrate_Click);
            // 
            // btnPreview
            // 
            this.btnPreview.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPreview.Location = new System.Drawing.Point(92, 63);
            this.btnPreview.Name = "btnPreview";
            this.btnPreview.Size = new System.Drawing.Size(213, 48);
            this.btnPreview.TabIndex = 1;
            this.btnPreview.Text = "Priview Migration";
            this.btnPreview.UseVisualStyleBackColor = true;
            this.btnPreview.Click += new System.EventHandler(this.btnPreview_Click);
            // 
            // grdPreview
            // 
            this.grdPreview.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdPreview.Location = new System.Drawing.Point(12, 117);
            this.grdPreview.Name = "grdPreview";
            this.grdPreview.Size = new System.Drawing.Size(776, 321);
            this.grdPreview.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(74, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Select Source";
            // 
            // drpSourceType
            // 
            this.drpSourceType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.drpSourceType.FormattingEnabled = true;
            this.drpSourceType.Location = new System.Drawing.Point(92, 21);
            this.drpSourceType.Name = "drpSourceType";
            this.drpSourceType.Size = new System.Drawing.Size(213, 21);
            this.drpSourceType.TabIndex = 4;
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.drpSourceType);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.grdPreview);
            this.Controls.Add(this.btnPreview);
            this.Controls.Add(this.BtnStartMigrate);
            this.Name = "frmMain";
            this.Text = "DoctoLy Migration App";
            this.Load += new System.EventHandler(this.frmMain_Load);
            ((System.ComponentModel.ISupportInitialize)(this.grdPreview)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button BtnStartMigrate;
        private System.Windows.Forms.Button btnPreview;
        private System.Windows.Forms.DataGridView grdPreview;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox drpSourceType;
    }
}

