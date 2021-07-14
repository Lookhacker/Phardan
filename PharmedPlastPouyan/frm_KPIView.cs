using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Telerik.Charting;
using Telerik.WinControls.UI;
using static PharmedPlastPouyan.Utility;

namespace PharmedPlastPouyan
{
    public partial class frm_KPIView : Form
    {
        DataTable AllData;
        DataTable Workorder;
        DataTable StopData;
        string prcode = ""; int template; int Month; int Fasl;
        int chk;
        bool date;
        DataTable dataFilter;
        DataTable StopFilter;
        DataTable WorkFilter;
        DataTable ListPR;
        bool Full = false;

        public frm_KPIView()
        {
            InitializeComponent();

        }
        private void frm_KPIView_Load(object sender, EventArgs e)
        {
            ListPR = CreateTable();
            LINQDataContext DB = new LINQDataContext();
            comMonth.DataSource = ToDataTable(DB.tblBaseDatas.Where(x => x.FK_Parent_uid == 97).ToList());
            comFasl.DataSource = ToDataTable(DB.tblBaseDatas.Where(x => x.FK_Parent_uid == 92).ToList());
            var tt = (from s in DB.WorkOrderMonths
                      where s.MachineNum < 100
                      select new
                      {
                          MachineNum = s.MachineNum
                      }).Distinct().ToList();

            comMachine.DataSource = ToDataTable(tt);
            comMachine.SelectedIndex = -1;
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (BWAllData.IsBusy != true)
            {
                BWAllData.RunWorkerAsync();
            }
        }
        private void radioFasl_CheckedChanged(object sender, EventArgs e)
        {
            if (radioFasl.Checked)
            {
                comFasl.Enabled = true;
                comFasl.SelectedIndex = 0;
                chk = 2;
            }
            else
            {
                comFasl.Enabled = false;
                comFasl.SelectedIndex = -1;
            }
        }
        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonth.Checked)
            {
                comMonth.Enabled = true;
                comMonth.SelectedIndex = 0;
                chk = 1;
            }
            else
            {
                comMonth.Enabled = false;
                comMonth.SelectedIndex = -1;
            }
        }
        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.Shart = "M";
            frm.ShowDialog();
            if (frm.Clicked)
            {
                GetPrdata(frm.PRCode);
                lblPRCode.Text = frm.PRCode;
                lblPRName.Text = frm.PRName;
                prcode = frm.PRCode;
            }
        }
        private void GetPrdata(string prcode)
        {
            try
            {
                LINQDataContext db = new LINQDataContext();
                var a = from u in db.QuickSelects
                        where u.Product_Code == prcode
                        select u;

                if (a.Count() == 1)
                {
                    var tmp = a.Single();
                    var mold = from S in db.Molds
                               where S.IDProtection == tmp.ID
                               select S;


                    if (mold.Count() == 0)
                    {
                        comtemplate.Items.Clear();
                        comtemplate.Enabled = false;
                        comtemplate.SelectedIndex = -1;

                        return;
                    }
                    if (mold.Count() == 1)
                    {
                        int i = int.Parse(mold.First().MoldNum.ToString());
                        comtemplate.Items.Clear();
                        comtemplate.Items.Add(i.ToString());
                        comtemplate.Enabled = false;
                        comtemplate.SelectedIndex = 0;
                    }
                    else
                    {
                        comtemplate.Enabled = true;
                        comtemplate.Items.Clear();
                        foreach (var item in mold)
                            comtemplate.Items.Add(item.MoldNum.ToString());
                        comtemplate.Focus();
                        comtemplate.SelectedIndex = 0;
                    }
                }
                else
                {
                    if (a.Count() > 1)
                    {
                        MessageBox.Show("خطا", "برای کد بیشتر از یک کالا تعریف شده است.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("خطا", "این کالا در لیست وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    comtemplate.Enabled = false;
                    comtemplate.SelectedIndex = -1;
                    lblPRCode.Text = "";
                    lblPRName.Text = "";
                    prcode = "";
                }


            }
            catch (Exception)
            {
                MessageBox.Show("دریافت اطلاعات با خطا مواجه شد مجدد بررسی نمایید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }

        }
        private void chkPR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPR.Checked)
            {
                pnlPR.Height = 200;
                lblPRCode.BackColor = lblPRName.BackColor = System.Drawing.SystemColors.Window;
            }
            else
            {
                pnlPR.Height = 40;
                lblPRCode.BackColor = lblPRName.BackColor = System.Drawing.SystemColors.Control;
            }
            prcode = lblPRCode.Text = lblPRName.Text = "";
            comtemplate.SelectedIndex = -1;
            comtemplate.Enabled = false;
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                pnlDate.Height = 210;
                radioMonth.Checked = true;
                date = true;
            }
            else
            {
                pnlDate.Height = 40;
                radioFasl.Checked = false;
                radioMonth.Checked = false;
                date = false;
            }
        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (BWFilter.IsBusy != true)
            {
                BWFilter.RunWorkerAsync();
            }
        }
        private void Filter()
        {

            bool multi = false;
            string Shart = "";

            if (prcode.Length > 0)
            {
                Shart = "ProdectionCode=" + prcode + " and TemplateNum=" + template;
                multi = true;
            }
            if (date)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }

                switch (chk)
                {
                    case 1:
                        Shart += "Month=" + Month;
                        break;
                    case 2:
                        string str = "";
                        switch (Fasl)
                        {
                            case 1:
                                str = "(Month=1 or Month=2 or Month=3)";
                                break;
                            case 2:
                                str = "(Month=4 or Month=5 or Month=6)";
                                break;
                            case 3:
                                str = "(Month=7 or Month=8 or Month=9)";
                                break;
                            case 4:
                                str = "(Month=10 or Month=11 or Month=12)";
                                break;
                        }
                        Shart += str;
                        break;
                    default:
                        break;

                }
                multi = true;
            }

            if (Machine > 0)
            {
                if (multi)
                {
                    Shart += " and ";
                }
                Shart += "MachineNum=" + Machine.ToString();
            }


            if (Shart == "")
            {
                dataFilter = ToDataTable<View_KPIPR>(AllData.Select());
                StopFilter = ToDataTable<View_KPIPRStop>(StopData.Select());
                WorkFilter = ToDataTable<WorkOrderMonth>(Workorder.Select());
            }
            else
            {
                dataFilter = ToDataTable<View_KPIPR>(AllData.Select(Shart));
                StopFilter = ToDataTable<View_KPIPRStop>(StopData.Select(Shart));
                WorkFilter = ToDataTable<WorkOrderMonth>(Workorder.Select(Shart));
            }

            ListPR = CreateTable();
            foreach (var item in WorkFilter.Select())
            {
                if (ListPR.Select("ProdectionCode=" + item["ProdectionCode"].ToString() + " and TemplateNum=" + item["TemplateNum"].ToString()).Count() == 0)
                {

                    DataRow DR = ListPR.NewRow();
                    DR["ProdectionCode"] = item["ProdectionCode"].ToString();
                    DR["ProdectionName"] = item["ProdectionName"].ToString();
                    DR["TemplateNum"] = item["TemplateNum"].ToString();
                    ListPR.Rows.Add(DR);
                }
            }



        }
        private void BWAllData_DoWork(object sender, DoWorkEventArgs e)
        {
            LINQDataContext DB = new LINQDataContext();
            AllData = ToDataTable(DB.View_KPIPRs.ToList());
            StopData = ToDataTable(DB.View_KPIPRStops.ToList());
            var tmp = from s in DB.WorkOrderMonths
                      join a in DB.QuickSelects on s.ProdectionCode equals a.Product_Code
                      where a.kind == "m" && s.Confirmation == true
                      select s;
            Workorder = ToDataTable(tmp.ToList());
        }
        private void BWAllData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
        }
        private void comtemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comtemplate.SelectedIndex < 0)
                template = 0;
            else
                template = int.Parse(comtemplate.SelectedItem.ToString());
        }
        private void comMonth_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comMonth.SelectedIndex < 0)
                Month = 0;
            else
                Month = int.Parse(comMonth.SelectedValue.ToString());
        }
        private void comFasl_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comFasl.SelectedIndex < 0)
                Fasl = 0;
            else
                Fasl = int.Parse(comFasl.SelectedValue.ToString());
        }
        private void BWFilter_DoWork(object sender, DoWorkEventArgs e)
        {
            //System.Threading.Thread.Sleep(2000);
            Filter();
        }
        private void BWFilter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            try
            {

                radWaitingBar1.StopWaiting();
                radWaitingBar1.Visible = false;

                lbl1.Text = " تعداد فرم های ثبت شده =  " + dataFilter.Rows.Count;
                lbl1.Text += "\nدستور کار های صادر شده = " + WorkFilter.Rows.Count;
                lbl1.Text += "\nتعداد محصولات = " + ListPR.Rows.Count;



                int Part = dataFilter.AsEnumerable().Sum(x => x.Field<int>("AllPart"));
                int permin = WorkFilter.AsEnumerable().Sum(x => x.Field<int>("MinAllWorkorder"));
                lbl1.Text += "\nتعداد قطعات سالم تولید شده \n " + Part.ToString();
                lbl1.Text += "\nتعداد مورد انتظار = " + permin.ToString();

                double s = Convert.ToDouble((Convert.ToDouble(Part) / Convert.ToDouble(permin)) * 100);
                if (s.ToString() == "NaN" || s == 0)
                {
                    s = 0;
                    lbl1.Text += "\nدرصد محقق شده = % " + 0;
                    SendGaugePresent(0);
                }
                else
                {
                    lbl1.Text += "\nدرصد محقق شده = % " + s.ToString("#.###");
                    if (s >= 100)
                    {
                        SendGaugePresent(100);
                    }
                    else
                    {
                        SendGaugePresent(s);
                    }
                }

                if (s >= 100 || s == 0)
                {
                    if (chkPresent.Checked)
                    {
                        ChartStopAll.Series.Clear();
                        ChartStopAll.Title = "";
                        ChartStopAll.Refresh();
                        ChartStopDeatial.Series.Clear();
                        ChartStopDeatial.Title = "";
                        ChartStopDeatial.Refresh();
                        SendGaugeGhaleb(dataFilter, 0, 0);
                        SendGaugeMachine(dataFilter, 0, 0);
                        SendPieChartStop(CreateTable<View_KPIPRStop>());

                        return;
                    }
                }

                int Tolid = 0;
                int Fani = 0;
                int Ghaleb = 0;
                int RQ = 0;
                int Sanaye = 0;
                int UTI = 0;
                Tolid = StopFilter.Select("ParrentID=1").Sum(x => int.Parse(Math.Round((double.Parse(x["StopTime"].ToString()) * 60 * double.Parse(x["ActiveKaviteh"].ToString())) / double.Parse(x["CycleTime"].ToString())).ToString()));
                Fani = StopFilter.Select("ParrentID=2").Sum(x => int.Parse(Math.Round((double.Parse(x["StopTime"].ToString()) * 60 * double.Parse(x["ActiveKaviteh"].ToString())) / double.Parse(x["CycleTime"].ToString())).ToString()));
                Ghaleb = StopFilter.Select("ParrentID=4").Sum(x => int.Parse(Math.Round((double.Parse(x["StopTime"].ToString()) * 60 * double.Parse(x["ActiveKaviteh"].ToString())) / double.Parse(x["CycleTime"].ToString())).ToString()));
                RQ = StopFilter.Select("ParrentID=5").Sum(x => int.Parse(Math.Round((double.Parse(x["StopTime"].ToString()) * 60 * double.Parse(x["ActiveKaviteh"].ToString())) / double.Parse(x["CycleTime"].ToString())).ToString()));
                Sanaye = StopFilter.Select("ParrentID=6").Sum(x => int.Parse(Math.Round((double.Parse(x["StopTime"].ToString()) * 60 * double.Parse(x["ActiveKaviteh"].ToString())) / double.Parse(x["CycleTime"].ToString())).ToString()));
                UTI = StopFilter.Select("ParrentID=9").Sum(x => int.Parse(Math.Round((double.Parse(x["StopTime"].ToString()) * 60 * double.Parse(x["ActiveKaviteh"].ToString())) / double.Parse(x["CycleTime"].ToString())).ToString()));

                lbl1.Text += "\nقطعات از دست رفته :";
                lbl1.Text += "\nتولید = " + Tolid.ToString();
                lbl1.Text += "\nفنی = " + Fani.ToString();
                lbl1.Text += "\nقالب = " + Ghaleb.ToString();
                lbl1.Text += "\nتحقیق و توسعه و تضمین کیفیت = " + RQ.ToString();
                lbl1.Text += "\nصنایع = " + Sanaye.ToString();
                lbl1.Text += "\nسایر= " + UTI.ToString();

                SendPieChartStop(StopFilter);
                SendGaugeGhaleb(dataFilter, (Tolid + Fani + Ghaleb + RQ + Sanaye + UTI), Ghaleb);
                SendChartTemplate();
                SendGaugeMachine(dataFilter, (Tolid + Fani + Ghaleb + RQ + Sanaye + UTI), Fani);
                SendChartMachine();
                SendGaugeWastage(dataFilter);
                SendChartWastage();
            }
            catch (Exception ex)
            {
                MessageBox.Show("خطا در بارگزاری اطلاعات مجدادا تلاش نمایید.\n" + ex.Message);
                //throw;
            }
        }

        private void SendChartPresent()
        {
            BarSeries mmp = new BarSeries();
            mmp.ValueMember = "Value";
            mmp.DisplayMember = "Value";
            mmp.CategoryMember = "PRName";
            mmp.ShowLabels = true;
            mmp.LabelRotationAngle = 310;
            mmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            
            chartPres.AreaType = ChartAreaType.Cartesian;
            chartPres.Axes[0].LabelRotationAngle = 300;
            chartPres.Axes[0].LabelFitMode = AxisLabelFitMode.Rotate;

            chartPres.Series.Clear();
            chartPres.Series.Add(mmp);
            chartPres.Title = "درصد محقق شده";
        }
        private void SendChartMachine()
        {
            BarSeries mmp = new BarSeries();
            mmp.ValueMember = "Value";
            mmp.DisplayMember = "Value";
            mmp.CategoryMember = "PRName";
            mmp.ShowLabels = true;
            mmp.LabelRotationAngle = 310;
            mmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
           
            chartMachine.AreaType = ChartAreaType.Cartesian;
            chartMachine.Axes[0].LabelRotationAngle = 300;
            chartMachine.Axes[0].LabelFitMode = AxisLabelFitMode.Rotate;

            chartMachine.Series.Clear();
            chartMachine.Series.Add(mmp);
            chartMachine.Title = "در دسترس بودن ماشین";
        }
        private void SendChartTemplate()
        {
            BarSeries mmp = new BarSeries();
            mmp.ValueMember = "Value";
            mmp.DisplayMember = "Value";
            mmp.CategoryMember = "PRName";
            mmp.ShowLabels = true;
            mmp.LabelRotationAngle = 310;
            mmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
           
            chartGhaleb.AreaType = ChartAreaType.Cartesian;
            chartGhaleb.Axes[0].LabelRotationAngle = 300;
            chartGhaleb.Axes[0].LabelFitMode = AxisLabelFitMode.Rotate;

            chartGhaleb.Series.Clear();
            chartGhaleb.Series.Add(mmp);
            chartGhaleb.Title = "در دسترس بودن قالب";
        }
        private void SendChartWastage()
        {
            BarSeries mmp = new BarSeries();
            mmp.ValueMember = "Value";
            mmp.DisplayMember = "Value";
            mmp.CategoryMember = "PRName";
            mmp.ShowLabels = true;
            mmp.LabelRotationAngle = 310;
            mmp.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            
            ChartWastage.AreaType = ChartAreaType.Cartesian;
            ChartWastage.Axes[0].LabelRotationAngle = 300;
            ChartWastage.Axes[0].LabelFitMode = AxisLabelFitMode.Rotate;

            ChartWastage.Series.Clear();
            ChartWastage.Series.Add(mmp);
            ChartWastage.Title = "درصد ضایعات";
        }

        private void SendGaugeWastage(DataTable Table)
        {
            double All = Table.Select().Sum(x => double.Parse(x["AllPart"].ToString()));
            double Wastage = Table.Select().Sum(x => double.Parse(x["Wastage"].ToString()));
            gaugeWastage.Visible = true;
            Wastag = (Wastage / All) * 100;
            if (All == 0)
                if (Wastag.ToString() == "NaN")
                    Wastag = 0;
                else
                    Wastag = 100;

            gaugeWastage.RangeEnd = 5;
            while (Wastag > gaugeWastage.RangeEnd)
            {
                gaugeWastage.RangeEnd += 5;
            }
            timer4.Enabled = true;

        }
        private void SendGaugeMachine(DataTable Table, int AllWastege, int FaniWastage)
        {
            int sumAll = Table.Select().Sum(x => int.Parse(x["AllPart"].ToString()) + int.Parse(x["Wastage"].ToString()));
            double Presless = (Convert.ToDouble(FaniWastage) / (AllWastege + sumAll)) * 100;
            int A = 100;
            if (Presless.ToString() != "NaN")
                A = int.Parse(Math.Round(Presless).ToString());
            gaugeMachine.Visible = true;
            Machh = 100 - A;
            timer3.Enabled = true;
        }
        private DataTable CreateTable()
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("ProdectionCode");
            temp.Columns.Add("ProdectionName");
            temp.Columns.Add("TemplateNum");


            return temp;
        }
        private void SendPieChartStop(DataTable Table)
        {
            DonutSeries donat = new DonutSeries();
            donat.ValueMember = "Value";
            donat.DisplayMember = "StopTitle";
            donat.ShowLabels = true;
            donat.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
      

            ChartStopAll.Views.AddNew("mmp");


            DrillDownController controller = new DrillDownController();
            ChartStopAll.Controllers.Add(controller);
            ChartStopAll.Series.Clear();
            ChartStopAll.Series.Add(donat);
            ChartStopAll.View.Margin = new Padding(0, 28, 0, 26);

            ChartStopAll.ShowTrackBall = false;
            ChartStopAll.Title = "تمام توقفات";
           
            
        }
        private void SendGaugeGhaleb(DataTable Table, int AllWastege, int GhalebWastage)
        {
            int sumAll = Table.Select().Sum(x => int.Parse(x["AllPart"].ToString()) + int.Parse(x["Wastage"].ToString()));
            double Presless = (Convert.ToDouble(GhalebWastage) / (AllWastege + sumAll)) * 100;
            int A = 100;
            if (Presless.ToString() != "NaN")
                A = int.Parse(Math.Round(Presless).ToString());
            gaugeGhaleb.Visible = true;
            gaduge = 100 - A;
            timer1.Enabled = true;
        }
        private void SendGaugePresent(double Value)
        {
            Mohaghagh = int.Parse(Math.Round(Value).ToString());
            gaugePres.Visible = true;
            SendChartPresent();
            timer2.Enabled = true;
        }
        private void Keypres(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void FullScreen(int v)
        {
            if (Full)
            {
                pnlTop.Dock = pnlCenter.Dock = pnlDown.Dock = pnlTL.Dock = pnlTC.Dock = pnlTR.Dock = pnlCL.Dock =
                pnlCC.Dock = pnlCR.Dock = pnlDL.Dock = pnlDC.Dock = pnlDR.Dock = DockStyle.None;

                pnlTop.Visible = pnlCenter.Visible = pnlDown.Visible = pnlTL.Visible = pnlTC.Visible = pnlTR.Visible =
                pnlCL.Visible = pnlCC.Visible = pnlCR.Visible = pnlDL.Visible = pnlDC.Visible = pnlDR.Visible = true;

                pnlDown.Dock = DockStyle.Bottom;
                pnlCenter.Dock = DockStyle.Bottom;
                pnlDR.Dock = DockStyle.Right;
                pnlDC.Dock = DockStyle.Right;
                pnlDL.Dock = DockStyle.Fill;
                pnlTop.Dock = DockStyle.Fill;
                pnlCR.Dock = DockStyle.Right;
                pnlCC.Dock = DockStyle.Right;
                pnlCL.Dock = DockStyle.Fill;
                pnlTR.Dock = DockStyle.Right;
                pnlTC.Dock = DockStyle.Right;
                pnlTL.Dock = DockStyle.Fill;
                Full = false;
            }
            else
            {
                Full = true;
                pnlTop.Visible = pnlCenter.Visible = pnlDown.Visible = pnlTL.Visible = pnlTC.Visible = pnlTR.Visible =
               pnlCL.Visible = pnlCC.Visible = pnlCR.Visible = pnlDL.Visible = pnlDC.Visible = pnlDR.Visible = false;

                pnlTop.Dock = pnlCenter.Dock = pnlDown.Dock = pnlTL.Dock = pnlTC.Dock = pnlTR.Dock = pnlCL.Dock =
                pnlCC.Dock = pnlCR.Dock = pnlDL.Dock = pnlDC.Dock = pnlDR.Dock = DockStyle.None;


                switch (v)
                {
                    case 1:
                        pnlTop.Visible = pnlTL.Visible = true;
                        pnlTop.Dock = pnlTL.Dock = DockStyle.Fill;
                        break;
                    case 2:
                        pnlTop.Visible = pnlTC.Visible = true;
                        pnlTop.Dock = pnlTC.Dock = DockStyle.Fill;
                        break;
                    case 3:
                        pnlTop.Visible = pnlTR.Visible = true;
                        pnlTop.Dock = pnlTR.Dock = DockStyle.Fill;
                        break;
                    case 4:
                        pnlCenter.Visible = pnlCL.Visible = true;
                        pnlCenter.Dock = pnlCL.Dock = DockStyle.Fill;
                        break;
                    case 5:
                        pnlCenter.Visible = pnlCC.Visible = true;
                        pnlCenter.Dock = pnlCC.Dock = DockStyle.Fill;
                        break;
                    case 6:
                        pnlCenter.Visible = pnlCR.Visible = true;
                        pnlCenter.Dock = pnlCR.Dock = DockStyle.Fill;
                        break;
                    case 7:
                        pnlDown.Visible = pnlDL.Visible = true;
                        pnlDown.Dock = pnlDL.Dock = DockStyle.Fill;
                        break;
                    case 8:
                        pnlDown.Visible = pnlDC.Visible = true;
                        pnlDown.Dock = pnlDC.Dock = DockStyle.Fill;
                        break;
                    case 9:
                        pnlDown.Visible = pnlDR.Visible = true;
                        pnlDown.Dock = pnlDR.Dock = DockStyle.Fill;
                        break;
                }
            }
        }
        private void ChartStopAll_Drill(object sender, DrillEventArgs e)
        {
            int sum = 0;
            DonutSeries donat = new DonutSeries();
            donat.ValueMember = "Value";
            donat.DisplayMember = "StopTitle";
            donat.ShowLabels = true;
            AngleRange range = donat.Range;
            range.StartAngle = 0;
            donat.Range = range;
            donat.Font = new System.Drawing.Font("B Nazanin", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
            string sss = "";
            

            ChartStopDeatial.Views.AddNew("mmp");
            ChartStopDeatial.Series.Clear();
            ChartStopDeatial.Title = "توقفات " + sss;
            ChartStopDeatial.Title += " -  " + sum + " دقیقه";


            donat.DrawLinesToLabels = true;
            donat.SyncLinesToLabelsColor = false;
            ChartStopDeatial.Series.Add(donat);
            ChartStopDeatial.ShowTrackBall = false;
        }
        private void ChartStopAll_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(9);
            if (Full)
            {
                pnlDR.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
            }
            else
            {
                pnlDR.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            }
        }
        private void ChartStopDeatial_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(8);
            if (Full)
            {
                pnlDC.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
            }
            else
            {
                pnlDC.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            }
        }
        private void chartGhaleb_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(4);
            if (Full)
            {
                pnlCL.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
            }
            else
            {
                pnlCL.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            }
        }

        int gaduge = 0;
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (mmpView.Value < gaduge)
            {

                digitalGhaleb.LabelText = (++mmpView.Value).ToString(); ;
            }
            else
            {
                if (mmpView.Value > gaduge)
                    digitalGhaleb.LabelText = (--mmpView.Value).ToString();
                else
                {
                    mmpView.Value = gaduge;
                    digitalGhaleb.LabelText = gaduge.ToString();
                    timer1.Enabled = false;
                }
            }
        }
        int Mohaghagh = 0;
        private void timer2_Tick(object sender, EventArgs e)
        {
            if (gaugePres.Value < Mohaghagh)
                mmp2.RangeEnd = mmp3.RangeStart = ++gaugePres.Value;
            else
            {
                if (gaugePres.Value > Mohaghagh)
                    mmp2.RangeEnd = mmp3.RangeStart = --gaugePres.Value;
                else
                {
                    timer2.Enabled = false;
                    timer2.Interval = 10;
                }
            }
        }

        private void gaugePres_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(3);
            if (Full)
            {
                pnlTR.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
                gaugePres.Enabled = false;
                gaugePres.Visible = false;
                gaugePres.Dock = DockStyle.None;

                chartPres.Enabled = true;
                chartPres.Visible = true;
                chartPres.Dock = DockStyle.Fill;

            }

        }

        private void ChartStopAll_SelectedPointChanged(object sender, ChartViewSelectedPointChangedEventArgs args)
        {
            UpdadateOffsetFromCenter(args.OldSelectedPoint as PieDataPoint);
            UpdadateOffsetFromCenter(args.NewSelectedPoint as PieDataPoint);
        }

        private void UpdadateOffsetFromCenter(PieDataPoint point)
        {
            if (point != null)
            {
                point.OffsetFromCenter = point.IsSelected ? 0.1 : 0;
            }
        }

        private void ChartStopDeatial_LabelFormatting(object sender, ChartViewLabelFormattingEventArgs e)
        {
            e.LabelElement.BorderColor = Color.Black;
            e.LabelElement.BackColor = Color.White;
            e.LabelElement.BorderWidth = 1;
            //e.LabelElement.ResetValue(LabelElement.BorderWidthProperty, Telerik.WinControls.ValueResetFlags.Local);
            //e.LabelElement.ResetValue(LabelElement.BackColorProperty, Telerik.WinControls.ValueResetFlags.Local);
        }

        private void chkMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMachine.Checked)
            {
                pnlMachnie.Height = 100;
                comMachine.SelectedIndex = 0;
            }
            else
            {
                pnlMachnie.Height = 40;
                comMachine.SelectedIndex = -1;
            }
        }
        int Machine = 0;

        private void comMachine_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comMachine.SelectedIndex < 0)
            {
                Machine = 0;
            }
            else
            {
                Machine = int.Parse(comMachine.SelectedValue.ToString());
            }
        }
        int Machh = 0;
        private void timer3_Tick(object sender, EventArgs e)
        {
            if (mmpview2.Value < Machh)
                digitalMachine.LabelText = (++mmpview2.Value).ToString();
            else
            {
                if (mmpview2.Value > Machh)
                    digitalMachine.LabelText = (--mmpview2.Value).ToString();
                else
                {
                    mmpview2.Value = Machh;
                    digitalMachine.LabelText = Machh.ToString();
                    timer3.Enabled = false;
                }
            }
        }

        private void gaugeGhaleb_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(6);
            if (Full)
            {
                pnlCR.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
                gaugeGhaleb.Enabled = false;
                gaugeGhaleb.Visible = false;
                gaugeGhaleb.Dock = DockStyle.None;

                chartGhaleb.Enabled = true;
                chartGhaleb.Visible = true;
                chartGhaleb.Dock = DockStyle.Fill;
            }
        }

        private void gaugeMachine_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(5);
            if (Full)
            {
                pnlCC.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
                gaugeMachine.Enabled = false;
                gaugeMachine.Visible = false;
                gaugeMachine.Dock = DockStyle.None;

                chartMachine.Enabled = true;
                chartMachine.Visible = true;
                chartMachine.Dock = DockStyle.Fill;
            }
        }

        double Wastag = 0;
        private void timer4_Tick(object sender, EventArgs e)
        {
            int s = Convert.ToInt32(Wastag);
            int tmp = Convert.ToInt32(gaugeWastage.Value);
            if (tmp < s)
                gaugeWastage.Value += float.Parse("0.2");
            else
            {
                if (tmp > s)
                    gaugeWastage.Value--;
                else
                {
                    gaugeWastage.Value = float.Parse(Wastag.ToString());
                    timer4.Enabled = false;
                }
            }
        }

        private void gaugeWastage_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(7);
            if (Full)
            {
                pnlDL.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
                gaugeWastage.Enabled = false;
                gaugeWastage.Visible = false;
                gaugeWastage.Dock = DockStyle.None;

                ChartWastage.Enabled = true;
                ChartWastage.Visible = true;
                ChartWastage.Dock = DockStyle.Fill;
            }
            else
            {
                pnlDL.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            }
        }

        private void radChartView4_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(2);
            if (Full)
            {
                pnlTC.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround2;
            }
            else
            {
                pnlTC.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
            }
        }

        private void chartPres_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(3);
            if (Full == false)
            {
                pnlTR.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
                gaugePres.Enabled = true;
                gaugePres.Visible = true;
                gaugePres.Dock = DockStyle.Fill;

                chartPres.Enabled = false;
                chartPres.Visible = false;
                chartPres.Dock = DockStyle.None;
            }
        }

        private void chartGhaleb_DoubleClick_1(object sender, EventArgs e)
        {
            FullScreen(6);
            if (Full == false)
            {
                pnlCR.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
                chartGhaleb.Enabled = false;
                chartGhaleb.Visible = false;
                chartGhaleb.Dock = DockStyle.None;

                gaugeGhaleb.Enabled = true;
                gaugeGhaleb.Visible = true;
                gaugeGhaleb.Dock = DockStyle.Fill;
            }
        }

        private void chartMachine_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(5);
            if (Full == false)
            {
                pnlCC.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
                chartMachine.Enabled = false;
                chartMachine.Visible = false;
                chartMachine.Dock = DockStyle.None;

                gaugeMachine.Enabled = true;
                gaugeMachine.Visible = true;
                gaugeMachine.Dock = DockStyle.Fill;
            }
        }

        private void ChartWastage_DoubleClick(object sender, EventArgs e)
        {
            FullScreen(7);
            if (Full == false)
            {
                pnlDL.BackgroundImage = global::PharmedPlastPouyan.Properties.Resources.panelbackGround;
                ChartWastage.Enabled = false;
                ChartWastage.Visible = false;
                ChartWastage.Dock = DockStyle.None;

                gaugeWastage.Enabled = true;
                gaugeWastage.Visible = true;
                gaugeWastage.Dock = DockStyle.Fill;
            }
        }
    }
}