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
    public partial class frm_TeacherEditDetails : Form
    {
        public frm_TeacherEditDetails(String[] data)
        {
            InitializeComponent();

            lblId.Text = data[0];
            txtTeacherName.Text = data[1];
            DrpSubject.Text = data[2];
            txtAddress.Text = data[3];
            DrpGender.Text = data[4];
            txtPhoneNumber.Text = data[5];
            txtEmail.Text = data[6];
        }

        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnUpdateTeacher_Click(object sender, EventArgs e)
        {
            if (txtTeacherName.Text.Length > 2)
            {
                if (DrpSubject.Text.Length > 2)
                {
                    if (txtAddress.Text.Length > 2)
                    {
                        if (DrpGender.SelectedIndex != -1)
                        {
                            if (txtPhoneNumber.Text.Length == 10 && txtPhoneNumber.Text[0] == '0')
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
                                    MongoClient connect = dbconnector.connection();
                                    var db = connect.GetDatabase("educationSystem");

                                    var logdata = db.GetCollection<teacherR>("teachers");

                                    var filter = Builders<teacherR>.Filter.Eq("index", lblId.Text);

                                    var rec = logdata.Find(filter).First();

                                    var name = Builders<teacherR>.Update.Set("name", txtTeacherName.Text);
                                    var sub = Builders<teacherR>.Update.Set("sub", DrpSubject.Text);
                                    var add = Builders<teacherR>.Update.Set("address", txtAddress.Text);
                                    var gender = Builders<teacherR>.Update.Set("gender", DrpGender.Text);
                                    var phone = Builders<teacherR>.Update.Set("phone", txtPhoneNumber.Text);
                                    var emailis = Builders<teacherR>.Update.Set("email", txtEmail.Text);

                                    logdata.UpdateOne(filter, name);
                                    logdata.UpdateOne(filter, sub);
                                    logdata.UpdateOne(filter, add);
                                    logdata.UpdateOne(filter, gender);
                                    logdata.UpdateOne(filter, phone);
                                    logdata.UpdateOne(filter, emailis);

                                    this.Alert("Successfully updated!", frm_Alert.enmType.Success);
                                    //MessageBox.Show("Data updates successfully !");
                                    this.Dispose();
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

        private void txtTeacherName_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && e.KeyChar != ' ')
            {
                e.Handled = true;
            }
        }

        private void Drpsubject_KeyPress(object sender, KeyPressEventArgs e)
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
