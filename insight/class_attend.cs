using System;
using System.Collections.Generic;

using System.Data;

using System.Linq;

using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;



namespace Education_Center
{
    public partial class class_attend : Form
    {
        public class_attend()
        {
            InitializeComponent();
            btn_norecord.Hide();

            setsubs();
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

                dropdown_sub.Items.Clear();

                for (int i = 0; i < sbs.Count; i++)
                {
                    dropdown_sub.Items.Add(sbs[i]);
                }
            }


        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            return std.Find(new BsonDocument()).ToList();
        }

        private void guna2VScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            datafiller();
        }

        public void datafiller()
        {
                    String[] user = new string[4];

                    try
                    {
                        btn_norecord.Hide();
                        DataTable table_data = new DataTable();

                        table_data.Columns.Add("INDEX NUMBER");
                        table_data.Columns.Add("NAME");
                        table_data.Columns.Add("TIME ATTEND");
                        table_data.Columns.Add("FEES STATE");

                        var recs = studentsFromSubs<mark_stdr>();
                        

                            user[0] = recs.index;
                            user[1] = recs.name;
                            user[2] = recs.time;
                            user[3] = chekfee(recs.index);

                table_data.Rows.Add(user);


                            grid_attend.DataSource = table_data;
                            grid_attend.Show();
                    }
                    catch (Exception e)
                    {
                              grid_attend.Hide();
                              btn_norecord.Show();
                        
                              error.errorNow(e.ToString()+"in class class_attend [ NORMAL SITUATION ]");
                    }


        }

        //get students
        public mark_stdr studentsFromSubs<mark_stdr>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<mark_stdr>("attendance");

            var builder = Builders<mark_stdr>.Filter;

            var filter1 = builder.Eq("index", txt_code.Text )& builder.Eq("grade", txt_code.Text) & builder.Eq("date", txt_date.Text) & builder.Eq("sub", dropdown_sub.Text);

            return std.Find<mark_stdr>(filter1).First();
        }

        //get all students
        public List<mark_stdr> studentsFromdate<mark_stdr>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<mark_stdr>("attendance");

            var builder = Builders<mark_stdr>.Filter;

            var filter1 = builder.Eq("date", txt_date.Text) & builder.Eq("sub", dropdown_sub.Text);

            return std.Find<mark_stdr>(filter1).ToList();
        }



        private void grid_attend_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void txt_code_TextChanged(object sender, EventArgs e)
        {

        }

        private void txt_date_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dropdown_sub_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btn_norecord_Click(object sender, EventArgs e)
        {

        }


        //fee paid or not searching method
        public String chekfee(String index)
        {
            String paid = "";

            try
            {
                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");
                var std = db.GetCollection<mark_feesr>("fees");

                var builder = Builders<mark_feesr>.Filter;

                DateTime datetime = DateTime.Now;

                Console.WriteLine(index+ dropdown_sub.Text+ datetime.ToString("MMMM"));
                var filter1 = builder.Eq("index", index) & builder.Eq("sub", dropdown_sub.Text) & builder.Eq("month", datetime.ToString("MMMM"));
                var precs = std.Find(filter1).First();

                paid = "PAID";
            }
            catch(Exception d)
            {
                paid = "NOT PAID";
            }
           


            return paid;
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            String[] user = new string[4];

            try
            {
                btn_norecord.Hide();
                DataTable table_data = new DataTable();

                table_data.Columns.Add("INDEX NUMBER");
                table_data.Columns.Add("NAME");
                table_data.Columns.Add("TIME ATTEND");
                table_data.Columns.Add("FEES STATE");

                var recs = studentsFromdate<mark_stdr>();



                foreach(var rec in recs)
                {
                    user[0] = rec.index;
                    user[1] = rec.name;
                    user[2] = rec.time;
                    user[3] = chekfee(rec.index);

                    table_data.Rows.Add(user);
                }

                


                grid_attend.DataSource = table_data;
                grid_attend.Show();
            }
            catch (Exception ex)
            {
                grid_attend.Hide();
                btn_norecord.Show();
                error.errorNow(e.ToString() + "in class class_attend [ NORMAL SITUATION ]");
            }

        }
    }
}
