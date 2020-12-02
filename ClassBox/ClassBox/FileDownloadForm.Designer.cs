namespace ClassBox
{
    partial class FileDownloadForm
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
            this.progressbar_download = new MetroFramework.Controls.MetroProgressBar();
            this.lbl_persentNum = new MetroFramework.Controls.MetroLabel();
            this.lbl_persent = new MetroFramework.Controls.MetroLabel();
            this.lbl_filename = new MetroFramework.Controls.MetroLabel();
            this.SuspendLayout();
            // 
            // progressbar_download
            // 
            this.progressbar_download.Location = new System.Drawing.Point(23, 122);
            this.progressbar_download.Name = "progressbar_download";
            this.progressbar_download.Size = new System.Drawing.Size(436, 23);
            this.progressbar_download.TabIndex = 0;
            // 
            // lbl_persentNum
            // 
            this.lbl_persentNum.AutoSize = true;
            this.lbl_persentNum.Location = new System.Drawing.Point(421, 86);
            this.lbl_persentNum.Name = "lbl_persentNum";
            this.lbl_persentNum.Size = new System.Drawing.Size(16, 19);
            this.lbl_persentNum.TabIndex = 1;
            this.lbl_persentNum.Text = "0";
            this.lbl_persentNum.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // lbl_persent
            // 
            this.lbl_persent.AutoSize = true;
            this.lbl_persent.Location = new System.Drawing.Point(439, 86);
            this.lbl_persent.Name = "lbl_persent";
            this.lbl_persent.Size = new System.Drawing.Size(20, 19);
            this.lbl_persent.TabIndex = 2;
            this.lbl_persent.Text = "%";
            this.lbl_persent.TextAlign = System.Drawing.ContentAlignment.TopCenter;
            // 
            // lbl_filename
            // 
            this.lbl_filename.AutoSize = true;
            this.lbl_filename.Location = new System.Drawing.Point(23, 86);
            this.lbl_filename.Name = "lbl_filename";
            this.lbl_filename.Size = new System.Drawing.Size(0, 0);
            this.lbl_filename.TabIndex = 3;
            // 
            // FileDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(482, 179);
            this.Controls.Add(this.lbl_filename);
            this.Controls.Add(this.lbl_persent);
            this.Controls.Add(this.lbl_persentNum);
            this.Controls.Add(this.progressbar_download);
            this.MaximizeBox = false;
            this.Name = "FileDownloadForm";
            this.Resizable = false;
            this.Text = "파일 다운로드";
            this.Load += new System.EventHandler(this.FileDownloadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroProgressBar progressbar_download;
        private MetroFramework.Controls.MetroLabel lbl_persentNum;
        private MetroFramework.Controls.MetroLabel lbl_persent;
        private MetroFramework.Controls.MetroLabel lbl_filename;
    }
}