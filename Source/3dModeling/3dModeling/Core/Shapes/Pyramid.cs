using System.Collections.Generic;
using Modeling.Core.Elements;
using System;

namespace Modeling.Core.Shapes
{
    public class Pyramid : BaseShape
    {
        #region Properties
        public float Height { get; set; }
        public float Radius { get; set; }
        public int SidesNumber { get; set; }
        #endregion

        protected Pyramid() { }

        public Pyramid(Point3D basePoint, int sidesNumber, float radius, float height)
        {
            SidesNumber = sidesNumber;
            Radius = radius;
            Height = height;
            Edges = new List<Edge>();

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
                Edges.Add(edgeInclinated);
                // Bottom edges
                var dxNext = Radius * (float)Math.Cos(angle + angleStep);
                var dzNext = Radius * (float)Math.Sin(angle + angleStep);

                var vNext = new Point3D(basePoint.X + dxNext, basePoint.Y, basePoint.Z + dzNext);

                var edgeBottom = new Edge(v, vNext);
                Edges.Add(edgeBottom);

            }
            previousState = new List<Edge>(Edges);
        }
    }
}
