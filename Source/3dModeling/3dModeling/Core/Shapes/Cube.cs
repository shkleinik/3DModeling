using System.Collections.Generic;
using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    class Cube : BaseShape
    {
        public int EdgeLength { get; set; }

        /// <summary>
        /// Constructor for cube
        /// </summary>
        /// <param name="bP">It is bottom, left and closest pint of cube</param>
        /// <param name="eL">The length of one of the edges</param>
        public Cube(Point3D bP, float eL)
        {
            initialEdges = new List<Edge>();
            Edges = new List<Edge>();
            //Vertical
            /*1*/
            Edges.Add(new Edge(bP, new Point3D(bP.X, bP.Y - eL, bP.Z)));
            /*2*/
            Edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y, bP.Z), new Point3D(bP.X + eL, bP.Y - eL, bP.Z)));
            /*3*/
            Edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y, bP.Z - eL), new Point3D(bP.X + eL, bP.Y - eL, bP.Z - eL)));
            /*4*/
            Edges.Add(new Edge(new Point3D(bP.X, bP.Y, bP.Z - eL), new Point3D(bP.X, bP.Y - eL, bP.Z - eL)));
            //Bottom
            /*5*/
            Edges.Add(new Edge(bP, new Point3D(bP.X + eL, bP.Y, bP.Z)));
            /*6*/
            Edges.Add(new Edge(bP, new Point3D(bP.X, bP.Y, bP.Z - eL)));
            /*7*/
            Edges.Add(new Edge(new Point3D(bP.X, bP.Y, bP.Z - eL), new Point3D(bP.X + eL, bP.Y, bP.Z - eL)));
            /*8*/
            Edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y, bP.Z - eL), new Point3D(bP.X + eL, bP.Y, bP.Z)));
            // Top
            /*9*/
            Edges.Add(new Edge(new Point3D(bP.X, bP.Y - eL, bP.Z), new Point3D(bP.X, bP.Y - eL, bP.Z - eL)));
            /*10*/
            Edges.Add(new Edge(new Point3D(bP.X, bP.Y - eL, bP.Z), new Point3D(bP.X + eL, bP.Y - eL, bP.Z)));
            /*11*/
            Edges.Add(new Edge(new Point3D(bP.X, bP.Y - eL, bP.Z - eL), new Point3D(bP.X + eL, bP.Y - eL, bP.Z - eL)));
            /*12*/
            Edges.Add(new Edge(new Point3D(bP.X + eL, bP.Y - eL, bP.Z), new Point3D(bP.X + eL, bP.Y - eL, bP.Z - eL)));

            previousState = new List<Edge>(Edges);

        }
    }
}
