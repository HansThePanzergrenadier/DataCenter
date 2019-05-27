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
    public partial class ConnectForm : Form
    {
        public ConnectForm()
        {
            InitializeComponent();
        }

        private void ConnectForm_Load(object sender, EventArgs e)
        {
            ((Form1)this.Tag).Enabled = false;

            if (((Form1)this.Tag).edit)
            {
                textBoxСapacity.Text = "edit";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                int capacity = (int)Convert.ToUInt32(textBoxСapacity.Text);

                if (!((Form1)this.Tag).edit)
                {
                    LineConnect line = new LineConnect(((Form1)this.Tag).X1, ((Form1)this.Tag).Y1, ((Form1)this.Tag).X2, ((Form1)this.Tag).Y2);
                    ((Form1)this.Tag).graphics.DrawLine(((Form1)this.Tag).pen, ((Form1)this.Tag).X1, ((Form1)this.Tag).Y1, ((Form1)this.Tag).X2, ((Form1)this.Tag).Y2);
                    ((Form1)this.Tag).lines.Add(line);
                    ((Form1)this.Tag).groundBox.Image = ((Form1)this.Tag).bmp;

                    Controller.getInstance().ConnectDevices(((Form1)this.Tag).figReturn1.Owner , ((Form1)this.Tag).figReturn2.Owner, capacity, line);
                }
                this.Close();
            }
            catch (Exception)
            {
                MessageBox.Show("Некоректний ввід", "ERROR :(");
            }
        }

        private void ConnectForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form1)this.Tag).Enabled = true;
            ((Form1)this.Tag).edit = false;
        }
    }
}