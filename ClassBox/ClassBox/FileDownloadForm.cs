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

namespace ClassBox
{
    public partial class FileDownloadForm : MetroForm
    {

        private ClientSocketWork clientSocketWork;
        private string requestFileName;
        private string newFileName;
        private StudentDownloadForm stuForm;
        public FileDownloadForm(ClientSocketWork clientSocketWork, string fileName, string newFileName, StudentDownloadForm stuForm)
        {
            InitializeComponent();
            this.clientSocketWork = clientSocketWork;
            this.requestFileName = fileName;
            this.stuForm = stuForm;
            this.newFileName = newFileName;
        }

        private void FileDownloadForm_Load(object sender, EventArgs e)
        {
            clientSocketWork.RequestFileDownload(requestFileName, newFileName);
        }

        public void UpdatePersent(int persent)
        {
            this.lbl_persentNum.Text = persent.ToString();
            this.progressbar_download.Value = persent;
        }
    }
}
