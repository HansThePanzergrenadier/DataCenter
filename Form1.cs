using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DataCenter
{
    public partial class Form1 : Form
    {
        public bool play = false;
        public bool otherFormIsClosed = true;
        string path;

        public Figure figReturn1, figReturn2;
        //---------Графіка----------
        public Graphics graphics, graphics2;
        public Pen penCheck = new Pen(Color.Green, 4);
        public Pen penLineDel = new Pen(Color.White, 6);
        public Color lineColor =  Color.FromArgb(255, 200, 200, 200);
        public Pen pen;
        public SolidBrush brushTG = new SolidBrush(Color.SaddleBrown);
        public SolidBrush brushPhM = new SolidBrush(Color.Black);
        public SolidBrush brushR = new SolidBrush(Color.DarkBlue);
        public SolidBrush brushDel = new SolidBrush(Color.White);
        public Bitmap bmp;
        public List<Figure> figures = new List<Figure>();
        public List<LineConnect> lines = new List<LineConnect>();
        public int sizeW, sizeH, chose = 0;
        public int X, Y, W1, H1, X1, Y1, X2, Y2, X22, X33, X44, Y22, Y33, Y44, xCheck, yCheck, wCheck, hCheck, xCheckLast, yCheckLast, wCheckLast, hCheckLast, del;
        public bool onFigure = false;


        string placeSomething = "";
        public bool edit = false;

        //------Фізична машина-------
        public PhysicMachineForm PhM;
        public uint memoryPhM;
        public uint speedPhM;
        public uint countPhM;

        //------Генератор задач------
        public TaskGeneratorForm TG;
        public bool isValueFixed;
        public int volume, complexity;

        //----------З'єднати----------
        public ConnectForm Connect;
        public uint capacity;

        public Form1()
        {
            InitializeComponent();

            pen = new Pen(lineColor, 6);
            graphics2 = groundBox.CreateGraphics();

            var location = System.Reflection.Assembly.GetExecutingAssembly().Location;
            path = Path.GetDirectoryName(location);

            bmp = new Bitmap(groundBox.Width, groundBox.Height);
            graphics = Graphics.FromImage(bmp);
            groundBox.Image = bmp;
        }

        private void ButtonPlay_Click(object sender, EventArgs e)
        {
            if (!play)
            {
                play = true;
                ButtonPlay.Image = Bitmap.FromFile(path + @"\icon\pauseButton.png");
                ButtonPlay.Text = "Пауза";
                //запуск теста
                Controller.getInstance().GlobalTimer.Start();
            }
            else if (play)
            {
                play = false;
                ButtonPlay.Image = Bitmap.FromFile(path + @"\icon\playButton.png");
                ButtonPlay.Text = "Почати тест";
                //пауза
                Controller.getInstance().GlobalTimer.Stop();
            }
        }

        private void ButtonStop_Click(object sender, EventArgs e)
        {
            play = false;
            ButtonPlay.Image = Bitmap.FromFile(path + @"\icon\playButton.png");
            //зупинити тест
            Controller.getInstance().CancelTest();
        }

        private void фізичнаМашинаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            placeSomething = "Фізична машина";
            sizeW = 70; sizeH = 50;
        }

        private void генераторЗадачToolStripMenuItem_Click(object sender, EventArgs e)
        {
            placeSomething = "Генератор задач";
            sizeW = 70; sizeH = 50;
        }

        private void маршрутизаторToolStripMenuItem_Click(object sender, EventArgs e)
        {
            placeSomething = "Маршрутизатор";
            sizeW = 50; sizeH = 30;
        }

        private void зєднатиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            placeSomething = "З'єднати";
        }

        private void groundBox_MouseDown(object sender, MouseEventArgs e)
        {
            if (placeSomething == "З'єднати" && checkFigure(e.Location.X, e.Location.Y))
            {
                figReturn1 = returnFigure(X, Y);

                X1 = xCheck;
                Y1 = yCheck;
                W1 = wCheck;
                H1 = hCheck;
            }
            else if(e.Button == MouseButtons.Left)
            {
                if (onFigure && chose == 0 && penCheck.Color == Color.Green)
                {
                    penCheck = new Pen(Color.Red, 4);
                }
                else if (chose == 1)
                {
                    penCheck = new Pen(Color.Green, 4);
                    chose = -1;
                }
            }
            else if (e.Button == MouseButtons.Right && placeSomething == "")
            {
                openEditDialog();
                penCheck = new Pen(Color.Green, 4);
                chose = 0;
            }  
        }

        private void groundBox_MouseUp(object sender, MouseEventArgs e)
        {
            if (placeSomething != "")
            {
                X = e.Location.X;
                Y = e.Location.Y;

                if (!checkPosition(X, Y, sizeW, sizeH) && placeSomething != "З'єднати")
                    return;

                if (placeSomething == "Фізична машина")
                {
                    PhM = new PhysicMachineForm();
                    PhM.Tag = this;
                    PhM.Show();
                }
                else if (placeSomething == "Генератор задач")
                {
                    if (Controller.getInstance().Generator == null)
                    {
                        TG = new TaskGeneratorForm();
                        TG.Tag = this;
                        TG.Show();
                    }
                    else
                    {
                        MessageBox.Show("Generator already exists", "Error");
                    }
                }
                else if (placeSomething == "Маршрутизатор")
                {
                    Figure fig = new Figure(X, Y, sizeW, sizeH);
                    graphics.FillRectangle(brushR, X, Y, sizeW, sizeH);
                    figures.Add(fig);
                    groundBox.Image = bmp;
                    Controller.getInstance().Devices.Add(new Router(fig));
                }
                else if (placeSomething == "З'єднати" && checkFigure(X, Y) && X1 != xCheck && Y1 != yCheck)
                {

                    figReturn2 = returnFigure(X, Y);

                    if (Controller.getInstance().FindLink(figReturn1.Owner, figReturn2.Owner) == null)
                    {
                        if (X1 < X)
                        {
                            X1 += W1;
                            X2 = xCheck;
                        }
                        else
                        {
                            X2 = xCheck + wCheck;
                        }

                        if (Y1 < Y)
                        {
                            Y1 += H1;
                            Y2 = yCheck;
                        }
                        else
                        {
                            Y2 = yCheck + hCheck;
                        }

                        Connect = new ConnectForm();
                        Connect.Tag = this;
                        Connect.Show();
                    }
                    else
                    {
                        MessageBox.Show("Devices already connected", "Error");
                    }
                }

                placeSomething = "";
            }  
        }

        private void groundBox_MouseMove(object sender, MouseEventArgs e)
        {
            X = e.Location.X;
            Y = e.Location.Y;

            if (checkFigure(X, Y) && chose == 0)
            {
                del = 1;
                graphics2.DrawRectangle(penCheck, xCheck, yCheck, wCheck, hCheck);
                xCheckLast = xCheck;
                yCheckLast = yCheck;
                wCheckLast = wCheck;
                hCheckLast = hCheck;

                onFigure = true;

                if(penCheck.Color == Color.Red)
                    chose = 1;
            }
            else if(checkLine(X, Y) && chose == 0)
            {
                del = 2;
                graphics2.DrawLine(penCheck, xCheck, yCheck, wCheck, hCheck);
                xCheckLast = xCheck;
                yCheckLast = yCheck;
                wCheckLast = wCheck;
                hCheckLast = hCheck;

                onFigure = true;

                if (penCheck.Color == Color.Red)
                    chose = 1;
            }
            else if (chose != 1)
            {
                groundBox.Image = bmp;
                onFigure = false;
                chose = 0;

                xCheck = -1;
                wCheck = -1;
                yCheck = -1;
                hCheck = -1;
            }

            if (placeSomething != "")
                groundBox.Cursor = Cursors.Cross;
            else
                groundBox.Cursor = Cursors.Default;
        }

        private void видалитиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if(chose == 1)
            {
                if(del == 1)
                {
                    graphics.FillRectangle(brushDel, xCheckLast, yCheckLast, wCheckLast, hCheckLast);

                    foreach (var el in figures)
                    {
                        if (el.Xpos == xCheckLast && el.Ypos == yCheckLast)
                        {
                            for (int i = 0; i < lines.Count; i++)
                            {
                                if ((lines[i].X1 == el.Xpos && lines[i].Y1 == el.Ypos) || (lines[i].X2 == el.Xpos && lines[i].Y2 == el.Ypos) ||
                                    (lines[i].X1 == el.Xpos + el.width && lines[i].Y1 == el.Ypos) || (lines[i].X2 == el.Xpos + el.width && lines[i].Y2 == el.Ypos) ||
                                    (lines[i].X1 == el.Xpos + el.width && lines[i].Y1 == el.Ypos + el.height) || (lines[i].X2 == el.Xpos + el.width && lines[i].Y2 == el.Ypos + el.height) ||
                                    (lines[i].X1 == el.Xpos && lines[i].Y1 == el.Ypos + el.height) || (lines[i].X2 == el.Xpos && lines[i].Y2 == el.Ypos + el.height))
                                {
                                    graphics.DrawLine(penLineDel, lines[i].X1, lines[i].Y1, lines[i].X2, lines[i].Y2);
                                    Controller.getInstance().Links.Remove(lines[i].Owner);
                                    lines.RemoveAt(i);
                                    i--;
                                }
                            }

                            chose = 0;
                            penCheck = new Pen(Color.Green, 4);

                            if(el.Owner.DeviceType == Device.DeviceTypes.TaskGenerator)
                            {
                                Controller.getInstance().Generator = null;
                            }
                            else if (el.Owner.DeviceType == Device.DeviceTypes.PhysicalMachine)
                            {
                                Controller.getInstance().Devices.Remove(el.Owner);
                                Controller.getInstance().Machines.Remove((PhysicalMachine)el.Owner);
                            }
                            else
                            {
                                Controller.getInstance().Devices.Remove(el.Owner);
                            }

                            figures.Remove(el);
                            break;
                        }
                    }
                }
                else  if(del == 2)
                {
                    foreach (var el in lines)
                    {
                        if ((el.X1 == xCheckLast && el.Y1 == yCheckLast && el.X2 == wCheckLast && el.Y2 == hCheckLast) || 
                            (el.X2 == xCheckLast && el.Y2 == yCheckLast && el.X1 == wCheckLast && el.Y1 == hCheckLast))
                        {
                            graphics.DrawLine(penLineDel, el.X1, el.Y1, el.X2, el.Y2);
                            chose = 0;
                            penCheck = new Pen(Color.Green, 4);
                            Controller.getInstance().Links.Remove(el.Owner);
                            lines.Remove(el);
                            break;
                        }
                    }
                }

                UpdateGraphics();
                groundBox.Image = bmp;
            }
        }

        void UpdateGraphics()
        {
            foreach (var el in figures)
            {
                if (el.Owner.DeviceType == Device.DeviceTypes.PhysicalMachine)
                    graphics.FillRectangle(brushPhM, el.Xpos, el.Ypos, el.width, el.height);
                else if (el.Owner.DeviceType == Device.DeviceTypes.TaskGenerator)
                    graphics.FillRectangle(brushTG, el.Xpos, el.Ypos, el.width, el.height);
                else
                    graphics.FillRectangle(brushR, el.Xpos, el.Ypos, el.width, el.height);
            }

            foreach (var el in lines)
            {
                graphics.DrawLine(pen, el.X1, el.Y1, el.X2, el.Y2);
            }
        }

        void openEditDialog()
        {
            foreach(var el in figures)
            {
                if(el.Owner.DeviceType == Device.DeviceTypes.PhysicalMachine && el.Xpos == xCheck && el.Ypos == yCheck)
                {
                    edit = true;
                    PhM = new PhysicMachineForm();
                    PhM.Tag = this;
                    PhM.Show();

                    return;
                }
                else if(el.Owner.DeviceType == Device.DeviceTypes.TaskGenerator && el.Xpos == xCheck && el.Ypos == yCheck)
                {
                    edit = true;
                    TG = new TaskGeneratorForm();
                    TG.Tag = this;
                    TG.Show();

                    return;
                }
            }

            foreach (var el in lines)
            {
                if ((el.X1 == xCheck && el.Y1 == yCheck && el.X2 == wCheck && el.Y2 == hCheck) ||
                   (el.X2 == xCheck && el.Y2 == yCheck && el.X1 == wCheck && el.Y1 == hCheck))
                {
                    edit = true;
                    Connect = new ConnectForm();
                    Connect.Tag = this;
                    Connect.Show();

                    return;
                }
            }
        }

        public bool checkPosition(int x, int y, int w, int h)
        {
            foreach (var el in figures)
            {
                if (x >= el.Xpos - w - 5 && x <= el.Xpos + el.width + 5 && y >= el.Ypos - h - 5 && y <= el.Ypos + el.height + 5)
                    return false;
            }

            foreach (var el in lines)
            {
                X33 = Math.Abs(el.X1 + el.X2) / 2;
                Y33 = Math.Abs(el.Y1 + el.Y2) / 2;

                X22 = Math.Abs(el.X1 + X33) / 2;
                Y22 = Math.Abs(el.Y1 + Y33) / 2;

                X44 = Math.Abs(X33 + el.X2) / 2;
                Y44 = Math.Abs(Y33 + el.Y2) / 2;

                if ((x >= el.X1 - w - 5 && x <= X22 + 5 && y >= el.Y1 - h - 5 && y <= Y22 + 5) || (x >= el.X1 - w - 5 && x <= X22 + 5 && y >= Y22 - h - 5 && y <= el.Y1 + 5) ||
                    (x >= X22 - w - 5 && x <= el.X1 + 5 && y >= Y22 - h - 5 && y <= el.Y1 + 5) || (x >= X22 - w - 5 && x <= el.X1 + 5 && y >= el.Y1 - h - 5 && y <= Y22 + 5) ||

                    (x >= X22 - w - 5 && x <= X33 + 5 && y >= Y22 - h - 5 && y <= Y33 + 5) || (x >= X22 - w - 5 && x <= X33 + 5 && y >= Y33 - h - 5 && y <= Y22 + 5) ||
                    (x >= X33 - w - 5 && x <= X22 + 5 && y >= Y33 - h - 5 && y <= Y22 + 5) || (x >= X33 - w - 5 && x <= X22 + 5 && y >= Y22 - h - 5 && y <= Y33 + 5) ||

                    (x >= X33 - w - 5 && x <= X44 + 5 && y >= Y33 - h - 5 && y <= Y44 + 5) || (x >= X33 - w - 5 && x <= X44 + 5 && y >= Y44 - h - 5 && y <= Y33 + 5) ||
                    (x >= X44 - w - 5 && x <= X33 + 5 && y >= Y44 - h - 5 && y <= Y33 + 5) || (x >= X44 - w - 5 && x <= X33 + 5 && y >= Y33 - h - 5 && y <= Y44 + 5) ||

                    (x >= X44 - w - 5 && x <= el.X2 + 5 && y >= Y44 - h - 5 && y <= el.Y2 + 5) || (x >= X44 - w - 5 && x <= el.X2 + 5 && y >= el.Y2 - h - 5 && y <= Y44 + 5) ||
                    (x >= el.X2 - w - 5 && x <= X44 + 5 && y >= el.Y2 - h - 5 && y <= Y44 + 5) || (x >= el.X2 - w - 5 && x <= X44 + 5 && y >= Y44 - h - 5 && y <= el.Y2 + 5))
                    return false;
            }
            return true;
        }


        public bool checkFigure(int x, int y)
        {
            foreach (var el in figures)
            {
                if (x >= el.Xpos  && x <= el.Xpos + el.width  && y >= el.Ypos && y <= el.Ypos + el.height)
                {
                    xCheck = el.Xpos;
                    yCheck = el.Ypos;
                    wCheck = el.width;
                    hCheck = el.height;

                    return true;
                }
            }
            return false;
        }

        public Figure returnFigure(int x, int y)
        {
            foreach (var el in figures)
            {
                if (x >= el.Xpos && x <= el.Xpos + el.width && y >= el.Ypos && y <= el.Ypos + el.height)
                {
                    xCheck = el.Xpos;
                    yCheck = el.Ypos;
                    wCheck = el.width;
                    hCheck = el.height;

                    return el;
                }
            }
            return null;
        }

        public bool checkLine(int x, int y)
        {
            foreach(var el in lines)
            {
                if (bmp.GetPixel(x, y) == lineColor && ((x < el.X1 && x > el.X2) || (x > el.X1 && x < el.X2)) && ((y < el.Y1 && y > el.Y2) || (y > el.Y1 && y < el.Y2)))
                {
                    if (el.X1 < el.X2)
                    {
                        xCheck = el.X1;
                        wCheck = el.X2;
                        yCheck = el.Y1;
                        hCheck = el.Y2;
                    }
                    else
                    {
                        xCheck = el.X2;
                        wCheck = el.X1;
                        yCheck = el.Y2;
                        hCheck = el.Y1;
                    }
                    return true;
                }
            }
            return false;
        }
    }
}
