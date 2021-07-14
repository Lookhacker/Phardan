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
    public partial class frmUserView : Form
    {
        DataAccess Data = new DataAccess();
        bool firstRun;
        public frmUserView()
        {
            InitializeComponent();
        }

        private void frmUserView_Load(object sender, EventArgs e)
        {
            firstRun = true;
            txtPhone.Text = DataAccess.User.PTell;
            txtPersonalName.Text = DataAccess.User.PName;
            txtUserName.Text = DataAccess.User.UName;
            txtUserCode.Text = DataAccess.User.PCode.ToString();
            if (DataAccess.User.verifyPhone)
            {
                pictureBox2.Image = global::PharmedPlastPouyan.Properties.Resources.Ready;
            }
            else
            {
                btnVerify.Visible = btnVerify.Enabled = txtVerify.Visible = true;
                pictureBox2.Image = global::PharmedPlastPouyan.Properties.Resources.NotReady;
            }
            firstRun = false;
        }


        bool PassCheck;
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (txtCurPass.Text == "")
            {
                this.Close();
                return;
            }

            if (txtCurPass.Text.Trim() == DataAccess.User.Password)
            {
                LINQDataContext Database = new LINQDataContext();

                if (PassCheck)
                {
                    var dt = (from u in Database.UserTables
                              where u.ID == DataAccess.User.ID
                              select u).FirstOrDefault();
                    UserTable user = dt;

                    user.Password = txtNewConfPass.Text.Trim();
                    DataAccess.User.Password = user.Password;
                    try
                    {
                        Database.SubmitChanges();
                        MessageBox.Show("تغییر رمز عبور انجام شد", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception)
                    {

                    }
                }
                this.Close();
            }
            else
            {
                MessageBox.Show("کلمه عبور فعلی اشتباه است", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCurPass.Text = "";
                txtCurPass.Focus();

            }

        }
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
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnPass_Click(object sender, EventArgs e)
        {
            if (btnPass.Text == "تغییر رمز عبور")
            {
                btnPass.Text = "لغو";
                label4.Visible = label5.Visible = txtNewPass.Visible = txtNewConfPass.Visible = true;
                pictureBox1.Visible = true;
                txtNewPass.Focus();

            }
            else
            {
                btnPass.Text = "تغییر رمز عبور";
                label4.Visible = label5.Visible = txtNewPass.Visible = txtNewConfPass.Visible = false;
                pictureBox1.Visible = false;
                txtNewPass.Text = txtNewConfPass.Text = "";
                txtCurPass.Focus();
            }
        }
        private void btnVerify_Click(object sender, EventArgs e)
        {
            if (txtPhone.Text.Length == 11)
            {
                string Verifycode="error";

                btnVerify.Enabled = false;
                if (Verifycode == "error")
                {
                    frmViewNotification frm = new frmViewNotification();
                    frm.Message = "کاربری گرامی \n\nاین سرویس برای خط شما غیر فعال است.\n\n ابتدا باید سرویس دریافت پیام کوتاه را برای شماره شرکت فعال کنید. \n\n اگر از خط همراه اول استفاده می کنید کافیست که عدد ۲ را به شماره ۸۹۹۹ ارسال کنید. \n\n و اگر از خط ایرانسل استفاده می کنید عدد ۰ را به شماره ۵۰۰۵ ارسال کنید. \n\nفارمد پلاست پویان ";
                    frm.ShowDialog();
                }
                else
                {
                    txtVerify.Visible = txtVerify.Enabled = true;
                }
                txtVerify.Focus();
            }

        }

        private void txtVerify_TextChanged(object sender, EventArgs e)
        {
        string Verifycode="error";
            if (txtVerify.Text == Verifycode)
            {
                txtVerify.Visible = false;
                btnVerify.Visible = false;
                pictureBox2.Image = global::PharmedPlastPouyan.Properties.Resources.Ready;

                LINQDataContext Database = new LINQDataContext();
                var dt = (from u in Database.UserTables
                          where u.ID == DataAccess.User.ID
                          select u).FirstOrDefault();
                UserTable user = dt;

                user.PTell = txtPhone.Text;
                DataAccess.User.PTell = user.PTell;
                user.verifyPhone = true;
                DataAccess.User.verifyPhone = user.verifyPhone;
                try
                {
                    Database.SubmitChanges();
                }
                catch (Exception)
                {
                    return;
                }
            }
        }

        private void txtPhone_TextChanged(object sender, EventArgs e)
        {
            if (firstRun)
                return;

            if (txtPhone.Text.Length == 11)
            {

                if (DataAccess.User.PTell == txtPhone.Text)
                {
                    if (DataAccess.User.verifyPhone)
                    {

                        txtVerify.Visible = false;
                        btnVerify.Visible = false;
                        pictureBox2.Image = global::PharmedPlastPouyan.Properties.Resources.Ready;
                        return;

                    }
                }
                txtVerify.Visible = true;
                btnVerify.Visible = true;
                btnVerify.Enabled = true;

            }
            pictureBox2.Image = global::PharmedPlastPouyan.Properties.Resources.NotReady;
        }

        private void txtVerify_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
