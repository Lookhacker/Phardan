using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PharmedPlastPouyan
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            if (File.Exists(Application.StartupPath + "\\License.dll"))
            {
               
                Application.Run(new frmLoding());
            }
            else
            {
                MessageBox.Show("خطا در بارگذاری فایل License.dll ", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
