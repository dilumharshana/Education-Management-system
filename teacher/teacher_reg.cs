using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center
{
    class teacher_reg
    {

        String[] teacher_reg_details = new String[7];

        String name;

        public teacher_reg(String[] details)
        {

            teacher_reg_details = details;
            register();
        }


        void register()
        {
            teacher_model connect = new teacher_model();
            connect.register_new_teacher(teacher_reg_details);
        }

    }
}
