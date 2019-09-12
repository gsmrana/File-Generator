namespace File_Generator
{
    partial class MainForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.textBoxFileName = new System.Windows.Forms.TextBox();
            this.textBoxFileContentTemp = new System.Windows.Forms.TextBox();
            this.buttonCreate = new System.Windows.Forms.Button();
            this.comboBoxFileSize = new System.Windows.Forms.ComboBox();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.comboBoxFileSizeUnit = new System.Windows.Forms.ComboBox();
            this.buttonBrowse = new System.Windows.Forms.Button();
            this.labelStatus = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // textBoxFileName
            // 
            this.textBoxFileName.Location = new System.Drawing.Point(12, 98);
            this.textBoxFileName.Name = "textBoxFileName";
            this.textBoxFileName.Size = new System.Drawing.Size(120, 20);
            this.textBoxFileName.TabIndex = 3;
            this.textBoxFileName.Text = "G:\\Test1.txt";
            // 
            // textBoxFileContentTemp
            // 
            this.textBoxFileContentTemp.Location = new System.Drawing.Point(12, 12);
            this.textBoxFileContentTemp.Multiline = true;
            this.textBoxFileContentTemp.Name = "textBoxFileContentTemp";
            this.textBoxFileContentTemp.ScrollBars = System.Windows.Forms.ScrollBars.Both;
            this.textBoxFileContentTemp.Size = new System.Drawing.Size(280, 80);
            this.textBoxFileContentTemp.TabIndex = 2;
            this.textBoxFileContentTemp.Text = "The quick brown fox jumps over the lazy dog!\r\n";
            // 
            // buttonCreate
            // 
            this.buttonCreate.Location = new System.Drawing.Point(227, 98);
            this.buttonCreate.Name = "buttonCreate";
            this.buttonCreate.Size = new System.Drawing.Size(65, 47);
            this.buttonCreate.TabIndex = 0;
            this.buttonCreate.Text = "Create";
            this.buttonCreate.UseVisualStyleBackColor = true;
            this.buttonCreate.Click += new System.EventHandler(this.ButtonCreate_Click);
            // 
            // comboBoxFileSize
            // 
            this.comboBoxFileSize.FormattingEnabled = true;
            this.comboBoxFileSize.Items.AddRange(new object[] {
            "1",
            "8",
            "16",
            "32",
            "64",
            "128",
            "256",
            "512",
            "1024"});
            this.comboBoxFileSize.Location = new System.Drawing.Point(12, 124);
            this.comboBoxFileSize.Name = "comboBoxFileSize";
            this.comboBoxFileSize.Size = new System.Drawing.Size(120, 21);
            this.comboBoxFileSize.TabIndex = 4;
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(12, 151);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(280, 14);
            this.progressBar1.Step = 1;
            this.progressBar1.TabIndex = 1;
            // 
            // comboBoxFileSizeUnit
            // 
            this.comboBoxFileSizeUnit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.comboBoxFileSizeUnit.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.comboBoxFileSizeUnit.FormattingEnabled = true;
            this.comboBoxFileSizeUnit.Items.AddRange(new object[] {
            "Bytes",
            "KBytes",
            "MBytes"});
            this.comboBoxFileSizeUnit.Location = new System.Drawing.Point(141, 124);
            this.comboBoxFileSizeUnit.Name = "comboBoxFileSizeUnit";
            this.comboBoxFileSizeUnit.Size = new System.Drawing.Size(80, 21);
            this.comboBoxFileSizeUnit.TabIndex = 5;
            // 
            // buttonBrowse
            // 
            this.buttonBrowse.Location = new System.Drawing.Point(141, 96);
            this.buttonBrowse.Name = "buttonBrowse";
            this.buttonBrowse.Size = new System.Drawing.Size(80, 23);
            this.buttonBrowse.TabIndex = 6;
            this.buttonBrowse.Text = "Browse";
            this.buttonBrowse.UseVisualStyleBackColor = true;
            this.buttonBrowse.Click += new System.EventHandler(this.ButtonBrowse_Click);
            // 
            // labelStatus
            // 
            this.labelStatus.Location = new System.Drawing.Point(12, 168);
            this.labelStatus.Name = "labelStatus";
            this.labelStatus.Size = new System.Drawing.Size(280, 13);
            this.labelStatus.TabIndex = 7;
            this.labelStatus.Text = "labelStatus";
            this.labelStatus.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(306, 185);
            this.Controls.Add(this.labelStatus);
            this.Controls.Add(this.buttonBrowse);
            this.Controls.Add(this.comboBoxFileSizeUnit);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.comboBoxFileSize);
            this.Controls.Add(this.buttonCreate);
            this.Controls.Add(this.textBoxFileContentTemp);
            this.Controls.Add(this.textBoxFileName);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.Name = "MainForm";
            this.Text = "File Generator";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.Shown += new System.EventHandler(this.MainForm_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox textBoxFileName;
        private System.Windows.Forms.TextBox textBoxFileContentTemp;
        private System.Windows.Forms.Button buttonCreate;
        private System.Windows.Forms.ComboBox comboBoxFileSize;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.ComboBox comboBoxFileSizeUnit;
        private System.Windows.Forms.Button buttonBrowse;
        private System.Windows.Forms.Label labelStatus;
    }
}

