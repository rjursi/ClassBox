namespace ClassBox
{
    partial class StudentDownloadForm
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
            this.btn_refresh = new MetroFramework.Controls.MetroButton();
            this.panel_filelist = new System.Windows.Forms.FlowLayoutPanel();
            this.SuspendLayout();
            // 
            // btn_refresh
            // 
            this.btn_refresh.Location = new System.Drawing.Point(722, 63);
            this.btn_refresh.Name = "btn_refresh";
            this.btn_refresh.Size = new System.Drawing.Size(112, 47);
            this.btn_refresh.TabIndex = 0;
            this.btn_refresh.Text = "목록 새로고침";
            this.btn_refresh.Click += new System.EventHandler(this.btn_refresh_Click);
            // 
            // panel_filelist
            // 
            this.panel_filelist.Location = new System.Drawing.Point(23, 127);
            this.panel_filelist.Name = "panel_filelist";
            this.panel_filelist.Size = new System.Drawing.Size(811, 366);
            this.panel_filelist.TabIndex = 1;
            // 
            // StudentDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 527);
            this.Controls.Add(this.panel_filelist);
            this.Controls.Add(this.btn_refresh);
            this.Name = "StudentDownloadForm";
            this.Text = "파일 다운로드";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentDownloadForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentDownloadForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_refresh;
        private System.Windows.Forms.FlowLayoutPanel panel_filelist;
    }
}