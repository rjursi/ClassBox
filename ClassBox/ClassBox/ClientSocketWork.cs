using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;
namespace ClassBox
{
    
    class ClientSocketWork
    {
        private bool isFirst;
        
        private Socket mainSocket; 
        private IPEndPoint endPoint;
        private string serverIP;
        private byte[] initSendData;
        private const int CLASSBOXPORT = 53278;
        private UserDTO userDTO;
        private ServerObject serverObject;
        public ClientSocketWork(UserDTO userDTO)
        {
           
            this.userDTO = userDTO; 
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
            
        }

        public void RequestSocketClose()
        {
            mainSocket.Send(Encoding.UTF8.GetBytes("exit"));

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

                    if (Encoding.UTF8.GetString(so.buffer).Contains("info")) // 접속 요청 데이터 받기
                    {

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
            
            isFirst = true; // 

           
            try
            {
                mainSocket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp); // 서버를 가르키는 소켓
                endPoint = new IPEndPoint(IPAddress.Parse(serverIP), CLASSBOXPORT);

                mainSocket.Connect(endPoint);

                initSendData = Encoding.UTF8.GetBytes($"info&{userDTO.Name}");

                mainSocket.Send(initSendData);

                serverObject = new ServerObject(65536);
                serverObject.serverSocket = mainSocket;

                mainSocket.BeginReceive(serverObject.buffer, 0, serverObject.bufferSize, SocketFlags.None, AsyncReceiveCallback, serverObject);
               
            }
            catch 
            {
                
            }
            
            
        }
        
    }
}
