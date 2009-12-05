//-----------------------------------------------------------------------
// <copyright file="Polygon.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Elements
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Reprsents a side of a shape.
    /// </summary>
    public class Polygon
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Polygon"/> class. Use it to create new instances.
        /// </summary>
        public Polygon()
        {
            Edges = new List<Edge>();
            verteces = new List<Point3D>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets collection of edges surrounding the side.
        /// </summary>
        public List<Edge> Edges { get; set; }

        /// <summary>
        /// Gets collection of verteces of current side.
        /// </summary>
        public List<Point3D> Verteces
        {
            get
            {
                //if (verteces.Count == 3)
                //    return verteces;

                //foreach (var edge in Edges)
                //{
                //    var isV1InCollection = false;

                //    foreach (var vertex in verteces)
                //    {
                //        if (vertex.CompareTo(edge.Vertex1) != 0) continue;
                //        isV1InCollection = true;
                //        break;
                //    }

                //    if (!isV1InCollection)
                //        verteces.Add(edge.Vertex1);

                //    var isV2InCollection = false;

                //    foreach (var vertex in verteces)
                //    {
                //        if (vertex.CompareTo(edge.Vertex2) != 0) continue;
                //        isV2InCollection = true;
                //        break;
                //    }

                //    if (!isV2InCollection)
                //        verteces.Add(edge.Vertex2);
                //}

                return verteces;
            }

            set
            {
                verteces = value;
            }
        }

        public float Depth
        {
            get
            {
                var verteces = Verteces;
                float cumulativeDepth = 0;

                foreach (var vertex in verteces)
                {
                    cumulativeDepth += vertex.Z;
                }

                return cumulativeDepth / verteces.Count;
            }
        }

        public bool IsVisible
        {
            get
            {
                return isVisible();
            }
        }
        #endregion

        #region Fields
        private List<Point3D> verteces;
        #endregion

        #region Methods
        private bool isVisible()
        {
            if (Verteces.Count < 3)
                return false;

            var Vis = new Point3D(0, 0, 1000);

            var normal = GetNormal();
            var normalLength = GetNormalLength();
            double cosAngleBetweenNormalAndVisiblePoint;

            var visiblePointLength = Math.Sqrt(Math.Pow(Vis.X, 2) + Math.Pow(Vis.Y, 2) + Math.Pow(Vis.Z, 2));

            if (normalLength == 0 || visiblePointLength == 0)
                cosAngleBetweenNormalAndVisiblePoint = -1;
            else
            {
                cosAngleBetweenNormalAndVisiblePoint = (normal.X * Vis.X + normal.Y * Vis.Y + normal.Z * Vis.Z) / (normalLength * visiblePointLength);
            }
            return (cosAngleBetweenNormalAndVisiblePoint > 0);
        }

        private double GetNormalLength()
        {
            var norm = GetNormal();

            return Math.Sqrt(Math.Pow(norm.X, 2) + Math.Pow(norm.Y, 2) + Math.Pow(norm.Z, 2));
        }

        private Point3D GetNormal()
        {
            var VecA = new Point3D(Verteces[1].X - Verteces[0].X, Verteces[1].Y - Verteces[0].Y, Verteces[1].Z - Verteces[0].Z);
            var VecB = new Point3D(Verteces[2].X - Verteces[1].X, Verteces[2].Y - Verteces[1].Y, Verteces[2].Z - Verteces[1].Z);
            return new Point3D(VecA.Y * VecB.Z - VecA.Z * VecB.Y, VecA.X * VecB.Z - VecA.Z * VecB.X, VecA.X * VecB.Y - VecA.Y * VecB.X);
        }
        #endregion
    }
}