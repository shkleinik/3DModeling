namespace Modeling.Core.Shapes
{
    using System;
    using System.Collections.Generic;
    using Elements;

    public class Cylinder : BaseShape
    {
        public int EdgeLength { get; set; }

        private Cylinder() { }

        /// <summary>
        /// Constructor for cube
        /// </summary>
        /// <param name="basePoint">It is bottom, left and closest pint of cube</param>
        /// <param name="radius">The length of one of the edges</param>
        /// <param name="height">Cylinder height.</param>
        public Cylinder(Point3D basePoint, float radius, float height)
        {

            SidesNumber = APPORXIMATION_LEVEL;
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
                var edgeInclinated = new Edge(v, new Point3D(v.X, v.Y + Height, v.Z));
                edges.Add(edgeInclinated);

                // Bottom edges
                var nextDX = Radius * (float)Math.Cos(angle + angleStep);
                var nextDZ = Radius * (float)Math.Sin(angle + angleStep);

                var nextVertex = new Point3D(basePoint.X + nextDX, basePoint.Y, basePoint.Z + nextDZ);

                var edgeBottom = new Edge(v, nextVertex);
                edges.Add(edgeBottom);

                // Top edges 
                var edgeTop = new Edge(new Point3D(v.X, v.Y + Height, v.Z), new Point3D(nextVertex.X, nextVertex.Y + Height, nextVertex.Z));
                edges.Add(edgeTop);

            }

            previousState = new List<Edge>(edges);

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
        private const int APPORXIMATION_LEVEL = 25;
        #endregion
    }
}
