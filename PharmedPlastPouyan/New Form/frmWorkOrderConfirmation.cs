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
    public partial class frmWorkOrderConfirmation : Form
    {
        public frmWorkOrderConfirmation()
        {
            InitializeComponent();
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            if (chkConf.Checked)
            {
                if (MessageBox.Show("دستور کار مورد تایید است؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    if (radioAccept.Checked)
                    {

                        LINQDataContext DataBase = new LINQDataContext();
                        WorkOrderConfirmation tmp = (from s in DataBase.WorkOrderConfirmations
                                                     where s.uid == Data.uid
                                                     select s).FirstOrDefault();
                        if (tmp != null)
                        {
                            if (DataAccess.User.PCode == Data.OP1Code)
                                tmp.OP1Condition = true;
                            if (DataAccess.User.PCode == Data.OP2Code)
                                tmp.OP2Condition = true;
                            if (DataAccess.User.PCode == Data.OP3Code)
                                tmp.OP3Condition = true;
                            if (DataAccess.User.PCode == Data.OP4Code)
                                tmp.OP4Condition = true;

                            if (tmp.OP1Condition && tmp.OP2Condition && tmp.OP3Condition && tmp.OP4Condition)
                            {
                                WorkOrderMonth tmp2 = (from s in DataBase.WorkOrderMonths
                                                       where s.ID == Data.ID && s.Year == Data.Year
                                                       select s).FirstOrDefault();
                                if (tmp2 != null)
                                {
                                    tmp2.Confirmation = true;
                                    Accept = true;
                                    changed = true;
                                }
                                else
                                {
                                    MessageBox.Show("خطا در بارگزاری مجدادا تلاش نمایید");
                                    return;
                                }

                            }

                            try
                            {
                                DataBase.SubmitChanges();
                                changed = true;
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("خطا در بارگزاری مجدادا تلاش نمایید");
                                return;
                            }

                        }
                        else
                        {
                            MessageBox.Show("خطا در بارگزاری مجدادا تلاش نمایید");
                            return;
                        }
                    }
                    else
                    {
                        if (txtReject.TextLength > 0)
                        {

                            LINQDataContext DataBase = new LINQDataContext();
                            WorkOrderMonth tmp = (from s in DataBase.WorkOrderMonths
                                                  where s.ID == Data.ID && s.Year == Data.Year
                                                  select s).SingleOrDefault();
                            if (tmp != null)
                            {
                                tmp.Description = DataAccess.User.PName+": "+txtReject.Text;
                                changed = true;
                            }
                            else
                            {
                                MessageBox.Show("خطا در بارگزاری مجدادا تلاش نمایید");
                                return;
                            }
                            try
                            {
                                DataBase.SubmitChanges();
                            }
                            catch (Exception)
                            {
                                MessageBox.Show("خطا در بارگزاری مجدادا تلاش نمایید");
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("در صورت عدم تایید باید فیلد توضیحات پر شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            txtReject.Focus();
                            return;
                        }
                    }
                }
                else
                {
                    return;
                }
            }
            this.Close();

        }

        private void chkConf_CheckedChanged(object sender, EventArgs e)
        {
            if (chkConf.Checked)
            {
                btnExit.Text = "ثبت و خروج";
                radioAccept.Visible = radioReject.Visible = true;
                radioAccept.Checked = true;
            }
            else
            {
                btnExit.Text = "خروج";
                radioAccept.Visible = radioReject.Visible = false;
            }
        }



        public WorkOrderConfirmation Data = new WorkOrderConfirmation();
        public bool Accept = false;
        public string EditText = "";

        public bool changed = false;

        private void frmWorkOrderConfirmation_Load(object sender, EventArgs e)
        {
            pnlchk.Visible = checkOP();
            txtID.Text = "N-" + Data.ID.ToString();
            if (Data.OP3Code == 12012)
            {
                lblM.Text = "مدیر تحقیق و توسعه";
                lblRA.Text = lblRB.Text = "----";
                lblOP1.Text = lblOP2.Text = "----";
            }
            if (Accept)
            {
                lblOP1.Text = lblOP2.Text = lblOP3.Text = lblOP4.Text = "دارد";
                lblResult.Text = "دستور کار مورد تایید است.";
                lblResult.ForeColor = Color.Green;
            }
            else
            {
                if (EditText != "" && pnlchk.Visible)
                {
                    pnlEdit.Visible = pnlEdit.Enabled = true;
                    lblEdit.Text += " " + EditText;
                }

                if (Data.OP3Code != 12012)
                {

                    if (Data.OP1Condition)
                        lblOP1.Text = "دارد";
                    else
                        lblOP1.Text = "ندارد";
                    if (Data.OP2Condition)
                        lblOP2.Text = "دارد";
                    else
                        lblOP2.Text = "ندارد";
                }
                if (Data.OP1Condition && Data.OP2Condition)
                {
                    if (Data.OP3Condition)
                    {

                        lblOP3.Text = "دارد";
                        if (Data.OP4Condition)
                        {
                            lblOP4.Text = "دارد";
                        }
                        else
                        {
                            lblOP4.Text = "ندارد";
                            lblResult.Text = "در انتظار تایید مدیر عامل";
                            if (Data.OP4Code == DataAccess.User.PCode)
                                pnlchk.Enabled = true;
                            else
                                pnlchk.Enabled = false;
                        }
                    }
                    else
                    {
                        lblOP3.Text = "ندارد";
                        lblResult.Text = "در انتظار تایید مدیر تولید";
                        if (Data.OP3Code == DataAccess.User.PCode)
                            pnlchk.Enabled = true;
                        else
                            pnlchk.Enabled = false;
                    }
                }
                else
                {
                    lblResult.Text = "در انتظار تایید روسای تولید";
                    if (Data.OP1Code == DataAccess.User.PCode || Data.OP2Code == DataAccess.User.PCode)
                        pnlchk.Enabled = true;
                    else
                        pnlchk.Enabled = false;
                }

            }

        }

        private bool checkOP()
        {
            if (Data.OP1Code == DataAccess.User.PCode)
                if (Data.OP1Condition)
                    return false;
                else
                    return true;
            if (Data.OP2Code == DataAccess.User.PCode)
                if (Data.OP2Condition)
                    return false;
                else
                    return true;
            if (Data.OP3Code == DataAccess.User.PCode)
                if (Data.OP3Condition)
                    return false;
                else
                    return true;
            if (Data.OP4Code == DataAccess.User.PCode)
                if (Data.OP4Condition)
                    return false;
                else
                    return true;
            return false;
        }

        private void radioReject_CheckedChanged(object sender, EventArgs e)
        {
            pnlReject.Visible = pnlReject.Enabled = radioReject.Checked;
        }
    }
}
