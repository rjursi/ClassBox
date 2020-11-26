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
    public partial class SignUpForm : MetroForm
    {
        private UserDTO userDTO;
      
        public UserDTO GetUserDTO()
        {
            return this.userDTO;
        }
        public SignUpForm()
        {
            InitializeComponent();
        }

        private void btn_signUp_Click(object sender, EventArgs e)
        {

            userDTO = new UserDTO();

            if(this.txtbox_id.Text.Equals(""))
            {
                MessageBox.Show("사용할 ID를 입력하지 않으셨습니다.", "알림",MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtbox_password.Text.Equals(""))
            {
                MessageBox.Show("사용할 패스워드를 입력하지 않으셨습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
            if (this.txtbox_name.Text.Equals(""))
            {
                MessageBox.Show("사용할 이름을 입력하지 않으셨습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            this.userDTO.Id = this.txtbox_id.Text;
            this.userDTO.Password = this.txtbox_password.Text;
            this.userDTO.Name = this.txtbox_name.Text;

            if (radio_professor.Checked)
            {
                this.userDTO.Accessno = 1;
            }else if (radio_stu.Checked)
            {
                this.userDTO.Accessno = 2;
            }
            

            UserDAO userDAO = new UserDAO();

            bool result = userDAO.SignUp(this.userDTO);

            if (result) // 아이디가 중복되지 않으면
            {
                MessageBox.Show("회원 가입이 완료되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            else
            {
                MessageBox.Show("아이디가 중복되었습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            
        }

        
    }
}
