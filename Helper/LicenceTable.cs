using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinkedinJAASerial
{
    public class LicenceTable
    {
        public int id { get; set; }
        public string email{ get; set; }
        public string serialkey { get; set; } 
        public bool isactive { get; set; }
        public bool isdeleted { get; set; }
        public bool isonline { get; set; }
        public string macAddress { get; set; }
        public DateTime expirydate { get; set; }
    }
}
