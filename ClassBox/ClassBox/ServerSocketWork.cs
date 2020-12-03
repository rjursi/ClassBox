using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Net;


namespace ClassBox
{
    class ServerSocketWork
    {
        private Dictionary<ClientObject, string> clientsList;
        private Socket listener;
        private IPEndPoint endPoint;
        private const int CLASSBOXPORT = 53278;
        private ServerFileControl serverFileControl;

        public class ClientObject
        {
            public Byte[] buffer;
            public readonly int bufferSize;
            public Socket clientSocket;
            public string address;


            public ClientObject(int bufferSize, Socket clientSocket, string address)
            {
                this.bufferSize = bufferSize;
                this.buffer = new byte[this.bufferSize];

                this.clientSocket = clientSocket;
                this.address = address;
            }

            public void ClearBuffer()
            {
                Array.Clear(this.buffer, 0, this.bufferSize);
            }
        }



       


        public Dictionary<ClientObject, string> ClientsList { get => clientsList; }
        public ServerSocketWork(ServerFileControl serverFileControl)
        {
            this.clientsList = new Dictionary<ClientObject, string>();
            // 앞에는 클라이언트 소켓 객체, 뒤에는 학생 이름
            this.serverFileControl = serverFileControl;
        }
        public void RequestSocketClose()
        {
            foreach(ClientObject clientObj in clientsList.Keys)
            {
                clientObj.clientSocket.Send(Encoding.UTF8.GetBytes("roomClose"));
                
            }

            listener.Close();
            Console.WriteLine(listener);
        }
        public void SocketOn()
        {
            listener = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            endPoint = new IPEndPoint(IPAddress.Any, CLASSBOXPORT);
            listener.Bind(endPoint);
            listener.Listen(50);

            listener.BeginAccept(AcceptCallback, null);
            
        }
        private void AsyncReceiveCallback(IAsyncResult ar)
        {
            ClientObject co = ar.AsyncState as ClientObject;

            if (co.clientSocket.Connected)
            {
                try
                {
                    // 비동기 데이터 읽기를 한번 끝냄
                    co.clientSocket.EndReceive(ar);
                    if (Encoding.UTF8.GetString(co.buffer).Contains("exit")) {
                        clientsList.Remove(co);
                        co.ClearBuffer(); // 데이터 받았으니 버퍼 비움

                        return;
                    }
                    else if (Encoding.UTF8.GetString(co.buffer).Contains("info")) // 접속 요청 데이터 받기
                    {
                        string receivedStuInfo = Encoding.UTF8.GetString(co.buffer);

                        clientsList.Add(co, receivedStuInfo.Split('&')[1]);
                        co.clientSocket.Send(Encoding.UTF8.GetBytes("infoReceived"));

                    }

                    else if (Encoding.UTF8.GetString(co.buffer).Contains("requestFileList"))
                    {
                        string fileList = "";
                        Console.WriteLine("server : requestFileList");
                        fileList += "fileList&";
                        if (serverFileControl.FileList.Count > 0)
                        {
                            foreach (string fileName in serverFileControl.FileList.Values)
                            {
                                
                                fileList += fileName;
                                fileList += ',';
                            }
                        }
                      
                        co.clientSocket.Send(Encoding.UTF8.GetBytes(fileList));

                    }else if (Encoding.UTF8.GetString(co.buffer).Contains("DownloadFile"))
                    {
                        string filename = Encoding.UTF8.GetString(co.buffer).Split('&')[1].TrimEnd('\0');
                        Console.WriteLine("server : get request file download");
                        co.clientSocket.Send(Encoding.UTF8.GetBytes("fileSendStart"));
                        co.clientSocket.Receive(new byte[32]); // "okay" 신호를 받고 나서 대기
                        Console.WriteLine("server : get okay");
                        Console.WriteLine(filename);
                        serverFileControl.SendFile(co.clientSocket, filename);
                        
                    }

                    co.ClearBuffer(); // 데이터 받았으니 버퍼 비움


                    // 다시 클라이언트로부터 데이터 받기 대기
                    co.clientSocket.BeginReceive(co.buffer, 0, co.bufferSize, SocketFlags.None, AsyncReceiveCallback, co);
                }
                catch { 

                }
            }
        }


        void AcceptCallback(IAsyncResult ar)
        {
            try { 
                Socket clientSocket = listener.EndAccept(ar); // 클라이언트 연결 요청 수락
                listener.BeginAccept(AcceptCallback, null); // 또 다른 클라이언트 연결 수락
                string address = clientSocket.RemoteEndPoint.ToString().Split(':')[0]; // 아이피 가져옴
                ClientObject clientObject = new ClientObject(4096, clientSocket, address);


                clientObject.clientSocket.BeginReceive(clientObject.buffer, 0, clientObject.bufferSize, SocketFlags.None, AsyncReceiveCallback, clientObject);

            }
            catch (ObjectDisposedException)
            {
                return;
            }
            
            
            
        }



    }
}
