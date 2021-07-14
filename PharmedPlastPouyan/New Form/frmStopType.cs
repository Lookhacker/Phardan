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
    public partial class frmStopType : Form
    {
        DataAccess Data = new DataAccess();
        DataTable DataParrent = new DataTable();
        DataTable DataAll = new DataTable();
        bool Edit; int ParrentID;
        StopType stop = new StopType();
        public frmStopType()
        {
            InitializeComponent();
            DataParrent = Data.Select("StopType", "ParrentID=0 order by Tartib ASC");
            comType.DataSource = DataParrent;
        }
        private void FetchData(string parrent)
        {
            DataAll = Data.Select("StopType", "ParrentID=" + parrent + " order by Tartib ASC");
            gridAll.DataSource = DataAll;
        }
        private void frmStopType_Load(object sender, EventArgs e)
        {
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParrentID = (int)comType.SelectedValue;
            FetchData(ParrentID.ToString());
        }

        private void btnPnlAdd_Click(object sender, EventArgs e)
        {
            Edit = false;
            pnlAcept.Visible = pnlAcept.Enabled = true;
            btnAdd.Text = "ثبت";
            gridAll.Enabled = false;

        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Edit)
                {
                    if (txtStopCode.Text.Trim() != stop.StopID.ToString() || txtStopName.Text.Trim() != stop.Title)
                    {
                        if (Data.Select("StopType", "StopID=" + txtStopCode.Text.Trim()).Rows.Count == 0)
                        {

                            if (Data.Select("StopType", "Title='" + txtStopName.Text.Trim() + "' and ParrentID = " + stop.ParrentID.ToString()).Rows.Count == 0)
                            {
                                if (MessageBox.Show("اطلاعات", "آیا از ویرایش اطلاعات اطمینان دارید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                                {
                                    LINQDataContext db = new LINQDataContext();
                                    StopType tt = (from s in db.StopTypes where s.ID == stop.ID select s).SingleOrDefault();
                                    tt.StopID = Convert.ToInt32(txtStopCode.Text);
                                    tt.Title = txtStopName.Text;
                                    try
                                    {
                                        db.SubmitChanges();
                                        MessageBox.Show("ویرایش اطلاعات با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        btnClosePanel_Click(null, null);
                                        FetchData(stop.ParrentID.ToString());
                                    }
                                    catch (Exception)
                                    {
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("این نام قبلا وارد شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("این کد قبلا برای توقف دیگری ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {

                        }
                    }
                    else
                    {
                        MessageBox.Show("شما هیچکدام از فیل ها را تغییر نداده اید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (txtStopCode.Text.Length > 1)
                    {
                        if (txtStopName.Text.Length > 0)
                        {
                            if (Data.Select("StopType", "StopID=" + txtStopCode.Text.Trim()).Rows.Count == 0)
                            {
                                if (Data.Select("StopType", "Title='" + txtStopName.Text.Trim() + "' and ParrentID = " + ParrentID.ToString()).Rows.Count == 0)
                                {
                                    LINQDataContext db = new LINQDataContext();
                                    StopType tt = new StopType();
                                    tt.StopID = Convert.ToInt32(txtStopCode.Text.Trim());
                                    tt.Title = txtStopName.Text;
                                    tt.Tartib = (from s in db.StopTypes where s.ParrentID == ParrentID select s).Max(x => x.Tartib);
                                    tt.ParrentID = ParrentID;
                                    db.StopTypes.InsertOnSubmit(tt);
                                    try
                                    {
                                        db.SubmitChanges();
                                        MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        btnClosePanel_Click(null, null);
                                        FetchData(ParrentID.ToString());
                                    }
                                    catch (Exception)
                                    {
                                    }
                                }
                                else
                                {
                                    MessageBox.Show("این نام قبلا وارد شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("این کد قبلا برای توقف دیگری ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                        else
                        {
                            MessageBox.Show("فیلد نوع توقف نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtStopName.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("فیلد کد توقف نباید کمتر از یک رقم باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtStopCode.Focus();
                    }

                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            pnlAcept.Visible = pnlAcept.Enabled = false;
            txtStopCode.Clear();
            txtStopName.Clear();
            gridAll.Enabled = true;
        }
    }
}
