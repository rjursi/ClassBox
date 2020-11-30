using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
namespace ClassBox
{
    public partial class LoginForm : MetroForm
    {
        private UserDTO userDTO;
        private UserDAO userDAO;
        
       
        public UserDTO GetUserDTO()
        {
            return this.userDTO;
        }
        
        public LoginForm()
        {
            InitializeComponent();
        }

     

        private void btn_login_Click(object sender, EventArgs e)
        {
            this.userDTO = new UserDTO();
            this.userDAO = new UserDAO();

            userDTO.Id = this.txtbox_id.Text;
            userDTO.Password = this.txtbox_password.Text;


            this.userDTO = userDAO.Login(userDTO);

            if (this.userDTO.Name.Equals("")) {
                MessageBox.Show("존재하지 않는 아이디 이거나 패스워드를 잘못 입력하셨습니다.", "로그인 실패", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show($"{userDTO.Name} 님 환영합니다","로그인", MessageBoxButtons.OK, MessageBoxIcon.Information);


                this.DialogResult = DialogResult.OK;
                this.Close();
            }
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {
            using (SignUpForm signUpForm = new SignUpForm())
            {
                signUpForm.ShowDialog();
            }
        }

        private void LoginForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            if(this.DialogResult != DialogResult.OK)
            {
                this.DialogResult = DialogResult.Cancel;
            }
        }
    }
}
