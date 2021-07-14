using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmViewNotification : Form
    {
        public string Message;
        public bool ViewTick = false;
        public bool Accept = false;
        public frmViewNotification()
        {
            InitializeComponent();
        }

        private void PRNoMandP_Load(object sender, EventArgs e)
        {
            lblMessege.Text = Message;
            chkAccept.Visible = ViewTick;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (ViewTick)
                if (chkAccept.Checked)
                {
                    Accept = true;
                }
            this.Close();
        }
    }
}
