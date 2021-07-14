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
    public partial class frmPersonal : Form
    {
        DataAccess Data = new DataAccess();
        public frmPersonal()
        {
            InitializeComponent();
        }

        private void frmPersonal_Load(object sender, EventArgs e)
        {
            DataTable DT = Data.Select("select * from PersonalList where PersonalCode>10");
            dataGridView1.DataSource = DT;
            btnAdd.Enabled = (int.Parse(DataAccess.Availability.Tolid[6].ToString()) > 1);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = false;
            btnAdd.Enabled = true;
            btnexit.Enabled = true;
            dataGridView1.Enabled = true;
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            LINQDataContext db = new LINQDataContext();


            var psa = from s in db.PersonalLists
                      where s.PersonalCode == Convert.ToInt32(txtCode.Text.Trim())
                      select s;
            if (psa.Count() == 0)
            {
                PersonalList ps = new PersonalList();
                ps.PersonalCode = Convert.ToInt32(txtCode.Text.Trim());
                ps.PersonalName = txtName.Text.Trim();
                db.PersonalLists.InsertOnSubmit(ps);

                db.SubmitChanges();
                MessageBox.Show("اطلاعات", "ثبت اطلاعات با موفقیت انجام شد", MessageBoxButtons.OK, MessageBoxIcon.Information);
                dataGridView1.DataSource = Data.Select("select * from PersonalList");

                panelEdit.Visible = false;
                btnAdd.Enabled = true;
                btnexit.Enabled = true;
                dataGridView1.Enabled = true;
            }
            else
            {
                MessageBox.Show("اطلاعات", "این کد پرسنلی قبلا به نام " + psa.First().PersonalName + " شده است", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtName.Clear();
                txtCode.Clear();
                txtName.Focus();
            }


        }
        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void btnAdd_Click(object sender, EventArgs e)
        {
            panelEdit.Visible = true;
            btnAdd.Enabled = false;
            btnexit.Enabled = false;
            dataGridView1.Enabled = false;
            txtCode.Clear();
            txtName.Clear();
            txtName.Focus();
        }

        private void txtCode_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || char.IsControl(e.KeyChar)))
            {
                e.Handled = true;
            }
        }

        private void dataGridView1_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            LINQDataContext DataBase = new LINQDataContext();
            PersonalList tmp = (from s in DataBase.PersonalLists
                                where s.ID == int.Parse(dataGridView1.Rows[e.RowIndex].Cells["ID"].Value.ToString())
                                select s).FirstOrDefault();

            if (int.Parse(DataAccess.Availability.Tolid[6].ToString()) == 9)
            {
                tmp.PersonalCode = int.Parse(dataGridView1.Rows[e.RowIndex].Cells["PersonalCode"].Value.ToString());
                tmp.PersonalName = dataGridView1.Rows[e.RowIndex].Cells["PersonalName"].Value.ToString().Trim();
                DataBase.SubmitChanges();
            }
            else
                MessageBox.Show("شما دسترسی به ویرایش ندارید", "هشدار", MessageBoxButtons.OK, MessageBoxIcon.Hand);

        }

        private void dataGridView1_UserDeletingRow(object sender, DataGridViewRowCancelEventArgs e)
        {
            if (int.Parse(DataAccess.Availability.Tolid[6].ToString()) == 9)
            {
                if (DialogResult.Yes == MessageBox.Show("آیا از حذف این کاربر اطمینان دارید؟", "هشدار", MessageBoxButtons.YesNo, MessageBoxIcon.Question))
                {
                    LINQDataContext DataBase = new LINQDataContext();

                    PersonalList ps = (from s in DataBase.PersonalLists
                                       where s.ID == int.Parse(e.Row.Cells["ID"].Value.ToString())
                                       select s).First();

                    DataBase.PersonalLists.DeleteOnSubmit(ps);
                    DataBase.SubmitChanges();
                }
            }
            else
            {
                MessageBox.Show("شما دسترسی حذف ندارید", "اطلاعات", MessageBoxButtons.OK, MessageBoxIcon.Information);
                e.Cancel = true;
            }

        }
    }
}
