namespace ClassBox
{
    partial class CreateRoom
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
            this.lbl_roomName = new MetroFramework.Controls.MetroLabel();
            this.txtbox_roomName = new MetroFramework.Controls.MetroTextBox();
            this.btn_createRoom = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lbl_roomName
            // 
            this.lbl_roomName.AutoSize = true;
            this.lbl_roomName.Location = new System.Drawing.Point(43, 91);
            this.lbl_roomName.Name = "lbl_roomName";
            this.lbl_roomName.Size = new System.Drawing.Size(55, 19);
            this.lbl_roomName.TabIndex = 0;
            this.lbl_roomName.Text = "방 이름";
            // 
            // txtbox_roomName
            // 
            this.txtbox_roomName.Location = new System.Drawing.Point(122, 91);
            this.txtbox_roomName.Name = "txtbox_roomName";
            this.txtbox_roomName.Size = new System.Drawing.Size(237, 23);
            this.txtbox_roomName.TabIndex = 1;
            // 
            // btn_createRoom
            // 
            this.btn_createRoom.Location = new System.Drawing.Point(43, 139);
            this.btn_createRoom.Name = "btn_createRoom";
            this.btn_createRoom.Size = new System.Drawing.Size(316, 42);
            this.btn_createRoom.TabIndex = 2;
            this.btn_createRoom.Text = "방 생성";
            this.btn_createRoom.Click += new System.EventHandler(this.btn_createRoom_Click);
            // 
            // CreateRoom
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(411, 215);
            this.Controls.Add(this.btn_createRoom);
            this.Controls.Add(this.txtbox_roomName);
            this.Controls.Add(this.lbl_roomName);
            this.Name = "CreateRoom";
            this.Text = "방 생성";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lbl_roomName;
        private MetroFramework.Controls.MetroTextBox txtbox_roomName;
        private MetroFramework.Controls.MetroButton btn_createRoom;
    }
}