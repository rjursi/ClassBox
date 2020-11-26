using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClassBox
{
    class RoomDAO : DBConnect
    {
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
    }
}
