using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    public partial class message : Form
    {
        public message()
        {
            InitializeComponent();
            setsubs();
            setgrade();
            setteacher();
        }

        public message(String index )
        {
            InitializeComponent();
            setsubs();
            setgrade();
            setteacher();

            txt_indexSinglestudent.Text = index;
        }

        public message(String teacher, String data)
        {
            InitializeComponent();
            setsubs();
            setgrade();
            setteacher();

            dropdown_teacher.Text = teacher;
            lbl_sub.Text = teacher;
            msg.SetPage(1);
            
        }

        void setsubs()
        {

            List<string> sbs = new List<string>();


            var recs = subjects<subjectr>();

            foreach (var rec in recs)
            {
                if (!sbs.Contains(rec.name))
                {
                    sbs.Add(rec.name);
                }
            }

            dropdown_subjects.Items.Clear();

            for (int i=0; i < sbs.Count; i++)
            {
                dropdown_subjects.Items.Add(sbs[i]);
            }

        }

        void setteacher()
        {
            var recs = teachers<teacherR>();
            dropdown_teacher.Items.Clear();
            foreach (var rec in recs)
            {
                dropdown_teacher.Items.Add(rec.name);
            }
        }

        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            return std.Find(new BsonDocument()).ToList();
        }

        public List<T> teachers<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("teachers");

            return std.Find(new BsonDocument()).ToList();
        }


        //get specific teacher
        public List<T> getteachers<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("teachers");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("index", lbl_sub.Text);

            return std.Find(filter1).ToList();
        }


        //setting dardes to dropdown menu

        void setgrade()
        {
            dropdown_grade.Items.Clear();

            dropdown_grade.Items.Add("12");
            dropdown_grade.Items.Add("13");
            dropdown_grade.Items.Add("Revesion");
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            
        }


        void sendMail(string email , String msg)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("educationaplus6@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "A Plus Education Center";
                    mail.Body = "<p>" + msg + "</p>";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }
                this.Alert("Message Sent!", frm_Alert.enmType.Success);
            }
            catch (Exception e) { MessageBox.Show("Some thing went wrong check your internet connection and try agan !");
                error.errorNow(e.ToString() + "in class class_attend [ RISK SITUATION ]");
            }
        }

        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }


        //getting student for sending single email
        public List<T> getstudent<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("index", txt_indexSinglestudent.Text);

            return std.Find(filter1).ToList();
        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceTileButton1_Click(object sender, EventArgs e)
        {
            msg.SetPage(1);
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton6_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
           
        }

        private void gunaAdvenceTileButton3_Click(object sender, EventArgs e)
        {
            msg.SetPage(0);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

        }

        private void dropdown_teacher_SelectedValueChanged(object sender, EventArgs e)
        {
            lbl_sub.Text = dropdown_teacher.Text;
        }

        public List<T> teachermail<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("teachers");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("name", dropdown_teacher.Text);

            return std.Find(filter1).ToList();
        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage2_Click(object sender, EventArgs e)
        {

        }

        private void gunaLabel2_Click(object sender, EventArgs e)
        {

        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceTileButton2_Click(object sender, EventArgs e)
        {
            msg.SetPage(2);
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            if (msg_dev.Text.Length>0)
            {
                Email send = new Email();
                send.toDeveloper(msg_dev.Text);
            }
            else
            {
                MessageBox.Show("Please enter message to send");
            }
        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            if (dropdown_teacher.Text.Length > 0 && msg_teacer.Text.Length > 0)
            {
                String email = null;

                var recs = teachermail<teacherR>();

                foreach (var rec in recs)
                {
                    email = rec.email;
                }

                if (email != null)
                {
                    sendMail(email, msg_teacer.Text);
                }
                else
                {
                    MessageBox.Show("Teacher's data is  not avaible to send email ");
                }

            }
            else
            {
                MessageBox.Show("Please fillout every field !");
            }
        }

        private void gunaAdvenceButton5_Click(object sender, EventArgs e)
        {
            if (txt_indexSinglestudent.Text.Length > 0 && msg_singleStudent.Text.Length > 0)
            {
                String email = null;

                var recs = getstudent<studentr>();

                foreach (var rec in recs)
                {
                    email = rec.email;
                }

                if (email != null)
                {
                    sendMail(email, msg_singleStudent.Text);
                }
                else
                {
                    MessageBox.Show("Incorrect index number or student not exist !");
                }

            }
            else
            {
                MessageBox.Show("Please fillout every field !");
            }
        }

        private void gunaAdvenceButton6_Click(object sender, EventArgs e)
        {
            if (dropdown_subjects.Text != null && dropdown_grade.Text != null && msg_streamStudent.Text.Length > 0)
            {

                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");
                var std = db.GetCollection<studentr>("al_students");

                var builder = Builders<studentr>.Filter;

                var filter1 = builder.Eq("sub1", dropdown_subjects.Text) & builder.Eq("grade", dropdown_grade.Text) | builder.Eq("sub2", dropdown_subjects.Text) & builder.Eq("grade", dropdown_grade.Text) | builder.Eq("sub3", dropdown_subjects.Text) & builder.Eq("grade", dropdown_grade.Text);

                var recs = std.Find<studentr>(filter1).ToList();

                bool available = false;

                foreach (var rec in recs)
                {
                    available = true;
                }

                if (available)
                {
                    try
                    {

                        foreach (var rec in recs)
                        {
                            using (MailMessage mail = new MailMessage())
                            {
                                mail.From = new MailAddress("educationaplus6@gmail.com");
                                mail.To.Add(rec.email);
                                mail.Subject = "A Plus Education Center";
                                mail.Body = "<p>" + msg_singleStudent.Text + "</p> <br/>";
                                mail.IsBodyHtml = true;

                                using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                                {
                                    smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                                    smtp.EnableSsl = true;
                                    smtp.Send(mail);
                                }
                            }
                        }
                    }
                    catch (Exception)
                    {
                        MessageBox.Show("Something went wrong check your internet connection !");
                        error.errorNow(e.ToString() + "in class class_attend [ RISK SITUATION  ]");
                    }
                }
                else
                {
                    MessageBox.Show("No class available");
                }
            }
            else
            {
                MessageBox.Show("Please provide all inputs !");
            }
        }

        private void gunaLabel6_Click(object sender, EventArgs e)
        {
            display_error open = new display_error();
            open.Show();
;        }
    }
}
