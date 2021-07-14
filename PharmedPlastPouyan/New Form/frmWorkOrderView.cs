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
    public partial class frmWorkOrderView : Form
    {
        public bool WMontEdit = false;
        public bool WYearEdit = false;
        public bool WtrailEdit = false;
        public long ID;
        DataAccess Data = new DataAccess();
        WorkOrderMonth WMont = new WorkOrderMonth();
        WorkOrderYear WYear = new WorkOrderYear();
        WorkOrderTrail Wtrail = new WorkOrderTrail();
        bool FirstRun = false;

        public frmWorkOrderView()
        {
            InitializeComponent();
        }

        private void frmWorkOrderView_Load(object sender, EventArgs e)
        {
            FirstRun = true;
            panlEnable();
            if (FillData())
            {

                getPRInformation();
                DayWork();
                CalcTotalPart();
                visablechane();
                getData();
                FirstRun = false;
            }
            if (DataAccess.User.Admin)
                btnDelete.Enabled = btnDelete.Visible = btnEdit.Enabled = btnEdit.Visible = true;
            else
                btnDelete.Enabled = btnDelete.Visible = btnEdit.Enabled = btnEdit.Visible = false;

        }

        private void visablechane()
        {
            switch (Kind)
            {
                case "GR":
                    txtActiveKavite.ReadOnly = true;
                    txtActiveKavite.TabStop = false;
                    txtCycleTime.ReadOnly = true;
                    txtCycleTime.TabStop = false;
                    txtMinPrDay.TabStop = true;
                    txtMinPrDay.ReadOnly = false;
                    txtAloans.TabStop = false;
                    txtAloans.ReadOnly = true;
                    break;
                case "AS":
                    label29.Text = "تعداد ایستگاه :";
                    break;

                default:
                    break;
            }
        }

        private void getPRInformation()
        {
            LINQDataContext db2 = new LINQDataContext();
            QuickSelect prd = null;
            if (WMontEdit)
            {
                prd = (from sa in db2.QuickSelects
                       where sa.Product_Code == WMont.ProdectionCode
                       select sa).SingleOrDefault();
            }
            else if (WtrailEdit)
            {
                prd = (from sa in db2.QuickSelects
                       where sa.Product_Code == Wtrail.ProdectionCode
                       select sa).SingleOrDefault();
            }
            else if (WYearEdit)
            {
                prd = (from sa in db2.QuickSelects
                       where sa.Product_Code == WYear.ProdectionCode
                       select sa).SingleOrDefault();
            }

            if (prd != null)
            {

                switch (prd.kind)
                {
                    case "A":
                        Kind = "AS";
                        break;
                    case "G":
                        Kind = "GR";
                        break;
                    case "M":
                        Kind = "PR";
                        if (WMontEdit)
                        {
                            kaviteh = (from s in db2.Molds where s.IDProtection == prd.ID && s.MoldNum == WMont.TemplateNum select s.Quetta).SingleOrDefault().Value;
                        }
                        else
                        if (WtrailEdit)
                        {
                            kaviteh = (from s in db2.Molds where s.IDProtection == prd.ID && s.MoldNum == Wtrail.TemplateNum select s.Quetta).SingleOrDefault().Value;
                        }

                        break;
                    default:
                        break;
                }
            }

        }

        private void getData()
        {
            #region Mont And Trail
            if (WMontEdit || WtrailEdit)
            {

                LINQDataContext db = new LINQDataContext();

                #region Production
                if (Kind == "PR")
                {
                    if (WMontEdit)
                    {

                        var Pdata = from s in db.ProductionDatas
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


                        var AllPart = from s in db.ProductionDatas
                                      where s.ProdectionCode == WMont.ProdectionCode
                                      select s;
                        if (AllPart.Count() > 0)
                            txtprNow.Text = AllPart.Sum(x => x.PartNum).ToString();
                        else
                            txtprNow.Text = "0";


                        var AllSalon = from s in db.BalanceAlls
                                       where s.ProdectionCode == WMont.ProdectionCode
                                       select s;
                        if (AllSalon.Count() > 0)
                            txtSalon.Text = AllSalon.Sum(x => x.PRSalon).ToString();
                        else
                            txtSalon.Text = "0";


                        var AllPartYear = from s in db.WorkOrderYears
                                          where s.ProdectionCode == WMont.ProdectionCode
                                          select s;
                        if (AllPartYear.Count() > 0)
                            txtpartOfYear.Text = AllPartYear.Sum(x => x.PartNum).ToString();
                        else
                            txtpartOfYear.Text = "0";



                        txtAllAloans.Text = (Convert.ToDouble(txtprNow.Text) / Convert.ToDouble(txtpartOfYear.Text) * 100).ToString("#.##") + "  %";



                        var LastWorkOrder = (from s in db.WorkOrderMonths
                                             where s.ProdectionCode == WMont.ProdectionCode && s.Month < WMont.Month  && s.TemplateNum == WMont.TemplateNum
                                             orderby s.Year, s.Month, s.DayFinish descending
                                             select s).FirstOrDefault();

                        if (LastWorkOrder != null)
                        {
                            var partInWorkOrder = from s in db.ProductionDatas
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
                    else if (WtrailEdit)
                    {
                        var Pdata = from s in db.ProductionDatas
                                    where s.ProdectionCode == Wtrail.ProdectionCode && s.TemplateNum == Wtrail.TemplateNum
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


                        var AllPart = from s in db.ProductionDatas
                                      where s.ProdectionCode == Wtrail.ProdectionCode
                                      select s;
                        if (AllPart.Count() > 0)
                            txtprNow.Text = AllPart.Sum(x => x.PartNum).ToString();
                        else
                            txtprNow.Text = "0";


                        var AllSalon = from s in db.BalanceAlls
                                       where s.ProdectionCode == Wtrail.ProdectionCode
                                       select s;
                        if (AllSalon.Count() > 0)
                            txtSalon.Text = AllSalon.Sum(x => x.PRSalon).ToString();
                        else
                            txtSalon.Text = "0";


                        var AllPartYear = from s in db.WorkOrderYears
                                          where s.ProdectionCode == Wtrail.ProdectionCode
                                          select s;
                        if (AllPartYear.Count() > 0)
                            txtpartOfYear.Text = AllPartYear.Sum(x => x.PartNum).ToString();
                        else
                            txtpartOfYear.Text = "0";



                        txtAllAloans.Text = (Convert.ToDouble(txtprNow.Text) / Convert.ToDouble(txtpartOfYear.Text) * 100).ToString("#.##") + "  %";



                        var LastWorkOrder = (from s in db.WorkOrderMonths
                                             where s.ProdectionCode == Wtrail.ProdectionCode && s.Month < Wtrail.Month && s.TemplateNum == Wtrail.TemplateNum
                                             orderby s.Year, s.Month, s.DayFinish descending
                                             select s).FirstOrDefault();

                        if (LastWorkOrder != null)
                        {
                            var partInWorkOrder = from s in db.ProductionDatas
                                                  where s.ProdectionCode == Wtrail.ProdectionCode && s.Month == LastWorkOrder.Month && s.TemplateNum == LastWorkOrder.TemplateNum &&
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

                }
                #endregion

                #region Granule

                if (Kind == "GR")
                {

                    var Data = from s in db.GranuleDatas
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


                    var partSalon = from s in db.BalanceAlls
                                    where s.ProdectionCode == WMont.ProdectionCode && s.TemplateNum == WMont.TemplateNum
                                    select s;
                    if (partSalon.Count() > 0)
                        txtSalon.Text = partSalon.Sum(x => x.PRSalon).ToString() + "  KG";
                    else
                        txtSalon.Text = "----";



                    var AllPartYear = from s in db.WorkOrderYears
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

                    var LastWorkOrder = (from s in db.WorkOrderMonths
                                         where s.ProdectionCode == WMont.ProdectionCode && s.Month == (WMont.Month - 1) && s.TemplateNum == WMont.TemplateNum
                                         orderby s.Year, s.Month, s.DayFinish descending
                                         select s).FirstOrDefault();

                    if (LastWorkOrder != null)
                    {
                        var partInWorkOrder = from s in db.GranuleDatas
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
                    var data = from s in db.AssemblyDatas
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
                            txtLastActivekavite.Text = (from s in db.AssemblyDatas where s.ProdectionCode == WMont.ProdectionCode && s.LotNum == tmp4.LotNum select s).Count().ToString();
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

                    var AllSalon = from s in db.BalanceAlls
                                   where s.ProdectionCode == WMont.ProdectionCode
                                   select s;
                    if (AllSalon.Count() > 0)
                        txtSalon.Text = AllSalon.Sum(x => x.PRSalon).ToString();
                    else
                        txtSalon.Text = "0";

                    var AllPartYear = from s in db.WorkOrderYears
                                      where s.ProdectionCode == WMont.ProdectionCode
                                      select s;

                    if (AllPartYear.Count() > 0)
                        txtpartOfYear.Text = AllPartYear.Sum(x => x.PartNum).ToString();
                    else
                        txtpartOfYear.Text = "0";

                    txtAllAloans.Text = (Convert.ToDouble(txtprNow.Text) / Convert.ToDouble(txtpartOfYear.Text) * 100).ToString("#.##") + "  %";

                    var LastWorkOrder = (from s in db.WorkOrderMonths
                                         where s.ProdectionCode == WMont.ProdectionCode && s.Month == (WMont.Month - 1) && s.TemplateNum == WMont.TemplateNum
                                         orderby s.Year, s.Month, s.DayFinish descending
                                         select s).FirstOrDefault();

                    if (LastWorkOrder != null)
                    {
                        var partInWorkOrder = from s in db.AssemblyDatas
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

            if (WYearEdit)
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

        }
        private void panlEnable()
        {
            if (WtrailEdit)
            {
                pnlR1T.Enabled = true;
                pnlR1C.Enabled = false;
                pnlR1D.Enabled = true;
                pnlR2D.Enabled = false;
                pnlR3Fill.Enabled = true;
                pnlR4T.Enabled = false;
                pnlR4C.Enabled = true;
                visableCheck();
            }
            if (WYearEdit)
            {
                pnlR1T.Enabled = false;
                pnlR1C.Enabled = false;
                pnlR1D.Enabled = false;
                pnlR2D.Enabled = true;
                pnlR3Fill.Enabled = false;
                pnlR4T.Enabled = false;
                pnlR4C.Enabled = false;
                visableCheck();
            }
            if (WMontEdit)
            {
                pnlR1T.Enabled = true;
                pnlR1C.Enabled = true;
                pnlR1D.Enabled = true;
                pnlR2D.Enabled = false;
                pnlR3Fill.Enabled = true;
                pnlR4T.Enabled = true;
                pnlR4C.Enabled = false;
                visableCheck();
            }
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
        LINQDataContext DBEdit = new LINQDataContext();
        private bool FillData()
        {

            if (WMontEdit)
            {
                WMont = (from s in DBEdit.WorkOrderMonths where s.uid == ID select s).SingleOrDefault();
                if (WMont == null)
                {
                    this.Close();
                    return false;
                }
                txtIDView.Text = "N-" + WMont.ID.ToString();
                txtYear.Text = WMont.Year.ToString();
                txtMont.Text = WMont.Month.ToString();
                txtDayStart.Text = WMont.DayStart.ToString();
                txtDayFinish.Text = WMont.DayFinish.ToString();
                txtClosingNotWork.Text = WMont.ClosingNotWork.ToString();
                txtClosingAll.Text = WMont.ClosingAll.ToString();
                txtMachineNum.Text = WMont.MachineNum.ToString();
                lblProdectCode.Text = WMont.ProdectionCode.ToString();
                lblProdectName.Text = WMont.ProdectionName.ToString();
                lblTemplateNum.Text = WMont.TemplateNum.ToString();
                txtDescription.Text = WMont.Description.ToString();
                txtCycleTime.Text = WMont.CycleTime.ToString("G22");
                txtActiveKavite.Text = WMont.ActiveKavite.ToString();
                txtAloans.Text = WMont.Aloans.ToString();
                txtEditNum.Text = WMont.EditNum.ToString();
                txtEditText.Text = WMont.EditText.ToString();
                return true;
            }
            else
            {
                if (WYearEdit)
                {
                    WYear = (from s in DBEdit.WorkOrderYears where s.uid == ID select s).SingleOrDefault();
                    if (WYear == null)
                    {
                        this.Close();
                        return false;
                    }
                    txtIDView.Text = "P-" + WYear.ID.ToString();
                    txtYear.Text = WYear.Year.ToString();
                    lblProdectCode.Text = WYear.ProdectionCode.ToString();
                    lblProdectName.Text = WYear.ProdectionName.ToString();
                    txtDescription.Text = WYear.Description.ToString();
                    txtEditNum.Text = WYear.EditNum.ToString();
                    txtEditText.Text = WYear.EditText.ToString();
                    txtPartNum.Text = WYear.PartNum.ToString();
                    return true;
                }
                else
                {

                    if (WtrailEdit)
                    {
                        Wtrail = (from s in DBEdit.WorkOrderTrails where s.uid == ID select s).SingleOrDefault();
                        if (Wtrail == null)
                        {
                            this.Close();
                            return false;
                        }
                        txtIDView.Text = "E-" + Wtrail.ID.ToString();
                        txtYear.Text = Wtrail.Year.ToString();
                        txtYear.Text = Wtrail.Year.ToString();
                        txtMont.Text = Wtrail.Month.ToString();
                        txtDayStart.Text = Wtrail.DayStart.ToString();
                        txtDayFinish.Text = Wtrail.DayFinish.ToString();
                        txtMachineNum.Text = Wtrail.MachineNum.ToString();
                        lblProdectCode.Text = Wtrail.ProdectionCode.ToString();
                        lblProdectName.Text = Wtrail.ProdectionName.ToString();
                        lblTemplateNum.Text = Wtrail.TemplateNum.ToString();
                        txtDescription.Text = Wtrail.Description.ToString();
                        txtEditNum.Text = Wtrail.EditNum.ToString();
                        txtEditText.Text = Wtrail.EditText.ToString();
                        txtApplicant.Text = Wtrail.Applicant.ToString();
                        txtRequestNum.Text = Wtrail.RequestNum.ToString();
                        return true;
                    }
                }
            }
            return false;
        }


        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        QuickSelect Fastcod = new QuickSelect();
        int kaviteh = 0;

        public string Kind { get; private set; }

        private void IsNumberic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void DayWork()
        {
            if (WMontEdit)
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
            else if (WtrailEdit)
            {
                if (Wtrail.DayFinish > 0 && Wtrail.DayStart > 0)
                {
                    int res = 0;
                    if (Wtrail.DayStart <= Wtrail.DayFinish)
                        res = (Wtrail.DayFinish - Wtrail.DayStart) + 1;
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
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (FirstRun) return;
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
        }

        private void txtMont_TextChanged(object sender, EventArgs e)
        {
            if (FirstRun) return;
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
            if (FirstRun) return;
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
            if (FirstRun) return;
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
            if (FirstRun) return;
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
            if (FirstRun) return;
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
            if (FirstRun) return;
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

        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (FirstRun) return;
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
            if (FirstRun) return;
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
            if (FirstRun) return;
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
            if (FirstRun) return;
            if (txtActiveKavite.TextLength > 0)
            {
                if (int.Parse(txtActiveKavite.Text) > kaviteh)
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
            if (FirstRun) return;
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
            if (FirstRun) return;
            if (txtMinPrDay.TextLength > 0)
            {
                WMont.MinPrDay = int.Parse(txtMinPrDay.Text);
            }
            else
            {
                WMont.MinPrDay = 0;
            }
            if (Kind == "GR")
                CalcTotalPart();
        }

        private void txtMinAllWorkorder_TextChanged(object sender, EventArgs e)
        {
            if (FirstRun) return;
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

        private bool checkData()
        {
            LINQDataContext DB = new LINQDataContext();
            if (WMont.Year < 1398)
            {
                MessageBox.Show("اطلاعات مربوط به سال صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtYear.Focus();
                return false;
            }
            if (WMont.EditNum > 0 && WMont.EditText == "بدون ویرایش")
            {
                MessageBox.Show("بعد از تغییر شماره ویرایش باید عنوان ویرایش  را وارد کنید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtEditText.Focus();
                return false;
            }
            if (WMontEdit)
            {
                if (!Utility.NotEqual<WorkOrderMonth>(WMont, (from s in DB.WorkOrderMonths where s.uid == WMont.uid select s).SingleOrDefault()))
                {
                    MessageBox.Show("شما ویرایشی انجام نداده اید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtMont.Focus();
                    return false;
                }
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
                if (WMont.CycleTime == 0 && Kind == "PR")
                {
                    MessageBox.Show("اطلاعات مربوط به سایکل تایم صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtCycleTime.Focus();
                    return false;
                }
                if (WMont.ActiveKavite == 0 && Kind == "PR")
                {
                    MessageBox.Show("اطلاعات مربوط به کویته فعال صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtActiveKavite.Focus();
                    return false;
                }
                if (WMont.Aloans == 0 && Kind == "PR")
                {
                    MessageBox.Show("اطلاعات مربوط به الونس صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtAloans.Focus();
                    return false;
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

                var tmp = from s in DB.WorkOrderMonths
                          where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month && s.TemplateNum == WMont.TemplateNum &&
                          ((WMont.DayStart >= s.DayStart && WMont.DayStart <= s.DayFinish) ||
                          (WMont.DayFinish >= s.DayStart && WMont.DayFinish <= s.DayFinish) ||
                           (WMont.DayStart <= s.DayStart && WMont.DayFinish >= s.DayFinish))
                          select s;
                switch (tmp.Count())
                {
                    case 0:
                        break;
                    case 1:
                        if (tmp.Single().uid != WMont.uid)
                        {
                            MessageBox.Show("این شماره دستورکار با شماره دستورکار " + tmp.Single().ID + " تداخل زمانی دارد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtMont.Focus();
                            return false;
                        }
                        break;
                    default:
                        MessageBox.Show("نمیتوان این دستور کار را ثبت کرد اطلاعات را بررسی نمایید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtMont.Focus();
                        return false;
                }

                var tmp2 = from s in DB.WorkOrderMonths
                           where s.MachineNum == WMont.MachineNum && s.Year == WMont.Year && s.Month == WMont.Month &&
                           ((WMont.DayStart >= s.DayStart && WMont.DayStart <= s.DayFinish) ||
                           (WMont.DayFinish >= s.DayStart && WMont.DayFinish <= s.DayFinish) ||
                            (WMont.DayStart <= s.DayStart && WMont.DayFinish >= s.DayFinish))
                           select s;

                switch (tmp2.Count())
                {
                    case 0:
                        break;
                    case 1:
                        if (tmp2.Single().uid != WMont.uid)
                        {
                            MessageBox.Show("این شماره دستورکار با شماره دستورکار " + tmp2.Single().ID + " تداخل ماشین دارد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtMachineNum.Focus();
                            return false;
                        }
                        break;
                    default:
                        if (WMont.MachineNum != 999)
                        {
                            MessageBox.Show("نمیتوان این دستور کار را ثبت کرد اطلاعات را بررسی نمایید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtMachineNum.Focus();
                            return false;
                        }
                        else
                        {
                            break;
                        }
                }

                switch (Kind)
                {
                    case "GR":
                        var GRtmp = from s in DB.GranuleDatas
                                    where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month &&
                                    (s.Day < WMont.DayStart && s.Day > WMont.DayFinish)
                                    select s;
                        if (GRtmp.Count() > 0)
                        {
                            MessageBox.Show("در بازه زمانی زیر اطلاعات ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtMinAllWorkorder.Focus();
                            return false;
                        }
                        break;
                    case "PR":
                        var PRtmp = from s in DB.ProductionDatas
                                    where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month && s.TemplateNum == WMont.TemplateNum &&
                                    (s.Day < WMont.DayStart || s.Day > WMont.DayFinish)
                                    select s;
                        if (PRtmp.Count() > 0)
                        {
                            MessageBox.Show("در بازه زمانی زیر اطلاعات ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtMinAllWorkorder.Focus();
                            return false;
                        }

                        break;
                    case "AS":
                        var AStmp = from s in DB.AssemblyDatas
                                    where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month &&
                                    (s.Day < WMont.DayStart && s.Day > WMont.DayFinish)
                                    select s;
                        if (AStmp.Count() > 0)
                        {
                            MessageBox.Show("در بازه زمانی زیر اطلاعات ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtMinAllWorkorder.Focus();
                            return false;
                        }
                        else
                            break;

                    default:
                        break;
                }


            }
            else
            {
                if (WtrailEdit)
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
                    var tmp = from s in DB.WorkOrderTrails
                              where s.ProdectionCode == Wtrail.ProdectionCode && s.Year == Wtrail.Year && s.TemplateNum == Wtrail.TemplateNum &&
                              s.RequestNum == Wtrail.RequestNum
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

                    if (WYearEdit)
                    {
                        if (WYear.PartNum == 0)
                        {
                            MessageBox.Show("اطلاعات مربوط به تعداد مورد نیاز سالانه صحیح نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                            txtRequestNum.Focus();
                            return false;
                        }
                    }
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
            if (FirstRun) return;
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
                if (Kind == "GR" && WMontEdit)
                {
                    txtMinPrDay.Text = WMont.MinPrDay.ToString();
                    txtMinAllWorkorder.Text = (dayWork * WMont.MinPrDay).ToString();
                }
                else
                {
                    txtMinPrDay.Text = "0";
                    txtMinAllWorkorder.Text = "0";
                }
            }
        }
        int EditNum;
        private void txtEditNum_TextChanged(object sender, EventArgs e)
        {
            if (FirstRun)
            {
                EditNum = int.Parse(txtEditNum.Text);
                return;
            }
            if (txtEditNum.TextLength > 0)
            {
                int ee = int.Parse(txtEditNum.Text);
                if (EditNum + 1 == ee)
                {
                    WMont.EditNum = ee;
                    WYear.EditNum = ee;
                    Wtrail.EditNum = ee;
                    txtEditText.Clear();
                    txtEditText.Focus();
                }
                else
                {
                    if (EditNum < ee)
                    {
                        txtEditNum.Text = (EditNum + 1).ToString();
                        return;
                    }
                    else
                    {
                        if (EditNum != ee)
                        {
                            txtEditText.Text = "بدون ویرایش";
                            MessageBox.Show("شماره ویرایش جدید نمیتواند از شماره ویرایش قبلی کمتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            txtEditNum.Text = EditNum.ToString();
                            return;
                        }
                    }
                }
            }
        }
        public bool Edited = false;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("آیا از ویرایش اطلاعات اطمینان دارید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                return;

            if (checkData())
            {
                LINQDataContext DataBase = new LINQDataContext();
                string Mes = "";
                if (WMontEdit)
                {
                    if (WMont.EditNum > EditNum)
                    {
                        var conf = (from s in DataBase.WorkOrderConfirmations
                                    where s.ID == WMont.ID
                                    select s).SingleOrDefault();
                        if (conf != null)
                        {

                            if (Fastcod.kind == "G")
                            {
                                conf.OP3Condition = false;
                                conf.OP4Condition = false;
                            }
                            else
                            {
                                conf.OP1Condition = false;
                                conf.OP2Condition = false;
                                conf.OP3Condition = false;
                                conf.OP4Condition = false;
                            }
                        }
                        WMont.Confirmation = false;
                    }
                    var sst = (from s in DataBase.WorkOrderMonths where s.uid == WMont.uid select s).SingleOrDefault();
                    if (sst.DayStart != WMont.DayStart || sst.DayFinish != WMont.DayFinish)
                    {
                        var tt = from s in DataBase.TemplateAgends where s.WorkOrderIDNew == WMont.ID && s.Year == WMont.Year select s.uid;
                        if (tt.Count() > 0)
                        {
                            TemplateAgend template = (from s in DataBase.TemplateAgends where s.uid == tt.Max() select s).SingleOrDefault();
                            template.Request = false;
                            template.AcceptOP = 0;
                            template.AcceptTime = null;
                        }
                    }

                    Mes = "N-" + WMont.ID;
                }
                else
                {
                    if (WtrailEdit)
                    {
                        if (txtDescription.TextLength == 0)
                            Wtrail.Description = "ندارد";

                        Mes = "E-" + Wtrail.ID;
                    }
                    else
                    {
                        if (WtrailEdit)
                        {
                            if (txtDescription.TextLength == 0)
                                WYear.Description = "ندارد";
                            Mes = "P-" + WYear.ID;
                        }
                    }
                }
                try
                {
                    DataBase.SubmitChanges();
                    DBEdit.SubmitChanges();
                    Edited = true;
                    MessageBox.Show("دستور کار " + Mes + " با موفقیت ویرایش شد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information, MessageBoxDefaultButton.Button1, MessageBoxOptions.RtlReading);
                    this.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("اطلاعات به دلیل" + ex.Message + "ثبت نشد لطفا با پشتیبان نرم افزار تماس بگیرید");
                }
            }
        }
        public bool Delete = false;
        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ایا مایل به حذف دستور کار هستید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                LINQDataContext db = new LINQDataContext();
                if (WYearEdit)
                {
                    var t = (from s in db.WorkOrderYears
                             where s.uid == WYear.uid
                             select s).SingleOrDefault();
                    if (t != null)
                    {
                        db.WorkOrderYears.DeleteOnSubmit(t);
                        try
                        {
                            db.SubmitChanges();
                            MessageBox.Show("دستور کار با موفقیت حذف شد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            Delete = true;
                            this.Close();
                            return;
                        }
                        catch (Exception) { }
                    }
                }
                else
                {
                    if (WtrailEdit)
                    {
                        bool delete = false;
                        switch (Kind)
                        {
                            case "GR":
                                var GRtmp = from s in db.GranuleDatas
                                            where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month &&
                                            (s.Day >= WMont.DayStart && s.Day <= WMont.DayFinish)
                                            select s;
                                if (GRtmp.Count() > 0)
                                {
                                    MessageBox.Show("برای این دستور کار فرم ثبت شده و نمیتوان آن را حذف کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (MessageBox.Show("آیا از حذف دستور کار اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        delete = true;
                                }
                                else
                                {
                                    delete = true;
                                }
                                break;
                            case "PR":
                                var PRtmp = from s in db.ProductionDatas
                                            where s.ProdectionCode == WMont.ProdectionCode && s.TypeOfTolid == 2 && s.Year == WMont.Year && s.Month == WMont.Month && s.TemplateNum == WMont.TemplateNum &&
                                            (s.Day >= WMont.DayStart && s.Day <= WMont.DayFinish)
                                            select s;
                                if (PRtmp.Count() > 0)
                                {
                                    MessageBox.Show("برای این دستور کار تعداد " + PRtmp.Count().ToString() + " فرم ثبت شده و نمیتوان آن را حذف کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (MessageBox.Show("آیا از حذف دستور کار اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        delete = true;
                                }
                                else
                                {
                                    delete = true;
                                }
                                break;
                            case "AS":
                                var AStmp = from s in db.AssemblyDatas
                                            where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month &&
                                            (s.Day >= WMont.DayStart && s.Day <= WMont.DayFinish)
                                            select s;
                                if (AStmp.Count() > 0)
                                {
                                    MessageBox.Show("برای این دستور کار فرم ثبت شده و نمیتوان آن را حذف کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (MessageBox.Show("آیا از حذف دستور کار اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        delete = true;
                                }
                                else
                                {
                                    delete = true;
                                }
                                break;

                            default:
                                break;
                        }

                        if (delete)
                        {
                            var t = (from s in db.WorkOrderTrails
                                     where s.uid == Wtrail.uid
                                     select s).SingleOrDefault();

                            if (t != null)
                            {

                                db.WorkOrderTrails.DeleteOnSubmit(t);

                                try
                                {
                                    db.SubmitChanges();
                                    MessageBox.Show("دستور کار با موفقیت حذف شد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Delete = true;
                                    this.Close();
                                    return;
                                }
                                catch (Exception) { }
                            }
                        }

                    }
                    else
                    {
                        bool delete = false;
                        switch (Kind)
                        {
                            case "GR":
                                var GRtmp = from s in db.GranuleDatas
                                            where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month &&
                                            (s.Day >= WMont.DayStart && s.Day <= WMont.DayFinish)
                                            select s;
                                if (GRtmp.Count() > 0)
                                {
                                    MessageBox.Show("برای این دستور کار فرم ثبت شده و نمیتوان آن را حذف کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (MessageBox.Show("آیا از حذف دستور کار اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        delete = true;
                                }
                                else
                                {
                                    delete = true;
                                }
                                break;
                            case "PR":
                                var PRtmp = from s in db.ProductionDatas
                                            where s.ProdectionCode == WMont.ProdectionCode && s.TypeOfTolid == 1 && s.Year == WMont.Year && s.Month == WMont.Month && s.TemplateNum == WMont.TemplateNum &&
                                            (s.Day >= WMont.DayStart && s.Day <= WMont.DayFinish)
                                            select s;
                                if (PRtmp.Count() > 0)
                                {
                                    MessageBox.Show("برای این دستور کار تعداد " + PRtmp.Count().ToString() + " فرم ثبت شده و نمیتوان آن را حذف کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (MessageBox.Show("آیا از حذف دستور کار اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        delete = true;
                                }
                                else
                                {
                                    delete = true;
                                }
                                break;
                            case "AS":
                                var AStmp = from s in db.AssemblyDatas
                                            where s.ProdectionCode == WMont.ProdectionCode && s.Year == WMont.Year && s.Month == WMont.Month &&
                                            (s.Day >= WMont.DayStart && s.Day <= WMont.DayFinish)
                                            select s;
                                if (AStmp.Count() > 0)
                                {
                                    MessageBox.Show("برای این دستور کار فرم ثبت شده و نمیتوان آن را حذف کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    if (MessageBox.Show("آیا از حذف دستور کار اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button2) == DialogResult.Yes)
                                        delete = true;
                                }
                                else
                                {
                                    delete = true;
                                }
                                break;

                            default:
                                break;
                        }

                        if (delete)
                        {
                            var t = (from s in db.WorkOrderMonths
                                     where s.uid == WMont.uid
                                     select s).SingleOrDefault();

                            if (t != null)
                            {
                                if (WMontEdit)
                                {
                                    var t2 = (from s in db.WorkOrderConfirmations
                                              where s.ID == WMont.ID
                                              select s).SingleOrDefault();
                                    if (t2 != null)
                                    {
                                        db.WorkOrderConfirmations.DeleteOnSubmit(t2);
                                    }
                                }
                                db.WorkOrderMonths.DeleteOnSubmit(t);

                                var tt = from s in db.TemplateAgends where s.WorkOrderIDNew == t.ID && s.Year == t.Year select s.uid;
                                if (tt.Count() > 0)
                                {
                                    TemplateAgend template = (from s in db.TemplateAgends where s.uid == tt.Max() && s.Year == t.Year select s).SingleOrDefault();
                                    db.TemplateAgends.DeleteOnSubmit(template);
                                }
                                try
                                {
                                    db.SubmitChanges();
                                    MessageBox.Show("دستور کار با موفقیت حذف شد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    Delete = true;
                                    this.Close();
                                    return;
                                }
                                catch (Exception)
                                {

                                }
                            }
                        }

                    }
                }
            }
        }

        private void txtEditText_TextChanged(object sender, EventArgs e)
        {
            if (txtEditText.TextLength > 0)
            {
                WMont.EditText = txtEditText.Text;
                WYear.EditText = txtEditText.Text;
                Wtrail.EditText = txtEditText.Text;

            }
            else
            {
                WMont.EditText = "بدون ویرایش";
                WYear.EditText = "بدون ویرایش";
                Wtrail.EditText = "بدون ویرایش";
            }
        }
    }
}

