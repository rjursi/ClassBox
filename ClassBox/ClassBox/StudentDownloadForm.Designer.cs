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
            this.components = new System.ComponentModel.Container();
            this.panel_filelist = new System.Windows.Forms.FlowLayoutPanel();
            this.timer_fileListRefresh = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // panel_filelist
            // 
            this.panel_filelist.Location = new System.Drawing.Point(23, 81);
            this.panel_filelist.Name = "panel_filelist";
            this.panel_filelist.Size = new System.Drawing.Size(811, 412);
            this.panel_filelist.TabIndex = 1;
            // 
            // timer_fileListRefresh
            // 
            this.timer_fileListRefresh.Interval = 500;
            this.timer_fileListRefresh.Tick += new System.EventHandler(this.timer_fileListRefresh_Tick);
            // 
            // StudentDownloadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(857, 527);
            this.Controls.Add(this.panel_filelist);
            this.Name = "StudentDownloadForm";
            this.Text = "파일 다운로드";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.StudentDownloadForm_FormClosing);
            this.Load += new System.EventHandler(this.StudentDownloadForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.FlowLayoutPanel panel_filelist;
        public System.Windows.Forms.Timer timer_fileListRefresh;
    }
}