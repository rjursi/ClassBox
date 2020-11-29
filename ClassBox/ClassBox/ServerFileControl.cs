using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
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
            if (!Directory.Exists(uploadFolderPath)){
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
        

    }
}
