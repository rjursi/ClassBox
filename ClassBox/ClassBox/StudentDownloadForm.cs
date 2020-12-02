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

        public FileDownloadForm fileDownloadForm;
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

            this.timer_fileListRefresh.Enabled = true;
        }

        private MetroPanel CreateFileTile(string fileName)
        {

            MetroPanel mPanel = new MetroPanel();

            
            mPanel.Width = 143;
            mPanel.Height = 88;

            int label_x = mPanel.Width - (mPanel.Width / 3);
            int label_y = mPanel.Height - (mPanel.Height / 3);

            MetroTile tile = new MetroTile();

            tile.Width = 141;
            tile.Height = 86;

            MetroLabel mLabel = new MetroLabel();
            mLabel.Text = fileName.Split('.')[1].ToUpper();
            mLabel.Location = new Point(label_x, label_y);
            mLabel.Font = new Font(mLabel.Font.FontFamily, 25, FontStyle.Bold);
            
            tile.Name = fileName;
            tile.Text = fileName.Split('.')[0];
            tile.TextAlign = ContentAlignment.TopLeft;

            
            tile.Style = this.StylePicker(mLabel.Text);
            mPanel.Controls.Add(tile);
            mPanel.Controls.Add(mLabel);
            mLabel.BringToFront();

            tile.Click += new EventHandler(this.fileDownload);
            tile.MouseHover += new EventHandler(this.tile_MouseHover_toolTip);
         

            
            return mPanel;
        }
        private void tile_MouseHover_toolTip(object sender, EventArgs e)
        {
            Button tile = (MetroTile)sender;
            this.tooltip_filename.ToolTipTitle = "파일명";
            this.tooltip_filename.IsBalloon = true;
            this.tooltip_filename.SetToolTip(tile, tile.Name);
        }
        private MetroFramework.MetroColorStyle StylePicker(string ext)
        {
            MetroFramework.MetroColorStyle colorNo;
            switch (ext)
            {
                case "PNG":
                    colorNo = MetroFramework.MetroColorStyle.Lime;
                    break;
                case "PDF":
                    colorNo = MetroFramework.MetroColorStyle.Red;
                    break;
                case "JPG":
                    colorNo = MetroFramework.MetroColorStyle.Lime;
                    break;
                case "JPEG":
                    colorNo = MetroFramework.MetroColorStyle.Lime;
                    break;
                case "EXE":
                    colorNo = MetroFramework.MetroColorStyle.Green;
                    break;
                case "HWP":
                    colorNo = MetroFramework.MetroColorStyle.Blue;
                    break;
                case "WORD":
                    colorNo = MetroFramework.MetroColorStyle.Blue;
                    break;
                case "XLSX":
                    colorNo = MetroFramework.MetroColorStyle.Blue;
                    break;
                case "PPT":
                    colorNo = MetroFramework.MetroColorStyle.Blue;
                    break;
                case "MP3":
                    colorNo = MetroFramework.MetroColorStyle.Purple;
                    break;
                case "MP4":
                    colorNo = MetroFramework.MetroColorStyle.Purple;
                    break;
                default:
                    colorNo = MetroFramework.MetroColorStyle.Silver;
                    break;
            }


            return colorNo;
        }
        private void fileDownload(object sender, EventArgs e)
        {
            Button tileButton = (MetroTile)sender;

            
            var result = MessageBox.Show("해당 파일을 다운로드 하시겠습니까?", "파일 다운로드", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if(result == DialogResult.Yes)
            {
               
                SaveFileDialog fileDlg_save = new SaveFileDialog();

                fileDlg_save.Title = "파일 저장";
                fileDlg_save.FileName = tileButton.Name;
                fileDlg_save.Filter = "모든 파일(*.*)|*.*";
                var fileDlgResult = fileDlg_save.ShowDialog();
                
                
                if(fileDlgResult == DialogResult.OK)
                {
                    
                    this.fileDownloadForm = new FileDownloadForm(this.clientSocketWork, tileButton.Name, fileDlg_save.FileName, this);
                    
                    fileDownloadForm.ShowDialog();

                    MessageBox.Show("파일 다운로드가 완료되었습니다.", "파일 다운로드 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                
                
                
            }
        }

        public void FileListRefresh(string receivedFileList)
        {
            List<string> fileList = new List<string>();

            string[] receivedFileNameArr = receivedFileList.Split(',');
            int arrCnt = receivedFileNameArr.Length - 1;
            fileList = receivedFileNameArr.ToList<string>();

            if(this.panel_filelist.Controls.Count != arrCnt)
            {
                this.panel_filelist.Controls.Clear();
                foreach (string fileName in fileList)
                {
                    int index = fileList.IndexOf(fileName);
                    if (index != arrCnt)
                    {
                        MetroPanel newTilePanel = CreateFileTile(fileName);

                        this.panel_filelist.Controls.Add(newTilePanel);
                    }
                }
            }
        }
        private void StudentDownloadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            clientSocketWork.RequestSocketClose();
        }

        private void timer_fileListRefresh_Tick(object sender, EventArgs e)
        { 
            clientSocketWork.RequestRefresh();
        }
    }
}
