using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;


namespace ClassBox
{
    class DBConnect
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        private MySqlConnection conn;
        private MySqlCommand comm;
        private MySqlDataReader myReader;
        
        private void MysqlConnection()
        {
            using(conn = new MySqlConnection(this.connectionString))
            {
                conn.Open();

                using (comm = new MySqlCommand())
                {
                    comm.Connection = conn;

                    comm.CommandText = "SELECT accessname FROM authority WHERE accessno=@accessno";

                    comm.Parameters.AddWithValue("@accessno", 1);

                    using (myReader = comm.ExecuteReader())
                    {
                        if (myReader.Read())
                        {
                            Console.WriteLine(myReader["accessname"].ToString());
                        }
                    }
                }
            }
            
            
        }
        public DBConnect()
        {
            this.MysqlConnection();
        }
    }
}
