using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center
{
    class attend_ctrl
    {
        public attend_ctrl(String[] data) 
        {
            attend_model attend = new attend_model();
            attend.mark(data);

        }

        
    }
}
