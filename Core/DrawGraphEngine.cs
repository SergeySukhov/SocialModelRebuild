using SocialModelRebuild.Models;
using System.Drawing;


namespace SocialModelRebuild.Core
{
    public class DrawGraphEngine
    {
        public GraphEngineSetup Setup = new GraphEngineSetup();

        SolidBrush brush_lastik;

        SolidBrush b = new SolidBrush(Color.Blue);
        SolidBrush r = new SolidBrush(Color.Red);
        SolidBrush brush_cur = new SolidBrush(Color.Green);
        Pen lines_pen = new Pen(Color.Black);
        Pen red = new Pen(Color.Red);
        Pen blue = new Pen(Color.Blue);
        Pen grey = new Pen(Color.DarkGray);
        Pen yellow = new Pen(Color.Yellow);

        Point prevPointRed, prevPointBlue, prevPointWhite, prevPointGrey;

        public Bitmap DrawCellModelGraph(CellModel cellModel, int width, int height)
        {
            int stepLength = (int)(8 * Setup.Scale);

            var myBitmap = new Bitmap(width, height);
            var gr = Graphics.FromImage(myBitmap);

            brush_lastik = new SolidBrush(Color.White);
            gr.FillRectangle(brush_lastik, 0, 0, width, height);

			int shiftedHeigth = (int)((height - 60)*Setup.Scale);
			int shiftedWidth = (int)((width - 60)*Setup.Scale);
            
			gr.DrawString("100", new Font(FontFamily.GenericSansSerif, 14), b, Setup.MainFieldShiftX, Setup.MainFieldShiftY);

            gr.DrawString("50", new Font(FontFamily.GenericSansSerif, 14), b, Setup.MainFieldShiftX, Setup.MainFieldShiftY + (shiftedHeigth) * 0.5f);
            gr.DrawLine(lines_pen, new Point(Setup.MainFieldShiftX + 40, (int)(Setup.MainFieldShiftY + shiftedHeigth * 0.5f)), 
                new Point(Setup.MainFieldShiftX + shiftedWidth + 40 + 100000, (int)( Setup.MainFieldShiftY + shiftedHeigth * 0.5f)));

            gr.DrawString("25", new Font(FontFamily.GenericSansSerif, 14), b, Setup.MainFieldShiftX, Setup.MainFieldShiftY + shiftedHeigth * 0.75f);
			gr.DrawLine(lines_pen, new Point(Setup.MainFieldShiftX + 40, (int)(Setup.MainFieldShiftY + shiftedHeigth * 0.75f)), 
                new Point(Setup.MainFieldShiftX + shiftedWidth + 40 + 100000, (int)(Setup.MainFieldShiftY + shiftedHeigth * 0.75f)));

            gr.DrawString("0", new Font(FontFamily.GenericSansSerif, 14), b, Setup.MainFieldShiftX, Setup.MainFieldShiftY + shiftedHeigth);

			gr.DrawLine(lines_pen, new Point(Setup.MainFieldShiftX + 40, Setup.MainFieldShiftY + shiftedHeigth), new Point(Setup.MainFieldShiftX + shiftedWidth + 40 + 100000, Setup.MainFieldShiftY + shiftedHeigth));
			gr.DrawLine(lines_pen, new Point(Setup.MainFieldShiftX + 40, Setup.MainFieldShiftY + shiftedHeigth), new Point(Setup.MainFieldShiftX + 40, Setup.MainFieldShiftY));

            for (int i = 0; i < cellModel.cellModelHistory.Count; i++)
            {
                if (i > 0)
                {
                    gr.DrawLine(lines_pen, Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth - 5, Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth + 5);

                    if (i % 10 == 0)
                    {
                        gr.DrawString(i.ToString(), new Font(FontFamily.GenericSansSerif, 14), b, Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth + stepLength);
                        gr.DrawLine(lines_pen, Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth - 5, Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth + 15);

                    }
                }

                if (Setup.DrawRed)
                {
                    var point = new Point(Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth - (int)(shiftedHeigth * cellModel.cellModelHistory[i].RedPercent));

                    gr.DrawEllipse(red, point.X - Setup.PointRad, point.Y - Setup.PointRad, Setup.PointRad * 2, Setup.PointRad * 2);

                    if (i > 0 && prevPointRed != null)
                    {
                        gr.DrawLine(red, prevPointRed, point);
                    }
                    prevPointRed = point;
                }
                if (Setup.DrawBlue)
                {
                    var point = new Point(Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth - (int)(shiftedHeigth * cellModel.cellModelHistory[i].BluePercent));

                    gr.DrawEllipse(blue, point.X - Setup.PointRad, point.Y - Setup.PointRad, Setup.PointRad * 2, Setup.PointRad * 2);

                    if (i > 0 && prevPointBlue != null)
                    {
                        gr.DrawLine(blue, prevPointBlue, point);
                    }
                    prevPointBlue = point;
                }
                if (Setup.DrawWhite)
                {
                    var point = new Point(Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth - (int)(shiftedHeigth * cellModel.cellModelHistory[i].WhitePercent));

                    gr.DrawEllipse(yellow, point.X - Setup.PointRad, point.Y - Setup.PointRad, Setup.PointRad * 2, Setup.PointRad * 2);

                    if (i > 0 && prevPointWhite != null)
                    {
                        gr.DrawLine(yellow, prevPointWhite, point);
                    }
                    prevPointWhite = point;
                }
                if (Setup.DrawGrey)
                {
                    var point = new Point(Setup.MainFieldShiftX + 40 + i * stepLength, Setup.MainFieldShiftY + shiftedHeigth - (int)(shiftedHeigth * cellModel.cellModelHistory[i].GreyPercent));

                    gr.DrawEllipse(grey, point.X - Setup.PointRad, point.Y - Setup.PointRad, Setup.PointRad * 2, Setup.PointRad * 2);

                    if (i > 0 && prevPointGrey != null)
                    {
                        gr.DrawLine(grey, prevPointGrey, point);
                    }
                    prevPointGrey = point;
                }

            }

			return myBitmap; 
        }
    }

    public class GraphEngineSetup
    {
        public int MainFieldShiftX = 40, MainFieldShiftY = 50;
        public double Scale = 1;
        public int PointRad = 3;

        public bool DrawRed = true, DrawBlue = true, DrawWhite = true, DrawGrey = true;
    }
}
