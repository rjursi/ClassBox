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
using System.IO;

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
            MetroLabel mLabel = new MetroLabel(); // 파일명
            MetroLabel mSize = new MetroLabel(); // 용량


            mPanel.Width = 170;
            mPanel.Height = 105;

            
            tile.Width = 151;
            tile.Height = 96;

            int label_x = tile.Width - (tile.Width / 3);
            int extLabel_x = label_x - (tile.Width / 3) * 2;
            int label_y = tile.Height - (tile.Height / 3);
            int extLabel_y = label_y - (tile.Height / 3);

            tile.Text = Path.GetExtension(fInfo.FullName).Replace(".", "").ToUpper();

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
            

            tile.Click += new EventHandler(this.tile_Click_fileDelete);
            tile.MouseHover += new EventHandler(this.tile_MouseHover_toolTip);
         

            
            return mPanel;
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

                foreach(string fileName in serverFileControl.FileList.Values)
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
