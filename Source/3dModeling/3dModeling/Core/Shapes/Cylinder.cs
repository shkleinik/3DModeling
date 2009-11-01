namespace Modeling.Core.Shapes
{
    using System;
    using System.Collections.Generic;
    using Elements;

    public class Cylinder : BaseShape
    {
        public int EdgeLength { get; set; }

        /// <summary>
        /// Initializes new instance of the <see cref="Cylinder"/> class.  Parametless constructor is required for normal serialization.
        /// </summary>
        private Cylinder() { }

        /// <summary>
        /// Constructor for cylinder
        /// </summary>
        /// <param name="basePoint">It is bottom center point.</param>
        /// <param name="radius">The radius of bottom or top circle.</param>
        /// <param name="height">Cylinder height.</param>
        public Cylinder(Point3D basePoint, float radius, float height)
        {
            SidesNumber = APPORXIMATION_LEVEL;
            Radius = radius;
            Height = height;

            // var spikePoint = new Point3D(basePoint.X, basePoint.Y + Height, basePoint.Z);
            var angleStep = 2 * Math.PI / SidesNumber;
            double angle = 0;

            var bottomEdges = new List<Edge>();
            var topEdges = new List<Edge>();

            for (var i = 0; i < SidesNumber; i++)
            {
                var edges = new List<Edge>();

                angle += angleStep;
                var dx = Radius * (float)Math.Cos(angle);
                var dz = Radius * (float)Math.Sin(angle);
                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                // Edges, wich connect cylinder's top and bottom
                var bottomVertex = new Point3D(basePoint.X + dx, basePoint.Y, basePoint.Z + dz);
                var nextBottomVertex = new Point3D(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);

                var topVertex = new Point3D(bottomVertex.X, bottomVertex.Y + Height, bottomVertex.Z);
                var nextTopVertex = new Point3D(nextBottomVertex.X, nextBottomVertex.Y + Height, nextBottomVertex.Z);

                var edgeVertical = new Edge(bottomVertex, topVertex);
                var edgeNextVertical = new Edge(nextBottomVertex, nextTopVertex);
                edges.Add(edgeVertical);
                edges.Add(edgeNextVertical);

                // Bottom edges
                var edgeBottom = new Edge(bottomVertex, nextBottomVertex);
                edges.Add(edgeBottom);
                bottomEdges.Add(edgeBottom);

                // Top edges
                var edgeTop = new Edge(topVertex, nextTopVertex);
                edges.Add(edgeTop);
                topEdges.Add(edgeTop);

                sides.Add(new Side{Edges = edges});
            }

            sides.Add(new Side{Edges = bottomEdges});
            sides.Add(new Side{Edges = topEdges});
        }

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

        #region Constants
        private const int APPORXIMATION_LEVEL = 50;
        #endregion
    }
}
