using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VendingMachine {
    internal class Admin {
        public int Code { get; set; }
        public string Passwd { get; set; }
        public Admin(int code, string passwd) {
            Code = code;
            Passwd = passwd;
        }



    }
}
