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
using MetroFramework.Controls;
namespace ClassBox
{
    public partial class MainForm : MetroForm
    {
        DBConnect dbconn;
        UserDTO userDTO;
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            using(LoginForm loginForm = new LoginForm())
            {
                var dialogResult = loginForm.ShowDialog(); // 로그인 창이 닫히면 결과 값을 가져옴

                this.userDTO = loginForm.GetUserDTO(); // 로그인 시 해당 사용자의 정보를 가져옴
            }
        }

        private void btn_createRoom_Click(object sender, EventArgs e)
        {

            CreateRoom createRoomForm = new CreateRoom();
            createRoomForm.ShowDialog();

            MetroButton button = new MetroButton();
            roomListPanel.Controls.Add(button);
        }
    }
}
