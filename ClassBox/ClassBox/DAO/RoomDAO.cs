using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassBox
{
    class RoomDAO : DBConnect
    {
        public ArrayList GetAllRoomList()
        {
            ArrayList roomList = new ArrayList();
          
            createConnection();

            comm.CommandText = "SELECT * FROM room"; //모든 현재 생성된 방의 목록을 가져옴

            using (myReader = comm.ExecuteReader()) {
                while (myReader.Read())
                {
               

                    RoomDTO roomDTO = new RoomDTO();

                    roomDTO.No = Int32.Parse(myReader["no"].ToString());
                    roomDTO.Name = myReader["name"].ToString();
                    roomDTO.Id = myReader["id"].ToString();
                    roomDTO.CreateTime = myReader["createtime"].ToString();
                    roomDTO.IpAddress = myReader["ipaddress"].ToString();



                    roomList.Add(roomDTO);

                }

            }
            comm.Dispose();
            conn.Close();

            return roomList;
        }

        public RoomDTO GetJoinRoomDTO(int roomNo)
        {
            createConnection();

            comm.CommandText = "SELECT * FROM room WHERE no = @no";
            comm.Parameters.AddWithValue("@no", roomNo);


            using (myReader = comm.ExecuteReader())
            {
                RoomDTO roomDTO = new RoomDTO();

                if (myReader.Read())
                {
                    
                    roomDTO.No = Int32.Parse(myReader["no"].ToString());
                    roomDTO.Id = myReader["id"].ToString();
                    roomDTO.Name = myReader["name"].ToString();
                    roomDTO.CreateTime = myReader["createtime"].ToString();
                    roomDTO.IpAddress = myReader["ipaddress"].ToString(); 
                }

                return roomDTO;
            }
        }
        public void CreateRoom(RoomDTO roomDTO)
        {


            
            createConnection();

            comm.CommandText = "SELECT MAX(no) FROM room";

            int maxRoomno = 0;

            using (myReader = comm.ExecuteReader())
            {
                while (myReader.Read())
                {
                    maxRoomno = (myReader.IsDBNull(0)) ? 1 : Int32.Parse(myReader["MAX(no)"].ToString());


                }


            } // 방 번호 할당

            
            roomDTO.No = maxRoomno;

            comm.CommandText = "INSERT INTO room VALUES(@no, @name, @id, @createtime, @ipaddress)";

            comm.Parameters.AddWithValue("@no", roomDTO.No);
            comm.Parameters.AddWithValue("@name", roomDTO.Name);
            comm.Parameters.AddWithValue("@id", roomDTO.Id);
            comm.Parameters.AddWithValue("@createtime", roomDTO.CreateTime);
            comm.Parameters.AddWithValue("@ipaddress", roomDTO.IpAddress);

            int result = this.comm.ExecuteNonQuery();

            if (result > -1)
            {
                MessageBox.Show("방이 정상적으로 생성이 되었습니다.", "방 생성 완료", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            else
            {
                MessageBox.Show("error : 방이 생성되지 않았습니다.", "방 생성 실패", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }


            comm.Dispose();
            conn.Close();
        }

        public void RemoveRoom(RoomDTO roomDTO)
        {
            createConnection();

            comm.CommandText = "DELETE FROM room WHERE id=@id";

            comm.Parameters.AddWithValue("@id", roomDTO.Id);

            comm.ExecuteNonQuery();


            comm.Dispose();
            conn.Close();
        }
    }
}
