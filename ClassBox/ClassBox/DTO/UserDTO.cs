using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBox.DTO
{
    class UserDTO
    {
        private string id;
        private string name;
        private string password;
        private int accessno;

        public string Id { get => id; set => id = value; }
        public string Name { get => name; set => name = value; }
        public string Password { get => password; set => password = value; }
        public int Accessno { get => accessno; set => accessno = value; }
    }
}
