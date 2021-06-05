using MongoDB.Bson;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Education_Center
{
    public partial class frm_Settings : Form
    {

        bool adminforgotpass = false;

        public frm_Settings(bool situation)
        {
             adminforgotpass = situation;
            InitializeComponent();
        }

        private void Frm_Settings_Load(object sender, EventArgs e)
        {
           
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel3_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel4_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            try
            {
                changepass();
                txt_oldpass.Text = null;
                txt_newpass.Text = null;
                txt_retypedpass.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
                error.errorNow(e.ToString() + "in class frm_settings [ RISK SITUATION ]");
            }
        }


        //PASWORD CHANGINGS
        void changepass() {
                    if ((txt_oldpass.Text != "") && (txt_newpass.Text != "") && (txt_retypedpass.Text != ""))
                    {
                        try
                        {

                            if (adminforgotpass == false)
                            {
                                MongoClient connect = dbconnector.connection();
                                var db = connect.GetDatabase("educationSystem");
                                var logdata = db.GetCollection<logindata>("login"); //getting student document

                                var filter = Builders<logindata>.Filter.Eq("role", "admin");
                                var rec = logdata.Find(filter).First();

                                if (txt_newpass.Text == txt_retypedpass.Text)
                                {
                                    if (rec.password == txt_oldpass.Text)
                                    {
         
                                        var update = Builders<logindata>.Update.Set("password", txt_retypedpass.Text);
                                        logdata.UpdateOne(filter, update);
                                        MessageBox.Show("Password updated successfully !");
                                    }
                                    else
                                    {
                                        MessageBox.Show("Old password is not matching !");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Passwords are not matching !");
                                }
                            }
                            else
                            {

                            }


                            changepass open = new changepass(txt_retypedpass.Text);
                        }
                        catch (Exception e)
                        {
                             error.errorNow(e.ToString() + "in class frm_settings [ NORMAL SITUATION ]");
                         }
                    }
                    else
                    {
                        MessageBox.Show("Please fill every fields");
                    }
        }


        //PASWORD CHANGINGS
        void changepassEMP()
        {
            if ((txt_emppass.Text != "") && (txt_emprepass.Text != ""))
            {
                try
                {

                    if (adminforgotpass == false)
                    {
                        MongoClient connect = dbconnector.connection();
                        var db = connect.GetDatabase("educationSystem");
                        var logdata = db.GetCollection<logindata>("login"); //getting student document

                        var filter = Builders<logindata>.Filter.Eq("role", "emp");

                        if (txt_emppass.Text == txt_emprepass.Text)
                        {

                                var update = Builders<logindata>.Update.Set("password", txt_emprepass.Text);
                                logdata.UpdateOne(filter, update);
                                MessageBox.Show("Password updated successfully !");

                        }
                        else
                        {
                            MessageBox.Show("Passwords are not matching !");
                        }
                    }
                    else
                    {

                    }


                    changepass open = new changepass(txt_emprepass.Text);
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class frm_settings [ RISK SITUATION ]");
                }
            }
            else
            {
                MessageBox.Show("Please fill every fields");
            }
        }

        //USER NAME CHANGING
        void changename()
        {
            if ((txt_oldusername.Text != "") && (txt_newusername.Text != "") && (txt_retypedusername.Text != ""))
            {
                try
                {

                    if (adminforgotpass == false)
                    {
                        MongoClient connect = dbconnector.connection();
                        var db = connect.GetDatabase("educationSystem");
                        var logdata = db.GetCollection<logindata>("login"); //getting student document

                        var filter = Builders<logindata>.Filter.Eq("role", "admin");
                        var rec = logdata.Find(filter).First();

                        if (txt_newusername.Text == txt_retypedusername.Text)
                        {
                            if (rec.username == txt_oldusername.Text)
                            {

                                var update = Builders<logindata>.Update.Set("username", txt_retypedusername.Text);
                                logdata.UpdateOne(filter, update);
                                MessageBox.Show("Username updated successfully !");
                            }
                            else
                            {
                                MessageBox.Show("Old username is not matching !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("usernames are not matching !");
                        }
                    }
                    else
                    {

                    }


                    changepass open = new changepass(txt_retypedpass.Text);
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class frm_Settings [ RISK SITUATION ]");
                }
            }
            else
            {
                MessageBox.Show("Please fill every fields");
            }
        }

        void changenameEMP()
        {
            if ((txt_empuname.Text != "") && (txt_empureuname.Text != ""))
            {
                try
                {

                    if (adminforgotpass == false)
                    {
                        MongoClient connect = dbconnector.connection();
                        var db = connect.GetDatabase("educationSystem");
                        var logdata = db.GetCollection<logindata>("login"); //getting student document

                        var filter = Builders<logindata>.Filter.Eq("role", "emp");

                        if (txt_empuname.Text == txt_empureuname.Text)
                        {

                                var update = Builders<logindata>.Update.Set("username", txt_empureuname.Text);
                                logdata.UpdateOne(filter, update);
                                MessageBox.Show("Username updated successfully !");
         
                        }
                        else
                        {
                            MessageBox.Show("usernames are not matching !");
                        }
                    }
                    else
                    {

                    }


                    changepass open = new changepass(txt_retypedpass.Text);
                }
                catch (Exception e)
                {
                    error.errorNow(e.ToString() + "in class class_attend [ RISK SITUATION ]");
                }
            }
            else
            {
                MessageBox.Show("Please fill every fields");
            }
        }


        private void Alert(string v, frm_Alert.enmType error)
        {
            throw new NotImplementedException();
        }

        private void tabPage3_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click_1(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click_2(object sender, EventArgs e)
        {

        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel1_Click_3(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            try {
                changename();
                txt_oldusername.Text = null;
                txt_newusername.Text = null;
                txt_retypedusername.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Somethind went wrong");
            }
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox2_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {

        }

        private void gunaTextBox3_TextChanged_1(object sender, EventArgs e)
        {

        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaLabel8_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            try
            {
                changepassEMP();
                txt_emppass.Text = null;
                txt_emprepass.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            try
            {
                changenameEMP();
                txt_empureuname.Text = null;
                txt_empuname.Text = null;
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            sendSMS s = new sendSMS();
            s.otp();

        }
    }
}
