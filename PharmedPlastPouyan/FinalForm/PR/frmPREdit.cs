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
    public partial class frmPREdit : Form
    {
        DataAccess Data = new DataAccess();
        ProductionData PData = new ProductionData();
        tblDescription Desc = new tblDescription();
        Stop st1 = new Stop();
        Stop st2 = new Stop();
        Stop st3 = new Stop();
        Stop st4 = new Stop();
        Stop st5 = new Stop();
        bool FirstRun;

        Tools tools;
        public int IDPR;
        public frmPREdit()
        {
            InitializeComponent();
            IDPR = 1;
        }
        private int StopCount = 0;
        LINQDataContext DataBase = new LINQDataContext();
        private void FillStop()
        {
            var ST = from u in DataBase.Stops
                     where u.IDProtection == IDPR
                     select u;


            StopCount = ST.Count();
            if (StopCount > 0 && StopCount < 6)
            {
                st1 = ST.First();
                txtcode1.Text = st1.StopID.ToString();
                txtcodewidth1.Text = st1.StopTime.ToString();
                lblcode1.Text = Data.SelectOneCol("StopType", "StopID", st1.StopID.ToString(), "Title");
            }
            if (StopCount > 1 && StopCount < 6)
            {
                st2 = ST.Skip(1).First();
                txtcode2.Text = st2.StopID.ToString();
                txtcodewidth2.Text = st2.StopTime.ToString();
                lblcode2.Text = Data.SelectOneCol("StopType", "StopID", st2.StopID.ToString(), "Title");
            }
            if (StopCount > 2 && StopCount < 6)
            {
                st3 = ST.Skip(2).First();
                txtcode3.Text = st3.StopID.ToString();
                txtcodewidth3.Text = st3.StopTime.ToString();
                lblcode3.Text = Data.SelectOneCol("StopType", "StopID", st3.StopID.ToString(), "Title");

            }
            if (StopCount > 3 && StopCount < 6)
            {
                st4 = ST.Skip(3).First();
                txtcode4.Text = st4.StopID.ToString();
                txtcodewidth4.Text = st4.StopTime.ToString();
                lblcode4.Text = Data.SelectOneCol("StopType", "StopID", st4.StopID.ToString(), "Title");

            }
            if (StopCount == 5)
            {
                st4 = ST.Skip(4).First();
                txtcode5.Text = st5.StopID.ToString();
                txtcodewidth5.Text = st5.StopTime.ToString();
                lblcode5.Text = Data.SelectOneCol("StopType", "StopID", st5.StopID.ToString(), "Title");
            }
        }
        private void FillAll()
        {
            lblIDNum.Text = IDPR.ToString();
            txtDay.Text = PData.Day.ToString();
            txtMonth.Text = PData.Month.ToString();
            txtYear.Text = PData.Year.ToString();
            comboShift.SelectedIndex = (int)PData.Shift - 1;
            lblWeek.Text = PData.WeekNum.ToString();
            lblLot.Text = PData.LotNum.ToString();
            lblBatch.Text = PData.BatchNum.ToString();
            txtmachineNum.Text = PData.MachineNum.ToString();
            txtWorkOrderNum.Text = PData.WorkOrder.ToString();
            txtCodeFast.Text = PData.FastCode.ToString();
            //txtCodeFast_Leave(null, null);
            lblProdectCode.Text = PData.ProdectionCode;
            lblProdectName.Text = PData.ProdectionName;
            txttemplateNume.Text = PData.TemplateNum.ToString();
            if (PData.TemplateNum > 1)
                txttemplateNume.Enabled = true;
            TypeOfTolid.SelectedIndex = (int)PData.TypeOfTolid - 1;
            txtvalidNum.Text = PData.PartNum.ToString();
            txtUnderControl.Text = PData.ControlNum.ToString();
            txtlosses.Text = PData.WastageNum.ToString();
            txtRahgah.Text = Math.Round(PData.VaznRahgah, 3).ToString();
            txtKoloukhe.Text = Math.Round(PData.VaznKoloukheh, 3).ToString();
            txtKaviteh.Text = PData.ActiveKaviteh.ToString();
            txtCycleTime.Text = PData.CycleTime.ToString();
            txtOperatorCode.Text = PData.OperatorCode.ToString();
            lblOperatorName.Text = PData.OperatorName;
            txtSeriSakht.Text = PData.GranuleSeries;
            lblKaviteh.Text = PData.Kaviteh.ToString();
            txtICC.Text = PData.ICCNum.ToString();
            txtTimeTolid.Text = PData.TimeTolid.ToString();
            txtRahandazi.Text = PData.WastageStart.ToString();
            lblNamePersonel.Text = PData.OperatorOrderName;
            lblCodePersonel.Text = PData.OperatorOrderCode.ToString();
            var desc = from u in DataBase.tblDescriptions
                       where u.IDPR == PData.IDPR
                       select u;
            if (desc.Count() > 0)
            {
                Desc = (tblDescription)(desc.First());
                txtDescription.Text = Desc.Description;
            }

        }
        private void Chart()
        {
            try
            {
                LINQDataContext db = new LINQDataContext();
                int ED_Create = int.Parse((from s in db.tblAdmins where s.Parameter == "ED-Create" select s.Value).SingleOrDefault());

                if ((bool)DataAccess.User.Admin)
                {
                    btnDelete.Enabled = btnDelete.Visible = btnSave.Enabled = btnSave.Visible = true;
                    return;
                }
                else
                {
                    if (DataAccess.User.PCode == PData.OperatorOrderCode)
                    {

                        DateTime s = DateTime.Today.AddHours(-ED_Create);
                        bool edittime = s <= PData.Time;
                        if (edittime)
                        {
                            btnDelete.Enabled = btnDelete.Visible = btnSave.Enabled = btnSave.Visible = true;
                            return;
                        }
                        else
                        {
                            btnDelete.Enabled = btnDelete.Visible = btnSave.Enabled = btnSave.Visible = false;
                            Closeed = true;
                            return;
                        }
                    }
                    else
                    {
                        Closeed = true;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                this.Close();
            }
        }
        private void frmInsertPR_Load(object sender, EventArgs e)
        {
            var dt = (from u in DataBase.ProductionDatas
                      where u.IDPR == IDPR
                      select u).FirstOrDefault();
            PData = (ProductionData)(dt);


            if (PData.IDPR == 0)
            {
                return;
            }
            FirstRun = true;
            FillAll();
            FillStop();
            FirstRun = false;
            Chart();

        }
        private void frmInsertPR_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Closeed)
            {
                return;
            }
            if (DialogResult.No == MessageBox.Show("اطلاعات", "آیا مایل به خروج از صفحه ورود اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {

                e.Cancel = true;
            }
        }

        #region Class And Button
        private void btnSave_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ویرایش اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (Save())
                {
                    MessageBox.Show("فرم شماره " + PData.IDPR.ToString() + " با موفقیت ویرایش شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Closeed = true;
                    this.Close();
                }
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
                            txtTimeTolid.Text = sql2;
                            PData.TimeTolid = 720 - Convert.ToInt32(sql2.Trim());
                            TypeOfTolid.SelectedIndex = Convert.ToInt16(sql);
                            txtvalidNum.Focus();
                        }
                        else
                        {
                            txtTimeTolid.Text = "720";
                            txtTimeTolid.Enabled = true;
                            TypeOfTolid.SelectedIndex = -1;
                            TypeOfTolid.Enabled = true;
                        }
                    }

        }
        private bool Save()
        {
            if (PData.FastCode == 999)
            {

                if (PData.MachineNum > 0 && PData.LotNum > 0)
                {
                    DataTable sql2 = Data.Select("ProductionData", "LotNum = " + PData.LotNum.ToString() + " and MachineNum = " + PData.MachineNum.ToString());
                    if (sql2.Rows.Count < 2)
                    {
                        if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ثبت اطلاعات ماشین به صورت بدون قالب و برنامه هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                        {
                            var dt = (from u in DataBase.ProductionDatas
                                      where u.IDPR == IDPR
                                      select u).FirstOrDefault();
                            PData = (ProductionData)(dt);

                            PData.Day = Convert.ToInt32(txtDay.Text);
                            PData.Month = Convert.ToInt32(txtMonth.Text);
                            PData.Year = Convert.ToInt32(txtYear.Text);
                            PData.Shift = comboShift.SelectedIndex + 1;
                            PData.WeekNum = Convert.ToInt32(lblWeek.Text);
                            PData.BatchNum = Convert.ToInt32(lblBatch.Text);
                            PData.LotNum = Convert.ToInt32(lblLot.Text);
                            PData.MachineNum = Convert.ToInt32(txtmachineNum.Text);
                            PData.Edited = true;
                            string tim = Tools.GetTimeNow().ToString();
                         
                            PData.LastIDEdit = Convert.ToInt32(Data.SelectOneCol2Where("Edit", "IDProduction=" + PData.IDPR + " and OperatorCode=" + DataAccess.User.PCode, "ID"));
                            bool sav = false;
                            string s = "";
                            try
                            {
                                DataBase.SubmitChanges();
                                sav = true;
                            }
                            catch (Exception ex)
                            {
                                s = ex.Message;
                                sav = false;
                            }


                            if (sav)
                            {
                                return true;
                            }
                            else
                            {
                                return false;
                            }
                        }
                    }
                }
            }

            if (CheckAll())
            {
                if (txtcode1.Text.Length > 0 && txtcodewidth1.Text.Length > 0)
                {
                    st1.StopID = Convert.ToInt16(txtcode1.Text);
                    st1.StopTime = Convert.ToDouble(txtcodewidth1.Text);
                    st1.See = false;
                    st1.IDProtection = PData.IDPR;
                    if (st1.ID == 0)
                        DataBase.Stops.InsertOnSubmit(st1);
                }
                else
                {
                    if (st1.ID > 0)
                    {
                        LINQDataContext db = new LINQDataContext();
                        db.Stops.DeleteOnSubmit((from s in db.Stops where s.ID == st1.ID select s).SingleOrDefault());
                        try { db.SubmitChanges(); }
                        catch (Exception) { }
                    }
                }
                if (txtcode2.Text.Length > 0 && txtcodewidth2.Text.Length > 0)
                {
                    st2.StopID = Convert.ToInt16(txtcode2.Text);
                    st2.StopTime = Convert.ToDouble(txtcodewidth2.Text);
                    st2.See = false;
                    st2.IDProtection = PData.IDPR;
                    if (st2.ID == 0)
                        DataBase.Stops.InsertOnSubmit(st2);
                }
                else
                {
                    if (st2.ID > 0)
                    {
                        LINQDataContext db = new LINQDataContext();
                        db.Stops.DeleteOnSubmit((from s in db.Stops where s.ID == st2.ID select s).SingleOrDefault());
                        try { db.SubmitChanges(); }
                        catch (Exception) { }
                    }
                }
                if (txtcode3.Text.Length > 0 && txtcodewidth3.Text.Length > 0)
                {
                    st3.StopID = Convert.ToInt16(txtcode3.Text);
                    st3.StopTime = Convert.ToDouble(txtcodewidth3.Text);
                    st3.See = false;
                    st3.IDProtection = PData.IDPR;
                    if (st3.ID == 0)
                        DataBase.Stops.InsertOnSubmit(st3);
                }
                else
                {
                    if (st3.ID > 0)
                    {
                        LINQDataContext db = new LINQDataContext();
                        db.Stops.DeleteOnSubmit((from s in db.Stops where s.ID == st3.ID select s).SingleOrDefault());
                        try { db.SubmitChanges(); }
                        catch (Exception) { }
                    }
                }
                if (txtcode4.Text.Length > 0 && txtcodewidth4.Text.Length > 0)
                {
                    st4.StopID = Convert.ToInt16(txtcode4.Text);
                    st4.StopTime = Convert.ToDouble(txtcodewidth4.Text);
                    st4.See = false;
                    st4.IDProtection = PData.IDPR;
                    if (st4.ID == 0)
                        DataBase.Stops.InsertOnSubmit(st4);
                }
                else
                {
                    if (st4.ID > 0)
                    {
                        LINQDataContext db = new LINQDataContext();
                        db.Stops.DeleteOnSubmit((from s in db.Stops where s.ID == st4.ID select s).SingleOrDefault());
                        try { db.SubmitChanges(); }
                        catch (Exception) { }
                    }
                }
                if (txtcode5.Text.Length > 0 && txtcodewidth5.Text.Length > 0)
                {
                    st5.StopID = Convert.ToInt16(txtcode5.Text);
                    st5.StopTime = Convert.ToDouble(txtcodewidth5.Text);
                    st5.See = false;
                    st5.IDProtection = PData.IDPR;
                    if (st5.ID == 0)
                        DataBase.Stops.InsertOnSubmit(st5);
                }
                else
                {
                    if (st5.ID > 0)
                    {
                        LINQDataContext db = new LINQDataContext();
                        db.Stops.DeleteOnSubmit((from s in db.Stops where s.ID == st5.ID select s).SingleOrDefault());
                        try { db.SubmitChanges(); }
                        catch (Exception) { }
                    }
                }
                try
                {
                    //BalanceShit();
                    DataBase.SubmitChanges();
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
            LINQDataContext db = new LINQDataContext();
            var tmp1 = (from s in db.ProductionDatas
                        where s.ID == PData.ID
                        select s).FirstOrDefault();
            if (tmp1 != null)
            {

                BalanceAll tmp2 = (from s in db.BalanceAlls
                                       where s.LotNum == tmp1.LotNum && s.ProdectionCode == tmp1.ProdectionCode && s.TemplateNum == tmp1.TemplateNum
                                       select s).FirstOrDefault();
                tmp2.ProdectionCode = PData.ProdectionCode;
                tmp2.ProdectionName = PData.ProdectionName;
                tmp2.LotNum = PData.LotNum;
                tmp2.TemplateNum = PData.TemplateNum;
                tmp2.PRSalon = PData.PartNum;
                tmp2.PRControl = PData.ControlNum;
                tmp2.Wastage = PData.WastageNum + PData.WastageStart.Value;

                try
                {
                    db.SubmitChanges();
                    return;
                }
                catch (Exception)
                {
                    return;
                }

            }
            return;
        }

         */
        private string CheckDuplicate()
        {
            string Temp = "Ready";
            string Shart = "ProdectionCode={0} AND LotNum={1} AND TemplateNum={2} AND TypeOfTolid={3}";
            Shart = string.Format(Shart, PData.ProdectionCode, PData.LotNum, PData.TemplateNum, PData.TypeOfTolid);
            string sql = Data.SelectOneCol2Where("ProductionData", Shart, "ID");
            //DataTable ddd = Data.Select("ProductionData", Shart);
            if (sql == "False")
                Temp = "Ready";
            else
                Temp = sql;

            return Temp;
        }
        private bool CheckAll()
        {
            try
            {
                LINQDataContext db = new LINQDataContext();

                if (CheckDate)
                {
                    if (CheckData())
                    {
                        if (CheckAmar())
                        {
                            if (CheckStop())
                            {
                                if (txtDescription.Text.Length > 0)
                                {
                                    string valid = CheckDuplicate().Trim();
                                    if (valid == PData.ID.ToString().Trim() || valid == "Ready")
                                    {
                                        if (CheckRah())
                                        {
                                            return true;
                                        }
                                        else
                                        {
                                            MessageBox.Show("برای اینکه ضایعات راه اندازی وارد شود \nحتما نوع توقف 15 یا توقف قالب و فنی اعمال شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
                    MessageBox.Show("اطلاعات مربوط به تاریخ به صورت کامل وارد نشده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }
            catch (Exception)
            {
                MessageBox.Show("ثبت انجام نشد اطلاعات را بررسی نمایید");
                return false;
            }
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        
        private void btnDelete_Click(object sender, EventArgs e)
        {
            try
            {
                MessageBox.Show("موقتا نمیتوان فرم های تولید  را حذف کرد");
                return;
                /*
                if (DialogResult.No == MessageBox.Show("اطلاعات", "آیا مایل به ویرایش اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                {
                    return;
                }
                int aa = 0;
                if (Data.Delete("ProductionData", "IDPR", PData.IDPR.ToString())) { aa++; }
                if (Data.Delete("Stop", "IDProtection", PData.IDPR.ToString())) { aa++; }
                if (Data.Delete("tblDescription", "IDPR", PData.IDPR.ToString())) { aa++; }
                Data.Delete("Edit", "IDProduction", PData.IDPR.ToString());

                Closeed = true;
                if (aa == 3)
                    MessageBox.Show("فرم شماره " + IDPR + " با موفقیت حذف شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
                */
            }
            catch (Exception)
            {
                MessageBox.Show("ثبت انجام نشد");
                return;
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
                PData.WeekNum = Convert.ToInt32(tools.WeekNum);
                PData.BatchNum = Convert.ToInt32(tools.BatchNum);
                PData.LotNum = Convert.ToInt32(tools.LotNum);
                lblWeek.Text = PData.WeekNum.ToString();
                lblBatch.Text = PData.BatchNum.ToString();
                lblLot.Text = PData.LotNum.ToString();







                CheckDate = true;
            }
            else
            {
                CheckDate = true;
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
        private bool Closeed;

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
                    pnlStop.TabIndex = 0;
                    pnlData.TabIndex = 10;
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
            if (FirstRun)
                return;

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
            if (FirstRun)
                return;
            if (txttemplateNume.Text == "" || kavite == true)
                return;

            if (Convert.ToInt16(txttemplateNume.Text) < 1)
                return;
            PData.TypeOfTolid = 0;
            CheckTolid();


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
            if (FirstRun)
                return;
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
            if (FirstRun)
                return;
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
            if (FirstRun)
                return;
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
            if (FirstRun)
                return;
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
            if (FirstRun)
                return;
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
            {
                txtDescription.Text = "قالب سرویس و گریسکاری شده است\n" + txtDescription.Text;
            }
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
                if (Convert.ToDouble(txtcodewidthTotal.Text) > 1)
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
                        if ((TotalPR * 1.1) >= Tedad || Tedad.ToString()=="NaN")
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
            }
        }
        private void txtDescription_Leave(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length > 0)
            {
                Desc.Description = txtDescription.Text;
            }

        }





        #endregion

        private void button2_Click(object sender, EventArgs e)
        {
            frmStopView frm = new frmStopView();
            frm.ShowDialog();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPersonal frm = new frmPersonal();
            frm.ShowDialog();
        }
    }
}
