//-----------------------------------------------------------------------
// <copyright file="Point3D.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Elements
{
    using System;
    using System.Drawing;

    public class Point3D : IComparable
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

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (!(obj is Point3D))
                throw new ArgumentException("object is not a Point3D");


            var otherPoint = (Point3D)obj;

            return X.CompareTo(otherPoint.X) + Y.CompareTo(otherPoint.Y) + Z.CompareTo(otherPoint.Z);

        }

        #endregion
    }
}