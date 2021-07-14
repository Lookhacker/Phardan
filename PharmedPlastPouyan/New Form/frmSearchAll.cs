using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmSearchAll : Form
    {

        DataAccess Data = new DataAccess();
        DataTable AlData = new DataTable();
        DataTable FilterData = new DataTable();
        LINQDataContext DataBase = new LINQDataContext();
        string FilterSort = "0000000";

        public frmSearchAll()
        {
            InitializeComponent();
        }

        private void frmSearch_Load(object sender, EventArgs e)
        {
            radioPR.Checked = true;
            string s =DataAccess.YearDefault.ToString();
            txtYear.Text = s[2].ToString() + s[3].ToString();
        }
        string strKind;

        private void radioAssembly_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioAssembly.Checked)
                return;
            chkMachine.Enabled = false;
            chkMachine.Checked = false;
            chkShift.Enabled = true;
            grwAssembly.Dock = DockStyle.Fill;
            grwAssembly.Visible = true;
            grwGr.Dock = DockStyle.None;
            grwGr.Visible = false;
            grwPR.Dock = DockStyle.None;
            grwPR.Visible = false;
            lbltemplate.Text = "اپراتور :";
            txtMoldNum.Enabled = true;
            strKind = "AS";
            lblStatus.Text = "";

        }
        private void radioGR_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioGR.Checked)
                return;
            chkMachine.Enabled = false;
            chkMachine.Checked = false;
            chkShift.Enabled = false;
            chkShift.Checked = false;
            grwAssembly.Dock = DockStyle.None;
            grwAssembly.Visible = false;
            grwGr.Dock = DockStyle.Fill;
            grwGr.Visible = true;
            grwPR.Dock = DockStyle.None;
            grwPR.Visible = false;
            lbltemplate.Text = "شماره قالب";
            txtMoldNum.Enabled = false;
            strKind = "GR";
            lblStatus.Text = "";

        }
        private void radioPR_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioPR.Checked)
                return;
            chkMachine.Enabled = true;
            chkShift.Enabled = true;
            grwAssembly.Dock = DockStyle.None;
            grwAssembly.Visible = false;
            grwGr.Dock = DockStyle.None;
            grwGr.Visible = false;
            grwPR.Dock = DockStyle.Fill;
            grwPR.Visible = true;
            lbltemplate.Text = "شماره قالب";
            txtMoldNum.Enabled = true;
            strKind = "PR";
            lblStatus.Text = "";

        }
        private void btnFilter_Click(object sender, EventArgs e)
        {
            RunningFilter();
        }

        private void RunningFilter()
        {
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (Filter.IsBusy != true)
            {
                Filter.RunWorkerAsync();
            }
        }
        private void Filter_DoWork(object sender, DoWorkEventArgs e)
        {
            RunFilter();
            Thread.Sleep(1000);
        }
        private void Filter_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (novalid)
            {
                lblStatus.Text = "پس از انتخاب فیلتر باید حداقل یکی از فیل های آن پر شود";
                lblStatus.ForeColor = Color.Red;
                switch (strKind)
                {
                    case "PR":
                        //grwPR.DataSource = gridviewall;
                        break;
                    case "GR":
                        //grwGr.DataSource = gridviewall;
                        break;

                    case "AS":
                        //grwAssembly.DataSource = gridviewall;
                        break;

                    default:
                        break;
                }
            }
            else
            {
                if (true)
                {
                    lblStatus.Text = "جستجو برای این ترکیب از فیلترها با هیچ داده ای هم‌خوانی نداشت";
                    lblStatus.ForeColor = Color.Red;
                }
                else
                {
                    //lblStatus.ForeColor = Color.Black;
                    //lblStatus.Text = "تعداد " + gridviewall.Rows.Count.ToString() + "داده پیدا شد.";
                }
                switch (strKind)
                {
                    case "PR":
                       // grwPR.DataSource = gridviewall;
                        break;
                    case "GR":
                      //  grwGr.DataSource = gridviewall;
                        break;

                    case "AS":
                      //  grwAssembly.DataSource = gridviewall;
                        break;

                    default:
                        break;
                }
            }
            radWaitingBar1.Visible = false;
        }

        private void RunFilter()
        {

        }





        string _IdStart = ""; string _IdEnd = ""; string _PrCode = ""; string _Template = "";

        private void CheckBoxfilterChecked()
        {
            if (chkID.Checked)
                FilterSort = "1";
            else
                FilterSort = "0";

            if (chkOperator.Checked)
                FilterSort += "1";
            else
                FilterSort += "0";

            if (chkPR.Checked)
                FilterSort += "1";
            else
                FilterSort += "0";

            if (chkMachine.Checked)
                FilterSort += "1";
            else
                FilterSort += "0";

            if (chkDate.Checked)
                FilterSort += "1";
            else
                FilterSort += "0";

            if (chkShift.Checked)
                FilterSort += "1";
            else
                FilterSort += "0";

            if (chkLot.Checked)
                FilterSort += "1";
            else
                FilterSort += "0";

            btnFilter.Enabled = !(FilterSort == "0000000");
        }

        private void chkID_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            if (chkID.Checked)
            {
                pnl1.Height = 100;
                SizeCheckBox();
            }
            else
            {
                pnl1.Height = 40;
                SizeCheckBox();
            }
        }
        private void txtIDStart_TextChanged(object sender, EventArgs e)
        {
            _IdStart = txtIDStart.Text;

        }
        private void txtIDEnd_TextChanged(object sender, EventArgs e)
        {
            _IdEnd = txtIDEnd.Text;
        }


        private void chkOperator_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            SizeCheckBox();
        }
        private void chkPR_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            if (chkPR.Checked)
            {
                pnl3.Height = 180;
                SizeCheckBox();
            }
            else
            {
                pnl3.Height = 40;
                SizeCheckBox();
            }
        }

        private void btnProduct_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            switch (strKind)
            {
                case "AS":
                    frm.Shart = "A";
                    break;
                case "PR":
                    frm.Shart = "M";
                    break;
                case "GR":
                    frm.Shart = "G";
                    break;
                default:
                    break;
            }
            frm.ShowDialog();
            if (frm.Clicked)
            {
                lblPRCode.Text = frm.PRCode;
                _PrCode = frm.PRCode;
                lblPRName.Text = frm.PRName;
            }
        }
        private void txtMoldNum_TextChanged(object sender, EventArgs e)
        {
            _Template = txtMoldNum.Text;
        }

        private void chkMachine_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            if (chkMachine.Checked)
            {
                pnl4.Height = 90;
                SizeCheckBox();
            }
            else
            {
                pnl4.Height = 40;
                SizeCheckBox();
            }
        }
        string _MachineNum = "";
        private void txtMachineNum_TextChanged(object sender, EventArgs e)
        {
            _MachineNum = txtMachineNum.Text;
        }


        private void chkDate_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            if (chkDate.Checked)
            {
                pnl5.Height = 220;
                SizeCheckBox();
            }
            else
            {
                pnl5.Height = 40;
                SizeCheckBox();
            }
        }

        private void radioDate_CheckedChanged(object sender, EventArgs e)
        {
            if (radioDate.Checked)
            {
                txtStartDate.Enabled = txtEndDate.Enabled = true;
                _Startlot = ""; _Endlot = "";
            }
            else
            {
                txtStartDate.Enabled = txtEndDate.Enabled = false;
            }
        }
        private void radioWeek_CheckedChanged(object sender, EventArgs e)
        {
            if (radioWeek.Checked)
            {
                txtStartWeek.Enabled = txtEndWeek.Enabled = true;
                _Startlot = ""; _Endlot = "";
            }
            else
            {
                txtStartWeek.Enabled = txtEndWeek.Enabled = false;
            }
        }
        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (radioMonth.Checked)
            {
                txtStartMonth.Enabled = txtEndMonth.Enabled = true;
                _Startlot = ""; _Endlot = "";
            }
            else
            {
                txtStartMonth.Enabled = txtEndMonth.Enabled = false;
            }
        }

        private void chkShift_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            if (chkShift.Checked)
            {
                pnl6.Height = 175;
                SizeCheckBox();
            }
            else
            {
                pnl6.Height = 40;
                SizeCheckBox();
            }
        }
        private void chkLot_CheckedChanged(object sender, EventArgs e)
        {
            CheckBoxfilterChecked();
            if (chkLot.Checked)
            {
                pnl7.Height = 100;
                SizeCheckBox();
            }
            else
            {
                pnl7.Height = 40;
                SizeCheckBox();
            }
        }



        private void SizeCheckBox()
        {
            pnlChekBox.Height = pnl1.Height + pnlRadio.Height + pnl2.Height + pnl3.Height + pnl4.Height + pnl5.Height + pnl6.Height + pnl7.Height + 40;
            if (pnlChekBox.Height > pnlFilter.Height)
            {
                vScrollBar1.Enabled = true;
                vScrollBar1.Maximum = (pnlChekBox.Height - pnlFilter.Height) + 50;
            }
            else
            {
                vScrollBar1.Enabled = false;
            }
        }

        private void vScrollBar1_Scroll(object sender, ScrollEventArgs e)
        {
            pnlChekBox.Location = new System.Drawing.Point(0, -(e.NewValue));
        }

        private void Press(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtStartDate_TextChanged(object sender, EventArgs e)
        {
            if (txtStartDate.Text.Length < 6 && txtStartDate.Text.Length > 2 && txtStartDate.Text != "")
            {
                String[] Temp = txtStartDate.Text.Split('/', '-');
                if (Temp.Length != 2)
                {
                    txtStartDate.Clear();
                    return;
                }

                if (Convert.ToInt16(Temp[0]) > 0)
                {
                    if (Convert.ToInt16(Temp[0]) < 7)
                    {
                        if (Temp[1] == "")
                            return;
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 31)
                        {
                            _Startlot = getLotNumber(txtYear.Text, Temp[0], Temp[1], 1);
                        }
                        else
                            txtStartDate.Clear();
                    }
                    else if (Convert.ToInt16(Temp[0]) <= 12)
                    {
                        if (Temp[1] == "")
                            return;
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 30)
                        {
                            _Startlot = getLotNumber(txtYear.Text, Temp[0], Temp[1], 0);
                        }
                        else
                            txtStartDate.Clear();
                    }
                    else
                        txtStartDate.Clear();
                }
                else
                {
                    txtStartDate.Clear();
                }
            }
        }

        string _Startlot = ""; string _Endlot = "";
        bool _shift = true;
        bool _shiftRadio = true;
        string _Operator1 = ""; string _Operator2 = "";
        private string _Startlot2 = "";
        private string _Endlot2 = "";
        private bool novalid = false;

        private string getLotNumber(string Year, string Month, string day, int shift)
        {
            if (Year.Length < 3)
            {
                Year = (int.Parse(Year) + 1300).ToString();
            }
            Tools tools = new Tools(Year, Month, day, shift);
            return tools.LotNum;
        }

        private void txtStartDate_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtEndDate_TextChanged(object sender, EventArgs e)
        {
            if (txtEndDate.Text.Length < 6 && txtEndDate.Text.Length > 2 && txtEndDate.Text != "")
            {
                String[] Temp = txtEndDate.Text.Split('/', '-');
                if (Temp.Length != 2)
                {
                    txtEndDate.Clear();
                    return;
                }

                if (Convert.ToInt16(Temp[0]) > 0)
                {
                    if (Convert.ToInt16(Temp[0]) < 7)
                    {
                        if (Temp[1] == "")
                            return;
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 31)
                        {
                            _Endlot = getLotNumber(txtYear.Text, Temp[0], Temp[1], 1);
                        }
                        else
                            txtEndDate.Clear();
                    }
                    else if (Convert.ToInt16(Temp[0]) <= 12)
                    {
                        if (Temp[1] == "")
                            return;
                        if (Convert.ToInt16(Temp[1]) > 0 && Convert.ToInt16(Temp[1]) <= 30)
                        {
                            _Endlot = getLotNumber(txtYear.Text, Temp[0], Temp[1], 1);
                        }
                        else
                            txtEndDate.Clear();
                    }
                    else
                        txtEndDate.Clear();
                }
                else
                {
                    txtEndDate.Clear();
                }
            }
        }

        private void txtStartWeek_TextChanged(object sender, EventArgs e)
        {
            if (txtStartWeek.TextLength > 0)
            {
                if (int.Parse(txtStartWeek.Text) > 0 && int.Parse(txtStartWeek.Text) < 53)
                {
                    if (txtStartWeek.TextLength == 1)
                        _Startlot = txtYear.Text[txtYear.TextLength - 1] + "0" + txtStartWeek.Text + "01";
                    else
                        _Startlot = txtYear.Text[txtYear.TextLength - 1] + txtStartWeek.Text + "01";
                }
                else
                    txtStartWeek.Clear();
            }
            else
            {
                _Startlot = "";
            }
        }

        private void txtEndWeek_TextChanged(object sender, EventArgs e)
        {
            if (txtEndWeek.TextLength > 0)
            {
                if (int.Parse(txtEndWeek.Text) > 0 && int.Parse(txtEndWeek.Text) < 55)
                {
                    if (txtEndWeek.TextLength == 1)
                        _Endlot = txtYear.Text[txtYear.TextLength - 1] + "0" + txtEndWeek.Text + "62";
                    else
                        _Endlot = txtYear.Text[txtYear.TextLength - 1] + txtEndWeek.Text + "62";
                }
                else
                    txtEndWeek.Clear();
            }
            else
            {
                _Endlot = "";
            }
        }

        private void txtStartMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtStartMonth.TextLength > 0)
            {
                if (int.Parse(txtStartMonth.Text) > 0 && int.Parse(txtStartMonth.Text) < 13)
                {
                    _Startlot = getLotNumber(txtYear.Text, txtStartMonth.Text, "1", 0);
                }
                else
                    _Startlot = "";
            }
            else
            {
                _Startlot = "";
            }
        }

        private void txtEndMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtEndMonth.TextLength > 0)
            {
                if (int.Parse(txtEndMonth.Text) > 0 && int.Parse(txtEndMonth.Text) < 13)
                {
                    _Endlot = getLotNumber(txtYear.Text, txtEndMonth.Text, "31", 1);
                }
                else
                    _Endlot = "";
            }
            else
            {
                _Endlot = "";
            }

        }

        private void chkShiftStatus_ValueChanged(object sender, EventArgs e)
        {
            _shift = chkShiftStatus.Value;
        }

        private void radioShift_CheckedChanged(object sender, EventArgs e)
        {
            _shiftRadio = radioShift.Checked;
            chkShiftStatus.Enabled = radioShift.Checked;
            txtOperator1.Enabled = txtOperator2.Enabled = !radioShift.Checked;
        }

        private void txtOperator1_TextChanged(object sender, EventArgs e)
        {
            if (txtOperator1.TextLength == 5)
            {
                _Operator1 = txtOperator1.Text;
            }
            else
            if (txtOperator1.TextLength == 0)
            {
                _Operator1 = "";
            }
        }

        private void txtOperator2_TextChanged(object sender, EventArgs e)
        {
            if (txtOperator2.TextLength == 5)
            {
                _Operator2 = txtOperator2.Text;
            }
            if (txtOperator2.TextLength == 0)
            {
                _Operator1 = "";
            }
        }

        private void txtLotStart_TextChanged(object sender, EventArgs e)
        {
            if (txtLotStart.TextLength > 1)
            {
                _Startlot2 = txtLotStart.Text;
                for (int i = 5; i > txtLotStart.Text.Length; i--)
                {
                    _Startlot2 += "0";
                }
            }
        }

        private void txtLotEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtLotEnd.TextLength > 1)
            {
                _Endlot2 = txtLotEnd.Text;
                for (int i = 5; i > txtLotEnd.Text.Length; i--)
                {
                    _Endlot2 += "9";
                }
            }
        }

        private void GridALL_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                int ID = int.Parse(e.Row.Cells["IDPR"].Value.ToString());
                frmPREdit frm = new frmPREdit();
                frm.IDPR = ID;
                frm.ShowDialog();
            }
        }

        private void grwGr_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                frmGranuleView frm = new frmGranuleView();
                frm.IDGR = ID;

                frm.ShowDialog();
            }
        }

        private void grwAssembly_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (!(e.RowIndex < 0))
            {
                int ID = int.Parse(e.Row.Cells["ID"].Value.ToString());
                frmAssemblyview frm = new frmAssemblyview();
                frm.IDAS = ID;
                frm.ShowDialog();
            }
        }
    }
}
