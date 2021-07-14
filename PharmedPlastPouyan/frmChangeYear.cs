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
    public partial class frmChangeYear : Form
    {
        public frmChangeYear()
        {
            InitializeComponent();
        }

        private void frmChangeYear_Load(object sender, EventArgs e)
        {
            LINQDataContext db = new LINQDataContext();

            comYear.DataSource = Utility.ToDataTable<tblBaseData>(db.tblBaseDatas.Where(x=>x.FK_Parent_uid==110).ToList());

        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
