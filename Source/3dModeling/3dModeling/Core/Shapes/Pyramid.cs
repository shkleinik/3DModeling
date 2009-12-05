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
        /// <param name="basePoint">Specifies the basepoint from what the pyramid will be built.</param>
        /// <remarks>
        /// Center of the bottom circumscribing circle.
        /// </remarks>
        /// <param name="sidesNumber">Specifies number of pyramid's sides.</param>
        /// <param name="radius">Specifies radius of pyramids circumscribing circle.</param>
        /// <param name="height">Specifies pyramids height.</param>
        public Pyramid(Vertex basePoint, int sidesNumber, float radius, float height)
        {
            SidesNumber = sidesNumber;
            Radius = radius;
            Height = height;

            var spikeVertex = new Vertex(basePoint.X, basePoint.Y + Height, basePoint.Z);
            var angleStep = 2 * Math.PI / SidesNumber;
            double angle = 0;

            for (var i = 0; i < SidesNumber; i++)
            {
                var inclinatedSide = new Polygon();
                var bottomSide = new Polygon();
                angle += angleStep;

                var dx = Radius * (float)Math.Cos(angle);
                var dz = Radius * (float)Math.Sin(angle);
                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                //      /\
                //      --
                var bottomVertex = new Vertex(basePoint.X + dx, basePoint.Y, basePoint.Z + dz);
                var nextBottomVertex = new Vertex(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);

                if (Height > 0)
                {
                    bottomSide.Verteces.Add(bottomVertex);
                    bottomSide.Verteces.Add(nextBottomVertex);
                    bottomSide.Verteces.Add(basePoint);

                    inclinatedSide.Verteces.Add(spikeVertex);
                    inclinatedSide.Verteces.Add(nextBottomVertex);
                    inclinatedSide.Verteces.Add(bottomVertex);
                }
                else
                {
                    bottomSide.Verteces.Add(basePoint);
                    bottomSide.Verteces.Add(nextBottomVertex);
                    bottomSide.Verteces.Add(bottomVertex);

                    inclinatedSide.Verteces.Add(bottomVertex);
                    inclinatedSide.Verteces.Add(nextBottomVertex);
                    inclinatedSide.Verteces.Add(spikeVertex);
                }

                if (!sides.Contains(inclinatedSide))
                {
                    sides.Add(inclinatedSide);
                }
                if (!sides.Contains(bottomSide))
                {
                    sides.Add(bottomSide);
                }
            }

            previousState = new List<Polygon>(sides);
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
