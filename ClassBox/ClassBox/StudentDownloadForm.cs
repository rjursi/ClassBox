using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Controls;
using MetroFramework.Forms;
namespace ClassBox
{
    public partial class StudentDownloadForm : MetroForm
    {
        private UserDTO userDTO;
        private RoomDTO joinRoomDTO;
        private ClientSocketWork clientSocketWork;

        public delegate void Delegate_FormClose();
        public Delegate_FormClose delegate_FormClose;


        public StudentDownloadForm(UserDTO userDTO, RoomDTO joinRoomDTO)
        {
            InitializeComponent();
            this.userDTO = userDTO; // 학생 정보를 가지고 옴
            this.joinRoomDTO = joinRoomDTO;
        }

        private void StudentDownloadForm_Load(object sender, EventArgs e)
        {
            clientSocketWork = new ClientSocketWork(userDTO, this);

            clientSocketWork.ServerIP = joinRoomDTO.IpAddress; // 접속하고자 하는 방에 들어감
            clientSocketWork.SocketConnection();
            
        }

        private void btn_refresh_Click(object sender, EventArgs e)
        {
            clientSocketWork.RequestRefresh();
        }


        private MetroTile CreateFileTile(string fileName)
        {
            MetroTile tile = new MetroTile();

            tile.Width = 141;
            tile.Height = 86;

            tile.Name = fileName;
            tile.Text = fileName;

            return tile;
        }


        public void FileListRefresh(string receivedFileList)
        {
            List<string> fileList = new List<string>();

            string[] receivedFileNameArr = receivedFileList.Split(',');
            int arrCnt = receivedFileNameArr.Length - 1;
            fileList = receivedFileNameArr.ToList<string>();


            this.panel_filelist.Controls.Clear();
            foreach(string fileName in fileList)
            {
                int index = fileList.IndexOf(fileName);
                if (index != arrCnt)
                {
                    MetroTile newTile = CreateFileTile(fileName);

                    this.panel_filelist.Controls.Add(newTile);
                }
            }
        }
        private void StudentDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientSocketWork.RequestSocketClose();
        }
    }
}
