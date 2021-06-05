using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Education_Center
{
    public partial class frm_Dashbord : Form
    {
        public frm_Dashbord()
        {
            InitializeComponent();


            //calling chart processors

            chart_weekdays();
            incomefromclassess();
            admitiondata();
            streamdata();
            attendance();
            streamincomeStater();
            home.SetPage(0);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            
        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton7_Click(object sender, EventArgs e)
        {
            home.SetPage(0);
        }


        // WEEK DAYS CLASSESS
        private void chart_weekdays()
        {
            weekclasses data = new weekclasses();
            int[] days = data.getclassess();

            weekclasses.Series["CLASSESS"].Points.AddXY("Sunday", days[0]);
            weekclasses.Series["CLASSESS"].Points.AddXY("Monday", days[1]);
            weekclasses.Series["CLASSESS"].Points.AddXY("Tuesday", days[2]);
            weekclasses.Series["CLASSESS"].Points.AddXY("Wednesday", days[3]);
            weekclasses.Series["CLASSESS"].Points.AddXY("Thursday", days[4]);
            weekclasses.Series["CLASSESS"].Points.AddXY("Friday", days[5]);
            weekclasses.Series["CLASSESS"].Points.AddXY("Saturday", days[6]);

        }




        /// /////////////////////////////////////////////////////////////
  

        // income from classess
        private void incomefromclassess()
        {
            incomemonthly data = new incomemonthly();
            int[] mths = data.getMonths();

            String[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Octomber", "November", "December" };
           
            for(int i=0; i<12; i++)
            {
                incomemonths.Series["Months"].Points.AddXY(months[i], mths[i]);
            }

        }




        /// ///////////////////////////////////////////////////////////////
      


        // Student admition month data
        public void admitiondata()
        {
            registerddata data = new registerddata();
            int[] mths = data.getMonths();

            String[] months = { "January", "February", "March", "April", "May", "June", "July", "August", "September", "Octomber", "November", "December" };

            for (int i = 0; i < 12; i++)
            {
                regdata.Series["Admitions"].Points.AddXY(months[i], mths[i]);
            }

        }





        /// ///////////////////////////////////////////////////////////////



        // Student admition month data
        public void streamdata()
        {
            //for getting reterning data an object purpose
            List<string> subjects = new List<string>();
            int[] amounts = { };

            streamdata data = new streamdata();

            String[] Streams = { "Science", "Commerce", "Art", "Technology" , "Common"};

                //getting science data

                Data datas = data.getData("Science");
                subjects = datas.strms;
                amounts = datas.amount;

                for (int i = 0; i < amounts.Length; i++)
                {
                    str_science.Series["Science"].Points.AddXY(subjects[i], amounts[i]);
                }

                //---------------------------------------------------------------------


                //getting commerce data

                datas = data.getData("Commerce");
                subjects = datas.strms;
                amounts = datas.amount;

                for (int i = 0; i < amounts.Length; i++)
                {
                    str_commerce.Series["Commerce"].Points.AddXY(subjects[i], amounts[i]);
                }

                //--------------------------------------------------------------------------


                //getting commerce data

                datas = data.getData("Art");
                subjects = datas.strms;
                amounts = datas.amount;

                for (int i = 0; i < amounts.Length; i++)
                {
                    str_art.Series["Art"].Points.AddXY(subjects[i], amounts[i]);

                }

                //--------------------------------------------------------------------------


                //getting commerce data

                datas = data.getData("Technology");
                subjects = datas.strms;
                amounts = datas.amount;

                for (int i = 0; i < amounts.Length; i++)
                {
                    str_technology.Series["Technology"].Points.AddXY(subjects[i], amounts[i]);
                }



                //--------------------------------------------------------------------------


                //getting commerce data

                datas = data.getData("Common");
                subjects = datas.strms;
                amounts = datas.amount;

                for (int i = 0; i < amounts.Length; i++)
                {
                    str_common.Series["Common"].Points.AddXY(subjects[i], amounts[i]);
                }
   

        }


        public void attendance()
        {
            //for getting reterning data an object purpose
            List<string> subjects = new List<string>();
            int[] amounts = { };

            attendance data = new attendance();

            String[] Streams = { "Science", "Commerce", "Art", "Technology", "Common" };

            //getting science data

            A_Data datas = data.getData("Science");
            subjects = datas.strms;
            amounts = datas.amount;

            for (int i = 0; i < amounts.Length; i++)
            {
                a_science.Series["ScienceA"].Points.AddXY(subjects[i], amounts[i]);
            }

            //---------------------------------------------------------------------


            //getting commerce data

            datas = data.getData("Commerce");
            subjects = datas.strms;
            amounts = datas.amount;

            for (int i = 0; i < amounts.Length; i++)
            {
                a_commerce.Series["CommerceA"].Points.AddXY(subjects[i], amounts[i]);
            }

            //--------------------------------------------------------------------------


            //getting commerce data

            datas = data.getData("Art");
            subjects = datas.strms;
            amounts = datas.amount;

            for (int i = 0; i < amounts.Length; i++)
            {
                a_art.Series["ArtA"].Points.AddXY(subjects[i], amounts[i]);

            }

            //--------------------------------------------------------------------------


            //getting commerce data

            datas = data.getData("Technology");
            subjects = datas.strms;
            amounts = datas.amount;

            for (int i = 0; i < amounts.Length; i++)
            {
                a_technology.Series["TechnologyA"].Points.AddXY(subjects[i], amounts[i]);
            }



            //--------------------------------------------------------------------------


            //getting commerce data

            datas = data.getData("Common");
            subjects = datas.strms;
            amounts = datas.amount;

            for (int i = 0; i < amounts.Length; i++)
            {
                a_common.Series["CommonA"].Points.AddXY(subjects[i], amounts[i]);
            }
        }


        /// ///////////////////////////////////////////////////////////////



        // stream income month data
        public void streamincome()
        {
            streamincome data = new streamincome();
            int[] mths = data.getData(dropdown_month.Text , DateTime.Now.Year.ToString());

            String[] months = { "Science", "Commerce", "Art", "Technology", "Common" };

            int count = chart_incomeMonth.Series.Count;

             for (int i=0; i<count; i++)
             {

            chart_incomeMonth.Series[i].Points.Clear();

            }

            for (int i = 0; i < 5; i++)
            {
                if (mths[i] > 0)
                {
                    chart_incomeMonth.Series["Income_Monthly"].Points.AddXY(months[i], mths[i]);;
                }
            }

        }

        public void streamincomeStater()
        {
            DateTime dt = DateTime.Now;

            streamincome data = new streamincome();

            int[] mths = data.getData(dt.ToString("MMMM") , DateTime.Now.Year.ToString());

            String[] months = { "Science", "Commerce", "Art", "Technology", "Common" };

            for (int i = 0; i < 5; i++)
            {
                if (mths[i] > 0)
                {
                    chart_incomeMonth.Series["Income_Monthly"].Points.AddXY(months[i], mths[i]);
                }
            }

            int[] yrs = data.getDataY(DateTime.Now.Year.ToString());

            for (int i = 0; i < 5; i++)
            {
                if (mths[i] > 0)
                {
                    chart_year.Series["Income_Annualy"].Points.AddXY(months[i], mths[i]);
                }
            }

        }

        private void gunaLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuSeparator1_Load(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void frm_Dashbord_Load(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void tabPage1_Click(object sender, EventArgs e)
        {

        }

        private void chart1_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton3_Click(object sender, EventArgs e)
        {
            

            home.SetPage(1);
        }

        private void chart1_Click_1(object sender, EventArgs e)
        {

        }

        private void chart4_Click(object sender, EventArgs e)
        {

        }

        private void label8_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton1_Click(object sender, EventArgs e)
        {
            home.SetPage(2);
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void gunaAdvenceButton4_Click(object sender, EventArgs e)
        {
            home.SetPage(3);
        }

        private void chart1_Click_2(object sender, EventArgs e)
        {

        }

        private void dropdown_month_SelectedValueChanged(object sender, EventArgs e)
        {
            streamincome();
        }

        private void gunaAdvenceButton2_Click(object sender, EventArgs e)
        {
            home.SetPage(4);
        }

        private void dropdown_month_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
