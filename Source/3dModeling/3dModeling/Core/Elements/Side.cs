//-----------------------------------------------------------------------
// <copyright file="Side.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Elements
{
    using System.Collections.Generic;

    /// <summary>
    /// Reprsents a side of a shape.
    /// </summary>
    public class Side
    {
        #region Constructors
        public Side()
        {
            Edges = new List<Edge>();
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets collection of edges surrounding the side.
        /// </summary>
        public List<Edge> Edges { get; set; }

        /// <summary>
        /// Gets collection of vertexes of current side.
        /// </summary>
        public List<Point3D> Vertexes
        {
            get
            {
                var vertexes = new List<Point3D>();

                foreach (var edge in Edges)
                {
                    var isV1InCollection = false;

                    foreach (var vertex in vertexes)
                    {
                        if (vertex.CompareTo(edge.Vertex1) != 0) continue;
                        isV1InCollection = true;
                        break;
                    }

                    if (!isV1InCollection)
                        vertexes.Add(edge.Vertex1);

                    var isV2InCollection = false;

                    foreach (var vertex in vertexes)
                    {
                        if (vertex.CompareTo(edge.Vertex2) != 0) continue;
                        isV2InCollection = true;
                        break;
                    }

                    if (!isV2InCollection)
                        vertexes.Add(edge.Vertex2);
                }

                return vertexes;
            }
        }

        public float Depth
        {
            get
            {
                var verteces = Vertexes;
                float cumulativeDepth = 0;

                foreach (var vertex in verteces)
                {
                    cumulativeDepth += vertex.Z;
                }

                return cumulativeDepth/verteces.Count;
            }
        }
        #endregion
    }
}