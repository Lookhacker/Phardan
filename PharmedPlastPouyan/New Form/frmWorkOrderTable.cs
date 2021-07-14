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
    public partial class frmWorkOrderTable : Form
    {
        int Year = 0;
        int Month = 0;
        int ID = 0;
        string PrCode = "";
        bool NOConf = false;

        DataTable dtMontALL = new DataTable();
        DataTable dtYearALL = new DataTable();
        DataTable dtTrailALL = new DataTable();
        DataTable dtMont = new DataTable();
        DataTable dtYear = new DataTable();
        DataTable dtTrail = new DataTable();

        public frmWorkOrderTable()
        {
            InitializeComponent();
        }

        private void radioTrail_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioTrail.Checked)
                return;
            grwMont.Visible = false;
            grwMont.Dock = DockStyle.None;
            grwTrail.Visible = true;
            grwTrail.Dock = DockStyle.Fill;
            grwYear.Visible = false;
            grwYear.Dock = DockStyle.None;
            txtMonth.Enabled = true;
            chkConf.Enabled = false;

        }

        private void radioYear_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioYear.Checked)
                return;
            grwMont.Visible = false;
            grwMont.Dock = DockStyle.None;
            grwTrail.Visible = false;
            grwTrail.Dock = DockStyle.None;
            grwYear.Visible = true;
            grwYear.Dock = DockStyle.Fill;

            txtMonth.Enabled = false;
            chkConf.Enabled = false;
        }

        private void radioMonth_CheckedChanged(object sender, EventArgs e)
        {
            if (!radioMonth.Checked)
                return;
            grwMont.Visible = true;
            grwMont.Dock = DockStyle.Fill;
            grwTrail.Visible = false;
            grwTrail.Dock = DockStyle.None;
            grwYear.Visible = false;
            grwYear.Dock = DockStyle.None;
            txtMonth.Enabled = true;
            chkConf.Enabled = true;
        }

        private void frmWorkOrderTable_Load(object sender, EventArgs e)
        {
            radioMonth.Checked = true;
            txtYear.Text = "1399";
        }
        private void IsNumbric(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            txtYear.BackColor = Color.White;
            if (txtYear.TextLength == 4)
            {
                Year = int.Parse(txtYear.Text);
                if (Year < 1398 || Year > 1500)
                {
                    Year = 0;
                    txtYear.BackColor = Color.Yellow;
                    return;
                }
            }
            else
            {
                Year = 0;
                return;
            }
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker2.IsBusy != true)
            {
                backgroundWorker2.RunWorkerAsync();
            }
        }
        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            txtMonth.BackColor = Color.White;
            if (txtMonth.TextLength > 0)
            {
                try
                {

                    int temp = int.Parse(txtMonth.Text);
                    if (temp < 13 && temp > 0)
                        Month = temp;
                    else
                    {
                        Month = 0;
                        txtMonth.BackColor = Color.Yellow;
                    }
                }
                catch (Exception)
                {
                    txtMonth.Clear();
                    return;
                }
            }
            else
            {
                Month = 0;
            }
            if (Year == 0)
                return;
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void txtID_TextChanged(object sender, EventArgs e)
        {
            if (txtID.TextLength > 0)
            {
                try
                {
                    int temp = int.Parse(txtID.Text);
                    if (temp > 0)
                        ID = temp;
                    else
                        txtID.Clear();
                }
                catch (Exception) { txtID.Clear(); return; }
            }
            else
            {
                ID = 0;
            }
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            if (Year != 0)
            {
                GetData();
            }
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
            if (dtMont.Columns.Count > 0)
            {
                dtMont.Columns.Add("ConfirmationView");
                for (int i = 0; i < dtMont.Rows.Count; i++)
                {
                    LINQDataContext dt = new LINQDataContext();

                    if (Convert.ToBoolean(dtMont.Rows[i]["Confirmation"]))
                        dtMont.Rows[i]["ConfirmationView"] = "تایید شده";
                    else
                    {
                        var tt = (from s in dt.WorkOrderConfirmations where s.ID == int.Parse(dtMont.Rows[i]["ID"].ToString()) && s.Year == int.Parse(dtMont.Rows[i]["Year"].ToString()) select s).SingleOrDefault();
                        if (tt.OP1Condition == false || tt.OP2Condition == false)
                        {
                            dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید روسای تولید";
                            continue;
                        }
                        else
                        {
                            if (tt.OP3Condition == false)
                            {
                                if (tt.OP3Code == 12063)
                                {
                                    dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید مدیر تولید";
                                    continue;
                                }
                                else
                                {
                                    dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید مدیر تحقیق و توسعه";
                                    continue;
                                }
                            }
                            else
                            {
                                dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید مدیر عامل";
                                continue;
                            }

                        }
                    }
                }
            }
            grwMont.DataSource = dtMont;
            grwYear.DataSource = dtYear;
            grwTrail.DataSource = dtTrail;
        }
        private void GetDataYear()
        {
            if (Year == 0)
            {
                dtMontALL.Rows.Clear();
                dtYearALL.Rows.Clear();
                dtTrailALL.Rows.Clear();
            }
            else
            {
                LINQDataContext db = new LINQDataContext();
                dtMontALL = Utility.ToDataTable<WorkOrderMonth>((from s in db.WorkOrderMonths where s.Year == Year select s).ToList());
                dtYearALL = Utility.ToDataTable<WorkOrderYear>((from s in db.WorkOrderYears where s.Year == Year select s).ToList());
                dtTrailALL = Utility.ToDataTable<WorkOrderTrail>((from s in db.WorkOrderTrails where s.Year == Year select s).ToList());
            }
        }
        private void backgroundWorker2_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(500);
            GetDataYear();
            GetData();
        }

        private void backgroundWorker2_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radWaitingBar1.StopWaiting();
            radWaitingBar1.Visible = false;
            if (dtMont.Columns.Count > 0)
            {
                dtMont.Columns.Add("ConfirmationView");
                for (int i = 0; i < dtMont.Rows.Count; i++)
                {
                    LINQDataContext dt = new LINQDataContext();

                    if (Convert.ToBoolean(dtMont.Rows[i]["Confirmation"]))
                        dtMont.Rows[i]["ConfirmationView"] = "تایید شده";
                    else
                    {
                        var tt = (from s in dt.WorkOrderConfirmations where s.ID == int.Parse(dtMont.Rows[i]["ID"].ToString()) && s.Year == int.Parse(dtMont.Rows[i]["Year"].ToString()) select s).SingleOrDefault();
                        if (tt.OP1Condition == false || tt.OP2Condition == false)
                        {
                            dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید روسای تولید";
                            continue;
                        }
                        else
                        {
                            if (tt.OP3Condition == false)
                            {
                                if (tt.OP3Code == 12063)
                                {
                                    dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید مدیر تولید";
                                    continue;
                                }
                                else
                                {
                                    dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید مدیر تحقیق و توسعه";
                                    continue;
                                }
                            }
                            else
                            {
                                dtMont.Rows[i]["ConfirmationView"] = "در انتظار تایید مدیر عامل";
                                continue;
                            }

                        }
                    }
                }
            }
            grwMont.DataSource = dtMont;
            grwYear.DataSource = dtYear;
            grwTrail.DataSource = dtTrail;
        }
        private void GetData()
        {
            if (Year != 0)
            {
                bool multi = false;
                string ShartM = "";
                string ShartY = "";
                string ShartT = "";



                if (Month != 0)
                {
                    ShartM = "Month=" + Month;
                    ShartT = "Month=" + Month;
                    multi = true;
                }
                if (ID != 0)
                {
                    if (multi)
                    {
                        ShartM += " and ";
                        ShartT += " and ";
                        multi = false;
                    }
                    ShartM += "ID=" + ID;
                    ShartT += "ID=" + ID;
                    ShartY = "ID=" + ID;
                    multi = true;
                }
                if (PrCode != "")
                {
                    if (multi)
                    {
                        ShartM += " and ";
                        if (ShartY != "") ShartY += " and ";
                        ShartT += " and ";
                        multi = false;
                    }
                    ShartM += string.Format("(ProdectionCode like '%{0}%' or ProdectionName like '%{0}%')", PrCode);
                    ShartT += string.Format("(ProdectionCode like '%{0}%' or ProdectionName like '%{0}%')", PrCode);
                    ShartY += string.Format("(ProdectionCode like '%{0}%' or ProdectionName like '%{0}%')", PrCode);
                    multi = true;
                }
               
                if (NOConf)
                {
                    if (multi)
                    {
                        ShartM += " and ";
                        multi = false;
                    }
                    ShartM += "Confirmation=" + !Accepted;
                    multi = true;
                }



                if (ShartM == "")
                    dtMont = Utility.ToDataTable<WorkOrderMonth>(dtMontALL.Select("", "ID desc"));
                else
                    dtMont = Utility.ToDataTable<WorkOrderMonth>(dtMontALL.Select(ShartM, "ID desc"));
                if (ShartT == "")
                    dtTrail = Utility.ToDataTable<WorkOrderTrail>(dtTrailALL.Select("", "ID desc"));
                else
                    dtTrail = Utility.ToDataTable<WorkOrderTrail>(dtTrailALL.Select(ShartT, "ID desc"));
                if (ShartY == "")
                    dtYear = Utility.ToDataTable<WorkOrderYear>(dtYearALL.Select("", "ID desc"));
                else
                    dtYear = Utility.ToDataTable<WorkOrderYear>(dtYearALL.Select(ShartY, "ID desc"));

            }
            else
            {
                dtMont.Rows.Clear();
                dtYear.Rows.Clear();
                dtTrail.Rows.Clear();
            }

        }

       
        bool Accepted = true;
        private void chkConf_CheckedChanged(object sender, EventArgs e)
        {
            NOConf = chkConf.Checked;
            if (chkConf.Checked)
                chkAccept.Enabled = true;
            else
                chkAccept.Enabled = false;

            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void chkAccept_ValueChanged(object sender, EventArgs e)
        {
            Accepted = chkAccept.Value;
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void grwTrail_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmWorkOrderView frm = new frmWorkOrderView();
                frm.WtrailEdit = true;
                frm.ID = Convert.ToInt64(e.Row.Cells["uid"].Value);
                frm.ShowDialog();
            }
        }

        private void grwYear_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmWorkOrderView frm = new frmWorkOrderView();
                frm.WYearEdit = true;
                frm.ID = Convert.ToInt64(e.Row.Cells["uid"].Value);
                frm.ShowDialog();
            }
        }

        private void grwMont_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                frmWorkOrderConfirmation frm = new frmWorkOrderConfirmation();
                LINQDataContext db = new LINQDataContext();
                frm.Data = (from s in db.WorkOrderConfirmations
                            where s.ID == int.Parse(e.Row.Cells["ID"].Value.ToString()) && s.Year == int.Parse(e.Row.Cells["Year"].Value.ToString())
                            select s).FirstOrDefault();
                if (frm.Data != null)
                {
                    frm.Accept = bool.Parse(e.Row.Cells["Confirmation"].Value.ToString());
                    if (e.Row.Cells["EditNum"].Value.ToString() != "0")
                    {
                        frm.EditText = e.Row.Cells["EditText"].Value.ToString();
                    }
                    frm.ShowDialog();
                    if (frm.Accept)
                    {
                        e.Row.Cells["Confirmation"].Value = "True";
                        e.Row.Cells["ConfirmationView"].Value = "تایید شده";
                    }
                    if (frm.changed)
                    {
                        radWaitingBar1.StartWaiting();
                        radWaitingBar1.Visible = true;
                        if (backgroundWorker2.IsBusy != true)
                        {
                            backgroundWorker2.RunWorkerAsync();
                        }
                    }
                }

            }
        }

        private void btnEditMonth_Click(object sender, EventArgs e)
        {
            frmWorkOrderView frm = new frmWorkOrderView();
            frm.WMontEdit = true;
            frm.ID = Convert.ToInt64(grwMont.SelectedRows[0].Cells["uid"].Value);
            frm.ShowDialog();
            if (frm.Delete || frm.Edited)
            {
                radWaitingBar1.StartWaiting();
                radWaitingBar1.Visible = true;
                if (backgroundWorker2.IsBusy != true)
                {
                    backgroundWorker2.RunWorkerAsync();
                }
            }
        }

        private void menuMonth_Opening(object sender, CancelEventArgs e)
        {
            if (grwMont.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void txtFastCode_TextChanged(object sender, EventArgs e)
        {
            PrCode = txtFastCode.Text;

            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
    }
}
