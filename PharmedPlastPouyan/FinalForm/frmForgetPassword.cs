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
    public partial class frmForgetPassword : Form
    {
        public frmForgetPassword()
        {
            InitializeComponent();
        }
        
        private void btnVerify_Click(object sender, EventArgs e)
        {
            LINQDataContext Database = new LINQDataContext();
            var dt = from u in Database.UserTables
                     where u.PTell == txtPhone.Text && u.UName == txtUser.Text
                     select u;
            if (dt.Count() == 1)
            {
                UserTable user = dt.FirstOrDefault();
                btnVerify.Enabled = txtPhone.Enabled = txtUser.Enabled = false;
                txtVerify.Enabled = true;
                txtVerify.Focus();
            }
            else
            {
                MessageBox.Show("نام کاربری یا شماره تلفن صحیح نیست", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }

        private void txtVerify_TextChanged(object sender, EventArgs e)
        {
            string VerifyCode = "1";
            if (txtVerify.Text==VerifyCode)
            {
                txtVerify.Enabled = false;
                txtNewConfPass.Visible = txtNewPass.Visible = label4.Visible = label5.Visible = pictureBox1.Visible = true;
                txtNewPass.Focus();
            }
        }
        bool PassCheck;
        private void txtNewConfPass_TextChanged(object sender, EventArgs e)
        {
            if (txtNewPass.Text.Trim() == txtNewConfPass.Text.Trim())
            {
                pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.Ready;
                PassCheck = true;
            }
            else
            {
                pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.NotReady;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            LINQDataContext Database = new LINQDataContext();
            if (PassCheck)
            {
                var dt = from u in Database.UserTables
                         where u.PTell == txtPhone.Text && u.UName == txtUser.Text
                         select u;
                UserTable user = dt.FirstOrDefault() ;
                user.Password = txtNewConfPass.Text.Trim();
                try
                {
                    Database.SubmitChanges();
                    MessageBox.Show("تغییر رمز عبور انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception)
                {

                }
            }
            else
            {
                MessageBox.Show("رمز های عبور با هم انطباق ندارند", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }
            this.Close();

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
