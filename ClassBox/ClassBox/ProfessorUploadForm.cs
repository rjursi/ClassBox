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
using System.Net.Sockets;
using System.Net;


namespace ClassBox
{
    public partial class ProfessorUploadForm : MetroForm
    {
        private Socket listener;
        private IPEndPoint endPoint;
        private const int CLASSBOXPORT = 53278;

        private class ClientObject
        {
            public Byte[] buffer;
            public Socket client;
            public string address;
        }


        public ProfessorUploadForm()
        {
            InitializeComponent();
        }

        
        private void SocketOn()
        {
            this.listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            // 양방향 연결, TCP 통신 사용
            this.endPoint = new IPEndPoint(IPAddress.Any, CLASSBOXPORT);
            // 모든 네트워크 영역에서의 IP 연결

            listener.Bind(endPoint);
            listener.Listen(50); // 최대 접속자 수

            
        }


        
        private void ProfessorUploadForm_Load(object sender, EventArgs e)
        {
            SocketOn(); // 클라이언트의 연결을 받는 소켓을 만듬
        }
    }
}
