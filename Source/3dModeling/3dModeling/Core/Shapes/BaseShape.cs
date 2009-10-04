using System.Collections.Generic;
using System.Drawing;
using System.Xml.Serialization;
using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    public class BaseShape
    {
        #region Fields
        protected List<Edge> initialEdges;
        protected List<Edge> previousState;
        protected List<Edge> Edges;
        #endregion

        #region Constructors
        public BaseShape()
        {
            Edges = new List<Edge>();
            initialEdges = new List<Edge>();
            previousState = new List<Edge>();
        }
        #endregion

        #region Geometry transformations
        public virtual void Scale(Point3D basePoint, float scale)
        {
            var tmpEdges = new List<Edge>();
            foreach (var edge in Edges)
            {
                tmpEdges.Add(Transformations.ScaleEdge(basePoint, edge, scale));
            }
            Edges = tmpEdges;
        }

        public void Rotate(Point3D basePoint, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            Edges.Clear();

            var t = new Transformations();

            foreach (var edge in initialEdges)
            {
                Edges.Add(t.RotateEdge(basePoint, edge, rotAngleX, rotAngleY, rotAngleZ));
            }
        }

        public void Move(float dX, float dY, float dZ)
        {
            Edges.Clear();
            foreach (var edge in initialEdges)
            {
                Edges.Add(Transformations.MoveEdge(edge, dX, dY, dZ));
            }
        }



        #endregion

        #region Draw logic
        public void SaveState()
        {
            initialEdges = new List<Edge>(Edges.ToArray());
        }

        public virtual void Draw(Graphics g)
        {
            foreach (var edge in Edges)
            {
                g.DrawLine(Pens.Black, edge.Vertex1, edge.Vertex2);
            }

            previousState = new List<Edge>(Edges);
        }

        public virtual void Erase(Graphics g)
        {
            foreach (var edge in previousState)
            {
                g.DrawLine(Pens.White, edge.Vertex1, edge.Vertex2);
            }
        }
        #endregion

        //[XmlInclude(typeof(CoordinateAxises)), XmlInclude(typeof(Cone)), XmlInclude(typeof(Pyramid)), XmlInclude(typeof(Cube))]
        //public new BaseShape GetType()
        //{
        //    return GetType();
        //}
    }
}