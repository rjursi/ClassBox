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



namespace ClassBox
{
    public partial class ProfessorUploadForm : MetroForm
    {
        private ServerSocketWork serverSocketWork;
        private int stuList = 0;
        public ProfessorUploadForm()
        {
            InitializeComponent();
        }

  
        private void ProfessorUploadForm_Load(object sender, EventArgs e)
        {
            serverSocketWork = new ServerSocketWork(); // 서버 단 소켓 관리를 하는 객채

            serverSocketWork.SocketOn(); // 서버 단 소켓 작업을 키는 함수 실행

            this.timer_stuListUpdate.Enabled = true;
        }

        private void ProfessorUploadForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            this.DialogResult = DialogResult.OK;
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
    }
}
