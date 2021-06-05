namespace Education_Center
{
    partial class frm_Alert
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
             components = new System.ComponentModel.Container();
             gunaPictureBox1 = new Guna.UI.WinForms.GunaPictureBox();
             gunaPictureBox2 = new Guna.UI.WinForms.GunaPictureBox();
             lblMsg = new System.Windows.Forms.Label();
             timer1 = new System.Windows.Forms.Timer( components);
            ((System.ComponentModel.ISupportInitialize)( gunaPictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)( gunaPictureBox2)).BeginInit();
             SuspendLayout();
            // 
            // gunaPictureBox1
            // 
             gunaPictureBox1.BaseColor = System.Drawing.Color.White;
             gunaPictureBox1.Image = global::Education_Center.Properties.Resources.succesicon;
             gunaPictureBox1.Location = new System.Drawing.Point(12, 20);
             gunaPictureBox1.Name = "gunaPictureBox1";
             gunaPictureBox1.Size = new System.Drawing.Size(35, 35);
             gunaPictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
             gunaPictureBox1.TabIndex = 0;
             gunaPictureBox1.TabStop = false;
            // 
            // gunaPictureBox2
            // 
             gunaPictureBox2.BaseColor = System.Drawing.Color.White;
             gunaPictureBox2.Image = global::Education_Center.Properties.Resources.exiticon;
             gunaPictureBox2.Location = new System.Drawing.Point(307, 23);
             gunaPictureBox2.Name = "gunaPictureBox2";
             gunaPictureBox2.Size = new System.Drawing.Size(30, 29);
             gunaPictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
             gunaPictureBox2.TabIndex = 1;
             gunaPictureBox2.TabStop = false;
             gunaPictureBox2.Click += new System.EventHandler( GunaPictureBox2_Click);
            // 
            // lblMsg
            // 
             lblMsg.AutoSize = true;
             lblMsg.BackColor = System.Drawing.Color.Transparent;
             lblMsg.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
             lblMsg.ForeColor = System.Drawing.Color.White;
             lblMsg.Location = new System.Drawing.Point(63, 24);
             lblMsg.Name = "lblMsg";
             lblMsg.Size = new System.Drawing.Size(125, 26);
             lblMsg.TabIndex = 2;
             lblMsg.Text = "Message Text";
            // 
            // timer1
            // 
             timer1.Tick += new System.EventHandler( Timer1_Tick);
            // 
            // frm_Alert
            // 
             AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
             AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
             BackColor = System.Drawing.Color.LimeGreen;
             ClientSize = new System.Drawing.Size(350, 75);
             Controls.Add( lblMsg);
             Controls.Add( gunaPictureBox2);
             Controls.Add( gunaPictureBox1);
             FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
             Name = "frm_Alert";
             Text = "frm_Alert";
             Load += new System.EventHandler( Frm_Alert_Load);
            ((System.ComponentModel.ISupportInitialize)( gunaPictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)( gunaPictureBox2)).EndInit();
             ResumeLayout(false);
             PerformLayout();

        }

        #endregion

        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox1;
        private Guna.UI.WinForms.GunaPictureBox gunaPictureBox2;
        private System.Windows.Forms.Label lblMsg;
        private System.Windows.Forms.Timer timer1;
    }
}