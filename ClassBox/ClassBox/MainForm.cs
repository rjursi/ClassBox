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
using MetroFramework.Controls;
namespace ClassBox
{
    public partial class MainForm : MetroForm
    {
        DBConnect dbconn;

        public MainForm()
        {
            InitializeComponent();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {
            // dbconn = new DBConnect();
        }

        private void btn_createRoom_Click(object sender, EventArgs e)
        {

            CreateRoom createRoomForm = new CreateRoom();
            createRoomForm.ShowDialog();

            MetroButton button = new MetroButton();
            roomListPanel.Controls.Add(button);
        }
    }
}
