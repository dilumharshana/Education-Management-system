using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    public partial class frm_TeacherDetails : Form
    {
        public frm_TeacherDetails()
        {
            InitializeComponent();
            setSubs();
            teacherData();
        }

        public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }

        public void teacherData()
        {

            String[] TechData = new string[7];

            try
            {
                DataTable table_data = new DataTable();

                table_data.Columns.Add("a");
                table_data.Columns.Add("aas");
                table_data.Columns.Add("adghf");
                table_data.Columns.Add("sfda");
                table_data.Columns.Add("asdf");
                table_data.Columns.Add("afhd");
                table_data.Columns.Add("adfghf");

                for (int i = 0; i < 7; i++)
                {
                    TechData[i] = null;
                }

                teacher_grid.DataSource = table_data;

                var recs = teacher<teacherR>();

                foreach (var rec in recs)
                {
                    TechData[0] = rec.index;
                    TechData[1] = rec.name;
                    TechData[2] = rec.sub;
                    TechData[3] = rec.address;
                    TechData[4] = rec.gender;
                    TechData[5] = rec.phone;
                    TechData[6] = rec.email;


                    table_data.Rows.Add(TechData);

                }

                teacher_grid.DataSource = table_data;
            }

            catch (Exception e)
            {
                error.errorNow(e.ToString() + "in classfrm_teacherDetails [ NORMAL SITUATION ]");
                TechData[0] = null;
            }
        }

        public List<T> teacher<T>()
        {

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var tea = db.GetCollection<T>("teachers");

            return tea.Find(new BsonDocument()).ToList();

        }

        public List<T> teacherSeacrh<T>()
        {

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var tea = db.GetCollection<T>("teachers");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("index", txt_search.Text);

            return tea.Find<T>(filter).ToList();

        }

        public List<T> teacherSeacrhBySub<T>()
        {

            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var tea = db.GetCollection<T>("teachers");

            var builder = Builders<T>.Filter;
            var filter = builder.Eq("sub", dropdown_subchange.Text);

            return tea.Find<T>(filter).ToList();

        }

        private void BtnTeaEdit_Click(object sender, EventArgs e)
        {
            try
            {
                String[] data = new string[7];

                data[0] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[0].Value.ToString();
                data[1] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[1].Value.ToString();
                data[2] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[2].Value.ToString();
                data[3] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[3].Value.ToString();
                data[4] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[4].Value.ToString();
                data[5] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[5].Value.ToString();
                data[6] = teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[6].Value.ToString();

                frm_TeacherEditDetails obj = new frm_TeacherEditDetails(data);

                obj.Show();
            }
            catch (Exception ex)
            {
                error.errorNow(e.ToString() + "in class frm_teacherDetails [ NORMAL SITUATION ]");
            }
        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void BtnSearch_Click(object sender, EventArgs e)
        {
            String[] TechData = new string[7];
            DataTable table_data = new DataTable();
            try
            {

                table_data.Columns.Add("a");
                table_data.Columns.Add("aas");
                table_data.Columns.Add("adghf");
                table_data.Columns.Add("sfda");
                table_data.Columns.Add("asdf");
                table_data.Columns.Add("afhd");
                table_data.Columns.Add("adfghf");

                for (var i = 0; i < 7; i++)
                {
                    TechData[i] = null;

                }

                if (txt_search.Text == "")
                {
                    teacherData();
                    error.errorNow(e.ToString() + "in class frm_teacherDetails [ NORMAL SITUATION ]");
                }

                var recs = teacherSeacrh<teacherR>();

                foreach (var rec in recs)
                {
                    TechData[0] = rec.index;
                    TechData[1] = rec.name;
                    TechData[2] = rec.sub;
                    TechData[3] = rec.address;
                    TechData[4] = rec.gender;
                    TechData[5] = rec.phone;
                    TechData[6] = rec.email;


                    table_data.Rows.Add(TechData);

                }

                teacher_grid.DataSource = table_data;
                txt_search.Text = "";
            }


            catch (Exception ex)
            {
                MessageBox.Show("No student found");

            }
        }

        private void Dropdown_subchange_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        public void delete()
        {
            try
            {
                // getting deleteing element index number
                int selectedRow = teacher_grid.CurrentCell.RowIndex;
                var index = teacher_grid.Rows[selectedRow].Cells[0].Value.ToString();

                var connect = new MongoClient();
                var db = connect.GetDatabase("educationSystem");

                var tea = db.GetCollection<BsonDocument>("teachers");

                var filter = Builders<BsonDocument>.Filter.Eq("index", index);

                tea.DeleteOne(filter);

                teacherData();
                this.Alert("Successfully Deleted!", frm_Alert.enmType.Success);
            }
            catch (Exception e)
            {
                this.Alert("Something went wrong!", frm_Alert.enmType.Error);
                error.errorNow(e.ToString() + "in class frm_teachrDetails [ RISK SITUATION ]");
            }
        }

        private void BtnDataDelete_Click(object sender, EventArgs e)
        {
            delete();
        }

        private void dropdown_subchange_SelectedValueChanged(object sender, EventArgs e)
        {
            String[] TechData = new string[7];
            DataTable table_data = new DataTable();
            try
            {

                table_data.Columns.Add("a");
                table_data.Columns.Add("aas");
                table_data.Columns.Add("adghf");
                table_data.Columns.Add("sfda");
                table_data.Columns.Add("asdf");
                table_data.Columns.Add("afhd");
                table_data.Columns.Add("adfghf");

                for (var i = 0; i < 7; i++)
                {
                    TechData[i] = null;

                }

                if (dropdown_subchange.Text == "")
                {
                    teacherData();
                }

                var recs = teacherSeacrhBySub<teacherR>();

                foreach (var rec in recs)
                {
                    TechData[0] = rec.index;
                    TechData[1] = rec.name;
                    TechData[2] = rec.sub;
                    TechData[3] = rec.address;
                    TechData[4] = rec.gender;
                    TechData[5] = rec.phone;
                    TechData[6] = rec.email;


                    table_data.Rows.Add(TechData);

                }

                teacher_grid.DataSource = table_data;
            }

            catch (Exception ex)
            {
                Console.WriteLine(e);
                TechData[0] = null;
            }

        }

        private void bunifuLabel7_Click(object sender, EventArgs e)
        {

        }

        void setSubs()
        {
            var recs = getsubjects<teacherR>();

            dropdown_subchange.Items.Clear();

            List<string> subjects = new List<string>();


            foreach (var rec in recs)
            {
                if (!subjects.Contains(rec.sub))
                {
                    subjects.Add(rec.sub);
                }
            }

            for (int i = 0; i < subjects.Count; i++)
            {
                dropdown_subchange.Items.Add(subjects[i]);
            }
        }

        public List<T> getsubjects<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("teachers");
            return std.Find(new BsonDocument()).ToList();
        }

        private void gunaButton1_Click(object sender, EventArgs e)
        {
            teacherData();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            message open = new message(teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[1].Value.ToString() , "");
            open.Show();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            message open = new message(teacher_grid.Rows[teacher_grid.CurrentCell.RowIndex].Cells[1].Value.ToString(), "");
            open.Show();
        }
    }
}
