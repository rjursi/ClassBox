using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
using System.Windows.Forms;

namespace ClassBox
{
    
    class ClientSocketWork
    {
       
        private Socket mainSocket; 
        private IPEndPoint endPoint;
        private string serverIP;
        private byte[] initSendData;
        private const int CLASSBOXPORT = 53278;
        private UserDTO userDTO;
        private ServerObject serverObject;
        private StudentDownloadForm stuForm;
        public ClientSocketWork(UserDTO userDTO, StudentDownloadForm stuForm)
        {
           
            this.userDTO = userDTO;
            this.stuForm = stuForm;
        }
        
        public class ServerObject
        {
            public Byte[] buffer;
            public readonly int bufferSize;
            public Socket serverSocket;

            public ServerObject(int bufferSize)
            {
                this.bufferSize = bufferSize;
                this.buffer = new byte[this.bufferSize];

            }

            public void ClearBuffer()
            {
                Array.Clear(this.buffer, 0, this.bufferSize);
            }
        }

        public string ServerIP { get => this.serverIP; set => this.serverIP = value; }
        public void RequestRefresh()
        {
            mainSocket.Send(Encoding.UTF8.GetBytes("requestFileList"));
            
        }

        public void RequestSocketClose()
        {
            try
            {
                mainSocket.Send(Encoding.UTF8.GetBytes("exit"));
            }catch (ObjectDisposedException)
            {
                Console.WriteLine("exception : 서버가 이미 종료되었음.");
            }
            

            mainSocket.Close();
        }

        private void AsyncReceiveCallback(IAsyncResult ar)
        {
            ServerObject so = ar.AsyncState as ServerObject;
            
            if (so.serverSocket.Connected)
            {
                try
                {
                    // 비동기 데이터 읽기를 한번 끝냄
                    so.serverSocket.EndReceive(ar);

                    if (Encoding.UTF8.GetString(so.buffer).Contains("fileList")) // 접속 요청 데이터 받기
                    {
                        string receivedFileList = Encoding.UTF8.GetString(so.buffer).Split('&')[1];
                        Console.WriteLine("client : flieList Received : " + receivedFileList);
                        stuForm.Invoke(
                            (MethodInvoker)delegate {
                                stuForm.FileListRefresh(receivedFileList);
                            }
                        );

                    }

                    if (Encoding.UTF8.GetString(so.buffer).Contains("roomClose")) // 접속 요청 데이터 받기
                    {
                        so.ClearBuffer();
                        so.serverSocket.Close();

                        MessageBox.Show("해당 방은 종료되었습니다. 방에서 나가집니다.", "방 종료", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        // 클라이언트 방 없어졌다는 로직이 들어가야함

                        stuForm.Invoke(new MethodInvoker(stuForm.Close));
                        
                        return;
                    }

                    so.ClearBuffer(); // 데이터 받았으니 버퍼 비움

                    // 다시 서버로부터 데이터 받기 대기
                    so.serverSocket.BeginReceive(serverObject.buffer, 0, serverObject.bufferSize, SocketFlags.None, AsyncReceiveCallback, so);
                }
                catch
                {

                }
            }
        }
       
        public void SocketConnection()
        {
            
           

           
            try
            {
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // 서버를 가르키는 소켓
                endPoint = new IPEndPoint(IPAddress.Parse(serverIP), CLASSBOXPORT);

                mainSocket.Connect(endPoint);

                initSendData = Encoding.UTF8.GetBytes($"info&{userDTO.Name}");

                mainSocket.Send(initSendData);
                mainSocket.Receive(new byte[32]); // 학생 정보를 받았다는 것을 받기 위한 임시 byte
                serverObject = new ServerObject(4096);
                serverObject.serverSocket = mainSocket;

                this.RequestRefresh();
                mainSocket.BeginReceive(serverObject.buffer, 0, serverObject.bufferSize, SocketFlags.None, AsyncReceiveCallback, serverObject);
               
            }
            catch 
            {
                
            }
            
            
        }
        
    }
}
