using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using System.Net.Sockets;
using Microsoft.VisualBasic.FileIO;
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
            FileSystem.DeleteDirectory(uploadFolderPath,UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
        }

        public void DeleteFile(string fileName)
        {
            FileSystem.DeleteFile(Path.Combine(uploadFolderPath, fileName),UIOption.OnlyErrorDialogs, RecycleOption.DeletePermanently);
            // File.Delete(Path.Combine(uploadFolderPath, fileName));
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
            if (!FileSystem.DirectoryExists(uploadFolderPath)) {
                FileSystem.CreateDirectory(uploadFolderPath);
            }
        }

        public string FileUpload(string filePath)
        {
            int fileNameIndex = filePath.Split('\\').Length - 1;
            string fileName = filePath.Split('\\')[fileNameIndex];
            string inServerFilePath = Path.Combine(uploadFolderPath, fileName);

            
            FileSystem.CopyFile(filePath, inServerFilePath,UIOption.AllDialogs);
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
           

                
                byte[] fileSize = FileSystem.ReadAllBytes(filePath); // 파일 사이즈
                byte[] file = BitConverter.GetBytes(fileSize.Length) ; // 파일
                
                
              
                byte[] sendBuffer = new byte[file.Length + fileSize.Length];
               

                Buffer.BlockCopy(file, 0, sendBuffer, 0, file.Length);
                Buffer.BlockCopy(fileSize, 0, sendBuffer, file.Length, fileSize.Length);

                byte[] temp = new byte[32768];

                Console.WriteLine("sendBuffer length : " + sendBuffer.Length);
                while(sendBuffer.Length > 32768)
                {
                    Buffer.BlockCopy(sendBuffer, 0, temp, 0, temp.Length);

                    sendBuffer = ByteMove(sendBuffer, temp.Length, sendBuffer.Length - temp.Length);
                    clientSocket.Send(temp);
                    

                }
                
                clientSocket.Send(sendBuffer); // 나머지 데이터를 보냄
             
            }
            catch (ArgumentException e)
            {
                Console.WriteLine($"server : {e.StackTrace}");
                    
            }
        }

    }
}
