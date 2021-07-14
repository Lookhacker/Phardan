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
    public partial class frmMoldPress : Form
    {
        DataAccess Data = new DataAccess();
        DataTable DT = new DataTable();

        public frmMoldPress()
        {
            InitializeComponent();
        }

        private void frmMoldPress_Load(object sender, EventArgs e)
        {
            FetchDataGrid("");
        }

        bool Filter; string FilterString;
        private void btnAdd_Click(object sender, EventArgs e)
        {
            Filter = false;
            if (txtYear.Text.Length == 4)
            {

                if (txtStart.Text.Length > 2 && txtEnd.Text.Length > 2)
                {
                    String[] strDateStart = txtStart.Text.Split('/', '-');
                    String[] strDateEnd = txtEnd.Text.Split('/', '-');
                    if (strDateStart.Length > 1 && strDateEnd.Length > 1)
                    {

                        int Tstart = ((Convert.ToInt16(strDateStart[0]) - 1) * 30) + Convert.ToInt16(strDateStart[1]);
                        if (Convert.ToInt16(strDateStart[0]) > 6)
                            Tstart += 6;
                        else
                            Tstart += Convert.ToInt16(strDateStart[0]) - 1;

                        int TEnd = ((Convert.ToInt16(strDateEnd[0]) - 1) * 30) + Convert.ToInt16(strDateEnd[1]);
                        if (Convert.ToInt16(strDateEnd[0]) > 6)
                            TEnd += 6;
                        else
                            TEnd += Convert.ToInt16(strDateEnd[0]) - 1;

                        Tstart -= 6;
                        TEnd -= 6;
                        FilterString = " and Year={0} and (((Month-1)*30)+Day >={1} and ((Month-1)*30)+Day<={2})";
                        FilterString = string.Format(FilterString, Convert.ToInt32(txtYear.Text), Tstart, TEnd);
                        Filter = true;
                    }
                    else
                    {
                        MessageBox.Show("فرمت وارد شده تاریخ اشتباه است", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        Filter = false;
                        FilterString = "";
                        txtStart.Clear();
                        txtEnd.Clear();
                        return;
                    }

                }
                else
                {
                    MessageBox.Show("فرمت وارد شده تاریخ اشتباه است ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    Filter = false;
                    FilterString = "";
                    txtStart.Clear();
                    txtEnd.Clear();
                    return;
                }

            }
            else
            {
                MessageBox.Show("فرمت وارد شده سال اشتباه است ", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                Filter = false;
                FilterString = "";
                txtYear.Clear();
                return;
            }

            FetchDataGrid(FilterString);

        }

        private void FetchDataGrid(string Valid)
        {





            string Sql = "SELECT DISTINCT [Mold].[MoldCode],[Mold].[MoldNum], [QuickSelect].Product_Code,  [QuickSelect].Product_Name FROM[Mold],[QuickSelect],[ProductionData]  where([Mold].IDProtection=[QuickSelect].ID and ProductionData.ProdectionCode= QuickSelect.Product_Code and ProductionData.TemplateNum= Mold.MoldNum)";
            DT = Data.Select(Sql + Valid);
            gridAll.DataSource = DT;
        }
        long Temp;
        long temp2;
        private void FetchBar(string Valid)
        {
            string Sql = "SELECT [Mold].[MoldCode],[Mold].[MoldNum], [ProductionData].PartNum,[ProductionData].ControlNum,[ProductionData].WastageNum,[ProductionData].ProdectionCode,[ProductionData].ProdectionName ,[ProductionData].ActiveKaviteh FROM [Mold],[ProductionData],[QuickSelect] where ([QuickSelect].Product_Code=[ProductionData].ProdectionCode and [Mold].IDProtection=[QuickSelect].ID and [ProductionData].TemplateNum= [Mold].MoldNum)";
            DT = Data.Select(Sql + Valid);
            Temp = 0;
            for (int i = 0; i < DT.Rows.Count; i++)
            {
                int a = ((int)DT.Rows[i]["PartNum"] + (int)DT.Rows[i]["ControlNum"] + (int)DT.Rows[i]["WastageNum"]) / (int)DT.Rows[i]["ActiveKaviteh"];
                Temp += a;
            }
            if (DT.Rows.Count > 0)
            {
                lblMoldName.Text = DT.Rows[0]["MoldCode"].ToString();
            }
            temp2 = Temp - 5;

        }

        private void gridAll_SelectionChanged(object sender, EventArgs e)
        {
            string Sqlwhere = "and (ProdectionCode='{0}' and TemplateNum={1})";
            Sqlwhere = string.Format(Sqlwhere, gridAll.SelectedRows[0].Cells["Product_Code"].Value.ToString().Trim(), gridAll.SelectedRows[0].Cells["MoldNum"].Value);
            if (Filter)
            {
                Sqlwhere += FilterString;
            }
            else
            {
                if (txtYear.Text.Length == 4)
                {
                    int year = Convert.ToInt32(txtYear.Text);
                    if (year > 1397 && year < 1500)
                    {
                        Sqlwhere += " and Year=" + year.ToString();
                    }
                    else
                    {
                        Sqlwhere += " and Year=1398";
                    }
                }
                else
                {
                    Sqlwhere += " and Year=1399";
                }

            }
            FetchBar(Sqlwhere);
            return;
        }

        
        private void txtStart_KeyPress(object sender, KeyPressEventArgs e)
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

        private void txtYear_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        
    }
}
