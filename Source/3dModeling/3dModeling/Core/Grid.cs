using System.Drawing;
using System.Drawing.Drawing2D;

namespace Modeling.Core
{
    public class Grid
    {
        /// <summary>
        /// Provides tools for grid displaying
        /// </summary>
        /// <param name="StartPoint">Sets left upper conner of grid.</param>
        /// <param name="step">Sets the distance between gridlines.</param>
        /// <param name="width">Specifies grids width</param>
        /// <param name="height">Specifies grids height</param>
        /// <param name="e">Specifies GDI+ drawing surface</param>
        public static void Draw(Point StartPoint, int step, int width, int height, Graphics e)
        {
            var GridPen = new Pen(Color.DarkGray);
            GridPen.DashStyle = DashStyle.Dash;
            var LeftPoint = new Point(0, 0);
            var RightPoint = new Point(0, 0);
            var UpPoint = new Point(0, 0);
            var DownPoint = new Point(0, 0);

            //int Limit = this.Width < this.Height ? this.Width : this.Height;
            var LimitX = width - 50;
            var LimitY = height - 50;

            LeftPoint.X = StartPoint.X;
            RightPoint.X = LimitX;
            UpPoint.Y = StartPoint.Y;
            DownPoint.Y = LimitY;

            for (var i = StartPoint.X; i <= LimitY; i += step)
            {
                LeftPoint.Y = i;
                RightPoint.Y = i;
                e.DrawLine(GridPen, LeftPoint, RightPoint);
            }

            for (var j = StartPoint.Y; j < LimitX; j += step)
            {
                UpPoint.X = j;
                DownPoint.X = j;
                e.DrawLine(GridPen, UpPoint, DownPoint);
            }
        }
    }
}


/// <summary>
/// Provides tools for grid displaying
/// </summary>
/// <param name="StartPoint">Sets left upper conner of grid.</param>
/// <param name="step">Sets the distance between gridlines.</param>
/// <param name="MarginRight">Sets the distance between grid and right border of window.</pparam>
/// <param name="MarginBottom">Sets the distance between grid and bottom of window.</param>
//private void Draw(Point StartPoint, int step, int MarginRight, int MarginBottom)
//{
//    Graphics e = CreateGraphics();

//    Pen GridPen = new Pen(Color.Black);
//    Point LeftPoint = new Point(0, 0);
//    Point RightPoint = new Point(0, 0);
//    Point UpPoint = new Point(0, 0);
//    Point DownPoint = new Point(0, 0);

//    //int Limit = this.Width < this.Height ? this.Width : this.Height;
//    int LimitX = this.Width - MarginRight;
//    int LimitY = this.Height - MarginBottom;

//    LeftPoint.X = StartPoint.X;
//    RightPoint.X = LimitX;
//    UpPoint.Y = StartPoint.Y;
//    DownPoint.Y = LimitY;

//    for (int i = StartPoint.Y; i <= LimitY; i += step)
//    {
//        LeftPoint.Y = i;
//        RightPoint.Y = i;
//        e.DrawLine(GridPen, LeftPoint, RightPoint);
//    }

//    for (int j = StartPoint.X; j < LimitX; j += step)
//    {
//        UpPoint.X = j;
//        DownPoint.X = j;
//        e.DrawLine(GridPen, UpPoint, DownPoint);
//    }


//    //e.Graphics.DrawString(var.ToString(),
//    //                            new Font("Times New Roman", 16),
//    //                            new SolidBrush(Color.Black), i, 590);
//    //e.Graphics.DrawString(var.ToString(),
//    //                         new Font("Times New Roman", 16),
//    //                         new SolidBrush(Color.Black), 0, 595 - i);
//    //var += 0.5;
//}