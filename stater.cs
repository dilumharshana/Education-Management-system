using System;

using System.Windows.Forms;

namespace Education_Center
{
    public partial class frm_Login : Form
    {
        public frm_Login()
        {
            InitializeComponent();

            bunifuFormDock1.SubscribeControlToDragEvents(bunifuGradientPanel1);
            bunifuFormDock1.SubscribeControlToDragEvents(tabPage1);

        }

        private void BunifuImageButton1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void BunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

          public void Alert(String msg, frm_Alert.enmType type)
        {
            frm_Alert frm = new frm_Alert();
            frm.showAlert(msg, type);
        }

        private void BtnSignIn_Click(object sender, EventArgs e)
        {

            login_ctrl login = new login_ctrl(txt_username.Text, txt_password.Text);

            Hide();


        }

        private void BunifuLabel1_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(1);
        }

        private void BunifuLabel2_Click(object sender, EventArgs e)
        {
            bunifuPages1.SetPage(0);
        }

        private void btn_adSignIn_Click(object sender, EventArgs e)
        {

        }

        private void txt_username_TextChanged(object sender, EventArgs e)
        {

        }

        private void lbl_forgotpass_Click(object sender, EventArgs e)
        {
            try
            {
                otp open = new otp();
                open.Show();
            }
            catch (Exception)
            {
                MessageBox.Show("Something went wrong");
            }
        }
    }
}
