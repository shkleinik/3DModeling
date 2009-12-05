/*//-----------------------------------------------------------------------
// <copyright file="Prizm.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using System;
    using Elements;

    /// <summary>
    /// Class for Prizm.
    /// </summary>
    public class Prizm : BaseShape
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Prizm"/> class. Use this class to create new instances.
        /// </summary>
        /// <remarks> 
        ///   topVertex     nextTopVertex
        ///          ________
        ///         |\       |
        ///         | \      |
        ///         |  \ two |
        /// vertical|   \    | nextVerticalEdge
        ///  Edge   |    \   |
        ///         | one \  |
        ///         |      \ |
        ///         |_______\|
        /// bottomVertex    nextBottomVertex 
        ///        bottomVertex
        ///               ______
        ///              /\    /\
        ///             / b\as/e \
        /// nextBottom /____\/____\
        ///   Vertex   \ poi/\nt  /
        ///             \  /  \  /
        ///              \/____\/ 
        /// </remarks>
        /// <param name="basePoint">It is bottom center point.</param>
        /// <param name="sidesNumber">Number of prizm sides.</param>
        /// <param name="radius">The radius of bottom or top circumscribing circle.</param>
        /// <param name="height">Prizm height.</param>
        public Prizm(Point3D basePoint, int sidesNumber, float radius, float height)
        {
            if (sidesNumber < 3)
            {
                throw new ArgumentException("Prizm should have at least three sides.");
            }

            if (radius < 0)
            {
                throw new ArgumentException("Radius should positive value.");
            }

            SidesNumber = sidesNumber;
            Radius = radius;
            Height = height;

            var angleStep = 2 * Math.PI / SidesNumber;
            double angle = 0;

            for (var i = 0; i < SidesNumber; i++)
            {
                var bottomSide = new Polygon();
                var topSide = new Polygon();
                var sideVerticalOne = new Polygon();
                var sideVerticalTwo = new Polygon();

                angle += angleStep;
                var dx = Radius * (float)Math.Cos(angle);
                var dz = Radius * (float)Math.Sin(angle);
                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                // Verteces
                var bottomVertex = new Point3D(basePoint.X + dx, basePoint.Y, basePoint.Z + dz);
                var nextBottomVertex = new Point3D(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);

                var topVertex = new Point3D(bottomVertex.X, bottomVertex.Y + Height, bottomVertex.Z);
                var nextTopVertex = new Point3D(nextBottomVertex.X, nextBottomVertex.Y + Height, nextBottomVertex.Z);
                var topBasePoint = new Point3D(basePoint.X, basePoint.Y + Height, basePoint.Z);
                // Edges
                //var edgeBottom = new Edge(bottomVertex, nextBottomVertex);
                //var edgeTop = new Edge(topVertex, nextTopVertex);
                //var edgeVertical = new Edge(bottomVertex, topVertex);
                //var edgeNextVertical = new Edge(nextBottomVertex, nextTopVertex);
                //var edgeInclinated = new Edge(bottomVertex, nextTopVertex);

                // Bottom sides
                bottomSide.Verteces.Add(basePoint);
                bottomSide.Verteces.Add(bottomVertex);
                bottomSide.Verteces.Add(nextBottomVertex);

                // Top sides
                topSide.Verteces.Add(topBasePoint);
                topSide.Verteces.Add(topVertex);
                topSide.Verteces.Add(nextTopVertex);

                // Vertical sides
                // One
                sideVerticalOne.Verteces.Add(bottomVertex);
                sideVerticalOne.Verteces.Add(nextBottomVertex);
                sideVerticalOne.Verteces.Add(topVertex);

                // Two
                sideVerticalTwo.Verteces.Add(topVertex);
                sideVerticalTwo.Verteces.Add(nextTopVertex);
                sideVerticalTwo.Verteces.Add(nextBottomVertex);

                // Add "piece" of the prizm.
                sides.Add(bottomSide);
                sides.Add(topSide);
                sides.Add(sideVerticalOne);
                sides.Add(sideVerticalTwo);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prizm"/> class.  Parametless constructor is required for normal serialization.
        /// </summary>
        protected Prizm()
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
*/

//-----------------------------------------------------------------------
// <copyright file="Prizm.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using System;
    using Elements;

    /// <summary>
    /// Class for Prizm.
    /// </summary>
    public class Prizm : BaseShape
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Prizm"/> class. Use this class to create new instances.
        /// </summary>
        /// <remarks> 
        ///   topVertex     nextTopVertex
        ///          ________
        ///         |\       |
        ///         | \      |
        ///         |  \ two |
        /// vertical|   \    | nextVerticalEdge
        ///  Edge   |    \   |
        ///         | one \  |
        ///         |      \ |
        ///         |_______\|
        /// bottomVertex    nextBottomVertex 
        ///        bottomVertex
        ///               ______
        ///              /\    /\
        ///             / b\as/e \
        /// nextBottom /____\/____\
        ///   Vertex   \ poi/\nt  /
        ///             \  /  \  /
        ///              \/____\/ 
        /// </remarks>
        /// <param name="basePoint">It is bottom center point.</param>
        /// <param name="sidesNumber">Number of prizm sides.</param>
        /// <param name="radius">The radius of bottom or top circumscribing circle.</param>
        /// <param name="height">Prizm height.</param>
        public Prizm(Point3D basePoint, int sidesNumber, float radius, float height)
        {
            if (sidesNumber < 3)
            {
                throw new ArgumentException("Prizm should have at least three sides.");
            }

            if (radius < 0)
            {
                throw new ArgumentException("Radius should positive value.");
            }

            SidesNumber = sidesNumber;
            Radius = radius;
            Height = height;

            var angleStep = 2 * Math.PI / SidesNumber;
            double angle = 0;

            for (var i = 0; i < SidesNumber; i++)
            {
                var bottomSide = new Polygon();
                var topSide = new Polygon();
                var sideVerticalOne = new Polygon();
                var sideVerticalTwo = new Polygon();

                angle += angleStep;
                var dx = Radius * (float)Math.Cos(angle);
                var dz = Radius * (float)Math.Sin(angle);
                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                // Verteces
                var bottomVertex = new Point3D(basePoint.X + dx, basePoint.Y, basePoint.Z + dz);
                var nextBottomVertex = new Point3D(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);

                var topVertex = new Point3D(bottomVertex.X, bottomVertex.Y + Height, bottomVertex.Z);
                var nextTopVertex = new Point3D(nextBottomVertex.X, nextBottomVertex.Y + Height, nextBottomVertex.Z);

                // Edges
                var edgeBottom = new Edge(bottomVertex, nextBottomVertex);
                var edgeTop = new Edge(topVertex, nextTopVertex);
                var edgeVertical = new Edge(bottomVertex, topVertex);
                var edgeNextVertical = new Edge(nextBottomVertex, nextTopVertex);
                var edgeInclinated = new Edge(bottomVertex, nextTopVertex);

                // Bottom sides
                bottomSide.Edges.Add(new Edge(bottomVertex, nextBottomVertex));
                bottomSide.Edges.Add(new Edge(bottomVertex, basePoint));
                bottomSide.Edges.Add(new Edge(nextBottomVertex, basePoint));

                // Top sides
                topSide.Edges.Add(new Edge(topVertex, nextTopVertex));
                topSide.Edges.Add(new Edge(topVertex, new Point3D(basePoint.X, basePoint.Y + Height, basePoint.Z)));
                topSide.Edges.Add(new Edge(nextTopVertex, new Point3D(basePoint.X, basePoint.Y + Height, basePoint.Z)));

                // Vertical sides
                // One
                sideVerticalOne.Edges.Add(edgeVertical);
                sideVerticalOne.Edges.Add(edgeInclinated);
                sideVerticalOne.Edges.Add(edgeBottom);

                // Two
                sideVerticalTwo.Edges.Add(edgeNextVertical);
                sideVerticalTwo.Edges.Add(edgeInclinated);
                sideVerticalTwo.Edges.Add(edgeTop);

                // Add "piece" of the prizm.
                sides.Add(bottomSide);
                sides.Add(topSide);
                sides.Add(sideVerticalOne);
                sides.Add(sideVerticalTwo);
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Prizm"/> class.  Parametless constructor is required for normal serialization.
        /// </summary>
        protected Prizm()
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

