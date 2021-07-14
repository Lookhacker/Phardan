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
    public partial class frmAssemblyInsert : Form
    {
        DataAccess Data = new DataAccess();
        DataTable tblCompletion;
        DataTable tblCompletionView;
        DataTable Formul = new DataTable();
        DataTable Personalist = new DataTable();
        Tools tools;
        AssemblyData AData = new AssemblyData();
        AssemblyDescription Desc = new AssemblyDescription();
        AssemblyCompletion ADataCompletion = new AssemblyCompletion();
        int CurrentId;


        public frmAssemblyInsert()
        {
            InitializeComponent();
        }


        #region Form 

        bool closeed = false;

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
            LINQDataContext DataBase = new LINQDataContext();
            AData.OperatorOrderCode = DataAccess.User.PCode;
            AData.OperatorOrderName = DataAccess.User.PName;
            lblCodePersonel.Text = DataAccess.User.PCode.ToString();
            lblNamePersonel.Text = DataAccess.User.PName;
            tblCompletion = Utility.CreateTable<AssemblyCompletion>();
            tblCompletionView = createAdataCompletionTable();
            gridAll.DataSource = tblCompletionView;
            CurrentId = Data.CurrentID("AssemblyData", "ID");
            AData.ID = CurrentId;
            lblIDNum.Text = CurrentId.ToString();
            var Exist = from s in DataBase.AssemblyDatas
                        where s.ID == (CurrentId - 1)
                        select s;

            if (Exist.Count() == 1)
            {
                //btnLastIDEdit.Enabled = true;
            }

            Formul = Utility.ToDataTable<AssemblyFormula>(DataBase.AssemblyFormulas.ToList<AssemblyFormula>());
            var s2 = from s in DataBase.PersonalLists
                     where s.PersonalCode > 10000
                     select s;
            Personalist = Utility.ToDataTable<PersonalList>(s2.ToList<PersonalList>());

        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            ClearForm();
        }
        private void ClearForm()
        {
            AData = new AssemblyData();
            ADataCompletion = new AssemblyCompletion();
            txtYear.Clear();
            txtYear.Text = "1399";
            txtDay.Clear();
            txtMonth.Clear();
            comboShift.SelectedIndex = -1;
            ClearPr();
            txtWorkOrderNum.Text = "";
            txtAssemblyNum.Text = "";
            txtTimeTolid.Text = "";
            txtDevice1.Text = "";
            txtDevice2.Text = "";
            txtDevice3.Text = "";
            txtOPerator1.Text = "";
            txtOPerator2.Text = "";
            txtOPerator2Time.Text = "";
            txtOPerator3.Text = "";
            txtOPerator3Time.Text = "";
            txtPartname.Text = "";
            txtWastageNum.Text = "";
            txtControl.Text = "";
            txtOperatorCheck.Text = "";
            txtOperatorPr.Text = "";
            txtLotNumer.Text = "";
            txtlotPart.Text = "";
            txtPartcom.Text = "";
            txtControlCom.Text = "";
            txtWastageCom.Text = "";
            txtDescription.Clear();
            Desc.Description = "";
            Desc.IDAS = 0;
            txtDay.Focus();
            AData.OperatorOrderCode = DataAccess.User.PCode;
            AData.OperatorOrderName = DataAccess.User.PName;
            lblCodePersonel.Text = DataAccess.User.PCode.ToString();
            lblNamePersonel.Text = DataAccess.User.PName;
            tblCompletion = Utility.CreateTable<AssemblyCompletion>();
            tblCompletionView = createAdataCompletionTable();
            gridAll.DataSource = tblCompletionView;
            CurrentId = Data.CurrentID("AssemblyData", "ID");
            AData.ID = CurrentId;
            lblIDNum.Text = CurrentId.ToString();
            LINQDataContext DataBase = new LINQDataContext();
            var Exist = from s in DataBase.AssemblyDatas
                        where s.ID == (CurrentId - 1)
                        select s;

            if (Exist.Count() == 1)
            {
                //btnLastIDEdit.Enabled = true;
            }
            fastCode = 0;
            Formul = Utility.ToDataTable(DataBase.AssemblyFormulas.ToList());
            Personalist = Utility.ToDataTable(DataBase.PersonalLists.Where(x => x.PersonalCode > 10000).ToList());
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
            if (txtYear.Text.Length < 4)
            {
                return;
            }
            FillDate();
        }
        private void comboShift_SelectedIndexChanged(object sender, EventArgs e)
        {
            FillDate();
        }
        private void FillDate()
        {
            if (txtDay.Text.Length > 0 && txtMonth.Text.Length > 0 && txtYear.Text.Length > 0 && comboShift.SelectedIndex >= 0)
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

                tools = new Tools(txtYear.Text, txtMonth.Text, txtDay.Text, comboShift.SelectedIndex);
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
        private void lblLot_TextChanged(object sender, EventArgs e)
        {
            //CheckTolid();
        }

        #endregion

        #region PRselect

        int fastCode = 0;
        QuickSelect Fastcod = new QuickSelect();
        // LINQDataContext DataBase = new LINQDataContext();

        private void btnFastcodeview_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.Shart = "A";
            frm.ShowDialog();
            if (frm.Clicked)
            {
                txtCodeFast.Text = frm.codefast;
                GetPrdata();
            }
        }
        private void txtCodeFast_Leave(object sender, EventArgs e)
        {
            GetPrdata();
        }
        private void GetPrdata()
        {
            if (txtCodeFast.Text.Length > 0)
            {
                if (fastCode.ToString() == txtCodeFast.Text.Trim())
                    return;
                LINQDataContext DataBase = new LINQDataContext();
                var a = from u in DataBase.QuickSelects
                        where u.CodeFast == int.Parse(txtCodeFast.Text)
                        select u;
                if (a.Count() == 1)
                {
                    Fastcod = null;
                    Fastcod = a.First();
                    FillProdection(Fastcod.Product_Code);
                    lblProdectCode.Text = Fastcod.Product_Code;
                    lblProdectName.Text = Fastcod.Product_Name;
                    fastCode = Convert.ToInt32(Fastcod.CodeFast);
                    AData.FastCode = Convert.ToInt32(Fastcod.CodeFast);
                    AData.ProdectionCode = Fastcod.Product_Code;
                    AData.ProdectionName = Fastcod.Product_Name;
                }
                else
                {
                    if (a.Count() > 1)
                    {
                        MessageBox.Show("خطا", "برای کد بیشتر از یک کالا تعریف شده است.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("خطا", "این کد فعلا تعریف نشده است", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    fastCode = 0;
                    ClearPr();
                }
            }
        }
        private void ClearPr()
        {
            ComboPRName.DataSource = null;
            ComboPRName.DisplayMember = "ProdectionName";
            ComboPRName.ValueMember = "ProdectionCode";
            ComboPRName.Enabled = false;

            for (int i = GridFormula.Rows.Count; i > 0; i--)
            {
                GridFormula.Rows.RemoveAt(i - 1);
            }
            txtCodeFast.Text = "";
            lblProdectCode.Text = "";
            lblProdectName.Text = "";
            Fastcod = new QuickSelect();
            AData.ProdectionCode = null;
            AData.ProdectionName = null;
            AData.FastCode = 0;
        }
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
                else
                {
                    MessageBox.Show("این کالا مونتاژی نیست", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ClearPr();
                }
            }
            catch (Exception ex)
            {
                string Messege = ex.Message;
                MessageBox.Show("داده های شما به دلیل \n " + Messege + "\n ثبت نشده ");
            }

        }
        private void txtWorkOrderNum_TextChanged(object sender, EventArgs e)
        {
            if (txtWorkOrderNum.Text.Length > 0)
                AData.WorkOrder = int.Parse(txtWorkOrderNum.Text);
            else
                AData.WorkOrder = 0;
        }
        private void txtAssemblyNum_TextChanged(object sender, EventArgs e)
        {
            if (txtAssemblyNum.Text.Length > 0)
                AData.AssemblyNum = int.Parse(txtAssemblyNum.Text);
            else
                AData.AssemblyNum = 0;
        }
        private void txtTimeTolid_TextChanged(object sender, EventArgs e)
        {
            if (txtTimeTolid.Text.Length > 0)
                AData.TimeTolid = int.Parse(txtTimeTolid.Text);
            else
                AData.TimeTolid = 0;
        }

        #endregion

        #region Device

        private void txtDevice1_TextChanged(object sender, EventArgs e)
        {
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
                LINQDataContext DataBase = new LINQDataContext();

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
                LINQDataContext DataBase = new LINQDataContext();
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
                LINQDataContext DataBase = new LINQDataContext();
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
            if (txtPartname.Text.Length > 0)
                AData.PartNum = int.Parse(txtPartname.Text);
            else
                AData.PartNum = 0;
        }
        private void txtWastageNum_TextChanged(object sender, EventArgs e)
        {
            if (txtWastageNum.Text.Length > 0)
                AData.WastageNum = int.Parse(txtWastageNum.Text);
            else
                AData.WastageNum = 0;
        }
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            if (txtControl.Text.Length > 0)
                AData.ControlNum = int.Parse(txtControl.Text);
            else
                AData.ControlNum = 0;
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length <= 350)
            {
                lblLength.Text = (350 - txtDescription.Text.Length).ToString();
            }
        }
        private void txtDescription_Leave(object sender, EventArgs e)
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
                LINQDataContext DataBase = new LINQDataContext();
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
                LINQDataContext DataBase = new LINQDataContext();
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




            if ((int)(ADataCompletion.LotNum / 10000) != 8)
            {
                LINQDataContext DataBase = new LINQDataContext();
                double pres = double.Parse((from s in DataBase.tblAdmins where s.Parameter == "Perc-Assembly" select s.Value).SingleOrDefault());
                pres /= 100;
                var query = from s in DataBase.BalanceAlls
                            where s.ProdectionCode == ADataCompletion.ProdectionCode && s.LotNum == ADataCompletion.LotNum
                            select new
                            {
                                mmp = s.PRSalon
                            };
               
                int darsad = Convert.ToInt32(((from s in DataBase.ProductionDatas
                                               where s.ProdectionCode == ADataCompletion.ProdectionCode && s.LotNum == ADataCompletion.LotNum
                                               select new
                                               {
                                                   mmp = s.PartNum
                                               }.mmp).FirstOrDefault()) * pres);
                //}.mmp).FirstOrDefault()) * 1).ToString());
                if (query.Count() == 1)
                {
                    long s = query.First().mmp;
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

        private void btnSaveExit_Click(object sender, EventArgs e)
        {

            if (validationData())
            {
                SaveData();
                MessageBox.Show("فرم ردیابی مونتاژ با شماره پیگیری " + AData.ID + " ثبت گردید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);

                closeed = true;
                this.Close();
            }
        }

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

        private void SaveData()
        {
            LINQDataContext DataBase = new LINQDataContext();

            foreach (var item in tblCompletion.Select())
            {
                ADataCompletion = FillCompletion(item);
                DataBase.AssemblyCompletions.InsertOnSubmit(ADataCompletion);

                if ((int)(ADataCompletion.LotNum / 10000) != 8)
                {
                    var dta = (from u in DataBase.BalanceAlls
                               where u.LotNum == ADataCompletion.LotNum && u.ProdectionCode == ADataCompletion.ProdectionCode
                               select u).FirstOrDefault();
                    BalanceAll tmp1 = (BalanceAll)dta;
                    tmp1.PRSalon -= (ADataCompletion.PartNum + ADataCompletion.WastageNum);
                    tmp1.Sell += (ADataCompletion.PartNum + ADataCompletion.WastageNum);
                    Sell sel = new Sell();
                    PRSalon sal = new PRSalon();
                    sel.LotNum = sal.LotNum = tmp1.LotNum;
                    sel.ProdectionCode = sal.ProdectionCode = tmp1.ProdectionCode;
                    sel.ProdectionName = sal.ProdectionName = tmp1.ProdectionName;
                    sel.TemplateNum = sal.TemplateNum = 1;
                    sel.Increase = sal.Decrease = (ADataCompletion.PartNum + ADataCompletion.WastageNum);
                    sel.Location = sal.Location = "AssemblyData";
                    sel.LocationID = sal.LocationID = AData.ID;

                    DataBase.PRSalons.InsertOnSubmit(sal);
                }
                try
                {
                    DataBase.SubmitChanges();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("ثبت اطلاعات به دلیل \n" + ex.Message + "\nانجام نشد با پشتیابن تماس بگیرید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

            }


            if (AData.PartNum > 0)
            {
                PRSalon sal = new PRSalon();
                sal.LotNum = AData.LotNum;
                sal.ProdectionCode = AData.ProdectionCode;
                sal.ProdectionName = AData.ProdectionName;
                sal.TemplateNum = 0;
                sal.Increase = AData.PartNum;
                sal.Location = "AssemblyData";
                sal.LocationID = AData.ID;
                DataBase.PRSalons.InsertOnSubmit(sal);
            }

            if (AData.ControlNum > 0)
            {
                PRControl ctrl = new PRControl();
                ctrl.LotNum = AData.LotNum;
                ctrl.ProdectionCode = AData.ProdectionCode;
                ctrl.ProdectionName = AData.ProdectionName;
                ctrl.TemplateNum = 0;
                ctrl.Increase = AData.ControlNum;
                ctrl.Location = "AssemblyData";
                ctrl.LocationID = AData.ID;
                DataBase.PRControls.InsertOnSubmit(ctrl);
            }

            if (AData.ControlNum > 0)
            {
                Wastage was = new Wastage();
                was.LotNum = AData.LotNum;
                was.ProdectionCode = AData.ProdectionCode;
                was.ProdectionName = AData.ProdectionName;
                was.TemplateNum = 0;
                was.Increase = AData.ControlNum;
                was.Location = "AssemblyData";
                was.LocationID = AData.ID;
                DataBase.Wastages.InsertOnSubmit(was);
            }
            try
            {
                DataBase.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات به دلیل \n" + ex.Message + "\nانجام نشد با پشتیابن تماس بگیرید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }


            var dt = from u in DataBase.BalanceAlls
                     where u.LotNum == AData.LotNum && u.ProdectionCode == AData.ProdectionCode && u.TemplateNum == 0
                     select u;
            if (dt.Count() == 1)
            {
                BalanceAll tmp1 = dt.SingleOrDefault();
                tmp1.PRSalon += AData.PartNum;
                tmp1.PRControl += AData.ControlNum;
                tmp1.Wastage += AData.WastageNum;
                DataBase.SubmitChanges();
            }
            else
            {
                BalanceAll tmp1 = new BalanceAll();
                tmp1.LotNum = AData.LotNum;
                tmp1.ProdectionCode = AData.ProdectionCode;
                tmp1.ProdectionName = AData.ProdectionName;
                tmp1.TemplateNum = 0;
                tmp1.PRSalon = AData.PartNum;
                tmp1.PRControl = AData.ControlNum;
                tmp1.Wastage = AData.WastageNum;
                DataBase.BalanceAlls.InsertOnSubmit(tmp1);
                try { DataBase.SubmitChanges(); }
                catch { }
            }

            AData.stock = true;
            AData.Time = Tools.GetTimeNow();
            DataBase.AssemblyDatas.InsertOnSubmit(AData);

            if (Desc.IDAS != 0)
            {
                DataBase.AssemblyDescriptions.InsertOnSubmit(Desc);
            }
            try
            {
                DataBase.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات به دلیل \n" + ex.Message + "\nانجام نشد با پشتیابن تماس بگیرید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

        }

        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (validationData())
            {
                SaveData();
                MessageBox.Show("فرم ردیابی مونتاژ با شماره پیگیری " + AData.ID + " ثبت گردید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);

                ClearForm();
            }

        }
        private bool CheckWorkOrder()
        {
            bool rr = false;
            LINQDataContext db = new LINQDataContext();
            var tmp = from s in db.WorkOrderMonths
                      where s.ProdectionCode == AData.ProdectionCode && s.Year == AData.Year &&
                      s.Month == AData.Month && (s.DayStart <= AData.Day && s.DayFinish >= AData.Day)
                      select s;
            switch (tmp.Count())
            {
                case 0:
                    MessageBox.Show("برای این ماشین و محصول دستور کاری صادر نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                case 1:
                    if (tmp.SingleOrDefault().Confirmation)
                        rr = true;
                    else
                        MessageBox.Show("دستور کار صادر شده تایید نشده است ", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
                default:
                    MessageBox.Show("برای این شماره ماشین و محصول " + tmp.Count() + " دستور کار صادر شده و نمیتوان فرم را ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    break;
            }
            return rr;
        }
        private bool validationData()
        {
            if (!CheckDate)
            {
                MessageBox.Show("اطلاعات تاریخ به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }
            if (Utility.CreateTime(AData.Year, AData.Month, AData.Day))
            {
                MessageBox.Show("اطلاعات وارد شده خارج از بازه زمانی مجاز برای ثبت اطلاعات است /n لطفا تاریخ وارد شده را بررسی نمایید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }
            if (AData.FastCode == 0)
            {
                MessageBox.Show("اطلاعات کالا وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtCodeFast.Focus();
                return false;
            }
            if (AData.WorkOrder == 0)
            {
                MessageBox.Show("شماره دستور کار وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtlotPart.Focus();
                return false;
            }
            if (!CheckWorkOrder())
            {
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
                    if (tblCompletion.Rows[j]["ProdectionCode"] == qu[i]["ProdectionCode"])
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
            LINQDataContext DataBase = new LINQDataContext();

            var query = from s in DataBase.AssemblyDatas
                        where s.LotNum == AData.LotNum && s.ProdectionCode == AData.ProdectionCode && s.Operator1 == AData.Operator1
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
            }
        }
    }
}
