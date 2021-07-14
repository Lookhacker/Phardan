using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmSoftWare : Form
    {
        public frmSoftWare()
        {
            InitializeComponent();
            label1.Text = DataAccess.User.EnglishName;
        }

        private void frmSoftWare_Load(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        frmMain frm;
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            frm = new frmMain();
            Thread.Sleep(4000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            frm.Show();
            this.Hide();
        }
    }
}
