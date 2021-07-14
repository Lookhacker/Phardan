using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmLogin : Form
    {
        DataAccess data = new DataAccess();
        public string State = "none";
        public frmLogin()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        bool login;

        private void btnLogin_Click(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = true;
            radWaitingBar1.StartWaiting();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void frmLogin_HelpRequested(object sender, HelpEventArgs hlpevent)
        {
            this.TopMost = false;
            frmAbout frm = new frmAbout();
            frm.ShowDialog();
            this.TopMost = true;
        }

        private void frmLogin_Load(object sender, EventArgs e)
        {
            lblVersion.Text = "Ver : " + System.Reflection.Assembly.GetExecutingAssembly().GetName().Version.ToString();
            if (State == "OK")
                btnLogin.Enabled = true;
            else
                btnLogin.Enabled = false;
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmServer frm = new frmServer();
            this.TopMost = false;
            frm.ShowDialog();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            login = data.login(txtuser.Text, txtpass.Text);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radWaitingBar1.StopWaiting();
            if (login)
            {

                this.TopMost = false;
                //string mes = "کاربر {0} ورود شما موفقیت آمیز بود.";
                //mes = string.Format(mes, DataAccess.User.PName);
                //MessageBox.Show("ورود", mes, MessageBoxButtons.OK, MessageBoxIcon.Information);

                radWaitingBar1.Visible = true;
                radWaitingBar1.StartWaiting();
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync();
                }

            }
            else
            {
                radWaitingBar1.Visible = false;
                this.TopMost = false;
                MessageBox.Show("اخطار", "رمز ورود اشتباه می باشد دوباره وارد کنید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                this.TopMost = false;
                txtpass.Clear();
                txtpass.Focus();
            }

        }
        frmSoftWare frm;
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            frm = new frmSoftWare();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm.Show();
            this.Hide();
        }

        private void forgetpass_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            frmForgetPassword frm = new frmForgetPassword();
            this.TopMost = false;
            frm.ShowDialog();
            this.TopMost = false;
        }
    }
}
