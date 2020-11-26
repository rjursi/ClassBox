using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassBox
{

    public class RoomDTO
    {
        private int no;
        private string name;
        private string id;
        private string createtime;
        private string ipaddress;

        public RoomDTO()
        {
            this.no = 0;
            this.name = "";
            this.id = "";
            this.createtime = "";
            this.ipaddress = "";

        }
        public int No {
            set
            {
                this.no = value;
            }
            get
            {
                return this.no;
            }
        }

        public string Name
        {
            set
            {
                this.name = value;
            }
            get
            {
                return this.name;
            }
        }
        
        public string Id {
            set
            {
                this.id = value;
            }
            get
            {
                return this.id;

            }
        }

        public string CreateTime
        {
            set
            {
                this.createtime = value;
                
            }
            get
            {
                return this.createtime;
            }
        }

        public string IpAddress {
            set
            {
                this.ipaddress = value;
            }
            get
            {
                return this.ipaddress;
            }
        }
        
        
    }

}
