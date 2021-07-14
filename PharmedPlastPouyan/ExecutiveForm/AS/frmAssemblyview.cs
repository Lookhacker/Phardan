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
    public partial class frmAssemblyview : Form
    {
        LINQDataContext DataBase = new LINQDataContext();
        QuickSelect Fastcod = new QuickSelect();

        public frmAssemblyview()
        {
            InitializeComponent();
        }

        DataTable tblCompletion;
        DataTable tblCompletionView;
        DataTable tblCompletionTemp;
        DataTable Formul = new DataTable();
        DataTable Personalist = new DataTable();
        public int IDAS = 1;
        bool firstRun = true;
        AssemblyData AData;
        AssemblyDescription Desc;
        AssemblyCompletion ADataCompletion;



        #region Form 

        bool closeed = false;
        private DataTable CreateTemp()
        {
            DataTable tmp = new DataTable();
            tmp.Columns.Add("ProdectionCode");
            tmp.Columns.Add("LotNum");
            tmp.Columns.Add("PartNum");
            return tmp;
        }
        private DataTable createAdataCompletionTable()
        {
            DataTable tmp = new DataTable();
            tmp.Columns.Add("ID");
            tmp.Columns.Add("IDAS");
            tmp.Columns.Add("ProdectionCode");
            tmp.Columns.Add("ProdectionName");
            tmp.Columns.Add("LotNum");
            tmp.Columns.Add("Total");
            tmp.Columns.Add("OperatorPR");
            tmp.Columns.Add("OperatorCheck");
            tmp.Columns.Add("PartNum");
            tmp.Columns.Add("WastageNum");
            tmp.Columns.Add("ControlNum");
            return tmp;
        }
        private void frmAssemblyInsert_Load(object sender, EventArgs e)
        {
            tblCompletionTemp = CreateTemp();
            var s2 = from s in DataBase.PersonalLists
                     where s.PersonalCode > 10000
                     select s;
            Personalist = Utility.ToDataTable<PersonalList>(s2.ToList<PersonalList>());
            Formul = Utility.ToDataTable<AssemblyFormula>(DataBase.AssemblyFormulas.ToList<AssemblyFormula>());
            clearParameter();
            firstRun = true;
            if (fildata())
            {

            }
            else
            {
                closeed = true;
                this.Close();
            }
            firstRun = false;
            gridAll.DataSource = tblCompletionView;
            lblIDNum.Text = IDAS.ToString();
            Chart();

        }
        private void Chart()
        {
            try
            {
                LINQDataContext db = new LINQDataContext();
                int ED_Create = int.Parse((from s in db.tblAdmins where s.Parameter == "ED-Create" select s.Value).SingleOrDefault());

                if ((bool)DataAccess.User.Admin)
                {
                    btnDelete.Enabled = btnDelete.Visible = btnSave.Enabled = btnSave.Visible = true;
                    return;
                }
                else
                {
                    if (DataAccess.User.PCode == AData.OperatorOrderCode)
                    {

                        DateTime s = DateTime.Today.AddHours(-ED_Create);
                        bool edittime = s <= AData.Time;
                        if (edittime)
                        {
                            btnDelete.Enabled = btnDelete.Visible = btnSave.Enabled = btnSave.Visible = true;
                            return;
                        }
                        else
                        {
                            btnDelete.Enabled = btnDelete.Visible = btnSave.Enabled = btnSave.Visible = false;
                            closeed = true;
                            return;
                        }
                    }
                    else
                    {
                        closeed = true;
                        return;
                    }
                }
            }
            catch (Exception)
            {
                this.Close();
            }

        }
        private bool fildata()
        {
            AData = (from s in DataBase.AssemblyDatas where s.ID == IDAS select s).SingleOrDefault();
            if (AData != null)
            {
                tblCompletionView = createAdataCompletionTable();
                tblCompletion = Utility.ToDataTable<AssemblyCompletion>((from s in DataBase.AssemblyCompletions where s.IDAS == IDAS select s).ToList());
                foreach (var item in tblCompletion.Select())
                {
                    DataRow DR = tblCompletionView.NewRow();
                    DR["ID"] = item["ID"];
                    DR["IDAS"] = item["IDAS"];
                    DR["ProdectionCode"] = item["ProdectionCode"];
                    DR["ProdectionName"] = item["ProdectionName"];
                    DR["LotNum"] = item["LotNum"];
                    DR["Total"] = int.Parse(item["PartNum"].ToString()) + int.Parse(item["WastageNum"].ToString()) + int.Parse(item["ControlNum"].ToString());
                    DR["OperatorPR"] = Personalist.Select("PersonalCode=" + item["OperatorPR"].ToString()).SingleOrDefault()["PersonalName"];
                    DR["OperatorCheck"] = Personalist.Select("PersonalCode=" + item["OperatorCheck"].ToString()).SingleOrDefault()["PersonalName"];
                    DR["PartNum"] = item["PartNum"];
                    DR["WastageNum"] = item["WastageNum"];
                    DR["ControlNum"] = item["ControlNum"];
                    tblCompletionView.Rows.Add(DR);
                }
                var tt = from s in DataBase.AssemblyDescriptions where s.IDAS == IDAS select s;
                if (tt.Count() == 1)
                {
                    Desc = tt.SingleOrDefault();
                    if (Desc != null)
                    {
                        txtDescription.Text = Desc.Description;
                    }
                }
                lblProdectCode.Text = AData.ProdectionCode;
                lblProdectName.Text = AData.ProdectionName;
                txtDay.Text = AData.Day.ToString();
                txtMonth.Text = AData.Month.ToString();
                txtYear.Text = AData.Year.ToString();
                closeed = true;
                if (AData.Shift == 1)
                    chkShiftStatus.Value = true;
                else
                    chkShiftStatus.Value = false;
                lblWeek.Text = AData.WeekNum.ToString();
                lblBatch.Text = AData.BatchNum.ToString();
                lblLot.Text = AData.LotNum.ToString();

                txtWorkOrderNum.Text = AData.WorkOrder.ToString();

                var sss = (from s in DataBase.WorkOrderMonths where s.ProdectionCode == AData.ProdectionCode && s.Year == AData.Year && s.Month == AData.Month && (s.DayStart <= AData.Day && s.DayFinish >= AData.Day) select s).SingleOrDefault();
                if (sss != null)
                    txtWorkOrderNum.Text = sss.ID.ToString();
                else
                    txtWorkOrderNum.Text = "ندارد";
                lblCodePersonel.Text = AData.OperatorOrderCode.ToString();
                lblNamePersonel.Text = AData.OperatorOrderName;
                txtAssemblyNum.Text = AData.AssemblyNum.ToString();
                txtTimeTolid.Text = AData.TimeTolid.ToString();
                if (AData.Device1 > 0)
                    txtDevice1.Text = AData.Device1.ToString();
                if (AData.Device2 > 0)
                    txtDevice2.Text = AData.Device2.ToString();
                if (AData.Device3 > 0)
                    txtDevice3.Text = AData.Device3.ToString();
                txtOPerator1.Text = AData.Operator1.ToString();
                if (AData.Operator2Code > 0)
                {
                    txtOPerator2.Text = AData.Operator2Code.ToString();
                    txtOPerator2Time.Text = AData.Operator2Time.ToString();
                }
                if (AData.Operator3Code > 0)
                {
                    txtOPerator3.Text = AData.Operator3Code.ToString();
                    txtOPerator3Time.Text = AData.Operator3Time.ToString();
                }
                FillProdection(AData.ProdectionCode);
                txtPartname.Text = AData.PartNum.ToString();
                txtWastageNum.Text = AData.WastageNum.ToString();
                txtControl.Text = AData.ControlNum.ToString();
                return true;
            }
            else
                return true;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmPersonal frm = new frmPersonal();
            frm.ShowDialog();
        }
        private void frmAssemblyInsert_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeed)
            {
                return;
            }
            if (DialogResult.No == MessageBox.Show("اطلاعات", "آیا مایل به خروج از فرم ثبت اطلاعات مونتاژ هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                e.Cancel = true;
            }
        }

        #endregion

        #region KeyPress

        private void KeyPres(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txtCodeFast_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtWorkOrderNum.Focus();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        #endregion

        #region Date
        bool CheckDate;

        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtDay.Text.Length > 0)
            {
                if (int.Parse(txtDay.Text) < 1)
                {
                    txtDay.Text = "1";
                    return;
                }
                if (int.Parse(txtDay.Text) > 31)
                {
                    txtDay.Text = "31";
                    return;
                }
            }
            FillDate();
        }
        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtMonth.Text.Length > 0)
            {
                if (int.Parse(txtMonth.Text) < 1)
                {
                    txtMonth.Text = "1";
                    return;
                }
                if (int.Parse(txtMonth.Text) > 12)
                {
                    txtMonth.Text = "12";
                    return;
                }
            }
            FillDate();
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtYear.Text.Length < 4)
            {
                return;
            }
            FillDate();
        }
        private void chkShiftStatus_ValueChanged(object sender, EventArgs e)
        {
            FillDate();
        }
        private void FillDate()
        {
            if (txtDay.Text.Length > 0 && txtMonth.Text.Length > 0 && txtYear.Text.Length > 0)
            {
                int month = Convert.ToInt16(txtMonth.Text);
                int day = Convert.ToInt16(txtDay.Text);
                if (month > 6)
                {
                    if (day > 30)
                    {
                        txtDay.Text = "30";
                        return;
                    }
                }


                if (Convert.ToInt16(txtYear.Text) < 1398 || Convert.ToInt16(txtYear.Text) > 1599)
                {
                    txtYear.Text = "1399";
                }
                int a = 0;
                if (chkShiftStatus.Value == false)
                    a = 1;

                Tools tools = new Tools(txtYear.Text, txtMonth.Text, txtDay.Text, a);
                AData.Day = Convert.ToInt16(txtDay.Text);
                AData.Month = Convert.ToInt16(txtMonth.Text);
                AData.Year = Convert.ToInt16(txtYear.Text);
                AData.Shift = tools.Shift;

                AData.WeekNum = Convert.ToInt16(tools.WeekNum);
                AData.BatchNum = Convert.ToInt16(tools.BatchNum);
                AData.LotNum = Convert.ToInt32(tools.LotNum);

                lblWeek.Text = AData.WeekNum.ToString();
                lblBatch.Text = AData.BatchNum.ToString();
                lblLot.Text = AData.LotNum.ToString();
                CheckDate = true;
            }
            else
            {
                if (CheckDate)
                {
                    CheckDate = false;
                    AData.Day = AData.Month = AData.Year = AData.Shift = AData.WeekNum = AData.BatchNum = AData.LotNum = 0;
                    lblWeek.Text = lblBatch.Text = lblLot.Text = "";
                }
            }
        }

        #endregion

        #region PRselect


        private void FillProdection(string PrCode)
        {
            try
            {
                PrCode.Trim();
                DataTable tmp1 = new DataTable();
                DataTable tmp2 = new DataTable();
                foreach (var item in Formul.Columns)
                {
                    tmp1.Columns.Add(item.ToString());
                    tmp2.Columns.Add(item.ToString());
                }

                DataRow[] qu = Formul.Select("IDPRCode = " + PrCode.ToString());
                if (qu.Count() > 0)
                {

                    foreach (var item in qu)
                    {
                        tmp1.Rows.Add(item.ItemArray);
                        tmp2.Rows.Add(item.ItemArray);
                    }

                    GridFormula.DataSource = tmp1;
                    GridFormula.CurrentCell.Selected = false;
                    ComboPRName.DataSource = tmp2;
                    ComboPRName.Enabled = true;
                }
            }
            catch (Exception)
            {

            }

        }

        private void txtAssemblyNum_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtAssemblyNum.Text.Length > 0)
                AData.AssemblyNum = int.Parse(txtAssemblyNum.Text);
            else
                AData.AssemblyNum = 0;
        }
        private void txtTimeTolid_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtTimeTolid.Text.Length > 0)
                AData.TimeTolid = int.Parse(txtTimeTolid.Text);
            else
                AData.TimeTolid = 0;
        }

        #endregion

        #region Device

        private void txtDevice1_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtDevice1.Text.Length > 0)
            {
                txtDevice2.Enabled = true;
                AData.Device1 = int.Parse(txtDevice1.Text);
            }
            else
            {
                txtDevice2.Enabled = false;
                AData.Device1 = 0;
            }
        }
        private void txtDevice2_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtDevice2.Text.Length > 0)
            {
                txtDevice3.Enabled = true;
                AData.Device2 = int.Parse(txtDevice2.Text);
            }
            else
            {
                txtDevice3.Enabled = false;
                AData.Device2 = 0;
            }
        }
        private void txtDevice3_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtDevice3.Text.Length > 0)
                AData.Device3 = int.Parse(txtDevice3.Text);
            else
                AData.Device3 = 0;
        }

        #endregion

        #region Operator

        private void txtOPerator1_TextChanged(object sender, EventArgs e)
        {
            if (txtOPerator1.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOPerator1.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    AData.Operator1 = int.Parse(temp.PersonalCode.ToString());
                    txtOPeratorName1.Text = temp.PersonalName;
                    txtOPerator2Time.Enabled = txtOPerator2.Enabled = true;
                    txtOPerator2.Focus();
                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOPeratorName1.Text = "";
                    AData.Operator1 = 0;
                    txtOPerator2Time.Enabled = txtOPerator2.Enabled = false;
                }

            }
            else
            {
                txtOPeratorName1.Text = "";
                txtOPerator2Time.Enabled = txtOPerator2.Enabled = false;
                AData.Operator1 = 0;
            }
        }
        private void txtOPerator2_TextChanged(object sender, EventArgs e)
        {
            if (txtOPerator2.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOPerator2.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    AData.Operator2Code = int.Parse(temp.PersonalCode.ToString());
                    txtOPeratorName2.Text = temp.PersonalName;
                    txtOPerator3Time.Enabled = txtOPerator3.Enabled = true;
                    txtOPerator2Time.Focus();

                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOPeratorName2.Text = "";
                    AData.Operator2Code = 0;
                    txtOPerator3Time.Enabled = txtOPerator3.Enabled = false;
                }

            }
            else
            {
                txtOPeratorName2.Text = "";
                txtOPerator3Time.Enabled = txtOPerator3.Enabled = false;
                AData.Operator2Code = 0;
            }
        }
        private void txtOPerator2Time_TextChanged(object sender, EventArgs e)
        {
            if (txtOPerator2Time.Text.Length > 0)
                if (int.Parse(txtOPerator2Time.Text) <= AData.TimeTolid)
                {
                    AData.Operator2Time = int.Parse(txtOPerator2Time.Text);
                }
                else
                {
                    MessageBox.Show("مدت زمان کار نیروی کمکی نمیتواند از مدت زمان کل مونتاژ بزرگتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AData.Operator2Time = 0;
                }
            else
                AData.Operator2Time = 0;
        }
        private void txtOPerator3_TextChanged(object sender, EventArgs e)
        {
            if (txtOPerator3.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOPerator3.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    AData.Operator3Code = int.Parse(temp.PersonalCode.ToString());
                    txtOPeratorName3.Text = temp.PersonalName;
                    txtOPerator3Time.Focus();
                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOPeratorName3.Text = "";
                    AData.Operator3Code = 0;
                }
            }
            else
            {
                txtOPeratorName3.Text = "";
                AData.Operator3Code = 0;
            }
        }
        private void txtOPerator3Time_TextChanged(object sender, EventArgs e)
        {
            if (txtOPerator3Time.Text.Length > 0)
                if (int.Parse(txtOPerator3Time.Text) <= AData.TimeTolid)
                {
                    AData.Operator3Time = int.Parse(txtOPerator3Time.Text);
                }
                else
                {
                    MessageBox.Show("مدت زمان کار نیروی کمکی نمیتواند از مدت زمان کل مونتاژ بزرگتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    AData.Operator3Time = 0;
                }
            else
                AData.Operator3Time = 0;
        }

        #endregion

        #region Amar and Description

        private void txtPartname_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtPartname.Text.Length > 0)
                AData.PartNum = int.Parse(txtPartname.Text);
            else
                AData.PartNum = 0;
        }
        private void txtWastageNum_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtWastageNum.Text.Length > 0)
                AData.WastageNum = int.Parse(txtWastageNum.Text);
            else
                AData.WastageNum = 0;
        }
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (firstRun) return;
            if (txtControl.Text.Length > 0)
                AData.ControlNum = int.Parse(txtControl.Text);
            else
                AData.ControlNum = 0;
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length > 0)
            {
                Desc.Description = txtDescription.Text;
                Desc.IDAS = AData.ID;
            }
            else
            {
                Desc.Description = txtDescription.Text;
                Desc.IDAS = 0;
            }

            if (txtDescription.Text.Length <= 350)
            {
                lblLength.Text = (350 - txtDescription.Text.Length).ToString();
            }
        }


        #endregion

        #region ADataCompletion

        private void ComboPRName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ComboPRName.SelectedIndex < 0)
            {
                ADataCompletion.ProdectionCode = null;
                ADataCompletion.ProdectionName = null;
            }
            else
            {
                ADataCompletion.ProdectionCode = ComboPRName.SelectedValue.ToString();
                ADataCompletion.ProdectionName = ComboPRName.Text;
            }
        }
        private void txtOperatorPr_TextChanged(object sender, EventArgs e)
        {
            if (txtOperatorPr.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOperatorPr.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    ADataCompletion.OperatorPR = int.Parse(temp.PersonalCode.ToString());
                    txtOPnamePR.Text = temp.PersonalName;
                    txtOperatorCheck.Focus();
                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOPnamePR.Text = "";
                }
            }
            else
            {
                txtOPnamePR.Text = "";
                ADataCompletion.OperatorPR = 0;
            }
        }
        private void txtOperatorCheck_TextChanged(object sender, EventArgs e)
        {
            if (txtOperatorCheck.Text.Length == 5)
            {
                var tmp = from u in DataBase.PersonalLists
                          where u.PersonalCode == int.Parse(txtOperatorCheck.Text)
                          select u;
                if (tmp.Count() == 1)
                {
                    var temp = tmp.First();
                    ADataCompletion.OperatorCheck = int.Parse(temp.PersonalCode.ToString());
                    txtOPnameCheck.Text = temp.PersonalName;
                    txtLotNumer.Focus();
                }
                else
                {
                    MessageBox.Show("خطا", "این کاربر وجود ندارد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtOPnameCheck.Text = "";
                }
            }
            else
            {
                txtOPnameCheck.Text = "";
                ADataCompletion.OperatorCheck = 0;
            }

        }
        private void txtLotNumer_TextChanged(object sender, EventArgs e)
        {
            if (txtLotNumer.Text.Length > 4)
                ADataCompletion.LotNum = int.Parse(txtLotNumer.Text);
            else
                ADataCompletion.LotNum = 0;
        }

        private void txtPartcom_TextChanged(object sender, EventArgs e)
        {
            if (txtPartcom.Text.Length > 0)
                ADataCompletion.PartNum = int.Parse(txtPartcom.Text);
            else
                ADataCompletion.PartNum = 0;
        }
        private void txtControlCom_TextChanged(object sender, EventArgs e)
        {
            if (txtControlCom.Text.Length > 0)
                ADataCompletion.ControlNum = int.Parse(txtControlCom.Text);
            else
                ADataCompletion.ControlNum = 0;
        }
        private void txtWastageCom_TextChanged(object sender, EventArgs e)
        {
            if (txtWastageCom.Text.Length > 0)
                ADataCompletion.WastageNum = int.Parse(txtWastageCom.Text);
            else
                ADataCompletion.WastageNum = 0;
        }
        private void btnAddTable_Click(object sender, EventArgs e)
        {
            if (CheckADataCompletion())
            {
                SendToGrid();
                clearParameter();
            }
        }
        private void clearParameter()
        {
            txtOperatorPr.Text = "";
            txtOperatorCheck.Text = "";
            txtLotNumer.Text = "";
            txtlotPart.Text = "";
            txtPartcom.Text = "";
            txtControlCom.Text = "";
            txtWastageCom.Text = "";
            ADataCompletion = new AssemblyCompletion();
            ComboPRName_SelectedIndexChanged(null, null);
            txtOperatorPr.Focus();

        }
        private bool CheckADataCompletion()
        {
            if (ADataCompletion.ProdectionCode == null && ADataCompletion.ProdectionName == null)
            {
                MessageBox.Show("اطلاعات کالای مصرفی نمیتواند خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }

            if (ADataCompletion.LotNum == 0)
            {
                MessageBox.Show("مشخصاتی با این لات نامبر یافت نشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlotPart.Focus();
                return false;
            }

            if (txtlotPart.TextLength == 0)
            {
                MessageBox.Show("تعداد کل قطعات مصرف شده نمیتواند خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlotPart.Focus();
                return false;
            }

            if (ADataCompletion.OperatorPR == 0)
            {
                MessageBox.Show("اپراتور تولید نمیتواند خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOperatorPr.Focus();
                return false;
            }

            if (ADataCompletion.OperatorCheck == 0)
            {
                MessageBox.Show("اپراتور چک نمیتواند خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOperatorCheck.Focus();
                return false;
            }


            DataRow[] s2 = tblCompletionTemp.Select("ProdectionCode=" + ADataCompletion.ProdectionCode + " and LotNum=" + ADataCompletion.LotNum);
            bool s2tmp = false;
            if ((int)(ADataCompletion.LotNum / 10000) != 8)
            {
                double pres = double.Parse((from s in DataBase.tblAdmins where s.Parameter == "Perc-Assembly" select s.Value).SingleOrDefault());
                pres /= 100;
                var query = from s in DataBase.BalanceAlls
                            where s.ProdectionCode == ADataCompletion.ProdectionCode && s.LotNum == ADataCompletion.LotNum
                            select new
                            {
                                mmp = s.PRSalon
                            };
                int darsad = int.Parse((((from s in DataBase.ProductionDatas
                                          where s.ProdectionCode == ADataCompletion.ProdectionCode && s.LotNum == ADataCompletion.LotNum
                                          select new
                                          {
                                              mmp = s.PartNum
                                          }.mmp).FirstOrDefault()) * pres).ToString());
                if (query.Count() == 1)
                {
                    long s = query.First().mmp;
                    if (s2.Count() == 1)
                    {
                        s += int.Parse(s2.SingleOrDefault()["PartNum"].ToString());
                        s2tmp = true;
                    }
                    if (int.Parse(txtlotPart.Text) > s + darsad)
                    {
                        MessageBox.Show("قطعه تولیدی با این لات نامبر به تعداد وارد شده موجود نمی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtLotNumer.Focus();
                        return false;
                    }
                }
                else
                {
                    MessageBox.Show("قطعه با این لات نامبر تولید نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtLotNumer.Focus();
                    return false;
                }
            }

            int tmp = 0;

            for (int i = 0; i < tblCompletion.Rows.Count; i++)
            {
                if (tblCompletion.Rows[i]["ProdectionCode"].ToString() == ADataCompletion.ProdectionCode)
                    if (tblCompletion.Rows[i]["LotNum"].ToString() == ADataCompletion.LotNum.ToString())
                        if (tblCompletion.Rows[i]["OperatorCheck"].ToString() == ADataCompletion.OperatorCheck.ToString())
                        {
                            MessageBox.Show("این لات نامبر با اپراتور چک قبلا در فرم ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            txtOperatorCheck.Focus();
                            return false;
                        }
                if (tblCompletion.Rows[i]["ProdectionCode"].ToString() == ADataCompletion.ProdectionCode)
                    tmp += int.Parse(tblCompletion.Rows[i]["PartNum"].ToString());
            }

            int tedad = int.Parse(Formul.Select("IDPRCode=" + AData.ProdectionCode + " and ProdectionCode=" + ADataCompletion.ProdectionCode).First()["PartNum"].ToString());
            if ((tmp + ADataCompletion.PartNum) / tedad > AData.AssemblyNum)
            {
                MessageBox.Show("تعداد قطعات وارد شده سالم بیشتر از تعداد کل قطعات مونتاژ شده می باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPartcom.Focus();
                return false;
            }



            if (ADataCompletion.PartNum + ADataCompletion.ControlNum + ADataCompletion.WastageNum != int.Parse(txtlotPart.Text))
            {
                MessageBox.Show("تعداد قطعات سالم ، تحت کنترل و ضایعات با تعداد کل کالاهای مصرفی همخوانی ندارد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPartcom.Focus();
                return false;
            }

            if (s2tmp)
            {
                tblCompletionTemp.Rows.Remove(s2.SingleOrDefault());
            }

            return true;
        }
        private void SendToGrid()
        {
            DataRow DR = tblCompletionView.NewRow();
            DataRow dr = tblCompletion.NewRow();
            dr["ID"] = DR["ID"] = ADataCompletion.ID;
            dr["IDAS"] = DR["IDAS"] = AData.ID;
            dr["ProdectionCode"] = DR["ProdectionCode"] = ADataCompletion.ProdectionCode;
            dr["ProdectionName"] = DR["ProdectionName"] = ADataCompletion.ProdectionName;
            dr["LotNum"] = DR["LotNum"] = ADataCompletion.LotNum;
            DR["Total"] = txtlotPart.Text;
            dr["OperatorPR"] = ADataCompletion.OperatorPR;
            DR["OperatorPR"] = txtOPnamePR.Text;
            dr["OperatorCheck"] = ADataCompletion.OperatorCheck;
            DR["OperatorCheck"] = txtOPnameCheck.Text;
            dr["PartNum"] = DR["PartNum"] = ADataCompletion.PartNum;
            dr["WastageNum"] = DR["WastageNum"] = ADataCompletion.WastageNum;
            dr["ControlNum"] = DR["ControlNum"] = ADataCompletion.ControlNum;
            tblCompletionView.Rows.Add(DR);
            tblCompletion.Rows.Add(dr);
        }



        #endregion



        private AssemblyCompletion FillCompletion(DataRow item)
        {
            AssemblyCompletion tmp = new AssemblyCompletion();
            tmp.IDAS = int.Parse(item["IDAS"].ToString());
            tmp.ProdectionCode = item["ProdectionCode"].ToString();
            tmp.ProdectionName = item["ProdectionName"].ToString();
            tmp.LotNum = int.Parse(item["LotNum"].ToString());
            tmp.OperatorPR = int.Parse(item["OperatorPR"].ToString());
            tmp.OperatorCheck = int.Parse(item["OperatorCheck"].ToString());
            tmp.PartNum = int.Parse(item["PartNum"].ToString());
            tmp.WastageNum = int.Parse(item["WastageNum"].ToString());
            tmp.ControlNum = int.Parse(item["ControlNum"].ToString());
            return tmp;
        }


        private bool validationData()
        {
            if (!CheckDate)
            {
                MessageBox.Show("اطلاعات تاریخ به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }
            if (AData.AssemblyNum == 0)
            {
                MessageBox.Show("تعداد مونتاژ وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlotPart.Focus();
                return false;
            }
            if (AData.TimeTolid < 1 && AData.TimeTolid > 720)
            {
                MessageBox.Show("دقیقه وارد شده صحیح نمی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtTimeTolid.Focus();
                return false;
            }
            if (AData.Operator1 == 0)
            {
                MessageBox.Show("اپراتور اصلی باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtOPerator1.Focus();
                return false;
            }

            if (AData.Operator2Code != 0)
                if (AData.Operator2Time == 0 || AData.Operator2Time > AData.TimeTolid)
                {
                    MessageBox.Show("پس از انتخاب اپراتور کمکی زمان فعالیت اپراتور نمی تواند خالی یا بیشتر از مدت زمان مونتاژ باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOPerator2Time.Focus();
                    return false;
                }

            if (AData.Operator3Code != 0)
                if (AData.Operator3Time == 0 || AData.Operator3Time > AData.TimeTolid)
                {
                    MessageBox.Show("پس از انتخاب اپراتور کمکی زمان فعالیت اپراتور نمی تواند خالی یا بیشتر از مدت زمان مونتاژ باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtOPerator3Time.Focus();
                    return false;
                }

            if (AData.PartNum == 0)
            {
                MessageBox.Show("تعداد قطعات سالم نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPartname.Focus();
                return false;
            }

            if (AData.PartNum + AData.WastageNum + AData.ControlNum != AData.AssemblyNum)
            {
                MessageBox.Show("مجموع کل قطعات تولیدی با تعداد مونتاژ هم خوانی ندارد لطفا دوباره بررسی شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtPartname.Focus();
                return false;
            }

            DataRow[] qu = Formul.Select("IDPRCode = " + AData.ProdectionCode);
            for (int i = 0; i < qu.Count(); i++)
            {
                int tmp = 0;
                for (int j = 0; j < tblCompletion.Rows.Count; j++)
                {
                    if (tblCompletion.Rows[j]["ProdectionCode"].ToString() == qu[i]["ProdectionCode"].ToString())
                    {
                        tmp += int.Parse(tblCompletion.Rows[j]["PartNum"].ToString());
                    }
                }
                int tedad = int.Parse(Formul.Select("IDPRCode=" + AData.ProdectionCode + " and ProdectionCode=" + qu[i]["ProdectionCode"].ToString()).First()["PartNum"].ToString());
                if (tmp / tedad != AData.AssemblyNum)
                {
                    MessageBox.Show("مجموع کالای وارد شده در فرم صحیح نمی باشد\n" + qu[i]["ProdectionName"].ToString(), "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return false;
                }
            }

            var query = from s in DataBase.AssemblyDatas
                        where s.LotNum == AData.LotNum && s.ProdectionCode == AData.ProdectionCode && s.Operator1 == AData.Operator1 && s.uid != AData.uid
                        select new
                        {
                            mmp = s.ID
                        };

            if (query.Count() > 0)
            {
                MessageBox.Show("این فرم قبلا با شماره پیگیری " + query.First().mmp.ToString() + "ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return false;
            }


            return true;
        }


        private void btnAddTable_Leave(object sender, EventArgs e)
        {
            txtOperatorPr.Focus();
        }

        private void gridAll_UserDeletingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف این آیتم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                AssemblyCompletion tmp = FillCompletion(tblCompletion.Rows[e.Rows[0].Index]);
                DataRow raw = tblCompletion.Select("ProdectionCode = " + tmp.ProdectionCode + " and LotNum = " + tmp.LotNum.ToString()).First();
                tblCompletion.Rows.Remove(raw);
                if (tmp.LotNum > 90000)
                {

                    bool find = true;
                    for (int i = 0; i < tblCompletionTemp.Rows.Count; i++)
                    {
                        if (tblCompletionTemp.Rows[i]["ProdectionCode"].ToString() == tmp.ProdectionCode && tblCompletionTemp.Rows[i]["LotNum"].ToString() == tmp.LotNum.ToString())
                        {
                            tblCompletionTemp.Rows[i]["PartNum"] = int.Parse(tblCompletionTemp.Rows[i]["PartNum"].ToString()) + tmp.PartNum;
                            find = false;
                            break;
                        }
                    }
                    if (find)
                    {
                        DataRow DR = tblCompletionTemp.NewRow();
                        DR["ProdectionCode"] = tmp.ProdectionCode;
                        DR["LotNum"] = tmp.LotNum;
                        DR["PartNum"] = tmp.PartNum;
                        tblCompletionTemp.Rows.Add(DR);
                    }
                }
            }
            else
            {
                e.Cancel = true;
            }
        }

        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (MessageBox.Show("آیا از ویرایش این آیتم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
                {
                    return;
                }
                AssemblyCompletion tmp = FillCompletion(tblCompletion.Rows[e.RowIndex]);
                ComboPRName.SelectedValue = tmp.ProdectionCode;
                txtOperatorPr.Text = tmp.OperatorPR.ToString();
                txtOperatorCheck.Text = tmp.OperatorCheck.ToString();
                txtLotNumer.Text = tmp.LotNum.ToString();
                txtlotPart.Text = (tmp.PartNum + tmp.ControlNum + tmp.WastageNum).ToString();
                txtPartcom.Text = tmp.PartNum.ToString();
                txtControlCom.Text = tmp.ControlNum.ToString();
                txtWastageCom.Text = tmp.WastageNum.ToString();

                DataRow raw = tblCompletion.Select("ProdectionCode = " + tmp.ProdectionCode + " and LotNum = " + tmp.LotNum.ToString()).First();
                tblCompletion.Rows.Remove(raw);
                tblCompletionView.Rows.RemoveAt(e.RowIndex);

                if (tmp.LotNum > 90000)
                {
                    bool find = true;
                    for (int i = 0; i < tblCompletionTemp.Rows.Count; i++)
                    {
                        if (tblCompletionTemp.Rows[i]["ProdectionCode"].ToString() == tmp.ProdectionCode && tblCompletionTemp.Rows[i]["LotNum"].ToString() == tmp.LotNum.ToString())
                        {
                            tblCompletionTemp.Rows[i]["PartNum"] = int.Parse(tblCompletionTemp.Rows[i]["PartNum"].ToString()) + tmp.PartNum;
                            find = false;
                            break;
                        }
                    }
                    if (find)
                    {
                        DataRow DR = tblCompletionTemp.NewRow();
                        DR["ProdectionCode"] = tmp.ProdectionCode;
                        DR["LotNum"] = tmp.LotNum;
                        DR["PartNum"] = tmp.PartNum;
                        tblCompletionTemp.Rows.Add(DR);
                    }
                }
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آیا مایل به حذف فرم مونتاژ با شماره ردیابی " + IDAS + " هستید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                LINQDataContext DB = new LINQDataContext();
                var tmp = from s in DB.AssemblyDatas where s.ID == IDAS select s;
                if (tmp.Count() == 1)
                {
                    AssemblyData dt = tmp.SingleOrDefault();
                    DB.AssemblyDatas.DeleteOnSubmit(dt);

                    AssemblyDescription dtd = (from s in DB.AssemblyDescriptions where s.IDAS == IDAS select s).SingleOrDefault();
                    if (dtd != null)
                        DB.AssemblyDatas.DeleteOnSubmit(dt);

                    BalanceAll balance = (from s in DB.BalanceAlls where s.ProdectionCode == dt.ProdectionCode && s.LotNum == dt.LotNum select s).SingleOrDefault();
                    if (balance != null)
                    {
                        if (balance.PRSalon - dt.PartNum > 0)
                        {
                            balance.PRSalon -= dt.PartNum;

                            PRSalon sal = (from s in DB.PRSalons where s.ProdectionCode == dt.ProdectionCode && s.LotNum == dt.LotNum && s.Location == "AssemblyData" && s.LocationID == dt.ID select s).SingleOrDefault();
                            if (sal != null)
                            {
                                DB.PRSalons.DeleteOnSubmit(sal);

                                var dtc = from s in DB.AssemblyCompletions where s.IDAS == IDAS select s;
                                foreach (var item in dtc)
                                {
                                    DB.AssemblyCompletions.DeleteOnSubmit(item);
                                    BalanceAll balan = (from s in DB.BalanceAlls where s.ProdectionCode == item.ProdectionCode && s.LotNum == item.LotNum select s).SingleOrDefault();
                                    if (balan != null)
                                    {
                                        balan.PRSalon += item.PartNum + item.ControlNum + item.WastageNum;

                                        PRSalon tbls = (from s in DB.PRSalons where s.ProdectionCode == item.ProdectionCode && s.LotNum == item.LotNum && s.Location == "AssemblyData" && s.LocationID == IDAS select s).SingleOrDefault();
                                        DB.PRSalons.DeleteOnSubmit(tbls);

                                        try { DB.SubmitChanges(); }
                                        catch (Exception) { }
                                    }
                                }
                            }
                        }
                        else
                        {
                            MessageBox.Show("برای این شماره ردیابی سند ضادر شده و نمیتوان آن را ثبت کرد با مدیر سیستم تماس بگیرید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            return;
                        }
                    }
                }
                else
                {
                    MessageBox.Show("با این شماره ردیابی دو شماره ثبت شده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            bool EditA = false;
            bool EditC = false;
            LINQDataContext db = new LINQDataContext();
            AssemblyData tmp = (from s in db.AssemblyDatas where s.ID == IDAS  select s).SingleOrDefault();
            DataTable tmp2 = Utility.ToDataTable<AssemblyCompletion>((from s in db.AssemblyCompletions where s.IDAS == IDAS select s).ToList());
            for (int i = 0; i < tmp2.Rows.Count; i++)
            {
                var ttmp2 = tblCompletion.Select(string.Format("ProdectionCode={0} and LotNum={1} and OperatorCheck={2}", tmp2.Rows[i]["ProdectionCode"].ToString(), tmp2.Rows[i]["LotNum"].ToString(), tmp2.Rows[i]["OperatorCheck"].ToString())).SingleOrDefault();
                if (ttmp2 != null)
                {
                    if (EditC)
                    {
                        EditC = true;
                        break;
                    }
                }
                else
                    EditC = true;
            }

           
            if (EditC || EditA)
            {
                if (validationData())
                {
                    if (EditC)
                    {
                        SaveDataCompletion();
                    }
                    if (EditA)
                    {
                        SaveData();
                    }
                }
            }
            else
            {
                MessageBox.Show("اطلاعاتی برای ویرایش وارد نشده ", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                closeed = true;
                this.Close();
            }

        }

        private void SaveData()
        {
            LINQDataContext DB = new LINQDataContext();
            AssemblyData tmp = (from s in DB.AssemblyDatas where s.ID == IDAS select s).SingleOrDefault();
            BalanceAll balance = (from s in DB.BalanceAlls where s.ProdectionCode == tmp.ProdectionCode && s.LotNum == tmp.LotNum select s).SingleOrDefault();
            if (balance != null)
            {
                if (AData.LotNum == tmp.LotNum && AData.PartNum == tmp.PartNum && AData.ControlNum == tmp.ControlNum)
                {
                    try { DataBase.SubmitChanges(); return; }
                    catch (Exception) { }
                }
                else
                {
                    if (balance.PRSalon - tmp.PartNum >= 0 && balance.PRControl - tmp.ControlNum >= 0)
                    {
                        balance.PRSalon -= tmp.PartNum;
                        balance.PRControl -= tmp.ControlNum;

                        BalanceAll balance2 = (from s in DB.BalanceAlls where s.ProdectionCode == AData.ProdectionCode && s.LotNum == AData.LotNum select s).SingleOrDefault();
                        if (balance2 != null)
                        {
                            balance2.PRSalon += AData.PartNum;
                            balance2.PRControl += AData.ControlNum;

                            try { DataBase.SubmitChanges(); DB.SubmitChanges(); return; }
                            catch (Exception) { }
                        }
                        else
                        {
                            balance2 = new BalanceAll();
                            balance2.LotNum = AData.LotNum;
                            balance2.ProdectionCode = AData.ProdectionCode;
                            balance2.ProdectionName = AData.ProdectionName;
                            balance2.PRSalon = AData.PartNum;
                            balance2.PRControl = AData.ControlNum;
                            DB.BalanceAlls.InsertOnSubmit(balance2);

                            try { DataBase.SubmitChanges(); DB.SubmitChanges(); return; }
                            catch (Exception) { }
                        }
                    }
                    else
                    {
                        MessageBox.Show("به دلیل صدور سند نمیتوان اطلاعات را ویرایش کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
        }

        private void SaveDataCompletion()
        {
            LINQDataContext DB = new LINQDataContext();
            var temp = from s in DataBase.AssemblyCompletions where s.IDAS == AData.ID select s;
            foreach (var item1 in temp)
            {
                PRSalon tsalon = (from s in DataBase.PRSalons where s.LotNum == item1.LotNum && s.ProdectionCode == item1.ProdectionCode && s.Location == "AssemblyData" && s.LocationID == IDAS select s).SingleOrDefault();
                if (tsalon != null)
                {
                    DB.PRSalons.DeleteOnSubmit(tsalon);
                }
                BalanceAll tbalanc = (from s in DataBase.BalanceAlls where s.LotNum == item1.LotNum && s.ProdectionCode == item1.ProdectionCode && s.TemplateNum == 1 select s).SingleOrDefault();
                if (tbalanc != null)
                {
                    tbalanc.PRSalon += tsalon.Decrease;
                }

                DB.AssemblyCompletions.DeleteOnSubmit(item1);
                try { DB.SubmitChanges(); }
                catch (Exception) { }
            }

            foreach (var item2 in tblCompletion.Select())
            {
                LINQDataContext DB2 = new LINQDataContext();

                AssemblyCompletion newas = FillCompletion(item2);
                if (newas.LotNum < 80000 || newas.LotNum > 90000)
                {
                    PRSalon tsalon = new PRSalon();
                    tsalon.LotNum = newas.LotNum;
                    tsalon.ProdectionCode = newas.ProdectionCode;
                    tsalon.ProdectionName = newas.ProdectionName;
                    tsalon.TemplateNum = 1;
                    tsalon.Decrease = newas.PartNum + newas.ControlNum + newas.WastageNum;
                    tsalon.Location = "AssemblyData";
                    tsalon.LocationID = IDAS;
                    BalanceAll tbalanc = (from s in DataBase.BalanceAlls where s.LotNum == newas.LotNum && s.ProdectionCode == newas.ProdectionCode && s.TemplateNum == 1 select s).SingleOrDefault();
                    tbalanc.PRSalon -= tsalon.Decrease;
                    DB2.PRSalons.InsertOnSubmit(tsalon);
                }
                DB2.AssemblyCompletions.InsertOnSubmit(newas);

                try { DB2.SubmitChanges(); }
                catch (Exception) { }

            }
        }

    }
}