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
    public partial class frmTemplateAgenda : Form
    {
        public frmTemplateAgenda()
        {
            InitializeComponent();
        }

        private void frmTemplateAgenda_Load(object sender, EventArgs e)
        {
            radWaitingBar1.StartWaiting();
            radWaitingBar1.Visible = true;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        DataTable AllData;
        private void getdata()
        {
            LINQDataContext db = new LINQDataContext();
            AllData = Utility.ToDataTable(db.MoldWorkOrderViews.ToList());
            filter();
        }

        private void filter()
        {
            DataTable tmp;
            bool multi = false;
            string Shart = "";
              
            if (txtId.TextLength > 0)
            {
                Shart = string.Format("(ID={0} or WorkOrderIDOld={0} or WorkOrderIDNew={0})", txtId.Text);
                multi = true;
            }
            if (txtMach.TextLength > 0)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }

                Shart += string.Format("(MachineOld={0} or MachineNew={0})", txtMach.Text);
                multi = true;
            }
            if (chkConf.Checked)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }
                if (chkAccept.Value)
                    Shart += "Request=false";
                else
                    Shart += "Request=true";
            }
            if (txtYear.TextLength == 4)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }

                Shart += "Convert(Year, 'System.String') like '%" + txtYear.Text + "%'";
                multi = true;
            }
            if (txtPrName.TextLength > 0)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }
                Shart += "(PROld like '%" + txtPrName.Text + "%' or PRNew like '%" + txtPrName.Text + "%')";
                multi = true;
            }

            if (Shart == "")
                tmp = Utility.ToDataTable<MoldWorkOrderView>(AllData.Select("", "ID desc"));
            else
                tmp = Utility.ToDataTable<MoldWorkOrderView>(AllData.Select(Shart, "ID desc"));

            tmp.Columns.Add("RequestView");
            for (int i = 0; i < tmp.Rows.Count; i++)
            {
                if (Convert.ToInt32(tmp.Rows[i]["WorkOrderIDOld"].ToString()) == 0)
                {
                    tmp.Rows[i]["PROld"] = "-----";
                    tmp.Rows[i]["ChangeDate"] = "-----";
                }
                if (Convert.ToBoolean(tmp.Rows[i]["Request"].ToString()))
                    tmp.Rows[i]["RequestView"] = "انجام شده";
                else
                    tmp.Rows[i]["RequestView"] = "انجام نشده";

                if (bool.Parse(tmp.Rows[i]["OldTrail"].ToString()))
                {
                    LINQDataContext dt = new LINQDataContext();
                    var aaa = tmp.Rows[i]["Year"].ToString();
                    var aa2 = tmp.Rows[i]["WorkOrderIDOld"].ToString();

                    var tmp2 = (from s in dt.WorkOrderTrails where s.Year == int.Parse(tmp.Rows[i]["Year"].ToString()) && s.ID == int.Parse(tmp.Rows[i]["WorkOrderIDOld"].ToString()) select s).Single();
                    tmp.Rows[i]["MachineOld"] = tmp2.MachineNum; 
                    tmp.Rows[i]["PROld"] = tmp2.ProdectionName;
                    tmp.Rows[i]["PRtmpOld"] = tmp2.TemplateNum;
                    tmp.Rows[i]["ChangeDate"] = tmp2.Year + "-" + tmp2.Month + "-" + tmp2.DayFinish;
                }
                if (bool.Parse(tmp.Rows[i]["NewTrail"].ToString()))
                {
                    LINQDataContext dt = new LINQDataContext();
                    var aaa = tmp.Rows[i]["Year"].ToString();
                    var aa2 = tmp.Rows[i]["WorkOrderIDNew"].ToString();

                    var tmp2 = (from s in dt.WorkOrderTrails where s.Year == int.Parse(tmp.Rows[i]["Year"].ToString()) && s.ID == int.Parse(tmp.Rows[i]["WorkOrderIDNew"].ToString()) select s).Single();
                    tmp.Rows[i]["MachineNew"] = tmp2.MachineNum;
                    tmp.Rows[i]["PRNew"] = tmp2.ProdectionName;
                    tmp.Rows[i]["PRtmpNew"] = tmp2.TemplateNum;
                    tmp.Rows[i]["ComplateDate"] = tmp2.Year + "-" + tmp2.Month + "-" + tmp2.DayStart;
                }

            }
            GridALL.DataSource = tmp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آیا قالب تحویل شده است؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int uid = int.Parse(GridALL.SelectedRows[0].Cells["uid"].Value.ToString());

                LINQDataContext db = new LINQDataContext();
                TemplateAgend tmp = (from s in db.TemplateAgends where s.uid == uid select s).SingleOrDefault();
                tmp.AcceptTime = Tools.GetTimeNow();
                tmp.AcceptOP = DataAccess.User.PCode;
                tmp.Request = true;
                try { db.SubmitChanges(); getdata(); }
                catch (Exception) { }
            }
        }

        private void KeyPresss(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void chkConf_CheckedChanged(object sender, EventArgs e)
        {
            chkAccept.Enabled = chkConf.Checked;
            filter();
        }

        private void txtMach_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void chkAccept_ValueChanged(object sender, EventArgs e)
        {
            filter();
        }



        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void txtPrName_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (GridALL.SelectedRows.Count == 0)
            {
                e.Cancel = true;
                return;
            }

            if (int.Parse((GridALL.SelectedRows[0].Cells["WorkOrderIDOld"].Value.ToString())) == 0)
                btnOldView.Visible = false;
            else
                btnOldView.Visible = true;

            if (DataAccess.User.Admin)
            {
                if (bool.Parse((GridALL.SelectedRows[0].Cells["Request"].Value.ToString())))
                {
                    btnAccept.Visible = btnAccept.Enabled = false;
                    btnCancel.Visible = btnCancel.Enabled = true;
                }
                else
                {
                    btnAccept.Visible = btnAccept.Enabled = true;
                    btnCancel.Visible = btnCancel.Enabled = false;
                }

            }
            else
            {
                if (int.Parse(DataAccess.Availability.Ghaleb[2].ToString()) > 1)
                {
                    if (bool.Parse((GridALL.SelectedRows[0].Cells["Request"].Value.ToString())))
                        btnAccept.Visible = btnAccept.Enabled = false;
                    else
                        btnAccept.Visible = btnAccept.Enabled = true;

                    btnCancel.Visible = btnCancel.Enabled = false;
                }
                else
                {
                    btnAccept.Visible = btnAccept.Enabled = false;
                    btnCancel.Visible = btnCancel.Enabled = false;
                }
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(400);
            
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            radWaitingBar1.Visible = false;
            radWaitingBar1.StopWaiting();
            getdata();
        }

        private void btnNewView_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(GridALL.SelectedRows[0].Cells["WorkOrderIDNew"].Value.ToString());
            bool trail = bool.Parse(GridALL.SelectedRows[0].Cells["NewTrail"].Value.ToString());
            if (ID > 0)
            {
                int Year = int.Parse(GridALL.SelectedRows[0].Cells["Year"].Value.ToString());
                if (trail)
                {
                    LINQDataContext db = new LINQDataContext();
                    var tmp = (from s in db.WorkOrderTrails where s.ID == ID && s.Year == Year select s.uid);
                    if (tmp.Count() == 1)
                    {
                        frmWorkOrderView frm = new frmWorkOrderView();
                        frm.WtrailEdit = true;
                        frm.ID = Convert.ToInt64(tmp.SingleOrDefault());
                        frm.ShowDialog();
                    }
                }
                else
                {
                    LINQDataContext db = new LINQDataContext();
                    var tmp = (from s in db.WorkOrderMonths where s.ID == ID && s.Year == Year select s.uid);
                    if (tmp.Count() == 1)
                    {
                        frmWorkOrderView frm = new frmWorkOrderView();
                        frm.WMontEdit = true;
                        frm.ID = Convert.ToInt64(tmp.SingleOrDefault());
                        frm.ShowDialog();
                    }

                }
            }

        }

        private void btnOldView_Click(object sender, EventArgs e)
        {
            int ID = int.Parse(GridALL.SelectedRows[0].Cells["WorkOrderIDOld"].Value.ToString());
            bool trail = bool.Parse(GridALL.SelectedRows[0].Cells["OldTrail"].Value.ToString());
            if (ID > 0)
            {
                int Year = int.Parse(GridALL.SelectedRows[0].Cells["Year"].Value.ToString());
                if (trail)
                {
                    LINQDataContext db = new LINQDataContext();
                    var tmp = (from s in db.WorkOrderTrails where s.ID == ID && s.Year == Year select s.uid);
                    if (tmp.Count() == 1)
                    {
                        frmWorkOrderView frm = new frmWorkOrderView();
                        frm.WtrailEdit = true;
                        frm.ID = Convert.ToInt64(tmp.SingleOrDefault());
                        frm.ShowDialog();
                    }
                }
                else
                {
                    LINQDataContext db = new LINQDataContext();
                    var tmp = (from s in db.WorkOrderMonths where s.ID == ID && s.Year == Year select s.uid);
                    if (tmp.Count() == 1)
                    {
                        frmWorkOrderView frm = new frmWorkOrderView();
                        frm.WMontEdit = true;
                        frm.ID = Convert.ToInt64(tmp.SingleOrDefault());
                        frm.ShowDialog();
                    }
                }
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آیا از لغو دستور کار اطمینان دارید؟", "سوال", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                int uid = int.Parse(GridALL.SelectedRows[0].Cells["uid"].Value.ToString());
                LINQDataContext db = new LINQDataContext();
                TemplateAgend tmp = (from s in db.TemplateAgends where s.uid == uid select s).SingleOrDefault();
                tmp.AcceptTime = null;
                tmp.AcceptOP = 0;
                tmp.Request = false;
                try { db.SubmitChanges(); getdata(); }
                catch (Exception) { }
            }
        }
    }
}
