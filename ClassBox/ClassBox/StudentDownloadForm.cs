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
    public partial class StudentDownloadForm : MetroForm
    {
        private UserDTO userDTO;
        private RoomDTO joinRoomDTO;
        private ClientSocketWork clientSocketWork;

        public StudentDownloadForm(UserDTO userDTO, RoomDTO joinRoomDTO)
        {
            InitializeComponent();
            this.userDTO = userDTO; // 학생 정보를 가지고 옴
            this.joinRoomDTO = joinRoomDTO;
        }

        private void StudentDownloadForm_Load(object sender, EventArgs e)
        {
            clientSocketWork = new ClientSocketWork(userDTO);

            clientSocketWork.ServerIP = joinRoomDTO.IpAddress; // 접속하고자 하는 방에 들어감
            clientSocketWork.SocketConnection();
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {

        }

        private void StudentDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientSocketWork.RequestSocketClose();
        }
    }
}
