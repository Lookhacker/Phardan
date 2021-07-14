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
    public partial class frmView : Form
    {
        DataAccess Data = new DataAccess();
        //public DataTable Data;
        public string Shart = "";
        public string codefast;
        public bool Clicked;
        public string kind; 
        public string PRCode;
        public string PRName;
        public int IDPR;
        DataTable AllData;
        public frmView()
        {
            InitializeComponent();
        }

        private void frmView_Load(object sender, EventArgs e)
        {
            string sql;
            if (Shart == "")
                sql = "select * from QuickSelect where kind!='N' order by CodeFast";
            else
                sql = "select * from QuickSelect where kind='" + Shart + "' order by CodeFast";
            AllData = Data.Select(sql);
            gridAll.DataSource = AllData;
        }

        private void radButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                int a = Convert.ToInt16(gridAll.Rows[e.RowIndex].Cells["CodeFast"].Value.ToString());
                PRCode = Convert.ToInt64(gridAll.Rows[e.RowIndex].Cells["Product_Code"].Value.ToString()).ToString();
                PRName = gridAll.Rows[e.RowIndex].Cells["Product_Name"].Value.ToString().Trim();
                kind= gridAll.Rows[e.RowIndex].Cells["kind"].Value.ToString().Trim();
                codefast = a.ToString();
                PRCode.Trim();
                IDPR = Convert.ToInt32(gridAll.Rows[e.RowIndex].Cells["ID"].Value);
                this.Close();
                Clicked = true;
            }
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var tmp = AllData.Select(string.Format("Product_Name like '%{0}%' or Product_Code like '%{0}%' or Convert(CodeFast, 'System.String') like '%{0}%' ", txtSearch.Text), "CodeFast");
                gridAll.DataSource = Utility.ToDataTable<QuickSelect>(tmp);
            }
            else
            {
                gridAll.DataSource = AllData;
            }
        }
    }
}
