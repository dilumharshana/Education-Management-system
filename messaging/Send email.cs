using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using MongoDB.Driver;
using MongoDB.Bson;
using System.Windows.Forms;

namespace Education_Center
{
    class Email
    {

        DateTime dt = DateTime.Now;
        int year = DateTime.Now.Year;

        public void sendmail()
        {

            String indexis = null;

            var recs = students<studentr>();

            foreach (var rec in recs)
            {


                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");

                //geting parent
                var par = db.GetCollection<parentr>("parent");
                var filter2 = Builders<parentr>.Filter.Eq("index", rec.index);
                var precs = par.Find(filter2).First();

                //getting attendance;
                var attendanced = attendace<mark_stdr>(rec.index);
                String report = "";
                try
                {
                    foreach (var attend in attendanced)
                    {
                        if (attend.date == null) 
                        {
                            report = " No report content for this month";
                        }
                        else
                        {
                            report += " > <p> On " + attend.date + " at " + attend.time + " to " + attend.sub+"<p>";

                            indexis = attend.index;
                        }
                    }
                }
                catch (Exception)
                {
                    report = " No report content for this month";
                }

                var parent = precs.email;
                var student = rec.firstname + " " + rec.lastname;

                try
                {

                    using (MailMessage mail = new MailMessage())
                    {
                        mail.From = new MailAddress("educationaplus6@gmail.com");
                        mail.To.Add(parent);
                        mail.Subject = "Monthyreport from A Plus Education Center";
                        mail.Body = "<b>Student name :"+rec.firstname+"</b><p>"+report+"</p> <br/>";
                        mail.IsBodyHtml = true;

                        using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                        {
                            smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                            smtp.EnableSsl = true;
                            smtp.Send(mail);
                        }
                    }

                    //inserting report deleverd document

                    this.Alert("monthly Reports sent!", frm_Alert.enmType.Success);

                }
                catch (Exception e) { MessageBox.Show("Something went wrong please check your internet connection");
                    error.errorNow(e.ToString() + "in class email [ RISK SITUATION ]");
                }

            }
            addreport(indexis);
        }

        void addreport(String index)
        {

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");

            db = connect.GetDatabase("educationSystem");


            var markreport = new emailw
            {
                index = index,
                month = dt.ToString("MMM"),
                year = DateTime.Now.Year.ToString()
            };

            //inserting student
            var collectionSTD = db.GetCollection<emailw>("reports");
            collectionSTD.InsertOne(markreport);
        }


        //gettinf students
        public List<T> students<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            return std.Find(new BsonDocument()).ToList();
        }

        //get all attendance
        public List<mark_stdr> attendace<mark_stdr>(String index)
        {

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<mark_stdr>("attendance");

            var builder = Builders<mark_stdr>.Filter;


            //getting last month
            String lm = DateTime.Now.AddMonths(-1).ToString("MMMM");



            //getting year


            if (lm == "January")
            {
                year = (DateTime.Now.Year) - 1;
            }

            var filter1 = builder.Eq("index", index) & builder.Eq("month", lm) & builder.Eq("year", year.ToString());

            return std.Find<mark_stdr>(filter1).ToList();

        }


        public bool cheksents()
        {
            bool sent = true; //true means monthly report has been sent

            int count = 0; // count = 0 means report does not has been sent yet

            var months = chekreport<emailr>();

            foreach (var month in months) 
            {
                count++;
            }

            if (count == 0)
            {
                sent = false;
            }

            return sent;
        }



        //gettinf students
        public List<T> chekreport<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("reports");
            var builder = Builders<T>.Filter;

            var filter = builder.Eq("year", dt.ToString(DateTime.Now.Year.ToString())) & builder.Eq("month", dt.ToString("MMM"));

            return std.Find(filter).ToList();
        }



        ////////////////////////////////////////////////////////////////////////////////////////////////////////////
        ///
        public void studentregmail(String [] subs, String grade,  String name , String email , String index)
        {

            String indexis = null;


            String report = "";

            foreach (var sub in subs)
            {
                var recs = getStdSubs<subjectr>(sub , grade);
                

                foreach (var rec in recs)
                {

                    try
                    {
                        report += "<br/>"+rec.name + "on " + rec.day + " " + rec.starttime + " to " + rec.endtime;
                    }
                    catch (Exception)
                    {

                    }
                }

            }

            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("educationaplus6@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Welcome to A Plus Education center";
                    mail.Body = "Hello " + name + "<b> Your Index Number : </b>" + index + "<br/><br/> <p>" + report + " </p> <br/> THANK YOU !";
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
            catch (Exception e) { MessageBox.Show("Something went wrong please check your internet connection");
                error.errorNow(e.ToString() + "in class email [ RISK SITUATION ]");
            }

        }

        //gettinf students
        public List<T> getStdSubs<T>(String sub , String grade)
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");
            var builder = Builders<T>.Filter;

            var filter = builder.Eq("name", sub) & builder.Eq("grade", grade);

            return std.Find(filter).ToList();
        }


        //sending email wehen recives fess
        public void feesRecived(String name , String fee , String subject ,String month , String email)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("educationaplus6@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Fees Recived";
                    mail.Body = "A Plus Education Center Has Recived " + fee + " for "+month+" from "+name+"<b> Subject : </b>" + subject + "<br/><br/> <p>" + DateTime.Now.ToString() + " </p> <br/> THANK YOU !";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

            }
            catch (Exception e) { MessageBox.Show("Something went wrong please check your internet connection");
                error.errorNow(e.ToString() + "in class email [ RISK SITUATION ]");
            }
        }


        //not recived fees

        public void feesnotRecived(String name,  String subject, String month, String email)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("educationaplus6@gmail.com");
                    mail.To.Add(email);
                    mail.Subject = "Fees not recived";
                    mail.Body = "Please pay the fee of " + subject + "  class for " + month + " ."+ " </p> <br/> THANK YOU !";
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }


            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong please check your internet connection");
                error.errorNow(e.ToString() + "in class email [ RISK SITUATION ]");
            }
        }


        public void toDeveloper(String msg)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("educationaplus6@gmail.com");
                    mail.To.Add("evon.customer@gmail.com");
                    mail.Subject = "CLIENT MESSAGE";
                    mail.Body = msg;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }


                this.Alert("Success!", frm_Alert.enmType.Success);

            }
            catch (Exception e) { MessageBox.Show("Something went wrong please check your internet connection");
                error.errorNow(e.ToString() + "in class email [ RISK SITUATION ]");
            }
        }


        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }

        public void toDeveloperERROR(String msg)
        {
            try
            {

                using (MailMessage mail = new MailMessage())
                {
                    mail.From = new MailAddress("educationaplus6@gmail.com");
                    mail.To.Add("evon.customer@gmail.com");
                    mail.Subject = "CLIENT MESSAGE";
                    mail.Body = "DANGER ERROR OCCURED IN ->>> A Plus Education Management System >>>>>>"+msg;
                    mail.IsBodyHtml = true;

                    using (SmtpClient smtp = new SmtpClient("smtp.gmail.com", 587))
                    {
                        smtp.Credentials = new NetworkCredential("educationaplus6@gmail.com", "Apluseducation123");
                        smtp.EnableSsl = true;
                        smtp.Send(mail);
                    }
                }

            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong please check your internet connection");
                error.errorNow(e.ToString() + "in class email [ RISK SITUATION ]");
            }
        }

    }

}
