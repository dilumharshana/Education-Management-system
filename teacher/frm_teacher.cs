using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Bson;
using MongoDB.Driver;

namespace Education_Center
{
    public partial class frm_teacher : Form
    {
        public frm_teacher()
        {
            InitializeComponent();
            teacherID();
        }

        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }

        void teacherID()
        {
            int number;
            bool got_new_id = true;

            Random n = new Random();

            while (got_new_id)
            {

                MongoClient connect = dbconnector.connection();
                var db = connect.GetDatabase("educationSystem");
                var logindata = db.GetCollection<teacherR>("teacher"); //getting teacher document

                number = n.Next(1000, 100000);

                try //if number exist this will run
                {

                    var filter = Builders<teacherR>.Filter.Eq("index", number);
                    var recs = logindata.Find(filter).First();

                }
                catch (Exception)//if not number exist this will run and get the new id
                {
                    got_new_id = false;
                    lblId.Text = number.ToString();
                   // lbl_id2.Text = number.ToString();
                }

            }
        }

        private void BtncClear_Click(object sender, EventArgs e)
        {

            clear();
        }

        void clear()
        {
            teacherID();
            txtTeacherName.Clear();
            txtAddress.Clear();
            txtPhoneNumber.Clear();
            txtEmail.Clear();
            DrpSubject.ResetText();
            DrpGender.ResetText();
        }

        private void BtnAddTeacher_Click(object sender, EventArgs e)
        {
            if (txtTeacherName.Text.Length > 2)
            {
                if (DrpSubject.Text.Length  > 2)
                {
                    if (txtAddress.Text.Length > 2)
                    {
                        if (DrpGender.SelectedIndex != -1)
                        {
                            if (txtPhoneNumber.Text.Length == 10 && txtPhoneNumber.Text[0]=='0')
                            {

                                //veryfing email
                                bool mailok = true;

                                string email = txtEmail.Text;
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

                                    if (mailok)
                                    {
                                    String[] regDetails = new string[7];

                                    regDetails[0] = lblId.Text;
                                    regDetails[1] = txtTeacherName.Text;
                                    regDetails[2] = DrpSubject.Text;
                                    regDetails[3] = txtAddress.Text;
                                    regDetails[4] = DrpGender.Text;
                                    regDetails[5] = txtPhoneNumber.Text;
                                    regDetails[6] = txtEmail.Text;

                                    teacher_reg get = new teacher_reg(regDetails);
                                    Alert("Registerd successfully!", frm_Alert.enmType.Success);
                                    clear();
                                    //this.Dispose();
                                }
                                else
                                    {
                                        MessageBox.Show("Please enter a valid email address !");
                                    }
                            }
                            else
                            {
                                MessageBox.Show("Please enter a valid phone number!");
                            }
                        }
                        else
                        {
                            MessageBox.Show("Please choose gender !");
                        }
                    }
                    else
                    {
                        MessageBox.Show("Please fill address !");
                    }
                }
                else
                {
                    MessageBox.Show("Please fill subject !");
                }
            }
            else
            {
                MessageBox.Show("Please fill name !");
            }
   

        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            frm_TeacherDetails obj = new frm_TeacherDetails();
            obj.Show();
        }

        private void Frm_teacher_Load(object sender, EventArgs e)
        {

        }

        private void txtTeacherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void DrpSubjects_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void txtPhoneNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        private void txtEmail_KeyPress(object sender, KeyPressEventArgs e)
        {
        }
    }
}
