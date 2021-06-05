using Education_Center.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Education_Center
{
    public partial class frm_Alert : Form
    {
        public frm_Alert()
        {
            InitializeComponent();
        }

        public enum enmAction
        {
            wait,
            start,
            close
        }

        public enum enmType
        {
            Success,
            Error
        }

        private void Frm_Alert_Load(object sender, EventArgs e)
        {

        }

        private frm_Alert.enmAction action;

        private int x, y;

        private void GunaPictureBox2_Click(object sender, EventArgs e)
        {
            timer1.Interval = 1;
            action = enmAction.close;
        }

        private void Timer1_Tick(object sender, EventArgs e)
        {
            switch ( action)
            {
                case enmAction.wait:
                    timer1.Interval = 5000;
                    action = enmAction.close;
                    break;
                case enmAction.start:
                    timer1.Interval = 1;
                     Opacity += 0.1;
                    if ( x <  Location.X)
                    {
                         Left--;
                    }
                    else
                    {
                        if ( Opacity == 1.0)
                        {
                            action = enmAction.wait;
                        }
                    }
                    break;
                case enmAction.close:
                    timer1.Interval = 1;
                     Opacity -= 0.1;

                     Left -= 3;
                    if (base.Opacity == 0.0)
                    {
                        base.Close();
                    }
                    break;
            }
        }

        public void showAlert(string msg, enmType type)
        {
             Opacity = 0.0;
             StartPosition = FormStartPosition.Manual;
             Location = new Point(1600, 200);

           /* string fname;

            for (int i = 0; i < 10; i++)
            {
                fname = "alert" + i.ToString();
                frm_Alert frm = (frm_Alert)Application.OpenForms[fname];

                if (frm == null)
                {
                     x = Screen.PrimaryScreen.WorkingArea.Width -  Width + 15;
                     x = Screen.PrimaryScreen.WorkingArea.Height -  Height * i;
                     Location = new Point( x,  y);
                    break;
                }
            } */
             x = Screen.PrimaryScreen.WorkingArea.Width - base.Width - 5;

            switch (type)
            {
                case enmType.Success:
                     gunaPictureBox1.Image = Resources.succesicon;
                     BackColor = Color.LimeGreen;
                    break;
                case enmType.Error:
                     gunaPictureBox1.Image = Resources.erroricon;
                     BackColor = Color.Red;
                    break;
            }

             lblMsg.Text = msg;

             Show();
             action = enmAction.start;
             timer1.Interval = 1;
            timer1.Start();
        }
    }
}
