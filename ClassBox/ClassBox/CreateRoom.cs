﻿using System;
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
using System.Net;
using System.Net.NetworkInformation;

namespace ClassBox
{
    
    public partial class CreateRoom : MetroForm
    {
        
        private UserDTO userDTO;
        private RoomDTO roomDTO;
       

        public RoomDTO GetRoomDTO()
        {
            return this.roomDTO;
        }

        // 방 생성시 자신의 로컬 IP 중 Gateway로 외부 인터넷과 통신을 하는 인터페이스만 가져옴
        private IPAddress GetRealIpAddress()
        {

            IPAddress gateway = FindGetGatewayAddress();

            if (gateway == null)
                return null;

            IPAddress[] pIPAddress = Dns.GetHostAddresses(Dns.GetHostName());

            foreach (IPAddress address in pIPAddress)
                if (IsAddressOfGateway(address, gateway))
                    return address;

            return null;

        }


        private bool IsAddressOfGateway(IPAddress address, IPAddress gateway)
        {

            if (address != null && gateway != null)
                return IsAddressOfGateway(address.GetAddressBytes(), gateway.GetAddressBytes());

            return false;

        }

        private bool IsAddressOfGateway(byte[] address, byte[] gateway)
        {

            if (address != null && gateway != null)
            {
                int gwLen = gateway.Length;

                if (gwLen > 0)

                {
                    if (address.Length == gateway.Length)
                    {
                        --gwLen;

                        int counter = 0;

                        for (int i = 0; i < gwLen; i++)
                        {

                            if (address[i] == gateway[i])
                                ++counter;
                        }


                        return (counter == gwLen);

                    }
                }
            }


            return false;
        }

        private IPAddress FindGetGatewayAddress()

        {

            IPGlobalProperties ipGlobProps = IPGlobalProperties.GetIPGlobalProperties();

            foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
            {

                IPInterfaceProperties ipInfProps = ni.GetIPProperties();

                foreach (GatewayIPAddressInformation gi in ipInfProps.GatewayAddresses)
                    return gi.Address;
            }

            return null;

        }
       

        public CreateRoom(UserDTO userDTO)
        {
            InitializeComponent();
            this.userDTO = userDTO;
        }

        private void btn_createRoom_Click(object sender, EventArgs e)
        {
            // MessageBox.Show(this.GetRealIpAddress().ToString());   
            RoomDAO roomDAO = new RoomDAO();
            this.roomDTO = new RoomDTO();

            if(txtbox_roomName.Text == "")
            {
                MessageBox.Show("방 이름을 입력하셔야 합니다.", "방 이름 입력", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return; 
            }


            // 폴더 생성하는 로직 추가

            roomDTO.IpAddress = this.GetRealIpAddress().ToString(); // 현재 컴퓨터의 IP 주소를 구함
            roomDTO.Name = this.txtbox_roomName.Text;
            roomDTO.CreateTime = DateTime.Now.ToString("yyyy-MM-dd HH-mm-ss");
            roomDTO.Id = this.userDTO.Id; 
            
            roomDAO.CreateRoom(roomDTO); // 방을 생성하는데 필요한 roomDTO를 보냄

            this.DialogResult = DialogResult.OK;
            this.Close();

        }
    }
}
