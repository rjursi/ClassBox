namespace ClassBox
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_createRoom = new MetroFramework.Controls.MetroButton();
            this.roomListPanel = new System.Windows.Forms.FlowLayoutPanel();
            this.btn_Logout = new MetroFramework.Controls.MetroButton();
            this.lbl_username = new MetroFramework.Controls.MetroLabel();
            this.btn_refreshRoom = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // btn_createRoom
            // 
            this.btn_createRoom.Location = new System.Drawing.Point(660, 114);
            this.btn_createRoom.Name = "btn_createRoom";
            this.btn_createRoom.Size = new System.Drawing.Size(117, 32);
            this.btn_createRoom.TabIndex = 2;
            this.btn_createRoom.Text = "방 생성";
            this.btn_createRoom.Visible = false;
            this.btn_createRoom.Click += new System.EventHandler(this.btn_createRoom_Click);
            // 
            // roomListPanel
            // 
            this.roomListPanel.Location = new System.Drawing.Point(40, 152);
            this.roomListPanel.Name = "roomListPanel";
            this.roomListPanel.Size = new System.Drawing.Size(737, 275);
            this.roomListPanel.TabIndex = 3;
            // 
            // btn_Logout
            // 
            this.btn_Logout.Location = new System.Drawing.Point(702, 72);
            this.btn_Logout.Name = "btn_Logout";
            this.btn_Logout.Size = new System.Drawing.Size(75, 23);
            this.btn_Logout.TabIndex = 4;
            this.btn_Logout.Text = "로그아웃";
            this.btn_Logout.Click += new System.EventHandler(this.btn_Logout_Click);
            // 
            // lbl_username
            // 
            this.lbl_username.AutoSize = true;
            this.lbl_username.Location = new System.Drawing.Point(610, 43);
            this.lbl_username.Name = "lbl_username";
            this.lbl_username.Size = new System.Drawing.Size(82, 19);
            this.lbl_username.TabIndex = 5;
            this.lbl_username.Text = "안녕하세요.";
            this.lbl_username.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // btn_refreshRoom
            // 
            this.btn_refreshRoom.Location = new System.Drawing.Point(543, 114);
            this.btn_refreshRoom.Name = "btn_refreshRoom";
            this.btn_refreshRoom.Size = new System.Drawing.Size(111, 32);
            this.btn_refreshRoom.TabIndex = 6;
            this.btn_refreshRoom.Text = "새로고침";
            this.btn_refreshRoom.Click += new System.EventHandler(this.btn_refreshRoom_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btn_refreshRoom);
            this.Controls.Add(this.lbl_username);
            this.Controls.Add(this.btn_Logout);
            this.Controls.Add(this.roomListPanel);
            this.Controls.Add(this.btn_createRoom);
            this.MinimizeBox = false;
            this.Name = "MainForm";
            this.Resizable = false;
            this.Text = "방 목록";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_createRoom;
        private System.Windows.Forms.FlowLayoutPanel roomListPanel;
        private MetroFramework.Controls.MetroButton btn_Logout;
        private MetroFramework.Controls.MetroLabel lbl_username;
        private MetroFramework.Controls.MetroButton btn_refreshRoom;
    }
}

