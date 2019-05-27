namespace DataCenter
{
    partial class TaskGeneratorForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonOK = new System.Windows.Forms.Button();
            this.volumeBox = new System.Windows.Forms.TextBox();
            this.complexityBox = new System.Windows.Forms.TextBox();
            this.volumeMinBox = new System.Windows.Forms.TextBox();
            this.volumeMaxBox = new System.Windows.Forms.TextBox();
            this.complexityMinBox = new System.Windows.Forms.TextBox();
            this.complexityMaxBox = new System.Windows.Forms.TextBox();
            this.fixedValue = new System.Windows.Forms.RadioButton();
            this.randomValue = new System.Windows.Forms.RadioButton();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // buttonOK
            // 
            this.buttonOK.Location = new System.Drawing.Point(122, 281);
            this.buttonOK.Name = "buttonOK";
            this.buttonOK.Size = new System.Drawing.Size(129, 43);
            this.buttonOK.TabIndex = 1;
            this.buttonOK.Text = "OK";
            this.buttonOK.UseVisualStyleBackColor = true;
            this.buttonOK.Click += new System.EventHandler(this.buttonOK_Click);
            // 
            // volumeBox
            // 
            this.volumeBox.Enabled = false;
            this.volumeBox.Location = new System.Drawing.Point(18, 83);
            this.volumeBox.Name = "volumeBox";
            this.volumeBox.Size = new System.Drawing.Size(100, 22);
            this.volumeBox.TabIndex = 3;
            // 
            // complexityBox
            // 
            this.complexityBox.Enabled = false;
            this.complexityBox.Location = new System.Drawing.Point(18, 189);
            this.complexityBox.Name = "complexityBox";
            this.complexityBox.Size = new System.Drawing.Size(100, 22);
            this.complexityBox.TabIndex = 4;
            // 
            // volumeMinBox
            // 
            this.volumeMinBox.Enabled = false;
            this.volumeMinBox.Location = new System.Drawing.Point(208, 83);
            this.volumeMinBox.Name = "volumeMinBox";
            this.volumeMinBox.Size = new System.Drawing.Size(100, 22);
            this.volumeMinBox.TabIndex = 5;
            // 
            // volumeMaxBox
            // 
            this.volumeMaxBox.Enabled = false;
            this.volumeMaxBox.Location = new System.Drawing.Point(208, 123);
            this.volumeMaxBox.Name = "volumeMaxBox";
            this.volumeMaxBox.Size = new System.Drawing.Size(100, 22);
            this.volumeMaxBox.TabIndex = 6;
            // 
            // complexityMinBox
            // 
            this.complexityMinBox.Enabled = false;
            this.complexityMinBox.Location = new System.Drawing.Point(208, 189);
            this.complexityMinBox.Name = "complexityMinBox";
            this.complexityMinBox.Size = new System.Drawing.Size(100, 22);
            this.complexityMinBox.TabIndex = 7;
            // 
            // complexityMaxBox
            // 
            this.complexityMaxBox.Enabled = false;
            this.complexityMaxBox.Location = new System.Drawing.Point(208, 228);
            this.complexityMaxBox.Name = "complexityMaxBox";
            this.complexityMaxBox.Size = new System.Drawing.Size(100, 22);
            this.complexityMaxBox.TabIndex = 8;
            // 
            // fixedValue
            // 
            this.fixedValue.AutoSize = true;
            this.fixedValue.Location = new System.Drawing.Point(18, 12);
            this.fixedValue.Name = "fixedValue";
            this.fixedValue.Size = new System.Drawing.Size(160, 21);
            this.fixedValue.TabIndex = 9;
            this.fixedValue.TabStop = true;
            this.fixedValue.Text = "Фіксовані значення";
            this.fixedValue.UseVisualStyleBackColor = true;
            this.fixedValue.CheckedChanged += new System.EventHandler(this.fixedValue_CheckedChanged);
            // 
            // randomValue
            // 
            this.randomValue.AutoSize = true;
            this.randomValue.Location = new System.Drawing.Point(208, 12);
            this.randomValue.Name = "randomValue";
            this.randomValue.Size = new System.Drawing.Size(162, 21);
            this.randomValue.TabIndex = 10;
            this.randomValue.TabStop = true;
            this.randomValue.Text = "Випадкові значення";
            this.randomValue.UseVisualStyleBackColor = true;
            this.randomValue.CheckedChanged += new System.EventHandler(this.randomValue_CheckedChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(100, 17);
            this.label1.TabIndex = 11;
            this.label1.Text = "Об\'єм пам\'яті:";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 160);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(84, 17);
            this.label2.TabIndex = 12;
            this.label2.Text = "Складність:";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(311, 86);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(30, 17);
            this.label3.TabIndex = 13;
            this.label3.Text = "min";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(314, 192);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(30, 17);
            this.label4.TabIndex = 14;
            this.label4.Text = "min";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(311, 126);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(33, 17);
            this.label5.TabIndex = 15;
            this.label5.Text = "max";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(311, 231);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(33, 17);
            this.label6.TabIndex = 16;
            this.label6.Text = "max";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(205, 51);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(100, 17);
            this.label7.TabIndex = 17;
            this.label7.Text = "Об\'єм пам\'яті:";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(205, 160);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(84, 17);
            this.label8.TabIndex = 18;
            this.label8.Text = "Складність:";
            // 
            // TaskGeneratorForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(379, 336);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.randomValue);
            this.Controls.Add(this.fixedValue);
            this.Controls.Add(this.complexityMaxBox);
            this.Controls.Add(this.complexityMinBox);
            this.Controls.Add(this.volumeMaxBox);
            this.Controls.Add(this.volumeMinBox);
            this.Controls.Add(this.complexityBox);
            this.Controls.Add(this.volumeBox);
            this.Controls.Add(this.buttonOK);
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(397, 383);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(397, 383);
            this.Name = "TaskGeneratorForm";
            this.ShowIcon = false;
            this.Text = "Генератор задач";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.TaskGeneratorForm_FormClosing);
            this.Load += new System.EventHandler(this.TaskGeneratorForm_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonOK;
        private System.Windows.Forms.TextBox volumeBox;
        private System.Windows.Forms.TextBox complexityBox;
        private System.Windows.Forms.TextBox volumeMinBox;
        private System.Windows.Forms.TextBox volumeMaxBox;
        private System.Windows.Forms.TextBox complexityMinBox;
        private System.Windows.Forms.TextBox complexityMaxBox;
        private System.Windows.Forms.RadioButton fixedValue;
        private System.Windows.Forms.RadioButton randomValue;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}