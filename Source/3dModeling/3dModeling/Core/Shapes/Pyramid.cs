//-----------------------------------------------------------------------
// <copyright file="Pyramid.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using System;
    using System.Collections.Generic;
    using Elements;

    /// <summary>
    /// Class for pyramid.
    /// </summary>
    public class Pyramid : BaseShape
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Pyramid"/> class. Use this class to create new instances.
        /// </summary>
        /// <param name="basePoint">Specifies the basepoint from what the pyramid will be built</param>
        /// <remarks>
        /// Center of the bottom circumscribing circle.
        /// </remarks>
        /// <param name="sidesNumber">Specifies number of puramids sides.</param>
        /// <param name="radius">Specifies radius of pyramids circumscribing circle.</param>
        /// <param name="height">Specifies pyramids height.</param>
        public Pyramid(Point3D basePoint, int sidesNumber, float radius, float height)
        {
            SidesNumber = sidesNumber;
            Radius = radius;
            Height = height;
            edges = new List<Edge>();

            var spikePoint = new Point3D(basePoint.X, basePoint.Y + Height, basePoint.Z);
            var angleStep = 2 * Math.PI / SidesNumber;
            double angle = 0;
            for (var i = 0; i < SidesNumber; i++)
            {
                angle += angleStep;

                var dx = Radius * (float)Math.Cos(angle);
                var dz = Radius * (float)Math.Sin(angle);

                // Edges, wich connect pyramids spike and its bottom
                var v = new Point3D(basePoint.X + dx, basePoint.Y, basePoint.Z + dz);
                var edgeInclinated = new Edge(v, spikePoint);
                edges.Add(edgeInclinated);

                // Bottom edges
                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                var nextVertex = new Point3D(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);

                var edgeBottom = new Edge(v, nextVertex);
                edges.Add(edgeBottom);
            }

            previousState = new List<Edge>(edges);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Pyramid"/> class. Parametless constructor is required for normal serialization.
        /// </summary>
        protected Pyramid()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets pyramids height(actualy only gets).
        /// </summary>
        public float Height { get; set; }

        /// <summary>
        /// Gets or sets radius of pyramids circumscribing circle(actualy only gets).
        /// </summary>
        public float Radius { get; set; }

        /// <summary>
        /// Gets or sets number of pyramid sides.
        /// </summary>
        public int SidesNumber { get; set; }
        #endregion
    }
}
