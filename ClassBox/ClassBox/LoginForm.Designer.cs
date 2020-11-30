namespace ClassBox
{
    partial class LoginForm
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
            this.lbl_id = new MetroFramework.Controls.MetroLabel();
            this.txtbox_id = new MetroFramework.Controls.MetroTextBox();
            this.lbl_password = new MetroFramework.Controls.MetroLabel();
            this.txtbox_password = new MetroFramework.Controls.MetroTextBox();
            this.btn_login = new MetroFramework.Controls.MetroButton();
            this.btn_signUp = new MetroFramework.Controls.MetroButton();
            this.SuspendLayout();
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(35, 101);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(51, 19);
            this.lbl_id.TabIndex = 0;
            this.lbl_id.Text = "아이디";
            // 
            // txtbox_id
            // 
            this.txtbox_id.Location = new System.Drawing.Point(106, 97);
            this.txtbox_id.Name = "txtbox_id";
            this.txtbox_id.Size = new System.Drawing.Size(228, 23);
            this.txtbox_id.TabIndex = 1;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(35, 152);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(65, 19);
            this.lbl_password.TabIndex = 2;
            this.lbl_password.Text = "비밀번호";
            // 
            // txtbox_password
            // 
            this.txtbox_password.Location = new System.Drawing.Point(106, 152);
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.PasswordChar = '*';
            this.txtbox_password.Size = new System.Drawing.Size(228, 23);
            this.txtbox_password.TabIndex = 3;
            // 
            // btn_login
            // 
            this.btn_login.Location = new System.Drawing.Point(35, 212);
            this.btn_login.Name = "btn_login";
            this.btn_login.Size = new System.Drawing.Size(135, 39);
            this.btn_login.TabIndex = 4;
            this.btn_login.Text = "로그인";
            this.btn_login.Theme = MetroFramework.MetroThemeStyle.Light;
            this.btn_login.Click += new System.EventHandler(this.btn_login_Click);
            // 
            // btn_signUp
            // 
            this.btn_signUp.Location = new System.Drawing.Point(199, 212);
            this.btn_signUp.Name = "btn_signUp";
            this.btn_signUp.Size = new System.Drawing.Size(135, 39);
            this.btn_signUp.TabIndex = 5;
            this.btn_signUp.Text = "회원가입";
            this.btn_signUp.Click += new System.EventHandler(this.btn_signUp_Click);
            // 
            // LoginForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(369, 283);
            this.Controls.Add(this.btn_signUp);
            this.Controls.Add(this.btn_login);
            this.Controls.Add(this.txtbox_password);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txtbox_id);
            this.Controls.Add(this.lbl_id);
            this.Name = "LoginForm";
            this.Text = " 로그인";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.LoginForm_FormClosing);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroLabel lbl_id;
        private MetroFramework.Controls.MetroTextBox txtbox_id;
        private MetroFramework.Controls.MetroLabel lbl_password;
        private MetroFramework.Controls.MetroTextBox txtbox_password;
        private MetroFramework.Controls.MetroButton btn_login;
        private MetroFramework.Controls.MetroButton btn_signUp;
    }
}