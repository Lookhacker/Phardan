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
    public partial class frmLoding : Form
    {
        DataAccess Data = new DataAccess();
        //int a = 0;
        public frmLoding()
        {
            InitializeComponent();
            backgroundWorker1.WorkerReportsProgress = true;
            backgroundWorker1.WorkerSupportsCancellation = true;
        }

        private void frmLoding_Load(object sender, EventArgs e)
        {
            
            radWaitingBar1.StartWaiting();
            if (backgroundWorker1.IsBusy != true)
            {
                backgroundWorker1.RunWorkerAsync();
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {
            Check = Data.CheckConnection();
        }
        bool Check;
        private void backgroundWorker1_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (Check)
            {
                
                int Version = int.Parse((Assembly.GetExecutingAssembly().GetName().Version.ToString()).Replace(".", ""));
                if (Version < Data.Version)
                {
                    frmViewNotification frm = new frmViewNotification();
                    frm.Message = "با تشکر از همکاری شما\n\n برای برنامه فردان آپدیت جدید منتشر شده است \n\n لطفا برنامه خود را آپدیت کنید";
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    if (Data.Repair)
                    {
                        frmViewNotification frm = new frmViewNotification();
                        frm.Message = "با تشکر از همکاری شما\n\n در حال تغییرات روی سرور هستیم از صبر و شکیبایی شما سپاسگزاریم \n\n بعد از 10 دقیقه مجدادا برنامه را اجرا نمایید";
                        frm.ShowDialog();
                        this.Close();
                    }
                    else
                    {

                        frmLogin frm = new frmLogin();
                        frm.State = "OK";
                        frm.Show();
                        this.Hide();
                    }
                }
            }
            else
            {
                radWaitingBar1.StopWaiting();

                if (Data.farsiMessage == "License")
                {
                    frmViewNotification frm = new frmViewNotification();
                    frm.Message = "برنامه نیاز به لایسنس جدید دارد\n\n لطفا لایسنس جدید برنامه را از واحد پشتیبانی نرم افزار تهیه و در مسیر نصب نرم افزار کپی نمایید";
                    frm.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show(Data.farsiMessage, "اخطار", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    frmLogin frm = new frmLogin();
                    frm.State = "Closed";
                    frm.Show();
                    this.Hide();
                }
            }
        }
    }
}
