using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Education_Center
{

    class login_ctrl
    {
        private String[] data = new String[2];

        public login_ctrl(String uname, String pass)
        {
             data[0] = uname;
             data[1] = pass;

            chekuser();
        }

        bool ok = true;

        public void chekuser()
        {
            login_model connect = new login_model();
            String[] passok = connect.chekuser(data);

            if (passok[0] == "1")
            {

                if (passok[2] == "admin")
                {
                    frm_Home open = new frm_Home("ADMIN");
                    open.Show();
                    this.Alert("Success!", frm_Alert.enmType.Success);


                }
                else if (passok[2] == "emp")
                {
                    frm_Home open = new frm_Home(passok[1] , false);
                    open.Show();
                    this.Alert("Success!", frm_Alert.enmType.Success);
                }

            }
            else
            {
                 Alert("Incorrect username or password!", frm_Alert.enmType.Error);

                frm_Login open = new frm_Login();
                open.Show();
            }

        }

        public bool close()
        {
            bool closer = true;

            if (!ok)
            {
                closer = false;
            }

            return closer;
        }

        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }
    }
}
