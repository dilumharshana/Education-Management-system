using System;
using System.Collections.Generic;

using System.Data;

using System.Linq;

using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    public partial class frm_Details : Form
    {
        public frm_Details()
        {
            InitializeComponent();

            datafiller();
            setgrade();
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

            dropdown_subchange.Items.Clear();

            for(int i=0; i<sbs.Count; i++)
            {
                dropdown_subchange.Items.Add(sbs[i]);
            }
        }


        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            return std.Find(new BsonDocument()).ToList();
        }

        //setting dardes to dropdown menu

        void setgrade()
        {
            dropdown_grade.Items.Clear();

            dropdown_grade.Items.Add("12");
            dropdown_grade.Items.Add("13");
            dropdown_grade.Items.Add("Revesion");

        }



        public void datafiller()
        {
            String[] user = new string[16];

            try
            {
                DataTable table_data = new DataTable();

                table_data.Columns.Add("Index");
                table_data.Columns.Add("INITIALS");
                table_data.Columns.Add("FIRST NAME");
                table_data.Columns.Add("LAST NAME");
                table_data.Columns.Add("ADDRESS");
                table_data.Columns.Add("DOB");
                table_data.Columns.Add("GENDER");
                table_data.Columns.Add("GRADE");
                table_data.Columns.Add("SCHOOL");
                table_data.Columns.Add("PHONE");
                table_data.Columns.Add("A_MONTH");
                table_data.Columns.Add("EMAIL");
                table_data.Columns.Add("STREAM");
                table_data.Columns.Add("SUBJECT 1");
                table_data.Columns.Add("SUBJECT 2");
                table_data.Columns.Add("SUBJECT 3");

                grid_data.DataSource = table_data;

                var recs = students<studentr>();

                foreach (var rec in recs)
                {
                    user[0] = rec.index;
                    user[1] = rec.initials;
                    user[2] = rec.firstname;
                    user[3] = rec.lastname;
                    user[4] = rec.address;
                    user[5] = rec.dob;
                    user[6] = rec.gender;
                    user[7] = rec.grade;
                    user[8] = rec.school;
                    user[9] = rec.phone;
                    user[10] = rec.admitionmonth;
                    user[11] = rec.email;
                    user[12] = rec.stream;
                    user[13] = rec.sub1;
                    user[14] = rec.sub2;
                    user[15] = rec.sub3;


                    table_data.Rows.Add(user);

                }

                grid_data.DataSource = table_data;




            }
            catch (Exception e)
            {
                error.errorNow(e.ToString() + "in class frm_details [ NORMAL SITUATION ]");
                user[0] = null;
            }


        }

        //gettinf students
        public List<T> students<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            return std.Find(new BsonDocument()).ToList();
        }


        //getting parent
        public String[] parent(String index)
        {
            String[] user = new string[8];

            try
            {
                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");
                var par = db.GetCollection<parentr>("parent");
                var filter2 = Builders<parentr>.Filter.Eq("index", index);

                var precs = par.Find(filter2).First();

                user[0] = precs.initials;
                user[1] = precs.firstname;
                user[2] = precs.lastname;
                user[3] = precs.address;
                user[4] = precs.nic;
                user[5] = precs.gender;
                user[6] = precs.phone;
                user[7] = precs.email;



            }
            catch (Exception e)
            {
                error.errorNow(e.ToString() + "in class frm_details [ NORMAL SITUATION ]");
                user[0] = null;
            }



            return user;

        }




        //student filter by dropdown menu
        public List<T> studentsFromSubs<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("sub1", dropdown_subchange.Text) & builder.Eq("grade", dropdown_grade.Text) | builder.Eq("sub2", dropdown_subchange.Text) & builder.Eq("grade", dropdown_grade.Text) | builder.Eq("sub3", dropdown_subchange.Text) & builder.Eq("grade", dropdown_grade.Text);


            return std.Find<T>(filter1).ToList();
        }


        //student filter by search box
        public List<T> studentsFromSearch<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("al_students");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("index", txt_search.Text);


            return std.Find<T>(filter1).ToList();
        }


        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void Guna2Button1_Click(object sender, EventArgs e)
        {
            try
            {
                String[] data = new string[24];

                data[0] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[0].Value.ToString();
                data[1] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[1].Value.ToString();
                data[2] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[2].Value.ToString();
                data[3] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[3].Value.ToString();
                data[4] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[4].Value.ToString();
                data[5] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[5].Value.ToString();
                data[6] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[6].Value.ToString();
                data[7] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[7].Value.ToString();
                data[8] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[8].Value.ToString();
                data[9] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[9].Value.ToString();
                data[10] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[10].Value.ToString();
                data[11] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[11].Value.ToString();
                data[12] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[12].Value.ToString();
                data[13] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[13].Value.ToString();
                data[14] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[14].Value.ToString();
                data[15] = grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[15].Value.ToString();

                String[]  prnt = parent(data[0]);

                data[16] = prnt[0];
                data[17] = prnt[1];
                data[18] = prnt[2];
                data[19] = prnt[3];
                data[20] = prnt[4];
                data[21] = prnt[5];
                data[22] = prnt[6];
                data[23] = prnt[7];

                frm_EditDetails obj = new frm_EditDetails(data);

                obj.Show();
            }
            catch (Exception ex)
            {
                error.errorNow(e.ToString() + "in class frm_details [ NORMAL SITUATION ]");
            }
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void btn_Fullscreen_Click(object sender, EventArgs e)
        {
            String[] user = new string[16];
            DataTable table_data = new DataTable();
            try
            {

                table_data.Columns.Add("Index");
                table_data.Columns.Add("INITIALS");
                table_data.Columns.Add("FIRST NAME");
                table_data.Columns.Add("LAST NAME");
                table_data.Columns.Add("ADDRESS");
                table_data.Columns.Add("DOB");
                table_data.Columns.Add("GENDER");
                table_data.Columns.Add("GRADE");
                table_data.Columns.Add("SCHOOL");
                table_data.Columns.Add("PHONE");
                table_data.Columns.Add("A_MONTH");
                table_data.Columns.Add("EMAIL");
                table_data.Columns.Add("STREAM");
                table_data.Columns.Add("SUBJECT 1");
                table_data.Columns.Add("SUBJECT 2");
                table_data.Columns.Add("SUBJECT 3");

                for (var i = 0; i < 15; i++)
                {
                    user[i] = null;

                }

                if (txt_search.Text == "")
                {
                    datafiller();
                }
              
                    var recs = studentsFromSearch<studentr>();

                    foreach (var rec in recs)
                    {
                    user[0] = rec.index;
                    user[1] = rec.initials;
                    user[2] = rec.firstname;
                    user[3] = rec.lastname;
                    user[4] = rec.address;
                    user[5] = rec.dob;
                    user[6] = rec.gender;
                    user[7] = rec.grade;
                    user[8] = rec.school;
                    user[9] = rec.phone;
                    user[10] = rec.admitionmonth;
                    user[11] = rec.email;
                    user[12] = rec.stream;
                    user[13] = rec.sub1;
                    user[14] = rec.sub2;
                    user[15] = rec.sub3;


                    table_data.Rows.Add(user);

                    }

                    grid_data.DataSource = table_data;
                    txt_search.Text = "";
            }


            catch (Exception ex)
            {
                MessageBox.Show("No student found");
            }
        }



        private void bunifuDropdown1_SelectedValueChanged(object sender, EventArgs e)
        {
           
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            delete();
        }

        public void delete()
        {
            try
            {
                // getting deleteing element index number
                int selectedRow = grid_data.CurrentCell.RowIndex;
                var index = grid_data.Rows[selectedRow].Cells[0].Value.ToString();

                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");

                var std = db.GetCollection<BsonDocument>("al_students"); //student
                var par = db.GetCollection<BsonDocument>("parent"); //parent

                var filter = Builders<BsonDocument>.Filter.Eq("index", index);

                std.DeleteOne(filter);
                par.DeleteOne(filter);

                datafiller();
            }
            catch (Exception e)
            {
                error.errorNow(e.ToString() + "in class frm_details [ RISK SITUATION ]");
                MessageBox.Show("Something went wrong");
            }
        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            datafiller();
        }

        private void dropdown_grade_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (dropdown_subchange.Text.Length > 0)
            {
                String[] user = new string[16];
                DataTable table_data = new DataTable();
                try
                {

                    table_data.Columns.Add("Index");
                    table_data.Columns.Add("INITIALS");
                    table_data.Columns.Add("FIRST NAME");
                    table_data.Columns.Add("LAST NAME");
                    table_data.Columns.Add("ADDRESS");
                    table_data.Columns.Add("DOB");
                    table_data.Columns.Add("GENDER");
                    table_data.Columns.Add("GRADE");
                    table_data.Columns.Add("SCHOOL");
                    table_data.Columns.Add("PHONE");
                    table_data.Columns.Add("A_MONTH");
                    table_data.Columns.Add("EMAIL");
                    table_data.Columns.Add("STREAM");
                    table_data.Columns.Add("SUBJECT 1");
                    table_data.Columns.Add("SUBJECT 2");
                    table_data.Columns.Add("SUBJECT 3");

                    for (var i = 0; i < 15; i++)
                    {
                        user[i] = null;

                    }

                    if (dropdown_subchange.Text == "ALL")
                    {
                        datafiller();
                    }
                    else
                    {
                        var recs = studentsFromSubs<studentr>();

                        foreach (var rec in recs)
                        {
                            user[0] = rec.index;
                            user[1] = rec.initials;
                            user[2] = rec.firstname;
                            user[3] = rec.lastname;
                            user[4] = rec.address;
                            user[5] = rec.dob;
                            user[6] = rec.gender;
                            user[7] = rec.grade;
                            user[8] = rec.school;
                            user[9] = rec.phone;
                            user[10] = rec.admitionmonth;
                            user[11] = rec.email;
                            user[12] = rec.stream;
                            user[13] = rec.sub1;
                            user[14] = rec.sub2;
                            user[15] = rec.sub3;


                            table_data.Rows.Add(user);

                        }

                        grid_data.DataSource = table_data;
                    }
                }


                catch (Exception ex)
                {
                    error.errorNow(e.ToString() + "in class frm_details [ NORMAL SITUATION ]");
                    user[0] = null;
                }
            }
            else
            {
                MessageBox.Show("Please Select a subject");
            }
        }

        private void grid_data_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            message open = new message(grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[0].Value.ToString());
            open.Show();
       }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            message open = new message(grid_data.Rows[grid_data.CurrentCell.RowIndex].Cells[0].Value.ToString());
            open.Show();
        }
    }

    }

