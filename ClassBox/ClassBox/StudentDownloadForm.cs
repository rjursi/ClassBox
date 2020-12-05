using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
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
        private readonly string[] SizeSuffixes =
                   { "B", "KB", "MB", "GB", "TB", "PB", "EB", "ZB", "YB" };
        private string SizeSuffix(Int64 value, int decimalPlaces = 1)
        {
            if (decimalPlaces < 0) { throw new ArgumentOutOfRangeException("decimalPlaces"); }
            if (value < 0) { return "-" + SizeSuffix(-value); }
            if (value == 0) { return string.Format("{0:n" + decimalPlaces + "} B", 0); }

            // mag is 0 for bytes, 1 for KB, 2, for MB, etc.
            int mag = (int)Math.Log(value, 1024);

            // 1L << (mag * 10) == 2 ^ (10 * mag) 
            // [i.e. the number of bytes in the unit corresponding to mag]
            decimal adjustedSize = (decimal)value / (1L << (mag * 10));

            // make adjustment when the value is large enough that
            // it would round up to 1000 or more
            if (Math.Round(adjustedSize, decimalPlaces) >= 1000)
            {
                mag += 1;
                adjustedSize /= 1024;
            }

            return string.Format("{0:n" + decimalPlaces + "} {1}",
                adjustedSize,
                SizeSuffixes[mag]);
        }

        private MetroPanel CreateFileTile(string fileName)
        {
            FileInfo fInfo = new FileInfo(fileName);

            MetroPanel mPanel = new MetroPanel();
            MetroTile tile = new MetroTile();
            MetroLabel mLabel = new MetroLabel();
            MetroLabel mSize = new MetroLabel(); // 용량

            mPanel.Width = 170;
            mPanel.Height = 105;

            tile.Width = 151;
            tile.Height = 96;

            int label_x = tile.Width - (tile.Width / 3) - 10;
            int extLabel_x = label_x - (tile.Width / 3) * 2 + 15;
            int label_y = tile.Height - (tile.Height / 3);
            int extLabel_y = (tile.Height / 2) - 10;

            tile.Text = Path.GetExtension(fInfo.FullName).Replace(".", "").ToUpper();
            tile.TileTextFontSize = MetroFramework.MetroTileTextSize.Tall;
            mLabel.Text = Path.GetFileNameWithoutExtension(fileName);
            mLabel.Location = new Point(extLabel_x, extLabel_y);
            mLabel.Font = new Font(mLabel.Font.FontFamily, 25, FontStyle.Bold);
            mLabel.Style = this.StylePicker(tile.Text);

            mSize.Text = SizeSuffix(fInfo.Length);
            mSize.Location = new Point(label_x, label_y);
            mSize.Style = this.StylePicker(tile.Text);


            tile.Name = fInfo.Name;
            
            tile.TextAlign = ContentAlignment.TopLeft;


            tile.Style = this.StylePicker(tile.Text);
            mPanel.Controls.Add(tile);
            tile.Controls.Add(mLabel);
            tile.Controls.Add(mSize);
            

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
                case "JAVA":
                case "JSP":
                    colorNo = MetroFramework.MetroColorStyle.JAVAnJSP;
                    break;


                case "PNG":
                case "JPG":
                case "GIF":
                    colorNo = MetroFramework.MetroColorStyle.PNGnJPGnGIF;
                    break;
                case "PDF":
                case "HWP":
                    colorNo = MetroFramework.MetroColorStyle.PDFnHWP;
                    break;
                case "PPTX":
                case "XLSX":
                case "DOCX":
                    colorNo = MetroFramework.MetroColorStyle.PPTXnXLSXnDOCX;
                    break;
                case "TXT":
                    colorNo = MetroFramework.MetroColorStyle.TXT;
                    break;
                case "PY":
                    colorNo = MetroFramework.MetroColorStyle.PY;
                    break;
                case "AVI":
                case "MP4":
                    colorNo = MetroFramework.MetroColorStyle.AVInMP4;
                    break;
                case "JS":
                    colorNo = MetroFramework.MetroColorStyle.JS;
                    break;
                case "ZIP":
                    colorNo = MetroFramework.MetroColorStyle.ZIP;
                    break;
                case "HTML":
                    colorNo = MetroFramework.MetroColorStyle.HTML;
                    break;
                case "CS":
                case "ASP":
                    colorNo = MetroFramework.MetroColorStyle.CSnASP;
                    break;

                default:
                    colorNo = MetroFramework.MetroColorStyle.ETC;
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
