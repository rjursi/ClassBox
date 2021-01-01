using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassBox
{
    
    class ClientFileControl
    {
        public ClientFileControl()
        {
           
        }

        public void Receive(FileDownloadForm fileDownloadForm, Socket serverSocket, string newFilename)
        {
            byte[] receiveBuffer = new byte[4096];
            byte[] fileSizeBuffer = new byte[4];
            byte[] fileBuffer;
            byte[] temp;


            int receiveSize = 0;
            int fileSize = 0;
            int fileSizeSum = 0;
            int persent = 0;


            Console.WriteLine("im receving");
            try
            {
                    
                receiveSize = serverSocket.Receive(receiveBuffer);
                
                if (receiveSize > 0)
                {
               
                     
                    Buffer.BlockCopy(receiveBuffer, 0, fileSizeBuffer, 0, fileSizeBuffer.Length);

                    fileSize = BitConverter.ToInt32(fileSizeBuffer, 0);

                    fileBuffer = ByteMove(receiveBuffer, fileSizeBuffer.Length,
                        receiveSize - (fileSizeBuffer.Length));

                    fileSizeSum = fileBuffer.Length;

                    

                    Console.WriteLine($"fileSize : {fileSize}, fileSizeSum : {fileSizeSum}");
                    while(fileSize > fileSizeSum){
                        receiveSize = serverSocket.Receive(receiveBuffer);
                        fileSizeSum += receiveSize;
                        if (fileSize != 0)
                        {
                            persent = (fileSizeSum * 100) / fileSize;
                        }

                        fileDownloadForm.Invoke((MethodInvoker)delegate
                        {
                            fileDownloadForm.UpdatePersent(persent);
                        });

                        temp = new byte[receiveSize + fileBuffer.Length];

                        Buffer.BlockCopy(fileBuffer, 0, temp, 0, fileBuffer.Length);
                        Buffer.BlockCopy(receiveBuffer, 0, temp, fileBuffer.Length, receiveSize);

                        fileBuffer = temp;
                        
                    
                    }
                    Console.WriteLine($"fileSize : {fileSize}, fileSizeSum : {fileSizeSum}");
                    if (fileSize != fileSizeSum)
                    {
                        MessageBox.Show("파일이 손상되었습니다.");

                    }
                    using (FileStream fs = new FileStream(newFilename, FileMode.Create, FileAccess.Write))
                    {
                        fs.Write(fileBuffer, 0, fileBuffer.Length);
                    }
                    Console.WriteLine("파일 생성 완료");

                    fileDownloadForm.Invoke((MethodInvoker)delegate
                    {
                        fileDownloadForm.Close();
                    });

                }
                
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.StackTrace);
            }catch (Exception e)
            {
                Console.WriteLine(e.StackTrace);
            }
            
            
        }

        private byte[] ByteMove(byte[] afterByte, int movePoint, int moveCount)
        {
            byte[] resultByte = new byte[moveCount];
            Buffer.BlockCopy(afterByte, movePoint, resultByte, 0, moveCount);
            Console.WriteLine("resultByte Size : " + resultByte.Length);
            return resultByte;
        }
    }
}
