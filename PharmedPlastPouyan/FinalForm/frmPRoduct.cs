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
    public partial class frmPRoduct : Form
    {
        DataAccess Data = new DataAccess();
        DataTable DataAll = new DataTable();
        bool Edit;
        QuickSelect PR = new QuickSelect();
        public frmPRoduct()
        {
            InitializeComponent();
        }
        private void FetchData()
        {
            DataTable dt = Data.Select("QuickSelect", "kind!='N'");

            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string tmp = dt.Rows[i]["kind"].ToString();

                if (tmp == "M")
                    dt.Rows[i]["kind"] = "تولید";
                else
                {
                    if (tmp == "A")
                        dt.Rows[i]["kind"] = "مونتاژ";
                    else
                    {
                        if (tmp == "G")
                            dt.Rows[i]["kind"] = "گرانول";
                    }
                }
            }

            DataAll = dt;

        }
        private void btnClosePanel_Click(object sender, EventArgs e)
        {
            pnlAcept.Visible = pnlAcept.Enabled = false;
            txtPRCode.Clear();
            txtFastCode.Clear();
            txtPrName.Clear();
            gridAll.Enabled = true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            try
            {

                if (Edit)
                {
                    if (txtFastCode.Text.Trim() != PR.CodeFast.ToString() || txtPRCode.Text.Trim() != PR.Product_Code || txtPrName.Text.Trim() != PR.Product_Name)
                    {
                        if (Data.Select("QuickSelect", "Product_Name='" + txtPrName.Text.Trim() + "' or Product_Code='" + txtPRCode.Text.Trim() + "' or CodeFast=" + txtFastCode.Text.Trim()).Rows.Count == 0)
                        {
                            if (MessageBox.Show("اطلاعات", "آیا از ویرایش اطلاعات اطمینان دارید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                            {
                                LINQDataContext db = new LINQDataContext();
                                QuickSelect tmp = (from s in db.QuickSelects where s.ID == PR.ID select s).SingleOrDefault();
                                tmp.Product_Code = txtPRCode.Text.Trim();
                                tmp.Product_Name = txtPrName.Text.Trim();
                                tmp.CodeFast = int.Parse(txtFastCode.Text.Trim());
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
                            MessageBox.Show("ویرایش اطلاعات انجام نشد لطفا داده ها بررسی و دوباره ویرایش کنید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                    }
                    else
                    {
                        MessageBox.Show("شما هیچکدام از فیل ها را تغییر نداده اید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }

                }
                else
                {
                    if (txtFastCode.Text.Length > 0)
                    {
                        if (txtPRCode.Text.Length > 0)
                        {
                            if (txtPrName.Text.Length > 0)
                            {
                                if (Data.Select("QuickSelect", "Product_Name='" + txtPrName.Text.Trim() + "' or Product_Code='" + txtPRCode.Text.Trim() + "' or CodeFast=" + txtFastCode.Text.Trim()).Rows.Count == 0)
                                {
                                    LINQDataContext db = new LINQDataContext();
                                    QuickSelect tmp = new QuickSelect();
                                    tmp.Product_Code = txtPRCode.Text.Trim();
                                    tmp.Product_Name = txtPrName.Text.Trim();
                                    tmp.CodeFast = int.Parse(txtFastCode.Text.Trim());
                                    switch (comType.SelectedIndex)
                                    {
                                        case 0:
                                            tmp.kind = "M";
                                            break;
                                        case 1:
                                            tmp.kind = "G";
                                            break;
                                        case 2:
                                            tmp.kind = "A";
                                            break;
                                    }
                                    db.QuickSelects.InsertOnSubmit(tmp);
                                    try
                                    {
                                        db.SubmitChanges();
                                        MessageBox.Show("ثبت اطلاعات با موفقیت انجام شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        btnClosePanel_Click(null, null);
                                        FetchData();
                                    }
                                    catch (Exception ex) { MessageBox.Show(ex.Message); }


                                }
                                else
                                {
                                    MessageBox.Show("در این فیل ها فیلد تکراری وجود دارد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                }
                            }
                            else
                            {
                                MessageBox.Show("فیلد نام محصول نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtPrName.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("فیلد کد محصول نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtPRCode.Focus();
                        }
                    }
                    else
                    {
                        MessageBox.Show("فیلد کد انتخاب سریع نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtFastCode.Focus();
                    }

                }
            }
            catch (Exception)
            {
                return;
            }

        }

        private void btnPnlAdd_Click(object sender, EventArgs e)
        {
            Edit = false;
            pnlAcept.Visible = pnlAcept.Enabled = true;
            btnAdd.Text = "ثبت";
            comType.SelectedIndex = 0;
            gridAll.Enabled = false;
        }

        private void frmPRoduct_Load(object sender, EventArgs e)
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
                if (e.RowIndex >= 0)
                {

                    Edit = true;
                    btnAdd.Text = "ویرایش";
                    txtFastCode.Text = e.Row.Cells["CodeFast"].Value.ToString();
                    PR.CodeFast = Convert.ToInt32(txtFastCode.Text);
                    txtPRCode.Text = e.Row.Cells["Product_Code"].Value.ToString().Trim();
                    PR.Product_Code = txtPRCode.Text.Trim();
                    txtPrName.Text = e.Row.Cells["Product_Name"].Value.ToString();
                    PR.Product_Name = txtPrName.Text.Trim();
                    PR.ID = Convert.ToInt32(e.Row.Cells["ID"].Value);

                    pnlAcept.Visible = pnlAcept.Enabled = true;
                    gridAll.Enabled = false;
                }
            }
        }

        private void txtFastCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

    }
}
