using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;
using System.Drawing.Printing;
using System.Text.RegularExpressions;

namespace Education_Center
{
    public partial class frm_student : Form
    {
        public frm_student()
        {
            InitializeComponent();
            lbl_rs.Hide();
            indexno();

            picker_year.Format = DateTimePickerFormat.Custom;
            picker_year.CustomFormat = "yyyy";
            picker_year.ShowUpDown = true;
            lbl_year.Text = DateTime.Now.Year.ToString();
        }

        public String stremis = null;
        public String cardemail = null;
        //generating new indexno
        void indexno()
        {
            int number;
            bool got_new_id = true;

            Random n = new Random();

            while (got_new_id)
            {

                MongoClient connect = dbconnector.connection();
                var db = connect.GetDatabase("educationSystem");
                var logindata = db.GetCollection<studentr>("al_students"); //getting student document

                number = n.Next(1000, 100000);

                try //if number exist this will run
                {

                    var filter = Builders<studentr>.Filter.Eq("index", number);
                    var recs = logindata.Find(filter).First();

                }
                catch (Exception)//if not number exist this will run and get the new id
                {
                    got_new_id = false;
                    lbl_id.Text = number.ToString();
                    lbl_id2.Text = number.ToString();
                }

            }
        }


        //get filterd subs
        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("stream", txt_stream.Text) & builder.Eq("grade", txt_grade.Text);

            return std.Find(filter).ToList(); 
        }

        //get common subs
        public List<T> commonsubjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("stream", "Common") & builder.Eq("grade", txt_grade.Text);

            return std.Find(filter).ToList();
        }


        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }

        private void Btn_Submit_Click(object sender, EventArgs e)
        {
             Alert("Success!", frm_Alert.enmType.Success);
        }

        private void Btn_Fees_Click_1(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void Btn_Regis_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }


        private void Btn_next_Click(object sender, EventArgs e)
        {
          
            if (lbl_id.Text.Length >= 4)
            {
                if (txt_ininame.Text.Length>0)
                {
                    if (txt_fname.Text.Length >= 2)
                    {
                        if (txt_lname.Text.Length >= 2)
                        {
                            if (txt_address.Text.Length >= 3)
                            {
                                if (lbl_bd_new.Text.Length >= 0)
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
                                                        if (txt_admitionMonth.SelectedIndex != -1)
                                                        {
                                                            if (txt_stream.SelectedIndex != -1)
                                                            {
                                                                if (sub1.SelectedIndex != -1 || sub2.SelectedIndex != -1 || sub3.SelectedIndex != -1)
                                                                {
                                                                    if (sub1.Text != sub2.Text && sub2.Text != sub3.Text && sub1.Text != sub3.Text)
                                                                    {

                                                                        //opening other page
                                                                        bunifuPages1.SetPage(2);
                                                                    }
                                                                    else
                                                                    {
                                                                        Console.WriteLine(sub1.Text+" "+ sub2.Text+ sub3.Text);

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
            indexno();
            bunifuPages1.SetPage(1);
        }  

        private void Btn_reset_Click_1(object sender, EventArgs e)
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
                        (control as ComboBox).Items.Clear();
                    }
                    else
                    {
                        func(control.Controls);
                    }
                }
            };
            func(Controls);
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            frm_Details obj = new frm_Details();
            obj.Show();
        }

        private void guna2TextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {
            lbl_bd_new.Text = txt_bdg.Text;
        }

        private void btn_Submit_Click_1(object sender, EventArgs e)
        {
            
            String[] register_data = new string[25];

            //getting student data into an array
          register_data[0] = lbl_id.Text;
          register_data[1] = txt_ininame.Text;
          register_data[2] = txt_fname.Text;
          register_data[3] = txt_lname.Text;
          register_data[4] = txt_address.Text;
          register_data[5] = txt_bdg.Text;
          register_data[6] = txt_sex.Text;
          register_data[7] = txt_grade.Text;
          register_data[8] = txt_school.Text;
          register_data[9] = txt_phone.Text;
          register_data[10] = txt_email.Text;
          register_data[11] = txt_admitionMonth.Text;
          register_data[12] = txt_stream.Text;
          register_data[13] = sub1.Text;
          register_data[14] = sub2.Text;
          register_data[15] = sub3.Text;

            //getting parent data
            register_data[16] = lbl_id.Text;
            register_data[17] = txt_p_ini_name.Text;
            register_data[18] = txt_p_fname.Text;
            register_data[19] = txt_p_lname.Text;
            register_data[20] = txt_p_address.Text;
            register_data[21] = txt_p_nic.Text;
            register_data[22] = txt_p_sex.Text;
            register_data[23] = txt_p_phone.Text;
            register_data[24] = txt_p_mail.Text;


            //by making an object it will autimaticly assing the student values in to std_reg_ctrl class arry

            if (lbl_id.Text.Length>0)
            {
                if (txt_p_ini_name.Text.Length>0)
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
                                            if (txt_p_phone.Text.Length == 10 && txt_p_phone.Text[0]=='0')
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
                                                    Zen.Barcode.Code128BarcodeDraw code = Zen.Barcode.BarcodeDrawFactory.Code128WithChecksum;
                                                    box_barcode.Image = code.Draw(lbl_id.Text, 60);


                                                    PrintDocument tmpDoc = new PrintDocument();
                                                    tmpDoc.PrintPage += new PrintPageEventHandler(Tmpdoc_Print);
                                                    PrintPreviewDialog tmpPpd = new PrintPreviewDialog();
                                                    tmpPpd.Document = tmpDoc;
                                                    tmpPpd.ShowDialog();

                                                    String[] subs = { register_data[13], register_data[14], register_data[15] };

                                                    Email send = new Email();

                                                    send.studentregmail(subs , register_data[7] , register_data[2]+" "+ register_data[3], register_data[10], register_data[0]);

                                                    //clearing
                                                    lbl_id.Text = null;
                                                    txt_ininame.Text = null;
                                                    txt_fname.Text = null;
                                                    txt_lname.Text = null;
                                                    txt_address.Text = null;
                                                    txt_bdg.Text = null;
                                                    txt_sex.Text = null;
                                                    txt_grade.Text = null;
                                                    txt_school.Text = null;
                                                    txt_phone.Text = null;
                                                    txt_email.Text = null;
                                                    txt_admitionMonth.Text = null;
                                                    txt_stream.Text = null;
                                                    sub1.Text = null;
                                                    sub2.Text = null;
                                                    sub3.Text = null;
                                                    lbl_id.Text = null;
                                                    txt_p_ini_name.Text = null;
                                                    txt_p_fname.Text = null;
                                                    txt_p_lname.Text = null;
                                                    txt_p_address.Text = null;
                                                    txt_p_nic.Text = null;
                                                    txt_p_sex.Text = null;
                                                    txt_p_phone.Text = null;
                                                    txt_p_mail.Text = null;



                                                    std_reg_ctrl get = new std_reg_ctrl(register_data);
                                                    MessageBox.Show("Student registerd successfully !");
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

        private void Tmpdoc_Print(Object sender, PrintPageEventArgs e)
        {
            e.Graphics.DrawImage(box_barcode.Image, 0, 0);
        }

        private void txt_P_nic_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click(object sender, EventArgs e)
        {
      
        }

        private void txt_p_lname_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void tabPage5_Click(object sender, EventArgs e)
        {

        }

        private void tabPage4_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel29_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel20_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox22_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaSeparator21_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel24_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel30_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel33_Click(object sender, EventArgs e)
        {

        }

        private void guna2TextBox21_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaSeparator18_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown4_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuFlatButton1_Click(object sender, EventArgs e)
        {

            //inserint attendance

            if(dropdown_sub.Text != null && dropdown_month.Text != null && lbl_fee.Text != "")
            {
                try
                {

                    var payment = new mark_fees
                    {
                        index = txt_code.Text,
                        name = lbl_name.Text,
                        date = DateTime.Now.ToLongDateString(),
                        month = dropdown_month.Text,
                        sub = dropdown_sub.Text,
                        fees = lbl_fee.Text,
                        stream = stremis,
                        year = lbl_year.Text
                    };


                    var connect = new MongoClient();
                    var db = connect.GetDatabase("educationSystem");

                    //inserting student
                    var collectionSTD = db.GetCollection<mark_fees>("fees");
                    collectionSTD.InsertOne(payment);

                    Email send = new Email();
                    send.feesRecived(lbl_name.Text, lbl_fee.Text ,dropdown_sub.Text, dropdown_month.Text, cardemail);
;
                    txt_code.Text = null;
                    lbl_name.Text = null;
                    dropdown_sub.Items.Clear();
                    dropdown_sub.Text = null;
                    lbl_fee.Text = null;
                    dropdown_month.Text = null;
                    lbl_rs.Hide();

                    

;                   MessageBox.Show("Payment Done !");

                    lbl_fee.Text = null;
                    lbl_year.Text = DateTime.Now.Year.ToString();
                }
                catch (Exception ex)
                {
                    error.errorNow(ex.ToString() + "in class frm_students [ NORMAL SITUATION ]");
                    MessageBox.Show("No student found !");
                }
            }
            else
            {
                MessageBox.Show("Please fill out every filed !");
            }


           }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
          
        }

        private void txt_p_phone_KeyPress(object sender, KeyPressEventArgs e)
        {

            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }

        }

        private void txt_phone_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) )
            {
                e.Handled = true;
            }

       
        }

        private void txt_phone_KeyDown(object sender, KeyEventArgs e)
        {

        }

        private void txt_ininame_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !(e.KeyChar != '.'))
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

        private void txt_grade_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_grade_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_school_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_school_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && (e.KeyChar != ' '))
            {
                e.Handled = true;
            }
        }

        private void txt_p_ini_name_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_p_ini_name_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_p_fname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_p_lname_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txt_p_nic_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) && (e.KeyChar != 'V'))
            {
                e.Handled = true;
            }
        }

        private void tabPage6_Click(object sender, EventArgs e)
        {

        }

        private void txt_stream_SelectedValueChanged(object sender, EventArgs e)
        {
            //setting subjects from db

            try {
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

        private void dropdown_sub_SelectedValueChanged(object sender, EventArgs e)
        {
            try
            {
                var subs = getFee<subjectr>();

                foreach(var fees in subs)
                {
                    lbl_fee.Text = fees.fee;
                }
                datafiller();
                lbl_rs.Show()
;            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong !");
            }
        }

        public void datafiller()
        {
            String[] subs = new string[3];

            try
            {
                DataTable table_data = new DataTable();

                table_data.Columns.Add("month");
                table_data.Columns.Add("payment");
                table_data.Columns.Add("year");


                for (int i = 0; i < 3; i++)
                {
                    subs[i] = null;
                }

                grid_months.DataSource = table_data;

                var recs = getfees<mark_feesr>();

                foreach (var rec in recs)
                {

                    subs[0] = rec.month;
                    subs[1] = rec.fees;
                    subs[2] = rec.year;

                    table_data.Rows.Add(subs);

                }

                grid_months.DataSource = table_data;

            }
            catch (Exception e)
            {
                subs[0] = null;
            }


        }

        //student filter by dropdown menu
        public List<T> getfees<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("fees");

            var builder = Builders<T>.Filter;
            var filter1 = builder.Eq("index", txt_code.Text) & builder.Eq("sub", dropdown_sub.Text);
            return std.Find(filter1).ToList();
        }


        //getting fee 
        public List<T> getFee<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("name", dropdown_sub.Text);

            return std.Find(filter).ToList(); 
        }

        private void gunaGradientTileButton1_Click(object sender, EventArgs e)
        {
            try
            {
                student_model model = new student_model();
                String[] data = model.found(txt_code.Text);

                stremis = data[12];
                cardemail = data[18];

                lbl_name.Text = data[1] + " " + data[2] + " " + data[3];
                dropdown_sub.Items.Clear();
                for (int i = 13; i <= 15; i++)
                {
                    if (data[i] != null)
                    {
                        dropdown_sub.Items.Add(data[i]);
                    }
                }




            }
            catch (Exception)
            {
                MessageBox.Show("No result found !");
            }
        }

        private void gunaLabel31_Click(object sender, EventArgs e)
        {
            lbl_year.Text = picker_year.Value.Year.ToString();
        }

        private void txt_stream_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2GradientButton1_Click_1(object sender, EventArgs e)
        {
            sub3.Text = "";
        }

        private void guna2GradientButton3_Click(object sender, EventArgs e)
        {
            sub1.Text = "";
        }

        private void guna2GradientButton2_Click_1(object sender, EventArgs e)
        {
            sub2.Text = "";
        }

        private void guna2GradientButton4_Click(object sender, EventArgs e)
        {
            txt_stream.Text = null;
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
