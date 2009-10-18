using System;
using System.Collections.Generic;
using System.Drawing;
using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    [Serializable]
    public class BaseShape
    {
        #region Fields
        public List<Edge> initialEdges;
        public List<Edge> previousState;
        public List<Edge> Edges;
        #endregion

        #region Constructors
        protected BaseShape()
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

        public virtual void Scale(Point3D basePoint, float scaleX, float scaleY, float scaleZ)
        {
            var tmpEdges = new List<Edge>();
            foreach (var edge in Edges)
            {
                tmpEdges.Add(Transformations.ScaleEdge(basePoint, edge, scaleX, scaleY, scaleZ));
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

        public void XYProjection()
        {
            Edges.Clear();
            foreach (var edge in initialEdges)
            {
                Edges.Add(Transformations.XYProjection(edge));
            }
        }

        public void YZProjection()
        {
            Edges.Clear();
            foreach (var edge in initialEdges)
            {
                Edges.Add(Transformations.YZProjection(edge));
            }
            
        }

        public void XZProjection()
        {
            Edges.Clear();
            foreach (var edge in initialEdges)
            {
                Edges.Add(Transformations.XZProjection(edge));
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
    }
}