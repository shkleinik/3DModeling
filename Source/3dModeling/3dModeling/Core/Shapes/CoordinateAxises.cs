using System.Collections.Generic;
using System.Drawing;
using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    public class CoordinateAxises : BaseShape
    {
        #region Constatnts
        private const int AXIS_LENGTH = 30;
        #endregion

        #region Properties
        public Point3D BasePoint
        {
            get
            {
                return edges[0].Vertex1;
            }
        }
        #endregion

        #region Constructors
        public CoordinateAxises() { }

        public CoordinateAxises(Point3D bP)
        {
            initialEdges = new List<Edge>();
            edges = new List<Edge>();

            edges.Add(new Edge(bP, new Point3D(bP.X + AXIS_LENGTH, bP.Y, bP.Z)));
            edges.Add(new Edge(bP, new Point3D(bP.X, bP.Y - AXIS_LENGTH, bP.Z)));
            edges.Add(new Edge(bP, new Point3D(bP.X, bP.Y, bP.Z + AXIS_LENGTH)));
        }
        #endregion

        #region Base methods overrides
        public override void Scale(Point3D basePoint, float scale)
        {
            var tmpEdges = new List<Edge>();
            var tmpE = Transformations.ScaleEdge(basePoint, edges[0], scale);
            tmpEdges.Add(new Edge(tmpE.Vertex2, new Point3D(tmpE.Vertex1.X + AXIS_LENGTH, tmpE.Vertex1.Y, tmpE.Vertex1.Z)));
            tmpEdges.Add(new Edge(tmpE.Vertex2, new Point3D(tmpE.Vertex1.X, tmpE.Vertex1.Y - AXIS_LENGTH, tmpE.Vertex1.Z)));
            tmpEdges.Add(new Edge(tmpE.Vertex2, new Point3D(tmpE.Vertex1.X, tmpE.Vertex1.Y, tmpE.Vertex1.Z + AXIS_LENGTH)));
        }

        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Blue, 3F), edges[0].Vertex1, edges[0].Vertex2);
            g.DrawLine(new Pen(Color.Red, 3F), edges[1].Vertex1, edges[1].Vertex2);
            g.DrawLine(new Pen(Color.Green, 3F), edges[2].Vertex1, edges[2].Vertex2);
            previousState = new List<Edge>(edges);
        }

        public override void Erase(Graphics g)
        {
            foreach (var edge in previousState)
            {
                g.DrawLine(new Pen(Color.White, 3F), edge.Vertex1, edge.Vertex2);
            }
        }
        #endregion
    }
}