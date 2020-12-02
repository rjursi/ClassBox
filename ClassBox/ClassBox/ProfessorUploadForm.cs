using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;
using MetroFramework.Controls;


namespace ClassBox
{
    public partial class ProfessorUploadForm : MetroForm
    {
        private ServerSocketWork serverSocketWork;
        private ServerFileControl serverFileControl;
        
        
      
        public ProfessorUploadForm()
        {
            InitializeComponent();
        }

  
        private void ProfessorUploadForm_Load(object sender, EventArgs e)
        {
            
            serverFileControl = new ServerFileControl();
            serverSocketWork = new ServerSocketWork(serverFileControl); // 서버 단 소켓 관리를 하는 객채

            serverSocketWork.SocketOn(); // 서버 단 소켓 작업을 키는 함수 실행

            this.timer_stuListUpdate.Enabled = true;
            this.timer_fileListUpdate.Enabled = true;
        }

        private void ProfessorUploadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            serverFileControl.DeleteServerDirectory();

            serverSocketWork.RequestSocketClose();
        }

        private void timer_stuListUpdate_Tick(object sender, EventArgs e)
        {

            int nowStuListCnt = this.listbox_stuList.Items.Count;
            List<string> stuNameList = serverSocketWork.ClientsList.Values.ToList<string>();


            if (nowStuListCnt != stuNameList.Count) // 현재 학생 리스트 수와 가져온 학생 리스트의 수가 다를때만
            {
                this.listbox_stuList.Items.Clear(); 
                
                foreach(string stuName in stuNameList)
                {
                    this.listbox_stuList.Items.Add(stuName);

                }
                
            }
           
        }

        private void btn_fileUpload_Click(object sender, EventArgs e)
        {
            string filePath = "";
            string fileName = "";


            if (fileDlg_selectFile.ShowDialog() == DialogResult.OK){
                filePath = fileDlg_selectFile.FileName;

                fileName = serverFileControl.FileUpload(filePath);

                MessageBox.Show("파일 업로드가 완료되었습니다.", "파일 업로드", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
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

            tile.Click += new EventHandler(this.tile_Click_fileDelete);
            tile.MouseHover += new EventHandler(this.tile_MouseHover_toolTip);
         

            
            return mPanel;
        }
        private MetroFramework.MetroColorStyle StylePicker(string ext)
        {
            MetroFramework.MetroColorStyle colorNo;
            switch (ext)
            {
                case "PNG":
                    colorNo = MetroFramework.MetroColorStyle.Lime;
                    break;
                case "JPG":
                    colorNo = MetroFramework.MetroColorStyle.Lime;
                    break;
                case "PDF":
                    colorNo = MetroFramework.MetroColorStyle.Red;
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
        
        private void tile_MouseHover_toolTip(object sender, EventArgs e)
        {
            Button tile = (MetroTile)sender;
            this.tooltip_filename.ToolTipTitle = "파일명";
            this.tooltip_filename.IsBalloon = true;
            this.tooltip_filename.SetToolTip(tile, tile.Name);
        }
        private void tile_Click_fileDelete(object sender, EventArgs e)
        {
            var result = MessageBox.Show("정말로 해당 파일을 삭제하시겠습니까?", "파일 삭제", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

            if(result == DialogResult.Yes)
            {
                Button file_tile = (MetroTile)sender;
                Console.WriteLine(file_tile.Name);
                this.serverFileControl.DeleteFile(file_tile.Name);
                MessageBox.Show("파일이 삭제되었습니다.", "파일 삭제 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void timer_fileListUpdate_Tick(object sender, EventArgs e)
        {
            int uploadedFileCount = this.panel_fileList.Controls.Count;

            if(serverFileControl.FileList.Count != uploadedFileCount)
            {
                this.panel_fileList.Controls.Clear();

                foreach(string fileName in serverFileControl.FileList.Keys)
                {
                    MetroPanel newTilePanel = CreateFileTile(fileName);

                    this.panel_fileList.Controls.Add(newTilePanel);
                }
            }
        }

        private void panel_fileList_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string filepath in files)
            {
                serverFileControl.FileUpload(filepath);
            }

            MessageBox.Show("파일 업로드가 완료되었습니다.", "파일 업로드", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void panel_fileList_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                e.Effect = DragDropEffects.Copy;
            }
        }

       
    }
}
