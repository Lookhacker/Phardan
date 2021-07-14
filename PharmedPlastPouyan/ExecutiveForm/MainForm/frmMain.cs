using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    public partial class frmMain : Telerik.WinControls.UI.RadRibbonForm
    {
        bool exitf;

        public frmMain()
        {
            InitializeComponent();
            Availability();
        }
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (!exitf)
            {
                DialogResult result = MessageBox.Show("خروج", "آیا مایل به خروج از نرم افزار هستید ؟", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (result == DialogResult.Yes)
                {
                    exitf = true;
                    Application.Exit();
                    return;
                }
                else
                {
                    e.Cancel = true;
                }
            }
        }

        private void frmMain_Load(object sender, EventArgs e)
        {
            string mes = "کاربر آنلاین {0}";
            mes = string.Format(mes, DataAccess.User.PName);
            btnChangeYear.Text = DataAccess.YearDefault.ToString();
            lblStatus.Text = mes;
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }

        }
        private void Availability()
        {
            if (DataAccess.User.Admin)
            {
                return;
            }
            //
            //***Ghaleb***//
            //

            if (int.Parse(DataAccess.Availability.Ghaleb[0].ToString()) < 1) { Mold_1.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Ghaleb[1].ToString()) < 1) { Mold_2.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Ghaleb[2].ToString()) < 1) { Mold_3.Enabled = false; }
            //
            //***QRD***//
            //
            if (int.Parse(DataAccess.Availability.QRD[0].ToString()) < 1) { QRD_1.Enabled = false; }
            if (int.Parse(DataAccess.Availability.QRD[1].ToString()) < 1) { QRD_2.Enabled = false; }

            //
            //***Fani***//
            //
            if (int.Parse(DataAccess.Availability.Fani[0].ToString()) < 1) { Fani_1.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Fani[1].ToString()) < 1) { Fani_2.Enabled = false; }
            //
            //***Sanaye***//
            //
            if (int.Parse(DataAccess.Availability.Sanaye[0].ToString()) < 1) { Sanaye_1.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Sanaye[1].ToString()) < 1) { Sanaye_2.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Sanaye[2].ToString()) < 1) { Sanaye_3.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Sanaye[3].ToString()) < 1) { Sanaye_4.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Sanaye[4].ToString()) < 1) { Sanaye_5.Enabled = false; }
            //
            //***Analiz***//
            //
            if (int.Parse(DataAccess.Availability.Analiz[0].ToString()) < 1) { Analiz_1.Enabled = false; } 
            if (int.Parse(DataAccess.Availability.Analiz[1].ToString()) < 1) { Analiz_2.Enabled = false; } 
            if (int.Parse(DataAccess.Availability.Analiz[2].ToString()) < 1) { Analiz_3.Enabled = false; } 
            if (int.Parse(DataAccess.Availability.Analiz[3].ToString()) < 1) { Analiz_4.Enabled = false; }
            if (int.Parse(DataAccess.Availability.Analiz[4].ToString()) < 1) { Analiz_5.Enabled = false; } 
            //
            //***Tolid***//
            //
            if (int.Parse(DataAccess.Availability.Tolid[0].ToString()) < 1) { Tolid_1.Enabled = false; } // ثبت آمار تولید
            if (int.Parse(DataAccess.Availability.Tolid[1].ToString()) < 1) { Tolid_2.Enabled = false; } // ثبت آمار بازکاری
            if (int.Parse(DataAccess.Availability.Tolid[2].ToString()) < 1) { Tolid_3.Enabled = false; } // ثبت آمار چک و مونتاژ
            if (int.Parse(DataAccess.Availability.Tolid[3].ToString()) < 1) { Tolid_4.Enabled = false; } //
            if (int.Parse(DataAccess.Availability.Tolid[6].ToString()) < 1) { Tolid_7.Enabled = false; } // اطلاعات اپراتور
            if (int.Parse(DataAccess.Availability.Tolid[8].ToString()) < 1) { Tolid_9.Enabled = false; } // جستجو و ویرایش
            if (int.Parse(DataAccess.Availability.Tolid[9].ToString()) < 1) { Tolid_10.Enabled = false; }//

        }
        private void Tolid_1_Click(object sender, EventArgs e)
        {
            //frmInsertPR frm = new frmInsertPR();
            frmPRInsert frm = new frmPRInsert();
            frm.ShowDialog();
        }
        private void InsertTolid_Click(object sender, EventArgs e)
        {
            Tolid_1_Click(null, null);
        }

        private void Tolid_9_Click(object sender, EventArgs e)
        {
            frmSearchAll frm = new frmSearchAll();
            frm.ShowDialog();
        }
        private void btnSearch_Click(object sender, EventArgs e)
        {
            Tolid_9_Click(null, null);
        }

        private void Tolid_7_Click(object sender, EventArgs e)
        {
            OperatorView_Click(null, null);
        }
        private void OperatorView_Click(object sender, EventArgs e)
        {
            PersonalForm frm = new PersonalForm();
            frm.ShowDialog();
        }
        private void btnUserControl_Click(object sender, EventArgs e)
        {
            frmUserView frm = new frmUserView();
            frm.ShowDialog();
        }
        private void btnMoldPress_Click(object sender, EventArgs e)
        {
            frmMoldPress frm = new frmMoldPress();
            frm.ShowDialog();
        }
        private void Mold_2_Click(object sender, EventArgs e)
        {
            btnMoldPress_Click(null, null);
        }
        private void btnGhaleb_Click(object sender, EventArgs e)
        {
            frmMold frm = new frmMold();
            frm.ShowDialog();
        }
        private void Mold_1_Click(object sender, EventArgs e)
        {
            btnGhaleb_Click(null, null);
        }

        private void btnInventory_Click(object sender, EventArgs e)
        {
            frmBalanceView frm = new frmBalanceView();
            frm.ShowDialog();
        }

        private void Analiz_1_Click(object sender, EventArgs e)
        {
            btnInventory_Click(null, null);
        }

        private void btnChartView_Click(object sender, EventArgs e)
        {
            frmChartView frm = new frmChartView();
            frm.Show();
        }

        private void Analiz_2_Click(object sender, EventArgs e)
        {
            btnChartView_Click(null, null);
        }

        private void Tolid_3_Click(object sender, EventArgs e)
        {
            btnAssembly_Click(null, null);
        }

        private void btnAssembly_Click(object sender, EventArgs e)
        {
            frmAssemblyInsert frm = new frmAssemblyInsert();
            frm.ShowDialog();
        }

        private void btnEditRequest_Click(object sender, EventArgs e)
        {
            //frmEditRequest frm = new frmEditRequest();
            //frm.ShowDialog();
        }

        private void Sanaye_1_Click(object sender, EventArgs e)
        {
            btnEditRequest_Click(null, null);
        }

        private void btnProductView_Click(object sender, EventArgs e)
        {
            frmPRoduct frm = new frmPRoduct();
            frm.ShowDialog();
        }

        private void Sanaye_2_Click(object sender, EventArgs e)
        {
            btnProductView_Click(null, null);
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Thread.Sleep(1000);
        }

        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (DataAccess.MessageForUser != "")
            {
                frmViewNotification frm = new frmViewNotification();
                frm.Message = " همکاری گرامی " + DataAccess.User.PName + "\n\n " + DataAccess.MessageForUser + " \n\n  با تشکر - شرکت فارمد پلاست پویان";
                frm.ViewTick = true;
                frm.ShowDialog();
                if (frm.Accept)
                {
                    LINQDataContext DB = new LINQDataContext();
                    tblAdmin tmp = (from u in DB.tblAdmins
                                    where u.Parameter == DataAccess.User.PCode.ToString()
                                    select u).First();
                    tmp.Value = tmp.Parameter + " - " + tmp.Value;
                    tmp.Parameter = "0";
                    try
                    {
                        DB.SubmitChanges();
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("ثبت اطلاعات به دلیل \n" + ex.Message + "\nانجام نشد با پشتیابن تماس بگیرید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        return;
                    }
                }
                MessageUser.Text = DataAccess.MessageForUser;
            }

        }



        private void Tolid_4_Click(object sender, EventArgs e)
        {
            btnGranulInsert_Click(null, null);
        }

        private void btnGranulInsert_Click(object sender, EventArgs e)
        {
            frmGranule frm = new frmGranule();
            frm.ShowDialog();
        }

        private void btnWorkOrder_Click(object sender, EventArgs e)
        {
            frmWorkOrder frm = new frmWorkOrder();
            frm.ShowDialog();

        }

        private void Sanaye_3_Click(object sender, EventArgs e)
        {
            btnWorkOrder_Click(null, null);
        }

        private void btnWorkOrderView_Click(object sender, EventArgs e)
        {
            frmWorkOrderTable frm = new frmWorkOrderTable();

            frm.ShowDialog();

        }

        private void Sanaye_4_Click(object sender, EventArgs e)
        {
            btnWorkOrderView_Click(null, null);
        }

        private void btnTime_Click(object sender, EventArgs e)
        {
            frmTimeTable frm = new frmTimeTable();
            frm.Show();
        }

        private void Sanaye_5_Click(object sender, EventArgs e)
        {
            btnTime_Click(null, null);
        }

        private void Analiz_4_Click(object sender, EventArgs e)
        {
            btnChartViewAS_Click(null, null);
        }

        private void btnChartViewAS_Click(object sender, EventArgs e)
        {
            frmChartViewAS frm = new frmChartViewAS();
            frm.Show();
        }

        private void Analiz_3_Click(object sender, EventArgs e)
        {
            btnChartViewGR_Click(null, null);
        }

        private void btnChartViewGR_Click(object sender, EventArgs e)
        {
            frmChartViewGR frm = new frmChartViewGR();
            frm.Show();
        }

        private void btnMachineSpecs_Click(object sender, EventArgs e)
        {
            frmMachineSpecs frm = new frmMachineSpecs();
            frm.ShowDialog();
        }

        private void Sanaye_6_Click(object sender, EventArgs e)
        {
            btnMachineSpecs_Click(null, null);
        }

        private void Mold_3_Click(object sender, EventArgs e)
        {
            btnWorkOrderMold_Click(null, null);
        }

        private void btnWorkOrderMold_Click(object sender, EventArgs e)
        {
            frmTemplateAgenda frm = new frmTemplateAgenda();
            frm.ShowDialog();
        }

        private void Fani_1_Click(object sender, EventArgs e)
        {
            btnMachine_Click(null, null);
        }

        private void btnMachine_Click(object sender, EventArgs e)
        {
            frmMediticalWorkOrder frm = new frmMediticalWorkOrder();
            frm.ShowDialog();
        }

        private void Tolid_10_Click(object sender, EventArgs e)
        {
            btnConvert_Click(null, null);
        }

        private void btnConvert_Click(object sender, EventArgs e)
        {
            frmConvert frm = new frmConvert();
            frm.ShowDialog();
        }

        private void Analiz_5_Click(object sender, EventArgs e)
        {
            btnKpiView_Click(null,null);
        }

        private void btnKpiView_Click(object sender, EventArgs e)
        {
            frm_KPIView frm = new frm_KPIView();
            frm.ShowDialog();
        }

        

        

        private void btnChangeYear_Click(object sender, EventArgs e)
        {
            frmChangeYear frm = new frmChangeYear();
            frm.ShowDialog();
        }
    }
}
