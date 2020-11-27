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
       
        UserDTO userDTO; // 여기서 Accessno 에 따라 할 수 있는 역할이 달라짐
        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            this.Visible = false;
            using(LoginForm loginForm = new LoginForm())
            {
                var dialogResult = loginForm.ShowDialog(); // 로그인 창이 닫히면 결과 값을 가져옴

                if(dialogResult == DialogResult.OK)
                {
                    this.userDTO = loginForm.GetUserDTO(); // 로그인 시 해당 사용자의 정보를 가져옴
                    this.Visible = true;

                    if (this.userDTO.Accessno == 1)
                    {
                        this.btn_createRoom.Visible = true;
                        this.lbl_username.Text = $"안녕하세요. {this.userDTO.Name} 님 ";
                    }else if(this.userDTO.Accessno == 2)
                    {
                        this.lbl_username.Text = $"안녕하세요. {this.userDTO.Name} 학생 ";
                    }
                }

                else if(dialogResult == DialogResult.Cancel) // 로그인 안하고 그냥 꺼버릴 경우
                {
                    Application.Exit();
                }
                
            }
        }


        private void GetAllRoomList()
        {
            // 처음 학생이든 교수자든 접속시 모든 방의 목록을 가져오는 함수


        }
        private void btn_createRoom_Click(object sender, EventArgs e)
        {
            // 방을 생성하는 경우는 교수자만 생성이 가능하므로 해당 로직은 교수자 방 생성 로직


            CreateRoom createRoomForm = new CreateRoom(this.userDTO);
            var result = createRoomForm.ShowDialog();

            
            if(result == DialogResult.OK)
            {
                MetroTile tile = new MetroTile();

                RoomDTO roomDTO = createRoomForm.GetRoomDTO();

                tile.Width = 141;
                tile.Height = 86;

                tile.Name = $"roomTile_{roomDTO.No}_{roomDTO.Name}";

                tile.Text = roomDTO.Name;

                tile.Click += new EventHandler(this.roomTile_Click); // 방 생성시 학생이 입장이 가능하도록 이벤트 핸들러 설정
                this.roomListPanel.Controls.Add(tile);

                MessageBox.Show("방이 생성되었습니다.", "방 생성 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (ProfessorUploadForm professorUploadForm = new ProfessorUploadForm())
                {
                    var professorFormResult = professorUploadForm.ShowDialog();

                    if(professorFormResult == DialogResult.OK)
                    {
                        this.roomListPanel.Controls.Remove(tile); // 내가 만든 것만 컨트롤을 지워버림
                    }
                }
            }
            
        }

        private void roomTile_Click(object sender, EventArgs e)
        {
            // 해당 타일을 클릭하는 경우, 즉 학생이 접속하는 경우에 해당
        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }
    }
}
