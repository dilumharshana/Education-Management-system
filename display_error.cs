using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using MongoDB.Driver;
using MongoDB.Bson;

namespace Education_Center
{
    public partial class display_error : Form
    {
        public display_error()
        {
            InitializeComponent();
            displayErrors();
        }


        //getting errors
        public List<T> errorlist<T>()
        {
            var connect = new MongoClient();
            var db = connect.GetDatabase("educationSystem");
            var std = db.GetCollection<T>("errorlist");

            return std.Find(new BsonDocument()).ToList();
        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        public void displayErrors()
        {
            String[] user = new string[1];

            try
            {
                DataTable table_data = new DataTable();

                table_data.Columns.Add("Exception Occured");

                grid_data.DataSource = table_data;

                var recs = errorlist<errorR>();

                foreach (var rec in recs)
                {
                    user[0] = rec.error;

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

        private void display_error_Load(object sender, EventArgs e)
        {

        }
    }
}
