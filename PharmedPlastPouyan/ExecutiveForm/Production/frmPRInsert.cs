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
    public partial class frmPRInsert : Form
    {
        Tools tools;
        ProductionData PData;
        LINQDataContext DataBase = new LINQDataContext();
        public frmPRInsert()
        {
            InitializeComponent();
        }

        #region Date
        bool CheckDate;
        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (txtDay.Text == "")
            {
                return;
            }
            int test = int.Parse(txtDay.Text);

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
            int test = int.Parse(txtMonth.Text);

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
            if (int.Parse(txtYear.Text) < 1398 || int.Parse(txtYear.Text) > 1599)
            {
                txtYear.Text = "1399";
            }
            FillDate();
        }
        private void chkShiftStatus_ValueChanged(object sender, EventArgs e)
        {
            FillDate();
        }
        private void FillDate()
        {
            if (txtDay.Text.Length > 0 && txtMonth.Text.Length > 0 && txtYear.Text.Length > 0)
            {
                int a = 0;
                if (chkShiftStatus.Value)
                    a = 0;
                else
                    a = 1;
                tools = new Tools(txtYear.Text, txtMonth.Text, txtDay.Text, a);
                PData.Day = int.Parse(txtDay.Text);
                PData.Month = int.Parse(txtMonth.Text);
                PData.Year = int.Parse(txtYear.Text);
                PData.Shift = tools.Shift;

                PData.WeekNum = int.Parse(tools.WeekNum);
                PData.BatchNum = int.Parse(tools.BatchNum);
                PData.LotNum = int.Parse(tools.LotNum);

                lblWeek.Text = PData.WeekNum.ToString();
                lblBatch.Text = PData.BatchNum.ToString();
                lblLot.Text = PData.LotNum.ToString();
                CheckDate = true;
                getWorkOreder();
            }
            else
            {
                CheckDate = false;
            }
        }
        #endregion


        private void getWorkOreder()
        {
            bool wMont = false;
            bool wTrail = false;
            if (PData.Day != 0 && PData.Month != 0 && PData.Year != 0 && FastCD != 0 && PData.TemplateNum != 0)
            {
                LINQDataContext db = new LINQDataContext();

                var tmp1 = from s in db.WorkOrderMonths
                           where s.Year == PData.Year && s.ProdectionCode == PData.ProdectionCode && s.TemplateNum == PData.TemplateNum &&
                           s.Month == PData.Month && (PData.Day >= s.DayStart && PData.Day <= s.DayFinish)
                           select s;
                if (tmp1.Count() == 1)
                {
                    wMont = true;
                }
                var tmp2 = from s in db.WorkOrderTrails
                           where s.Year == PData.Year && s.ProdectionCode == PData.ProdectionCode && s.TemplateNum == PData.TemplateNum &&
                           s.Month == PData.Month && (PData.Day >= s.DayStart && PData.Day <= s.DayFinish)
                           select s;
                if (tmp2.Count() == 1)
                {
                    wTrail = true;
                }



                if (wMont && wTrail)
                {
                    if (tmp1.Single().Confirmation)
                    {
                        TypeOfTolid.Enabled = true;
                        TypeOfTolid.Value = true;
                        txtWorkOrderNum.Text = tmp1.First().ID.ToString();
                        txtmachineNum.Text = tmp1.First().MachineNum.ToString();
                        TypeOfTolid.Value = true;
                        PData.TypeOfTolid = 1;
                    }
                    else
                    {
                        TypeOfTolid.Enabled = false;
                        TypeOfTolid.Value = false;
                        txtWorkOrderNum.Text = tmp2.First().ID.ToString();
                        txtmachineNum.Text = tmp2.First().MachineNum.ToString();
                        TypeOfTolid.Value = false;
                        PData.TypeOfTolid = 2;
                    }
                }
                else
                {
                    TypeOfTolid.Enabled = false;
                    if (wMont)
                    {
                        if (tmp1.Single().Confirmation)
                        {
                            TypeOfTolid.Value = true;
                            txtWorkOrderNum.Text = tmp1.First().ID.ToString();
                            txtmachineNum.Text = tmp1.First().MachineNum.ToString();
                            TypeOfTolid.Value = true;
                            PData.TypeOfTolid = 1;
                        }
                        else
                        {
                            MessageBox.Show("دستور کار صادر شده تایید نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtWorkOrderNum.Clear();
                            txtmachineNum.Clear();
                            TypeOfTolid.Enabled = false;
                            TypeOfTolid.Value = true;
                            PData.TypeOfTolid = 1;
                            return;
                        }
                    }
                    else if (wTrail)
                    {
                        TypeOfTolid.Value = false;
                        txtWorkOrderNum.Text = tmp2.First().ID.ToString();
                        txtmachineNum.Text = tmp2.First().MachineNum.ToString();
                        TypeOfTolid.Value = false;
                        PData.TypeOfTolid = 2;
                    }
                    else
                    {
                        MessageBox.Show("برای این تاریخ و محصول هیچ دستور کاری صادر نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtWorkOrderNum.Clear();
                        txtmachineNum.Clear();
                        TypeOfTolid.Enabled = false;
                        TypeOfTolid.Value = true;
                        PData.TypeOfTolid = 1;
                        return;
                    }
                }
                getNewTimeTolid();

            }
            else
            {
                txtWorkOrderNum.Clear();
                txtmachineNum.Clear();
                TypeOfTolid.Enabled = false;
                TypeOfTolid.Value = true;
                PData.TypeOfTolid = 1;
            }
        }


        private void getWorkOreder2()
        {
            if (PData.Day != 0 && PData.Month != 0 && PData.Year != 0 && FastCD != 0 && PData.TemplateNum != 0)
            {
                LINQDataContext db = new LINQDataContext();

                var tmp1 = (from s in db.WorkOrderMonths
                            where s.Year == PData.Year && s.ProdectionCode == PData.ProdectionCode && s.TemplateNum == PData.TemplateNum &&
                            s.Month == PData.Month && (PData.Day >= s.DayStart && PData.Day <= s.DayFinish)
                            select s).SingleOrDefault();

                var tmp2 = (from s in db.WorkOrderTrails
                            where s.Year == PData.Year && s.ProdectionCode == PData.ProdectionCode && s.TemplateNum == PData.TemplateNum &&
                            s.Month == PData.Month && (PData.Day >= s.DayStart && PData.Day <= s.DayFinish)
                            select s).SingleOrDefault();

                if (TypeOfTolid.Value)
                {
                    if (tmp1 == null)
                        return;
                    txtWorkOrderNum.Text = tmp1.ID.ToString();
                    txtmachineNum.Text = tmp1.MachineNum.ToString();
                    TypeOfTolid.Value = true;
                    PData.TypeOfTolid = 1;
                }
                else
                {
                    if (tmp2 == null)
                        return;
                    txtWorkOrderNum.Text = tmp2.ID.ToString();
                    txtmachineNum.Text = tmp2.MachineNum.ToString();
                    TypeOfTolid.Value = false;
                    PData.TypeOfTolid = 2;
                }
            }
        }


        int Timetolid = 0;
        private void getNewTimeTolid()
        {
            LINQDataContext db = new LINQDataContext();

            var aaa = from s in db.ProductionDatas
                      where s.ProdectionCode == PData.ProdectionCode && s.LotNum == PData.LotNum
                      && s.TemplateNum == PData.TemplateNum
                      select s;
            if (aaa.Count() == 0)
            {
                Timetolid = 720;
                txtTimeTolid.Text = Timetolid.ToString();
            }
            else if (aaa.Count() == 1)
            {
                Timetolid = (720 - aaa.Single().TimeTolid.Value);
                if (Timetolid == 0 && !TypeOfTolid.Enabled)
                {
                    MessageBox.Show("این فرم قبلا ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTimeTolid.Text = Timetolid.ToString();
                }
                else
                {
                    txtTimeTolid.Text = Timetolid.ToString();
                }
            }
            else if (aaa.Count() > 1)
            {
                MessageBox.Show("این محصول در تاریخ فوق اطلاعات آزمایشی و روتین آن ثبت شده است و نمیتوان فرم جدید ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Timetolid = 0;
                txtTimeTolid.Text = Timetolid.ToString();
                return;

            }
        }

        private void frmPRInsert_Load(object sender, EventArgs e)
        {
            StartForm();
        }

        private void StartForm()
        {
            PData = new ProductionData();
            txtDay.Clear();
            txtMonth.Clear();
            txtYear.Clear();
            lblBatch.Text = "";
            lblWeek.Text = "";
            lblLot.Text = "";
            txtYear.Text = "1399";
            chkShiftStatus.Value = true;
            PData.Shift = 1;
            PData.OperatorOrderCode = DataAccess.User.PCode;
            PData.OperatorOrderName = DataAccess.User.PName;
            lblCodePersonel.Text = DataAccess.User.PCode.ToString();
            lblNamePersonel.Text = DataAccess.User.PName;
            int query = ((from s in DataBase.ProductionDatas select new { mmp = s.IDPR }).Max(a => a.mmp)) + 1;
            PData.IDPR = query;
            lblIDNum.Text = query.ToString();
            FastCD = 0;
            ClearPR();
            txtmachineNum.Clear();
            txtWorkOrderNum.Clear();
            TypeOfTolid.Value = true;
            txtTimeTolid.Clear();
            PData.TypeOfTolid = 1;
            txtPartNum.Clear();
            txtWastage.Clear();
            txtRahgah.Clear();
            txtKoloukhe.Clear();
            txtWastageStart.Clear();
            txtControl.Clear();
            txtActiveKaviteh.Clear();
            txtCycleTime.Clear();
            txtOperatorCode.Clear();
            stop = new Stop();
            tblStop = Utility.CreateTable<GranuleStop>();
            tblStopview = CreateStopTable();
            gridAll.DataSource = tblStopview;
            PData.TimeTolid = 0;
            Desc = new tblDescription();
            txtDescription.Clear();
            PData.GranuleSeries = "No";
            PData.WastageStart = 0;
            txtDay.Focus();

        }
        Stop stop = new Stop();
        private DataTable CreateStopTable()
        {
            DataTable temp = new DataTable();

            temp.Columns.Add("StopID");
            temp.Columns.Add("StopTitle");
            temp.Columns.Add("StopTime");

            return temp;
        }

        private void ClearPR()
        {
            FastCD = 0;
            lblProdectCode.Text = "";
            PData.ProdectionCode = null;
            lblProdectName.Text = "";
            PData.ProdectionName = null;
            txtFastCode.Clear();
            comTemplate.Items.Clear();
            comTemplate.Enabled = false;
            TypeOfTolid.Value = true;
            txtActiveKaviteh.Clear();
            txtFastCode.Enabled = true;
            btnFastcodeview.Enabled = true;
            lblKaviteh.Text = "";
            getWorkOreder();
        }

        int FastCD = 0;
        private void IsNumberic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void IsNumbericFastCode(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                GetPrdata();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
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
                GetPrdata();
            }
        }
        private void txtFastCode_Leave(object sender, EventArgs e)
        {
            if (FastCD == 0)
            {
                GetPrdata();
            }
        }
        int ID;
        private void GetPrdata()
        {
            try
            {
                if (txtFastCode.Text.Trim().Length > 0)
                {
                    if (FastCD.ToString() == txtFastCode.Text.Trim())
                        return;
                    if (txtFastCode.Text.Trim() == "999")
                    {
                        FillNoMold();
                        return;
                    }
                    var a = from u in DataBase.QuickSelects
                            where u.CodeFast == int.Parse(txtFastCode.Text) && u.kind == "M"
                            select u;

                    if (a.Count() == 1)
                    {
                        var tmp = a.FirstOrDefault();
                        FastCD = PData.FastCode = tmp.CodeFast;
                        lblProdectCode.Text = PData.ProdectionCode = tmp.Product_Code;
                        lblProdectName.Text = PData.ProdectionName = tmp.Product_Name;
                        ID = tmp.ID;

                        var mold = from S in DataBase.Molds
                                   where S.IDProtection == ID
                                   select S;

                        if (mold.Count() == 0)
                        {
                            //kavite = true;
                            lblKaviteh.Text = "0";
                            comTemplate.Items.Clear();
                            txtActiveKaviteh.Text = "0";
                            TypeOfTolid.Value = true;
                            txtmachineNum.Focus();
                            getWorkOreder();
                            return;

                        }
                        if (mold.Count() == 1)
                        {
                            int i = int.Parse(mold.First().MoldNum.ToString());
                            comTemplate.Items.Clear();
                            comTemplate.Items.Add(i.ToString());

                            i = int.Parse(mold.First().Quetta.ToString());
                            PData.Kaviteh = i;
                            lblKaviteh.Text = i.ToString();
                            comTemplate.Enabled = false;
                            comTemplate.SelectedIndex = 0;
                            //TypeOfTolid.Value = true;
                            txtmachineNum.Focus();
                            txtActiveKaviteh.Clear();
                        }
                        else
                        {
                            comTemplate.Enabled = true;
                            comTemplate.Items.Clear();
                            foreach (var item in mold)
                                comTemplate.Items.Add(item.MoldNum.ToString());
                            txtActiveKaviteh.Clear();
                            //TypeOfTolid.Value = true;
                            comTemplate.Focus();
                            comTemplate.SelectedIndex = 0;
                        }
                    }
                    else
                    {
                        FastCD = 0;
                        if (a.Count() > 1)
                        {
                            MessageBox.Show("خطا", "برای کد بیشتر از یک کالا تعریف شده است.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            MessageBox.Show("خطا", "این کالا در لیست وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        ClearPR();
                    }
                }
                else
                {
                    ClearPR();
                }
            }
            catch (Exception)
            {
                MessageBox.Show("دریافت اطلاعات با خطا مواجه شد مجدد بررسی نمایید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
        private void FillNoMold()
        {

        }
        private void txtFastCode_TextChanged(object sender, EventArgs e)
        {
            FastCD = 0;
        }
        private void comTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                var tmp = (from S in DataBase.Molds
                           where S.IDProtection == ID && S.MoldNum == int.Parse(comTemplate.SelectedItem.ToString())
                           select S).FirstOrDefault();
                PData.TemplateNum = int.Parse(tmp.MoldNum.ToString());
                PData.Kaviteh = int.Parse(tmp.Quetta.ToString());
                lblKaviteh.Text = PData.Kaviteh.ToString();
                getWorkOreder();
            }
            catch (Exception)
            {
                MessageBox.Show("خطا", "این شماره قالب وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }
        }
        private void txtmachineNum_TextChanged(object sender, EventArgs e)
        {
            if (txtmachineNum.TextLength > 0)
            {
                PData.MachineNum = int.Parse(txtmachineNum.Text);
                btnMacineView.Enabled = true;
            }
            else
            {
                PData.MachineNum = 0;
                btnMacineView.Enabled = false;
            }
        }
        private void txtWorkOrderNum_TextChanged(object sender, EventArgs e)
        {
            if (txtWorkOrderNum.TextLength > 0)
                PData.WorkOrder = int.Parse(txtWorkOrderNum.Text);
            else
                PData.WorkOrder = 0;
        }
        private void txtTimeTolid_TextChanged(object sender, EventArgs e)
        {
            if (txtTimeTolid.TextLength > 0)
            {
                int tmp = int.Parse(txtTimeTolid.Text);
                if (tmp <= 720)
                {
                    PData.TimeTolid = tmp;
                }
                else
                {
                    txtTimeTolid.Text = "720";
                    return;
                }
            }
            else
                PData.TimeTolid = 0;
        }
        private void txtPartNum_TextChanged(object sender, EventArgs e)
        {
            if (txtPartNum.TextLength > 0)
                PData.PartNum = int.Parse(txtPartNum.Text);
            else
                PData.PartNum = 0;
        }
        private void txtWastage_TextChanged(object sender, EventArgs e)
        {
            if (txtWastage.TextLength > 0)
                PData.WastageNum = int.Parse(txtWastage.Text);
            else
                PData.WastageNum = 0;
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
        private void txtWastageStart_TextChanged(object sender, EventArgs e)
        {
            if (txtWastageStart.TextLength > 0)
                PData.WastageStart = int.Parse(txtWastageStart.Text);
            else
                PData.WastageStart = 0;
        }
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (txtControl.TextLength > 0)
                PData.ControlNum = int.Parse(txtControl.Text);
            else
                PData.ControlNum = 0;
        }
        private void txtActiveKaviteh_Leave(object sender, EventArgs e)
        {
            if (txtActiveKaviteh.Text.Length > 0)
            {

                PData.ActiveKaviteh = int.Parse(txtActiveKaviteh.Text);
                if (PData.ActiveKaviteh > PData.Kaviteh)
                {
                    PData.ActiveKaviteh = PData.Kaviteh;
                    txtActiveKaviteh.Text = PData.ActiveKaviteh.ToString();
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
        private void txtOperatorCode_TextChanged(object sender, EventArgs e)
        {
            if (txtOperatorCode.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOperatorCode.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    PData.OperatorCode = int.Parse(temp.PersonalCode.ToString());
                    PData.OperatorName = temp.PersonalName;
                    lblOperatorName.Text = temp.PersonalName;
                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOperatorCode.Clear();
                }
            }
            else
            {
                lblOperatorName.Text = "";
                PData.OperatorCode = 0;
                PData.OperatorName = "";
            }
        }
        private void txtOperatorCheck_TextChanged(object sender, EventArgs e)
        {
            if (txtOperatorCode.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOperatorCode.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    PData.OperatorCode = int.Parse(temp.PersonalCode.ToString());
                    PData.OperatorName = temp.PersonalName;

                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOperatorCode.Clear();
                }
            }
            else
            {
                lblOperatorName.Text = "";
                PData.OperatorCode = 0;
                PData.OperatorName = "";
            }
        }
        private void btnOp_Click(object sender, EventArgs e)
        {
            PersonalForm frm = new PersonalForm();
            frm.ShowDialog();
        }
        private void btnOpChk_Click(object sender, EventArgs e)
        {
            PersonalForm frm = new PersonalForm();
            frm.ShowDialog();
        }
        DataTable tblStop;
        DataTable tblStopview;
        private void gridStop_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                stop.StopID = int.Parse(gridAll.Rows[e.RowIndex].Cells["StopID"].Value.ToString());
                txtStopCode.Text = stop.StopID.ToString();
                lblcode1.Text = gridAll.Rows[e.RowIndex].Cells["StopTitle"].Value.ToString();
                txtStopTime.Text = gridAll.Rows[e.RowIndex].Cells["StopTime"].Value.ToString();
                stop.IDProtection = PData.IDPR;

                DataRow dr = tblStop.Select("StopID=" + stop.StopID).First();
                tblStop.Rows.Remove(dr);
                dr = tblStopview.Select("StopID=" + stop.StopID).First();
                tblStopview.Rows.Remove(dr);
            }
        }
        private void btnAddStop_Click(object sender, EventArgs e)
        {
            if (stop.StopID == 0)
            {

                MessageBox.Show("کد توقف باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStopCode.Focus();
                return;
            }
            if (stop.StopTime == 0)
            {
                MessageBox.Show("مدت توقف نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStopTime.Focus();
                return;
            }
            int tot = 0;
            for (int i = 0; i < tblStop.Rows.Count; i++)
            {
                if (stop.StopID == int.Parse(tblStop.Rows[i]["StopID"].ToString()))
                {
                    MessageBox.Show("نمیتوان مورد تکراری ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtStopCode.Focus();
                    return;
                }
                tot += int.Parse(tblStop.Rows[i]["StopTime"].ToString());
            }

            if (tot + stop.StopTime > PData.TimeTolid)
            {
                MessageBox.Show("جمع کل توقفات نمیتواند بیشتر از زمان تولید باشد دقیقه باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStopTime.Focus();
                return;
            }

            if (stop.StopID == 14 && txtDescription.TextLength == 0)
            {
                txtDescription.Text = "14-سرویس قالب انجام شد.\n";
            }

            stop.See = false;
            AddToTableStop();
            ClearStopForm();

        }
        private void txtStopCode_Leave(object sender, EventArgs e)
        {
            StopFill();
        }
        private void txtStopCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtStopTime.Focus();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txtStopTime_TextChanged(object sender, EventArgs e)
        {
            if (txtStopTime.Text.Trim().Length > 0)
                stop.StopTime = int.Parse(txtStopTime.Text);
            else
                stop.StopTime = 0;
        }
        private void StopFill()
        {
            if (txtStopCode.Text.Trim().Length > 0)
            {
                if (txtStopCode.TextLength == 1)
                {
                    txtStopCode.Clear();
                    lblcode1.Text = "";
                    txtStopTime.Clear();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }
                LINQDataContext tmp = new LINQDataContext();

                var a = from s in tmp.StopTypes
                        where s.StopID == int.Parse(txtStopCode.Text)
                        select s;

                if (a.Count() == 1)
                {
                    var str = a.First();
                    lblcode1.Text = str.Title;
                    stop.StopID = str.StopID;
                    txtStopTime.Focus();

                }
                else
                {
                    txtStopCode.Clear();
                    lblcode1.Text = "";
                    txtStopTime.Clear();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                }
            }
        }
        private void AddToTableStop()
        {

            DataRow DR = tblStop.NewRow();
            DR["uid"] = stop.ID;
            DR["IDGranule"] = stop.IDProtection;
            DR["StopID"] = stop.StopID;
            DR["StopTime"] = stop.StopTime;
            DR["See"] = stop.See;
            tblStop.Rows.Add(DR);

            DataRow dr = tblStopview.NewRow();
            dr["StopID"] = stop.StopID;
            dr["StopTitle"] = lblcode1.Text;
            dr["StopTime"] = stop.StopTime;
            tblStopview.Rows.Add(dr);

        }
        private void ClearStopForm()
        {
            stop = new Stop();
            stop.IDProtection = PData.IDPR;
            txtStopCode.Clear();
            txtStopTime.Clear();
            lblcode1.Text = "";
            txtStopCode.Focus();
        }
        private void gridAll_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            int Total = 0;
            foreach (var item in gridAll.Rows)
            {
                Total += int.Parse(item.Cells["StopTime"].Value.ToString());
            }
            lblTotalStopTime.Text = Total.ToString();

        }
        private void gridAll_UserDeletingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف این آیتم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = int.Parse(e.Rows[0].Cells["StopID"].Value.ToString());

                DataRow dr = tblStop.Select("StopID=" + id).First();
                tblStop.Rows.Remove(dr);

            }
            else
            {
                e.Cancel = true;
            }
        }
        private void TypeOfTolid_ValueChanged(object sender, EventArgs e)
        {
            getWorkOreder2();
            getNewTimeTolid();
        }
        tblDescription Desc = new tblDescription();
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
        private void btnNew_Click(object sender, EventArgs e)
        {
            StartForm();
        }
        private bool closeed;
        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ثبت اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (Save())
                {
                    MessageBox.Show("فرم شماره " + PData.IDPR.ToString() + " با موفقیت ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    closeed = true;
                    this.Close();
                }
            }
        }
        private bool Save()
        {
            if (checkData())
            {
                PData.stock = false;
                var db = new LINQDataContext();
                PData.Time = Tools.GetTimeNow();
                int query = ((from s in DataBase.ProductionDatas select new { mmp = s.IDPR }).Max(a => a.mmp)) + 1;
                PData.IDPR = query;
                db.ProductionDatas.InsertOnSubmit(PData);
                Desc.IDPR = query;
                db.tblDescriptions.InsertOnSubmit(Desc);

                foreach (var item in tblStop.Select())
                {
                    Stop st = new Stop
                    {
                        IDProtection = PData.IDPR,
                        StopID = int.Parse(item["StopID"].ToString()),
                        StopTime = int.Parse(item["StopTime"].ToString()),
                        See = false
                    };
                    db.Stops.InsertOnSubmit(st);
                }

                try
                {
                    db.SubmitChanges();
                    BalanceShit();
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
        private void BalanceShit()
        {
            LINQDataContext DataBase = new LINQDataContext();
            var dt = from u in DataBase.BalanceAlls
                     where u.LotNum == PData.LotNum && u.ProdectionCode == PData.ProdectionCode && u.TemplateNum == PData.TemplateNum
                     select u;
            if (dt.Count() == 1)
            {
                BalanceAll tmp1 = dt.Single();
                tmp1.PRSalon += PData.PartNum;
                tmp1.PRControl += PData.ControlNum;
                tmp1.Wastage += PData.WastageNum + PData.WastageStart.Value;

                if (PData.PartNum > 0)
                {
                    PRSalon sal = new PRSalon();
                    sal.LotNum = PData.LotNum;
                    sal.ProdectionCode = PData.ProdectionCode;
                    sal.ProdectionName = PData.ProdectionName;
                    sal.TemplateNum = PData.TemplateNum;
                    sal.Decrease = 0;
                    sal.Increase = PData.PartNum;
                    sal.Location = "ProductionData";
                    sal.LocationID = PData.IDPR;
                    DataBase.PRSalons.InsertOnSubmit(sal);
                }
                if (PData.ControlNum > 0)
                {
                    PRControl ctrl = new PRControl();
                    ctrl.LotNum = PData.LotNum;
                    ctrl.ProdectionCode = PData.ProdectionCode;
                    ctrl.ProdectionName = PData.ProdectionName;
                    ctrl.TemplateNum = PData.TemplateNum;
                    ctrl.Increase = PData.ControlNum;
                    ctrl.Location = "ProductionData";
                    ctrl.LocationID = PData.IDPR;
                    DataBase.PRControls.InsertOnSubmit(ctrl);
                }
                if (PData.WastageNum + PData.WastageStart > 0)
                {
                    Wastage was = new Wastage();
                    was.LotNum = PData.LotNum;
                    was.ProdectionCode = PData.ProdectionCode;
                    was.ProdectionName = PData.ProdectionName;
                    was.TemplateNum = PData.TemplateNum;
                    was.Increase = PData.ControlNum;
                    was.Location = "ProductionData";
                    was.LocationID = PData.IDPR;
                    DataBase.Wastages.InsertOnSubmit(was);
                }
                ProductionData tmp = (from ss in DataBase.ProductionDatas
                                      where ss.IDPR == PData.IDPR
                                      select ss).FirstOrDefault();
                tmp.stock = true;
                try { DataBase.SubmitChanges(); }
                catch { }
            }
            else
            {
                BalanceAll bal = new BalanceAll();
                bal.LotNum = PData.LotNum;
                bal.ProdectionCode = PData.ProdectionCode;
                bal.ProdectionName = PData.ProdectionName;
                bal.TemplateNum = PData.TemplateNum;
                bal.PRSalon = PData.PartNum;
                bal.PRControl = PData.ControlNum;
                bal.Wastage = PData.WastageNum + PData.WastageStart.Value;

                DataBase.BalanceAlls.InsertOnSubmit(bal);

                if (PData.PartNum > 0)
                {
                    PRSalon sal = new PRSalon();
                    sal.LotNum = PData.LotNum;
                    sal.ProdectionCode = PData.ProdectionCode;
                    sal.ProdectionName = PData.ProdectionName;
                    sal.TemplateNum = PData.TemplateNum;
                    sal.Decrease = 0;
                    sal.Increase = PData.PartNum;
                    sal.Location = "ProductionData";
                    sal.LocationID = PData.IDPR;
                    DataBase.PRSalons.InsertOnSubmit(sal);
                }
                if (PData.ControlNum > 0)
                {
                    PRControl ctrl = new PRControl();
                    ctrl.LotNum = PData.LotNum;
                    ctrl.ProdectionCode = PData.ProdectionCode;
                    ctrl.ProdectionName = PData.ProdectionName;
                    ctrl.TemplateNum = PData.TemplateNum;
                    ctrl.Increase = PData.ControlNum;
                    ctrl.Location = "ProductionData";
                    ctrl.LocationID = PData.IDPR;
                    DataBase.PRControls.InsertOnSubmit(ctrl);
                }
                if (PData.WastageNum + PData.WastageStart > 0)
                {
                    Wastage was = new Wastage();
                    was.LotNum = PData.LotNum;
                    was.ProdectionCode = PData.ProdectionCode;
                    was.ProdectionName = PData.ProdectionName;
                    was.TemplateNum = PData.TemplateNum;
                    was.Increase = PData.ControlNum;
                    was.Location = "ProductionData";
                    was.LocationID = PData.IDPR;
                    DataBase.Wastages.InsertOnSubmit(was);
                }


                ProductionData tmp = (from ss in DataBase.ProductionDatas
                                      where ss.IDPR == PData.IDPR
                                      select ss).FirstOrDefault();
                tmp.stock = true;

                try { DataBase.SubmitChanges(); }
                catch { }
            }
        }

        private bool checkData()
        {
            if (!CheckDate)
            {
                MessageBox.Show("اطلاعات تاریخ به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }

            if (PData.FastCode == 0 || PData.ProdectionCode == null || PData.ProdectionName == null)
            {
                MessageBox.Show("اطلاعات کالا وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFastCode.Focus();
                return false;
            }
            if (PData.MachineNum == 0 || PData.WorkOrder == 0)
            {
                MessageBox.Show("برای این تاریخ و محصول دستور کاری صادر نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtmachineNum.Focus();
                return false;
            }
            if (PData.TimeTolid == 0)
            {
                MessageBox.Show("اطلاعات مدت زمان تولید وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderNum.Focus();
                return false;
            }
            if (PData.ActiveKaviteh == 0)
            {
                MessageBox.Show("اطلاعات کویته فعال وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderNum.Focus();
                return false;
            }

            if (PData.CycleTime == 0)
            {
                MessageBox.Show("اطلاعات سایکل تایم وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderNum.Focus();
                return false;
            }

            if (PData.VaznRahgah > 150 || PData.VaznKoloukheh > 50)
            {
                MessageBox.Show("وزن راه گاه باید کمتر از 150 کیلوگرم و وزن کلوخه کمتر از 50 کیلو باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRahgah.Focus();
                return false;
            }
            if (PData.OperatorCode == 0)
            {
                MessageBox.Show("اطلاعات نام اپراتور وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtWorkOrderNum.Focus();
                return false;
            }
            if (Utility.CreateTime(PData.Year, PData.Month, PData.Day))
            {
                MessageBox.Show("اطلاعات وارد شده خارج از بازه زمانی مجاز برای ثبت اطلاعات است \n لطفا تاریخ وارد شده را بررسی نمایید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }

            if (tblStop.Rows.Count == 0)
            {
                MessageBox.Show("توقف دستگاه وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtStopCode.Focus();
                return false;
            }

            if (Convert.ToDouble(lblTotalStopTime.Text) > 0)
            {
                double TotalTime = Convert.ToDouble(lblTotalStopTime.Text);
                double Tedad = (double)PData.TimeTolid - TotalTime;
                Tedad *= 60;
                Tedad /= (double)PData.CycleTime;
                Tedad *= (double)PData.ActiveKaviteh;
                int TotalPR = (int)PData.PartNum + (int)PData.ControlNum + (int)PData.WastageNum + (int)PData.WastageStart;


                if (!((Tedad * 1.5) > TotalPR && TotalPR > (Tedad * 0.5)))
                {
                    if (Tedad > 0)
                    {
                        MessageBox.Show("تعداد کل تولید شما با توقف همخوانی ندارد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return false;
                    }
                }


            }
            else
            {
                MessageBox.Show("جمع زمان توفقات دستگاه نمیتواند کمتر از 1 دقیقه باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }

            if (txtDescription.TextLength == 0)
            {
                MessageBox.Show("توضیحات نمیتواند خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDescription.Focus();
                return false;
            }
            LINQDataContext db = new LINQDataContext();
            var tmp = from s in db.ProductionDatas
                      where s.ProdectionCode == PData.ProdectionCode && s.LotNum == PData.LotNum && s.TemplateNum == PData.TemplateNum && s.TypeOfTolid == PData.TypeOfTolid
                      select s;
            if (tmp.Count() > 0)
            {
                MessageBox.Show("این فرم قبلا ثبت شده است.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }
            if (PData.WastageStart > 0 && tblStop.Rows.Count == 1)
            {
                if (tblStop.Rows[0]["StopID"].ToString() == "14")
                {
                    MessageBox.Show("در صورت فقط ثبت توقف روتین نمیتوان ضایعات راه اندازی ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtStopCode.Focus();
                    return false;
                }
            }

            if (PData.ControlNum > 0)
            {
                /*
                var tmp2 = from s in db.tblQCNonConformities
                           where s.LotNum == PData.LotNum && s.ProdectionCode == PData.ProdectionCode && s.TemplateNum == PData.TemplateNum && s.DiagnosisLevel == 1
                           select s;
                int a = 0;
                if (tmp2.Count() > 0)
                {
                    a = tmp2.Sum(x => x.ControlNum);
                }

                if (PData.ControlNum != a)
                {
                    MessageBox.Show("برای این محصول و لات نامبر به این تعداد عدم انطباق صادر نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtControl.Focus();
                    return false;
                }
                 */

            }

            return true;

        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("اطلاعات", "آیا مایل به ثبت اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                if (Save())
                {
                    MessageBox.Show("فرم شماره " + PData.IDPR.ToString() + " با موفقیت ثبت شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    StartForm();
                }
            }
        }
        private void frmPRInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeed)
            {
                return;
            }
            if (DialogResult.No == MessageBox.Show("آیا مایل به خروج هستید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                e.Cancel = true;
            }
        }
        private void btnLastIDEdit_Click(object sender, EventArgs e)
        {

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnMacineView_Click(object sender, EventArgs e)
        {
            frmViewMachine frm = new frmViewMachine();
            frm.MachineNumber = PData.MachineNum;
            frm.ShowDialog();
        }

        private void btnStopView_Click(object sender, EventArgs e)
        {
            frmStopView frm = new frmStopView();
            frm.ShowDialog();
            if (frm.DoubleClicked)
            {
                txtStopCode.Text = frm.stopID;
                StopFill();
            }
        }
    }
}
