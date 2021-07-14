using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmServer : Form
    {
        DataAccess Data = new DataAccess();
        bool ServerCheck;
        bool ChangeServer;
        string ServerAddress;
        public frmServer()
        {
            InitializeComponent();
        }
        private void frmServer_Load(object sender, EventArgs e)
        {
            string txt = File.ReadAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Setting.mmp");
            txt = txt.Replace("ipaddress=", "");
            ServerAddress = txtServer.Text = txt;
        }
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ChangeServer)
            {
                if (ServerCheck)
                {
                    File.WriteAllText(Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location) + "\\Setting.mmp", txtServer.Text);
                    MessageBox.Show("اتصال با موفقیت انجام شد \n پس از بسته شدن برنامه آن را مجدادا باز کنید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Application.Exit();
                }
            }
            this.Close();
        }
        private void txtServer_Leave(object sender, EventArgs e)
        {
            if (txtServer.Text != ServerAddress)
                ChangeServer = true;
            else
                ChangeServer = false;
        }
        private void btnTest_Click(object sender, EventArgs e)
        {
            radWaitingBar1.Visible = true;
            radWaitingBar1.StartWaiting();
            if (BackWork.IsBusy != true)
            {
                BackWork.RunWorkerAsync();
            }
            btnSave.Enabled = btnTest.Enabled = txtServer.Enabled = false;
        }

        private void BackWork_DoWork(object sender, DoWorkEventArgs e)
        {
            ServerCheck = Data.CheckConnection(txtServer.Text);
            if (ServerCheck)
                System.Threading.Thread.Sleep(500);
        }

        private void BackWork_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            btnSave.Enabled = btnTest.Enabled = true;
            txtServer.Enabled = true;
            radWaitingBar1.Visible = false;
            if (ServerCheck)
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.Ready;
                btnSave.Text = "تایید";
            }
            else
            {
                pictureBox1.Visible = true;
                pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.NotReady;
                btnSave.Text = "بستن";
            }
        }

        private void frmServer_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (BackWork.IsBusy == true)
            {
                e.Cancel = true;
            }
        }
    }
}
