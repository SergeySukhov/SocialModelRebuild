namespace SocialModelRebuild
{
    partial class FormMain
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.buttonStart = new System.Windows.Forms.Button();
            this.buttonFirstIter = new System.Windows.Forms.Button();
            this.buttonGraph = new System.Windows.Forms.Button();
            this.timerIteration = new System.Windows.Forms.Timer(this.components);
            this.buttonExit = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.buttonReset = new System.Windows.Forms.Button();
            this.textBoxInfo = new System.Windows.Forms.TextBox();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonAddSmi = new System.Windows.Forms.Button();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.textBox2 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonToIteration = new System.Windows.Forms.Button();
            this.textBoxIteration = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(13, 14);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(713, 591);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timerDraw
            // 
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // buttonStart
            // 
            this.buttonStart.Location = new System.Drawing.Point(3, 2);
            this.buttonStart.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonStart.Name = "buttonStart";
            this.buttonStart.Size = new System.Drawing.Size(101, 46);
            this.buttonStart.TabIndex = 1;
            this.buttonStart.Text = "Старт";
            this.buttonStart.UseVisualStyleBackColor = true;
            this.buttonStart.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // buttonFirstIter
            // 
            this.buttonFirstIter.Location = new System.Drawing.Point(229, 2);
            this.buttonFirstIter.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonFirstIter.Name = "buttonFirstIter";
            this.buttonFirstIter.Size = new System.Drawing.Size(101, 46);
            this.buttonFirstIter.TabIndex = 2;
            this.buttonFirstIter.Text = "Первая итерация";
            this.buttonFirstIter.UseVisualStyleBackColor = true;
            // 
            // buttonGraph
            // 
            this.buttonGraph.Location = new System.Drawing.Point(336, 2);
            this.buttonGraph.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonGraph.Name = "buttonGraph";
            this.buttonGraph.Size = new System.Drawing.Size(101, 46);
            this.buttonGraph.TabIndex = 3;
            this.buttonGraph.Text = "График";
            this.buttonGraph.UseVisualStyleBackColor = true;
            this.buttonGraph.Click += new System.EventHandler(this.buttonGraph_Click);
            // 
            // timerIteration
            // 
            this.timerIteration.Interval = 200;
            this.timerIteration.Tick += new System.EventHandler(this.timerIteration_Tick);
            // 
            // buttonExit
            // 
            this.buttonExit.Location = new System.Drawing.Point(929, 2);
            this.buttonExit.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonExit.Name = "buttonExit";
            this.buttonExit.Size = new System.Drawing.Size(101, 46);
            this.buttonExit.TabIndex = 4;
            this.buttonExit.Text = "Выход";
            this.buttonExit.UseVisualStyleBackColor = true;
            this.buttonExit.Click += new System.EventHandler(this.buttonExit_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.buttonReset);
            this.panel1.Controls.Add(this.buttonStart);
            this.panel1.Controls.Add(this.buttonExit);
            this.panel1.Controls.Add(this.buttonFirstIter);
            this.panel1.Controls.Add(this.buttonGraph);
            this.panel1.Location = new System.Drawing.Point(13, 610);
            this.panel1.Margin = new System.Windows.Forms.Padding(4);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1033, 50);
            this.panel1.TabIndex = 5;
            // 
            // buttonReset
            // 
            this.buttonReset.Location = new System.Drawing.Point(123, 2);
            this.buttonReset.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.buttonReset.Name = "buttonReset";
            this.buttonReset.Size = new System.Drawing.Size(101, 46);
            this.buttonReset.TabIndex = 5;
            this.buttonReset.Text = "Сброс";
            this.buttonReset.UseVisualStyleBackColor = true;
            this.buttonReset.Click += new System.EventHandler(this.buttonReset_Click);
            // 
            // textBoxInfo
            // 
            this.textBoxInfo.Font = new System.Drawing.Font("Microsoft Sans Serif", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(204)));
            this.textBoxInfo.Location = new System.Drawing.Point(732, 14);
            this.textBoxInfo.Multiline = true;
            this.textBoxInfo.Name = "textBoxInfo";
            this.textBoxInfo.ReadOnly = true;
            this.textBoxInfo.Size = new System.Drawing.Size(374, 238);
            this.textBoxInfo.TabIndex = 8;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonAddSmi);
            this.panel2.Controls.Add(this.label2);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.textBox2);
            this.panel2.Controls.Add(this.textBox1);
            this.panel2.Location = new System.Drawing.Point(733, 259);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(373, 114);
            this.panel2.TabIndex = 9;
            // 
            // buttonAddSmi
            // 
            this.buttonAddSmi.Location = new System.Drawing.Point(35, 69);
            this.buttonAddSmi.Name = "buttonAddSmi";
            this.buttonAddSmi.Size = new System.Drawing.Size(299, 42);
            this.buttonAddSmi.TabIndex = 0;
            this.buttonAddSmi.Text = "Добавить СМИ";
            this.buttonAddSmi.UseVisualStyleBackColor = true;
            this.buttonAddSmi.Click += new System.EventHandler(this.buttonAddSmi_Click);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(4, 4);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(109, 22);
            this.textBox1.TabIndex = 0;
            // 
            // textBox2
            // 
            this.textBox2.Location = new System.Drawing.Point(4, 32);
            this.textBox2.Name = "textBox2";
            this.textBox2.Size = new System.Drawing.Size(109, 22);
            this.textBox2.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(120, 4);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(141, 17);
            this.label1.TabIndex = 3;
            this.label1.Text = "Исходящее влияние";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(120, 35);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(55, 17);
            this.label2.TabIndex = 4;
            this.label2.Text = "Радиус";
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonToIteration);
            this.panel3.Controls.Add(this.label4);
            this.panel3.Controls.Add(this.textBoxIteration);
            this.panel3.Location = new System.Drawing.Point(733, 379);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(373, 83);
            this.panel3.TabIndex = 10;
            // 
            // buttonToIteration
            // 
            this.buttonToIteration.Location = new System.Drawing.Point(35, 32);
            this.buttonToIteration.Name = "buttonToIteration";
            this.buttonToIteration.Size = new System.Drawing.Size(299, 42);
            this.buttonToIteration.TabIndex = 0;
            this.buttonToIteration.Text = "Перейти к итреации";
            this.buttonToIteration.UseVisualStyleBackColor = true;
            this.buttonToIteration.Click += new System.EventHandler(this.buttonToIteration_Click);
            // 
            // textBoxIteration
            // 
            this.textBoxIteration.Location = new System.Drawing.Point(4, 3);
            this.textBoxIteration.Name = "textBoxIteration";
            this.textBoxIteration.Size = new System.Drawing.Size(109, 22);
            this.textBoxIteration.TabIndex = 0;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(120, 4);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(73, 17);
            this.label4.TabIndex = 3;
            this.label4.Text = "Итерация";
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1118, 665);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.textBoxInfo);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormMain";
            this.Text = "Form1";
            this.MouseDown += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseDown);
            this.MouseMove += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseMove);
            this.MouseUp += new System.Windows.Forms.MouseEventHandler(this.FormMain_MouseUp);
            this.Resize += new System.EventHandler(this.FormMain_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.Button buttonStart;
        private System.Windows.Forms.Button buttonFirstIter;
        private System.Windows.Forms.Button buttonGraph;
		private System.Windows.Forms.Timer timerIteration;
		private System.Windows.Forms.Button buttonExit;
		private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Button buttonReset;
        private System.Windows.Forms.TextBox textBoxInfo;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonAddSmi;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox textBox2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonToIteration;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textBoxIteration;
    }
}

