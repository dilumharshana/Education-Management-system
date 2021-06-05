using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center
{
   
    class std_reg_ctrl
    {
       String[] registration_details = new String[25];

        String name;

         public std_reg_ctrl(String [] details )
        {

                 registration_details = details;
                register();
        }


        //registration process of  new student
        void register() 
            {
                student_model connect = new student_model();
                connect.register_new_student(registration_details);
            }
    }
}
