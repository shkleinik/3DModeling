using System.Drawing;

namespace Modeling.Core.Elements
{
    public class Point3D
    {
        #region Properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        #endregion

        #region Constructors
        private Point3D() { }

        public Point3D(float x, float y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Point3D(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Point3D(Point p)
        {
            X = p.X;
            Y = p.Y;
            Z = 0;
        }
        #endregion

        public static implicit operator PointF(Point3D point3D)
        {
            return new PointF(point3D.X, point3D.Y);
        }
    }
}