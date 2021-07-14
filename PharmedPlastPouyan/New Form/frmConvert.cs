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
    public partial class frmConvert : Form
    {
        public frmConvert()
        {
            InitializeComponent();
        }
        private void IsNumberic(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        #region Date
        private void txtDay_TextChanged(object sender, EventArgs e)
        {
            if (txtDay.Text == "")
            {
                return;
            }
            int test = int.Parse(txtDay.Text);

            if (test > 31 || test < 1)
            {
                txtDay.Clear();
                return;
            }
            FillDate();
        }
        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            if (txtMonth.Text == "")
            {
                return;
            }
            int test = int.Parse(txtMonth.Text);

            if (test > 12 || test < 1)
            {
                txtMonth.Clear();
                return;
            }
            FillDate();
        }
        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            FillDate();
        }
        private void chkShiftStatus_ValueChanged(object sender, EventArgs e)
        {
            FillDate();
        }
        private void FillDate()
        {
            if (txtDay.Text.Length > 0 && txtMonth.Text.Length > 0 && (txtYear.Text.Length > 3 && txtYear.Text.Length < 5))
            {
                int a = 0;
                if (chkShiftStatus.Value)
                    a = 0;
                else
                    a = 1;
                Tools tools = new Tools(txtYear.Text, txtMonth.Text, txtDay.Text, a);
                lblWeek.Text = tools.WeekNum.ToString();
                lblBatch.Text = tools.BatchNum.ToString();
                lblLot.Text = tools.LotNum.ToString();
            }
            else
            {
                lblWeek.Text = "-----";
                lblBatch.Text = "-----";
                lblLot.Text = "-----";
            }
        }
        #endregion

        private void frmConvert_Load(object sender, EventArgs e)
        {
            txtDay.Text = Tools.GetPersianDay().ToString();
            txtMonth.Text = Tools.GetPersianMonth().ToString();
            txtYear.Text = Tools.GetPersianYear().ToString();

        }

        private void txtLot_TextChanged(object sender, EventArgs e)
        {
            if (txtLot.TextLength == 5)
            {
                int week = int.Parse(txtLot.Text[1].ToString() + txtLot.Text[2].ToString());
                MessageBox.Show("فرمت وارد شده صحیح نمیباشد", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                lblDay.Text = lblMonth.Text = lblYear.Text = lblShift.Text = "-----";
            }
            else
            {
                lblDay.Text = lblMonth.Text = lblYear.Text = lblShift.Text = "-----";
            }
        }
    }
}
