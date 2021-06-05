using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Net;
using System.Collections.Specialized;
using System.IO;

namespace Education_Center
{
    public partial class otp : Form
    {
        public otp()
        {
            InitializeComponent();
            panel_code.Hide();
            pannel_passset.Hide();
        }

        private void gunaLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void btn_otpsender_Click(object sender, EventArgs e)
        {
			sendSMS s = new sendSMS();
			s.otp();
			panel_code.Show();

		}
    }

	class sendSMS
	{
		public void otp()
		{
			String result;
			string apiKey = "MGE3ZjczNzdkYjdjZWY0MzM2MTg1NGNiZThkOGU1MWE";
			string numbers = "+12029495161"; // in a comma seperated list
			string message = "This is your message";
			string sender = "";

			String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
			//refer to parameters to complete correct url string

			StreamWriter myWriter = null;
			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

			objRequest.Method = "POST";
			objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
			objRequest.ContentType = "application/x-www-form-urlencoded";
			try
			{
				myWriter = new StreamWriter(objRequest.GetRequestStream());
				myWriter.Write(url);
			}
			catch (Exception e)
			{
				//return e.Message;
			}
			finally
			{
				myWriter.Close();
			}

			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
			{
				result = sr.ReadToEnd();
				// Close and clean up the StreamReader
				sr.Close();
			}
			MessageBox.Show("sent");
		}




		public void stdmark(String tp , string name)
		{
			String result;
			string apiKey = "MGE3ZjczNzdkYjdjZWY0MzM2MTg1NGNiZThkOGU1MWE";
			string numbers = tp; // in a comma seperated list
			string message = name+" attended class";
			string sender = "";

			String url = "https://api.txtlocal.com/send/?apikey=" + apiKey + "&numbers=" + numbers + "&message=" + message + "&sender=" + sender;
			//refer to parameters to complete correct url string

			StreamWriter myWriter = null;
			HttpWebRequest objRequest = (HttpWebRequest)WebRequest.Create(url);

			objRequest.Method = "POST";
			objRequest.ContentLength = Encoding.UTF8.GetByteCount(url);
			objRequest.ContentType = "application/x-www-form-urlencoded";
			try
			{
				myWriter = new StreamWriter(objRequest.GetRequestStream());
				myWriter.Write(url);
			}
			catch (Exception e)
			{
				//return e.Message;
			}
			finally
			{
				myWriter.Close();
			}

			HttpWebResponse objResponse = (HttpWebResponse)objRequest.GetResponse();
			using (StreamReader sr = new StreamReader(objResponse.GetResponseStream()))
			{
				result = sr.ReadToEnd();
				// Close and clean up the StreamReader
				sr.Close();
			}
		}
	}
}






