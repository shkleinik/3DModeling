using System.Collections.Generic;
using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    public class Cube : BaseShape
    {
        public int EdgeLength { get; set; }

        private Cube() { }

        /// <summary>
        /// Constructor for cube
        /// </summary>
        /// <param name="bP">It is bottom, left and closest pint of cube</param>
        /// <param name="eL">The length of one of the edges</param>
        public Cube(Point3D bP, float eL)
        {
            initialEdges = new List<Edge>();
            edges = new List<Edge>();
            //Vertical
            /*1*/
            edges.Add(new Edge(bP, new Point3D(bP.X, bP.Y - eL, bP.Z)));
            /*2*/
            edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y, bP.Z), new Point3D(bP.X + eL, bP.Y - eL, bP.Z)));
            /*3*/
            edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y, bP.Z - eL), new Point3D(bP.X + eL, bP.Y - eL, bP.Z - eL)));
            /*4*/
            edges.Add(new Edge(new Point3D(bP.X, bP.Y, bP.Z - eL), new Point3D(bP.X, bP.Y - eL, bP.Z - eL)));
            //Bottom
            /*5*/
            edges.Add(new Edge(bP, new Point3D(bP.X + eL, bP.Y, bP.Z)));
            /*6*/
            edges.Add(new Edge(bP, new Point3D(bP.X, bP.Y, bP.Z - eL)));
            /*7*/
            edges.Add(new Edge(new Point3D(bP.X, bP.Y, bP.Z - eL), new Point3D(bP.X + eL, bP.Y, bP.Z - eL)));
            /*8*/
            edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y, bP.Z - eL), new Point3D(bP.X + eL, bP.Y, bP.Z)));
            // Top
            /*9*/
            edges.Add(new Edge(new Point3D(bP.X, bP.Y - eL, bP.Z), new Point3D(bP.X, bP.Y - eL, bP.Z - eL)));
            /*10*/
            edges.Add(new Edge(new Point3D(bP.X, bP.Y - eL, bP.Z), new Point3D(bP.X + eL, bP.Y - eL, bP.Z)));
            /*11*/
            edges.Add(new Edge(new Point3D(bP.X, bP.Y - eL, bP.Z - eL), new Point3D(bP.X + eL, bP.Y - eL, bP.Z - eL)));
            /*12*/
            edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y - eL, bP.Z), new Point3D(bP.X + eL, bP.Y - eL, bP.Z - eL)));

            previousState = new List<Edge>(edges);

        }
    }
}
