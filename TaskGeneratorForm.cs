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
    public partial class TaskGeneratorForm : Form
    {
        Random rnd = new Random();

        public TaskGeneratorForm()
        {
            InitializeComponent();
        }

        private void TaskGeneratorForm_Load(object sender, EventArgs e)
        {
            ((Form1)this.Tag).Enabled = false;

            if (((Form1)this.Tag).edit)
            {
                volumeBox.Text = "edit";
                complexityBox.Text = "edit";
            }
        }

        private void buttonOK_Click(object sender, EventArgs e)
        {
            try
            {
                Figure fig = new Figure(((Form1)this.Tag).X, ((Form1)this.Tag).Y, ((Form1)this.Tag).sizeW, ((Form1)this.Tag).sizeH);
                if (((Form1)this.Tag).isValueFixed)
                {
                    int volume = Convert.ToInt32(volumeBox.Text);
                    int complexity = Convert.ToInt32(complexityBox.Text);

                    if (Controller.getInstance().Generator == null)
                    {
                        Controller.getInstance().Generator = new TaskGenerator(TaskGenerator.GenerationMode.Defined, complexity, volume, fig);
                    }
                    else
                    {
                        Controller.getInstance().Generator.Mode = TaskGenerator.GenerationMode.Defined;
                        Controller.getInstance().Generator.TaskMemoryConsumption = volume;
                        Controller.getInstance().Generator.TaskVolume = complexity;
                    }
                }
                else if(!((Form1)this.Tag).isValueFixed)
                {
                    int memmin = Convert.ToInt32(volumeMinBox.Text);
                    int memmax = Convert.ToInt32(volumeMaxBox.Text);
                    int volmin = Convert.ToInt32(complexityMinBox.Text);
                    int volmax = Convert.ToInt32(complexityMaxBox.Text);

                    if (Controller.getInstance().Generator == null)
                    {
                        Controller.getInstance().Generator = new TaskGenerator(TaskGenerator.GenerationMode.Random, volmin, volmax, memmin, memmax, fig);
                    }
                    else
                    {
                        Controller.getInstance().Generator.Mode = TaskGenerator.GenerationMode.Random;
                        Controller.getInstance().Generator.VolumeMinGenerationBound = volmin;
                        Controller.getInstance().Generator.VolumeMaxGenerationBound = volmax;
                        Controller.getInstance().Generator.MemConsumptionMinGenerationBound = memmin;
                        Controller.getInstance().Generator.MemConsumptionMaxGenerationBound = memmax;
                    }
                }

                if (!((Form1)this.Tag).edit)
                {
                    ((Form1)this.Tag).graphics.FillRectangle(((Form1)this.Tag).brushTG, ((Form1)this.Tag).X, ((Form1)this.Tag).Y, ((Form1)this.Tag).sizeW, ((Form1)this.Tag).sizeH);
                    ((Form1)this.Tag).figures.Add(fig);
                    ((Form1)this.Tag).groundBox.Image = ((Form1)this.Tag).bmp;
                }
                this.Close();
            }
            catch(FormatException)
            {
                MessageBox.Show("Некоректний ввід", "ERROR :(");
            }
        }

        private void fixedValue_CheckedChanged(object sender, EventArgs e)
        {
            ((Form1)this.Tag).isValueFixed = true;
            enabledTextBox(((Form1)this.Tag).isValueFixed);
        }

        private void randomValue_CheckedChanged(object sender, EventArgs e)
        {
            ((Form1)this.Tag).isValueFixed = false;
            enabledTextBox(((Form1)this.Tag).isValueFixed);
        }

        void enabledTextBox(bool flag)
        {
            volumeBox.Enabled = flag;
            complexityBox.Enabled = flag;

            volumeMinBox.Enabled = !flag;
            volumeMaxBox.Enabled = !flag;
            complexityMinBox.Enabled = !flag;
            complexityMaxBox.Enabled = !flag;
        }

        private void TaskGeneratorForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            ((Form1)this.Tag).Enabled = true;
            ((Form1)this.Tag).edit = false;
        }
    }
}
