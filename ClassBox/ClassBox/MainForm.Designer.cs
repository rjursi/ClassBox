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
            this.SuspendLayout();
            // 
            // btn_createRoom
            // 
            this.btn_createRoom.Location = new System.Drawing.Point(660, 63);
            this.btn_createRoom.Name = "btn_createRoom";
            this.btn_createRoom.Size = new System.Drawing.Size(117, 32);
            this.btn_createRoom.TabIndex = 2;
            this.btn_createRoom.Text = "방 생성";
            this.btn_createRoom.Click += new System.EventHandler(this.btn_createRoom_Click);
            // 
            // roomListPanel
            // 
            this.roomListPanel.Location = new System.Drawing.Point(23, 120);
            this.roomListPanel.Name = "roomListPanel";
            this.roomListPanel.Size = new System.Drawing.Size(754, 307);
            this.roomListPanel.TabIndex = 3;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.roomListPanel);
            this.Controls.Add(this.btn_createRoom);
            this.Name = "MainForm";
            this.Text = "방 목록";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_createRoom;
        private System.Windows.Forms.FlowLayoutPanel roomListPanel;
    }
}

