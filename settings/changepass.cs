using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center
{
    class changepass
    {
        private String newpass;

        public changepass(String newpass)
        {
             newpass = newpass;
        }
    }

    class pass
    {
        public String user { get; set; }
        public String password { get; set; }
    }
}
