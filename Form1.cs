using SocialModelRebuild.Core;
using SocialModelRebuild.Libraries;
using SocialModelRebuild.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SocialModelRebuild
{
	public partial class FormMain : Form
	{
		DrawEngine drawEngine;

		CellModel cellModel;

		bool isRightMouseDown = false;
		bool isResizeMouseDownX = false;
		bool isResizeMouseDownY = false;

		Point mouseDownPoint;
		Point mouseDownResizePoint;

		public FormMain()
		{
			InitializeComponent();

			drawEngine = new DrawEngine();
			cellModel = CellModelLibrary.CreateCalssicModel(40);

			LocateElems();

			this.MouseWheel += new MouseEventHandler(Form1_MouseWheel);

			timerDraw.Enabled = true;


		}

		public void setupCellModel(CellModel cellModel)
		{
			this.cellModel = cellModel;
		}

		private void timerDraw_Tick(object sender, EventArgs e)
		{
			this.pictureBox1.Image = drawEngine.DrawCellField(cellModel, pictureBox1.Width, pictureBox1.Height);
		}

		private void LocateElems()
		{
			this.pictureBox1.Width = this.Width - 410;
			this.pictureBox1.Height = this.Height - 110;
			this.pictureBox1.Location = new Point(5, 5);

			this.panel1.Location = new Point(5, this.Height - 105);
            this.textBoxInfo.Location = new Point(this.pictureBox1.Width + 10, 5);
            this.textBoxInfo.Width = this.Width - this.pictureBox1.Width - 40;

            this.panel2.Location = new Point(textBoxInfo.Location.X, textBoxInfo.Location.Y + textBoxInfo.Height + 5);
            this.panel3.Location = new Point(textBoxInfo.Location.X, panel2.Location.Y + panel2.Height + 5);
		}

		private void FormMain_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.X - pictureBox1.Width > 0 && e.X - pictureBox1.Width < 25)
			{
				isResizeMouseDownX = true;
				mouseDownResizePoint.X = e.X;
			}
			if (e.Y - pictureBox1.Height > 0 && e.Y - pictureBox1.Height < 25)
			{
				isResizeMouseDownY = true;
				mouseDownResizePoint.Y = e.Y;
			}

		}

		private void FormMain_MouseUp(object sender, MouseEventArgs e)
		{
			isResizeMouseDownX = false;
			isResizeMouseDownY = false;
		}

		private void FormMain_MouseMove(object sender, MouseEventArgs e)
		{
			if (isResizeMouseDownX)
			{
				this.pictureBox1.Width += e.X - mouseDownResizePoint.X;
				if (this.pictureBox1.Width < 5) this.pictureBox1.Width = 5;

				mouseDownResizePoint.X = e.X;
			}

			if (isResizeMouseDownY)
			{
				this.pictureBox1.Height += e.Y - mouseDownResizePoint.Y;
				if (this.pictureBox1.Height < 5) this.pictureBox1.Height = 5;
				mouseDownResizePoint.Y = e.Y;
			}
		}

		private void pictureBox1_MouseDown(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				isRightMouseDown = true;
				mouseDownPoint = new Point(e.X, e.Y);
			}
			else
			{

			}
		}

		private void pictureBox1_MouseUp(object sender, MouseEventArgs e)
		{
			if (e.Button == MouseButtons.Right)
			{
				isRightMouseDown = false;
			}
			else
			{
				this.drawEngine.onFieldClick(e.X, e.Y);
			}
		}

		private void pictureBox1_MouseMove(object sender, MouseEventArgs e)
		{
			if (isRightMouseDown)
			{
				this.drawEngine.mainFieldShiftX = e.X - mouseDownPoint.X;
				this.drawEngine.mainFieldShiftY = e.Y - mouseDownPoint.Y;
			}

		}

		private void Form1_MouseWheel(object sender, MouseEventArgs e)
		{
			this.drawEngine.IncrementCellWidth(Math.Sign(e.Delta) * 1, 0);
		}

		private void timerIteration_Tick(object sender, EventArgs e)
		{
			this.cellModel.IterationTick();

            this.textBoxInfo.Text = cellModel.GetModelInfo();
		}

		private void buttonExit_Click(object sender, EventArgs e)
		{
			this.Close();
		}

		private void buttonStart_Click(object sender, EventArgs e)
		{
			this.timerIteration.Enabled = !this.timerIteration.Enabled;
			this.buttonStart.Text = this.timerIteration.Enabled ? "Стоп" : "Старт";
		}

		private void buttonReset_Click(object sender, EventArgs e)
		{
			cellModel = CellModelLibrary.CreateCalssicModel(this.cellModel.N); // !!
		}

		private void FormMain_Resize(object sender, EventArgs e)
		{
			LocateElems();
		}

        private void buttonGraph_Click(object sender, EventArgs e)
        {
            var formGraph = new FormGraph(this.cellModel);

            formGraph.Show();
        }

        private void buttonAddSmi_Click(object sender, EventArgs e)
        {
            if (this.cellModel.CurrentCell == null) return;

            int smiInfluence = 0, smiRadius = 2;
            int.TryParse(textBox1.Text, out smiInfluence);
            int.TryParse(textBox2.Text, out smiRadius);

            var smiCell = new SmiCell(this.cellModel.CurrentCell.id);
            smiCell.M = smiRadius;
            smiCell.K = Math.Abs(smiInfluence);
            smiCell.d = 1 * Math.Sign(smiInfluence);
            smiCell.U = smiCell.d * 100;
            smiCell.x = cellModel.CurrentCell.x + 10;
            smiCell.y = cellModel.CurrentCell.y + 10;
            cellModel.AllSmiCells.Add(smiCell);
            CellFrinedsFindingLibrary.AddSmi(smiCell, this.cellModel);

        }

        private void buttonToIteration_Click(object sender, EventArgs e)
        {
            if (textBoxIteration.Text == "") return;

            this.timerIteration.Stop();
            this.timerDraw.Stop();

            int iteration = 0;
            int.TryParse(textBoxIteration.Text, out iteration);

			cellModel = CellModelLibrary.CreateCalssicModel(this.cellModel.N); // !!

            for(int i = 0; i < iteration; i++)
            {
                cellModel.IterationTick();               
            }
            this.timerDraw.Start();
            this.timerIteration.Stop();

        }
    }
}
