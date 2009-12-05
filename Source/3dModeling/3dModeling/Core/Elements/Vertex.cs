//-----------------------------------------------------------------------
// <copyright file="Vertex.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Elements
{
    using System;
    using System.Drawing;

    public class Vertex : IComparable
    {
        #region Properties
        public float X { get; set; }
        public float Y { get; set; }
        public float Z { get; set; }
        #endregion

        #region Constructors
        private Vertex() { }

        public Vertex(float x, float y)
        {
            X = x;
            Y = y;
            Z = 0;
        }

        public Vertex(float x, float y, float z)
        {
            X = x;
            Y = y;
            Z = z;
        }

        public Vertex(Point p)
        {
            X = p.X;
            Y = p.Y;
            Z = 0;
        }
        #endregion

        public static implicit operator PointF(Vertex point3D)
        {
            return new PointF(point3D.X, point3D.Y);
        }

        #region IComparable Members

        public int CompareTo(object obj)
        {
            if (!(obj is Vertex))
                throw new ArgumentException("object is not a Point3D");


            var otherPoint = (Vertex)obj;

            return X.CompareTo(otherPoint.X) + Y.CompareTo(otherPoint.Y) + Z.CompareTo(otherPoint.Z);

        }

        #endregion
    }
}