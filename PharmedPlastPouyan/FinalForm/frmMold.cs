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
    public partial class frmMold : Form
    {
        DataAccess Data = new DataAccess();
        DataTable DataAll = new DataTable();
        int IDPR; bool Edit;
        Mold mold = new Mold();
        public frmMold()
        {
            InitializeComponent();
        }

        private void FetchData()
        {
            DataAll = Data.Select("SELECT [Mold].ID , [Mold].MoldCode, [Mold].MoldNum, [Mold].Quetta,[Mold].IDProtection, [QuickSelect].Product_Code, [QuickSelect].Product_Name ,[QuickSelect].CodeFast FROM [Mold],[QuickSelect] where Mold.IDProtection=QuickSelect.ID order by [Mold].MoldCode,[Mold].MoldNum");
            gridAll.DataSource = DataAll;
        }
        private void frmMold_Load(object sender, EventArgs e)
        {
            FetchData();
            gridAll.DataSource = DataAll;
            if (DataAccess.User.Admin)
            {
                btnPnlAdd.Visible = true;
            }
        }
        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (DataAccess.User.Admin)
            {
                Edit = true;
                btnAdd.Text = "ویرایش";
                txtFastCode.Text = e.Row.Cells["CodeFast"].Value.ToString();
                txtMoldCode.Text = e.Row.Cells["MoldCode"].Value.ToString().Trim();
                mold.MoldCode = txtMoldCode.Text;
                txtMoldNumber.Text = e.Row.Cells["MoldNum"].Value.ToString();
                mold.MoldNum = Convert.ToInt32(txtMoldNumber.Text);
                txtQuetta.Text = e.Row.Cells["Quetta"].Value.ToString();
                mold.Quetta = Convert.ToInt32(txtQuetta.Text);
                mold.ID = Convert.ToInt32(e.Row.Cells["ID"].Value);
                mold.IDProtection = IDPR = Convert.ToInt32(e.Row.Cells["IDProtection"].Value);
                lblPrCode.Text = e.Row.Cells["Product_Code"].Value.ToString();
                lblPrName.Text = e.Row.Cells["Product_Name"].Value.ToString();
                pnlAcept.Visible = pnlAcept.Enabled = true;
                gridAll.Enabled = false;
            }
        }
        private void btnPnlAdd_Click(object sender, EventArgs e)
        {
            Edit = false;
            pnlAcept.Visible = pnlAcept.Enabled = true;
            btnAdd.Text = "ثبت";
            gridAll.Enabled = false;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            pnlAcept.Visible = pnlAcept.Enabled = false;
            txtFastCode.Text = "";
            txtMoldCode.Clear();
            txtMoldNumber.Clear();
            txtQuetta.Clear();
            lblPrCode.Text = "";
            lblPrName.Text = "";
            gridAll.Enabled = true;
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {
                if (Edit)
                {
                    if (IDPR != mold.IDProtection || txtMoldCode.Text.Trim() != mold.MoldCode || txtMoldNumber.Text.Trim() != mold.MoldNum.ToString() || txtQuetta.Text.Trim() != mold.Quetta.ToString())
                    {
                        if (MessageBox.Show("اطلاعات", "آیا از ویرایش اطلاعات اطمینان دارید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                        {
                            LINQDataContext db = new LINQDataContext();
                            Mold tmp = (from s in db.Molds where s.ID == mold.ID select s).SingleOrDefault();
                            tmp.MoldCode = txtMoldCode.Text.Trim();
                            tmp.MoldNum = Convert.ToInt16(txtMoldNumber.Text.Trim());
                            tmp.Quetta = Convert.ToInt16(txtQuetta.Text.Trim());
                            tmp.IDProtection = IDPR;
                            try
                            {
                                db.SubmitChanges();
                                MessageBox.Show("ویرایش اطلاعات با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnClosePanel_Click(null, null);
                                FetchData();
                            }
                            catch (Exception) { }
                        }
                    }
                    else
                    {
                        MessageBox.Show("شما هیچکدام از فیل ها را تغییر نداده اید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (txtMoldCode.Text.Length > 0)
                    {
                        if (txtMoldNumber.Text.Length > 0)
                        {
                            if (txtQuetta.Text.Length > 0)
                            {
                                if (txtFastCode.Text.Length > 0)
                                {
                                    LINQDataContext db = new LINQDataContext();
                                    Mold tmp = new Mold();
                                    tmp.MoldCode = txtMoldCode.Text.Trim();
                                    tmp.MoldNum = Convert.ToInt16(txtMoldNumber.Text.Trim());
                                    tmp.Quetta = Convert.ToInt16(txtQuetta.Text.Trim());
                                    tmp.IDProtection = IDPR;
                                    db.Molds.InsertOnSubmit(tmp);
                                    try
                                    {
                                        db.SubmitChanges();
                                        MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        btnClosePanel_Click(null, null);
                                        FetchData();
                                    }
                                    catch (Exception) { }
                                }
                                else
                                {
                                    MessageBox.Show("فیلد کد انتخاب سریع نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    btnFastcodeview.Focus();
                                }
                            }
                            else
                            {
                                MessageBox.Show("فیلد تعداد کویته نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                btnFastcodeview.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("فیلد شماره قالب نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnFastcodeview.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("فیلد نام قالب نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        btnFastcodeview.Focus();
                    }

                }
            }
            catch (Exception)
            {
                return;
            }

        }
        private void btnFastcodeview_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.Shart = "M";
            frm.ShowDialog();
            if (frm.Clicked)
            {
                txtFastCode.Text = frm.codefast;
                lblPrCode.Text = frm.PRCode;
                lblPrName.Text = frm.PRName;
                IDPR = frm.IDPR;
            }
        }
        private void txtMoldNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}
