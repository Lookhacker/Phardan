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
    public partial class frmInventory : Form
    {
        DataTable AllData = new DataTable();
        public string PRCode;
        public string PRName;
        DataTable templateNum;
        int PRSalon1 = 0;
        int PRControl1 = 0;
        int StoreSalon1 = 0;
        int StoreControl1 = 0;
        int Sell1 = 0;
        int Wastage1 = 0;

        public frmInventory()
        {
            InitializeComponent();
        }

        private void frmInventory_Load(object sender, EventArgs e)
        {
            pnlWait.Visible = true;
            radWaitingBar1.StartWaiting();
            if (FetchAllData.IsBusy != true)
            {
                FetchAllData.RunWorkerAsync();
            }
            lblProdectCode.Text = PRCode;
            lblProdectName.Text = PRName;

        }

        private void FetchAllData_DoWork(object sender, DoWorkEventArgs e)
        {
            FetchData();
            FillDataForTable(AllData);
        }

        private void FetchAllData_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            combGhaleb.DataSource = templateNum;
            combGhaleb.SelectedIndex = -1;
            combGhaleb.Enabled = moldch;
            gridAll.Columns["TemplateNum"].IsVisible = moldch;
            txtPRSalon.Text = PRSalon1.ToString();
            txtPRControl.Text = PRControl1.ToString();
            txtStoreSalon.Text = StoreSalon1.ToString();
            txtStoreControl.Text = StoreControl1.ToString();
            txtSell.Text = Sell1.ToString();
            txtWastage.Text = Wastage1.ToString();
            gridAll.DataSource = ViewTbl;
            pnlWait.Visible = false;
            radWaitingBar1.StopWaiting();
            chkMold.Enabled = moldch;
        }

        private void FetchData()
        {
           
            LINQDataContext DataBase = new LINQDataContext();

            AllData = Utility.ToDataTable<BalanceAll>((from s in DataBase.BalanceAlls where s.ProdectionCode == PRCode && s.ProdectionName == PRName select s).ToList());

            var query = from s in DataBase.QuickSelects
                        where s.Product_Code == PRCode.ToString()
                        select new
                        {
                            mmp = s.kind
                        };
            if (query.First().mmp == "M")
            {
                var query2 = (from s in DataBase.BalanceAlls
                              where s.ProdectionCode == PRCode
                              orderby s.TemplateNum

                              select new
                              {
                                  TemplateNum = s.TemplateNum
                              }).Distinct();
                            
                templateNum = Utility.ToDataTable(query2.ToList());
                moldch = true;


                
            }
            else
            {
                moldch = false;
            }
        }
        private void SendFilter()
        {
            MoldNumtxt = combGhaleb.Text;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }
        private void Filter()
        {
            bool multi = false;
            string Shart = "";
            if (chkMold.Checked == true)
            {
                if (combGhaleb.Items.Count > 1)
                {
                    Shart = "TemplateNum=" + MoldNumtxt;
                    multi = true;
                }
            }

            if (chkLot.Checked == true)
            {
                if (txtLotStart.Text.Length > 1)
                {
                    if (multi)
                    {
                        Shart += " and ";
                        multi = false;
                    }
                    Shart += "LotNum >= " + startLot;
                    multi = true;
                }
                if (txtLotEnd.Text.Length > 1)
                {
                    if (multi)
                    {
                        Shart += " and ";
                        multi = false;
                    }
                    Shart += "LotNum <= " + endLot;
                    multi = true;
                }
            }


            if (Shart == "")
            {
                FillDataForTable(AllData);
            }
            else
            {
                DataRow[] result = AllData.Select(Shart, "LotNum ASC");
                DataTable tmp = Utility.ToDataTable<BalanceAll>(result);

                FillDataForTable(tmp);
            }
        }
        DataTable ViewTbl;
        private void FillDataForTable(DataTable allData)
        {
            ViewTbl = allData;

            PRSalon1 = allData.Select().Sum(x => int.Parse(x["PRSalon"].ToString()));
            PRControl1 = allData.Select().Sum(x => int.Parse(x["PRControl"].ToString()));
            StoreSalon1 = allData.Select().Sum(x => int.Parse(x["StoreSalon"].ToString()));
            StoreControl1 = allData.Select().Sum(x => int.Parse(x["StoreControl"].ToString()));
            Sell1 = allData.Select().Sum(x => int.Parse(x["Sell"].ToString()));
            Wastage1 = allData.Select().Sum(x => int.Parse(x["Wastage"].ToString()));

        }

        private void chkMold_CheckedChanged(object sender, EventArgs e)
        {
            if (chkMold.Checked)
            {
                combGhaleb.Enabled = true;
                combGhaleb.SelectedIndex = 0;
            }
            else
            {
                combGhaleb.Enabled = false;
                combGhaleb.SelectedIndex = -1;
                if (combGhaleb.Items.Count > 1)
                {
                    SendFilter();
                }
            }
        }
        private void combGhaleb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (chkMold.Checked)
            {
                if (combGhaleb.Items.Count > 1)
                {
                    SendFilter();
                }
            }
        }

        string startLot;
        string endLot;
        private string MoldNumtxt;
        private bool moldch;

        private void chkLot_CheckedChanged(object sender, EventArgs e)
        {
            txtLotStart.Enabled = txtLotEnd.Enabled = chkLot.Checked;
            txtLotStart.Text = txtLotEnd.Text = "";
            SendFilter();
        }
        private void txtLotStart_TextChanged(object sender, EventArgs e)
        {
            if (txtLotStart.Text.Length > 1)
            {
                startLot = txtLotStart.Text;
                for (int i = 5; i > txtLotStart.Text.Length; i--)
                {
                    startLot += "0";
                }
                SendFilter();
            }
        }
        private void txtLotEnd_TextChanged(object sender, EventArgs e)
        {
            if (txtLotEnd.Text.Length > 1)
            {
                endLot = txtLotEnd.Text;
                for (int i = 5; i > txtLotEnd.Text.Length; i--)
                {
                    endLot += "9";
                }
                SendFilter();
            }

        }
        private void chkZeroLot_CheckedChanged(object sender, EventArgs e)
        {
            SendFilter();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();

        }
        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmInventoryDetails frm = new frmInventoryDetails();
                frm.PRcode = PRCode;
                frm.PRname = PRName;
                frm.Template = gridAll.Rows[e.RowIndex].Cells["TemplateNum"].Value.ToString();
                frm.LotNum = gridAll.Rows[e.RowIndex].Cells["LotNum"].Value.ToString();
                frm.ShowDialog();
            }
        }
        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Filter();
        }
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            gridAll.DataSource = ViewTbl;

            txtPRSalon.Text = PRSalon1.ToString();
            txtPRControl.Text = PRControl1.ToString();
            txtStoreSalon.Text = StoreSalon1.ToString();
            txtStoreControl.Text = StoreControl1.ToString();
            txtSell.Text = Sell1.ToString();
            txtWastage.Text = Wastage1.ToString();
        }
        private void txtKeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
    }
}