using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBox
{
    class UserDAO : DBConnect
    {
        public UserDTO Login(UserDTO userDTO)
        {
            
            base.createConnection();

            base.comm.CommandText = "SELECT name,accessno FROM user WHERE id=@id AND password=@password";
            base.comm.Parameters.AddWithValue("@password", userDTO.Password);
            base.comm.Parameters.AddWithValue("@id", userDTO.Id);
            using (base.myReader = base.comm.ExecuteReader())
            {
                while (base.myReader.Read())
                {
                    userDTO.Name = (myReader.IsDBNull(0)) ? "" : myReader["name"].ToString();
                    userDTO.Accessno = (myReader.IsDBNull(0)) ? 0 : Int32.Parse(myReader["accessno"].ToString());
                }
            }   

            Console.WriteLine(userDTO.Name + "님");
            return userDTO;
        }


        public void SignUp(UserDTO userDTO)
        {
            base.createConnection();

            base.comm.CommandText = "INSERT INTO user VALUES(@id, @name, @password, @accessno)";

            base.comm.Parameters.AddWithValue("@id", userDTO.Id);
            base.comm.Parameters.AddWithValue("@password", userDTO.Password);
            base.comm.Parameters.AddWithValue("@name", userDTO.Name);
            base.comm.Parameters.AddWithValue("@accessno", userDTO.Accessno);

            base.comm.ExecuteNonQuery();

            
            
        }
    }
}
