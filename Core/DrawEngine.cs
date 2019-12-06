using SocialModelRebuild.Models;
using System.Drawing;



namespace SocialModelRebuild.Core
{
    public class DrawEngine
    {
   

        public int betweenCell = 5;
        public int widthCell = 15;
        public int scale = 1;
        public int mainFieldShiftX = 10, mainFieldShiftY = 10;
		public Point currentCellPoint;

		public Cell currentCell;

        SolidBrush brush_lastik;

        SolidBrush b = new SolidBrush(Color.Blue);
        SolidBrush r = new SolidBrush(Color.Red);
        SolidBrush brush_cur = new SolidBrush(Color.Green);
        Pen lines_pen = new Pen(Color.Black);

        Pen b_pen = new Pen(Color.Blue);
        Pen r_pen = new Pen(Color.Red);
        Pen gray_pen = new Pen(Color.Gray);


        public Bitmap DrawCellField(CellModel cellModel, int width, int height)
        {
            if (width == 0 || height == 0 || cellModel == null) return null;
            /////// перед отрисовкой //////

            var myBitmap = new Bitmap(width, height);
            var gr = Graphics.FromImage(myBitmap);

            brush_lastik = new SolidBrush(Color.White);
            gr.FillRectangle(brush_lastik, 0, 0, width, height);

            /////////////////////////////////

            cellModel.CellsPosition(widthCell, betweenCell, mainFieldShiftX, mainFieldShiftY);

            cellModel.CurrentCell = this.currentCell;
            ////////все клетки//////////////////
            foreach (var cell in cellModel.AllCells)
            {
                DrawCell(gr, widthCell, cell);
            }

            foreach(var smi in cellModel.AllSmiCells)
            {
                DrawSmi(gr, widthCell + 5, smi);
            }

            return myBitmap;
        }

        public void DrawCell(Graphics gr, int cellWidth, Cell cell)
        {
            var s = cell;
            SolidBrush r = new SolidBrush(Color.Red);
            SolidBrush b = new SolidBrush(Color.Blue);
            SolidBrush w = new SolidBrush(Color.White);
            SolidBrush gray = new SolidBrush(Color.Black);
			SolidBrush green = new SolidBrush(Color.Green);

            Pen contur = new Pen(Color.Black, 0.1f);

            if (currentCellPoint != null && currentCellPoint.X != -1 &&
                s.x < currentCellPoint.X && s.x + widthCell > currentCellPoint.X &&
                s.y < currentCellPoint.Y && s.y + widthCell > currentCellPoint.Y)
            {
                this.currentCell = cell;
                currentCellPoint = new Point(-1, -1);
            }
            if (currentCell != null && currentCell.x == cell.x && currentCell.y == cell.y)
			{
				gr.FillRectangle(green, s.x - betweenCell / 2, s.y - betweenCell / 2, cellWidth + betweenCell, cellWidth + betweenCell);
			}

			if (s.d == 1) gr.FillRectangle(r, s.x, s.y, cellWidth, cellWidth);
            if (s.d == -1) gr.FillRectangle(b, s.x, s.y, cellWidth, cellWidth);
            if (s.d == 0) gr.FillRectangle(w, s.x, s.y, cellWidth, cellWidth);
            if (s.d == 2) gr.FillRectangle(gray, s.x, s.y, cellWidth, cellWidth);

            gr.DrawRectangle(contur, s.x, s.y, cellWidth, cellWidth);
        }

        public void DrawSmi(Graphics gr, int cellWidth, SmiCell cell)
        {
            var s = cell;
            SolidBrush r = new SolidBrush(Color.Red);
            SolidBrush b = new SolidBrush(Color.Blue);
            SolidBrush w = new SolidBrush(Color.White);
            SolidBrush gray = new SolidBrush(Color.Black);
            SolidBrush green = new SolidBrush(Color.Green);

            Pen contur = new Pen(Color.Black, 0.1f);

            if (currentCellPoint != null && currentCellPoint.X != -1 &&
                s.x < currentCellPoint.X && s.x + widthCell > currentCellPoint.X &&
                s.y < currentCellPoint.Y && s.y + widthCell > currentCellPoint.Y)
            {
                this.currentCell = cell;
                currentCellPoint = new Point(-1, -1);
            }
            if (currentCell != null && currentCell.x == cell.x && currentCell.y == cell.y)
            {
                gr.FillRectangle(green, s.x - betweenCell / 2, s.y - betweenCell / 2, cellWidth + betweenCell, cellWidth + betweenCell);
            }

            if (s.d == 1) gr.FillEllipse(r, s.x, s.y, cellWidth, cellWidth);
            if (s.d == -1) gr.FillEllipse(b, s.x, s.y, cellWidth, cellWidth);
            //if (s.d == 0) gr.FillRectangle(w, s.x, s.y, cellWidth, cellWidth);
            //if (s.d == 2) gr.FillRectangle(gray, s.x, s.y, cellWidth, cellWidth);

            gr.DrawEllipse(contur, s.x, s.y, cellWidth, cellWidth);
        }

        public void IncrementCellWidth(int cellWidth, int betweenCell)
		{
			this.betweenCell += betweenCell;
			this.widthCell += cellWidth;

			if (this.betweenCell < 1) betweenCell = 1;
			if (this.betweenCell > 10) betweenCell = 10;

			if (this.widthCell < 1) this.widthCell = 1;
			if (this.widthCell > 100) this.widthCell = 100;

		}

		public void onFieldClick(int x, int y)
		{
			this.currentCellPoint = new Point(x, y);
		}
	}
}
