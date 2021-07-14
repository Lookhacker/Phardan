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
    public partial class PersonalForm : Form
    {
        DataTable All_Personal;

        public PersonalForm()
        {
            InitializeComponent();
        }

        private void viewOption()
        {
            if (AllView)
            {
                RightClickMenu.Enabled = false;
                return;
            }
            if (DataAccess.User.Admin)
            {
                btnEdit.Visible = true;
                btnDelete.Visible = true;
                btnNew.Visible = true;
            }
            else
            {
                if (DataAccess.Availability.Tolid != null)
                {

                    switch (int.Parse(DataAccess.Availability.Tolid[6].ToString()))
                    {
                        case 2:
                            btnEdit.Visible = false;
                            btnNew.Visible = true;
                            break;
                        case 3:
                            btnEdit.Visible = true;
                            btnNew.Visible = true;
                            break;
                        default:
                            btnEdit.Visible = false;
                            btnNew.Visible = false;
                            break;
                    }
                }
                else
                {
                    btnEdit.Visible = false;
                    btnNew.Visible = false;
                }
            }
        }
        public bool AllView;
        private void PersonalForm_Load(object sender, EventArgs e)
        {
            viewOption();
            LINQDataContext DataBase = new LINQDataContext();
            if (AllView)
            {
                var tmp = from s in DataBase.View_AllPersonals
                          where s.PersonalCode>10000
                          orderby s.PersonalCode
                          select s;
                All_Personal = Utility.ToDataTable(tmp.ToList<View_AllPersonal>());
            }
            else
            {
                var tmp = from s in DataBase.PersonalLists
                          where s.PersonalCode > 10000
                          orderby s.PersonalCode
                          select s;
                All_Personal = Utility.ToDataTable<PersonalList>(tmp.ToList<PersonalList>());

            }
            gridAll.DataSource = All_Personal;
            txtSearch.Focus();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                var tmp = All_Personal.Select(string.Format("EnglishName like '%{0}%' or PersonalName like '%{0}%' or Convert(PersonalCode, 'System.String') like '%{0}%' ", txtSearch.Text), "PersonalCode");
                if (AllView)
                    gridAll.DataSource = Utility.ToDataTable<View_AllPersonal>(tmp);
                else
                    gridAll.DataSource = Utility.ToDataTable<PersonalList>(tmp);
            }
            else
            {
                gridAll.DataSource = All_Personal;
            }
        }



        private void btnexit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnNew_Click(object sender, EventArgs e)
        {
            pnlEditNew.Visible = true;
            gridAll.Enabled = false;
            txtSearch.Enabled = false;
            New = true;
            txtPcode.Enabled = true;
            txtPcode.Text = "";
            txtPnameFA.Text = "";
            txtPnameEN.Text = "";
            txtPcode.Focus();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            pnlEditNew.Visible = false;
            gridAll.Enabled = true;
            txtSearch.Enabled = true;
        }

        bool New = true;
        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (New)
            {
                LINQDataContext db = new LINQDataContext();
                PersonalList data = new PersonalList();
                data.PersonalCode = int.Parse(txtPcode.Text);
                data.PersonalName = txtPnameFA.Text;
                data.EnglishName = txtPnameEN.Text;

                var tmp = (from s in db.PersonalLists where s.PersonalCode == data.PersonalCode select s).SingleOrDefault();
                if (tmp == null)
                {
                    db.PersonalLists.InsertOnSubmit(data);
                }
                else
                {
                    MessageBox.Show("این نام کاربری قبلا به نام " + tmp.PersonalName + " وارد شده است");
                }
                try { db.SubmitChanges(); }
                catch (Exception) { }
            }
            else
            {
                LINQDataContext db = new LINQDataContext();
                var tmp = (from s in db.PersonalLists where s.PersonalCode == int.Parse(txtPcode.Text) select s).SingleOrDefault();
                tmp.EnglishName = txtPnameEN.Text.Trim();
                tmp.PersonalName = txtPnameFA.Text.Trim();
                try { db.SubmitChanges(); }
                catch (Exception) { }

            }
            txtPcode.Enabled = true;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            pnlEditNew.Visible = true;
            gridAll.Enabled = false;
            txtSearch.Enabled = false;
            New = false;
            txtPcode.Enabled = false;
            txtPcode.Text = gridAll.SelectedRows[0].Cells["PersonalCode"].Value.ToString();
            txtPnameFA.Text = gridAll.SelectedRows[0].Cells["PersonalName"].Value.ToString();
            txtPnameEN.Text = gridAll.SelectedRows[0].Cells["EnglishName"].Value.ToString();

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("ایا مایل به حذف کاربر می باشید؟", "اطلاعات", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
            {
                LINQDataContext db = new LINQDataContext();
                var tmp = (from s in db.PersonalLists
                           where s.PersonalCode == int.Parse(gridAll.SelectedRows[0].Cells["PersonalCode"].Value.ToString())
                           select s).SingleOrDefault();
                db.PersonalLists.DeleteOnSubmit(tmp);
                try { db.SubmitChanges(); }
                catch (Exception) { }
            }
        }

        private void label42_Click(object sender, EventArgs e)
        {

        }
    }
}
