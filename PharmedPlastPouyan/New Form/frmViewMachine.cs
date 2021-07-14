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
    public partial class frmViewMachine : Form
    {
        public int MachineNumber = 0;

        public frmViewMachine()
        {
            InitializeComponent();
        }
        private void frmViewMachine_Load(object sender, EventArgs e)
        {
            LINQDataContext DataBase = new LINQDataContext();
            var tmp = from s in DataBase.MachineSpecs where s.MachineNumber == MachineNumber select s;
            if (tmp.Count() == 1)
            {
                MachineSpec mac = tmp.SingleOrDefault();
                txtMachineNumber.Text = mac.MachineNumber.ToString();
                txtMachineName.Text = mac.MachineName;
                txtModel.Text = mac.Model;
                txtSerial.Text = mac.Serial;
                txtOrigin.Text = mac.Origin;
                txtManufacturingYear.Text = mac.ManufacturingYear;
                ViewMachine(mac.InstallationPosition);
                Animation(mac.MachineNumber);
            }
        }

        private void Animation(int machineNumber)
        {
            switch (machineNumber)
            {
                case 1:
                    led2.Location= new Point(82, 98);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 2:
                    led2.Location= new Point(159, 104);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 3:
                    led3.Location= new Point(226, 107);
                    led3.Enabled = true;
                    timer3.Enabled = true;
                    break;
                case 4:
                    led3.Location= new Point(372, 107);
                    led3.Enabled = true;
                    timer3.Enabled = true;
                    break;
                case 5:
                    led2.Location= new Point(485, 107);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 6:
                   // led2.Location= new Point(156, 114);
                    break;
                case 15:
                    led2.Location= new Point(802, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 16:
                    led2.Location= new Point(721, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 17:
                    led2.Location= new Point(631, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 18:
                    led2.Location= new Point(549, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 19:
                    led1.Location= new Point(475, 380);
                    led1.Enabled = true;
                    timer1.Enabled = true;
                    break;
                case 20:
                    led1.Location= new Point(402,380);
                    led1.Enabled = true;
                    timer1.Enabled = true;
                    break;
                case 27:
                    led2.Location= new Point(80, 308);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 28:
                    led2.Location= new Point(172, 308);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 31:
                    led2.Location= new Point(402, 308);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 32:
                    led2.Location= new Point(482, 308);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 33:
                    led2.Location= new Point(567, 308);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 52:
                    led2.Location= new Point(510, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 53:
                    led2.Location = new Point(590, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 54:
                    led2.Location = new Point(684, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 55:
                    led2.Location = new Point(748, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 56:
                    led2.Location = new Point(851, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 57:
                    led2.Location = new Point(929, 329);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 58:
                    led3.Location= new Point(1018, 319);
                    led3.Enabled = true;
                    timer3.Enabled = true;
                    break;
                case 60:
                    led2.Location= new Point(1085,67);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                case 61:
                    led2.Location= new Point(1009, 67);
                    led2.Enabled = true;
                    timer2.Enabled = true;
                    break;
                default:
                    break;
            }
        }

        private void ViewMachine(string installationPosition)
        {
            switch (installationPosition)
            {
                case "Production Site Ground floor 1":
                    txtInstallationPosition.Text = "طبقه همکف - سالن 1";
                    pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.Salon_1;
                    break;

                case "Production Site First floor 1":
                    txtInstallationPosition.Text = "طبقه اول - سالن 2";
                    pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.Salon_2;
                    break;

                case "Production Site First floor 2":
                    pictureBox1.Image = global::PharmedPlastPouyan.Properties.Resources.Salon_3;
                    txtInstallationPosition.Text = "طبقه اول - سالن 3";
                    break;

                default:
                    break;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
                led1.Visible = !led1.Visible;
        }
        private void timer2_Tick(object sender, EventArgs e)
        {
            led2.Visible = !led2.Visible;
        }
        private void timer3_Tick(object sender, EventArgs e)
        {
            led3.Visible = !led3.Visible;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            timer1.Enabled = timer2.Enabled = timer3.Enabled = false;
            this.Close();
        }
    }
}
