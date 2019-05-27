namespace DataCenter
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripDropDownButton1 = new System.Windows.Forms.ToolStripDropDownButton();
            this.розміститиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.фізичнаМашинаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.генераторЗадачToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.маршрутизаторToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.зєднатиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.видалитиToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonPlay = new System.Windows.Forms.ToolStripButton();
            this.ButtonStop = new System.Windows.Forms.ToolStripButton();
            this.groundBox = new System.Windows.Forms.PictureBox();
            this.toolStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groundBox)).BeginInit();
            this.SuspendLayout();
            // 
            // toolStrip1
            // 
            this.toolStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripSeparator1,
            this.toolStripDropDownButton1,
            this.toolStripSeparator2,
            this.ButtonPlay,
            this.ButtonStop});
            this.toolStrip1.Location = new System.Drawing.Point(0, 0);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(731, 27);
            this.toolStrip1.TabIndex = 0;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 27);
            // 
            // toolStripDropDownButton1
            // 
            this.toolStripDropDownButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripDropDownButton1.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.розміститиToolStripMenuItem,
            this.зєднатиToolStripMenuItem,
            this.видалитиToolStripMenuItem});
            this.toolStripDropDownButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripDropDownButton1.Image")));
            this.toolStripDropDownButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripDropDownButton1.Name = "toolStripDropDownButton1";
            this.toolStripDropDownButton1.Size = new System.Drawing.Size(34, 24);
            this.toolStripDropDownButton1.Text = "Меню";
            // 
            // розміститиToolStripMenuItem
            // 
            this.розміститиToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.фізичнаМашинаToolStripMenuItem,
            this.генераторЗадачToolStripMenuItem,
            this.маршрутизаторToolStripMenuItem});
            this.розміститиToolStripMenuItem.Name = "розміститиToolStripMenuItem";
            this.розміститиToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.розміститиToolStripMenuItem.Text = "Розмістити";
            // 
            // фізичнаМашинаToolStripMenuItem
            // 
            this.фізичнаМашинаToolStripMenuItem.Name = "фізичнаМашинаToolStripMenuItem";
            this.фізичнаМашинаToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.фізичнаМашинаToolStripMenuItem.Text = "Фізична машина";
            this.фізичнаМашинаToolStripMenuItem.Click += new System.EventHandler(this.фізичнаМашинаToolStripMenuItem_Click);
            // 
            // генераторЗадачToolStripMenuItem
            // 
            this.генераторЗадачToolStripMenuItem.Name = "генераторЗадачToolStripMenuItem";
            this.генераторЗадачToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.генераторЗадачToolStripMenuItem.Text = "Генератор задач";
            this.генераторЗадачToolStripMenuItem.Click += new System.EventHandler(this.генераторЗадачToolStripMenuItem_Click);
            // 
            // маршрутизаторToolStripMenuItem
            // 
            this.маршрутизаторToolStripMenuItem.Name = "маршрутизаторToolStripMenuItem";
            this.маршрутизаторToolStripMenuItem.Size = new System.Drawing.Size(201, 26);
            this.маршрутизаторToolStripMenuItem.Text = "Маршрутизатор";
            this.маршрутизаторToolStripMenuItem.Click += new System.EventHandler(this.маршрутизаторToolStripMenuItem_Click);
            // 
            // зєднатиToolStripMenuItem
            // 
            this.зєднатиToolStripMenuItem.Name = "зєднатиToolStripMenuItem";
            this.зєднатиToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.зєднатиToolStripMenuItem.Text = "З\'єднати";
            this.зєднатиToolStripMenuItem.Click += new System.EventHandler(this.зєднатиToolStripMenuItem_Click);
            // 
            // видалитиToolStripMenuItem
            // 
            this.видалитиToolStripMenuItem.Name = "видалитиToolStripMenuItem";
            this.видалитиToolStripMenuItem.Size = new System.Drawing.Size(160, 26);
            this.видалитиToolStripMenuItem.Text = "Видалити";
            this.видалитиToolStripMenuItem.Click += new System.EventHandler(this.видалитиToolStripMenuItem_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 27);
            // 
            // ButtonPlay
            // 
            this.ButtonPlay.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonPlay.Image = ((System.Drawing.Image)(resources.GetObject("ButtonPlay.Image")));
            this.ButtonPlay.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonPlay.Name = "ButtonPlay";
            this.ButtonPlay.Size = new System.Drawing.Size(24, 24);
            this.ButtonPlay.Text = "Почати тест";
            this.ButtonPlay.Click += new System.EventHandler(this.ButtonPlay_Click);
            // 
            // ButtonStop
            // 
            this.ButtonStop.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ButtonStop.Image = ((System.Drawing.Image)(resources.GetObject("ButtonStop.Image")));
            this.ButtonStop.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonStop.Name = "ButtonStop";
            this.ButtonStop.Size = new System.Drawing.Size(24, 24);
            this.ButtonStop.Text = "Завершити тест";
            this.ButtonStop.Click += new System.EventHandler(this.ButtonStop_Click);
            // 
            // groundBox
            // 
            this.groundBox.BackColor = System.Drawing.Color.White;
            this.groundBox.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.groundBox.Cursor = System.Windows.Forms.Cursors.Default;
            this.groundBox.Location = new System.Drawing.Point(13, 47);
            this.groundBox.Name = "groundBox";
            this.groundBox.Size = new System.Drawing.Size(706, 441);
            this.groundBox.TabIndex = 1;
            this.groundBox.TabStop = false;
            this.groundBox.MouseDown += new System.Windows.Forms.MouseEventHandler(this.groundBox_MouseDown);
            this.groundBox.MouseMove += new System.Windows.Forms.MouseEventHandler(this.groundBox_MouseMove);
            this.groundBox.MouseUp += new System.Windows.Forms.MouseEventHandler(this.groundBox_MouseUp);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(731, 500);
            this.Controls.Add(this.groundBox);
            this.Controls.Add(this.toolStrip1);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(749, 547);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(749, 547);
            this.Name = "Form1";
            this.ShowIcon = false;
            this.Text = "DataCenter";
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.groundBox)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripDropDownButton toolStripDropDownButton1;
        private System.Windows.Forms.ToolStripMenuItem розміститиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem фізичнаМашинаToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem генераторЗадачToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem маршрутизаторToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem зєднатиToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem видалитиToolStripMenuItem;
        private System.Windows.Forms.ToolStripButton ButtonPlay;
        private System.Windows.Forms.ToolStripButton ButtonStop;
        public System.Windows.Forms.PictureBox groundBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
    }
}

