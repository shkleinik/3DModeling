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

            var spikeVertex = new Point3D(basePoint.X, basePoint.Y + Height, basePoint.Z);
            var angleStep = 2 * Math.PI / SidesNumber;
            double angle = 0;

            var bottomEdges = new List<Edge>();
            for (var i = 0; i < SidesNumber; i++)
            {
                var inclinatedSide = new Side();

                angle += angleStep;

                var dx = Radius * (float)Math.Cos(angle);
                var dz = Radius * (float)Math.Sin(angle);

                //      /\
                //      --
                var bottomVertex = new Point3D(basePoint.X + dx, basePoint.Y, basePoint.Z + dz);
                var inclinatedEdge = new Edge(bottomVertex, spikeVertex);

                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                var nextBottomVertex = new Point3D(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);
                var nextInclinatedEdge = new Edge(nextBottomVertex, spikeVertex);

                var bottomEdge = new Edge(bottomVertex, nextBottomVertex);

                inclinatedSide.Edges.Add(inclinatedEdge);
                inclinatedSide.Edges.Add(nextInclinatedEdge);
                inclinatedSide.Edges.Add(bottomEdge);

                if (!bottomEdges.Contains(bottomEdge))
                {
                    bottomEdges.Add(bottomEdge);
                }

                if (!sides.Contains(inclinatedSide))
                {
                    sides.Add(inclinatedSide);
                }
            }

            var bottomSide = new Side();
            bottomSide.Edges.AddRange(bottomEdges);

            previousState = new List<Side>(sides);
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
