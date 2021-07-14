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
    public partial class frmInsertPR : Form
    {
        DataAccess Data = new DataAccess();
        Tools tools;
        ProductionData PData = new ProductionData();
        tblDescription Desc = new tblDescription();

        public frmInsertPR()
        {
            InitializeComponent();
        }
        private void frmInsertPR_Load(object sender, EventArgs e)
        {
            PData.OperatorOrderCode = DataAccess.User.PCode;
            PData.OperatorOrderName = DataAccess.User.PName;
            lblCodePersonel.Text = DataAccess.User.PCode.ToString();
            lblNamePersonel.Text = DataAccess.User.PName;
            CurrentId = Data.CurrentID("ProductionData");
            PData.IDPR = CurrentId;
            lblIDNum.Text = CurrentId.ToString();
           
        }
        private void frmInsertPR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeed)
            {
                return;
            }
            if (DialogResult.No == MessageBox.Show("اطلاعات", "آیا مایل به خروج از صفحه ورود اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {

                e.Cancel = true;
            }
        }

        #region Class And Button
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            textClear();
        }
        
        private void textClear()
        {
            //
            //Date Clear
            //
            txtDay.Clear();
            txtMonth.Clear();
            txtYear.Text = "1399";
            comboShift.SelectedIndex = -1;
            lblWeek.Text = lblBatch.Text = lblLot.Text = "";
            CheckDate = false;
            //
            //Data1 Clear
            //
            txtmachineNum.Clear();
            txtWorkOrderNum.Clear();
            txtCodeFast.Clear();
            lblProdectCode.Text = lblProdectName.Text = "";
            txttemplateNume.Clear();
            lblKaviteh.Text = "";
            //
            //Amar Clear
            //
            TypeOfTolid.SelectedIndex = -1;
            txtvalidNum.Clear();
            txtTimeTolid.Clear();
            txtUnderControl.Clear();
            txtlosses.Clear();
            txtRahandazi.Clear();
            txtRahgah.Clear();
            txtRahgah.Clear();
            txtKoloukhe.Clear();
            //
            //Data2 Clear
            //
            txtKaviteh.Clear();
            txtCycleTime.Clear();
            txtOperatorCode.Clear();
            lblOperatorName.Text = "";
            txtSeriSakht.Clear();
            txtICC.Clear();
            //
            //Stop Clear
            //
            txtcode1.Clear();
            txtcode2.Clear();
            txtcode3.Clear();
            txtcode4.Clear();
            txtcode5.Clear();
            lblcode1.Text = lblcode2.Text = lblcode3.Text = lblcode4.Text = lblcode5.Text = "";
            txtcodewidth1.Clear();
            txtcodewidth2.Clear();
            txtcodewidth3.Clear();
            txtcodewidth4.Clear();
            txtcodewidth5.Clear();
            txtcodewidthTotal.Text = "";
            txtcode2.Enabled = txtcode3.Enabled = txtcode4.Enabled = txtcode5.Enabled = false;
            txtcodewidth1.Enabled = txtcodewidth2.Enabled = txtcodewidth3.Enabled = txtcodewidth4.Enabled = txtcodewidth5.Enabled = false;
            //
            //Description Clear
            //
            txtDescription.Clear();
            txtDay.Focus();
            PData = new ProductionData();

            PData.OperatorOrderCode = DataAccess.User.PCode;
            PData.OperatorOrderName = DataAccess.User.PName;
            lblCodePersonel.Text = DataAccess.User.PCode.ToString();
            lblNamePersonel.Text = DataAccess.User.PName;
            CurrentId = Data.CurrentID("ProductionData");
            PData.IDPR = CurrentId;
            lblIDNum.Text = CurrentId.ToString();
            
            Data = new DataAccess();
            Desc = new tblDescription();
            Desc.IDPR = PData.IDPR;
            ID = 0;
            kavite = false;

        }
        private void CheckTolid()
        {
            if (lblProdectName.Text.Length > 0)
                if (lblLot.Text.Length > 0)
                    if (txttemplateNume.Text.Length > 0)
                    {
                        string Shart;
                        if (PData.TypeOfTolid > 0)
                        {
                            Shart = "ProdectionCode={0} AND LotNum={1} AND TemplateNum={2} AND TypeOfTolid={3}";
                            Shart = string.Format(Shart, PData.ProdectionCode, PData.LotNum, PData.TemplateNum, PData.TypeOfTolid);
                        }
                        else
                        {
                            Shart = "ProdectionCode={0} AND LotNum={1} AND TemplateNum={2}";
                            Shart = string.Format(Shart, PData.ProdectionCode, PData.LotNum, PData.TemplateNum);
                        }
                        string sql = Data.SelectOneCol2Where("ProductionData", Shart, "TypeOFTolid");
                        string sql2 = Data.SelectOneCol2Where("ProductionData", Shart, "TimeTolid");

                        if (sql != "False")
                        {
                            txtTimeTolid.Enabled = false;
                            PData.TimeTolid = 720 - Convert.ToInt32(sql2.Trim());
                            txtTimeTolid.Text = PData.TimeTolid.ToString();
                            TypeOfTolid.Enabled = false;
                            if (sql == "1")
                            {
                                TypeOfTolid.SelectedIndex = 1;
                            }
                            else
                            {
                                TypeOfTolid.SelectedIndex = 0;

                            }
                            txtvalidNum.Focus();
                        }
                        else
                        {
                            //در صورت مشکل اینجا رو تغییر بده
                            txtTimeTolid.Text = "720";
                            PData.TimeTolid = 720;
                            txtTimeTolid.Enabled = true;
                            if (TypeOfTolid.SelectedIndex == 0)
                                PData.TypeOfTolid = 1;
                            TypeOfTolid.SelectedIndex = 0;
                            TypeOfTolid.Enabled = true;
                        }
                    }

        }
        private bool Save()
        {
            if (CheckAll())
            {
                PData.IDPR = Data.CurrentID("ProductionData");
                PData.stock = false;
                var db = new LINQDataContext();
                PData.Time = Tools.GetTimeNow();
                db.ProductionDatas.InsertOnSubmit(PData);
                db.tblDescriptions.InsertOnSubmit(Desc);

                if (txtcode1.Text.Length > 0 && txtcodewidth1.Text.Length > 0)
                {
                    Stop st = new Stop
                    {
                        IDProtection = PData.IDPR,
                        StopID = Convert.ToInt16(txtcode1.Text),
                        StopTime = Convert.ToDouble(txtcodewidth1.Text),
                        See = false
                    };
                    db.Stops.InsertOnSubmit(st);
                }
                if (txtcode2.Text.Length > 0 && txtcodewidth2.Text.Length > 0)
                {
                    Stop st = new Stop
                    {
                        IDProtection = PData.IDPR,
                        StopID = Convert.ToInt16(txtcode2.Text),
                        StopTime = Convert.ToDouble(txtcodewidth2.Text),
                        See = false
                    };
                    db.Stops.InsertOnSubmit(st);
                }
                if (txtcode3.Text.Length > 0 && txtcodewidth3.Text.Length > 0)
                {
                    Stop st = new Stop
                    {
                        IDProtection = PData.IDPR,
                        StopID = Convert.ToInt16(txtcode3.Text),
                        StopTime = Convert.ToDouble(txtcodewidth3.Text),
                        See = false
                    };
                    db.Stops.InsertOnSubmit(st);
                }
                if (txtcode4.Text.Length > 0 && txtcodewidth4.Text.Length > 0)
                {
                    Stop st = new Stop
                    {
                        IDProtection = PData.IDPR,
                        StopID = Convert.ToInt16(txtcode4.Text),
                        StopTime = Convert.ToDouble(txtcodewidth4.Text),
                        See = false
                    };
                    db.Stops.InsertOnSubmit(st);
                }
                if (txtcode5.Text.Length > 0 && txtcodewidth5.Text.Length > 0)
                {
                    Stop st = new Stop
                    {
                        IDProtection = PData.IDPR,
                        StopID = Convert.ToInt16(txtcode5.Text),
                        StopTime = Convert.ToDouble(txtcodewidth5.Text),
                        See = false
                    };
                    db.Stops.InsertOnSubmit(st);
                }
                try
                {
                    db.SubmitChanges();
                    //BalanceShit();
                    return true;
                }
                catch (Exception ex)
                {
                    string s = ex.Message;
                    return false;
                }

            }
            else
            {
                return false;
            }
        }
        /*
        private void BalanceShit()
        {
            LINQDataContext DataBase = new LINQDataContext();
            var dt = from u in DataBase.tblBalanceShits
                     where u.LotNum == PData.LotNum && u.ProdectionCode == PData.ProdectionCode && u.TemplateNum == PData.TemplateNum
                     select u;
            int aaaa = dt.Count();
            if (dt.Count() == 1)
            {
                tblBalanceShit tmp1 = (tblBalanceShit)dt.First();
                tmp1.Salon += PData.PartNum;
                tmp1.Control += PData.ControlNum;
                if (PData.PartNum > 0)
                {
                    tblMSalon sal = new tblMSalon();
                    sal.LotNum = PData.LotNum;
                    sal.ProdectionCode = PData.ProdectionCode;
                    sal.ProdectionName = PData.ProdectionName;
                    sal.TemplateNum = PData.TemplateNum;
                    sal.Decrease = 0;
                    sal.Increase = PData.PartNum;
                    sal.Location = "ProductionData";
                    sal.LocationID = PData.IDPR;
                    DataBase.tblMSalons.InsertOnSubmit(sal);
                }
                if (PData.ControlNum > 0)
                {
                    tblMControl ctrl = new tblMControl();
                    ctrl.LotNum = PData.LotNum;
                    ctrl.ProdectionCode = PData.ProdectionCode;
                    ctrl.ProdectionName = PData.ProdectionName;
                    ctrl.TemplateNum = PData.TemplateNum;
                    ctrl.Increase = PData.ControlNum;
                    ctrl.Location = "ProductionData";
                    ctrl.LocationID = PData.IDPR;
                    DataBase.tblMControls.InsertOnSubmit(ctrl);
                }

                ProductionData tmp = (from ss in DataBase.ProductionDatas
                                      where ss.IDPR == PData.IDPR
                                      select ss).FirstOrDefault();
                tmp.stock = true;

                DataBase.SubmitChanges();
            }
            else
            {
                if (PData.PartNum > 0 || PData.ControlNum > 0)
                {
                    tblBalanceShit bal = new tblBalanceShit();
                    bal.LotNum = PData.LotNum;
                    bal.ProdectionCode = PData.ProdectionCode;
                    bal.ProdectionName = PData.ProdectionName;
                    bal.TemplateNum = PData.TemplateNum;
                    bal.Salon = PData.PartNum;
                    bal.Anbar = 0;
                    bal.Control = PData.ControlNum;
                    DataBase.tblBalanceShits.InsertOnSubmit(bal);
                    if (PData.PartNum > 0)
                    {
                        tblMSalon sal = new tblMSalon();
                        sal.LotNum = PData.LotNum;
                        sal.ProdectionCode = PData.ProdectionCode;
                        sal.ProdectionName = PData.ProdectionName;
                        sal.TemplateNum = PData.TemplateNum;
                        sal.Increase = PData.PartNum;
                        sal.Location = "ProductionData";
                        sal.LocationID = PData.IDPR;
                        DataBase.tblMSalons.InsertOnSubmit(sal);
                    }
                    if (PData.ControlNum > 0)
                    {
                        tblMControl ctrl = new tblMControl();
                        ctrl.LotNum = PData.LotNum;
                        ctrl.ProdectionCode = PData.ProdectionCode;
                        ctrl.ProdectionName = PData.ProdectionName;
                        ctrl.TemplateNum = PData.TemplateNum;
                        ctrl.Increase = PData.ControlNum;
                        ctrl.Location = "ProductionData";
                        ctrl.LocationID = PData.IDPR;
                        DataBase.tblMControls.InsertOnSubmit(ctrl);
                    }
                }

                ProductionData tmp = (from ss in DataBase.ProductionDatas
                                      where ss.IDPR == PData.IDPR
                                      select ss).FirstOrDefault();
                tmp.stock = true;

                DataBase.SubmitChanges();
            }
        }
         */

        private string CheckDuplicate()
        {
            string Temp = "Ready";
            string Shart = "ProdectionCode={0} AND LotNum={1} AND TemplateNum={2} AND TypeOfTolid={3}";
            Shart = string.Format(Shart, PData.ProdectionCode, PData.LotNum, PData.TemplateNum, PData.TypeOfTolid);
            string sql = Data.SelectOneCol2Where("ProductionData", Shart, "ID");
            if (sql == "False")
                Temp = "Ready";
            else
                Temp = sql;

            return Temp;
        }
        private bool CheckWorkOrder()
        {
            bool rr = false;
            LINQDataContext db = new LINQDataContext();
            var tmp = from s in db.WorkOrderMonths
                      where s.ProdectionCode == PData.ProdectionCode && s.TemplateNum == PData.TemplateNum &&
                      s.Year == PData.Year && s.Month == PData.Month && (s.DayStart <= PData.Day && s.DayFinish >= PData.Day)
                      select s;
            switch (tmp.Count())
            {
                case 0:
                    MessageBox.Show("برای این ماشین و محصول دستور کاری صادر نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    if (tmp.SingleOrDefault().Confirmation)
                        rr = true;
                    else
                        MessageBox.Show("دستور کار صادر شده تایید نشده است ", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("برای این شماره ماشین و محصول " + tmp.Count() + " دستور کار صادر شده و نمیتوان فرم را ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            return rr;
        }
        private bool CheckAll()
        {
            try
            {
                if (CheckDate)
                {
                    if (!Utility.CreateTime(PData.Year, PData.Month, PData.Day))
                    {

                        if (CheckData())
                        {
                            if (CheckAmar())
                            {
                                if (CheckStop())
                                {
                                    if (txtDescription.Text.Length > 0)
                                    {
                                        if (CheckDuplicate() == "Ready")
                                        {
                                            if (CheckRah())
                                            {
                                                if (CheckWorkOrder())
                                                {
                                                    return true;
                                                }
                                                else
                                                {
                                                    return false;
                                                }
                                            }
                                            else
                                            {
                                                MessageBox.Show("در صورت ققط ثبت توقف روتین نمیتوان ضایعات راه اندازی ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                                return false;
                                            }
                                        }
                                        else
                                        {
                                            MessageBox.Show("این فرم با مشخصات بالا قبلا ثبت شده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            return false;
                                        }
                                    }
                                    else
                                    {
                                        MessageBox.Show("اطلاعات مربوط به توضیحات توقف ماشین به صورت کامل وارد نشده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        return false;
                                    }

                                }
                                else
                                {
                                    MessageBox.Show("اطلاعات مربوط به اطلاعات توقف به صورت کامل وارد نشده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    return false;
                                }
                            }
                            else
                            {
                                MessageBox.Show("اطلاعات مربوط به اطلاعات آماری به صورت کامل وارد نشده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                return false;
                            }
                        }
                        else
                        {
                            MessageBox.Show("اطلاعات مربوط به اطلاعات اولیه و تکمیلی به صورت کامل وارد نشده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return false;
                        }

                    }
                    else
                    {
                        MessageBox.Show("اطلاعات وارد شده خارج از بازه زمانی مجاز برای ثبت اطلاعات است /n لطفا تاریخ وارد شده را بررسی نمایید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("اطلاعات مربوط به تاریخ به صورت کامل وارد نشده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("برنامه را ببنید و مجددا باز کنید");
                return false;
            }
        }
        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ثبت اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (Save())
                {
                    MessageBox.Show("فرم شماره " + PData.IDPR.ToString() + " با موفقیت ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    closeed = true;
                    textClear();
                    this.Close();
                }
            }
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ثبت اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (Save())
                {
                    MessageBox.Show("فرم شماره " + PData.IDPR.ToString() + " با موفقیت ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textClear();
                }
            }
        }

        #endregion

        #region TextKeyPress
        private void TextKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void WidthChek(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 46)
            {
                return;
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Date
        bool CheckDate;

        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (txtDay.Text == "")
            {
                return;
            }
            int test = Convert.ToInt16(txtDay.Text);

            if (test > 31 || test < 1)
            {
                txtDay.Clear();
                return;
            }
            FillDate();
        }
        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text == "")
            {
                return;
            }
            int test = Convert.ToInt16(txtMonth.Text);

            if (test > 12 || test < 1)
            {
                txtMonth.Clear();
                return;
            }
            FillDate();
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (txtYear.Text.Length < 4)
            {
                return;
            }
            if (Convert.ToInt16(txtYear.Text) < 1398 || Convert.ToInt16(txtYear.Text) > 1599)
            {
                txtYear.Text = "1399";
            }
            FillDate();
        }
        private void comboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboShift.SelectedIndex >= 0)
            {
                FillDate();
            }
        }
        private void FillDate()
        {
            if (txtDay.Text.Length > 0 && txtMonth.Text.Length > 0 && txtYear.Text.Length > 0 && comboShift.SelectedIndex >= 0)
            {
                tools = new Tools(txtYear.Text, txtMonth.Text, txtDay.Text, comboShift.SelectedIndex);
                PData.Day = Convert.ToInt16(txtDay.Text);
                PData.Month = Convert.ToInt16(txtMonth.Text);
                PData.Year = Convert.ToInt16(txtYear.Text);
                PData.Shift = tools.Shift;

                PData.WeekNum = Convert.ToInt16(tools.WeekNum);
                PData.BatchNum = Convert.ToInt16(tools.BatchNum);
                PData.LotNum = Convert.ToInt32(tools.LotNum);

                lblWeek.Text = PData.WeekNum.ToString();
                lblBatch.Text = PData.BatchNum.ToString();
                lblLot.Text = PData.LotNum.ToString();
                CheckDate = true;
            }
            else
            {
                CheckDate = false;
            }
        }

        private void lblLot_TextChanged(object sender, EventArgs e)
        {
            CheckTolid();
        }


        #endregion

        #region Data
        bool kavite;
        bool CheckFastCode;
        int ID;
        private int CurrentId;
        private bool closeed;

        private bool CheckData()
        {
            bool temp = true;
            if (txtmachineNum.Text.Trim() == "") { temp = false; }
            if (txtWorkOrderNum.Text.Trim() == "") { temp = false; }
            if (lblProdectCode.Text.Trim() == "") { temp = false; }
            if (txttemplateNume.Text.Trim() == "") { temp = false; }
            if (txtKaviteh.Text.Trim() == "") { temp = false; }
            if (txtCycleTime.Text.Trim() == "") { temp = false; }
            if (txtOperatorCode.Text.Trim() == "") { temp = false; }
            if (txtSeriSakht.Text.Trim() == "") { temp = false; }
            if (txtICC.Text.Trim() == "") { temp = false; }
            return temp;
        }
        private void txtmachineNum_Leave(object sender, EventArgs e)
        {
            if (txtmachineNum.Text.Length > 0)
                PData.MachineNum = Convert.ToInt16(txtmachineNum.Text);
        }
        private void txtWorkOrderNum_Leave(object sender, EventArgs e)
        {
            if (txtWorkOrderNum.Text.Length > 0)
            {
                PData.WorkOrder = Convert.ToInt16(txtWorkOrderNum.Text);
            }
        }
        private void btnFastcodeview_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.Shart = "M";
            frm.ShowDialog();
            if (frm.Clicked)
            {
                FillProdection(frm.codefast);
            }
        }
        private void FillProdection(string FastCode)
        {
            try
            {

                FastCode.Trim();
                txtCodeFast.Text = FastCode;

                string sql = "select * from QuickSelect where CodeFast={0}";
                sql = string.Format(sql, FastCode);
                DataTable DT = Data.Select(sql);

                if (DT.Rows.Count == 1)
                {
                    PData.FastCode = Convert.ToInt16(FastCode);
                    PData.ProdectionCode = lblProdectCode.Text = DT.Rows[0]["Product_Code"].ToString();
                    PData.ProdectionName = lblProdectName.Text = DT.Rows[0]["Product_Name"].ToString();
                    ID = Convert.ToInt16(DT.Rows[0]["ID"]);
                }
                else
                {
                    if (DT.Rows.Count > 1)
                    {
                        MessageBox.Show("خطا", "برای کد بیشتر از یک کالا تعریف شده است.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("خطا", "این کد فعلا تعریف نشده است", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    txtCodeFast.Clear();
                    PData.FastCode = 0;
                    PData.ProdectionCode = lblProdectCode.Text = "";
                    PData.ProdectionName = lblProdectName.Text = "";
                    lblKaviteh.Text = "";
                    txttemplateNume.Clear();
                    PData.TemplateNum = 0;
                    PData.Kaviteh = 0;
                    txtCodeFast.Focus();
                    return;
                }
                if (PData.FastCode == 999)
                {
                    if (PData.MachineNum > 0 && PData.LotNum > 0)
                    {
                        if (MessageBox.Show("آیا مایل به توقف کامل دستگاه با کد 999 هستید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                        {
                            return;
                        }
                        string sql2 = Data.SelectOneCol2Where("ProductionData", "LotNum=" + PData.LotNum + " and MachineNum=" + PData.MachineNum, "IDPR");
                        if (sql2 == "False")
                        {
                            PData.GranuleSeries = "0";
                            PData.OperatorCode = 1;
                            PData.OperatorName = "بدون کاربر";
                            PData.TimeTolid = 0;
                            PData.WastageStart = 0;
                            if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ثبت اطلاعات ماشین به صورت بدون قالب و برنامه هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                            {

                                PData.IDPR = Data.CurrentID("ProductionData");
                                var db = new LINQDataContext();
                                PData.Time = Tools.GetTimeNow();
                                db.ProductionDatas.InsertOnSubmit(PData);
                                Desc.IDPR = PData.IDPR;
                                Desc.Description = "بدون قالب و بدون برنامه";
                                db.tblDescriptions.InsertOnSubmit(Desc);

                                Stop st = new Stop
                                {
                                    IDProtection = PData.IDPR,
                                    StopID = 98,
                                    StopTime = 720,
                                    See = false
                                };

                                db.Stops.InsertOnSubmit(st);
                                bool sav = false;
                                string s = "";
                                try
                                {
                                    db.SubmitChanges();
                                    sav = true;
                                }
                                catch (Exception ex)
                                {
                                    s = ex.Message;
                                    sav = false;
                                }


                                if (sav)
                                {
                                    MessageBox.Show("فرم شماره " + PData.IDPR.ToString() + " با موفقیت ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textClear();
                                }
                                else
                                {
                                    MessageBox.Show("به دلیل " + s + " ثبت نشد ", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    textClear();
                                }
                            }
                        }
                    }
                    else
                    {
                        MessageBox.Show("در صورت وارد نکردن تاریخ و شماره ماشین نمیتوان آن را ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        textClear();
                    }
                    return;
                }


                sql = "select * from Mold where IDProtection={0}";
                sql = string.Format(sql, ID);
                DT = Data.Select(sql);
                lblKaviteh.Text = "";
                txttemplateNume.Clear();
                PData.TemplateNum = 0;
                PData.Kaviteh = 0;

                if (DT.Rows.Count == 0)
                {
                    kavite = true;
                    lblKaviteh.Text = "0";
                    txttemplateNume.Text = "0";
                    txtKaviteh.Text = "0";
                    TypeOfTolid.Focus();
                    return;

                }
                if (DT.Rows.Count == 1)
                {
                    int i = Convert.ToInt16(DT.Rows[0]["MoldNum"]);
                    PData.TemplateNum = i;
                    txttemplateNume.Text = i.ToString();
                    i = Convert.ToInt16(DT.Rows[0]["Quetta"]);
                    PData.Kaviteh = i;
                    lblKaviteh.Text = i.ToString();
                    txttemplateNume.Enabled = false;
                    TypeOfTolid.Focus();
                    txtKaviteh.Clear();
                }
                else
                {
                    kavite = false;
                    txttemplateNume.Enabled = true;
                    txttemplateNume.Clear();
                    txttemplateNume.Focus();
                    txtKaviteh.Clear();
                }
            }
            catch (Exception ex)
            {
                string Messege = ex.Message;
                MessageBox.Show("داده های شما به دلیل \n " + Messege + "\n ثبت نشده ");
            }

        }
        private void txtCodeFast_TextChanged(object sender, EventArgs e)
        {
            CheckFastCode = false;
        }
        private void txtCodeFast_Leave(object sender, EventArgs e)
        {
            if (txtCodeFast.Text.Trim() != "" && !CheckFastCode)
            {
                CheckFastCode = true;
                FillProdection(txtCodeFast.Text);
            }
        }
        private void txttemplateNume_TextChanged(object sender, EventArgs e)
        {
            if (txttemplateNume.Text == "" || kavite == true)
                return;

            if (Convert.ToInt16(txttemplateNume.Text) < 1)
                return;
            PData.TypeOfTolid = 0;


            string sql = "select * from Mold where IDProtection={0} And MoldNum={1}";
            sql = string.Format(sql, ID, txttemplateNume.Text);
            DataTable DT = Data.Select(sql);

            if (DT.Rows.Count == 1)
            {
                int i = Convert.ToInt16(DT.Rows[0]["Quetta"]);
                PData.TemplateNum = Convert.ToInt16(txttemplateNume.Text);
                PData.Kaviteh = i;
                lblKaviteh.Text = i.ToString();
                TypeOfTolid.Focus();
            }
            else
            {
                MessageBox.Show("خطا", "این شماره قالب وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txttemplateNume.Clear();
                txttemplateNume.Focus();
                PData.TemplateNum = 0;
                PData.Kaviteh = 0;
            }
        }
        private void txtKaviteh_Leave(object sender, EventArgs e)
        {
            if (txtKaviteh.Text.Length > 0)
            {

                PData.ActiveKaviteh = Convert.ToInt16(txtKaviteh.Text);
                if (PData.ActiveKaviteh > PData.Kaviteh)
                {
                    PData.ActiveKaviteh = PData.Kaviteh;
                    txtKaviteh.Text = PData.ActiveKaviteh.ToString();
                }
            }
        }
        private void txtCycleTime_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtCycleTime.Text == "")
                    return;

                PData.CycleTime = (float)Convert.ToDouble(txtCycleTime.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtCycleTime.Clear();
                    MessageBox.Show("مقدار صحیح را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtCycleTime.Focus();
                }
            }
        }
        private void txtCycleTime_Leave(object sender, EventArgs e)
        {
            if (txtCycleTime.Text != "")
            {
                PData.CycleTime = Convert.ToDouble(txtCycleTime.Text);
            }
        }
        private void txtOperatorCode_Leave(object sender, EventArgs e)
        {
            if (txtOperatorCode.TextLength == 5)
            {
                string sql = "select * from PersonalList where PersonalCode='{0}'";
                sql = string.Format(sql, txtOperatorCode.Text);
                DataTable DT = Data.Select(sql);
                if (DT.Rows.Count > 0)
                {
                    PData.OperatorName = lblOperatorName.Text = DT.Rows[0]["PersonalName"].ToString();
                    PData.OperatorCode = Convert.ToInt32(txtOperatorCode.Text);
                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOperatorCode.Clear();
                    lblOperatorName.Text = "";
                    PData.OperatorCode = 0;
                    PData.OperatorName = "";
                    return;
                }

            }
        }
        private void txtSeriSakht_Leave(object sender, EventArgs e)
        {
            PData.GranuleSeries = txtSeriSakht.Text;
        }
        private void txtICC_Leave(object sender, EventArgs e)
        {
            if (txtICC.Text != "")
            {
                PData.ICCNum = Convert.ToInt32(txtICC.Text);
            }
        }
        private void lblProdectName_TextChanged(object sender, EventArgs e)
        {
            CheckTolid();
        }


        #endregion

        #region Amar
        private bool CheckAmar()
        {
            bool temp = true;
            if (txtTimeTolid.Text.Trim() == "") { temp = false; }
            if (txtvalidNum.Text.Trim() == "") { temp = false; }
            if (txtUnderControl.Text.Trim() == "") { temp = false; }
            if (txtlosses.Text.Trim() == "") { temp = false; }
            if (txtRahandazi.Text.Trim() == "") { temp = false; }
            if (txtRahgah.Text.Trim() == "") { temp = false; }
            if (txtKoloukhe.Text.Trim() == "") { temp = false; }
            return temp;
        }
        private void TypeOfTolid_SelectedIndexChanged(object sender, EventArgs e)
        {
            PData.TypeOfTolid = (int)(TypeOfTolid.SelectedIndex + 1);
        }
        private void txtTimeTolid_Leave(object sender, EventArgs e)
        {
            if (txtTimeTolid.Text.Length > 0)
            {
                PData.TimeTolid = Convert.ToInt32(txtTimeTolid.Text);
            }
        }
        private void txtvalidNum_Leave(object sender, EventArgs e)
        {
            if (txtvalidNum.Text.Length > 0)
            {
                PData.PartNum = Convert.ToInt32(txtvalidNum.Text);
            }

        }
        private void txtUnderControl_Leave(object sender, EventArgs e)
        {
            if (txtUnderControl.Text.Length > 0)
            {
                PData.ControlNum = Convert.ToInt32(txtUnderControl.Text);
            }
        }
        private void txtlosses_Leave(object sender, EventArgs e)
        {
            if (txtlosses.Text.Length > 0)
            {
                PData.WastageNum = Convert.ToInt32(txtlosses.Text);
            }
        }
        private void txtRahandazi_Leave(object sender, EventArgs e)
        {
            if (txtRahandazi.Text.Length > 0)
            {
                PData.WastageStart = Convert.ToInt32(txtRahandazi.Text);
            }
        }
        private void txtRahgah_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtRahgah.Text == "")
                    return;

                PData.VaznRahgah = (float)Math.Round(Convert.ToDouble(txtRahgah.Text), 2);
                if (PData.VaznRahgah > 200)
                {
                    PData.VaznRahgah = 200;
                    txtRahgah.Text = "200";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtRahgah.Clear();
                    MessageBox.Show("مقدار صحیح را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtRahgah.Focus();
                }
            }
        }
        private void txtKoloukhe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtKoloukhe.Text == "")
                    return;

                PData.VaznKoloukheh = (float)Math.Round(Convert.ToDouble(txtKoloukhe.Text), 2);
                if (PData.VaznKoloukheh > 50)
                {
                    PData.VaznKoloukheh = 50;
                    txtKoloukhe.Text = "50";
                }
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtKoloukhe.Clear();
                    MessageBox.Show("مقدار صحیح را وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKoloukhe.Focus();
                }
            }
        }

        #endregion

        #region Stop
        private double TotalTime()
        {
            double Temp = 0;
            try
            {
                if (txtcodewidth1.Text != "")
                    Temp += Convert.ToDouble(txtcodewidth1.Text);
                if (txtcodewidth2.Text != "")
                    Temp += Convert.ToDouble(txtcodewidth2.Text);
                if (txtcodewidth3.Text != "")
                    Temp += Convert.ToDouble(txtcodewidth3.Text);
                if (txtcodewidth4.Text != "")
                    Temp += Convert.ToDouble(txtcodewidth4.Text);
                if (txtcodewidth5.Text != "")
                    Temp += Convert.ToDouble(txtcodewidth5.Text);
            }
            catch (Exception)
            {
                Temp = -1;
                MessageBox.Show("لطفا مقدار را به صورت صحیح وارد کنید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            return Temp;
        }
        private bool CheckStopDuplicate()
        {
            String[] Temp = { txtcode1.Text, txtcode2.Text, txtcode3.Text, txtcode4.Text, txtcode5.Text };
            for (int i = 0; i < 5; i++)
            {
                for (int j = i + 1; j < 5; j++)
                {
                    if (Temp[i] != "" && Temp[i] == Temp[j])
                    {
                        return true;
                    }
                }
            }
            return false;
        }
        private void txtcode1_TextChanged(object sender, EventArgs e)
        {
            if (txtcode1.Text.Length > 0)
                txtcodewidth1.Enabled = true;
            else
            {
                txtcodewidth1.Enabled = false;
                lblcode1.Text = "";
            }
        }
        private void txtcode2_TextChanged(object sender, EventArgs e)
        {
            if (txtcode2.Text.Length > 0)
                txtcodewidth2.Enabled = true;
            else
            {
                txtcodewidth2.Enabled = false;
                lblcode2.Text = "";
            }
        }
        private void txtcode3_TextChanged(object sender, EventArgs e)
        {
            if (txtcode3.Text.Length > 0)
                txtcodewidth3.Enabled = true;
            else
            {
                txtcodewidth3.Enabled = false;
                lblcode3.Text = "";
            }
        }
        private void txtcode4_TextChanged(object sender, EventArgs e)
        {
            if (txtcode4.Text.Length > 0)
                txtcodewidth4.Enabled = true;
            else
            {
                txtcodewidth4.Enabled = false;
                lblcode4.Text = "";
            }
        }
        private void txtcode5_TextChanged(object sender, EventArgs e)
        {
            if (txtcode5.Text.Length > 0)
                txtcodewidth5.Enabled = true;
            else
            {
                txtcodewidth5.Enabled = false;
                lblcode5.Text = "";
            }
        }
        private void txtcodewidth1_TextChanged(object sender, EventArgs e)
        {
            txtcodewidthTotal.Text = TotalTime().ToString();
            if (txtcodewidth1.Text.Length > 0 && txtcodewidthTotal.Text != "-1")
                txtcode2.Enabled = true;
            else
            {
                txtcode2.Enabled = false;
                txtcodewidth1.Clear();
            }
        }
        private void txtcodewidth2_TextChanged(object sender, EventArgs e)
        {
            txtcodewidthTotal.Text = TotalTime().ToString();
            if (txtcodewidth2.Text.Length > 0 && txtcodewidthTotal.Text != "-1")
                txtcode3.Enabled = true;
            else
            {
                txtcode3.Enabled = false;
                txtcodewidth2.Clear();
            }
        }
        private void txtcodewidth3_TextChanged(object sender, EventArgs e)
        {
            txtcodewidthTotal.Text = TotalTime().ToString();
            if (txtcodewidth3.Text.Length > 0 && txtcodewidthTotal.Text != "-1")
                txtcode4.Enabled = true;
            else
            {
                txtcode4.Enabled = false;
                txtcodewidth3.Clear();
            }
        }
        private void txtcodewidth4_TextChanged(object sender, EventArgs e)
        {
            txtcodewidthTotal.Text = TotalTime().ToString();
            if (txtcodewidth4.Text.Length > 0 && txtcodewidthTotal.Text != "-1")
                txtcode5.Enabled = true;
            else
            {
                txtcode5.Enabled = false;
                txtcodewidth4.Clear();
            }
        }
        private void txtcodewidth5_TextChanged(object sender, EventArgs e)
        {
            txtcodewidthTotal.Text = TotalTime().ToString();
            if (!(txtcodewidth5.Text.Length > 0 && txtcodewidthTotal.Text != "-1"))
            {
                txtcodewidth5.Clear();
            }
        }
        private void txtcode1_Leave(object sender, EventArgs e)
        {
            if (txtcode1.Text == "14")
                if (txtDescription.Text.Length == 0)
                    txtDescription.Text = "14-سرویس قالب انجام شد.\n" + txtDescription.Text;

            if (CheckStopDuplicate())
            {
                MessageBox.Show("این کد قبلا وارد شده است");
                txtcode1.Clear();
            }
            if (txtcode1.Text != "")
            {
                string dt = Data.SelectOneCol("StopType", "StopID", txtcode1.Text, "Title");
                if (dt == "False" || Convert.ToInt32(txtcode1.Text) < 10)
                {
                    txtcode1.Clear();
                    lblcode1.Text = "";
                    txtcode1.Focus();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }

                lblcode1.Text = dt;
            }
        }
        private void txtcode2_Leave(object sender, EventArgs e)
        {
            if (CheckStopDuplicate())
            {
                MessageBox.Show("این کد قبلا وارد شده است");
                txtcode2.Clear();
            }
            if (txtcode2.Text != "")
            {
                string dt = Data.SelectOneCol("StopType", "StopID", txtcode2.Text, "Title");
                if (dt == "False" || Convert.ToInt32(txtcode2.Text) < 10)
                {
                    txtcode2.Clear();
                    lblcode2.Text = "";
                    txtcode2.Focus();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }

                lblcode2.Text = dt;
            }
        }
        private void txtcode3_Leave(object sender, EventArgs e)
        {
            if (CheckStopDuplicate())
            {
                MessageBox.Show("این کد قبلا وارد شده است");
                txtcode3.Clear();
            }
            if (txtcode3.Text != "")
            {
                string dt = Data.SelectOneCol("StopType", "StopID", txtcode3.Text, "Title");
                if (dt == "False" || Convert.ToInt32(txtcode3.Text) < 10)
                {
                    txtcode3.Clear();
                    lblcode3.Text = "";
                    txtcode3.Focus();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }

                lblcode3.Text = dt;
            }
        }
        private void txtcode4_Leave(object sender, EventArgs e)
        {
            if (txtcode4.Text != "")
            {
                if (CheckStopDuplicate())
                {
                    MessageBox.Show("این کد قبلا وارد شده است");
                    txtcode4.Clear();
                }
                string dt = Data.SelectOneCol("StopType", "StopID", txtcode4.Text, "Title");
                if (dt == "False" || Convert.ToInt32(txtcode4.Text) < 10)
                {
                    txtcode4.Clear();
                    lblcode4.Text = "";
                    txtcode4.Focus();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }

                lblcode4.Text = dt;
            }
        }
        private void txtcode5_Leave(object sender, EventArgs e)
        {
            if (CheckStopDuplicate())
            {
                MessageBox.Show("این کد قبلا وارد شده است");
                txtcode5.Clear();
            }
            if (txtcode5.Text != "")
            {
                string dt = Data.SelectOneCol("StopType", "StopID", txtcode5.Text, "Title");
                if (dt == "False" || Convert.ToInt32(txtcode5.Text) < 10)
                {
                    txtcode5.Clear();
                    lblcode5.Text = "";
                    txtcode5.Focus();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }

                lblcode5.Text = dt;
            }
        }
        private bool CheckRah()
        {
            if (PData.WastageStart > 0)
                if (txtcode1.Text == "14" && txtcode2.Text == "" && txtcode2.Text == "" && txtcode2.Text == "" && txtcode2.Text == "")
                    return false;
                else
                    return true;
            else
                return true;
        }
        private bool CheckStop()
        {
            bool Temp;
            if (txtcode5.Text.Length > 0 && txtcodewidth5.Text.Length > 0)
                Temp = true;
            else
                Temp = false;

            if (txtcode4.Text.Length > 0 && txtcodewidth4.Text.Length > 0)
                Temp = true;
            else
                Temp = false;

            if (txtcode3.Text.Length > 0 && txtcodewidth3.Text.Length > 0)
                Temp = true;
            else
                Temp = false;

            if (txtcode2.Text.Length > 0 && txtcodewidth2.Text.Length > 0)
                Temp = true;
            else
                Temp = false;

            if (txtcode1.Text.Length > 0 && txtcodewidth1.Text.Length > 0)
                Temp = true;
            else
                Temp = false;


            if (Temp)
            {
                if (Convert.ToDouble(txtcodewidthTotal.Text) > 0)
                {
                    PData.TimeTolid = Convert.ToInt16(txtTimeTolid.Text);
                    double TotalTime = Convert.ToDouble(txtcodewidthTotal.Text);
                    double Tedad = (double)PData.TimeTolid - TotalTime;
                    Tedad *= 60;
                    Tedad /= (double)PData.CycleTime;
                    Tedad *= (double)PData.ActiveKaviteh;
                    int TotalPR = (int)PData.PartNum + (int)PData.ControlNum + (int)PData.WastageNum + (int)PData.WastageStart;

                    if (TotalTime < PData.TimeTolid - 50)
                    {
                        if ((Tedad * 1.3) > TotalPR && TotalPR > (Tedad * 0.7))
                        {
                            Temp = true;
                        }
                        else
                        {
                            MessageBox.Show("تعداد کل تولید شما با توقف همخوانی ندارد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Temp = false;
                        }
                    }
                    else
                    {
                        if ((TotalPR * 1.1) >= Tedad)
                        {
                            Temp = true;
                        }
                        else
                        {
                            MessageBox.Show("تعداد کل تولید شما با توقف همخوانی ندارد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            Temp = false;
                        }
                    }

                }
                else
                {
                    MessageBox.Show("جمع زمان توفقات دستگاه نمیتواند کمتر از 1 دقیقه باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Temp = false;
                }
            }
            return Temp;
        }




        #endregion

        #region Description
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length <= 350)
            {
                lblLength.Text = (350 - txtDescription.Text.Length).ToString();
                if (txtDescription.TextLength > 0)
                {
                    Desc.Description = txtDescription.Text;
                    Desc.IDPR = PData.IDPR;
                }
                else
                {
                    Desc.Description = "";
                    Desc.IDPR = 0;
                }
            }

        }




        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            frmPersonal frm = new frmPersonal();
            frm.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            frmStopView frm = new frmStopView();
            frm.ShowDialog();
        }

        private void txttemplateNume_Leave(object sender, EventArgs e)
        {
            CheckTolid();
        }

        private void TypeOfTolid_Enter(object sender, EventArgs e)
        {
            CheckTolid();
        }

        private void txtvalidNum_Enter(object sender, EventArgs e)
        {
           
        }
    }
}
