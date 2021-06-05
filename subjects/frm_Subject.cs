using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    public partial class frm_Subject : Form
    {
        bool updater = false;
        public frm_Subject()
        {
            InitializeComponent();
            setSubs();
            datafiller();
        }




        void setSubs()
        {
            var recs = getsubjects<teacherR>();

            txt_sub.Items.Clear();

            List<string> subjects = new List<string>();


            foreach(var rec in recs)
            {
                if (!subjects.Contains(rec.sub))
                {
                    subjects.Add(rec.sub);
                }   
            }

            for(int i=0; i<subjects.Count; i++)
            {
                txt_sub.Items.Add(subjects[i]);
            }
        }


        public void datafiller()
        {
            String[] subs = new string[8];

            try
            {
                DataTable table_data = new DataTable();

                table_data.Columns.Add("SUBJECT");
                table_data.Columns.Add("GRADE");
                table_data.Columns.Add("TEACHER");
                table_data.Columns.Add("FEE");
                table_data.Columns.Add("STREAM");
                table_data.Columns.Add("DAYS");
                table_data.Columns.Add("STARTING");
                table_data.Columns.Add("ENDING");


                for (int i = 0; i < 8; i++)
                {
                    subs[i] = null;
                }

                grid_subjects.DataSource = table_data;

                var recs = subjects<subjectr>();

                foreach (var rec in recs)
                {

                    subs[0] = rec.name;
                    subs[1] = rec.grade;
                    subs[2] = rec.teacher;
                    subs[3] = rec.fee;
                    subs[4] = rec.stream;
                    subs[5] = rec.day;
                    subs[6] = rec.starttime;
                    subs[7] = rec.endtime;

                    table_data.Rows.Add(subs);

                }

                grid_subjects.DataSource = table_data;

            }
            catch (Exception e)
            {
                subs[0] = null;
                error.errorNow(e.ToString() + "in class frm_subjects [ NORMAL SITUATION ]");
            }


        }

        //student filter by dropdown menu
        public List<T> subjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");
            return std.Find(new BsonDocument()).ToList();
        }

        public List<T> getsubjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("teachers");
            return std.Find(new BsonDocument()).ToList();
        }

        private void txt_ininame_TextChanged(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton1_Click(object sender, EventArgs e)
        {
            if (updater)
            {
                updateSubject();
            }
            else //0776180369
            {
                addSubject();
            }
        }

        //add new subject
        void addSubject()
        {
            if ((txt_sub.Text.Length > 0) && (txt_teacher.Text.Length > 0) && (txt_fee.Text.Length > 0) && (time_start.Value > 0) && (time_end.Value > 0) && (time_start.Value < time_end.Value) && (time_end.Value <= 24) && (time_start.Value <= 24) && dropdown_day.Text != "" && dropdown_stream.Text != "" && dropdown_grade.Text != "")
            {
                bool available = true; // this variable hold if the process running automatic or manualy

                if (box_auto.Checked)
                {
                    var recs = time<subjectr>(dropdown_day.Text, dropdown_stream.Text);

                    foreach (var rec in recs)
                    {
                        if (Int16.Parse(time_start.Text) < Int16.Parse(rec.endtime) && Int16.Parse(time_end.Text) > Int16.Parse(rec.starttime) || Int16.Parse(time_start.Text) == Int16.Parse(rec.starttime))
                        {

                            if (rec.grade == dropdown_grade.Text || rec.name == txt_sub.Text)
                            {
                                available = false;
                                break;
                            }

                        }

                        var subs = time<subjectr>(dropdown_day.Text, txt_sub.Text);

                        foreach (var sub in subs)
                        {

                            available = false;
                            break;

                        }
                    }
                }


                if (available) // done
                {
                    var newSubject = new subjectinsert
                    {
                        name = txt_sub.Text,
                        teacher = txt_teacher.Text,
                        fee = txt_fee.Text,
                        stream = dropdown_stream.Text,
                        day = dropdown_day.Text,
                        starttime = time_start.Text,
                        endtime = time_end.Text,
                        grade = dropdown_grade.Text
                    };

                    var connect = new MongoClient();
                    var db = connect.GetDatabase("educationSystem");
                    var collectionPRT = db.GetCollection<subjectinsert>("subjects");
                    collectionPRT.InsertOne(newSubject);

                    txt_sub.Text = null;
                    txt_teacher.Text = null;
                    txt_fee.Text = null;
                    dropdown_day.Text = null;
                    dropdown_stream.Text = null;
                    time_start.Value = 0;
                    time_end.Value = 0;
                    select_day.Text = null;
                    slect_stream.Text = null;
                    dropdown_grade.Text = null;

                datafiller();
                }
                else
                {
                    MessageBox.Show("Time in not available on this day for this subject !");
                }
            }
            else
            {
                MessageBox.Show("Please fill out every fields or Chek the times again  ");
            }
        }

        //update existing subject
        void updateSubject()
        {

            if ((txt_sub.Text.Length > 0) && (txt_teacher.Text.Length > 0) && (txt_fee.Text.Length > 0) && (time_start.Value > 0) && (time_end.Value > 0) && (time_start.Value < time_end.Value) && time_end.Value <= 24 && time_start.Value <= 24 && dropdown_day != null && dropdown_stream != null && dropdown_grade != null)
            {
                bool available = true;

                if (box_auto.Checked) //chking is the process is auto or manual
                {
                    var recs = time<subjectr>(dropdown_day.Text, dropdown_stream.Text);

                    foreach (var rec in recs)
                    {
                        if (Int16.Parse(time_start.Text) < Int16.Parse(rec.endtime) && Int16.Parse(time_end.Text) > Int16.Parse(rec.starttime) || Int16.Parse(time_start.Text) == Int16.Parse(rec.starttime))
                        {
                            if (Int16.Parse(rec.grade) == Int16.Parse(dropdown_grade.Text) || rec.name == txt_sub.Text)
                            {
                                if (rec.name != grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[0].Value.ToString() && rec.grade != grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[1].Value.ToString())
                                {
                                    available = false;
                                    break;
                                }
                            }


                        }
                    }
                }


                if (available)
                {
                    MongoClient connect = dbconnector.connection();
                    var db = connect.GetDatabase("educationSystem");

                    var logdata = db.GetCollection<subjectr>("subjects"); //getting subject document

                    var builder = Builders<subjectr>.Filter;

                    var filter = builder.Eq("name", grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[0].Value.ToString()) & builder.Eq("grade", grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[1].Value.ToString());

                    var rec = logdata.Find(filter).First();

                    var name = Builders<subjectr>.Update.Set("name", txt_sub.Text);
                    var teacher = Builders<subjectr>.Update.Set("teacher", txt_teacher.Text);
                    var fee = Builders<subjectr>.Update.Set("fee", txt_fee.Text);
                    var stream = Builders<subjectr>.Update.Set("stream", dropdown_stream.Text);
                    var day = Builders<subjectr>.Update.Set("day", dropdown_day.Text);
                    var starttime = Builders<subjectr>.Update.Set("starttime", time_start.Value);
                    var endtime = Builders<subjectr>.Update.Set("endtime", time_end.Value);
                    var grade = Builders<subjectr>.Update.Set("grade", dropdown_grade.Text);


                    logdata.UpdateOne(filter, name);
                    logdata.UpdateOne(filter, grade);
                    logdata.UpdateOne(filter, teacher);
                    logdata.UpdateOne(filter, fee);
                    logdata.UpdateOne(filter, stream);
                    logdata.UpdateOne(filter, day);
                    logdata.UpdateOne(filter, starttime);
                    logdata.UpdateOne(filter, endtime);
                    

                    txt_sub.Text = null;
                    txt_teacher.Text = null;
                    txt_fee.Text = null;
                    dropdown_day.Text = null;
                    dropdown_stream.Text = null;
                    dropdown_grade.Text = null;
                    time_start.Value = 0;
                    time_end.Value = 0;
                    select_day.Text = null;
                    slect_stream.Text = null;

                    updater = false;
                    btn_add.Text = "ADD NEW";

                    datafiller();
                    MessageBox.Show("Updated Successfully !");
                }
                else
                {
                    MessageBox.Show("Time in not available on this day for this subject !");
                }
            }
            else
            {
                MessageBox.Show("Please fill out every fields or Chek the times again  ");
            }

        }


        private void txt_fee_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }

        public List<T> time<T>(String day , String stream )
        {
     

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");
            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("day", day) & builder.Eq("stream", stream);


            return std.Find(filter1).ToList(); 
            
        }



        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void dropdown_day_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void frm_Subject_Load(object sender, EventArgs e)
        {

        }

        private void gunaGradientButton2_Click(object sender, EventArgs e)
        {
            delete();
            datafiller();
        }

        public void delete()
        {
            try
            {
                // getting deleteing element index number
                int selectedRow = grid_subjects.CurrentCell.RowIndex;
                var name = grid_subjects.Rows[selectedRow].Cells[0].Value.ToString();

                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");

                var std = db.GetCollection<BsonDocument>("subjects"); //subjects

                var filter = Builders<BsonDocument>.Filter.Eq("name", name);

                std.DeleteOne(filter);

                datafiller();

                MessageBox.Show("Deleted Successfully !");
            }
            catch (Exception e)
            {
                MessageBox.Show("Something went wrong");
                error.errorNow(e.ToString() + "in class frm_subjects [ RISK SITUATION ]");
            }
        }

        private void gunaGradientButton3_Click(object sender, EventArgs e)
        {
            txt_sub.Text = grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[0].Value.ToString();
            dropdown_grade.Text = grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[1].Value.ToString();
            txt_teacher.Text = grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[2].Value.ToString();
            txt_fee.Text = grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[3].Value.ToString();
            dropdown_stream.Text = grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[4].Value.ToString();
            dropdown_day.Text = grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[5].Value.ToString();
            time_start.Value = Int16.Parse(grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[6].Value.ToString());
            time_end.Value = Int16.Parse(grid_subjects.Rows[grid_subjects.CurrentCell.RowIndex].Cells[7].Value.ToString());

            updater = true;
            btn_add.Text = "UPDATE";
        }

        private void gunaGradientButton1_Click_1(object sender, EventArgs e)
        {
            updater = false;

            txt_sub.Text = null;
            txt_teacher.Text = null;
            dropdown_grade.Text = null;
            txt_fee.Text = null;
            dropdown_stream.Text = null;
            dropdown_day.Text = null;
            time_start.Text = null;
            time_end.Text = null;
            select_day.Text = null;
            slect_stream.Text = null;
            box_auto.Checked = true ;

            btn_add.Text = "ADD NEW";
            datafiller();
        }

        private void slect_stream_SelectedValueChanged(object sender, EventArgs e)
        {
            
            String[] user = new string[8];
            DataTable table_data = new DataTable();
            try
            {

                table_data.Columns.Add("SUBJECT");
                table_data.Columns.Add("GRADE");
                table_data.Columns.Add("TEACHER");
                table_data.Columns.Add("FEE");
                table_data.Columns.Add("STREAM");
                table_data.Columns.Add("DAYS");
                table_data.Columns.Add("STARTING");
                table_data.Columns.Add("ENDING");

                for (var i = 0; i < 8; i++)
                {
                    user[i] = null;

                }

                if (slect_stream.Text == "ALL")
                {
                    datafiller();
                }
                else
                {
                    var recs = getSubsByStream<subjectr>();

                    foreach (var rec in recs)
                    {
                        user[0] = rec.name;
                        user[1] = rec.teacher;
                        user[2] = rec.fee;
                        user[3] = rec.stream;
                        user[4] = rec.day;
                        user[5] = rec.starttime;
                        user[6] = rec.endtime;
                        user[7] = rec.grade;

                        table_data.Rows.Add(user);

                    }

                    grid_subjects.DataSource = table_data;
                }
            }


            catch (Exception ex)
            {
                error.errorNow(ex.ToString() + "in class frm_subjects [ NORMAL SITUATION ]");
                user[0] = null;
            }
        }

        //subjects filter by dropdown menu
        public List<T> getSubsByStream<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("stream", slect_stream.Text);


            return std.Find<T>(filter1).ToList();
        }


        //getting subjects by day
        private void select_day_SelectedValueChanged(object sender, EventArgs e)
        {
            String[] user = new string[8];
            DataTable table_data = new DataTable();
            try
            {

                table_data.Columns.Add("SUBJECT");
                table_data.Columns.Add("GRADE");
                table_data.Columns.Add("TEACHER");
                table_data.Columns.Add("FEE");
                table_data.Columns.Add("STREAM");
                table_data.Columns.Add("DAYS");
                table_data.Columns.Add("STARTING");
                table_data.Columns.Add("ENDING");

                for (var i = 0; i < 8; i++)
                {
                    user[i] = null;

                }

                if (slect_stream.Text == "ALL")
                {
                    datafiller();
                }
                else
                {
                    var recs = getSubsByDay<subjectr>();

                    foreach (var rec in recs)
                    {
                        user[0] = rec.name;
                        user[1] = rec.grade;
                        user[2] = rec.teacher;
                        user[3] = rec.fee;
                        user[4] = rec.stream;
                        user[5] = rec.day;
                        user[6] = rec.starttime;
                        user[7] = rec.endtime;
                       

                        table_data.Rows.Add(user);

                    }

                    grid_subjects.DataSource = table_data;
                }
            }


            catch (Exception ex)
            {
                error.errorNow(e.ToString() + "in class frm_subjects [ NORMAL SITUATION ]");
                user[0] = null;
            }
        }

        //subjects filter by dropdown menu
        public List<T> getSubsByDay<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("subjects");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("day", select_day.Text);


            return std.Find<T>(filter1).ToList();
        }


        public List<T> getteacher<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("teachers");

            var builder = Builders<T>.Filter;

            var filter1 = builder.Eq("sub", txt_sub.Text);


            return std.Find<T>(filter1).ToList();
        }

        private void slect_stream_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void txt_teacher_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsLetter(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = false;
            }
        }




        //teacjer id holder
        public List<string> teacherid = new List<string>();

        private void txt_sub_SelectedValueChanged(object sender, EventArgs e)
        {
            var recs = getteacher<teacherR>();
            txt_teacher.Items.Clear();
            foreach (var rec in recs)
            {
                txt_teacher.Items.Add(rec.name);
                teacherid.Add(rec.index);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
