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
    public partial class frmChartViewAS : Form
    {
        public frmChartViewAS()
        {
            FirstRun = true;
            InitializeComponent();
        }

        DataAccess Data = new DataAccess();
        int NumberOfViewChart = 0;
        bool viewTable = false;
        int scroll; bool UpDown; bool LeftRight; bool FirstRun;


        private void frmChartView_Load(object sender, EventArgs e)
        {
            comTitle.DataSource = Data.Select("select * from ChartTitleAS where ParentID=1 order by Tartib ASC");
            FirstRun = false;
            pnlChekBox.Height = SizeCheckBox();
            UpDown = true;
            LeftRight = false;
            radioTable.Checked = true;
        }
        private void btnChartView_Click(object sender, EventArgs e)
        {
            if (radioChart.Checked)
            {
                ViewChart();
            }
            else
            {
                TableView();
            }
            btnDownUp_Click(null, null);
        }

        #region Code for Chart

        //data type

        string ChartSortInt;
        string ChartSortString;
        //class

        private DataTable ChartData(string strColumn, string TypeRes, string strRow, int NumberLine, string Code)
        {

            DataTable Temp1 = new DataTable();
            if (strColumn == "" || TypeRes == "")
            {
                return Temp1;
            }
            try
            {
                Temp1.Columns.Add("Category");

                for (int i = 1; i <= NumberLine; i++)
                {
                    Temp1.Columns.Add("Value" + i);
                }

                string temp = "";
                if (strRow == "Day")
                    for (int i = 0; i < DataAll.Rows.Count; i++)
                    {
                        if (!(temp.Contains(DataAll.Rows[i]["Month"].ToString() + "-" + DataAll.Rows[i][strRow].ToString())))
                            temp += DataAll.Rows[i]["Month"].ToString() + "-" + DataAll.Rows[i][strRow].ToString() + "*";
                    }
                else
                    for (int i = 0; i < DataAll.Rows.Count; i++)
                    {
                        if (!(temp.Contains(DataAll.Rows[i][strRow].ToString())))
                            temp += DataAll.Rows[i][strRow].ToString() + "*";
                    }

                String[] Temp2 = temp.Split('*');
                String[] Code2 = Code.Split('-');

                string qwe;
                string ewq;

                for (int i = 0; i < Temp2.Length - 1; i++)//بازه زمانی
                {
                    DataRow DR = Temp1.NewRow();
                    DR["Category"] = Temp2[i].ToString();
                    for (int x = 0; x < NumberLine; x++)//خط
                    {
                        double a = 0;
                        String[] Col = strColumn.Split('+');
                        for (int u = 0; u < Col.Length; u++)//جمع کل تعداد ها
                        {
                            qwe = TypeRes + "(" + Col[u] + ")";
                            if (strRow == "Day")
                            {
                                String[] aaa = Temp2[i].Split('-');
                                ewq = "Month=" + aaa[0] + " AND Day=" + aaa[1] + " AND ProdectionCode=" + Code2[x];
                            }
                            else
                                ewq = strRow + " = " + Temp2[i] + " AND ProdectionCode=" + Code2[x];

                            string mm = DataAll.Compute(qwe, ewq).ToString();
                            if (mm != "")
                                a += Convert.ToDouble(DataAll.Compute(qwe, ewq));

                        }
                        a = Math.Round(a, 2);
                        DR["Value" + (x + 1)] = a;
                    }
                    Temp1.Rows.Add(DR);
                }

            }
            catch (Exception)
            {
                MessageBox.Show("نمایش اطلاعات با خطا مواجه شد مجدادا تلاش کنید", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Information);
                Temp1 = null;
                return null;
            }

            if (Temp1.Rows.Count == 1)
                Temp1.TableName = "Point";
            else
                Temp1.TableName = "Line";

            return Temp1;

        }
        private void chart1(string strlist, string strlist2, String[] PRname, int send, string temp, string SplitTime)
        {
            DataTable DT1;
            DT1 = ChartData(Data.SelectOneCol("ChartTitleAS", "ID", strlist, "Result"), Data.SelectOneCol("ChartTitleAS", "ID", strlist, "TypeResult"), SplitTime, send, temp);
            for (int i = ChartView1.Series.Count; i > 0; i--)
            {
                ChartView1.Series.RemoveAt(i - 1);
            }
            if (ChartView1.Legends.Count == 1)
                ChartView1.Legends.RemoveAt(0);
            ChartView1.Titles[0].Text = "";
            if (DT1.TableName == "Line")
            {
                if (DT1.Columns.Count == 2)
                {
                    ChartView1.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                }
                else
                {
                    ChartView1.Titles[0].Text = "نمودار " + strlist2;
                    ChartView1.Legends.Add("Leg1");
                    ChartView1.Legends[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView1.Legends[0].DockedToChartArea = "ChartArea1";
                }
                for (int i = 0; i < send; i++)
                {
                    ChartView1.Series.Add(PRname[i]);
                    ChartView1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    ChartView1.Series[i].BorderWidth = 5;
                    ChartView1.Series[i].IsValueShownAsLabel = true;
                    ChartView1.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].YValueMembers = "Value" + (i + 1);
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                }
            }
            else
            {
                ChartView1.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                for (int i = 0; i < send; i++)
                {
                    ChartView1.Series.Add("A" + (i + 1));
                    ChartView1.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    ChartView1.Series[i].IsValueShownAsLabel = true;
                    ChartView1.Series[i].MarkerSize = 10;
                    ChartView1.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                    ChartView1.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView1.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }

            ChartView1.DataSource = DT1;
            ChartView1.DataBind();

        }
        private void chart2(string strlist, string strlist2, String[] PRname, int send, string temp, string SplitTime)
        {
            DataTable DT2;
            DT2 = ChartData(Data.SelectOneCol("ChartTitleAS", "ID", strlist, "Result"), Data.SelectOneCol("ChartTitleAS", "ID", strlist, "TypeResult"), SplitTime, send, temp);
            for (int i = ChartView2.Series.Count; i > 0; i--)
            {
                ChartView2.Series.RemoveAt(i - 1);
            }
            if (ChartView2.Legends.Count == 1)
                ChartView2.Legends.RemoveAt(0);
            ChartView2.Titles[0].Text = "";
            if (DT2.TableName == "Line")
            {
                if (DT2.Columns.Count == 2)
                {
                    ChartView2.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                }
                else
                {
                    ChartView2.Titles[0].Text = "نمودار " + strlist2;
                    ChartView2.Legends.Add("Leg1");
                    ChartView2.Legends[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView2.Legends[0].DockedToChartArea = "ChartArea1";
                }
                for (int i = 0; i < send; i++)
                {
                    ChartView2.Series.Add(PRname[i]);
                    ChartView2.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    ChartView2.Series[i].BorderWidth = 5;
                    ChartView2.Series[i].IsValueShownAsLabel = true;
                    ChartView2.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView2.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }
            else
            {
                ChartView2.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                for (int i = 0; i < send; i++)
                {
                    ChartView2.Series.Add("A" + (i + 1));
                    ChartView2.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    ChartView2.Series[i].IsValueShownAsLabel = true;
                    ChartView2.Series[i].MarkerSize = 10;
                    ChartView2.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                    ChartView2.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView2.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }

            ChartView2.DataSource = DT2;
            ChartView2.DataBind();

        }
        private void chart3(string strlist, string strlist2, String[] PRname, int send, string temp, string SplitTime)
        {
            DataTable DT3;
            DT3 = ChartData(Data.SelectOneCol("ChartTitleAS", "ID", strlist, "Result"), Data.SelectOneCol("ChartTitleAS", "ID", strlist, "TypeResult"), SplitTime, send, temp);
            for (int i = ChartView3.Series.Count; i > 0; i--)
            {
                ChartView3.Series.RemoveAt(i - 1);
            }
            if (ChartView3.Legends.Count == 1)
                ChartView3.Legends.RemoveAt(0);
            ChartView3.Titles[0].Text = "";
            if (DT3.TableName == "Line")
            {
                if (DT3.Columns.Count == 2)
                {
                    ChartView3.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                }
                else
                {
                    ChartView3.Titles[0].Text = "نمودار " + strlist2;
                    ChartView3.Legends.Add("Leg1");
                    ChartView3.Legends[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView3.Legends[0].DockedToChartArea = "ChartArea1";
                }
                for (int i = 0; i < send; i++)
                {
                    ChartView3.Series.Add(PRname[i]);
                    ChartView3.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    ChartView3.Series[i].BorderWidth = 5;
                    ChartView3.Series[i].IsValueShownAsLabel = true;
                    ChartView3.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView3.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }
            else
            {
                ChartView3.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                for (int i = 0; i < send; i++)
                {
                    ChartView3.Series.Add("A" + (i + 1));
                    ChartView3.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    ChartView3.Series[i].IsValueShownAsLabel = true;
                    ChartView3.Series[i].MarkerSize = 10;
                    ChartView3.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                    ChartView3.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView3.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }

            ChartView3.DataSource = DT3;
            ChartView3.DataBind();

        }
        private void chart4(string strlist, string strlist2, String[] PRname, int send, string temp, string SplitTime)
        {
            DataTable DT4;
            DT4 = ChartData(Data.SelectOneCol("ChartTitleAS", "ID", strlist, "Result"), Data.SelectOneCol("ChartTitleAS", "ID", strlist, "TypeResult"), SplitTime, send, temp);
            for (int i = ChartView4.Series.Count; i > 0; i--)
            {
                ChartView4.Series.RemoveAt(i - 1);
            }
            if (ChartView4.Legends.Count == 1)
                ChartView4.Legends.RemoveAt(0);
            ChartView4.Titles[0].Text = "";
            if (DT4.TableName == "Line")
            {
                if (DT4.Columns.Count == 2)
                {
                    ChartView4.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                }
                else
                {
                    ChartView4.Titles[0].Text = "نمودار " + strlist2;
                    ChartView4.Legends.Add("Leg1");
                    ChartView4.Legends[0].Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView4.Legends[0].DockedToChartArea = "ChartArea1";
                }
                for (int i = 0; i < send; i++)
                {
                    ChartView4.Series.Add(PRname[i]);
                    ChartView4.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
                    ChartView4.Series[i].BorderWidth = 5;
                    ChartView4.Series[i].IsValueShownAsLabel = true;
                    ChartView4.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView4.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }
            else
            {
                ChartView4.Titles[0].Text = "نمودار " + strlist2 + " " + PRname[0];
                for (int i = 0; i < send; i++)
                {
                    ChartView4.Series.Add("A" + (i + 1));
                    ChartView4.Series[i].ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Point;
                    ChartView4.Series[i].IsValueShownAsLabel = true;
                    ChartView4.Series[i].MarkerSize = 10;
                    ChartView4.Series[i].MarkerStyle = System.Windows.Forms.DataVisualization.Charting.MarkerStyle.Circle;
                    ChartView4.Series[i].XValueMember = "Category";
                    ChartView1.Series[i].Font = new System.Drawing.Font("Microsoft Sans Serif", 15F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(178)));
                    ChartView4.Series[i].YValueMembers = "Value" + (i + 1);
                }
            }

            ChartView4.DataSource = DT4;
            ChartView4.DataBind();

        }
        private void ViewChart()
        {
            SizeChartFix();
            String[] strlist = ChartSortInt.Split('-');
            String[] strlist2 = ChartSortString.Split('-');

            string temp = "";
            string PrTemp = "";
            int send = 0;
            for (int i = 0; i < DataAll.Rows.Count; i++)
            {
                if (!(temp.Contains(DataAll.Rows[i]["ProdectionCode"].ToString().TrimEnd())))
                {
                    temp += DataAll.Rows[i]["ProdectionCode"].ToString().TrimEnd() + "-";
                    PrTemp += DataAll.Rows[i]["ProdectionName"].ToString() + "-";
                    send++;
                }
            }
            string tt = "WeekNum";
            if (FilterSort[2] == '1')
            {
                if (radioDate.Checked)
                    tt = "Day";
                if (radioMonth.Checked)
                    tt = "Month";
            }
            String[] PRname = PrTemp.Split('-');

            switch (strlist.Length)
            {
                case 2:
                    chart1(strlist[0], strlist2[0], PRname, send, temp, tt);
                    break;
                case 3:
                    chart1(strlist[0], strlist2[0], PRname, send, temp, tt);
                    chart3(strlist[1], strlist2[1], PRname, send, temp, tt);
                    break;
                case 4:
                    chart1(strlist[0], strlist2[0], PRname, send, temp, tt);
                    chart2(strlist[1], strlist2[1], PRname, send, temp, tt);
                    chart3(strlist[2], strlist2[2], PRname, send, temp, tt);
                    break;
                case 5:
                    chart1(strlist[0], strlist2[0], PRname, send, temp, tt);
                    chart2(strlist[1], strlist2[1], PRname, send, temp, tt);
                    chart3(strlist[2], strlist2[2], PRname, send, temp, tt);
                    chart4(strlist[3], strlist2[3], PRname, send, temp, tt);
                    break;
                default:
                    break;
            }
        }
        private void SizeChartFix()
        {
            if (FullScreen)
                return;

            pnlTableView.Visible = ChartView1.Visible = ChartView2.Visible = ChartView3.Visible = ChartView4.Visible = pnlChartUp.Visible = pnlChartDown.Visible = false;
            pnlTableView.Dock = ChartView1.Dock = ChartView2.Dock = ChartView3.Dock = ChartView4.Dock = pnlChartUp.Dock = pnlChartDown.Dock = System.Windows.Forms.DockStyle.None;

            if (NumberOfViewChart == 1)
            {
                pnlChartUp.Visible = true;
                pnlChartUp.Dock = System.Windows.Forms.DockStyle.Fill;
                ChartView1.Visible = true;
                ChartView1.Dock = System.Windows.Forms.DockStyle.Fill;
                return;
            }
            if (NumberOfViewChart == 2)
            {
                pnlChartUp.Visible = true;
                pnlChartUp.Dock = System.Windows.Forms.DockStyle.Top;
                pnlChartUp.Height = (pnlCharView.Height) / 2;
                ChartView1.Visible = true;
                ChartView1.Dock = System.Windows.Forms.DockStyle.Fill;
                pnlChartDown.Visible = true;
                pnlChartDown.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnlChartDown.Height = (pnlCharView.Height) / 2;
                ChartView3.Visible = true;
                ChartView3.Dock = System.Windows.Forms.DockStyle.Fill;
                return;
            }
            if (NumberOfViewChart == 3)
            {
                pnlChartUp.Visible = true;
                pnlChartUp.Dock = System.Windows.Forms.DockStyle.Top;
                pnlChartUp.Height = (pnlCharView.Height) / 2;
                ChartView1.Visible = true;
                ChartView1.Dock = System.Windows.Forms.DockStyle.Left;
                ChartView1.Width = (pnlChartUp.Width) / 2;
                ChartView2.Visible = true;
                ChartView2.Dock = System.Windows.Forms.DockStyle.Right;
                ChartView2.Width = (pnlChartUp.Width) / 2;
                pnlChartDown.Visible = true;
                pnlChartDown.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnlChartDown.Height = (pnlCharView.Height) / 2;
                ChartView3.Visible = true;
                ChartView3.Dock = System.Windows.Forms.DockStyle.Fill;
                return;
            }
            if (NumberOfViewChart == 4)
            {
                pnlChartUp.Visible = true;
                pnlChartUp.Dock = System.Windows.Forms.DockStyle.Top;
                pnlChartUp.Height = (pnlCharView.Height) / 2;
                ChartView1.Visible = true;
                ChartView1.Dock = System.Windows.Forms.DockStyle.Left;
                ChartView1.Width = (pnlChartUp.Width) / 2;
                ChartView2.Visible = true;
                ChartView2.Dock = System.Windows.Forms.DockStyle.Right;
                ChartView2.Width = (pnlChartUp.Width) / 2;
                pnlChartDown.Visible = true;
                pnlChartDown.Dock = System.Windows.Forms.DockStyle.Bottom;
                pnlChartDown.Height = (pnlCharView.Height) / 2;
                ChartView3.Visible = true;
                ChartView3.Dock = System.Windows.Forms.DockStyle.Left;
                ChartView3.Width = (pnlChartDown.Width) / 2;
                ChartView4.Visible = true;
                ChartView4.Dock = System.Windows.Forms.DockStyle.Right;
                ChartView4.Width = (pnlChartDown.Width) / 2;
                return;
            }
        }
        private void LabelView()
        {
            if (ChartSortString == null)
            {
                lbl1.Visible = lbl2.Visible = lbl3.Visible = lbl4.Visible = false;
                return;
            }
            String[] strlist = ChartSortString.Split('-');
            String[] strlist2 = ChartSortInt.Split('-');
            switch (strlist.Length)
            {
                case 2:
                    lbl1.Visible = true;
                    lbl1.Width = 400;
                    lbl1.Height = 200;
                    lbl1.Text = strlist[0];
                    lbl1.Tag = strlist2[0];
                    lbl2.Visible = lbl3.Visible = lbl4.Visible = false;
                    break;
                case 3:
                    lbl1.Visible = true;
                    lbl1.Width = 400;
                    lbl1.Height = 100;
                    lbl1.Text = strlist[0];
                    lbl1.Tag = strlist2[0];
                    lbl3.Visible = true;
                    lbl3.Width = 400;
                    lbl3.Height = 100;
                    lbl3.Text = strlist[1];
                    lbl3.Tag = strlist2[1];
                    lbl2.Visible = lbl4.Visible = false;
                    break;
                case 4:
                    lbl1.Visible = true;
                    lbl1.Width = 200;
                    lbl1.Height = 100;
                    lbl1.Text = strlist[0];
                    lbl1.Tag = strlist2[0];
                    lbl2.Visible = true;
                    lbl2.Width = 200;
                    lbl2.Height = 100;
                    lbl2.Text = strlist[1];
                    lbl2.Tag = strlist2[1];
                    lbl3.Visible = true;
                    lbl3.Width = 400;
                    lbl3.Height = 100;
                    lbl3.Text = strlist[2];
                    lbl3.Tag = strlist2[2];
                    lbl4.Visible = false;
                    break;
                case 5:
                    lbl1.Visible = true;
                    lbl1.Width = 200;
                    lbl1.Height = 100;
                    lbl1.Text = strlist[0];
                    lbl1.Tag = strlist2[0];
                    lbl2.Visible = true;
                    lbl2.Width = 200;
                    lbl2.Height = 100;
                    lbl2.Text = strlist[1];
                    lbl2.Tag = strlist2[1];
                    lbl3.Visible = true;
                    lbl3.Width = 200;
                    lbl3.Height = 100;
                    lbl3.Text = strlist[2];
                    lbl3.Tag = strlist2[2];
                    lbl4.Visible = true;
                    lbl4.Width = 200;
                    lbl4.Height = 100;
                    lbl4.Text = strlist[3];
                    lbl4.Tag = strlist2[3];
                    break;
                default:
                    lbl1.Visible = lbl2.Visible = lbl3.Visible = lbl4.Visible = false;
                    break;
            }

        }
        private void SendChartSort(string ChartNameString, string ChartnameInt)
        {
            bool Find = false;
            if (ChartSortString == null)
            {
                ChartSortString = ChartNameString + "-";
                ChartSortInt = ChartnameInt + "-";
                NumberOfViewChart++;
            }
            else
            {

                String[] strlist = ChartSortString.Split('-');
                String[] strlist2 = ChartSortInt.Split('-');
                for (int i = 0; i < strlist.Length; i++)
                    if (strlist2[i] != "")
                        if (strlist2[i] == ChartnameInt)
                        {
                            strlist[i] = "";
                            strlist2[i] = "";
                            Find = true;
                            break;
                        }
                ChartSortString = "";
                ChartSortInt = "";
                for (int i = 0; i < strlist.Length - 1; i++)
                {
                    if (strlist2[i] != "-" && strlist2[i] != "")
                    {
                        ChartSortString += strlist[i] + "-";
                        ChartSortInt += strlist2[i] + "-";
                    }
                }

                if (Find)
                {
                    NumberOfViewChart = 0;
                    strlist = ChartSortString.Split('-');
                    ChartSortString = "";
                    strlist2 = ChartSortInt.Split('-');
                    ChartSortInt = "";
                    for (int i = 0; i < strlist.Length; i++)
                        if (strlist[i] != "")
                        {
                            ChartSortString += strlist[i] + "-";
                            ChartSortInt += strlist2[i] + "-";
                            NumberOfViewChart++;
                        }

                    if (ChartSortString == "")
                    {
                        ChartSortString = null;
                        ChartSortInt = null;

                    }
                }
                else
                {
                    if (strlist.Length < 5)
                    {
                        ChartSortString += ChartNameString + "-";
                        ChartSortInt += ChartnameInt + "-";
                        NumberOfViewChart++;
                    }
                    else
                        MessageBox.Show("تعداد نمودار ها نمی تواند بیشتر از چهار عدد انتخاب شود");
                }
            }
            if (ChartSortString == null)
                btnChartTable.Enabled = false;
            else
                btnChartTable.Enabled = true;
        }
        //action
        private void lbl1_Click(object sender, EventArgs e)
        {
            SendChartSort(lbl1.Text, (string)lbl1.Tag);
            LabelView();
        }
        private void lbl2_Click(object sender, EventArgs e)
        {
            SendChartSort(lbl2.Text, (string)lbl2.Tag);
            LabelView();
        }
        private void lbl3_Click(object sender, EventArgs e)
        {
            SendChartSort(lbl3.Text, (string)lbl3.Tag);
            LabelView();
        }
        private void lbl4_Click(object sender, EventArgs e)
        {
            SendChartSort(lbl4.Text, (string)lbl4.Tag);
            LabelView();
        }
        private void btnDownUp_Click(object sender, EventArgs e)
        {
            int Height = pnlCharView.Height;
            int Width = pnlCharView.Width;
            var Location = pnlCharView.Location;

            pnlCharView.Dock = DockStyle.None;

            if (pnlChart.Height != 300)
            {
                Location.Y += 300;
                pnlCharView.Location = Location;
                pnlCharView.Height = Height - 300;
            }
            else
            {
                pnlCharView.Location = Location;
                pnlCharView.Height = Height;
            }
            pnlCharView.Width = Width;
            TimerUpDown.Enabled = true;
        }
        private void TimerUpDown_Tick(object sender, EventArgs e)
        {
            if (UpDown)
            {
                if (pnlChart.Height >= 300)
                {
                    pnlChart.Height = 300;
                    btnDownUp.Image = global::PharmedPlastPouyan.Properties.Resources.Arrow_Up;
                    UpDown = !UpDown;
                    TimerUpDown.Enabled = false;
                    pnlCharView.Dock = DockStyle.Fill;
                    if (radioChart.Checked)
                        SizeChartFix();
                    else
                        SizeTableFix();
                    return;
                }
                pnlChart.Height = pnlChart.Height + 10;
            }
            else
            {
                if (pnlChart.Height <= 35)
                {
                    pnlChart.Height = 35;
                    btnDownUp.Image = global::PharmedPlastPouyan.Properties.Resources.Arrow_Down;
                    UpDown = !UpDown;
                    TimerUpDown.Enabled = false;
                    pnlCharView.Dock = DockStyle.Fill;
                    if (radioChart.Checked)
                        SizeChartFix();
                    else
                        SizeTableFix();
                    return;
                }
                pnlChart.Height = pnlChart.Height - 10;
            }
        }
        private void btnAction_Click(object sender, EventArgs e)
        {
            DataRowView a = comchart.SelectedItem as DataRowView;
            if (a != null)
            {
                if ((int)a["ParentID"] == 3)
                {
                    if (comStop.SelectedIndex < 0)
                        SendChartSort("توقف های " + comchart.Text, comchart.SelectedValue.ToString());
                    else
                        SendChartSort("توقف های " + comStop.Text, comStop.SelectedValue.ToString());
                }
                else
                    SendChartSort(comchart.Text, comchart.SelectedValue.ToString());
                LabelView();
            }
        }
        private void comTitle_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataTable dt = Data.Select("select * from ChartTitleAS where ParentID=" + comTitle.SelectedValue + " order by Tartib ASC");
            comchart.DataSource = dt;
            if (dt.Rows.Count == 0)
                comStop.Visible = false;
        }
        private void RadioType()
        {
            if (radioTable.Checked)
            {
                pnlChartA.Dock = DockStyle.None;
                pnlChartA.Visible = false;
                pnlTableRadio.Dock = DockStyle.Fill;
                pnlTableRadio.Visible = true;
                btnChartTable.Text = "نمایش جدول";
                btnChartTable.Enabled = true;
            }
            else
            {
                pnlTableRadio.Dock = DockStyle.None;
                pnlTableRadio.Visible = false;
                pnlChartA.Dock = DockStyle.Fill;
                pnlChartA.Visible = true;
                btnChartTable.Text = "نمایش نمودار";
                if (NumberOfViewChart > 0)
                    btnChartTable.Enabled = true;
                else
                    btnChartTable.Enabled = false;
            }
        }
        private void radioTable_CheckedChanged(object sender, EventArgs e)
        {
            RadioType();
        }
        private void radioChart_CheckedChanged(object sender, EventArgs e)
        {
            RadioType();
        }
        bool FullScreen = false;
        private void ChartView1_Click(object sender, EventArgs e)
        {
            ChartFullScren(1, FullScreen);
        }
        private void ChartView2_Click(object sender, EventArgs e)
        {
            ChartFullScren(2, FullScreen);
        }
        private void ChartView3_Click(object sender, EventArgs e)
        {
            ChartFullScren(3, FullScreen);
        }
        private void ChartView4_Click(object sender, EventArgs e)
        {
            ChartFullScren(4, FullScreen);
        }
        private void ChartFullScren(int ChartNum, bool Full)
        {
            if (NumberOfViewChart < 2)
                return;

            if (Full)
            {
                FullScreen = false;
                SizeChartFix();
                return;
            }
            switch (ChartNum)
            {
                case 1:
                    pnlChartDown.Dock = DockStyle.None;
                    pnlChartUp.Dock = DockStyle.Fill;
                    pnlChartDown.Visible = false;
                    ChartView2.Visible = false;
                    ChartView2.Dock = DockStyle.None;
                    ChartView1.Dock = DockStyle.Fill;
                    FullScreen = true;
                    break;
                case 2:
                    pnlChartDown.Dock = DockStyle.None;
                    pnlChartUp.Dock = DockStyle.Fill;
                    pnlChartDown.Visible = false;
                    ChartView1.Visible = false;
                    ChartView1.Dock = DockStyle.None;
                    ChartView2.Dock = DockStyle.Fill;
                    FullScreen = true;
                    break;
                case 3:
                    pnlChartUp.Dock = DockStyle.None;
                    pnlChartDown.Dock = DockStyle.Fill;
                    pnlChartUp.Visible = false;
                    ChartView4.Visible = false;
                    ChartView4.Dock = DockStyle.None;
                    ChartView3.Dock = DockStyle.Fill;
                    FullScreen = true;
                    break;
                case 4:
                    pnlChartUp.Dock = DockStyle.None;
                    pnlChartDown.Dock = DockStyle.Fill;
                    pnlChartUp.Visible = false;
                    ChartView3.Visible = false;
                    ChartView3.Dock = DockStyle.None;
                    ChartView4.Dock = DockStyle.Fill;
                    FullScreen = true;
                    break;
                default:
                    break;
            }

        }
        private void comchart_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView a = comchart.SelectedItem as DataRowView;

            if ((int)a["ParentID"] == 3)
            {
                comStop.Visible = true;
                comStop.DataSource = Data.Select("select * from ChartTitleAS where ParentID=" + comchart.SelectedValue + " order by Tartib ASC");
                comStop.SelectedIndex = -1;
                if (comStop.Items.Count > 0)
                    comStop.Visible = true;
                else
                    comStop.Visible = false;
            }
            else
            {
                comStop.Visible = false;
            }
        }

        #endregion

        #region Code For Filter

        //data type
        int FilterCount;
        string FilterSort;
        DataTable DataAll;

        //class
        private void CheckBoxfilterChecked()
        {
            bool a = false;
            FilterCount = 0;
            if (chkPR.Checked)
            {
                a = true;
                FilterCount++;
                FilterSort = "1";
            }
            else
                FilterSort = "0";
            if (chkMachine.Checked)
            {
                a = true;
                FilterCount++;
                FilterSort += "1";
            }
            else
                FilterSort += "0";
            if (chkDate.Checked)
            {
                a = true;
                FilterCount++;
                FilterSort += "1";
            }
            else
                FilterSort += "0";
            if (chkShift.Checked)
            {
                a = true;
                FilterCount++;
                FilterSort += "1";
            }
            else
                FilterSort += "0";
            if (chkLot.Checked)
            {
                a = true;
                FilterCount++;
                FilterSort += "1";
            }
            else
                FilterSort += "0";

            btnFilter.Enabled = a;
        }
        private void FilterChart()
        {
            bool MultiSelect = false;
            string Sql; string SqlWhere = "where";
            #region Production
            if (FilterSort[0] == '1')
            {
                MultiSelect = true;
                if (lblPRCode.Text != "")
                {
                    if (txtMoldNum.Text != "")
                    {
                        SqlWhere += " ProdectionCode=" + lblPRCode.Text + " AND TemplateNum=" + txtMoldNum.Text;
                    }
                    else
                    {
                        SqlWhere += " ProdectionCode=" + lblPRCode.Text;
                    }

                }
                else
                {
                    MessageBox.Show("بعد از اعمال فیلتر قطعه حتما باید کالا انتخاب شود.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    //btnViewProdection.Focus();
                    return;
                }
            }
            #endregion

            #region Operator

            if (FilterSort[1] == '1')
            {
                if (MultiSelect)
                    SqlWhere += " AND";

                if (lblopview.Text != "")
                {
                    if (helper)
                        SqlWhere += string.Format(" (Operator1={0} OR Operator2Code={0} OR Operator3Code={0})", txtOpAs.Text);
                    else
                        SqlWhere += string.Format(" Operator1={0}", txtOpAs.Text);
                    MultiSelect = true;
                }
                else
                {
                    MultiSelect = false;
                    return;
                }
            }
            #endregion

            #region Date

            if (FilterSort[2] == '1')
            {
                if (MultiSelect)
                    SqlWhere += " AND";
                MultiSelect = true;
                int TYear = Convert.ToInt16(txtYear.Text);
                if (TYear < 100)
                {
                    if (TYear < 90)
                        TYear += 1400;
                    else
                        TYear += 1300;
                }


                if (radioDate.Checked)
                {
                    if (txtStartDate.Text.Length > 2 && txtEndDate.Text.Length > 2)
                    {
                        String[] strDateStart = txtStartDate.Text.Split('/', '-');
                        String[] strDateEnd = txtEndDate.Text.Split('/', '-');
                        if (strDateStart.Length > 1 && strDateEnd.Length > 1)
                        {
                            int Tstart = Tools.GetLotNumber(TYear, Convert.ToInt16(strDateStart[0]), Convert.ToInt16(strDateStart[1]), 1);
                            int TEnd = Tools.GetLotNumber(TYear, Convert.ToInt16(strDateEnd[0]), Convert.ToInt16(strDateEnd[1]), 2);
                            SqlWhere += " (LotNum>=" + Tstart + " AND LotNum<=" + TEnd + ")";
                        }
                        else
                        {
                            MessageBox.Show("فرمت وارد شده تاریخ اشتباه است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //txtStartDate.Focus();
                            return;
                        }

                    }
                    else
                    {
                        MessageBox.Show("بعد از اعمال فیلتر تاریخ حتما باید تاریخ شروع و تاریخ پایان را وارد کنید ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //txtStartDate.Focus();

                        return;
                    }
                }
                else
                {
                    if (radioWeek.Checked)
                    {
                        if (txtStartWeek.Text != "" && txtEndWeek.Text != "")
                        {
                            int Tstart = Convert.ToInt16(txtStartWeek.Text);
                            int TEnd = Convert.ToInt16(txtEndWeek.Text);
                            if ((Tstart > 0 && Tstart < 54) && (TEnd > 0 && TEnd < 54))
                            {
                                SqlWhere += " Year=" + TYear + " AND (WeekNum>=" + Tstart + " AND WeekNum <=" + TEnd + ")";
                            }
                            else
                            {
                                MessageBox.Show("هفته نمی تواند کمتر از 1 یا بیشتر از 53 باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                //txtStartWeek.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("بعد از اعمال فیلتر تاریخ حتما باید هفته شروع و هفته پایان را وارد کنید ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //txtStartDate.Focus();
                            return;
                        }
                    }
                    else
                    {



                        if (txtStartMonth.Text != "" && txtEndMonth.Text != "")
                        {
                            int Tstart = Convert.ToInt16(txtStartMonth.Text);
                            int TEnd = Convert.ToInt16(txtEndMonth.Text);
                            if ((Tstart > 0 && Tstart < 13) && (TEnd > 0 && TEnd < 13))
                            {
                                SqlWhere += " Year=" + TYear + " AND (Month>=" + Tstart + " AND Month<=" + TEnd + ")";
                            }
                            else
                            {
                                MessageBox.Show("ماه نمی تواند کمتر از 1 یا بیشتر از 12 باشد", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                ///txtStartWeek.Focus();
                                return;
                            }
                        }
                        else
                        {
                            MessageBox.Show("بعد از اعمال فیلتر تاریخ حتما باید ماه شروع و ماه پایان را وارد کنید ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            //txtStartDate.Focus();
                            return;
                        }
                    }
                }

            }

            #endregion

            #region Shift
            if (FilterSort[3] == '1')
            {
                if (MultiSelect)
                    SqlWhere += " AND";
                MultiSelect = true;

                if (radioShift.Checked)
                {
                    if (chkShiftStatus.Value)
                        SqlWhere += " Shift=1";
                    else
                        SqlWhere += " Shift=2";
                }
                else
                {
                    if (txtOperator1.Text.Length > 0)
                    {
                        string sqltemp = " (";
                        sqltemp += " OperatorOrderCode=" + txtOperator1.Text;
                        if (txtOperator2.Text.Length > 0)
                        {
                            sqltemp += " OR OperatorOrderCode=" + txtOperator2.Text;
                            if (txtOperator3.Text.Length > 0)
                            {
                                sqltemp += " OR OperatorOrderCode=" + txtOperator3.Text;
                                if (txtOperator4.Text.Length > 0)
                                {
                                    sqltemp += " OR OperatorOrderCode=" + txtOperator4.Text;
                                }
                            }
                        }
                        sqltemp += " )";
                        SqlWhere += sqltemp;
                    }
                    else
                    {
                        MessageBox.Show("بعد از اعمال فیلتر شیفت شیفت بر اساس اپراتور،\n باید کد اپراتور وارد شود", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        //txtMachineNum.Focus();
                        return;
                    }

                }

            }
            #endregion

            #region LotNumber

            if (FilterSort[4] == '1')
            {
                if (MultiSelect)
                    SqlWhere += " AND";
                MultiSelect = true;

                if (txtLotStart.Text.Length == 5 && txtLotEnd.Text.Length == 5)
                {
                    int Tstart = Convert.ToInt32(txtLotStart.Text);
                    int TEnd = Convert.ToInt32(txtLotEnd.Text);
                    SqlWhere += " (LotNum>=" + Tstart + " AND LotNum<=" + TEnd + ")";
                }
                else
                {
                    return;
                }

            }
            #endregion


            SqlWhere += " order by LotNum";
            Sql = "select * from AssemblyData {0}";
            Sql = string.Format(Sql, SqlWhere);
            DataAll = Data.Select(Sql);

            return;


        }

        private int SizeCheckBox()
        {
            return pnl1.Height + pnl2.Height + pnl3.Height + pnl4.Height + pnl5.Height;
        }
        //action
        private void btnFilter_Click(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void chkPR_CheckedChanged(object sender, EventArgs e)
        {
            if (chkPR.Checked)
            {
                pnl1.Height = 175;
                CheckBoxfilterChecked();
                btnViewProdection.Enabled = txtMoldNum.Enabled = true;
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
            else
            {
                pnl1.Height = 40;
                CheckBoxfilterChecked();
                btnViewProdection.Enabled = txtMoldNum.Enabled = false;
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
        }
        private void chkMachine_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMachine.Checked)
            {
                pnl2.Height = 165;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
            else
            {
                pnl2.Height = 40;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
        }
        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            if (chkDate.Checked)
            {
                pnl3.Height = 215;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
            else
            {
                pnl3.Height = 40;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
        }
        private void chkShift_CheckedChanged(object sender, EventArgs e)
        {
            if (chkShift.Checked)
            {
                pnl4.Height = 215;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
            else
            {
                pnl4.Height = 40;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
        }
        private void chkLot_CheckedChanged(object sender, EventArgs e)
        {
            if (chkLot.Checked)
            {
                pnl5.Height = 100;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
            else
            {
                pnl5.Height = 40;
                CheckBoxfilterChecked();
                pnlChekBox.Height = SizeCheckBox();
                scroll = SizeCheckBox() - pnlFillFilter.Height;
                if (scroll > 0)
                {
                    vScrollBar1.Enabled = true;
                    vScrollBar1.Maximum = scroll + 25;
                }
                else
                {
                    vScrollBar1.Enabled = false;
                    pnlChekBox.Location = new System.Drawing.Point(0, 0);
                }
            }
        }
        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pnlChekBox.Location = new System.Drawing.Point(0, -(e.NewValue));
        }
        private void btnLeftRight_Click(object sender, EventArgs e)
        {
            int Height = pnlCharView.Height;
            int Width = pnlCharView.Width;
            var Location = pnlCharView.Location;
            pnlCharView.Dock = DockStyle.None;
            pnlCharView.Location = Location;
            pnlCharView.Height = Height;
            if (pnlFilter.Width != 423)
                pnlCharView.Width = Width - 423;
            else
                pnlCharView.Width = Width;

            TimerLeftRight.Enabled = true;
        }
        private void frmChartView_Resize(object sender, EventArgs e)
        {
            if (FirstRun)
                return;
            SizeChartFix();
            scroll = SizeCheckBox() - pnlFillFilter.Height;
            if (scroll > 0)
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.Maximum = scroll + 25;
            }
            else
            {
                vScrollBar1.Enabled = false;
                pnlChekBox.Location = new System.Drawing.Point(0, 0);
            }
        }
        private void TimerLeftRight_Tick(object sender, EventArgs e)
        {
            if (LeftRight)
            {
                if (pnlFilter.Width >= 423)
                {
                    pnlFilter.Width = 423;
                    btnLeftRight.Image = global::PharmedPlastPouyan.Properties.Resources.Arrow_Right;
                    LeftRight = !LeftRight;
                    TimerLeftRight.Enabled = false;
                    pnlCharView.Dock = DockStyle.Fill;
                    if (radioChart.Checked)
                        SizeChartFix();
                    else
                        SizeTableFix();
                    return;
                }
                pnlFilter.Width = pnlFilter.Width + 10;
            }
            else
            {
                if (pnlFilter.Width <= 55)
                {
                    pnlFilter.Width = 55;
                    btnLeftRight.Image = global::PharmedPlastPouyan.Properties.Resources.Arrow_Left;
                    LeftRight = !LeftRight;
                    TimerLeftRight.Enabled = false;
                    pnlCharView.Dock = DockStyle.Fill;
                    if (radioChart.Checked)
                        SizeChartFix();
                    else
                        SizeTableFix();
                    return;
                }
                pnlFilter.Width = pnlFilter.Width - 10;
            }
        }
        private void btnViewProdection_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.Shart = "A";
            frm.ShowDialog();
            if (frm.Clicked)
            {
                lblPRCode.Text = frm.PRCode;
                lblPRName.Text = frm.PRName;
            }
        }
        private void CheckTextForInsertNumber(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void CheckTextForInsertDate(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 47 || e.KeyChar == 45)
            {
                return;
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txtStartDate_Leave(object sender, EventArgs e)
        {
            if (txtStartDate.Text.Length < 6 && txtStartDate.Text.Length > 2 && txtStartDate.Text != "")
            {
                String[] Temp = txtStartDate.Text.Split('/', '-');
                if (Temp.Length != 2)
                {
                    txtStartDate.Clear();
                }

                if (Convert.ToInt16(Temp[0]) > 0)
                {
                    if (Convert.ToInt16(Temp[0]) < 7)
                    {
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 31)
                        {
                            return;
                        }
                        else
                        {
                            txtStartDate.Clear();
                        }
                    }
                    if (Convert.ToInt16(Temp[0]) <= 12)
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 30)
                            return;
                        else
                            txtStartDate.Clear();
                    else
                        txtStartDate.Clear();
                }
                else
                {
                    txtStartDate.Clear();
                }
            }

        }
        private void txtEndDate_Leave(object sender, EventArgs e)
        {
            if (txtEndDate.Text.Length < 6 && txtEndDate.Text != "")
            {
                String[] Temp = txtEndDate.Text.Split('/', '-');
                if (Temp.Length != 2)
                {
                    txtEndDate.Clear();
                }

                if (Convert.ToInt16(Temp[0]) > 0)
                {
                    if (Convert.ToInt16(Temp[0]) < 7)
                    {
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 31)
                        {
                            return;
                        }
                        else
                        {
                            txtEndDate.Clear();
                        }
                    }
                    if (Convert.ToInt16(Temp[0]) <= 12)
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 30)
                            return;
                        else
                            txtEndDate.Clear();
                    else
                        txtEndDate.Clear();
                }
                else
                {
                    txtEndDate.Clear();
                }
            }
        }
        private void txtStartWeek_Leave(object sender, EventArgs e)
        {
            if (txtStartWeek.Text.Length < 3 && txtStartWeek.Text != "")
            {
                int temp = Convert.ToInt32(txtStartWeek.Text);
                if (temp > 0 && temp < 54)
                {
                    return;
                }
                else
                {
                    txtStartWeek.Clear();
                }
            }
            else
            {
                txtStartWeek.Clear();
            }

        }
        private void txtEndWeek_Leave(object sender, EventArgs e)
        {
            if (txtEndWeek.Text.Length < 3 && txtEndWeek.Text != "")
            {
                int temp = Convert.ToInt32(txtEndWeek.Text);
                if (temp > 0 && temp < 54)
                {
                    return;
                }
                else
                {
                    txtEndWeek.Clear();
                }
            }
            else
            {
                txtEndWeek.Clear();
            }
        }
        private void txtStartMonth_Leave(object sender, EventArgs e)
        {
            if (txtStartMonth.Text.Length < 3 && txtStartMonth.Text != "")
            {
                int temp = Convert.ToInt32(txtStartMonth.Text);
                if (temp > 0 && temp < 13)
                {
                    return;
                }
                else
                {
                    txtStartMonth.Clear();
                }
            }
            else
            {
                txtStartMonth.Clear();
            }
        }
        private void txtEndMonth_Leave(object sender, EventArgs e)
        {
            if (txtEndMonth.Text.Length < 3 && txtEndMonth.Text != "")
            {
                int temp = Convert.ToInt32(txtEndMonth.Text);
                if (temp > 0 && temp < 13)
                {
                    return;
                }
                else
                {
                    txtEndMonth.Clear();
                }
            }
            else
            {
                txtEndMonth.Clear();
            }
        }
        private void radioDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDate.Checked)
                txtStartDate.Enabled = txtEndDate.Enabled = true;
            else
                txtStartDate.Enabled = txtEndDate.Enabled = false;
        }
        private void radioWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWeek.Checked)
                txtStartWeek.Enabled = txtEndWeek.Enabled = true;
            else
                txtStartWeek.Enabled = txtEndWeek.Enabled = false;
        }
        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonth.Checked)
                txtStartMonth.Enabled = txtEndMonth.Enabled = true;
            else
                txtStartMonth.Enabled = txtEndMonth.Enabled = false;
        }
        private void txtYear_Leave(object sender, EventArgs e)
        {
            if (txtYear.Text.Length == 2)
            {
                return;
            }
            if (txtYear.Text.Length == 4)
            {
                int temp = Convert.ToInt16(txtYear.Text);
                if (temp > 1398 && temp < 1450)
                    return;
            }

            txtYear.Text = "1398";
        }
        private void radioShift_CheckedChanged(object sender, EventArgs e)
        {
            if (radioShift.Checked)
                chkShiftStatus.Enabled = true;
            else
                chkShiftStatus.Enabled = false;
        }
        private void radioOperator_CheckedChanged(object sender, EventArgs e)
        {
            if (radioOperator.Checked)
            {
                txtOperator1.Enabled = true;
                txtOperator1.Text = "";
            }
            else
            {
                radioShift.Focus();
                txtOperator1.Text = txtOperator2.Text = txtOperator3.Text = txtOperator4.Text = "";
                txtOperator1.Enabled = txtOperator2.Enabled = txtOperator3.Enabled = txtOperator4.Enabled = false;
            }
        }
        private void txtOperator1_TextChanged(object sender, EventArgs e)
        {
            if (txtOperator1.Text.Length > 0)
                txtOperator2.Enabled = true;
            else
                txtOperator2.Enabled = false;
        }
        private void txtOperator2_TextChanged(object sender, EventArgs e)
        {
            if (txtOperator2.Text.Length > 0)
                txtOperator3.Enabled = true;
            else
                txtOperator3.Enabled = false;
        }
        private void txtOperator3_TextChanged(object sender, EventArgs e)
        {
            if (txtOperator3.Text.Length > 0)
                txtOperator4.Enabled = true;
            else
                txtOperator4.Enabled = false;
        }

        #endregion

        #region Code For Table

        private void TableView()
        {
            viewTable = true;
            SizeTableFix();
            tblView.DataSource = DataAll;

            string mess = "مجموع تعداد تولید شده : {0}  -  مجموع ضایعات : {1}  -  مجموع تعداد تحت کنترل : {2}";
            lblview.Text = string.Format(mess, DataAll.AsEnumerable().Sum(x => x.Field<int>("PartNum")),
                DataAll.AsEnumerable().Sum(x => x.Field<int>("WastageNum")),
                DataAll.AsEnumerable().Sum(x => x.Field<int>("ControlNum")));


        }
        private void SizeTableFix()
        {
            pnlTableView.Visible = pnlChartUp.Visible = pnlChartDown.Visible = false;
            pnlTableView.Dock = pnlChartUp.Dock = pnlChartDown.Dock = System.Windows.Forms.DockStyle.None;
            if (!viewTable)
                return;

            pnlTableView.Visible = true;
            pnlTableView.Dock = DockStyle.Fill;

        }





        #endregion

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (DataAll == null)
            {
                radWaitingBar1.StopWaiting();
                radWaitingBar1.Visible = false;
                return;
            }
            if (DataAll.Rows.Count > 0)
            {
                radWaitingBar1.StopWaiting();
                radWaitingBar1.Visible = false;
                lblStatus.ForeColor = Color.Black;
                lblStatus.Text = "تعداد " + DataAll.Rows.Count.ToString() + "داده پیدا شد.";
                btnDownUp.Enabled = true;
                if (pnlChart.Height == 35)
                {
                    btnDownUp_Click(null, null);
                }
            }
            else
            {
                radWaitingBar1.StopWaiting();
                radWaitingBar1.Visible = false;
                lblStatus.Text = "جستجو برای این ترکیب از فیلترها با هیچ داده ای هم‌خوانی نداشت";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            FilterChart();
        }

        private void tblView_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                frmAssemblyview frm = new frmAssemblyview();
                frm.IDAS = ID;
                frm.ShowDialog();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            PersonalForm frm = new PersonalForm();
            frm.ShowDialog();
        }

        private void txtOpAs_TextChanged(object sender, EventArgs e)
        {
            if (txtOpAs.TextLength == 5)
            {
                LINQDataContext db = new LINQDataContext();
                var tmp = (from s in db.PersonalLists where s.PersonalCode == int.Parse(txtOpAs.Text) select s).SingleOrDefault();
                if (tmp != null)
                {
                    lblopview.Text = tmp.PersonalName;
                }
                else
                {
                    MessageBox.Show("این کد پرسنلی وجود ندارد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    lblopview.Text = "";
                }

            }
            else
            {
                lblopview.Text = "";
            }
        }
        bool helper = false;
        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            helper = checkBox1.Checked;
        }
    }
}
