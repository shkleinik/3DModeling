//-----------------------------------------------------------------------
// <copyright file="Polygon.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Elements
{
    using System.Collections.Generic;
    using L = Light;

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
            Verteces = new List<Vertex>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets collection of edges surrounding the side.
        /// </summary>
        public List<Edge> Edges
        {
            get
            {
                var edges = new List<Edge>
                            {
                                new Edge(Verteces[0], Verteces[1]),
                                new Edge(Verteces[1], Verteces[2]),
                                new Edge(Verteces[2], Verteces[0])
                            };

                return edges;
            }
        }

        /// <summary>
        /// Gets collection of verteces of current side.
        /// </summary>
        public List<Vertex> Verteces { get; set; }

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

        #endregion

        #region Methods
        private bool isVisible()
        {
            if (Verteces.Count < 3)
                return false;

            var pointOfView = new Vertex(0, 0, 1000);
            var normal = L.GetNormal(this);

            var cosAngleBetweenNormalAndPointOfView = L.GetAngleBetweenNormals(normal, pointOfView);

            return (cosAngleBetweenNormalAndPointOfView > 0);
        }
        #endregion
    }
}