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
    public partial class frmMachineSpecs : Form
    {
        bool Edit = false;
        public frmMachineSpecs()
        {
            InitializeComponent();
        }

        private void frmMachineSpecs_Load(object sender, EventArgs e)
        {
            getData();
        }

        private void getData()
        {
            LINQDataContext db = new LINQDataContext();
            DataTable dt = Utility.ToDataTable<MachineSpec>(db.MachineSpecs.Where(x=>x.MachineNumber<900).ToList());
            gridAll.DataSource = dt;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlView.Visible = pnlView.Enabled = false;
            btnExit.Enabled = true;
            gridAll.Enabled = true;
            Edit = false;
            getData();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlView.Visible = pnlView.Enabled = true;
            btnExit.Enabled = false;
            gridAll.Enabled = false;
            txtNum.Clear();
            txtName.Clear();
            txtSerial.Clear();
            txtPosition.Clear();
            txtModel.Clear();
            txtorigin.Clear();
            txtYear.Clear();
            txtNum.Focus();
            Edit = false;
        }
        int uid = 0;
        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlView.Visible = pnlView.Enabled = true;
            btnExit.Enabled = false;
            gridAll.Enabled = false;
            uid = int.Parse(gridAll.SelectedRows[0].Cells["uid"].Value.ToString());
            txtNum.Text = gridAll.SelectedRows[0].Cells["MachineNumber"].Value.ToString();
            txtName.Text = gridAll.SelectedRows[0].Cells["MachineName"].Value.ToString();
            txtSerial.Text = gridAll.SelectedRows[0].Cells["Serial"].Value.ToString();
            txtPosition.Text = gridAll.SelectedRows[0].Cells["InstallationPosition"].Value.ToString();
            txtModel.Text = gridAll.SelectedRows[0].Cells["Model"].Value.ToString();
            txtorigin.Text = gridAll.SelectedRows[0].Cells["Origin"].Value.ToString();
            txtYear.Text = gridAll.SelectedRows[0].Cells["ManufacturingYear"].Value.ToString();

            Edit = true;
        }

        private void txtNum_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            try
            {

                if (Edit)
                {
                    LINQDataContext db = new LINQDataContext();
                    MachineSpec tmp = (from s in db.MachineSpecs where s.uid == uid select s).SingleOrDefault();
                    MachineSpec tmp2 = new MachineSpec();
                    tmp2.uid = uid;
                    tmp2.MachineNumber = int.Parse(txtNum.Text);
                    tmp2.MachineName = txtName.Text;
                    tmp2.Model = txtModel.Text;
                    tmp2.Serial = txtSerial.Text;
                    tmp2.Origin = txtorigin.Text;
                    tmp2.ManufacturingYear = txtYear.Text;
                    tmp2.InstallationPosition = txtPosition.Text;

                    if (tmp != null)
                    {
                        if (Utility.NotEqual(tmp, tmp2))
                        {
                            var moj = from s in db.MachineSpecs where s.MachineNumber == tmp2.MachineNumber && s.Serial == tmp2.Serial select s;

                            if (moj.Count() < 2)
                            {
                                tmp.uid = tmp2.uid;
                                tmp.MachineNumber = tmp2.MachineNumber;
                                tmp.MachineName = tmp2.MachineName;
                                tmp.Model = tmp2.Model;
                                tmp.Serial = tmp2.Serial;
                                tmp.Origin = tmp2.Origin;
                                tmp.ManufacturingYear = tmp2.ManufacturingYear;
                                tmp.InstallationPosition = tmp2.InstallationPosition;
                                db.SubmitChanges();
                            }
                            else
                            {
                                MessageBox.Show("این شماره ماشین و شماره سریال قبلا ثبت شده اند", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                txtNum.Focus();
                            }
                        }
                        else
                        {
                            MessageBox.Show("موردی را برای ویرایش انجام ندادید", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            btnClose_Click(null, null);
                        }
                    }

                }
                else
                {
                    LINQDataContext db = new LINQDataContext();
                    MachineSpec tmp = new MachineSpec();
                    tmp.uid = uid;
                    tmp.MachineNumber = int.Parse(txtNum.Text);
                    tmp.MachineName = txtName.Text;
                    tmp.Model = txtModel.Text;
                    tmp.Serial = txtSerial.Text;
                    tmp.Origin = txtorigin.Text;
                    tmp.ManufacturingYear = txtYear.Text;
                    tmp.InstallationPosition = txtPosition.Text;


                    var moj = from s in db.MachineSpecs where s.MachineNumber == tmp.MachineNumber && s.Serial == tmp.Serial select s;

                    if (moj.Count() == 0)
                    {
                        db.MachineSpecs.InsertOnSubmit(tmp);
                        db.SubmitChanges();
                    }
                    else
                    {
                        MessageBox.Show("این شماره ماشین و شماره سریال قبلا ثبت شده اند", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        txtNum.Focus();
                    }
                }
                btnClose_Click(null, null);
            }
            catch (Exception)
            {
                MessageBox.Show("خطا در بارگزاری اطللاعات.", "", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            if (!DataAccess.User.Admin || gridAll.SelectedRows.Count == 0)
            {
                e.Cancel = true;
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ایا مایل به حذف این ماشین می باشید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                LINQDataContext db = new LINQDataContext();
                var tmp = (from s in db.MachineSpecs
                           where s.uid == int.Parse(gridAll.SelectedRows[0].Cells["uid"].Value.ToString())
                           select s).SingleOrDefault();
                db.MachineSpecs.DeleteOnSubmit(tmp);
                try { db.SubmitChanges(); }
                catch (Exception) { }
            }
        }

        private void gridAll_CellDoubleClick(object sender, Telerik.WinControls.UI.GridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                frmViewMachine frm = new frmViewMachine();
                frm.MachineNumber = int.Parse(e.Row.Cells["MachineNumber"].Value.ToString());
                frm.ShowDialog();
            }
        }
    }
}
