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
    public partial class frmGranuleV1 : Form
    {
        DataTable BaseDat;
        public DataTable tblDataMaterial;
        public DataTable tblDataMaterialview;
        public GranuleDetail data;
        public DataRow[] gridview;
        GranuleMaterial PDatamaterial;

        public TimeSpan EndLast;
        public TimeSpan StartNext;
        public int Radifplus;

        public frmGranuleV1()
        {
            InitializeComponent();
        }

        private void frmGranuleV1_Load(object sender, EventArgs e)
        {
            PDatamaterial = new GranuleMaterial();
            LINQDataContext DataBase = new LINQDataContext();
            BaseDat = Utility.ToDataTable<tblBaseData>(DataBase.tblBaseDatas.ToList());
            comRawMaterial.DataSource = Utility.ToDataTable<tblBaseData>(BaseDat.Select("FK_Parent_uid=28"));
            lblBatchview.Text = data.IDBatch.ToString();
            txtHeatingMixerNumber.Text = data.HeatingMixerNumber.ToString();
            txtCoolingMixerNumber.Text = data.CoolingMixerNumber.ToString();
            txtExtruderNumber.Text = data.ExtruderNumber.ToString();
            if (data.HeatingMixerTime.Minutes<10)
                txtHeatingMixerTime.Text ="0"+ data.HeatingMixerTime.Minutes.ToString() + data.HeatingMixerTime.Seconds.ToString();
            else
                txtHeatingMixerTime.Text = data.HeatingMixerTime.Minutes.ToString() + data.HeatingMixerTime.Seconds.ToString();
            if (txtHeatingMixerTime.MaskCompleted==false)
                txtHeatingMixerTime.Text += "0";
            
            txtHeatingMixerTemp.Text = data.HeatingMixerTemp.ToString();
            txtHeatingMixerAmps.Text = data.HeatingMixerAmps.ToString();
            if (data.PlasticizerTimeFrom.Minutes < 10)
                txtPlasticizerTimeFrom.Text = "0" + data.PlasticizerTimeFrom.Minutes.ToString() + data.PlasticizerTimeFrom.Seconds.ToString();
            else
                txtPlasticizerTimeFrom.Text = data.PlasticizerTimeFrom.Minutes.ToString() + data.PlasticizerTimeFrom.Seconds.ToString();
            if (txtPlasticizerTimeFrom.MaskCompleted==false)
                txtPlasticizerTimeFrom.Text += "0";

            if (data.PlasticizerTimeTo.Minutes < 10)
                txtPlasticizerTimeTo.Text = "0" + data.PlasticizerTimeTo.Minutes + data.PlasticizerTimeTo.Seconds.ToString();
            else
                txtPlasticizerTimeTo.Text = data.PlasticizerTimeTo.Minutes.ToString() + data.PlasticizerTimeTo.Seconds.ToString();
            if (txtPlasticizerTimeTo.MaskCompleted==false)
                txtPlasticizerTimeTo.Text += "0";
            txtPlasticizerTempFrom.Text = data.PlasticizerTempFrom.ToString();
            txtPlasticizerTempTo.Text = data.PlasticizerTempTo.ToString();
            if (data.CoolingMixerTime.Minutes < 10)
                txtCoolingMixerTime.Text = "0" + data.CoolingMixerTime.Minutes.ToString() + data.CoolingMixerTime.Seconds.ToString();
            else
                txtCoolingMixerTime.Text = data.CoolingMixerTime.Minutes.ToString() + data.CoolingMixerTime.Seconds.ToString();
            if (txtCoolingMixerTime.MaskCompleted == false)
                txtCoolingMixerTime.Text += "0";
            txtCoolingMixerTemp.Text = data.CoolingMixerTemp.ToString();
            txtCoolingMixerMaxTemp.Text = data.CoolingMixerMaxTemp.ToString();
            txtStartTime.Text = data.StartTime.ToString();
            txtFinishTime.Text = data.FinishTime.ToString();

            tblDataMaterial = Utility.ToDataTable<GranuleMaterial>(gridview);
            tblDataMaterialview = CreateMaterialTable();
            gridviewMaterial.DataSource = tblDataMaterialview;
            foreach (var item in gridview)
            {
                DataRow dr = tblDataMaterialview.NewRow();

                dr["uid"] = item["uid"];
                dr["IDGranule"] = item["IDGranule"];
                dr["IDBatch"] = item["IDBatch"];
                var ttt = BaseDat.Select("FK_Parent_uid=28 and ID=" + item["RawMaterial"].ToString());
                dr["RawMaterial"] = ttt.First()["Title"].ToString();

                if (item["MaterialName"].ToString() != "0")
                    dr["MaterialName"] = BaseDat.Select("FK_Parent_uid="+ttt.First()["uid"] .ToString()+" and ID=" + item["MaterialName"].ToString()).First()["Title"].ToString();
                dr["ICC"] = item["ICC"];
                dr["PartNum"] = item["PartNum"];
                dr["SeriSakht"] = item["SeriSakht"];

                tblDataMaterialview.Rows.Add(dr);
            }
            PDatamaterial.IDBatch = data.IDBatch;
            PDatamaterial.IDGranule = data.IDGranule;
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
        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void IsNumberic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void comRawMaterial_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comRawMaterial.SelectedIndex<0)
            {
                return;
            }

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
            if (PDatamaterial.uid == 0)
            {
                dr["uid"] = DR["uid"] = Radifplus;
                Radifplus++;
            }
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
            PDatamaterial.IDGranule = data.IDGranule;
            PDatamaterial.IDBatch = data.IDBatch;

            PDatamaterial.RawMaterial = int.Parse(BaseDat.Select("uid=" + comRawMaterial.SelectedValue.ToString()).First()["ID"].ToString());
            //PDatamaterial.RawMaterial = int.Parse(comRawMaterial.SelectedValue.ToString());
            if (comMaterialName.Enabled)
                PDatamaterial.MaterialName = int.Parse(comMaterialName.SelectedValue.ToString());
            txtICCMaterial.Clear();
            txtPartNumMaterial.Clear();
            txtSerisakht.Clear();

            comRawMaterial.Focus();
        }
        public bool Edit = false;
        private void btnDetail_Click(object sender, EventArgs e)
        {
            if (DialogResult.Yes == MessageBox.Show("آیا از ویرایش اطلاعات اطمینان دارید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
            {
                if (CheckDetails())
                {
                    Edit = true;
                    this.Close();
                }
            }
        }
        private bool CheckDetails()
        {
            TimeSpan tmp = new TimeSpan();

            if (data.HeatingMixerNumber == 0)
            {
                MessageBox.Show("شماره دستگاه هیتینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerNumber.Focus();
                return false;
            }
            if (data.CoolingMixerNumber == 0)
            {
                MessageBox.Show("شماره دستگاه کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerNumber.Focus();
                return false;
            }

            if (data.ExtruderNumber == 0)
            {
                MessageBox.Show("شماره دستگاه اسکترودر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtExtruderNumber.Focus();
                return false;
            }
            if (data.HeatingMixerTime == tmp)
            {
                MessageBox.Show("زمان هیتینگ میکسر دیسشارژ نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerTime.Focus();
                return false;
            }
            if (data.HeatingMixerTemp == 0)
            {
                MessageBox.Show("دمای هیتینگ میکسر دیسشارژ نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerTemp.Focus();
                return false;
            }
            if (data.HeatingMixerAmps == 0)
            {
                MessageBox.Show("آمپر هیتینگ میکسر دیسشارژ نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtHeatingMixerAmps.Focus();
                return false;
            }
            if (data.PlasticizerTimeFrom == tmp)
            {
                MessageBox.Show("زمان شروع پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTimeFrom.Focus();
                return false;
            }
            if (data.PlasticizerTimeTo == tmp)
            {
                MessageBox.Show("زمان پایان پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTimeTo.Focus();
                return false;
            }
            if (data.PlasticizerTimeFrom > data.PlasticizerTimeTo)
            {
                MessageBox.Show("زمان شروع پلاستیسایزر نمیتواند از پایان آن بیشتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTimeTo.Focus();
                return false;
            }
            if (data.PlasticizerTempFrom == 0)
            {
                MessageBox.Show("دمای شروع پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTempFrom.Focus();
                return false;
            }
            if (data.PlasticizerTempTo == 0)
            {
                MessageBox.Show("دمای پایان پلاستیسایزر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtPlasticizerTempTo.Focus();
                return false;
            }
            if (data.CoolingMixerTime == tmp)
            {
                MessageBox.Show("زمان کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerTime.Focus();
                return false;
            }
            if (data.CoolingMixerTemp == 0)
            {
                MessageBox.Show("دمای کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerTemp.Focus();
                return false;
            }
            if (data.CoolingMixerMaxTemp == 0)
            {
                MessageBox.Show("حداکثر دمای کولینگ میکسر نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtCoolingMixerMaxTemp.Focus();
                return false;
            }
            if (data.StartTime == tmp)
            {
                MessageBox.Show("زمان شروع نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStartTime.Focus();
                return false;
            }
            if (data.FinishTime == tmp)
            {
                MessageBox.Show("زمان پایان نمیتواند 0 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtFinishTime.Focus();
                return false;
            }
            if (data.StartTime > data.FinishTime)
            {
                if (!(data.StartTime - data.FinishTime > TimeSpan.Parse("13:0:0")))
                {
                    MessageBox.Show("زمان شروع نمیتواند بزرگتر از زمان پایان باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtStartTime.Focus();
                    return false;
                }
            }
            if (data.FinishTime - data.StartTime > TimeSpan.Parse("13:0:0"))
            {
                MessageBox.Show("زمان شروع و پایان نمیتواند بیشتر از یک شیفت طول بکشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                txtStartTime.Focus();
                return false;
            }


            if (data.StartTime < EndLast)
            {
                if (EndLast - data.StartTime < TimeSpan.Parse("13:0:0"))
                {
                    MessageBox.Show("زمان شروع این بچ نمیتواند از زمان پایان بچ قبلی کمتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                    txtStartTime.Focus();
                    return false;
                }
            }
            if (StartNext != TimeSpan.Parse("0:0:0"))
            {
                if (data.FinishTime > StartNext)
                {
                    if (data.FinishTime - StartNext < TimeSpan.Parse("13:0:0"))
                    {

                        MessageBox.Show("زمان پایان این بچ نمیتواند از زمان شروع بچ بعدی بیشتر باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                        txtStartTime.Focus();
                        return false;
                    }
                }
            }



            DataRow[] raw = tblDataMaterial.Select("IDBatch=" + data.IDBatch);
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

            return true;
        }



        private void txtHeatingMixerNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtHeatingMixerNumber.Text.Trim().Length > 0)
                data.HeatingMixerNumber = int.Parse(txtHeatingMixerNumber.Text);
            else
                data.HeatingMixerNumber = 0;
        }
        private void txtCoolingMixerNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolingMixerNumber.Text.Trim().Length > 0)
                data.CoolingMixerNumber = int.Parse(txtCoolingMixerNumber.Text);
            else
                data.CoolingMixerNumber = 0;
        }
        private void txtExtruderNumber_TextChanged(object sender, EventArgs e)
        {
            if (txtExtruderNumber.Text.Trim().Length > 0)
                data.ExtruderNumber = int.Parse(txtExtruderNumber.Text);
            else
                data.ExtruderNumber = 0;
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
                            data.HeatingMixerTime = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data.HeatingMixerTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        data.HeatingMixerTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.HeatingMixerTime = new TimeSpan();
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
                            data.CoolingMixerTime = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data.CoolingMixerTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        data.CoolingMixerTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.CoolingMixerTime = new TimeSpan();
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
                                data.StartTime = new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), 0);
                            else
                            {
                                MessageBox.Show("ساعت نمی تواند بیشتر از 24 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                data.StartTime = new TimeSpan();
                            }
                        else
                        {
                            MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data.StartTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود ساعت ،دقیقه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        data.StartTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.StartTime = new TimeSpan();
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
                                data.FinishTime = new TimeSpan(int.Parse(tmp[0]), int.Parse(tmp[1]), 0);
                            else
                            {
                                MessageBox.Show("ساعت نمی تواند بیشتر از 24 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                data.FinishTime = new TimeSpan();
                            }
                        else
                        {
                            MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data.FinishTime = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود ساعت ،دقیقه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        data.FinishTime = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("دقیقه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.FinishTime = new TimeSpan();
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
                            data.PlasticizerTimeTo = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data.PlasticizerTimeTo = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        data.PlasticizerTimeTo = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.PlasticizerTimeTo = new TimeSpan();
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
                            data.PlasticizerTimeFrom = new TimeSpan(0, int.Parse(tmp[0]), int.Parse(tmp[1]));
                        else
                        {
                            MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            data.PlasticizerTimeFrom = new TimeSpan();
                        }
                    }
                    else
                    {
                        MessageBox.Show("بعد از ورود دقیقه ثانیه باید وارد شود", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        data.PlasticizerTimeFrom = new TimeSpan();
                    }
                }

            }
            else
            {
                MessageBox.Show("ثانیه وارد شده نمیتواند بیشتر از 59 باشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                data.PlasticizerTimeFrom = new TimeSpan();
            }
        }
        private void txtPlasticizerTempTo_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (txtPlasticizerTempTo.TextLength == 0)
                {
                    data.PlasticizerTempTo = 0;
                    return;
                }
                if (Convert.ToDecimal(txtPlasticizerTempTo.Text) < 1000)
                    data.PlasticizerTempTo = Convert.ToDecimal(txtPlasticizerTempTo.Text);
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
                    data.PlasticizerTempFrom = 0;
                    return;
                }
                if (Convert.ToDecimal(txtPlasticizerTempFrom.Text) < 1000)
                    data.PlasticizerTempFrom = Convert.ToDecimal(txtPlasticizerTempFrom.Text);
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
                data.HeatingMixerTemp = int.Parse(txtHeatingMixerTemp.Text);
            else
                data.HeatingMixerTemp = 0;
        }
        private void txtHeatingMixerAmps_TextChanged(object sender, EventArgs e)
        {
            if (txtHeatingMixerAmps.Text.Trim().Length > 0)
                data.HeatingMixerAmps = int.Parse(txtHeatingMixerAmps.Text);
            else
                data.HeatingMixerAmps = 0;
        }
        private void txtCoolingMixerTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolingMixerTemp.Text.Trim().Length > 0)
                data.CoolingMixerTemp = int.Parse(txtCoolingMixerTemp.Text);
            else
                data.CoolingMixerTemp = 0;
        }
        private void txtCoolingMixerMaxTemp_TextChanged(object sender, EventArgs e)
        {
            if (txtCoolingMixerMaxTemp.Text.Trim().Length > 0)
                data.CoolingMixerMaxTemp = int.Parse(txtCoolingMixerMaxTemp.Text);
            else
                data.CoolingMixerMaxTemp = 0;
        }

        private void txtPlasticizerTimeFrom_Enter(object sender, EventArgs e)
        {
            MaskedTextBox TB = (MaskedTextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.Show("زمان را به دقیقه و ثانیه وارد کنید", TB, -30, -40, VisibleTime);
        }

        private void txtStartTime_Enter(object sender, EventArgs e)
        {
            MaskedTextBox TB = (MaskedTextBox)sender;
            int VisibleTime = 3000;  //in milliseconds

            ToolTip tt = new ToolTip();
            tt.IsBalloon = true;
            tt.Show("زمان را به ساعت و دقیقه وارد کنید", TB, -30, -40, VisibleTime);
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

        private void gridviewMaterial_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                if (DialogResult.No == MessageBox.Show("مایل به ویرایش اطلاعات هستید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Information))
                    return;

                var id = int.Parse(gridviewMaterial.Rows[e.RowIndex].Cells["uid"].Value.ToString());

                DataRow dr = tblDataMaterial.Select("uid=" + id).First();
                ClearMaterialForm();
                PDatamaterial.uid = int.Parse(dr["uid"].ToString());
                PDatamaterial.IDGranule = int.Parse(dr["IDGranule"].ToString());
                PDatamaterial.IDBatch = int.Parse(dr["IDBatch"].ToString());
                PDatamaterial.RawMaterial = int.Parse(dr["RawMaterial"].ToString());
                PDatamaterial.MaterialName = int.Parse(dr["MaterialName"].ToString());
                PDatamaterial.ICC = int.Parse(dr["ICC"].ToString());
                PDatamaterial.PartNum = decimal.Parse(dr["PartNum"].ToString());
                PDatamaterial.SeriSakht = dr["SeriSakht"].ToString();
                var aa = int.Parse(BaseDat.Select("FK_Parent_uid=28 and ID=" + PDatamaterial.RawMaterial.ToString()).First()["uid"].ToString());
                comRawMaterial.SelectedValue = aa;
                comMaterialName.SelectedValue = PDatamaterial.MaterialName;
                txtICCMaterial.Text = PDatamaterial.ICC.ToString();
                txtPartNumMaterial.Text = PDatamaterial.PartNum.ToString();
                txtSerisakht.Text = PDatamaterial.SeriSakht;
                tblDataMaterial.Rows.Remove(dr);
                dr = tblDataMaterialview.Select("uid=" + id).First();
                tblDataMaterialview.Rows.Remove(dr);
            }
        }
    }
}
