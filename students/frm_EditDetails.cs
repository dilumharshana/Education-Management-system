using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;
using System.Text.RegularExpressions;

namespace Education_Center
{
    public partial class frm_EditDetails : Form
    {
        public frm_EditDetails(String[] data)
        {

            InitializeComponent();

            lbl_id.Text = data[0];
            txt_ininame.Text = data[1];
            txt_fname.Text = data[2];
            txt_lname.Text = data[3];
            txt_address.Text = data[4];
            txt_bd.Text = data[5];
            txt_sex.Text = data[6];
            txt_grade.Text = data[7];
            txt_school.Text = data[8];
            txt_phone.Text = data[9];
            dropdown_amonth.Text = data[10];
            txt_email.Text = data[11];
            dropdown_stream.Text = data[12];
            sub1.Text = data[13];
            sub2.Text = data[14];
            sub3.Text = data[15];

            txt_p_ini_name.Text = data[16]; ;
            txt_p_fname.Text = data[17]; ;
            txt_p_lname.Text = data[18]; ;
            txt_p_address.Text = data[19]; ;
            txt_p_nic.Text = data[20]; ;
            txt_p_sex.Text = data[21]; ;
            txt_p_phone.Text = data[22]; ;
            txt_pemail.Text = data[23]; ;
        }

        private void Btn_next_Click_1(object sender, EventArgs e)
        {
            if (lbl_id.Text.Length >= 4)
            {
                if (txt_ininame.Text.Length > 0)
                {
                    if (txt_fname.Text.Length >= 2)
                    {
                        if (txt_lname.Text.Length >= 2)
                        {
                            if (txt_address.Text.Length >= 3)
                            {
                                if (txt_bd.Text.Length >= 0 && txt_bd.Text != DateTime.Today.ToString())
                                {
                                    if (txt_sex.SelectedIndex != -1)
                                    {
                                        if (txt_grade.SelectedIndex != -1)
                                        {
                                            if (txt_school.Text.Length >= 0)
                                            {
                                                if (txt_phone.Text.Length == 10 && txt_phone.Text[0] == '0')
                                                {
                                                    //veryfing email
                                                    bool mailok = true;

                                                    string email = txt_email.Text;
                                                    Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");
                                                    Match match = regex.Match(email);
                                                    if (match.Success)
                                                    {
                                                        mailok = true;
                                                    }

                                                    else
                                                    {
                                                        mailok = false;
                                                    }

                                                    if (txt_email.Text.Length > 0 && mailok)
                                                    {
                                                        if (dropdown_amonth.SelectedIndex != -1)
                                                        {
                                                            if (dropdown_stream.SelectedIndex != -1)
                                                            {
                                                                if (sub1.SelectedIndex != -1 || sub2.SelectedIndex != -1 || sub3.SelectedIndex != -1)
                                                                {
                                                                    if (sub1.Text != sub2.Text && sub2.Text != sub3.Text && sub1.Text != sub3.Text)
                                                                    {

                                                                        //opening other page
                                                                        bunifuPages1.SetPage(1);
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine(sub1.Text + " " + sub2.Text + sub3.Text);

                                                                        MessageBox.Show("Please select subjects in correct order  !");
                                                                    }

                                                                }
                                                                else
                                                                {
                                                                    MessageBox.Show("please choose a subjects");
                                                                }
                                                            }
                                                            else
                                                            {
                                                                MessageBox.Show("please choose a stream");
                                                            }
                                                        }
                                                        else
                                                        {
                                                            MessageBox.Show("please choose admition month");
                                                        }
                                                    }
                                                    else
                                                    {
                                                        MessageBox.Show("please provide valid email address");
                                                    }
                                                }
                                                else
                                                {
                                                    MessageBox.Show("please provide valid phone number");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("please fill your school !");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("please fill choose your grade !");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("please fill choose your gender !");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("please fill choose your birthday !");
                                }
                            }
                            else
                            {
                                MessageBox.Show("please fill last address !");
                            }
                        }
                        else
                        {
                            MessageBox.Show("please fill last name !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("please fill first name !");
                    }
                }
                else
                {
                    MessageBox.Show("please fill name Initial !");
                }
            }
            else
            {
                MessageBox.Show("Something went wrong with the system please restart !");
            }


        }

        private void Btn_previous_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void Btn_reset2_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (Controls) =>
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };
            func(Controls);
        }

        private void Btn_reset_Click(object sender, EventArgs e)
        {
            Action<Control.ControlCollection> func = null;
            func = (Controls) =>
            {
                foreach (Control control in Controls)
                {
                    if (control is TextBox)
                    {
                        (control as TextBox).Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };
            func(Controls);
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Btn_Update_Click(object sender, EventArgs e)
        {
            if (lbl_id.Text.Length > 0)
            {
                if (txt_p_ini_name.Text.Length > 0)
                {
                    if (txt_p_fname.Text.Length > 2)
                    {
                        if (txt_p_lname.Text.Length > 2)
                        {
                            if (txt_p_address.Text.Length > 2)
                            {
                                if (txt_p_nic.Text.Length > 2)
                                {
                                    bool nicok = true;


                                    if (txt_p_nic.Text.Length == 10 && txt_p_nic.Text[9] == 'V')
                                    {
                                        nicok = true;
                                    }
                                    else if (txt_p_nic.Text.Length == 12)
                                    {
                                        nicok = true;
                                    }
                                    else
                                    {
                                        nicok = false;
                                    }


                                    if (nicok)
                                    {
                                        if (txt_p_sex.SelectedIndex != -1)
                                        {
                                            if (txt_p_phone.Text.Length == 10 && txt_p_phone.Text[0] == '0')
                                            {
                                                // veryfing email
                                                bool mailokP = true;

                                                Match match = null;

                                                string emailP = txt_email.Text;
                                                Regex regex = new Regex(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$");

                                                match = regex.Match(emailP);
                                                if (match.Success)
                                                {

                                                    mailokP = true;
                                                }

                                                else
                                                {
                                                    mailokP = false;
                                                }

                                                if (mailokP)
                                                {
                                                    MongoClient connect = dbconnector.connection();
                                                    var db = connect.GetDatabase("educationSystem");

                                                    var logdata = db.GetCollection<studentr>("al_students"); //getting student document
                                                    var logdataP = db.GetCollection<studentr>("parent"); //getting parent document

                                                    var filter = Builders<studentr>.Filter.Eq("index", lbl_id.Text);

                                                    var rec = logdata.Find(filter).First();

                                                    var initial = Builders<studentr>.Update.Set("initials", txt_ininame.Text);
                                                    var fn = Builders<studentr>.Update.Set("firstname", txt_fname.Text);
                                                    var ln = Builders<studentr>.Update.Set("lastname", txt_lname.Text);
                                                    var add = Builders<studentr>.Update.Set("address", txt_address.Text);
                                                    var dob = Builders<studentr>.Update.Set("dob", txt_bd.Text);
                                                    var gender = Builders<studentr>.Update.Set("gender", txt_sex.Text);
                                                    var grade = Builders<studentr>.Update.Set("grade", txt_grade.Text);
                                                    var scl = Builders<studentr>.Update.Set("school", txt_school.Text);
                                                    var phone = Builders<studentr>.Update.Set("phone", txt_phone.Text);
                                                    var mail = Builders<studentr>.Update.Set("email", txt_email.Text);
                                                    var amonth = Builders<studentr>.Update.Set("admitionmonth", dropdown_amonth.Text);
                                                    var stream = Builders<studentr>.Update.Set("stream", dropdown_stream.Text);
                                                    var sub = Builders<studentr>.Update.Set("sub1", sub1.Text);
                                                    var subtwo = Builders<studentr>.Update.Set("sub2", sub2.Text);
                                                    var subthree = Builders<studentr>.Update.Set("sub3", sub3.Text);

                                                    logdata.UpdateOne(filter, initial);
                                                    logdata.UpdateOne(filter, fn);
                                                    logdata.UpdateOne(filter, ln);
                                                    logdata.UpdateOne(filter, add);
                                                    logdata.UpdateOne(filter, dob);
                                                    logdata.UpdateOne(filter, gender);
                                                    logdata.UpdateOne(filter, grade);
                                                    logdata.UpdateOne(filter, scl);
                                                    logdata.UpdateOne(filter, phone);
                                                    logdata.UpdateOne(filter, mail);
                                                    logdata.UpdateOne(filter, amonth);
                                                    logdata.UpdateOne(filter, stream);
                                                    logdata.UpdateOne(filter, sub);
                                                    logdata.UpdateOne(filter, subtwo);
                                                    logdata.UpdateOne(filter, subthree);

                                                    var pini = Builders<studentr>.Update.Set("initials", txt_p_ini_name.Text);
                                                    var pfname = Builders<studentr>.Update.Set("firstname", txt_p_fname.Text);
                                                    var plname = Builders<studentr>.Update.Set("lastname", txt_p_lname.Text);
                                                    var padreess = Builders<studentr>.Update.Set("address", txt_p_address.Text);
                                                    var nic = Builders<studentr>.Update.Set("nic", txt_p_nic.Text);
                                                    var pgender = Builders<studentr>.Update.Set("gender", txt_p_sex.Text);
                                                    var pcontact = Builders<studentr>.Update.Set("phone", txt_p_phone.Text);
                                                    var pmail = Builders<studentr>.Update.Set("email", txt_pemail.Text);


                                                    logdataP.UpdateOne(filter, pini);
                                                    logdataP.UpdateOne(filter, pfname);
                                                    logdataP.UpdateOne(filter, plname);
                                                    logdataP.UpdateOne(filter, padreess);
                                                    logdataP.UpdateOne(filter, nic);
                                                    logdataP.UpdateOne(filter, pgender);
                                                    logdataP.UpdateOne(filter, pcontact);
                                                    logdataP.UpdateOne(filter, pmail);


                                                    txt_ininame.Text = null;
                                                    txt_fname.Text = null;
                                                    txt_lname.Text = null;
                                                    txt_address.Text = null;
                                                    txt_sex.Text = null;
                                                    txt_grade.Text = null;
                                                    txt_school.Text = null;
                                                    txt_phone.Text = null;
                                                    txt_email.Text = null;
                                                    dropdown_amonth.Text = null;
                                                    dropdown_stream.Text = null;
                                                    this.sub1.Text = null;
                                                    this.sub2.Text = null;
                                                    this.sub3.Text = null;

                                                    MessageBox.Show("Data updates successfully !");
                                                    this.Dispose();
                                                }
                                                else
                                                {
                                                    MessageBox.Show("Enter a valid email address !");
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("Please provide a valid phone number !");
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("Please choose your gender !");
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("Please enter valid nic number !");
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("Please fill nic number!");
                                }
                            }
                            else
                            {
                                MessageBox.Show("Please fill address!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please fill last name!");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill first name!");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill name initials !");
                }
            }
            else
            {
                MessageBox.Show("Sorry something went wrong in sysytem please restart !");
            }

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown3_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_dob_ValueChanged(object sender, EventArgs e)
        {
            txt_bd.Text = txt_dob.Text;
        }

        private void txt_initials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_grade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_school_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_stdcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_pinitials_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_pfname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_plname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_pcontact_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_nic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 'V'))
            {
                e.Handled = true;
            }
        }

        private void dropdown_stream_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {

                try
                {
                    var subs = subjects<subjectr>();
                    var subsCommon = commonsubjects<subjectr>();

                    sub1.Items.Clear();
                    sub2.Items.Clear();
                    sub3.Items.Clear();

                    List<string> subsare = new List<string>();

                    foreach (var sub in subs)
                    {
                        if (!subsare.Contains(sub.name))
                        {
                            subsare.Add(sub.name);
                        }
                    }

                    foreach (var csub in subsCommon)
                    {
                        if (!subsare.Contains(csub.name))
                        {
                            subsare.Add(csub.name);
                        }
                    }

                    foreach (var s in subsare)
                    {
                        sub1.Items.Add(s);
                        sub2.Items.Add(s);
                        sub3.Items.Add(s);
                    }

                    sub1.Items.Add("NONE 1");
                    sub2.Items.Add("NONE 2");
                    sub3.Items.Add("NONE 3");
                }
                catch (Exception)
                {
                    MessageBox.Show("Something went wrong");
                }

            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
                error.errorNow(e.ToString() + "in class frm_editdetails [ RISK SITUATION ]");
            }
        }

        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("stream", dropdown_stream.Text);

            return std.Find(filter).ToList();
        }

        //get common subs
        public List<T> commonsubjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("stream", "Common");

            return std.Find(filter).ToList();
        }

        private void gunaLabel7_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void txt_grade_SelectedValueChanged(object sender, EventArgs e)
        {
            sub1.Items.Clear();
            sub2.Items.Clear();
            sub3.Items.Clear();

            sub1.Items.Add("NONE 1");
            sub2.Items.Add("NONE 2");
            sub3.Items.Add("NONE 3");
        }
    }

}
