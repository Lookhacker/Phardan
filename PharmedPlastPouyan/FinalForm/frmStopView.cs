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
    public partial class frmStopView : Form
    {
        DataAccess Data = new DataAccess();
        DataTable DataParrent = new DataTable();
        DataTable DataAll = new DataTable();
        int ParrentID;

        public bool DoubleClicked = false;
        public string stopID = "";

        public frmStopView()
        {
            InitializeComponent();
            DataParrent = Data.Select("StopType", "ParrentID=0 order by Tartib ASC");
            comType.DataSource = DataParrent;
        }
        private void FetchData(string parrent)
        {
            DataAll = Data.Select("StopType", "ParrentID=" + parrent + " order by Tartib ASC");
            gridAll.DataSource = DataAll;
        }
        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void comType_SelectedIndexChanged(object sender, EventArgs e)
        {
            ParrentID = (int)comType.SelectedValue;
            FetchData(ParrentID.ToString());
        }

        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                stopID = gridAll.Rows[e.RowIndex].Cells["StopID"].Value.ToString();
                DoubleClicked = true;
                this.Close();
            }
        }
    }
}
