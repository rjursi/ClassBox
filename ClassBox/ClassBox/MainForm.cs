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
using System.Collections;

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

                    this.ShowAllRoomList(); // 기존에 데이터베이스에 저장되어있는 방 리스트를 가져옴
                }

                else if(dialogResult == DialogResult.Cancel) // 로그인 안하고 그냥 꺼버릴 경우
                {
                    Application.Exit();
                }
                
            }
        }


        private void ShowAllRoomList()
        {
            // 처음 학생이든 교수자든 접속시 모든 방의 목록을 가져오는 함수
            this.roomListPanel.Controls.Clear();

            RoomDAO roomDAO = new RoomDAO();
            ArrayList roomList = roomDAO.GetAllRoomList();

            foreach(RoomDTO roomDTO in roomList)
            {

                MetroTile tile = new MetroTile();

                tile.Width = 141;
                tile.Height = 86;

                tile.Name = $"roomTile_{roomDTO.No}_{roomDTO.Name}";

                tile.Text = roomDTO.Name;

                tile.Click += new EventHandler(this.roomTile_Click); // 방 생성시 학생이 입장이 가능하도록 이벤트 핸들러 설정
                this.roomListPanel.Controls.Add(tile);
            }
            

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

                // MessageBox.Show("방이 생성되었습니다.", "방 생성 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

                using (ProfessorUploadForm professorUploadForm = new ProfessorUploadForm())
                {
                    var professorFormResult = professorUploadForm.ShowDialog();
                    // 사용이 끝나고 나면 해당 방이 없어지는 구조

                    if(professorFormResult == DialogResult.OK)
                    {
                        this.roomListPanel.Controls.Remove(tile); // 내가 만든 것만 컨트롤을 지워버림

                        RoomDAO roomDAO = new RoomDAO();
                        roomDAO.RemoveRoom(roomDTO); // 데이터베이스 상에서도 지워버림
                        
                    }
                }
            }
            
        }

        private void roomTile_Click(object sender, EventArgs e)
        {
            // 해당 타일을 클릭하는 경우, 즉 학생이 접속하는 경우에 해당
            Button joinRoom_tile = (MetroTile)sender;
            int joinRoomNo = Int32.Parse(joinRoom_tile.Name.Split('_')[1]); // 클릭한 타일의 Name 값에 방 번호가 저장되어 있음
            if(this.userDTO.Accessno == 1) // 교수는 다른 방에 들어가지 못하도록 우선적으로 막음, 일단은...
            {
                MessageBox.Show("학생만 다른 방에 들어갈 수 있습니다.", "방 들어가기", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            DialogResult stuFormResult;
            RoomDAO roomDAO = new RoomDAO();
            RoomDTO joinRoomDTO = new RoomDTO();

            joinRoomDTO = roomDAO.GetJoinRoomDTO(joinRoomNo);

            using (StudentDownloadForm studentDownloadForm = new StudentDownloadForm(userDTO, joinRoomDTO))
            {
                stuFormResult = studentDownloadForm.ShowDialog();
            }
            // 학생이 방에 들어가는 로직을 만들어야 함.
            // 여기는 학생이 로그인 시 userDTO를 같이 넘겨줘야함

        }

        private void btn_Logout_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void btn_refreshRoom_Click(object sender, EventArgs e)
        {
            ShowAllRoomList();
        }
    }
}
