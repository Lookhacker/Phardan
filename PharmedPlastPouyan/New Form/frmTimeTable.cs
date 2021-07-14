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
    public partial class frmTimeTable : Form
    {
        public frmTimeTable()
        {
            InitializeComponent();
            LINQDataContext DataBase = new LINQDataContext();
            edit = (from s in DataBase.tblAdmins where s.Parameter == "ED-Create" select s.Value).SingleOrDefault();
            darsad = (from s in DataBase.tblAdmins where s.Parameter == "Perc-Assembly" select s.Value).SingleOrDefault();
            createTime = (from s in DataBase.tblAdmins where s.Parameter == "CR-Time" select s.Value).SingleOrDefault();
            limit = Convert.ToBoolean((from s in DataBase.tblAdmins where s.Parameter == "CR-TimeLimit" select s.Value).SingleOrDefault());
        }
        string edit = "";
        string darsad = "";
        string createTime = "";
        bool limit = false;
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KeyPresss(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void frmTimeTable_Load(object sender, EventArgs e)
        {
            txtEdit.Text = edit;
            txtDarsad.Text = darsad;
            txtCreateTime.Text = createTime;
            chkLimit.Checked = limit;
            chkLimit_CheckedChanged(null, null);
        }

        private void txtEdit_TextChanged(object sender, EventArgs e)
        {
            if (txtEdit.TextLength == 0)
                btnSave.Enabled = false;
            else
            {
                if (txtEdit.Text == edit)
                    btnSave.Enabled = false;
                else
                    btnSave.Enabled = true;
            }
        }
        private void txtRequest_TextChanged(object sender, EventArgs e)
        {
            if (txtDarsad.TextLength == 0)
                btnSave.Enabled = false;
            else
            {
                if (txtDarsad.Text == darsad)
                    btnSave.Enabled = false;
                else
                    btnSave.Enabled = true;
            }
        }
        
        private void txtCreateTime_TextChanged(object sender, EventArgs e)
        {
            if (txtCreateTime.TextLength == 0)
                btnSave.Enabled = false;
            else
            {
                if (txtCreateTime.Text == createTime)
                    btnSave.Enabled = false;
                else
                    btnSave.Enabled = true;
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DataAccess.User.Admin)
            {
                LINQDataContext db = new LINQDataContext();

                if (txtDarsad.Text != darsad)
                {
                    var tmp2 = (from s in db.tblAdmins
                                where s.Parameter == "ED-Accept"
                                select s).SingleOrDefault();
                    tmp2.Value = txtDarsad.Text;
                }

                if (txtEdit.Text != edit)
                {
                    var tmp3 = (from s in db.tblAdmins
                                where s.Parameter == "ED-Create"
                                select s).SingleOrDefault();
                    tmp3.Value = txtEdit.Text;
                }

                if (txtCreateTime.Text != createTime)
                {
                    var tmp4 = (from s in db.tblAdmins
                                where s.Parameter == "CR-Time"
                                select s).SingleOrDefault();
                    tmp4.Value = txtCreateTime.Text;
                }

                if (chkLimit.Checked != limit)
                {
                    var tmp4 = (from s in db.tblAdmins
                                where s.Parameter == "CR-TimeLimit"
                                select s).SingleOrDefault();
                    if (chkLimit.Checked)
                    {
                        tmp4.Value = "true";
                        limit = true;
                    }
                    else
                    {
                        tmp4.Value = "false";
                        limit = false;
                    }
                }

                try
                {
                    db.SubmitChanges();
                    edit = txtEdit.Text;
                    darsad = txtDarsad.Text;
                    MessageBox.Show("ثبت با موفقیت انجام شد.", "اطلاعات");
                    btnSave.Enabled = false;
                }
                catch (Exception)
                {
                }
            }
            else
            {
                MessageBox.Show("شما مجوز ویرایش زمان ها را ندارید", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void chkLimit_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLimit.Checked)
                txtCreateTime.Enabled = false;
            else
                txtCreateTime.Enabled = true;

            if (chkLimit.Checked!=limit)
                btnSave.Enabled = true;
            else
                btnSave.Enabled = false;
        }
    }
}
