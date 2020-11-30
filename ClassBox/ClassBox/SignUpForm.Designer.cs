namespace ClassBox
{
    partial class SignUpForm
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
            this.btn_signUp = new MetroFramework.Controls.MetroButton();
            this.txtbox_password = new MetroFramework.Controls.MetroTextBox();
            this.lbl_password = new MetroFramework.Controls.MetroLabel();
            this.txtbox_id = new MetroFramework.Controls.MetroTextBox();
            this.lbl_id = new MetroFramework.Controls.MetroLabel();
            this.txtbox_name = new MetroFramework.Controls.MetroTextBox();
            this.lbl_name = new MetroFramework.Controls.MetroLabel();
            this.radio_professor = new MetroFramework.Controls.MetroRadioButton();
            this.radio_stu = new MetroFramework.Controls.MetroRadioButton();
            this.lbl_userType = new MetroFramework.Controls.MetroLabel();
            this.panel_userType = new MetroFramework.Controls.MetroPanel();
            this.panel_userType.SuspendLayout();
            this.SuspendLayout();
            // 
            // btn_signUp
            // 
            this.btn_signUp.Location = new System.Drawing.Point(28, 321);
            this.btn_signUp.Name = "btn_signUp";
            this.btn_signUp.Size = new System.Drawing.Size(299, 39);
            this.btn_signUp.TabIndex = 11;
            this.btn_signUp.Text = "회원가입";
            this.btn_signUp.Click += new System.EventHandler(this.btn_signUp_Click);
            // 
            // txtbox_password
            // 
            this.txtbox_password.Location = new System.Drawing.Point(99, 180);
            this.txtbox_password.Name = "txtbox_password";
            this.txtbox_password.PasswordChar = '*';
            this.txtbox_password.Size = new System.Drawing.Size(228, 23);
            this.txtbox_password.TabIndex = 9;
            // 
            // lbl_password
            // 
            this.lbl_password.AutoSize = true;
            this.lbl_password.Location = new System.Drawing.Point(28, 180);
            this.lbl_password.Name = "lbl_password";
            this.lbl_password.Size = new System.Drawing.Size(65, 19);
            this.lbl_password.TabIndex = 8;
            this.lbl_password.Text = "비밀번호";
            // 
            // txtbox_id
            // 
            this.txtbox_id.Location = new System.Drawing.Point(99, 86);
            this.txtbox_id.Name = "txtbox_id";
            this.txtbox_id.Size = new System.Drawing.Size(228, 23);
            this.txtbox_id.TabIndex = 7;
            // 
            // lbl_id
            // 
            this.lbl_id.AutoSize = true;
            this.lbl_id.Location = new System.Drawing.Point(28, 90);
            this.lbl_id.Name = "lbl_id";
            this.lbl_id.Size = new System.Drawing.Size(51, 19);
            this.lbl_id.TabIndex = 6;
            this.lbl_id.Text = "아이디";
            // 
            // txtbox_name
            // 
            this.txtbox_name.Location = new System.Drawing.Point(99, 132);
            this.txtbox_name.Name = "txtbox_name";
            this.txtbox_name.Size = new System.Drawing.Size(228, 23);
            this.txtbox_name.TabIndex = 13;
            // 
            // lbl_name
            // 
            this.lbl_name.AutoSize = true;
            this.lbl_name.Location = new System.Drawing.Point(28, 136);
            this.lbl_name.Name = "lbl_name";
            this.lbl_name.Size = new System.Drawing.Size(37, 19);
            this.lbl_name.TabIndex = 12;
            this.lbl_name.Text = "이름";
            // 
            // radio_professor
            // 
            this.radio_professor.AutoSize = true;
            this.radio_professor.Checked = true;
            this.radio_professor.Location = new System.Drawing.Point(30, 46);
            this.radio_professor.Name = "radio_professor";
            this.radio_professor.Size = new System.Drawing.Size(59, 15);
            this.radio_professor.TabIndex = 14;
            this.radio_professor.TabStop = true;
            this.radio_professor.Text = "교수자";
            this.radio_professor.UseVisualStyleBackColor = true;
            // 
            // radio_stu
            // 
            this.radio_stu.AutoSize = true;
            this.radio_stu.Location = new System.Drawing.Point(160, 46);
            this.radio_stu.Name = "radio_stu";
            this.radio_stu.Size = new System.Drawing.Size(59, 15);
            this.radio_stu.TabIndex = 14;
            this.radio_stu.Text = "학습자";
            this.radio_stu.UseVisualStyleBackColor = true;
            // 
            // lbl_userType
            // 
            this.lbl_userType.AutoSize = true;
            this.lbl_userType.Location = new System.Drawing.Point(83, 14);
            this.lbl_userType.Name = "lbl_userType";
            this.lbl_userType.Size = new System.Drawing.Size(83, 19);
            this.lbl_userType.TabIndex = 15;
            this.lbl_userType.Text = "사용자 유형";
            // 
            // panel_userType
            // 
            this.panel_userType.Controls.Add(this.lbl_userType);
            this.panel_userType.Controls.Add(this.radio_stu);
            this.panel_userType.Controls.Add(this.radio_professor);
            this.panel_userType.HorizontalScrollbarBarColor = true;
            this.panel_userType.HorizontalScrollbarHighlightOnWheel = false;
            this.panel_userType.HorizontalScrollbarSize = 10;
            this.panel_userType.Location = new System.Drawing.Point(55, 232);
            this.panel_userType.Name = "panel_userType";
            this.panel_userType.Size = new System.Drawing.Size(249, 79);
            this.panel_userType.TabIndex = 16;
            this.panel_userType.VerticalScrollbarBarColor = true;
            this.panel_userType.VerticalScrollbarHighlightOnWheel = false;
            this.panel_userType.VerticalScrollbarSize = 10;
            // 
            // SignUpForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(361, 383);
            this.Controls.Add(this.panel_userType);
            this.Controls.Add(this.txtbox_name);
            this.Controls.Add(this.lbl_name);
            this.Controls.Add(this.btn_signUp);
            this.Controls.Add(this.txtbox_password);
            this.Controls.Add(this.lbl_password);
            this.Controls.Add(this.txtbox_id);
            this.Controls.Add(this.lbl_id);
            this.Name = "SignUpForm";
            this.Text = "회원가입";
            this.panel_userType.ResumeLayout(false);
            this.panel_userType.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private MetroFramework.Controls.MetroButton btn_signUp;
        private MetroFramework.Controls.MetroTextBox txtbox_password;
        private MetroFramework.Controls.MetroLabel lbl_password;
        private MetroFramework.Controls.MetroTextBox txtbox_id;
        private MetroFramework.Controls.MetroLabel lbl_id;
        private MetroFramework.Controls.MetroTextBox txtbox_name;
        private MetroFramework.Controls.MetroLabel lbl_name;
        private MetroFramework.Controls.MetroRadioButton radio_professor;
        private MetroFramework.Controls.MetroRadioButton radio_stu;
        private MetroFramework.Controls.MetroLabel lbl_userType;
        private MetroFramework.Controls.MetroPanel panel_userType;
    }
}