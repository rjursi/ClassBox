using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;

namespace ClassBox
{
    public class ServerFileControl
    {
        const string UPLOAD_FOLDER_NAME = "Classbox Share Files";
        string uploadFolderPath = "";

        private Dictionary<string, string> fileList;

        public Dictionary<string, string> FileList { get => this.fileList; }

        public void DeleteServerDirectory()
        {
            Directory.Delete(uploadFolderPath, true);
        }

        public void DeleteFile(string fileName)
        {
            File.Delete(Path.Combine(uploadFolderPath, fileName));
            fileList.Remove(fileName);
        }
        public ServerFileControl()
        {
            this.CreateServerFileFolder();
            this.fileList = new Dictionary<string, string>();
        }
        private void CreateServerFileFolder()
        {
            // 내 문서에다가 클래스 박스 업로드 폴더를 만듬
            uploadFolderPath = Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments), UPLOAD_FOLDER_NAME);
            if (!Directory.Exists(uploadFolderPath)) {
                Directory.CreateDirectory(uploadFolderPath);
            }
        }

        public string FileUpload(string filePath)
        {
            int fileNameIndex = filePath.Split('\\').Length - 1;
            string fileName = filePath.Split('\\')[fileNameIndex];
            string inServerFilePath = Path.Combine(uploadFolderPath, fileName);

            
            File.Copy(filePath, inServerFilePath);
            // 파일 복사 과정

            fileList.Add(fileName, inServerFilePath);

            return fileName;

        }


        private byte[] ByteMove(byte[] afterByte, int movePoint, int moveCount)
        {
            byte[] resultByte = new byte[moveCount];
            Buffer.BlockCopy(afterByte, movePoint, resultByte, 0, moveCount);
            return resultByte;
        }
        
        public void SendFile(Socket clientSocket, string filename)
        {
            try
            {
                
                string filePath = Path.Combine(uploadFolderPath, filename);


                FileInfo fileinfo = new FileInfo(filePath);

                Console.WriteLine($"filepath : {filePath}");
                /*
                byte[] fileName = Encoding.UTF8.GetBytes(fileinfo.Name); // 파일명
                byte[] fileNameSize = BitConverter.GetBytes(fileName.Length); // 파일 이름 사이즈
                */

                byte[] fileSize = File.ReadAllBytes(filePath); // 파일 사이즈
                byte[] file = BitConverter.GetBytes(fileSize.Length) ; // 파일
                
                
                // byte[] sendBuffer = new byte[fileName.Length + fileNameSize.Length + file.Length + fileSize.Length];
                byte[] sendBuffer = new byte[file.Length + fileSize.Length];
                /*
                Buffer.BlockCopy(fileNameSize, 0, sendBuffer, 0, fileNameSize.Length);
                Buffer.BlockCopy(fileName, 0, sendBuffer, fileNameSize.Length, fileName.Length);
                */

                Buffer.BlockCopy(file, 0, sendBuffer, 0, file.Length);
                Buffer.BlockCopy(fileSize, 0, sendBuffer, file.Length, fileSize.Length);

                byte[] temp = new byte[32768];

                Console.WriteLine("sendBuffer length : " + sendBuffer.Length);
                while(sendBuffer.Length > 32768)
                {
                    Buffer.BlockCopy(sendBuffer, 0, temp, 0, temp.Length);

                    sendBuffer = ByteMove(sendBuffer, temp.Length, sendBuffer.Length - temp.Length);
                    clientSocket.Send(temp);
                    //clientSocket.Receive(new Byte[32]); //받았다는 신호를 받는 곳

                }
                
                clientSocket.Send(sendBuffer); // 나머지 데이터를 보냄
                // clientSocket.Receive(new Byte[32]); //받았다는 신호를 받는 곳

                

            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"server : {e.StackTrace}");
                    
            }
        }

    }
}
