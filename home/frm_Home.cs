using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Windows.Forms;
using MongoDB.Driver;



namespace Education_Center
{
    public partial class frm_Home : Form
    {

        //Feilds
        private Form currentChildForm;
        bool auto = true;
        //public frm_Home() for ADMIN
        public frm_Home(string val)
        {
            InitializeComponent();
            lblName.Text = val;
            setupInterface();
            sendmails();
            //Form
             MaximizedBounds = Screen.FromHandle( Handle).WorkingArea;
        }

        //for payment message sending
        bool payment = true;


        void sendmails() {

            Email mail = new Email(); //Pass html string to Email function. 

            bool mailsent = mail.cheksents();

            if (!mailsent) 
            {
                mail.sendmail();
            }

        }

        void setupInterface()
        {
            txt_stdCode.Text = null;
            btn_mark.Hide();
            btn_payment.Hide();
            btn_search.Hide();
            lbl_noresult.Hide();
            pnl_student.Hide();
            pnl_data.Hide();
            pnl_chek.Show();
            dropdown_sub.Items.Clear();
            dropdown_sub.Text = null;

        }

        //public frm_Home() CASHIER
        public frm_Home(string val , bool role)
        {
            InitializeComponent();
            setupInterface();
            lblName.Text = val;
            btnSettings.Hide();
            btnDashbord.Hide();
            btn_msg.Hide();

            //Form
             MaximizedBounds = Screen.FromHandle( Handle).WorkingArea;
        }

        //Title bar
        //Drag form
        [DllImport("user32.DLL", EntryPoint = "ReleaseCapture")]
        private extern static void ReleaseCapture();

        [DllImport("user32.DLL", EntryPoint = "SendMessage")]
        private extern static void SendMessage(System.IntPtr hWnd, int wMsg, int wParm, int lParam);

        private void PanelTitlebar_MouseDown(object sender, MouseEventArgs e)
        {
            ReleaseCapture();
            SendMessage( Handle, 0x112, 0xf012, 0);
        }

       


        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");
            var builder = Builders<T>.Filter;
            var filter1 = builder.Eq("day", DateTime.Now.DayOfWeek.ToString()) ;
            Console.WriteLine(DateTime.Now.DayOfWeek.ToString());
            return std.Find(filter1).ToList();
        }


        public List<T> attends<T>(String sub)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("attendance");
            var builder = Builders<T>.Filter;
            var filter1 = builder.Eq("sub", sub);

            return std.Find(filter1).ToList();
        }


        //title bar buttons
        private void Guna2GradientButton1_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to Exit programe?", "Exit", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                Application.ExitThread();
            }
            else if (dialog == DialogResult.No)
            {
                //Do nothing
            }
        }

        private void Guna2GradientButton2_Click(object sender, EventArgs e)
        {
            if (WindowState == FormWindowState.Normal)
            {
                WindowState = FormWindowState.Maximized;
            }
            else
                WindowState = FormWindowState.Normal;
        }

        private void Btn_Minimize_Click(object sender, EventArgs e)
        {
            WindowState = FormWindowState.Minimized;
        }

        //Time
        private void PanelHome_Paint(object sender, PaintEventArgs e)
        {
            timer1.Start();
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            lblDate.Text = DateTime.Now.ToLongDateString();
            lblTime.Text = DateTime.Now.ToLongTimeString();
        }

        //Open multi forms
        private void OpenChildForm(Form childForm)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
            currentChildForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panelHome.Controls.Add(childForm);
            panelHome.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        //Menu Buttons
        private void BtnHome_Click_1(object sender, EventArgs e)
        {
            if (currentChildForm != null)
            {
                currentChildForm.Close();
            }
        }

        private void BtnStudent_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frm_student());
        }

        private void BtnTeacher_Click_1(object sender, EventArgs e)
        {
            OpenChildForm(new frm_teacher());
        }

        private void BtnBook_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_Subject());
        }

        private void BtnDashbord_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_Dashbord());
        }

        private void BtnSettings_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_Settings(false));
        }

        private void Btn_SignOut_Click(object sender, EventArgs e)
        {
            DialogResult dialog = MessageBox.Show("Do you really want to signout?", "Sign Out", MessageBoxButtons.YesNo);
            if (dialog == DialogResult.Yes)
            {
                 Close();
                frm_Login obj = new frm_Login();
                obj.Show();
            }
            else if (dialog == DialogResult.No)
            {
                //Do nothing
            }           
        }

        //toolTips

        private void BtnHome_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Home", btnHome);
        }

        private void BtnStudent_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Student", btnStudent);
        }

        private void BtnTeacher_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Teacher", btnTeacher);
        }

   

        private void BtnDashbord_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Dashbord", btnDashbord);
        }

        private void BtnSettings_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Settings", btnSettings);
        }

        private void GunaPictureBox2_MouseHover(object sender, EventArgs e)
        {
         
        }

        private void Btn_SignOut_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Sign Out", btn_SignOut);
        }

        private void gunaLineTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            if (!auto)
            {
                search_ctrl id = new search_ctrl(txt_stdCode.Text);
                id.getData();
                txt_stdCode.Text = "";

            }
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel1_Click(object sender, EventArgs e)
        {

        }

        private void pnl_student_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuCustomLabel5_Click(object sender, EventArgs e)
        {

        }

        private void btn_mark_Click(object sender, EventArgs e)
        {
            if(dropdown_sub.Text != null)
            {
                String[] data = new string[8];

                DateTime datetime = DateTime.Now;
                int year = DateTime.Now.Year;

                var recs = getStream<subjectr>(dropdown_sub.Text);

                data[0] = lbl_index.Text;
                data[1] = lbl_name.Text;
                data[2] = DateTime.Now.ToLongDateString(); ; 
                data[3] = DateTime.Now.ToLongTimeString();
                data[4] = dropdown_sub.Text;
                data[5] = datetime.ToString("MMMM");
                data[6] = year.ToString();
                data[7] = lbl_stream.Text;

                String tp = null;

                foreach(var rec in recs)
                {
                    data[7] = rec.stream;
                }
                

               attend_ctrl mark = new attend_ctrl(data);

                if (!payment)
                {
                    if (Int16.Parse(datetime.Day.ToString()) >= 14)
                    {
                        Email send = new Email();
                        send.feesnotRecived(lblName.Text, dropdown_sub.Text, datetime.ToString("MMM"), lbl_email.Text);
                    }
                }

                dropdown_sub.Items.Clear();
                dropdown_sub.Text = null;

                sendSMS msg = new sendSMS();
                msg.stdmark(lbl_contact.Text , lbl_name.Text);



                setupInterface();
            }
            else
            {
                MessageBox.Show("Please Select the subject");
            }
        }

        public List<T> getStream<T>(String subject)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("name", subject);

               return std.Find(filter1).ToList();
        }

        private void bunifuCustomLabel13_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            pnl_data.Hide();
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuCustomLabel21_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {
            setupInterface();
        }

        private void bunifuImageButton2_Click(object sender, EventArgs e)
        {
            pnl_data.Show();
        }

        public static void setData(String[] data)
        {

            if(data[0] != null)
            {
                pnl_chek.Hide();
                btn_mark.Show();
                pnl_student.Show();

                lbl_index.Text = data[0];
                lbl_name.Text = data[2] + " " + data[3];
                lbl_address.Text = data[4];
                lbl_contact.Text = data[9];
                lbl_email.Text = data[11];
                lbl_scl.Text = data[8];
                lbl_stream.Text = data[12];
                lbl_subs.Text = data[13] + " , " + data[14] + " , " + data[15];

                for(int i=13; i<=15; i++)
                {
                    if(data[i] != null)
                    {
                        dropdown_sub.Items.Add(data[i]);
                    }
                }

                lbl_pname.Text = data[16];
                lbl_Pcontact.Text = data[17];
            }
            


        }

        private void lbl_nic_Click(object sender, EventArgs e)
        {

        }

        private void lbl_address_Click(object sender, EventArgs e)
        {

        }

        private void lbl_contact_Click(object sender, EventArgs e)
        {

        }

        private void lbl_email_Click(object sender, EventArgs e)
        {

        }

        private void lbl_scl_Click(object sender, EventArgs e)
        {

        }

        private void lbl_stream_Click(object sender, EventArgs e)
        {

        }

        private void lbl_pname_Click(object sender, EventArgs e)
        {

        }

        private void lbl_Pcontact_Click(object sender, EventArgs e)
        {

        }

        private void lblTime_Click(object sender, EventArgs e)
        {

        }

        private void btn_payment_Click(object sender, EventArgs e)
        {

        }

        private void dropdown_sub_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void dropdown_sub_SelectedValueChanged(object sender, EventArgs e)
        {
            String paid = chekfee(lbl_index.Text);

            if(paid == "PAID")
            {
                btn_payment.Hide();
            }
            else
            {
                btn_payment.Show();
                payment = false;
            }
        }
        public String chekfee(String index)
        {
            String paid = "";
            DateTime datetime = DateTime.Now;

            try
            {
                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");
                var std = db.GetCollection<mark_feesr>("fees");

                var builder = Builders<mark_feesr>.Filter;
                
                var filter1 = builder.Eq("index", index) & builder.Eq("sub", dropdown_sub.Text) & builder.Eq("month", datetime.ToString("MMMM")) & builder.Eq("year", DateTime.Now.Year.ToString()) ;
                var precs = std.Find(filter1).First();
                paid = "PAID";
            }
            catch (Exception d)
            {
                Console.WriteLine(d);
                paid = "NOT PAID";
            }

            //sending message after 2 weeks
            if (paid == "NOT PAID")
            {
                try
                {
                    int day = Int16.Parse(datetime.ToString("DD"));

                    if (day >= 14)
                    {

                    }
                }
                catch (Exception)
                {

                }
            
            }



            return paid;
        }

        private void txt_stdCode_KeyPress(object sender, KeyPressEventArgs e)
        {
           
        }

        private void switch_AM_OnValuechange(object sender, EventArgs e)
        {
            if (!auto)
            {
                auto = true;
            }
            else
            {
                auto = false;
            }
        }

        private void txt_stdCode_KeyUp(object sender, KeyEventArgs e)
        {
            if (auto)
            {
                search_ctrl id = new search_ctrl(txt_stdCode.Text.Trim());
                Console.WriteLine(txt_stdCode.Text);
                id.getData();
                txt_stdCode.Text = "";
            }
        }

        private void gunaTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            search_ctrl id = new search_ctrl(txt_stdCode.Text);
            id.getData();
            txt_stdCode.Text = "";
        }

        private void txt_stdCode_KeyUp_1(object sender, KeyEventArgs e)
        {

            if (!auto)
            {
                if (txt_stdCode.Text.Length > 0)
                {
                    btn_search.Show();
                }
                else
                {
                    btn_search.Hide();
                }
            }
            else
            {
                search_ctrl id = new search_ctrl(txt_stdCode.Text);
                id.getData();
                txt_stdCode.Text = "";
            }
        }

        private void txt_stdCode_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            OpenChildForm(new frm_Subject());
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            class_attend open = new class_attend();
            open.Show();
        }

        private void bunifuImageButton3_Click(object sender, EventArgs e)
        {
            message open = new message();
            open.Show();
        }
    }
}
