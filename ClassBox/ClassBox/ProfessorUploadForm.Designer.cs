namespace ClassBox
{
    partial class ProfessorUploadForm
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
            this.panel_fileList = new System.Windows.Forms.FlowLayoutPanel();
            this.listbox_stuList = new System.Windows.Forms.ListBox();
            this.lbl_userList = new MetroFramework.Controls.MetroLabel();
            this.btn_fileUpload = new MetroFramework.Controls.MetroButton();
            this.btn_fileDelete = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // panel_fileList
            // 
            this.panel_fileList.Location = new System.Drawing.Point(200, 127);
            this.panel_fileList.Name = "panel_fileList";
            this.panel_fileList.Size = new System.Drawing.Size(661, 364);
            this.panel_fileList.TabIndex = 0;
            // 
            // listbox_stuList
            // 
            this.listbox_stuList.FormattingEnabled = true;
            this.listbox_stuList.ItemHeight = 12;
            this.listbox_stuList.Location = new System.Drawing.Point(23, 127);
            this.listbox_stuList.Name = "listbox_stuList";
            this.listbox_stuList.Size = new System.Drawing.Size(162, 364);
            this.listbox_stuList.TabIndex = 1;
            // 
            // lbl_userList
            // 
            this.lbl_userList.AutoSize = true;
            this.lbl_userList.FontSize = MetroFramework.MetroLabelSize.Tall;
            this.lbl_userList.Location = new System.Drawing.Point(23, 89);
            this.lbl_userList.Name = "lbl_userList";
            this.lbl_userList.Size = new System.Drawing.Size(107, 25);
            this.lbl_userList.TabIndex = 2;
            this.lbl_userList.Text = "접속자 목록";
            // 
            // btn_fileUpload
            // 
            this.btn_fileUpload.Location = new System.Drawing.Point(603, 86);
            this.btn_fileUpload.Name = "btn_fileUpload";
            this.btn_fileUpload.Size = new System.Drawing.Size(125, 35);
            this.btn_fileUpload.TabIndex = 3;
            this.btn_fileUpload.Text = "파일 업로드";
            // 
            // btn_fileDelete
            // 
            this.btn_fileDelete.Location = new System.Drawing.Point(734, 86);
            this.btn_fileDelete.Name = "btn_fileDelete";
            this.btn_fileDelete.Size = new System.Drawing.Size(127, 35);
            this.btn_fileDelete.TabIndex = 3;
            this.btn_fileDelete.Text = "파일 삭제";
            // 
            // ProfessorUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(884, 514);
            this.Controls.Add(this.btn_fileDelete);
            this.Controls.Add(this.btn_fileUpload);
            this.Controls.Add(this.lbl_userList);
            this.Controls.Add(this.listbox_stuList);
            this.Controls.Add(this.panel_fileList);
            this.Name = "ProfessorUploadForm";
            this.Text = "파일 공유 관리";
            this.Load += new System.EventHandler(this.ProfessorUploadForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel_fileList;
        private System.Windows.Forms.ListBox listbox_stuList;
        private MetroFramework.Controls.MetroLabel lbl_userList;
        private MetroFramework.Controls.MetroButton btn_fileUpload;
        private MetroFramework.Controls.MetroButton btn_fileDelete;
    }
}