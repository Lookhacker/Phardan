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
    public partial class frmMediticalWorkOrder : Form
    {
        public frmMediticalWorkOrder()
        {
            InitializeComponent();
        }

        private void frmTemplateAgenda_Load(object sender, EventArgs e)
        {
            getdata();
        }
        DataTable AllData;
        private void getdata()
        {
            LINQDataContext db = new LINQDataContext();
            AllData = Utility.ToDataTable(db.MachineOrderViews.ToList());
            filter();
        }

        private void filter()
        {
            DataTable tmp;
            bool multi = false;
            string Shart = "";

            if (txtId.TextLength > 0)
            {
                Shart = "ID="+txtId.Text;
                multi = true;
            }
            if (txtMach.TextLength > 0)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }

                Shart += "MachineNum=" + txtMach.Text;
                multi = true;
            }
            if (txtYear.TextLength == 4)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }

                Shart += "Year=" + txtYear.Text;
                multi = true;
            }
            if (txtMonth.TextLength >0)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }

                Shart += "Month=" + txtMonth.Text;
                multi = true;
            }
            if (txtPrName.TextLength > 0)
            {
                if (multi)
                {
                    Shart += " and ";
                    multi = false;
                }
                Shart += "ProdectionName like '%" + txtPrName.Text + "%'";
            }

            if (Shart == "")
                tmp = Utility.ToDataTable<MachineOrderView>(AllData.Select("", "ID desc"));
            else
                tmp = Utility.ToDataTable<MachineOrderView>(AllData.Select(Shart, "ID desc"));

            GridALL.DataSource = tmp;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void KeyPresss(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }
       
        private void txtMach_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void txtId_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void txtYear_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void txtPrName_TextChanged(object sender, EventArgs e)
        {
            filter();
        }

        private void txtMonth_TextChanged(object sender, EventArgs e)
        {
            filter();
        }
    }
}
