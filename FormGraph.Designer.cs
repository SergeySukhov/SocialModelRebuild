namespace SocialModelRebuild
{
    partial class FormGraph
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
            this.components = new System.ComponentModel.Container();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.timerDraw = new System.Windows.Forms.Timer(this.components);
            this.checkBoxRed = new System.Windows.Forms.CheckBox();
            this.checkBoxBlue = new System.Windows.Forms.CheckBox();
            this.checkBoxWhite = new System.Windows.Forms.CheckBox();
            this.checkBoxGrey = new System.Windows.Forms.CheckBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(12, 11);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(1004, 502);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseDown += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseDown);
            this.pictureBox1.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseMove);
            this.pictureBox1.MouseUp += new System.Windows.Forms.MouseEventHandler(this.pictureBox1_MouseUp);
            // 
            // timerDraw
            // 
            this.timerDraw.Enabled = true;
            this.timerDraw.Tick += new System.EventHandler(this.timerDraw_Tick);
            // 
            // checkBoxRed
            // 
            this.checkBoxRed.AutoSize = true;
            this.checkBoxRed.Location = new System.Drawing.Point(13, 12);
            this.checkBoxRed.Name = "checkBoxRed";
            this.checkBoxRed.Size = new System.Drawing.Size(88, 21);
            this.checkBoxRed.TabIndex = 1;
            this.checkBoxRed.Text = "Красный";
            this.checkBoxRed.UseVisualStyleBackColor = true;
            // 
            // checkBoxBlue
            // 
            this.checkBoxBlue.AutoSize = true;
            this.checkBoxBlue.Location = new System.Drawing.Point(13, 39);
            this.checkBoxBlue.Name = "checkBoxBlue";
            this.checkBoxBlue.Size = new System.Drawing.Size(71, 21);
            this.checkBoxBlue.TabIndex = 2;
            this.checkBoxBlue.Text = "Синий";
            this.checkBoxBlue.UseVisualStyleBackColor = true;
            // 
            // checkBoxWhite
            // 
            this.checkBoxWhite.AutoSize = true;
            this.checkBoxWhite.Location = new System.Drawing.Point(13, 66);
            this.checkBoxWhite.Name = "checkBoxWhite";
            this.checkBoxWhite.Size = new System.Drawing.Size(73, 21);
            this.checkBoxWhite.TabIndex = 3;
            this.checkBoxWhite.Text = "Белый";
            this.checkBoxWhite.UseVisualStyleBackColor = true;
            // 
            // checkBoxGrey
            // 
            this.checkBoxGrey.AutoSize = true;
            this.checkBoxGrey.Location = new System.Drawing.Point(117, 11);
            this.checkBoxGrey.Name = "checkBoxGrey";
            this.checkBoxGrey.Size = new System.Drawing.Size(73, 21);
            this.checkBoxGrey.TabIndex = 4;
            this.checkBoxGrey.Text = "Серый";
            this.checkBoxGrey.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.checkBoxRed);
            this.panel1.Controls.Add(this.checkBoxGrey);
            this.panel1.Controls.Add(this.checkBoxBlue);
            this.panel1.Controls.Add(this.checkBoxWhite);
            this.panel1.Location = new System.Drawing.Point(12, 558);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(200, 100);
            this.panel1.TabIndex = 5;
            // 
            // FormGraph
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1033, 670);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pictureBox1);
            this.Margin = new System.Windows.Forms.Padding(3, 2, 3, 2);
            this.Name = "FormGraph";
            this.Text = "FormGraph";
            this.Resize += new System.EventHandler(this.FormGraph_Resize);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox pictureBox1;
		private System.Windows.Forms.Timer timerDraw;
        private System.Windows.Forms.CheckBox checkBoxRed;
        private System.Windows.Forms.CheckBox checkBoxBlue;
        private System.Windows.Forms.CheckBox checkBoxWhite;
        private System.Windows.Forms.CheckBox checkBoxGrey;
        private System.Windows.Forms.Panel panel1;
    }
}