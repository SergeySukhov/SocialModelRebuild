using SocialModelRebuild.Core;
using SocialModelRebuild.Models;
using System;
using System.Drawing;

using System.Windows.Forms;

namespace SocialModelRebuild
{
    public partial class FormGraph : Form
    {
        DrawGraphEngine drawGraphEngine;
        CellModel cellModel;


        bool isRightMouseDown = false;
        Point mouseDownPoint;
        Point currentShiftPoint = new Point(0, 0);

        public FormGraph(CellModel cellModel)
        {
            InitializeComponent();
            this.drawGraphEngine = new DrawGraphEngine();
            this.cellModel = cellModel;
            this.MouseWheel += new MouseEventHandler(FormGraph_MouseWheel);

            this.checkBoxRed.Checked = this.drawGraphEngine.Setup.DrawRed;
            this.checkBoxBlue.Checked = this.drawGraphEngine.Setup.DrawBlue;
            this.checkBoxWhite.Checked = this.drawGraphEngine.Setup.DrawWhite;
            this.checkBoxGrey.Checked = this.drawGraphEngine.Setup.DrawGrey;

            this.checkBoxRed.CheckedChanged += (object sender, EventArgs e) => { this.drawGraphEngine.Setup.DrawRed = this.checkBoxRed.Checked; };
            this.checkBoxBlue.CheckedChanged += (object sender, EventArgs e) => { this.drawGraphEngine.Setup.DrawBlue = this.checkBoxBlue.Checked; };
            this.checkBoxWhite.CheckedChanged += (object sender, EventArgs e) => { this.drawGraphEngine.Setup.DrawWhite = this.checkBoxWhite.Checked; };
            this.checkBoxGrey.CheckedChanged += (object sender, EventArgs e) => { this.drawGraphEngine.Setup.DrawGrey = this.checkBoxGrey.Checked; };

            this.pictureBox1.Location = new Point(0, 0);
            this.pictureBox1.Width = this.Width;
            this.pictureBox1.Height =  this.Height - 120;

            this.panel1.Height = 100;
            this.panel1.Location = new Point(0, this.Height - 110);
            
        }

        public void SetNewCellModel(CellModel cellModel)
        {
            this.cellModel = cellModel;
        }

        private void timerDraw_Tick(object sender, EventArgs e)
        {
            this.pictureBox1.Image = this.drawGraphEngine.DrawCellModelGraph(this.cellModel, this.pictureBox1.Width, this.pictureBox1.Height);
        }

        private void FormGraph_Resize(object sender, EventArgs e)
        {
            this.pictureBox1.Width = this.Width;
            this.pictureBox1.Height = this.Height - 120;
            this.panel1.Location = new Point(0, this.Height - 110);
        }


        private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRightMouseDown = false;
                currentShiftPoint = new Point(currentShiftPoint.X + e.X - mouseDownPoint.X, currentShiftPoint.Y + e.Y - mouseDownPoint.Y);
            }
        }

        private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                isRightMouseDown = true;
                mouseDownPoint = new Point(e.X, e.Y);
            }

        }

        private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
        {
            if (isRightMouseDown)
            {
                this.drawGraphEngine.Setup.MainFieldShiftX = currentShiftPoint.X + e.X - mouseDownPoint.X;
                this.drawGraphEngine.Setup.MainFieldShiftY = currentShiftPoint.Y + e.Y - mouseDownPoint.Y;
            }
        }

        private void FormGraph_MouseWheel(object sender, MouseEventArgs e)
        {

            this.drawGraphEngine.Setup.Scale += Math.Sign(e.Delta) * 0.1;
            if (this.drawGraphEngine.Setup.Scale < 0.1) this.drawGraphEngine.Setup.Scale = 0.1;
        }

    }
}
