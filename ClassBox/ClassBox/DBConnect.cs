using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Windows.Forms;

namespace ClassBox
{
    class DBConnect
    {
        protected string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;
        protected MySqlConnection conn;
        protected MySqlCommand comm;
        protected MySqlDataReader myReader;

        protected void createConnection()
        {
            this.conn = new MySqlConnection(this.connectionString);
            this.conn.Open();
            this.comm = new MySqlCommand();


            comm.Connection = conn;
            
        }
        
        
        public DBConnect()
        {
           
        }
    }
}
