//-----------------------------------------------------------------------
// <copyright file="BaseShape.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using Elements;
    using System.Runtime.Serialization;

    /// <summary>
    /// Class for the base shape. In this class perfoms all draw actions(now).
    /// </summary>
    [Serializable]
    public class BaseShape
    {
        #region Fields
        /// <summary>
        /// State of the shape before transformation.
        /// </summary>
        [DataMember]
        protected List<Edge> initialEdges;

        /// <summary>
        /// List of edges. Is used for correct render. Here we save state of our shape before change its
        /// state. Also we use it to erase previous state.        
        /// </summary>
        [DataMember]
        protected List<Edge> previousState;

        /// <summary>
        /// Collection of edges for current shape.
        /// </summary>
        [DataMember]
        protected List<Edge> edges;

        /// <summary>
        /// Collection of sides for current shape.
        /// </summary>
        [DataMember]
        protected List<Side> sides;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseShape"></see> class. Not used directly only from derived classes.
        /// </summary>
        protected BaseShape()
        {
            edges = new List<Edge>();
            initialEdges = new List<Edge>();
            previousState = new List<Edge>();
        }
        #endregion

        #region Geometry transformations

        /// <summary>
        /// Scales shape relatevile base point.
        /// </summary>
        /// <param name="basePoint">The point in the space relatively of wich the shape would be scaled.</param>
        /// <param name="scale">This value is used to increase(decrease) shape size in all directions.</param>
        public virtual void Scale(Point3D basePoint, float scale)
        {
            var tmpEdges = new List<Edge>();
            foreach (var edge in edges)
            {
                tmpEdges.Add(Transformations.ScaleEdge(basePoint, edge, scale));
            }

            edges = tmpEdges;
        }

        /// <summary>
        /// Scales shape relatevile base point.
        /// </summary>
        /// <param name="basePoint">The point in the space relatively of wich the shape would be scaled.</param>
        /// <param name="scaleX">Scale for X axis.</param>
        /// <param name="scaleY">Scale for Y axis.</param>
        /// <param name="scaleZ">Scale for Z axis.</param>
        public virtual void Scale(Point3D basePoint, float scaleX, float scaleY, float scaleZ)
        {
            var tmpEdges = new List<Edge>();
            foreach (var edge in edges)
            {
                tmpEdges.Add(Transformations.ScaleEdge(basePoint, edge, scaleX, scaleY, scaleZ));
            }

            edges = tmpEdges;
        }

        /// <summary>
        /// Scales shape relatevile base point.
        /// </summary>
        /// <param name="basePoint">The point in the space relatively of wich the shape would be scaled.</param>
        /// <param name="rotAngleX">The angle to rotate around X axis.</param>
        /// <param name="rotAngleY">The angle to rotate around Y axis.</param>
        /// <param name="rotAngleZ">The angle to rotate around Z axis.</param>
        public void Rotate(Point3D basePoint, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            edges.Clear();

            var t = new Transformations();

            foreach (var edge in initialEdges)
            {
                edges.Add(t.RotateEdge(basePoint, edge, rotAngleX, rotAngleY, rotAngleZ));
            }
        }

        /// <summary>
        /// Moves the shape to specified displacement.
        /// </summary>
        /// <param name="dX">Displacment along X axis.</param>
        /// <param name="dY">Displacment along Y axis.</param>
        /// <param name="dZ">Displacment along Z axis.</param>
        public void Move(float dX, float dY, float dZ)
        {
            edges.Clear();
            foreach (var edge in initialEdges)
            {
                edges.Add(Transformations.MoveEdge(edge, dX, dY, dZ));
            }
        }

        /// <summary>
        /// Projects the shape to xOy plane.
        /// </summary>
        public void XYProjection()
        {
            edges.Clear();
            foreach (var edge in initialEdges)
            {
                edges.Add(Transformations.XYProjection(edge));
            }
        }

        /// <summary>
        /// Projects the shape to yOz plane.
        /// </summary>
        public void YZProjection()
        {
            edges.Clear();
            foreach (var edge in initialEdges)
            {
                edges.Add(Transformations.YZProjection(edge));
            }
        }

        /// <summary>
        /// Projects the shape to xOz plane.
        /// </summary>
        public void XZProjection()
        {
            edges.Clear();
            foreach (var edge in initialEdges)
            {
                edges.Add(Transformations.XZProjection(edge));
            }
        }
        #endregion

        #region Draw logic
        /// <summary>
        /// Saves current state of the shape.
        /// </summary>
        public void SaveState()
        {
            initialEdges = new List<Edge>(edges.ToArray());
        }

        /// <summary>
        /// Renders shape in its current state on form graphical context.
        /// </summary>
        /// <param name="g">Graphics of form where the shape should be rendered.</param>
        public virtual void Draw(Graphics g)
        {
            foreach (var edge in edges)
            {
                g.DrawLine(Pens.Black, edge.Vertex1, edge.Vertex2);
            }

            previousState = new List<Edge>(edges);
        }

        /// <summary>
        /// Erases the shape according its previous state.
        /// </summary>
        /// <param name="g">Graphics of form where the shape should be rendered.</param>
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