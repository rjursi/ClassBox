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
            this.components = new System.ComponentModel.Container();
            this.panel_fileList = new System.Windows.Forms.FlowLayoutPanel();
            this.scrollbar_fileList = new MetroFramework.Controls.MetroScrollBar();
            this.listbox_stuList = new System.Windows.Forms.ListBox();
            this.lbl_userList = new MetroFramework.Controls.MetroLabel();
            this.btn_fileUpload = new MetroFramework.Controls.MetroButton();
            this.timer_stuListUpdate = new System.Windows.Forms.Timer(this.components);
            this.fileDlg_selectFile = new System.Windows.Forms.OpenFileDialog();
            this.timer_fileListUpdate = new System.Windows.Forms.Timer(this.components);
            this.metroLabel1 = new MetroFramework.Controls.MetroLabel();
            this.tooltip_filename = new MetroFramework.Components.MetroToolTip();
            this.panel_fileList.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel_fileList
            // 
            this.panel_fileList.AllowDrop = true;
            this.panel_fileList.AutoScroll = true;
            this.panel_fileList.Controls.Add(this.scrollbar_fileList);
            this.panel_fileList.Location = new System.Drawing.Point(176, 127);
            this.panel_fileList.Name = "panel_fileList";
            this.panel_fileList.Size = new System.Drawing.Size(773, 364);
            this.panel_fileList.TabIndex = 0;
            this.panel_fileList.DragDrop += new System.Windows.Forms.DragEventHandler(this.panel_fileList_DragDrop);
            this.panel_fileList.DragEnter += new System.Windows.Forms.DragEventHandler(this.panel_fileList_DragEnter);
            // 
            // scrollbar_fileList
            // 
            this.scrollbar_fileList.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.scrollbar_fileList.Location = new System.Drawing.Point(3, 3);
            this.scrollbar_fileList.Name = "scrollbar_fileList";
            this.scrollbar_fileList.Orientation = MetroFramework.Controls.MetroScrollOrientation.Horizontal;
            this.scrollbar_fileList.ScrollbarSize = 2;
            this.scrollbar_fileList.Size = new System.Drawing.Size(200, 2);
            this.scrollbar_fileList.TabIndex = 0;
            // 
            // listbox_stuList
            // 
            this.listbox_stuList.Font = new System.Drawing.Font("굴림", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(129)));
            this.listbox_stuList.FormattingEnabled = true;
            this.listbox_stuList.ItemHeight = 21;
            this.listbox_stuList.Location = new System.Drawing.Point(23, 127);
            this.listbox_stuList.Name = "listbox_stuList";
            this.listbox_stuList.Size = new System.Drawing.Size(147, 361);
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
            this.btn_fileUpload.Location = new System.Drawing.Point(832, 86);
            this.btn_fileUpload.Name = "btn_fileUpload";
            this.btn_fileUpload.Size = new System.Drawing.Size(89, 35);
            this.btn_fileUpload.Style = MetroFramework.MetroColorStyle.Lime;
            this.btn_fileUpload.TabIndex = 3;
            this.btn_fileUpload.Text = "파일 업로드";
            this.btn_fileUpload.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btn_fileUpload.Click += new System.EventHandler(this.btn_fileUpload_Click);
            // 
            // timer_stuListUpdate
            // 
            this.timer_stuListUpdate.Tick += new System.EventHandler(this.timer_stuListUpdate_Tick);
            // 
            // fileDlg_selectFile
            // 
            this.fileDlg_selectFile.FileName = "openFileDialog1";
            // 
            // timer_fileListUpdate
            // 
            this.timer_fileListUpdate.Tick += new System.EventHandler(this.timer_fileListUpdate_Tick);
            // 
            // metroLabel1
            // 
            this.metroLabel1.AutoSize = true;
            this.metroLabel1.Location = new System.Drawing.Point(200, 95);
            this.metroLabel1.Name = "metroLabel1";
            this.metroLabel1.Size = new System.Drawing.Size(244, 19);
            this.metroLabel1.TabIndex = 4;
            this.metroLabel1.Text = "* 파일을 클릭하면 삭제가 가능합니다.";
            // 
            // ProfessorUploadForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(972, 514);
            this.Controls.Add(this.metroLabel1);
            this.Controls.Add(this.btn_fileUpload);
            this.Controls.Add(this.lbl_userList);
            this.Controls.Add(this.listbox_stuList);
            this.Controls.Add(this.panel_fileList);
            this.MaximizeBox = false;
            this.Name = "ProfessorUploadForm";
            this.Resizable = false;
            this.Text = "파일 공유 관리";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.ProfessorUploadForm_FormClosing);
            this.Load += new System.EventHandler(this.ProfessorUploadForm_Load);
            this.panel_fileList.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel panel_fileList;
        private System.Windows.Forms.ListBox listbox_stuList;
        private MetroFramework.Controls.MetroLabel lbl_userList;
        private MetroFramework.Controls.MetroButton btn_fileUpload;
        private System.Windows.Forms.Timer timer_stuListUpdate;
        private System.Windows.Forms.OpenFileDialog fileDlg_selectFile;
        private System.Windows.Forms.Timer timer_fileListUpdate;
        private MetroFramework.Controls.MetroLabel metroLabel1;
        private MetroFramework.Controls.MetroScrollBar scrollbar_fileList;
        private MetroFramework.Components.MetroToolTip tooltip_filename;
    }
}