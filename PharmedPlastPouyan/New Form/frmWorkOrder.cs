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
    public partial class frmWorkOrder : Form
    {
        public frmWorkOrder()
        {
            InitializeComponent();
        }
        DataAccess Data = new DataAccess();
        WorkOrderMonth WMont;
        WorkOrderYear WYear;
        WorkOrderTrail Wtrail;


        private void frmWorkOrder_Load(object sender, EventArgs e)
        {
            ClearForm();
        }

        private void ClearForm()
        {
            txtIDView.Text = "-----";
            radioMont.Checked = true;
            WMont = new WorkOrderMonth();
            WYear = new WorkOrderYear();
            Wtrail = new WorkOrderTrail();
            WMont.EditText = WYear.EditText = Wtrail.EditText = "بدون ویرایش";
            txtYear.Clear();
            txtYear.Text = "1399";
            txtMont.Clear();
            txtDayStart.Clear();
            txtDayFinish.Clear();
            txtClosingNotWork.Clear();
            txtClosingAll.Clear();
            FectID();
            txtMachineNum.Clear();
            Fastcod = new QuickSelect();
            fastCode = 0;
            txtFastCode.Clear();
            lblProdectCode.Text = "";
            lblProdectName.Text = "";
            comboTemplate.Items.Clear();
            comboTemplate.Enabled = false;
            txtDescription.Clear();
            txtPartNum.Clear();
            txtSalon.Clear();
            txtprNow.Clear();
            txtpartOfYear.Clear();
            txtlasCycleTime.Clear();
            txtMinCycleTime.Clear();
            txtPerMonthAloans.Clear();
            txtAllAloans.Clear();
            txtLastActivekavite.Clear();
            kaviteh = 0;
            txtavgCycleTime.Clear();
            txtCycleTime.Clear();
            txtActiveKavite.Clear();
            txtDayWoked.Clear();
            txtAloans.Clear(); ;
            txtMinPrDay.Clear();
            txtMinAllWorkorder.Clear();
            txtApplicant.Clear();
            txtRequestNum.Clear();
            txtMont.Focus();
            txtAloans.Clear();
            DayWork();
        }

        private void FectID()
        {
            int Year = 0;
            if (txtYear.TextLength == 0)
                Year = 0;
            else
                Year = int.Parse(txtYear.Text);
            if (Year > 1398)
            {
                LINQDataContext db = new LINQDataContext();
                var tmp1 = (from s in db.WorkOrderMonths
                            where s.Year == WMont.Year
                            select new
                            {
                                mmp = s.ID
                            }.mmp);
                if (tmp1.Count() > 0)
                    WMont.ID = tmp1.Max() + 1;
                else
                    WMont.ID = 1;
                var tmp2 = (from s in db.WorkOrderYears
                            where s.Year == WMont.Year
                            select new
                            {
                                mmp = s.ID
                            }.mmp);
                if (tmp2.Count() > 0)
                    WYear.ID = tmp2.Max() + 1;
                else
                    WYear.ID = 1;

                var tmp3 = (from s in db.WorkOrderTrails
                            where s.Year == WMont.Year
                            select new
                            {
                                mmp = s.ID
                            }.mmp);
                if (tmp3.Count() > 0)
                    Wtrail.ID = tmp3.Max() + 1;
                else
                    Wtrail.ID = 1;

            }
            else
            {
                WMont.ID = 0;
                WYear.ID = 0;
                Wtrail.ID = 0;
            }
            changeTxtID();
            LINQDataContext dd = new LINQDataContext();

            WorkOrderMonth mac = (from s in dd.WorkOrderMonths
                                  where s.ID == (WMont.ID - 1) && s.Year == WMont.Year
                                  select s).SingleOrDefault();

            if (mac != null)
            {
                txtMont.Text = mac.Month.ToString();
                txtDayStart.Text = mac.DayStart.ToString();
                txtDayFinish.Text = mac.DayFinish.ToString();
                txtClosingAll.Text = mac.ClosingAll.ToString();
            }
            else
            {
                txtMont.Clear();
                txtDayStart.Clear();
                txtDayFinish.Clear();
                txtClosingAll.Clear();
            }
        }
        private void changeTxtID()
        {
            int Year = 0;
            if (txtYear.TextLength == 0)
                Year = 0;
            else
                Year = int.Parse(txtYear.Text);
            if (Year > 1398)
            {
                if (radioMont.Checked)
                {
                    txtIDView.Text = "N-" + WMont.ID.ToString();
                    return;
                }
                else
                {
                    if (radioTrail.Checked)
                    {
                        txtIDView.Text = "E-" + Wtrail.ID.ToString();
                        return;
                    }
                    else
                    {

                        if (radioYear.Checked)
                        {
                            txtIDView.Text = "P-" + WYear.ID.ToString();
                            return;
                        }
                        else
                        {
                            txtIDView.Text = "-----";
                            return;
                        }
                    }
                }
            }
            else
            {
                txtIDView.Text = "-----";
                return;
            }

        }
        private void radioTrail_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioTrail.Checked)
                return;
            pnlR1T.Enabled = true;
            pnlR1C.Enabled = false;
            pnlR1D.Enabled = true;
            pnlR2D.Enabled = false;
            pnlR3Fill.Enabled = true;
            pnlR4T.Enabled = false;
            pnlR4C.Enabled = true;
            changeTxtID();
            visableCheck();
            getData();
        }

        private void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioYear.Checked)
                return;
            pnlR1T.Enabled = false;
            pnlR1C.Enabled = false;
            pnlR1D.Enabled = false;
            pnlR2D.Enabled = true;
            pnlR3Fill.Enabled = false;
            pnlR4T.Enabled = false;
            pnlR4C.Enabled = false;
            comboTemplate.Enabled = false;
            changeTxtID();
            visableCheck();
            getData();
        }

        private void radioMont_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioMont.Checked)
                return;
            pnlR1T.Enabled = true;
            pnlR1C.Enabled = true;
            pnlR1D.Enabled = true;
            pnlR2D.Enabled = false;
            pnlR3Fill.Enabled = true;
            pnlR4T.Enabled = true;
            pnlR4C.Enabled = false;
            comboTemplate.Enabled = true;
            changeTxtID();
            visableCheck();
            getData();
        }

        private void visableCheck()
        {
            picR1T.Visible = !pnlR1T.Enabled;
            picR1C.Visible = !pnlR1C.Enabled;
            picR1D.Visible = !pnlR1D.Enabled;
            picR2D.Visible = !pnlR2D.Enabled;
            picR3Fill.Visible = !pnlR3Fill.Enabled;
            picR4T.Visible = !pnlR4T.Enabled;
            picR4C.Visible = !pnlR4C.Enabled;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnFastView_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.ShowDialog();
            if (frm.Clicked)
            {
                txtFastCode.Text = frm.codefast;
                GetPrdata();
            }
        }
        int fastCode = 0;
        QuickSelect Fastcod = new QuickSelect();
        private int kaviteh;

        string Kind = "";
        private void GetPrdata()
        {
            LINQDataContext DataBase = new LINQDataContext();
            if (txtFastCode.Text.Trim().Length > 0)
            {
                if (fastCode.ToString() == txtFastCode.Text.Trim())
                    return;

                var a = from u in DataBase.QuickSelects
                        where u.CodeFast == int.Parse(txtFastCode.Text) && u.kind != "N"
                        select u;
                if (a.Count() == 1)
                {
                    Fastcod = null;
                    Fastcod = a.First();

                    switch (Fastcod.kind)
                    {
                        case "G":
                            txtActiveKavite.ReadOnly = true;
                            txtActiveKavite.TabStop = false;
                            txtCycleTime.ReadOnly = true;
                            txtCycleTime.TabStop = false;
                            label29.Text = "کویته فعال :";
                            txtActiveKavite.Text = "0";
                            txtCycleTime.Text = "0";
                            txtMinPrDay.TabStop = true;
                            txtMinPrDay.ReadOnly = false;
                            txtAloans.TabStop = false;
                            txtAloans.ReadOnly = true;
                            Kind = "GR";
                            break;
                        case "A":
                            txtActiveKavite.ReadOnly = false;
                            txtActiveKavite.TabStop = true;
                            txtCycleTime.ReadOnly = false;
                            txtCycleTime.TabStop = true;
                            label29.Text = "تعداد ایستگاه :";
                            txtActiveKavite.Clear();
                            txtCycleTime.Clear();
                            txtMinPrDay.TabStop = false;
                            txtMinPrDay.ReadOnly = true;
                            txtAloans.TabStop = true;
                            txtAloans.ReadOnly = false;
                            Kind = "AS";
                            break;

                        default:
                            txtActiveKavite.ReadOnly = false;
                            txtActiveKavite.TabStop = true;
                            txtCycleTime.ReadOnly = false;
                            txtCycleTime.TabStop = true;
                            label29.Text = "کویته فعال :";
                            txtActiveKavite.Clear();
                            txtCycleTime.Clear();
                            txtMinPrDay.TabStop = false;
                            txtMinPrDay.ReadOnly = true;
                            txtAloans.TabStop = true;
                            txtAloans.ReadOnly = false;
                            Kind = "PR";
                            break;
                    }

                    lblProdectCode.Text = Fastcod.Product_Code;
                    lblProdectName.Text = Fastcod.Product_Name;
                    fastCode = Convert.ToInt32(Fastcod.CodeFast);
                    WMont.ProdectionCode = Fastcod.Product_Code;
                    WYear.ProdectionCode = Fastcod.Product_Code;
                    Wtrail.ProdectionCode = Fastcod.Product_Code;
                    WMont.ProdectionName = Fastcod.Product_Name;
                    WYear.ProdectionName = Fastcod.Product_Name;
                    Wtrail.ProdectionName = Fastcod.Product_Name;

                    var b = from u in DataBase.Molds
                            where u.IDProtection == Fastcod.ID
                            select u;

                    switch (b.Count())
                    {
                        case 0:
                            comboTemplate.Enabled = false;
                            comboTemplate.Items.Clear();
                            WMont.TemplateNum = 0;
                            Wtrail.TemplateNum = 0;
                            getData();
                            break;
                        case 1:
                            comboTemplate.Enabled = false;
                            comboTemplate.Items.Clear();
                            comboTemplate.Items.Add("1");
                            comboTemplate.SelectedIndex = 0;
                            break;
                        default:
                            if (!radioYear.Checked)
                            {
                                comboTemplate.Enabled = true;
                            }
                            comboTemplate.Items.Clear();
                            for (int i = 0; i < b.Count(); i++)
                            {
                                comboTemplate.Items.Add((i + 1).ToString());
                            }
                            comboTemplate.SelectedIndex = 0;
                            break;
                    }
                    if (comboTemplate.Enabled)
                        comboTemplate.Focus();
                    else
                        txtDescription.Focus();
                    return;
                }
                else
                {
                    if (a.Count() > 1)
                    {
                        MessageBox.Show("خطا", "برای کد بیشتر از یک کالا تعریف شده است.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("خطا", "این کالا تعریف نشده است", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            fastCode = 0;
            lblProdectCode.Text = "";
            lblProdectName.Text = "";
            WMont.ProdectionCode = null;
            WYear.ProdectionCode = null;
            Wtrail.ProdectionCode = null;
            WMont.ProdectionName = null;
            WYear.ProdectionName = null;
            Wtrail.ProdectionName = null;
            comboTemplate.Items.Clear();
            comboTemplate.Enabled = false;
            txtActiveKavite.ReadOnly = false;
            txtActiveKavite.TabStop = true;
            txtCycleTime.ReadOnly = false;
            txtCycleTime.TabStop = true;
            txtActiveKavite.Clear();
            txtCycleTime.Clear();
            txtAllAloans.Clear();
            txtMinPrDay.TabStop = false;
            txtMinPrDay.ReadOnly = true;
            txtAloans.TabStop = true;
            txtAloans.ReadOnly = false;
            txtFastCode.Clear();
            getData();

        }
        private void IsNumberic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void DayWork()
        {
            if (WMont.DayFinish > 0 && WMont.DayStart > 0)
            {
                int res = 0;
                if (WMont.DayStart <= WMont.DayFinish)
                    res = ((WMont.DayFinish - WMont.DayStart) - WMont.ClosingNotWork) + 1;
                if (res > 0)
                    txtDayWoked.Text = res.ToString();
                else
                    txtDayWoked.Text = "0";
            }
            else
            {
                txtDayWoked.Text = "0";
            }
        }

        private void IsNumbericFastCode(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtDescription.Focus();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtFastCode_Leave(object sender, EventArgs e)
        {
            GetPrdata();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.TextLength > 3)
            {
                WMont.Year = int.Parse(txtYear.Text);
                WYear.Year = int.Parse(txtYear.Text);
                Wtrail.Year = int.Parse(txtYear.Text);
            }
            else
            {
                WMont.Year = 0;
                WYear.Year = 0;
                Wtrail.Year = 0;
            }
            FectID();
        }

        private void txtMont_TextChanged(object sender, EventArgs e)
        {
            if (txtMont.TextLength > 0)
            {
                int temp = int.Parse(txtMont.Text);
                if (temp < 13 && temp > 0)
                {
                    if (txtYear.TextLength > 3)
                    {
                        WMont.Month = temp;
                        Wtrail.Month = temp;
                    }
                    else
                    {
                        MessageBox.Show("ابتدا سال را به صورت صحیح وارد کنید");
                    }
                }
                else
                {
                    txtMont.Clear();
                }
            }
        }

        private void txtDayStart_TextChanged(object sender, EventArgs e)
        {
            if (txtDayStart.TextLength > 0)
            {
                int temp = int.Parse(txtDayStart.Text);
                if (temp < 32 && temp > 0)
                {
                    if (txtYear.TextLength > 3)
                    {
                        WMont.DayStart = temp;
                        Wtrail.DayStart = temp;
                    }
                    else
                    {
                        MessageBox.Show("ابتدا سال را به صورت صحیح وارد کنید");
                    }
                }
                else
                {
                    txtDayStart.Clear();
                }
            }
            else
            {
                WMont.DayStart = 0;
                Wtrail.DayStart = 0;
            }
            DayWork();
        }

        private void txtDayFinish_TextChanged(object sender, EventArgs e)
        {
            if (txtDayFinish.TextLength > 0)
            {
                int temp = int.Parse(txtDayFinish.Text);
                if (temp < 32 && temp > 0)
                {
                    if (txtYear.TextLength > 3)
                    {
                        WMont.DayFinish = temp;
                        Wtrail.DayFinish = temp;
                    }
                    else
                    {
                        MessageBox.Show("ابتدا سال را به صورت صحیح وارد کنید");
                    }
                }
                else
                {
                    txtDayFinish.Clear();
                }
            }
            else
            {
                WMont.DayFinish = 0;
                Wtrail.DayFinish = 0;
            }
            DayWork();
        }

        private void txtClosingNotWork_TextChanged(object sender, EventArgs e)
        {
            if (txtClosingNotWork.TextLength > 0)
            {
                WMont.ClosingNotWork = int.Parse(txtClosingNotWork.Text);
            }
            else
            {
                WMont.ClosingNotWork = 0;
            }
            DayWork();
        }

        private void txtClosingAll_TextChanged(object sender, EventArgs e)
        {
            if (txtClosingAll.TextLength > 0)
            {
                WMont.ClosingAll = int.Parse(txtClosingAll.Text);
            }
            else
            {
                WMont.ClosingAll = 0;
            }
        }

        private void txtMachineNum_TextChanged(object sender, EventArgs e)
        {
            if (txtMachineNum.TextLength > 0)
            {
                int temp = int.Parse(txtMachineNum.Text);
                if (temp > 0)
                {
                    if (txtYear.TextLength > 3)
                    {
                        WMont.MachineNum = temp;
                        Wtrail.MachineNum = temp;
                    }
                }
            }
        }

        private void comboTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            WMont.TemplateNum = comboTemplate.SelectedIndex + 1;
            Wtrail.TemplateNum = comboTemplate.SelectedIndex + 1;
            getData();
        }

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.TextLength > 0)
            {
                WMont.Description = WYear.Description = Wtrail.Description = txtDescription.Text;
            }
            else
            {
                WMont.Description = WYear.Description = Wtrail.Description = "ندارد";
            }
        }

        private void txtPartNum_TextChanged(object sender, EventArgs e)
        {
            if (txtPartNum.TextLength > 0)
            {
                WYear.PartNum = int.Parse(txtPartNum.Text);
            }
            else
            {
                WYear.PartNum = 0;
            }
        }

        private void txtCycleTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCycleTime.TextLength == 0)
                {
                    WMont.CycleTime = 0;
                    CalcTotalPart();
                    return;
                }
                WMont.CycleTime = Convert.ToDecimal(txtCycleTime.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtCycleTime.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCycleTime.Focus();
                }
            }
            CalcTotalPart();
        }

        private void txtActiveKavite_TextChanged(object sender, EventArgs e)
        {
            if (txtActiveKavite.TextLength > 0)
            {
                if (int.Parse(txtActiveKavite.Text) > kaviteh && Kind == "M")
                {
                    txtActiveKavite.Text = kaviteh.ToString();
                    return;
                }
                else
                {
                    WMont.ActiveKavite = int.Parse(txtActiveKavite.Text);
                }
            }
            else
            {
                WMont.ActiveKavite = 0;
            }
            CalcTotalPart();
        }

        private void txtAloans_TextChanged(object sender, EventArgs e)
        {
            if (txtAloans.TextLength > 0)
            {
                WMont.Aloans = int.Parse(txtAloans.Text);
            }
            else
            {
                WMont.Aloans = 0;
            }
            CalcTotalPart();
        }

        private void txtMinPrDay_TextChanged(object sender, EventArgs e)
        {
            if (txtMinPrDay.TextLength > 0)
            {
                WMont.MinPrDay = int.Parse(txtMinPrDay.Text);
            }
            else
            {
                WMont.MinPrDay = 0;
            }
            if (Kind == "GR" && txtDayWoked.Text != "")
            {
                txtMinAllWorkorder.Text = (int.Parse(txtDayWoked.Text) * WMont.MinPrDay).ToString();
            }
        }

        private void txtMinAllWorkorder_TextChanged(object sender, EventArgs e)
        {
            if (txtMinAllWorkorder.TextLength > 0)
            {
                WMont.MinAllWorkorder = int.Parse(txtMinAllWorkorder.Text);
            }
            else
            {
                WMont.MinAllWorkorder = 0;
            }
        }

        private void txtApplicant_TextChanged(object sender, EventArgs e)
        {
            if (txtApplicant.TextLength > 0)
            {
                Wtrail.Applicant = int.Parse(txtApplicant.Text);
            }
            else
            {
                Wtrail.Applicant = 0;
            }
        }

        private void txtRequestNum_TextChanged(object sender, EventArgs e)
        {
            if (txtRequestNum.TextLength > 0)
            {
                Wtrail.RequestNum = int.Parse(txtRequestNum.Text);
            }
            else
            {
                Wtrail.RequestNum = 0;
            }
        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {

            if (checkData())
            {
                LINQDataContext DataBase = new LINQDataContext();
                string Mes = "";
                if (radioMont.Checked)
                {
                    WMont.Description = "ندارد";
                    DataBase.WorkOrderMonths.InsertOnSubmit(WMont);
                    if (Fastcod.kind == "G")
                    {
                        WorkOrderConfirmation tmp = new WorkOrderConfirmation();
                        tmp.ID = WMont.ID;
                        tmp.Year = WMont.Year;
                        tmp.OP1Code = 0;
                        tmp.OP1Condition = true;
                        tmp.OP2Code = 0;
                        tmp.OP2Condition = true;
                        tmp.OP3Code = 12012;
                        tmp.OP3Condition = false;
                        tmp.OP4Code = 12010;
                        tmp.OP4Condition = false;
                        DataBase.WorkOrderConfirmations.InsertOnSubmit(tmp);
                    }
                    else
                    {
                        WorkOrderConfirmation tmp = new WorkOrderConfirmation();
                        tmp.ID = WMont.ID;
                        tmp.Year = WMont.Year;
                        tmp.OP1Code = 12038;
                        tmp.OP1Condition = false;
                        tmp.OP2Code = 12036;
                        tmp.OP2Condition = false;
                        tmp.OP3Code = 12063;
                        tmp.OP3Condition = false;
                        tmp.OP4Code = 12010;
                        tmp.OP4Condition = false;
                        DataBase.WorkOrderConfirmations.InsertOnSubmit(tmp);
                    }
                    Mes = "N-" + WMont.ID;
                }
                else
                {
                    if (radioTrail.Checked)
                    {
                        Wtrail.Description = "ندارد";
                        DataBase.WorkOrderTrails.InsertOnSubmit(Wtrail);
                        Mes = "E-" + Wtrail.ID;
                    }
                    else
                    {
                        if (radioYear.Checked)
                        {
                            WYear.Description = "ندارد";
                            DataBase.WorkOrderYears.InsertOnSubmit(WYear);
                            Mes = "P-" + WYear.ID;
                        }
                    }
                }
                try
                {
                    DataBase.SubmitChanges();
                    MessageBox.Show("دستور کار جدید صادر گردید.\n" + Mes, "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    ClearForm();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("اطلاعات به دلیل" + ex.Message + "ثبت نشد لطفا با پشتیبان نرم افزار تماس بگیرید");
                }
                // ClearForm();
            }
        }

        private bool checkData()
        {
            if (WMont.Year < 1398)
            {
                MessageBox.Show("اطلاعات مربوط به سال صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtYear.Focus();
                return false;
            }

            if (fastCode == 0)
            {
                MessageBox.Show("اطلاعات کالا به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtFastCode.Focus();
                return false;
            }

            if (radioMont.Checked)
            {
                if (WMont.Month == 0)
                {
                    MessageBox.Show("اطلاعات مربوط به ماه صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMont.Focus();
                    return false;
                }
                if (WMont.DayStart == 0)
                {
                    MessageBox.Show("اطلاعات مربوط به روز شروع صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtDayStart.Focus();
                    return false;
                }
                if (WMont.ClosingAll < WMont.ClosingNotWork)
                {
                    MessageBox.Show("تعداد روزهای تعطیل کاری نمی تواند بیشتر از \nتعداد روزهای تعطیل کاری باشد که در آن کار نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtDayStart.Focus();
                    return false;
                }
                if (WMont.DayFinish == 0)
                {
                    MessageBox.Show("اطلاعات مربوط به روز پایان صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtDayFinish.Focus();
                    return false;
                }
                if (WMont.MachineNum == 0)
                {
                    MessageBox.Show("اطلاعات مربوط به شماره ماشین صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMachineNum.Focus();
                    return false;
                }
                if (Kind != "GR")
                {
                    if (WMont.CycleTime == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به سایکل تایم صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtCycleTime.Focus();
                        return false;
                    }
                    if (WMont.ActiveKavite == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به کویته فعال صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtActiveKavite.Focus();
                        return false;
                    }
                    if (WMont.Aloans == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به الونس صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtAloans.Focus();
                        return false;
                    }
                }
                if (WMont.MinPrDay == 0)
                {
                    MessageBox.Show("اطلاعات مربوط به حداقل مورد نیاز روز صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMinPrDay.Focus();
                    return false;
                }
                if (WMont.MinAllWorkorder == 0)
                {
                    MessageBox.Show("اطلاعات مربوط به حداقل مورد نیاز کل دستور صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMinAllWorkorder.Focus();
                    return false;
                }

                LINQDataContext DB = new LINQDataContext();
                var tmp = from s in DB.WorkOrderMonths
                          where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month && s.TemplateNum == WMont.TemplateNum &&
                          ((WMont.DayStart >= s.DayStart && WMont.DayStart <= s.DayFinish) ||
                          (WMont.DayFinish >= s.DayStart && WMont.DayFinish <= s.DayFinish) ||
                           (WMont.DayStart <= s.DayStart && WMont.DayFinish >= s.DayFinish))
                          select s;
                if (tmp.Count() > 0)
                {
                    MessageBox.Show("قالب در این شماره دستورکار با شماره دستورکار " + tmp.First().ID + " تداخل زمانی دارد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (MessageBox.Show("آیا از ثبت دستور کار فوق طمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        txtMinAllWorkorder.Focus();
                        return false;
                    }
                }
                var tmp2 = from s in DB.WorkOrderMonths
                           where s.MachineNum == WMont.MachineNum && s.Year == WMont.Year && s.Month == WMont.Month &&
                           ((WMont.DayStart >= s.DayStart && WMont.DayStart <= s.DayFinish) ||
                           (WMont.DayFinish >= s.DayStart && WMont.DayFinish <= s.DayFinish) ||
                            (WMont.DayStart <= s.DayStart && WMont.DayFinish >= s.DayFinish))
                           select s;
                if (tmp2.Count() > 0)
                {
                    MessageBox.Show("ماشین در این شماره دستورکار با شماره دستورکار " + tmp2.First().ID + " تداخل زمانی دارد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    if (MessageBox.Show("آیا از ثبت دستور کار فوق طمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.No)
                    {
                        txtMinAllWorkorder.Focus();
                        return false;
                    }
                }

            }
            else
            {
                if (radioTrail.Checked)
                {
                    if (Wtrail.Month == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به ماه صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMont.Focus();
                        return false;
                    }
                    if (Wtrail.DayStart == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به روز شروع صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtDayStart.Focus();
                        return false;
                    }
                    if (Wtrail.DayFinish == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به روز پایان صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtDayFinish.Focus();
                        return false;
                    }
                    if (Wtrail.MachineNum == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به شماره ماشین صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMachineNum.Focus();
                        return false;
                    }
                    if (Wtrail.Applicant == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به درخواست کننده صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtApplicant.Focus();
                        return false;
                    }
                    if (Wtrail.RequestNum == 0)
                    {
                        MessageBox.Show("اطلاعات مربوط به شماره درخواست صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtRequestNum.Focus();
                        return false;
                    }
                    LINQDataContext DB = new LINQDataContext();
                    var tmp = from s in DB.WorkOrderTrails
                              where s.ProdectionCode == Wtrail.ProdectionCode && s.Year == Wtrail.Year && s.Month == Wtrail.Month && s.TemplateNum == Wtrail.TemplateNum &&
                              s.RequestNum == Wtrail.RequestNum &&
                              ((Wtrail.DayStart >= s.DayStart && Wtrail.DayStart <= s.DayFinish) ||
                          (Wtrail.DayFinish >= s.DayStart && Wtrail.DayFinish <= s.DayFinish) ||
                           (Wtrail.DayStart <= s.DayStart && Wtrail.DayFinish >= s.DayFinish))
                              select s;
                    if (tmp.Count() > 0)
                    {
                        MessageBox.Show("این شماره دستورکار با شماره دستور کار " + tmp.First().ID + " تداخل زمانی دارد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMinAllWorkorder.Focus();
                        return false;
                    }

                }
                else
                {

                    if (radioYear.Checked)
                    {
                        if (WYear.PartNum == 0)
                        {
                            MessageBox.Show("اطلاعات مربوط به تعداد مورد نیاز سالانه صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtRequestNum.Focus();
                            return false;
                        }
                    }
                    LINQDataContext DB = new LINQDataContext();
                    var tmp = from s in DB.WorkOrderYears
                              where s.ProdectionCode == WYear.ProdectionCode && s.Year == WYear.Year
                              select s;
                    if (tmp.Count() > 0)
                    {
                        MessageBox.Show("این شماره دستورکار با شماره دستورکار \n P-" + tmp.First().ID + "\n قبلا ثبت شده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop, MessageBoxDefaultButton.Button1, MessageBoxOptions.RightAlign);
                        txtMinAllWorkorder.Focus();
                        return false;
                    }
                }
            }

            return true;

        }

        private void txtDayWoked_TextChanged(object sender, EventArgs e)
        {
            CalcTotalPart();
        }

        private void CalcTotalPart()
        {
            if (txtDayWoked.TextLength < 1)
                return;
            int dayWork = int.Parse(txtDayWoked.Text);
            if (dayWork > 0 && WMont.CycleTime > 0 && WMont.ActiveKavite > 0)
            {
                long PartMin = 0;
                long PartMinAll = 0;
                PartMin = Convert.ToInt64((((24 * 3600) * WMont.ActiveKavite) / Convert.ToDouble(WMont.CycleTime)) * (1 - (Convert.ToDouble(WMont.Aloans) / 100)));
                PartMinAll = dayWork * PartMin;


                txtMinPrDay.Text = PartMin.ToString();
                txtMinAllWorkorder.Text = PartMinAll.ToString();
            }
            else
            {
                txtMinPrDay.Text = "0";
                txtMinAllWorkorder.Text = "0";
            }
        }

        private void btnTableView_Click(object sender, EventArgs e)
        {
            frmWorkOrderTable frm = new frmWorkOrderTable();
            frm.ShowDialog();
            FectID();
        }

        private void getData()
        {

            if (fastCode > 0)
            {
                #region Mont And Trail
                if (radioMont.Checked || radioTrail.Checked)
                {

                    LINQDataContext DataBase = new LINQDataContext();

                    var FillDefult = from s in DataBase.WorkOrderMonths
                                     where s.ProdectionCode == WMont.ProdectionCode && s.TemplateNum == WMont.TemplateNum
                                     select s;
                    if (FillDefult.Count() > 0)
                    {
                        txtMachineNum.Text = FillDefult.SingleOrDefault(x => x.uid == FillDefult.Max(ss => ss.uid)).MachineNum.ToString();
                        txtCycleTime.Text = FillDefult.SingleOrDefault(x => x.uid == FillDefult.Max(ss => ss.uid)).CycleTime.ToString();
                        txtActiveKavite.Text = FillDefult.SingleOrDefault(x => x.uid == FillDefult.Max(ss => ss.uid)).ActiveKavite.ToString();
                        txtAloans.Text = FillDefult.SingleOrDefault(x => x.uid == FillDefult.Max(ss => ss.uid)).Aloans.ToString();
                    }
                    else
                    {
                        txtMachineNum.Clear();
                        txtCycleTime.Clear();
                        txtActiveKavite.Clear();
                        txtAloans.Clear();
                    }

                    #region Production
                    if (Kind == "PR")
                    {

                        var Pdata = from s in DataBase.ProductionDatas
                                    where s.ProdectionCode == WMont.ProdectionCode && s.TemplateNum == WMont.TemplateNum
                                    select s;
                        if (Pdata.Count() > 0)
                        {
                            txtMinCycleTime.Text = Pdata.Min(x => x.CycleTime).ToString();
                            txtavgCycleTime.Text = Pdata.Average(x => x.CycleTime).ToString("#.##");
                            var PdataLast = Pdata.SingleOrDefault(x => x.IDPR == Pdata.Max(ss => ss.IDPR));

                            if (PdataLast != null)
                            {
                                txtlasCycleTime.Text = PdataLast.CycleTime.ToString();
                                txtLastActivekavite.Text = PdataLast.ActiveKaviteh.ToString();
                                kaviteh = PdataLast.Kaviteh;
                            }

                        }
                        else
                        {
                            txtMinCycleTime.Text = "0";
                            txtavgCycleTime.Text = "0";
                            txtlasCycleTime.Text = "0";
                            txtLastActivekavite.Text = "0";
                        }


                        var AllPart = from s in DataBase.ProductionDatas
                                      where s.ProdectionCode == WMont.ProdectionCode
                                      select s;
                        if (AllPart.Count() > 0)
                            txtprNow.Text = AllPart.Sum(x => x.PartNum).ToString();
                        else
                            txtprNow.Text = "0";


                        var AllSalon = from s in DataBase.BalanceAlls
                                       where s.ProdectionCode == WMont.ProdectionCode
                                       select s;
                        if (AllSalon.Count() > 0)
                            txtSalon.Text = AllSalon.Sum(x => x.PRSalon).ToString();
                        else
                            txtSalon.Text = "0";


                        var AllPartYear = from s in DataBase.WorkOrderYears
                                          where s.ProdectionCode == WMont.ProdectionCode
                                          select s;
                        if (AllPartYear.Count() > 0)
                            txtpartOfYear.Text = AllPartYear.Sum(x => x.PartNum).ToString();
                        else
                            txtpartOfYear.Text = "0";



                        txtAllAloans.Text = (Convert.ToDouble(txtprNow.Text) / Convert.ToDouble(txtpartOfYear.Text) * 100).ToString("#.##") + "  %";



                        var LastWorkOrder = (from s in DataBase.WorkOrderMonths
                                             where s.ProdectionCode == WMont.ProdectionCode && s.Month == (WMont.Month - 1) && s.TemplateNum == WMont.TemplateNum
                                             orderby s.Year, s.Month, s.DayFinish descending
                                             select s).FirstOrDefault();

                        if (LastWorkOrder != null)
                        {
                            var partInWorkOrder = from s in DataBase.ProductionDatas
                                                  where s.ProdectionCode == WMont.ProdectionCode && s.Month == LastWorkOrder.Month && s.TemplateNum == LastWorkOrder.TemplateNum &&
                                                  (s.Day >= LastWorkOrder.DayStart && s.Day <= LastWorkOrder.DayFinish)
                                                  select s.PartNum;
                            if (partInWorkOrder.Count() > 0)
                                txtPerMonthAloans.Text = (Convert.ToDouble(partInWorkOrder.Sum(x => x) / Convert.ToDouble(LastWorkOrder.MinAllWorkorder)) * 100).ToString("#.##") + " %";
                            else
                                txtPerMonthAloans.Text = "0 %";
                        }
                        else
                            txtPerMonthAloans.Text = "0 %";

                        return;

                    }
                    #endregion

                    #region Granule

                    if (Kind == "GR")
                    {

                        var Data = from s in DataBase.GranuleDatas
                                   where s.ProdectionCode == WMont.ProdectionCode
                                   select s;
                        if (Data.Count() > 0)
                        {
                            txtprNow.Text = Data.Sum(x => x.PartNum).ToString("n0") + " KG";

                            txtMinCycleTime.Text = Data.Min(x => (x.PartNum + x.ControlNum + x.WastageNum) / 43200).ToString("0.###");
                            txtavgCycleTime.Text = Data.Average(x => (x.PartNum + x.ControlNum + x.WastageNum) / 43200).ToString("0.###");
                            var PdataLast = Data.SingleOrDefault(x => x.ID == Data.Max(ss => ss.ID));

                            if (PdataLast != null)
                            {
                                txtlasCycleTime.Text = ((PdataLast.PartNum + PdataLast.ControlNum + PdataLast.WastageNum) / 43200).ToString("0.###");
                                txtLastActivekavite.Text = "----";
                            }

                        }
                        else
                        {
                            txtMinCycleTime.Text = "----";
                            txtavgCycleTime.Text = "----";
                            txtlasCycleTime.Text = "----";
                            txtLastActivekavite.Text = "----";
                        }


                        var partSalon = from s in DataBase.BalanceAlls
                                        where s.ProdectionCode == WMont.ProdectionCode && s.TemplateNum == WMont.TemplateNum
                                        select s;
                        if (partSalon.Count() > 0)
                            txtSalon.Text = partSalon.Sum(x => x.PRSalon).ToString() + "  KG";
                        else
                            txtSalon.Text = "----";



                        var AllPartYear = from s in DataBase.WorkOrderYears
                                          where s.ProdectionCode == WMont.ProdectionCode
                                          select s;

                        if (AllPartYear.Count() > 0)
                            txtpartOfYear.Text = AllPartYear.Sum(x => x.PartNum).ToString() + "  KG";
                        else
                            txtpartOfYear.Text = "0";

                        if (txtprNow.TextLength > 0)
                            txtAllAloans.Text = (Convert.ToDouble((txtprNow.Text.Replace(" KG", ""))) / Convert.ToDouble(txtpartOfYear.Text.Replace(" KG", "")) * 100).ToString("#.##") + "  %";
                        else
                            txtAllAloans.Text = "----";

                        var LastWorkOrder = (from s in DataBase.WorkOrderMonths
                                             where s.ProdectionCode == WMont.ProdectionCode && s.Month == (WMont.Month - 1) && s.TemplateNum == WMont.TemplateNum
                                             orderby s.Year, s.Month, s.DayFinish descending
                                             select s).FirstOrDefault();

                        if (LastWorkOrder != null)
                        {
                            var partInWorkOrder = from s in DataBase.GranuleDatas
                                                  where s.ProdectionCode == WMont.ProdectionCode && s.Month == LastWorkOrder.Month && 
                                                  (s.Day >= LastWorkOrder.DayStart && s.Day <= LastWorkOrder.DayFinish)
                                                  select s.PartNum;
                            if (partInWorkOrder.Count() > 0)
                                txtPerMonthAloans.Text = (Convert.ToDouble(Convert.ToDouble(partInWorkOrder.Sum(x => x)) / Convert.ToDouble(LastWorkOrder.MinAllWorkorder)) * 100).ToString("#.##") + " %";
                            else
                                txtPerMonthAloans.Text = "0 %";
                        }
                        else
                            txtPerMonthAloans.Text = "0 %";






                        return;
                    }
                    #endregion

                    #region Assembly
                    if (Kind == "AS")
                    {
                        var data = from s in DataBase.AssemblyDatas
                                   where s.ProdectionCode == WMont.ProdectionCode
                                   select s;
                        if (data.Count() > 0)
                        {
                            txtprNow.Text = data.Sum(x => x.PartNum).ToString();
                            txtMinCycleTime.Text = data.Min(x => Convert.ToDouble(x.TimeTolid * 60) / (x.PartNum + x.ControlNum + x.WastageNum)).ToString("#.###");
                            txtavgCycleTime.Text = data.Average(x => Convert.ToDouble(x.TimeTolid * 60) / (x.PartNum + x.ControlNum + x.WastageNum)).ToString("#.###");
                            var tmp4 = data.SingleOrDefault(x => x.ID == data.Max(ss => ss.ID - 1));

                            if (tmp4 != null)
                            {
                                txtlasCycleTime.Text = (Convert.ToDouble(tmp4.TimeTolid * 60) / (tmp4.PartNum + tmp4.ControlNum + tmp4.WastageNum)).ToString("#.###");
                                txtLastActivekavite.Text = (from s in DataBase.AssemblyDatas where s.ProdectionCode == WMont.ProdectionCode && s.LotNum == tmp4.LotNum select s).Count().ToString();
                            }

                        }
                        else
                        {
                            txtprNow.Text = "0";
                            txtMinCycleTime.Text = "0";
                            txtavgCycleTime.Text = "0";
                            txtlasCycleTime.Text = "0";
                            txtLastActivekavite.Text = "0";
                        }

                        var AllSalon = from s in DataBase.BalanceAlls
                                       where s.ProdectionCode == WMont.ProdectionCode
                                       select s;
                        if (AllSalon.Count() > 0)
                            txtSalon.Text = AllSalon.Sum(x => x.PRSalon).ToString();
                        else
                            txtSalon.Text = "0";

                        var AllPartYear = from s in DataBase.WorkOrderYears
                                          where s.ProdectionCode == WMont.ProdectionCode
                                          select s;

                        if (AllPartYear.Count() > 0)
                            txtpartOfYear.Text = AllPartYear.Sum(x => x.PartNum).ToString();
                        else
                            txtpartOfYear.Text = "0";

                        txtAllAloans.Text = (Convert.ToDouble(txtprNow.Text) / Convert.ToDouble(txtpartOfYear.Text) * 100).ToString("#.##") + "  %";

                        var LastWorkOrder = (from s in DataBase.WorkOrderMonths
                                             where s.ProdectionCode == WMont.ProdectionCode && s.Month == (WMont.Month - 1) && s.TemplateNum == WMont.TemplateNum
                                             orderby s.Year, s.Month, s.DayFinish descending
                                             select s).FirstOrDefault();

                        if (LastWorkOrder != null)
                        {
                            var partInWorkOrder = from s in DataBase.AssemblyDatas
                                                  where s.ProdectionCode == WMont.ProdectionCode && s.Month == LastWorkOrder.Month &&
                                                  (s.Day >= LastWorkOrder.DayStart && s.Day <= LastWorkOrder.DayFinish)
                                                  select s.PartNum;
                            if (partInWorkOrder.Count() > 0)
                                txtPerMonthAloans.Text = (Convert.ToDouble(partInWorkOrder.Sum(x => x) / Convert.ToDouble(LastWorkOrder.MinAllWorkorder)) * 100).ToString("#.##") + " %";
                            else
                                txtPerMonthAloans.Text = "0 %";
                        }
                        else
                            txtPerMonthAloans.Text = "0 %";




                        return;
                    }
                    #endregion

                }
                #endregion

                #region Year

                if (radioYear.Checked)
                {

                    txtprNow.Clear();
                    txtMinCycleTime.Clear();
                    txtavgCycleTime.Clear();
                    txtlasCycleTime.Clear();
                    txtLastActivekavite.Clear();
                    txtSalon.Clear();
                    txtpartOfYear.Clear();
                }

                #endregion
                /*
                #region Trail
                else
                {
                    LINQDataContext DataBase = new LINQDataContext();
                    var a = (from s in DataBase.QuickSelects
                             where s.Product_Code == WYear.ProdectionCode
                             select new
                             {
                                 mmp = s.kind
                             }.mmp).First();
                    if (a == "M")
                    {
                        var tmp1 = from s in DataBase.ProductionDatas
                                   where s.ProdectionCode == WYear.ProdectionCode
                                   select s;
                        if (tmp1.Count() > 0)
                        {
                            txtprNow.Text = tmp1.Sum(x => x.PartNum).ToString();
                            txtMinCycleTime.Text = tmp1.Min(x => x.CycleTime).ToString();
                            txtavgCycleTime.Text = tmp1.Average(x => x.CycleTime).ToString("#.##");
                            var tmp4 = tmp1.SingleOrDefault(x => x.IDPR == tmp1.Max(ss => ss.IDPR));

                            if (tmp4 != null)
                            {
                                txtlasCycleTime.Text = tmp4.CycleTime.ToString();
                                txtLastActivekavite.Text = tmp4.ActiveKaviteh.ToString();
                                kaviteh = tmp4.Kaviteh;
                            }

                        }
                        else
                            txtprNow.Text = "0";

                        var tmp2 = from s in DataBase.tblBalanceShits
                                   where s.ProdectionCode == WYear.ProdectionCode
                                   select s;
                        if (tmp2.Count() > 0)
                            txtSalon.Text = tmp2.Sum(x => x.Salon).ToString();
                        else
                            txtSalon.Text = "0";

                        var tmp3 = from s in DataBase.WorkOrderYears
                                   where s.ProdectionCode == WYear.ProdectionCode
                                   select s;

                        if (tmp3.Count() > 0)
                            txtpartOfYear.Text = tmp3.Sum(x => x.PartNum).ToString();
                        else
                            txtpartOfYear.Text = "0";



                        return;
                    }
                    if (a == "G")
                    {

                        return;
                    }
                    if (a == "A")
                    {

                        return;
                    }

                }
                #endregion
*/
            }
            else
            {
                txtprNow.Clear();
                txtMinCycleTime.Clear();
                txtavgCycleTime.Clear();
                txtlasCycleTime.Clear();
                txtLastActivekavite.Clear();
                kaviteh = 0;
                txtSalon.Clear();
                txtpartOfYear.Clear();

            }
        }

    }
}

