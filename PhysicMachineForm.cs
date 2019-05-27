using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCenter
{
    public partial class PhysicMachineForm : Form
    {
        public PhysicMachineForm()
        {
            InitializeComponent();
        }

        private void PhysicMachineForm_Load(object sender, EventArgs e)
        {
            ((Form1)this.Tag).Enabled = false;

            if(((Form1)this.Tag).edit)
            {
                textBoxMemory.Text = "edit";
                textBoxSpeed.Text = "edit";
                textBoxCount.Text = "edit";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                uint memoryPhM = Convert.ToUInt32(textBoxMemory.Text);
                uint speedPhM = Convert.ToUInt32(textBoxSpeed.Text);
                uint countPhM = Convert.ToUInt32(textBoxCount.Text);

                if(!((Form1)this.Tag).edit)
                {
                    Figure fig = new Figure(((Form1)this.Tag).X, ((Form1)this.Tag).Y, ((Form1)this.Tag).sizeW, ((Form1)this.Tag).sizeH);
                    ((Form1)this.Tag).graphics.FillRectangle(((Form1)this.Tag).brushPhM, ((Form1)this.Tag).X, ((Form1)this.Tag).Y, ((Form1)this.Tag).sizeW, ((Form1)this.Tag).sizeH);
                    ((Form1)this.Tag).figures.Add(fig);
                    ((Form1)this.Tag).groundBox.Image = ((Form1)this.Tag).bmp;

                    PhysicalMachine physical = new PhysicalMachine((int)speedPhM, (int)memoryPhM, (int)countPhM, fig);

                    Controller.getInstance().Devices.Add(physical);
                    Controller.getInstance().Machines.Add(physical);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректний ввід", "ERROR :(");
            }
        }

        private void PhysicMachineForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form1)this.Tag).Enabled = true;
            ((Form1)this.Tag).edit = false;
        }
    }
}
