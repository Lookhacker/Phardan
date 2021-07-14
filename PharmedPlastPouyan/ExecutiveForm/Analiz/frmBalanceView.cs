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
    public partial class frmBalanceView : Form
    {
        DataTable AllData = new DataTable();
        DataTable gridview = new DataTable();
        public frmBalanceView()
        {
            InitializeComponent();
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(20000);
            getData();
            getData2();
            getData3();
            FillDataForTable();
        }

        private void FillDataForTable()
        {
            LINQDataContext DataBase = new LINQDataContext();
            AllData = Utility.ToDataTable<BalanceView>(DataBase.BalanceViews.OrderBy(x => x.ProdectionName).ToList());
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            pnlWait.Visible = false;
            radWaitingBar1.StopWaiting();
            gridAll.DataSource = AllData;
            Radif();
        }

        private void Radif()
        {
            int tmp = 1;
            foreach (var item in gridAll.Rows)
            {
                item.Cells["Radif"].Value = tmp.ToString();
                tmp++;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }



        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmInventory frm = new frmInventory();
                frm.PRCode = gridAll.Rows[e.RowIndex].Cells["ProdectionCode"].Value.ToString();
                frm.PRName = gridAll.Rows[e.RowIndex].Cells["ProdectionName"].Value.ToString();
                frm.ShowDialog();
            }

        }

        private void frmBalanceView_Load(object sender, EventArgs e)
        {

            pnlWait.Visible = true;
            radWaitingBar1.StartWaiting();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void getData()
        {
            LINQDataContext DataBase = new LINQDataContext();
            var tmp = from s in DataBase.GranuleDatas where s.stock == false orderby s.LotNum select s;
            foreach (var item in tmp)
            {
                var t = from s in DataBase.BalanceAlls where s.ProdectionCode == item.ProdectionCode && s.LotNum == item.LotNum select s;
                if (t.Count() == 0)
                {
                    BalanceAll balance = new BalanceAll();
                    balance.LotNum = item.LotNum;
                    balance.ProdectionCode = item.ProdectionCode;
                    balance.ProdectionName = item.ProdectionName;
                    balance.TemplateNum = 0;
                    balance.PRSalon = long.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                    balance.PRControl = long.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                    balance.Wastage = long.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                    DataBase.BalanceAlls.InsertOnSubmit(balance);
                    if (item.PartNum > 0)
                    {
                        PRSalon tmp1 = new PRSalon();
                        tmp1.LotNum = item.LotNum;
                        tmp1.ProdectionCode = item.ProdectionCode;
                        tmp1.ProdectionName = item.ProdectionName;
                        tmp1.TemplateNum = 0;
                        tmp1.Location = "GranuleData";
                        tmp1.LocationID = item.ID;
                        tmp1.Increase = int.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                        DataBase.PRSalons.InsertOnSubmit(tmp1);
                    }
                    if (item.ControlNum > 0)
                    {
                        PRControl tmp2 = new PRControl();
                        tmp2.LotNum = item.LotNum;
                        tmp2.ProdectionCode = item.ProdectionCode;
                        tmp2.ProdectionName = item.ProdectionName;
                        tmp2.TemplateNum = 0;
                        tmp2.Location = "GranuleData";
                        tmp2.LocationID = item.ID;
                        tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                        DataBase.PRControls.InsertOnSubmit(tmp2);
                    }
                    if (item.WastageNum > 0)
                    {
                        Wastage tmp3 = new Wastage();
                        tmp3.LotNum = item.LotNum;
                        tmp3.ProdectionCode = item.ProdectionCode;
                        tmp3.ProdectionName = item.ProdectionName;
                        tmp3.TemplateNum = 0;
                        tmp3.Location = "GranuleData";
                        tmp3.LocationID = item.ID;
                        tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                        DataBase.Wastages.InsertOnSubmit(tmp3);
                    }

                }
                else
                {
                    BalanceAll balance = t.First();
                    balance.PRSalon += long.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                    balance.PRControl += long.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                    balance.Wastage += long.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                    if (item.PartNum > 0)
                    {
                        PRSalon tmp1 = new PRSalon();
                        tmp1.LotNum = item.LotNum;
                        tmp1.ProdectionCode = item.ProdectionCode;
                        tmp1.ProdectionName = item.ProdectionName;
                        tmp1.TemplateNum = 0;
                        tmp1.Location = "GranuleData";
                        tmp1.LocationID = item.ID;
                        tmp1.Increase = int.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                        DataBase.PRSalons.InsertOnSubmit(tmp1);
                    }
                    if (item.ControlNum > 0)
                    {
                        PRControl tmp2 = new PRControl();
                        tmp2.LotNum = item.LotNum;
                        tmp2.ProdectionCode = item.ProdectionCode;
                        tmp2.ProdectionName = item.ProdectionName;
                        tmp2.TemplateNum = 0;
                        tmp2.Location = "GranuleData";
                        tmp2.LocationID = item.ID;
                        tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                        DataBase.PRControls.InsertOnSubmit(tmp2);
                    }
                    if (item.WastageNum > 0)
                    {
                        Wastage tmp3 = new Wastage();
                        tmp3.LotNum = item.LotNum;
                        tmp3.ProdectionCode = item.ProdectionCode;
                        tmp3.ProdectionName = item.ProdectionName;
                        tmp3.TemplateNum = 0;
                        tmp3.Location = "GranuleData";
                        tmp3.LocationID = item.ID;
                        tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                        DataBase.Wastages.InsertOnSubmit(tmp3);
                    }
                }
                item.stock = true;
                try { DataBase.SubmitChanges(); }
                catch (Exception) { }

            }


        }
        private void getData2()
        {
            LINQDataContext DataBase = new LINQDataContext();
            var tmp = from s in DataBase.ProductionDatas where s.stock == false orderby s.ProdectionCode, s.LotNum select s;
            foreach (var item in tmp)
            {
                var t = from s in DataBase.BalanceAlls where s.ProdectionCode == item.ProdectionCode && s.LotNum == item.LotNum && s.TemplateNum == item.TemplateNum select s;
                if (t.Count() == 0)
                {
                    BalanceAll balance = new BalanceAll();
                    balance.LotNum = item.LotNum;
                    balance.ProdectionCode = item.ProdectionCode;
                    balance.ProdectionName = item.ProdectionName;
                    balance.TemplateNum = item.TemplateNum;
                    balance.PRSalon = long.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                    balance.PRControl = long.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                    balance.Wastage = long.Parse(Math.Round(Convert.ToDouble(item.WastageNum + item.WastageStart)).ToString());
                    DataBase.BalanceAlls.InsertOnSubmit(balance);
                    if (item.PartNum > 0)
                    {
                        PRSalon tmp1 = new PRSalon();
                        tmp1.LotNum = item.LotNum;
                        tmp1.ProdectionCode = item.ProdectionCode;
                        tmp1.ProdectionName = item.ProdectionName;
                        tmp1.TemplateNum = item.TemplateNum;
                        tmp1.Location = "ProductionData";
                        tmp1.LocationID = item.IDPR;
                        tmp1.Increase = int.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                        DataBase.PRSalons.InsertOnSubmit(tmp1);
                    }
                    if (item.ControlNum > 0)
                    {
                        PRControl tmp2 = new PRControl();
                        tmp2.LotNum = item.LotNum;
                        tmp2.ProdectionCode = item.ProdectionCode;
                        tmp2.ProdectionName = item.ProdectionName;
                        tmp2.TemplateNum = item.TemplateNum;
                        tmp2.Location = "ProductionData";
                        tmp2.LocationID = item.IDPR;
                        tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                        DataBase.PRControls.InsertOnSubmit(tmp2);
                    }
                    if (item.WastageNum + item.WastageStart > 0)
                    {
                        Wastage tmp3 = new Wastage();
                        tmp3.LotNum = item.LotNum;
                        tmp3.ProdectionCode = item.ProdectionCode;
                        tmp3.ProdectionName = item.ProdectionName;
                        tmp3.TemplateNum = item.TemplateNum;
                        tmp3.Location = "ProductionData";
                        tmp3.LocationID = item.IDPR;
                        tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item.WastageNum + item.WastageStart)).ToString());
                        DataBase.Wastages.InsertOnSubmit(tmp3);
                    }

                }
                else
                {
                    BalanceAll balance = t.First();
                    balance.PRSalon += long.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                    balance.PRControl += long.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                    balance.Wastage += long.Parse(Math.Round(Convert.ToDouble(item.WastageNum + item.WastageStart)).ToString());
                    if (item.PartNum > 0)
                    {
                        PRSalon tmp1 = new PRSalon();
                        tmp1.LotNum = item.LotNum;
                        tmp1.ProdectionCode = item.ProdectionCode;
                        tmp1.ProdectionName = item.ProdectionName;
                        tmp1.TemplateNum = item.TemplateNum;
                        tmp1.Location = "ProductionData";
                        tmp1.LocationID = item.IDPR;
                        tmp1.Increase = int.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                        DataBase.PRSalons.InsertOnSubmit(tmp1);
                    }
                    if (item.ControlNum > 0)
                    {
                        PRControl tmp2 = new PRControl();
                        tmp2.LotNum = item.LotNum;
                        tmp2.ProdectionCode = item.ProdectionCode;
                        tmp2.ProdectionName = item.ProdectionName;
                        tmp2.TemplateNum = item.TemplateNum;
                        tmp2.Location = "ProductionData";
                        tmp2.LocationID = item.IDPR;
                        tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                        DataBase.PRControls.InsertOnSubmit(tmp2);
                    }
                    if (item.WastageNum + item.WastageStart > 0)
                    {
                        Wastage tmp3 = new Wastage();
                        tmp3.LotNum = item.LotNum;
                        tmp3.ProdectionCode = item.ProdectionCode;
                        tmp3.ProdectionName = item.ProdectionName;
                        tmp3.TemplateNum = item.TemplateNum;
                        tmp3.Location = "ProductionData";
                        tmp3.LocationID = item.IDPR;
                        tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item.WastageNum + item.WastageStart)).ToString());
                        DataBase.Wastages.InsertOnSubmit(tmp3);
                    }
                }
                item.stock = true;
                try { DataBase.SubmitChanges(); }
                catch (Exception) { }

            }


        }
        private void getData3()
        {
            LINQDataContext DataBase = new LINQDataContext();
            var tmp = from s in DataBase.AssemblyDatas where s.stock == false orderby s.LotNum select s;
            foreach (var item in tmp)
            {
                var t = from s in DataBase.BalanceAlls where s.ProdectionCode == item.ProdectionCode && s.LotNum == item.LotNum select s;
                if (t.Count() == 0)
                {
                    BalanceAll balance = new BalanceAll();
                    balance.LotNum = item.LotNum;
                    balance.ProdectionCode = item.ProdectionCode;
                    balance.ProdectionName = item.ProdectionName;
                    balance.TemplateNum = 0;
                    balance.PRSalon = long.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                    balance.PRControl = long.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                    balance.Wastage = long.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                    DataBase.BalanceAlls.InsertOnSubmit(balance);
                    if (item.PartNum > 0)
                    {
                        PRSalon tmp1 = new PRSalon();
                        tmp1.LotNum = item.LotNum;
                        tmp1.ProdectionCode = item.ProdectionCode;
                        tmp1.ProdectionName = item.ProdectionName;
                        tmp1.TemplateNum = 0;
                        tmp1.Location = "AssemblyData";
                        tmp1.LocationID = item.ID;
                        tmp1.Increase = int.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                        DataBase.PRSalons.InsertOnSubmit(tmp1);
                    }
                    if (item.ControlNum > 0)
                    {
                        PRControl tmp2 = new PRControl();
                        tmp2.LotNum = item.LotNum;
                        tmp2.ProdectionCode = item.ProdectionCode;
                        tmp2.ProdectionName = item.ProdectionName;
                        tmp2.TemplateNum = 0;
                        tmp2.Location = "AssemblyData";
                        tmp2.LocationID = item.ID;
                        tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                        DataBase.PRControls.InsertOnSubmit(tmp2);
                    }
                    if (item.WastageNum > 0)
                    {
                        Wastage tmp3 = new Wastage();
                        tmp3.LotNum = item.LotNum;
                        tmp3.ProdectionCode = item.ProdectionCode;
                        tmp3.ProdectionName = item.ProdectionName;
                        tmp3.TemplateNum = 0;
                        tmp3.Location = "AssemblyData";
                        tmp3.LocationID = item.ID;
                        tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                        DataBase.Wastages.InsertOnSubmit(tmp3);
                    }

                }
                else
                {
                    BalanceAll balance = t.First();
                    balance.PRSalon += long.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                    balance.PRControl += long.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                    balance.Wastage += long.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                    if (item.PartNum > 0)
                    {
                        PRSalon tmp1 = new PRSalon();
                        tmp1.LotNum = item.LotNum;
                        tmp1.ProdectionCode = item.ProdectionCode;
                        tmp1.ProdectionName = item.ProdectionName;
                        tmp1.TemplateNum = 0;
                        tmp1.Location = "AssemblyData";
                        tmp1.LocationID = item.ID;
                        tmp1.Increase = int.Parse(Math.Round(Convert.ToDouble(item.PartNum)).ToString());
                        DataBase.PRSalons.InsertOnSubmit(tmp1);
                    }
                    if (item.ControlNum > 0)
                    {
                        PRControl tmp2 = new PRControl();
                        tmp2.LotNum = item.LotNum;
                        tmp2.ProdectionCode = item.ProdectionCode;
                        tmp2.ProdectionName = item.ProdectionName;
                        tmp2.TemplateNum = 0;
                        tmp2.Location = "AssemblyData";
                        tmp2.LocationID = item.ID;
                        tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item.ControlNum)).ToString());
                        DataBase.PRControls.InsertOnSubmit(tmp2);
                    }
                    if (item.WastageNum > 0)
                    {
                        Wastage tmp3 = new Wastage();
                        tmp3.LotNum = item.LotNum;
                        tmp3.ProdectionCode = item.ProdectionCode;
                        tmp3.ProdectionName = item.ProdectionName;
                        tmp3.TemplateNum = 0;
                        tmp3.Location = "AssemblyData";
                        tmp3.LocationID = item.ID;
                        tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item.WastageNum)).ToString());
                        DataBase.Wastages.InsertOnSubmit(tmp3);
                    }
                }

                var ttt = from s in DataBase.AssemblyCompletions where s.IDAS == item.ID select s;
                foreach (var item2 in ttt)
                {
                    if (item2.LotNum / 10000 != 8)
                    {
                        var tt = from s in DataBase.BalanceAlls where s.ProdectionCode == item2.ProdectionCode && s.LotNum == item2.LotNum select s;
                        if (tt.Count() == 0)
                        {

                        }
                        else
                        {
                            BalanceAll balance = tt.First();
                            balance.PRSalon -= long.Parse(Math.Round(Convert.ToDouble(item2.PartNum + item2.ControlNum + item2.WastageNum)).ToString());
                            balance.Consumed += long.Parse(Math.Round(Convert.ToDouble(item2.PartNum + item2.ControlNum + item2.WastageNum)).ToString());
                            if (item2.PartNum + item2.ControlNum + item2.WastageNum > 0)
                            {
                                PRSalon tmp1 = new PRSalon();
                                Consumed sel = new Consumed();
                                tmp1.LotNum = sel.LotNum = item2.LotNum;
                                tmp1.ProdectionCode = sel.ProdectionCode = item2.ProdectionCode;
                                tmp1.ProdectionName = sel.ProdectionName = item2.ProdectionName;
                                tmp1.TemplateNum = sel.TemplateNum = 1;
                                tmp1.Location = sel.Location = "AssemblyData";
                                tmp1.LocationID = sel.LocationID = item.ID;
                                tmp1.Decrease = sel.Increase = int.Parse(Math.Round(Convert.ToDouble(item2.PartNum + item2.ControlNum + item2.WastageNum)).ToString());
                                DataBase.Consumeds.InsertOnSubmit(sel);
                                DataBase.PRSalons.InsertOnSubmit(tmp1);
                            }
                            if (item2.ControlNum > 0)
                            {
                                PRControl tmp2 = new PRControl();
                                tmp2.LotNum = item2.LotNum;
                                tmp2.ProdectionCode = item2.ProdectionCode;
                                tmp2.ProdectionName = item2.ProdectionName;
                                tmp2.TemplateNum = 1;
                                tmp2.Location = "AssemblyData";
                                tmp2.LocationID = item.ID;
                                tmp2.Increase = int.Parse(Math.Round(Convert.ToDouble(item2.ControlNum)).ToString());
                                DataBase.PRControls.InsertOnSubmit(tmp2);
                            }
                            if (item2.WastageNum > 0)
                            {
                                Wastage tmp3 = new Wastage();
                                tmp3.LotNum = item2.LotNum;
                                tmp3.ProdectionCode = item2.ProdectionCode;
                                tmp3.ProdectionName = item2.ProdectionName;
                                tmp3.TemplateNum = 1;
                                tmp3.Location = "AssemblyData";
                                tmp3.LocationID = item.ID;
                                tmp3.Increase = int.Parse(Math.Round(Convert.ToDouble(item2.WastageNum)).ToString());
                                DataBase.Wastages.InsertOnSubmit(tmp3);
                            }
                        }
                    }
                }

                item.stock = true;
                try { DataBase.SubmitChanges(); }
                catch (Exception) { }



            }
        }


        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var tmp = AllData.Select(string.Format("ProdectionCode like '%{0}%' or ProdectionName like '%{0}%'", txtSearch.Text), "ProdectionName");
                gridAll.DataSource = Utility.ToDataTable<BalanceView>(tmp);
                Radif();
            }
            else
            {
                gridAll.DataSource = AllData;
                Radif();
            }
        }

    }
}
