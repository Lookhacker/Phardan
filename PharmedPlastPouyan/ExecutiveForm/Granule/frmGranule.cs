using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmGranule : Form
    {
        #region Class and Variable
        DataAccess Data = new DataAccess();
        GranuleData PData;
        GranuleDetail PDataDetail;
        GranuleMaterial PDatamaterial;
        GranuleStop stop;
        GranuleDescription Desc;
        QuickSelect Fastcod;
        DataTable BaseDat;
        DataTable tblDatailData;
        DataTable tblDataMaterial;
        DataTable tblDataMaterialview;
        DataTable tblStop;
        DataTable tblStopview;
        private int CurrentId;
        bool closeed = false;

        #endregion
        private int fastCode;
        int Radif = 1;
        bool NoSelect = false;

        #region FormAction
        public frmGranule()
        {
            InitializeComponent();
        }
        private void frmGranule_Load(object sender, EventArgs e)
        {
            fillAllData();
        }
        private void fillAllData()
        {
            PData = new GranuleData();
            PDataDetail = new GranuleDetail();
            PDatamaterial = new GranuleMaterial();
            stop = new GranuleStop();
            Desc = new GranuleDescription();
            LINQDataContext DataBase = new LINQDataContext();
            BaseDat = Utility.ToDataTable<tblBaseData>(DataBase.tblBaseDatas.ToList());

            comPackageType.DataSource = Utility.ToDataTable<tblBaseData>(BaseDat.Select("FK_Parent_uid=27"));
            comRawMaterial.DataSource = Utility.ToDataTable<tblBaseData>(BaseDat.Select("FK_Parent_uid=28"));
            comFormul.DataSource = Utility.ToDataTable<tblBaseData>(BaseDat.Select("FK_Parent_uid=29"));

            PData.Year = 1399;
            tblDatailData = Utility.CreateTable<GranuleDetail>();

            tblDataMaterial = Utility.CreateTable<GranuleMaterial>();
            tblDataMaterialview = CreateMaterialTable();

            tblStop = Utility.CreateTable<GranuleStop>();
            tblStopview = CreateStopTable();

            PData.OperatorOrderCode = DataAccess.User.PCode;
            lblCodePersonel.Text = DataAccess.User.PCode.ToString();
            lblNamePersonel.Text = DataAccess.User.PName;
            txtDay.Clear();
            txtMonth.Clear();
            txtYear.Text = "1399";
            chkShiftStatus.Value = true;
            txtParNum.Clear();
            txtWastage.Clear();
            txtControl.Clear();
            txtKolokhe.Clear();
            comPackageType.SelectedIndex = 0;
            txtICCData.Clear();
            comFormul.SelectedIndex = 0;
            fastCode = 0;
            lblProdectCode.Text = "";
            PData.ProdectionCode = null;
            lblProdectName.Text = "";
            PData.ProdectionName = null;
            txtFastCode.Clear();
            CurrentId = Data.CurrentID("GranuleData", "ID");
            PData.ID = CurrentId;
            lblIDNum.Text = CurrentId.ToString();

            /*
            var Exist = from s in DataBase.GranuleDatas
                        where s.ID == (CurrentId - 1)
                        select s;

            if (Exist.Count() == 1)
            {
                btnLastIDEdit.Enabled = true;
            }
            */


            lblBatchview.Text = CurBatch().ToString();

            PDataDetail.IDGranule = PData.ID;
            PDatamaterial.IDGranule = PData.ID;
            PDataDetail.IDBatch = tblDatailData.Rows.Count + 1;
            PDatamaterial.IDBatch = PDataDetail.IDBatch;

            gridviewMaterial.DataSource = tblDataMaterialview;
            GridALL.DataSource = tblDatailData;
            gridStop.DataSource = tblStopview;
            stop.IDGranule = PData.ID;
            stop.Type = true;
            chkStopStatus.Value = true;
            ClearDetailsForm();
            txtDescription.Clear();
            txtDay.Focus();
        }
        private void IsNumberic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void IsNumbericFastCode(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                comRawMaterial.Focus();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        #endregion
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

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

                int a;
                if (chkShiftStatus.Value)
                    a = 0;
                else
                    a = 1;
                Tools tools = new Tools(txtYear.Text, txtMonth.Text, txtDay.Text, a);
                //tools.Tools2(txtYear.Text, txtMonth.Text, txtDay.Text, comboShift.SelectedIndex);
                PData.Day = Convert.ToInt16(txtDay.Text);
                PData.Month = Convert.ToInt16(txtMonth.Text);
                PData.Year = Convert.ToInt16(txtYear.Text);
                PData.Shift = tools.Shift;

                PData.WeekNum = Convert.ToInt16(tools.WeekNum);
                PData.BatchNum = Convert.ToInt16(tools.BatchNum);
                PData.LotNum = Convert.ToInt32(tools.LotNum);

                lblWeek.Text = PData.WeekNum.ToString();
                lblBatch.Text = PData.BatchNum.ToString();
                lblLot.Text = PData.LotNum.ToString();
                CheckDate = true;
            }
            else
            {
                if (CheckDate)
                {
                    CheckDate = false;
                    PData.Day = PData.Month = PData.Year = PData.Shift = PData.WeekNum = PData.BatchNum = PData.LotNum = 0;
                    lblWeek.Text = lblBatch.Text = lblLot.Text = "";
                }
            }
        }
        #endregion

        #region Data

        #region PData
        private void btnFastView_Click(object sender, EventArgs e)
        {
            frmView frm = new frmView();
            frm.Shart = "G";
            frm.ShowDialog();
            if (frm.Clicked)
            {
                txtFastCode.Text = frm.codefast;
                GetPrdata();
            }
        }
        private void txtFastCode_Leave(object sender, EventArgs e)
        {
            GetPrdata();
        }
        private void GetPrdata()
        {
            if (NoSelect)
            {
                MessageBox.Show("خطا", "شما قبلا اطلاعات وارد کرده اید و نمیتوانید کالا را عوض کنید", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtFastCode.Text = fastCode.ToString();
                return;
            }
            LINQDataContext DataBase = new LINQDataContext();
            if (txtFastCode.Text.Trim().Length > 0)
            {
                if (fastCode.ToString() == txtFastCode.Text.Trim())
                    return;

                var a = from u in DataBase.QuickSelects
                        where u.CodeFast == int.Parse(txtFastCode.Text) && u.kind == "G"
                        select u;
                if (a.Count() == 1)
                {
                    Fastcod = null;
                    Fastcod = a.First();
                    lblProdectCode.Text = Fastcod.Product_Code;
                    lblProdectName.Text = Fastcod.Product_Name;
                    fastCode = Convert.ToInt32(Fastcod.CodeFast);
                    PData.ProdectionCode = Fastcod.Product_Code;
                    PData.ProdectionName = Fastcod.Product_Name;
                    comRawMaterial.Focus();
                    btnDetail.Enabled = true;
                    return;
                }
                else
                {
                    if (a.Count() > 1)
                    {
                        MessageBox.Show("خطا", "برای کد بیشتر از یک کالا تعریف شده است.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        MessageBox.Show("خطا", "این کالا را نمیتوان انتخاب کرد", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    fastCode = 0;
                    lblProdectCode.Text = "";
                    PData.ProdectionCode = null;
                    lblProdectName.Text = "";
                    PData.ProdectionName = null;
                    txtFastCode.Clear();
                }
            }
            btnDetail.Enabled = false;
            fastCode = 0;
            lblProdectCode.Text = "";
            PData.ProdectionCode = null;
            lblProdectName.Text = "";
            PData.ProdectionName = null;
            txtFastCode.Clear();

        }
        private void comPackageType_SelectedIndexChanged(object sender, EventArgs e)
        {
            PData.PackageType = int.Parse(comPackageType.SelectedValue.ToString());
        }
        private void txtICCData_TextChanged(object sender, EventArgs e)
        {
            if (txtICCData.Text.Trim().Length > 0)
                PData.ICCNum = int.Parse(txtICCData.Text);
            else
                PData.ICCNum = 0;
        }
        private void comFormul_SelectedIndexChanged(object sender, EventArgs e)
        {
            PData.Formulation = int.Parse(comFormul.SelectedValue.ToString());
        }
        #endregion

        #region Vazn
        private void txtParNum_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtParNum.TextLength == 0)
                {
                    PData.PartNum = 0;
                    calTotalData();

                    return;
                }
                PData.PartNum = Convert.ToDecimal(txtParNum.Text);
                calTotalData();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtParNum.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtParNum.Focus();
                }
            }
        }
        private void txtWastage_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtWastage.TextLength == 0)
                {
                    PData.WastageNum = 0;
                    calTotalData();

                    return;
                }
                PData.WastageNum = Convert.ToDecimal(txtWastage.Text);
                calTotalData();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtWastage.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtWastage.Focus();
                }
            }
        }
        private void txtControl_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtControl.TextLength == 0)
                {
                    PData.ControlNum = 0;
                    calTotalData();
                    return;
                }
                PData.ControlNum = Convert.ToDecimal(txtControl.Text);
                calTotalData();
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtControl.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtControl.Focus();
                }
            }
        }
        private void txtKolokhe_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtKolokhe.TextLength == 0)
                {
                    PData.Kolokhe = 0;
                    return;
                }
                PData.Kolokhe = Convert.ToDecimal(txtKolokhe.Text);
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtKolokhe.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtKolokhe.Focus();
                }
            }
        }
        #endregion

        #region Bach
        private int CurBatch()
        {
            int tmp = 1;
            DataView view = new DataView(tblDatailData);
            DataTable distinctValues = view.ToTable(true, "IDBatch");
            distinctValues.DefaultView.Sort = "IDBatch asc";
            distinctValues = distinctValues.DefaultView.ToTable();
            for (int i = 0; i < distinctValues.Rows.Count; i++)
                if (int.Parse(distinctValues.Rows[i]["IDBatch"].ToString()) == tmp)
                    tmp++;
                else
                    break;

            return tmp;
        }
        private DataTable CreateMaterialTable()
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("uid");
            temp.Columns.Add("IDGranule");
            temp.Columns.Add("IDBatch");
            temp.Columns.Add("RawMaterial");
            temp.Columns.Add("MaterialName");
            temp.Columns.Add("ICC");
            temp.Columns.Add("PartNum");
            temp.Columns.Add("SeriSakht");
            return temp;
        }








        private void comRawMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comRawMaterial.SelectedIndex >= 0)
            {
                PDatamaterial.RawMaterial = int.Parse(BaseDat.Select("uid=" + comRawMaterial.SelectedValue.ToString()).First()["ID"].ToString());
                var tmp = BaseDat.Select("FK_Parent_uid=" + comRawMaterial.SelectedValue.ToString(), "Tartib");
                if (tmp.Count() > 0)
                {
                    comMaterialName.Enabled = true;
                    comMaterialName.DataSource = Utility.ToDataTable<tblBaseData>(tmp);
                }
                else
                {
                    comMaterialName.SelectedIndex = -1;
                    comMaterialName.Enabled = false;
                }
            }
        }
        private void comMaterialName_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comMaterialName.SelectedIndex < 0)
                PDatamaterial.MaterialName = 0;
            else
                PDatamaterial.MaterialName = int.Parse(comMaterialName.SelectedValue.ToString());
        }
        private void txtICCMaterial_TextChanged(object sender, EventArgs e)
        {
            if (txtICCMaterial.Text.Trim().Length > 0)
                PDatamaterial.ICC = int.Parse(txtICCMaterial.Text);
            else
                PDatamaterial.ICC = 0;
        }
        private void txtPartNumMaterial_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPartNumMaterial.TextLength == 0)
                {
                    PDatamaterial.PartNum = 0;
                    return;
                }
                if (Convert.ToDecimal(txtPartNumMaterial.Text) < 100000)
                    PDatamaterial.PartNum = Convert.ToDecimal(txtPartNumMaterial.Text);
                else
                    txtPartNumMaterial.Text = "99999.999";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtPartNumMaterial.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPartNumMaterial.Focus();
                }
            }
        }

        private void btnMaterial_Click(object sender, EventArgs e)
        {
            if (CheckMaterial())
            {
                AddToTableMaterial();
                ClearMaterialForm();
            }
        }
        private bool CheckMaterial()
        {

            if (PDatamaterial.ICC == 0)
            {
                MessageBox.Show("مواد انتخابی باید وارد شود ICC", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtICCMaterial.Focus();
                return false;
            }
            if (PDatamaterial.PartNum == 0)
            {
                MessageBox.Show("میزان مواد مصرف شده باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPartNumMaterial.Focus();
                return false;
            }
            if (PDatamaterial.SeriSakht == null)
            {
                MessageBox.Show("سری ساخت نباید خالی باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPartNumMaterial.Focus();
                return false;
            }
            for (int i = 0; i < tblDataMaterial.Rows.Count; i++)
                if (PDatamaterial.IDBatch == int.Parse(tblDataMaterial.Rows[i]["IDBatch"].ToString()))
                    if (PDatamaterial.RawMaterial == int.Parse(tblDataMaterial.Rows[i]["RawMaterial"].ToString()))
                        if (PDatamaterial.MaterialName == int.Parse(tblDataMaterial.Rows[i]["MaterialName"].ToString()))
                            if (PDatamaterial.ICC == int.Parse(tblDataMaterial.Rows[i]["ICC"].ToString()))
                                if (PDatamaterial.SeriSakht == tblDataMaterial.Rows[i]["SeriSakht"].ToString())
                                {
                                    MessageBox.Show("نمیتوان مورد تکراری ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                                    txtPartNumMaterial.Focus();
                                    return false;
                                }
            return true;
        }
        private void AddToTableMaterial()
        {
            DataRow DR = tblDataMaterial.NewRow();
            DataRow dr = tblDataMaterialview.NewRow();

            dr["uid"] = DR["uid"] = Radif;
            Radif++;
            dr["IDGranule"] = DR["IDGranule"] = PDatamaterial.IDGranule;
            dr["IDBatch"] = DR["IDBatch"] = PDatamaterial.IDBatch;
            dr["RawMaterial"] = comRawMaterial.Text;
            DR["RawMaterial"] = PDatamaterial.RawMaterial;
            dr["MaterialName"] = comMaterialName.Text;
            DR["MaterialName"] = PDatamaterial.MaterialName;
            dr["ICC"] = DR["ICC"] = PDatamaterial.ICC;
            dr["PartNum"] = DR["PartNum"] = PDatamaterial.PartNum;
            dr["SeriSakht"] = DR["SeriSakht"] = PDatamaterial.SeriSakht;

            tblDataMaterial.Rows.Add(DR);
            tblDataMaterialview.Rows.Add(dr);
        }
        private void ClearMaterialForm()
        {
            PDatamaterial = new GranuleMaterial();
            PDatamaterial.IDGranule = PData.ID;
            PDatamaterial.IDBatch = PDataDetail.IDBatch;
            int tmp = comRawMaterial.SelectedIndex;
            comRawMaterial.SelectedIndex = -1;
            comRawMaterial.SelectedIndex = tmp;
            if (comMaterialName.Enabled)
                PDatamaterial.MaterialName = int.Parse(comMaterialName.SelectedValue.ToString());
            txtICCMaterial.Clear();
            txtPartNumMaterial.Clear();
            txtSerisakht.Clear();

            comRawMaterial.Focus();
        }

        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (CheckDetails())
            {
                AddToTableDetails();
                ClearDetailsForm();
            }
        }

        private bool CheckDetails()
        {
            TimeSpan tmp = new TimeSpan();

            if (PDataDetail.HeatingMixerNumber == 0)
            {
                MessageBox.Show("شماره دستگاه هیتینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerNumber.Focus();
                return false;
            }
            if (PDataDetail.CoolingMixerNumber == 0)
            {
                MessageBox.Show("شماره دستگاه کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerNumber.Focus();
                return false;
            }

            if (PDataDetail.ExtruderNumber == 0)
            {
                MessageBox.Show("شماره دستگاه اسکترودر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtExtruderNumber.Focus();
                return false;
            }
            if (PDataDetail.HeatingMixerTime == tmp)
            {
                MessageBox.Show("زمان هیتینگ میکسر دیسشارژ نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerTime.Focus();
                return false;
            }
            if (PDataDetail.HeatingMixerTemp == 0)
            {
                MessageBox.Show("دمای هیتینگ میکسر دیسشارژ نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerTemp.Focus();
                return false;
            }
            if (PDataDetail.HeatingMixerAmps == 0)
            {
                MessageBox.Show("آمپر هیتینگ میکسر دیسشارژ نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerAmps.Focus();
                return false;
            }
            if (PDataDetail.PlasticizerTimeFrom == tmp)
            {
                MessageBox.Show("زمان شروع پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTimeFrom.Focus();
                return false;
            }
            if (PDataDetail.PlasticizerTimeTo == tmp)
            {
                MessageBox.Show("زمان پایان پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTimeTo.Focus();
                return false;
            }
            if (PDataDetail.PlasticizerTimeFrom > PDataDetail.PlasticizerTimeTo)
            {
                MessageBox.Show("زمان شروع پلاستیسایزر نمیتواند از پایان آن بیشتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTimeTo.Focus();
                return false;
            }
            if (PDataDetail.PlasticizerTempFrom == 0)
            {
                MessageBox.Show("دمای شروع پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTempFrom.Focus();
                return false;
            }
            if (PDataDetail.PlasticizerTempTo == 0)
            {
                MessageBox.Show("دمای پایان پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTempTo.Focus();
                return false;
            }
            if (PDataDetail.CoolingMixerTime == tmp)
            {
                MessageBox.Show("زمان کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerTime.Focus();
                return false;
            }
            if (PDataDetail.CoolingMixerTemp == 0)
            {
                MessageBox.Show("دمای کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerTemp.Focus();
                return false;
            }
            if (PDataDetail.CoolingMixerMaxTemp == 0)
            {
                MessageBox.Show("حداکثر دمای کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerMaxTemp.Focus();
                return false;
            }
            if (PDataDetail.StartTime == tmp)
            {
                MessageBox.Show("زمان شروع نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStartTime.Focus();
                return false;
            }
            if (PDataDetail.FinishTime == tmp)
            {
                MessageBox.Show("زمان پایان نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtFinishTime.Focus();
                return false;
            }
            if (PDataDetail.StartTime > PDataDetail.FinishTime)
            {
                if (!(PDataDetail.StartTime - PDataDetail.FinishTime > TimeSpan.Parse("13:0:0")))
                {
                    MessageBox.Show("زمان شروع نمیتواند بزرگتر از زمان پایان باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtStartTime.Focus();
                    return false;
                }
            }
            if (PDataDetail.FinishTime - PDataDetail.StartTime > TimeSpan.Parse("13:0:0"))
            {
                MessageBox.Show("زمان شروع و پایان نمیتواند بیشتر از یک شیفت طول بکشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStartTime.Focus();
                return false;
            }

            DataRow[] raw = tblDataMaterial.Select("IDBatch=" + PDataDetail.IDBatch);
            bool poodr = false; bool roghan = false;
            foreach (var item in raw)
            {
                if (item["RawMaterial"].ToString() == "1")
                    poodr = true;
                if (item["RawMaterial"].ToString() == "2")
                    roghan = true;

            }
            if (!(poodr && roghan))
            {
                MessageBox.Show("برای هر بچ استفاده از پودر و روغن الزامی می باشد.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtFinishTime.Focus();
                return false;
            }




            if (tblDatailData.Rows.Count > 0)
            {
                DataRow tmmm = tblDatailData.Select("IDBatch=" + (PDataDetail.IDBatch - 1).ToString()).First();
                tmp = TimeSpan.Parse(tmmm["FinishTime"].ToString());
                if (tmp > PDataDetail.StartTime)
                {
                    if (!(tmp - PDataDetail.StartTime > TimeSpan.Parse("12:0:0")))
                    {
                        MessageBox.Show("زمان شروع بچ نمیتوان از زمان پایان بچ قبلی کوچکتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtStartTime.Focus();
                        return false;
                    }
                }

                TimeSpan start = TimeSpan.Parse(tblDatailData.Select("IDBatch=" + (1).ToString()).First()["StartTime"].ToString());
                TimeSpan finish = TimeSpan.Parse(PDataDetail.FinishTime.ToString());

                if (finish - start > TimeSpan.Parse("13:0:0"))
                {
                    MessageBox.Show("از زمان شروع اولین بچ تا زمان پایان آخرین بچ نمیتواند بیشتر از 13 ساعت باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtStartTime.Focus();
                    return false;
                }
            }


            return true;
        }
        private void AddToTableDetails()
        {
            DataRow DR = tblDatailData.NewRow();

            DR["IDGranule"] = PData.ID;
            DR["IDBatch"] = CurBatch();
            DR["HeatingMixerNumber"] = PDataDetail.HeatingMixerNumber;
            DR["CoolingMixerNumber"] = PDataDetail.CoolingMixerNumber;
            DR["ExtruderNumber"] = PDataDetail.ExtruderNumber;
            DR["HeatingMixerTime"] = PDataDetail.HeatingMixerTime;
            DR["HeatingMixerTemp"] = PDataDetail.HeatingMixerTemp;
            DR["HeatingMixerAmps"] = PDataDetail.HeatingMixerAmps;
            DR["PlasticizerTimeFrom"] = PDataDetail.PlasticizerTimeFrom;
            DR["PlasticizerTimeTo"] = PDataDetail.PlasticizerTimeTo;
            DR["PlasticizerTempFrom"] = PDataDetail.PlasticizerTempFrom;
            DR["PlasticizerTempTo"] = PDataDetail.PlasticizerTempTo;
            DR["CoolingMixerTime"] = PDataDetail.CoolingMixerTime;
            DR["CoolingMixerTemp"] = PDataDetail.CoolingMixerTemp;
            DR["CoolingMixerMaxTemp"] = PDataDetail.CoolingMixerMaxTemp;
            DR["StartTime"] = PDataDetail.StartTime;
            DR["FinishTime"] = PDataDetail.FinishTime;

            tblDatailData.Rows.Add(DR);
        }
        private void ClearDetailsForm()
        {
            tblDataMaterialview.Rows.Clear();
            PDataDetail = new GranuleDetail();
            PData.ID = CurrentId;
            PDataDetail.IDBatch = CurBatch();
            comRawMaterial.SelectedIndex = 0;
            comMaterialName.SelectedIndex = 0;
            txtHeatingMixerNumber.Clear();
            txtCoolingMixerNumber.Clear();
            txtExtruderNumber.Clear();
            txtHeatingMixerTime.Clear();
            txtHeatingMixerTemp.Clear();
            txtHeatingMixerAmps.Clear();
            txtPlasticizerTimeFrom.Clear();
            txtPlasticizerTimeTo.Clear();
            txtPlasticizerTempFrom.Clear();
            txtPlasticizerTempTo.Clear();
            txtCoolingMixerTime.Clear();
            txtCoolingMixerTemp.Clear();
            txtCoolingMixerMaxTemp.Clear();
            txtStartTime.Clear();
            txtFinishTime.Clear();
            lblBatchview.Text = PDataDetail.IDBatch.ToString();
            ClearMaterialForm();
        }
        #endregion


        private void txtHeatingMixerNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtHeatingMixerNumber.Text.Trim().Length > 0)
                PDataDetail.HeatingMixerNumber = int.Parse(txtHeatingMixerNumber.Text);
            else
                PDataDetail.HeatingMixerNumber = 0;
        }
        private void txtCoolingMixerNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolingMixerNumber.Text.Trim().Length > 0)
                PDataDetail.CoolingMixerNumber = int.Parse(txtCoolingMixerNumber.Text);
            else
                PDataDetail.CoolingMixerNumber = 0;
        }
        private void txtExtruderNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtExtruderNumber.Text.Trim().Length > 0)
                PDataDetail.ExtruderNumber = int.Parse(txtExtruderNumber.Text);
            else
                PDataDetail.ExtruderNumber = 0;
        }

        private void txtHeatingMixerTime_Leave(object sender, EventArgs e)
        {
            String[] tmp = txtHeatingMixerTime.Text.Split(':');

            if (tmp.Count() == 2)
            {
                if (tmp[0].Trim() != "")
                {
                    if (tmp[1].Trim() != "")
                    {
                        if (int.Parse(tmp[1]) < 60)
                            PDataDetail.HeatingMixerTime = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PDataDetail.HeatingMixerTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDataDetail.HeatingMixerTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDataDetail.HeatingMixerTime = new TimeSpan();
            }

        }
        private void txtCoolingMixerTime_Leave(object sender, EventArgs e)
        {
            String[] tmp = txtCoolingMixerTime.Text.Split(':');

            if (tmp.Count() == 2)
            {
                if (tmp[0].Trim() != "")
                {
                    if (tmp[1].Trim() != "")
                    {
                        if (int.Parse(tmp[1]) < 60)
                            PDataDetail.CoolingMixerTime = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PDataDetail.CoolingMixerTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDataDetail.CoolingMixerTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDataDetail.CoolingMixerTime = new TimeSpan();
            }
        }
        private void txtStartTime_Leave(object sender, EventArgs e)
        {
            String[] tmp = txtStartTime.Text.Split(':');

            if (tmp.Count() == 2)
            {
                if (tmp[0].Trim() != "")
                {
                    if (tmp[1].Trim() != "")
                    {
                        if (int.Parse(tmp[1]) < 60)
                            if (int.Parse(tmp[0]) < 24)
                                PDataDetail.StartTime = new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), 0);
                            else
                            {
                                MessageBox.Show("ساعت نمی تواند بیشتر از 24 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PDataDetail.StartTime = new TimeSpan();
                            }
                        else
                        {
                            MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PDataDetail.StartTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود ساعت ،دقیقه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDataDetail.StartTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDataDetail.StartTime = new TimeSpan();
            }
        }
        private void FinishTime_Leave(object sender, EventArgs e)
        {
            String[] tmp = txtFinishTime.Text.Split(':');

            if (tmp.Count() == 2)
            {
                if (tmp[0].Trim() != "")
                {
                    if (tmp[1].Trim() != "")
                    {
                        if (int.Parse(tmp[1]) < 60)
                            if (int.Parse(tmp[0]) < 24)
                                PDataDetail.FinishTime = new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), 0);
                            else
                            {
                                MessageBox.Show("ساعت نمی تواند بیشتر از 24 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                PDataDetail.FinishTime = new TimeSpan();
                            }
                        else
                        {
                            MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PDataDetail.FinishTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود ساعت ،دقیقه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDataDetail.FinishTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDataDetail.FinishTime = new TimeSpan();
            }
        }
        private void txtPlasticizerTimeTo_Leave(object sender, EventArgs e)
        {
            String[] tmp = txtPlasticizerTimeTo.Text.Split(':');

            if (tmp.Count() == 2)
            {
                if (tmp[0].Trim() != "")
                {
                    if (tmp[1].Trim() != "")
                    {
                        if (int.Parse(tmp[1]) < 60)
                            PDataDetail.PlasticizerTimeTo = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PDataDetail.PlasticizerTimeTo = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDataDetail.PlasticizerTimeTo = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDataDetail.PlasticizerTimeTo = new TimeSpan();
            }
        }
        private void PlasticizerTimeFrom_Leave(object sender, EventArgs e)
        {
            String[] tmp = txtPlasticizerTimeFrom.Text.Split(':');

            if (tmp.Count() == 2)
            {
                if (tmp[0].Trim() != "")
                {
                    if (tmp[1].Trim() != "")
                    {
                        if (int.Parse(tmp[1]) < 60)
                            PDataDetail.PlasticizerTimeFrom = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            PDataDetail.PlasticizerTimeFrom = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        PDataDetail.PlasticizerTimeFrom = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                PDataDetail.PlasticizerTimeFrom = new TimeSpan();
            }
        }
        private void txtPlasticizerTempTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPlasticizerTempTo.TextLength == 0)
                {
                    PDataDetail.PlasticizerTempTo = 0;
                    return;
                }
                if (Convert.ToDecimal(txtPlasticizerTempTo.Text) < 1000)
                    PDataDetail.PlasticizerTempTo = Convert.ToDecimal(txtPlasticizerTempTo.Text);
                else
                    txtPlasticizerTempTo.Text = "999.9";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtPlasticizerTempTo.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPlasticizerTempTo.Focus();
                }
            }
        }
        private void txtPlasticizerTempFrom_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPlasticizerTempFrom.TextLength == 0)
                {
                    PDataDetail.PlasticizerTempFrom = 0;
                    return;
                }
                if (Convert.ToDecimal(txtPlasticizerTempFrom.Text) < 1000)
                    PDataDetail.PlasticizerTempFrom = Convert.ToDecimal(txtPlasticizerTempFrom.Text);
                else
                    txtPlasticizerTempFrom.Text = "999.9";
            }
            catch (Exception ex)
            {
                if (ex.Message == "Input string was not in a correct format.")
                {
                    txtPlasticizerTempFrom.Clear();
                    MessageBox.Show("مقدار را به صورت صحیح وارد کنید", "خطا", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txtPlasticizerTempFrom.Focus();
                }
            }
        }
        private void txtHeatingMixerTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtHeatingMixerTemp.Text.Trim().Length > 0)
                PDataDetail.HeatingMixerTemp = int.Parse(txtHeatingMixerTemp.Text);
            else
                PDataDetail.HeatingMixerTemp = 0;
        }
        private void txtHeatingMixerAmps_TextChanged(object sender, EventArgs e)
        {
            if (txtHeatingMixerAmps.Text.Trim().Length > 0)
                PDataDetail.HeatingMixerAmps = int.Parse(txtHeatingMixerAmps.Text);
            else
                PDataDetail.HeatingMixerAmps = 0;
        }
        private void txtCoolingMixerTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolingMixerTemp.Text.Trim().Length > 0)
                PDataDetail.CoolingMixerTemp = int.Parse(txtCoolingMixerTemp.Text);
            else
                PDataDetail.CoolingMixerTemp = 0;
        }
        private void txtCoolingMixerMaxTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolingMixerMaxTemp.Text.Trim().Length > 0)
                PDataDetail.CoolingMixerMaxTemp = int.Parse(txtCoolingMixerMaxTemp.Text);
            else
                PDataDetail.CoolingMixerMaxTemp = 0;
        }

        #region Stop
        private DataTable CreateStopTable()
        {
            DataTable temp = new DataTable();
            temp.Columns.Add("StopID");
            temp.Columns.Add("StopTitle");
            temp.Columns.Add("StopTime");
            temp.Columns.Add("Type");
            return temp;
        }

        private void txtStopCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == 13)
            {
                txtStopCodeWidth.Focus();
            }
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
        private void txtStopCode_Leave(object sender, EventArgs e)
        {
            StopFill();
        }
        private void StopFill()
        {
            if (txtStopCode.Text.Trim().Length > 0)
            {
                if (txtStopCode.TextLength == 1)
                {
                    txtStopCode.Clear();
                    lblStopCode.Text = "";
                    txtStopCodeWidth.Clear();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                    return;
                }
                LINQDataContext tmp = new LINQDataContext();

                var a = from s in tmp.StopTypes
                        where s.StopID == int.Parse(txtStopCode.Text)
                        select s;
                if (a.Count() == 1)
                {
                    var str = a.First();
                    lblStopCode.Text = str.Title;
                    stop.StopID = str.StopID;
                    txtStopCodeWidth.Focus();
                }
                else
                {
                    txtStopCode.Clear();
                    lblStopCode.Text = "";
                    txtStopCodeWidth.Clear();
                    MessageBox.Show("این نوع توقف وجود ندارد");
                }
            }
        }
        private void txtStopCodeWidth_TextChanged(object sender, EventArgs e)
        {
            if (txtStopCodeWidth.Text.Trim().Length > 0)
                stop.StopTime = int.Parse(txtStopCodeWidth.Text);
            else
                stop.StopTime = 0;

        }
        private void btnAddStop_Click(object sender, EventArgs e)
        {
            if (stop.StopID == 0)
            {

                MessageBox.Show("کد توقف باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStopCode.Focus();
                return;
            }
            if (stop.StopTime == 0)
            {
                MessageBox.Show("مدت توقف نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStopCodeWidth.Focus();
                return;
            }
            int tot = 0;
            for (int i = 0; i < tblStop.Rows.Count; i++)
            {
                if (stop.StopID == int.Parse(tblStop.Rows[i]["StopID"].ToString()))
                {
                    MessageBox.Show("نمیتوان مورد تکراری ثبت کرد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtStopCode.Focus();
                    return;
                }
                tot += int.Parse(tblStop.Rows[i]["StopTime"].ToString());
            }

            if (tot + stop.StopTime > (720 * 3))
            {
                MessageBox.Show("جمع کل توقفات نمیتواند بیشتر از 720 دقیقه باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStopCodeWidth.Focus();
                return;
            }
            AddToTableStop();
            ClearStopForm();

        }
        private void AddToTableStop()
        {
            DataRow DR = tblStop.NewRow();
            DR["uid"] = stop.uid;
            DR["IDGranule"] = stop.IDGranule;
            DR["StopID"] = stop.StopID;
            DR["StopTime"] = stop.StopTime;
            DR["Type"] = stop.Type;
            DR["See"] = stop.See;
            tblStop.Rows.Add(DR);

            DataRow dr = tblStopview.NewRow();
            dr["StopID"] = stop.StopID;
            dr["StopTitle"] = lblStopCode.Text;
            dr["StopTime"] = stop.StopTime;
            if (stop.Type)
                dr["Type"] = "اکسترودر";
            else
                dr["Type"] = "کامپوند سازی";


            tblStopview.Rows.Add(dr);

        }
        private void ClearStopForm()
        {
            stop = new GranuleStop();
            stop.IDGranule = PData.ID;
            txtStopCode.Clear();
            txtStopCodeWidth.Clear();
            lblStopCode.Text = "";
            txtStopCode.Focus();
        }
        private void gridStop_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                stop.StopID = int.Parse(gridStop.Rows[e.RowIndex].Cells["StopID"].Value.ToString());
                txtStopCode.Text = stop.StopID.ToString();
                lblStopCode.Text = gridStop.Rows[e.RowIndex].Cells["StopTitle"].Value.ToString();
                txtStopCodeWidth.Text = gridStop.Rows[e.RowIndex].Cells["StopTime"].Value.ToString();
                stop.IDGranule = PData.ID;

                DataRow dr = tblStop.Select("StopID=" + stop.StopID).First();
                tblStop.Rows.Remove(dr);
                dr = tblStopview.Select("StopID=" + stop.StopID).First();
                tblStopview.Rows.Remove(dr);
            }
        }

        #endregion

        private void txtSerisakht_TextChanged(object sender, EventArgs e)
        {
            if (txtSerisakht.Text.Trim().Length > 0)
            {
                PDatamaterial.SeriSakht = txtSerisakht.Text;
            }
            else
            {
                txtSerisakht.Clear();
                PDatamaterial.SeriSakht = null;
            }
        }
        private void gridStop_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            int Total = 0;
            foreach (var item in gridStop.Rows)
            {
                Total += int.Parse(item.Cells["StopTime"].Value.ToString());
            }
            txtcodewidthTotal.Text = Total.ToString();
        }
        private void btnStopView_Click(object sender, EventArgs e)
        {
            frmStopView frm = new frmStopView();
            frm.ShowDialog();
            if (frm.DoubleClicked)
            {
                txtStopCode.Text = frm.stopID;
                StopFill();
            }
        }
        private void btnSaveExit_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                SaveData();
                closeed = true;
                this.Close();
            }
        }

        private void SaveData()
        {
            if (SaveAll())
            {
                //BalanceShit();
                MessageBox.Show("اطلاعات شما با شماره پیگیری " + PData.ID + " ثبت گردید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private bool SaveAll()
        {
            LINQDataContext DataBase = new LINQDataContext();
            PData.Time = Tools.GetTimeNow();
            PData.stock = false;
            DataBase.GranuleDatas.InsertOnSubmit(PData);

            if (tblStop.Rows.Count > 0)
            {
                for (int i = 0; i < tblStop.Rows.Count; i++)
                {
                    stop = new GranuleStop();
                    stop.IDGranule = PData.ID;
                    stop.StopID = int.Parse(tblStop.Rows[i]["StopID"].ToString());
                    stop.StopTime = int.Parse(tblStop.Rows[i]["StopTime"].ToString());
                    DataBase.GranuleStops.InsertOnSubmit(stop);
                }
            }
            if (Desc.IDGranule != 0)
            {
                DataBase.GranuleDescriptions.InsertOnSubmit(Desc);
            }
            foreach (var item in tblDatailData.Select("", "IDBatch"))
            {
                PDataDetail = new GranuleDetail();
                PDataDetail.IDGranule = PData.ID;
                PDataDetail.IDBatch = int.Parse(item["IDBatch"].ToString());
                PDataDetail.HeatingMixerNumber = int.Parse(item["HeatingMixerNumber"].ToString());
                PDataDetail.CoolingMixerNumber = int.Parse(item["CoolingMixerNumber"].ToString());
                PDataDetail.ExtruderNumber = int.Parse(item["ExtruderNumber"].ToString());
                PDataDetail.HeatingMixerTime = TimeSpan.Parse(item["HeatingMixerTime"].ToString());
                PDataDetail.HeatingMixerTemp = int.Parse(item["HeatingMixerTemp"].ToString());
                PDataDetail.HeatingMixerAmps = int.Parse(item["HeatingMixerAmps"].ToString());
                PDataDetail.PlasticizerTimeFrom = TimeSpan.Parse(item["PlasticizerTimeFrom"].ToString());
                PDataDetail.PlasticizerTimeTo = TimeSpan.Parse(item["PlasticizerTimeTo"].ToString());
                PDataDetail.PlasticizerTempFrom = Decimal.Parse(item["PlasticizerTempFrom"].ToString());
                PDataDetail.PlasticizerTempTo = Decimal.Parse(item["PlasticizerTempTo"].ToString());
                PDataDetail.CoolingMixerTime = TimeSpan.Parse(item["CoolingMixerTime"].ToString());
                PDataDetail.CoolingMixerTemp = int.Parse(item["CoolingMixerTemp"].ToString());
                PDataDetail.CoolingMixerMaxTemp = int.Parse(item["CoolingMixerMaxTemp"].ToString());
                PDataDetail.StartTime = TimeSpan.Parse(item["StartTime"].ToString());
                PDataDetail.FinishTime = TimeSpan.Parse(item["FinishTime"].ToString());

                DataBase.GranuleDetails.InsertOnSubmit(PDataDetail);
            }
            for (int i = 0; i < tblDatailData.Rows.Count; i++)
            {

            }
            foreach (var item in tblDataMaterial.Select("", "IDBatch"))
            {
                PDatamaterial = new GranuleMaterial();
                PDatamaterial.IDGranule = PData.ID;
                PDatamaterial.IDBatch = int.Parse(item["IDBatch"].ToString());
                PDatamaterial.SeriSakht = item["SeriSakht"].ToString();
                PDatamaterial.ICC = int.Parse(item["ICC"].ToString());
                PDatamaterial.MaterialName = int.Parse(item["MaterialName"].ToString());
                PDatamaterial.PartNum = Decimal.Parse(item["PartNum"].ToString());
                PDatamaterial.RawMaterial = int.Parse(item["RawMaterial"].ToString());
                DataBase.GranuleMaterials.InsertOnSubmit(PDatamaterial);

            }
            try
            {
                DataBase.SubmitChanges();
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات به دلیل \n " + ex.Message + "انجام نشد. با پشتیبان نرم افزار تماس بگیرید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return false;
            }

        }
        private void BalanceShit()
        {
            LINQDataContext Database = new LINQDataContext();


            var dt = from u in Database.BalanceAlls
                     where u.LotNum == PData.LotNum && u.ProdectionCode == PData.ProdectionCode && u.TemplateNum == 0
                     select u;
            if (dt.Count() == 1)
            {
                BalanceAll ball = dt.SingleOrDefault();
                ball.PRSalon += Convert.ToInt64(PData.PartNum);
                ball.PRControl += Convert.ToInt64(PData.ControlNum);
                ball.Wastage += Convert.ToInt64(PData.WastageNum);
            }
            else
            {
                BalanceAll ball = new BalanceAll();
                ball.LotNum = PData.LotNum;
                ball.ProdectionCode = PData.ProdectionCode;
                ball.ProdectionName = PData.ProdectionName;
                ball.TemplateNum = 0;
                ball.PRSalon = Convert.ToInt64(PData.PartNum);
                ball.PRControl = Convert.ToInt64(PData.ControlNum);
                ball.Wastage = Convert.ToInt64(PData.WastageNum);
                Database.BalanceAlls.InsertOnSubmit(ball);
            }

            if (PData.PartNum > 0)
            {
                PRSalon sal = new PRSalon();
                sal.LotNum = PData.LotNum;
                sal.ProdectionCode = PData.ProdectionCode;
                sal.ProdectionName = PData.ProdectionName;
                sal.TemplateNum = 0;
                sal.Increase = Convert.ToInt32(PData.PartNum);
                sal.Location = "GranuleData";
                sal.LocationID = PData.ID;
                Database.PRSalons.InsertOnSubmit(sal);
            }

            if (PData.ControlNum > 0)
            {
                PRControl ctrl = new PRControl();
                ctrl.LotNum = PData.LotNum;
                ctrl.ProdectionCode = PData.ProdectionCode;
                ctrl.ProdectionName = PData.ProdectionName;
                ctrl.TemplateNum = 0;
                ctrl.Increase = Convert.ToInt32(PData.ControlNum);
                ctrl.Location = "GranuleData";
                ctrl.LocationID = PData.ID;
                Database.PRControls.InsertOnSubmit(ctrl);
            }
            if (PData.WastageNum > 0)
            {
                Wastage ws = new Wastage();
                ws.LotNum = PData.LotNum;
                ws.ProdectionCode = PData.ProdectionCode;
                ws.ProdectionName = PData.ProdectionName;
                ws.TemplateNum = 0;
                ws.Increase = Convert.ToInt32(PData.WastageNum);
                ws.Location = "GranuleData";
                ws.LocationID = PData.ID;
                Database.Wastages.InsertOnSubmit(ws);
            }
            try
            {
                Database.SubmitChanges();
            }
            catch (Exception ex)
            {
                MessageBox.Show("ثبت اطلاعات به دلیل \n " + ex.Message + "انجام نشد. با پشتیبان نرم افزار تماس بگیرید.", "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                return;
            }
        }
        private bool CheckWorkOrder()
        {
            bool rr = false;
            LINQDataContext db = new LINQDataContext();
            var tmp = from s in db.WorkOrderMonths
                      where s.ProdectionCode == PData.ProdectionCode && s.Year == PData.Year &&
                      s.Month == PData.Month && (s.DayStart <= PData.Day && s.DayFinish >= PData.Day)
                      select s;
            var tmp2 = from s in db.WorkOrderTrails
                       where s.ProdectionCode == PData.ProdectionCode && s.Year == PData.Year &&
                       s.Month == PData.Month && (s.DayStart <= PData.Day && s.DayFinish >= PData.Day)
                       select s;

            switch (tmp.Count())
            {
                case 0:
                    if (tmp2.Count() == 1)
                        rr = true;
                    else
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
        private bool CheckData()
        {

            if (!CheckDate)
            {
                MessageBox.Show("اطلاعات تاریخ به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }
            if (Utility.CreateTime(PData.Year, PData.Month, PData.Day))
            {
                MessageBox.Show("اطلاعات وارد شده خارج از بازه زمانی مجاز برای ثبت اطلاعات است /n لطفا تاریخ وارد شده را بررسی نمایید.", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }
            if (PData.ICCNum == 0)
            {
                MessageBox.Show("اطلاعات ICC بسته بندی به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtICCData.Focus();
                return false;
            }
            if (PData.ProdectionCode == "")
            {
                MessageBox.Show("اطلاعات کالا به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtFastCode.Focus();
                return false;
            }
            if (PData.PartNum + PData.ControlNum + PData.WastageNum + PData.Kolokhe == 0)
            {
                MessageBox.Show("اطلاعات مجموع تولید به صورت صحیح وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtParNum.Focus();
                return false;
            }
            if (!CheckWorkOrder())
            {
                return false;
            }
            if (tblDatailData.Rows.Count < 1)
            {
                MessageBox.Show("اطلاعات مربوط به بچ های تولیدی شما وارد نشده است", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                comMaterialName.Focus();
                return false;
            }
            LINQDataContext database = new LINQDataContext();
            var t = from s in database.GranuleDatas
                    where s.LotNum == PData.LotNum && s.ProdectionCode == PData.ProdectionCode
                    select s;
            if (t.Count() > 0)
            {
                MessageBox.Show("این کالا با این لات نامبر قبلا با شماره ردیابی " + t.First().ID + " وارد شده است .", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtDay.Focus();
                return false;
            }


            return true;
        }
        private void btnSaveNew_Click(object sender, EventArgs e)
        {
            if (CheckData())
            {
                SaveData();
                fillAllData();
            }

        }
        private void btnNew_Click(object sender, EventArgs e)
        {
            if (tblDatailData.Rows.Count > 0)
            {
                if (DialogResult.Yes == MessageBox.Show("برای این شماره ردیابی اطلاعات وارد شده آیا از خالی کردن فرم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    fillAllData();
                }
            }
            else
            {
                fillAllData();
                return;
            }
        }
        private void txtStartTime_Enter(object sender, EventArgs e)
        {
            MaskedTextBox TB = (MaskedTextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.Show("زمان را به ساعت و دقیقه وارد کنید", TB, -30, -40, VisibleTime);

        }
        private void txtFinishTime_Enter(object sender, EventArgs e)
        {
            MaskedTextBox TB = (MaskedTextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.Show("زمان را به ساعت و دقیقه وارد کنید", TB, -30, -40, VisibleTime);
        }
        private void txtPlasticizerTimeFrom_Enter(object sender, EventArgs e)
        {
            MaskedTextBox TB = (MaskedTextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.Show("زمان را به دقیقه و ثانیه وارد کنید", TB, -30, -40, VisibleTime);
        }
        private void gridviewMaterial_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DialogResult.No == MessageBox.Show("مایل به ویرایش اطلاعات هستید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;

                var id = int.Parse(gridviewMaterial.Rows[e.RowIndex].Cells["uid"].Value.ToString());

                DataRow dr = tblDataMaterial.Select("uid=" + id).First();
                ClearMaterialForm();
                PDatamaterial.IDGranule = int.Parse(dr["IDGranule"].ToString());
                PDatamaterial.IDBatch = int.Parse(dr["IDBatch"].ToString());
                PDatamaterial.RawMaterial = int.Parse(dr["RawMaterial"].ToString());
                PDatamaterial.MaterialName = int.Parse(dr["MaterialName"].ToString());
                PDatamaterial.ICC = int.Parse(dr["ICC"].ToString());
                PDatamaterial.PartNum = decimal.Parse(dr["PartNum"].ToString());
                PDatamaterial.SeriSakht = dr["SeriSakht"].ToString();
                comRawMaterial.SelectedValue = PDatamaterial.RawMaterial;
                comMaterialName.SelectedValue = PDatamaterial.MaterialName;
                txtICCMaterial.Text = PDatamaterial.ICC.ToString();
                txtPartNumMaterial.Text = PDatamaterial.PartNum.ToString();
                txtSerisakht.Text = PDatamaterial.SeriSakht;
                tblDataMaterial.Rows.Remove(dr);
                dr = tblDataMaterialview.Select("uid=" + id).First();
                tblDataMaterialview.Rows.Remove(dr);
            }
        }
        private void gridStop_UserDeletingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف این آیتم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = int.Parse(e.Rows[0].Cells["StopID"].Value.ToString());

                DataRow dr = tblStop.Select("StopID=" + id).First();
                tblStop.Rows.Remove(dr);

            }
            else
            {
                e.Cancel = true;
            }
        }
        private void gridviewMaterial_UserDeletingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف این آیتم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                var id = int.Parse(e.Rows[0].Cells["uid"].Value.ToString());

                DataRow dr = tblDataMaterial.Select("uid=" + id).First();
                tblDataMaterial.Rows.Remove(dr);

            }
            else
            {
                e.Cancel = true;
            }
        }
        private void btnLastIDEdit_Click(object sender, EventArgs e)
        {

        }
        private void frmGranule_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (closeed)
            {
                return;
            }
            if (DialogResult.No == MessageBox.Show("اطلاعات", "آیا مایل به خروج از صفحه ورود اطلاعات هستید؟", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
            {
                e.Cancel = true;
            }
        }
        private void txtDescription_TextChanged(object sender, EventArgs e)
        {
            if (txtDescription.Text.Length <= 350)
            {
                lblLength.Text = (350 - txtDescription.Text.Length).ToString();
                if (txtDescription.TextLength > 0)
                {
                    Desc.Description = txtDescription.Text;
                    Desc.IDGranule = PData.ID;
                }
                else
                {
                    Desc.Description = "";
                    Desc.IDGranule = 0;
                }
            }
        }
        private void GridALL_UserDeletingRow(object sender, Telerik.WinControls.UI.GridViewRowCancelEventArgs e)
        {
            if (MessageBox.Show("آیا از حذف این آیتم اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                e.Cancel = true;
                return;
            }
            var id = int.Parse(e.Rows[0].Cells["IDBatch"].Value.ToString());

            DataRow[] dr2 = tblDataMaterial.Select("IDBatch=" + id);
            foreach (var item in dr2)
            {
                tblDataMaterial.Rows.Remove(item);
            }


        }
        private void GridALL_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex < 0)
                return;

            frmGranuleV1 frm = new frmGranuleV1();
            var a2 = tblDatailData.Select("IDBatch=" + e.Row.Cells["IDBatch"].Value.ToString()).First();
            
            frm.gridview = tblDataMaterial.Select("IDBatch=" + e.Row.Cells["IDBatch"].Value.ToString());

            frm.Radifplus = Radif;
            if (frm.data.IDBatch > 1)
                frm.EndLast = TimeSpan.Parse(tblDatailData.Select("IDBatch=" + (frm.data.IDBatch - 1).ToString()).First()["FinishTime"].ToString());
            if ((frm.data.IDBatch + 1) < CurBatch())
                frm.StartNext = TimeSpan.Parse(tblDatailData.Select("IDBatch=" + (frm.data.IDBatch + 1).ToString()).First()["StartTime"].ToString());
            frm.ShowDialog();
            if (frm.Edit)
            {
                foreach (var item in tblDataMaterial.Select("IDBatch=" + e.Row.Cells["IDBatch"].Value.ToString()))
                {
                    tblDataMaterial.Rows.Remove(item);
                }

                foreach (var item in frm.tblDataMaterial.Select())
                {
                    DataRow sa = tblDataMaterial.NewRow();

                    sa["uid"] = item["uid"];

                    sa["IDGranule"] = item["IDGranule"];
                    sa["IDBatch"] = item["IDBatch"];

                    sa["RawMaterial"] = item["RawMaterial"];

                    sa["MaterialName"] = item["MaterialName"];
                    sa["ICC"] = item["ICC"];
                    sa["PartNum"] = item["PartNum"];
                    sa["SeriSakht"] = item["SeriSakht"];

                    tblDataMaterial.Rows.Add(sa);

                }

                Radif = frm.Radifplus;

                var tmp = tblDatailData.Select("IDBatch=" + e.Row.Cells["IDBatch"].Value.ToString()).First();
                tblDatailData.Rows.Remove(tmp);

                DataRow DR = tblDatailData.NewRow();

                DR["IDGranule"] = frm.data.IDGranule;
                DR["IDBatch"] = frm.data.IDBatch;
                DR["HeatingMixerNumber"] = frm.data.HeatingMixerNumber;
                DR["CoolingMixerNumber"] = frm.data.CoolingMixerNumber;
                DR["ExtruderNumber"] = frm.data.ExtruderNumber;
                DR["HeatingMixerTime"] = frm.data.HeatingMixerTime;
                DR["HeatingMixerTemp"] = frm.data.HeatingMixerTemp;
                DR["HeatingMixerAmps"] = frm.data.HeatingMixerAmps;
                DR["PlasticizerTimeFrom"] = frm.data.PlasticizerTimeFrom;
                DR["PlasticizerTimeTo"] = frm.data.PlasticizerTimeTo;
                DR["PlasticizerTempFrom"] = frm.data.PlasticizerTempFrom;
                DR["PlasticizerTempTo"] = frm.data.PlasticizerTempTo;
                DR["CoolingMixerTime"] = frm.data.CoolingMixerTime;
                DR["CoolingMixerTemp"] = frm.data.CoolingMixerTemp;
                DR["CoolingMixerMaxTemp"] = frm.data.CoolingMixerMaxTemp;
                DR["StartTime"] = frm.data.StartTime;
                DR["FinishTime"] = frm.data.FinishTime;

                tblDatailData.Rows.Add(DR);


                tblDatailData = Utility.ToDataTable<GranuleDetail>(tblDatailData.Select("", "IDBatch"));
                GridALL.DataSource = tblDatailData;
            }
        }
        private void GridALL_UserDeletedRow(object sender, Telerik.WinControls.UI.GridViewRowEventArgs e)
        {
            int tmp = CurBatch();
            lblBatchview.Text = tmp.ToString();
            PDataDetail.IDBatch = tmp;
            PDatamaterial.IDBatch = tmp;
        }
        private void GridALL_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            calTotalcon();
            if (GridALL.Rows.Count > 0)
            {
                btnFastView.Enabled = false;
                NoSelect = true;
            }
            else
            {
                NoSelect = false;
                btnFastView.Enabled = true;
            }
        }
        private void calTotalData()
        {
            lblTotalData.Text = (PData.PartNum + PData.ControlNum + PData.WastageNum).ToString("G29");
        }
        private void calTotalcon()
        {
            decimal mmp = 0;
            if (tblDataMaterial == null)
            {
                txtTotalCon.Text = mmp.ToString();
                return;
            }
            foreach (var item in tblDataMaterial.Select())
            {
                mmp += decimal.Parse(item["PartNum"].ToString());
            }

            txtTotalCon.Text = mmp.ToString("G29");
        }

        private void gridviewMaterial_RowsChanged(object sender, Telerik.WinControls.UI.GridViewCollectionChangedEventArgs e)
        {
            calTotalcon();
        }


        private void chkStopStatus_ValueChanged(object sender, EventArgs e)
        {
            stop.Type = chkStopStatus.Value;
        }

        private void chkShiftStatus_ValueChanged(object sender, EventArgs e)
        {
            FillDate();
        }

        #endregion
    }
}
