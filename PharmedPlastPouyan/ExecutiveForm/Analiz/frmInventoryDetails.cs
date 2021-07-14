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
    public partial class frmInventoryDetails : Form
    {
        public string PRcode;
        public string PRname;
        public string Template;
        public string Shift;
        public string LotNum;
        public int IDPR;
        DataTable tblPRSalon;
        DataTable tblPRControl;
        DataTable tblStoreSalon;
        DataTable tblStoreControl;
        DataTable tblSell;
        DataTable tblWastage;
        DataTable tblDHR;


        public frmInventoryDetails()
        {
            InitializeComponent();
        }

        private void getAllData()
        {
            LINQDataContext DataBase = new LINQDataContext();
            tblPRSalon = Utility.ToDataTable<PRSalon>((from s in DataBase.PRSalons where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum==int.Parse(Template) select s).ToList());
            tblPRControl = Utility.ToDataTable<PRControl>((from s in DataBase.PRControls where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum == int.Parse(Template) select s).ToList());
            tblStoreSalon = Utility.ToDataTable<StoreSalon>((from s in DataBase.StoreSalons where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum == int.Parse(Template) select s).ToList());
            tblStoreControl = Utility.ToDataTable<StoreControl>((from s in DataBase.StoreControls where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum == int.Parse(Template) select s).ToList());
            tblSell = Utility.ToDataTable<Sell>((from s in DataBase.Sells where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum == int.Parse(Template) select s).ToList());
            tblWastage = Utility.ToDataTable<Wastage>((from s in DataBase.Wastages where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum == int.Parse(Template) select s).ToList());
            tblDHR = Utility.ToDataTable<DHR>((from s in DataBase.DHRs where s.ProdectionCode == PRcode && s.LotNum == int.Parse(LotNum) && s.TemplateNum == int.Parse(Template) select s).ToList());
        }

        private void frmInventoryDetails_Load(object sender, EventArgs e)
        {
            getAllData();
            if (LotNum[LotNum.Length - 1] == '1')
                lblShift.Text = "روز";
            else
                lblShift.Text = "شب";
            lblProdectCode.Text = PRcode;
            lblProdectName.Text = PRname;
            lblLot.Text = LotNum;
            lblMold.Text = Template;

            comType.SelectedIndex = 0;

        }

        LINQDataContext DataBase = new LINQDataContext();
        DataAccess Data = new DataAccess();

        private void ResualtTotal(DataTable tmp)
        {
            var res = tmp.Select();
            var sum1 = res.Sum(row => row.Field<int>("Increase"));
            var sum2 = res.Sum(row => row.Field<int>("Decrease"));
            TotalView.Text = (sum1 - sum2).ToString();
        }

        private void getData()
        {
            DataTable tmp;
            switch (comType.SelectedIndex)
            {
                case 0:
                    tmp = tblPRSalon;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                case 1:
                    tmp = tblPRControl;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                case 2:
                    tmp = tblStoreSalon;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                case 3:
                    tmp = tblStoreControl;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                case 4:
                    tmp = tblDHR;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                case 5:
                    tmp = tblSell;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                case 6:
                    tmp = tblWastage;
                    gridAll.DataSource = tmp;
                    ResualtTotal(tmp);
                    break;
                default:
                    break;
            }

        }

        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {

                switch (gridAll.Rows[e.RowIndex].Cells["Location"].Value.ToString())
                {
                    case "ProductionData":
                        frmPREdit frm = new frmPREdit();
                        frm.IDPR = Convert.ToInt32(gridAll.Rows[e.RowIndex].Cells["LocationID"].Value);
                        frm.ShowDialog();
                        break;
                    case "AssemblyData":
                        frmAssemblyview frmas = new frmAssemblyview();
                        frmas.IDAS = Convert.ToInt32(gridAll.Rows[e.RowIndex].Cells["LocationID"].Value);
                        frmas.ShowDialog();
                        break;
                    case "GranuleData":
                        frmGranuleView frmgr = new frmGranuleView();
                        frmgr.IDGR = Convert.ToInt32(gridAll.Rows[e.RowIndex].Cells["LocationID"].Value);
                        frmgr.ShowDialog();
                        break;
                    default:
                        break;
                }

            }
        }

        private void comTemplate_SelectedIndexChanged(object sender, EventArgs e)
        {
            getData();
        }
    }
}
