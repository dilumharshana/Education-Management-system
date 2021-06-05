using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center
{
    class search_ctrl
    {
        String index;

        public search_ctrl(String index)
        {
            this.index = index;
        }

        public void getData()
        {
            student_model model = new student_model();

            String [] std_data = model.found(index);

            frm_Home.setData(std_data);
        }
    }
}
