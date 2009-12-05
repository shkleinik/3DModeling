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
    using Microsoft.DirectX.Direct3D;

    /// <summary>
    /// Class for the base shape. In this class perfoms all draw actions(now).
    /// </summary>
    [Serializable]
    public class BaseShape
    {
        #region Fields
        /// <summary>
        /// List of sides. Is used for correct render. Here we save state of our shape before change its
        /// state. Also we use it to erase previous state.
        /// </summary>
        [DataMember]
        protected List<Polygon> previousState;

        /// <summary>
        /// Collection of sides for current shape.
        /// </summary>
        [DataMember]
        public List<Polygon> sides;
        /// <summary>
        /// State of the shape before transformation. Is used to visualize continious transformation.
        /// Here we save our state after mouse down and store it until mouse up. All dynamic transformations 
        /// are doing relatively this state.
        /// </summary>
        [DataMember]
        protected List<Polygon> initialSides;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="BaseShape"></see> class. Not used directly only from derived classes.
        /// </summary>
        public BaseShape()
        {
            //edges = new List<Edge>();
            sides = new List<Polygon>();
            //initialEdges = new List<Edge>();
            initialSides = new List<Polygon>();
            previousState = new List<Polygon>();
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
            var tmpSides = new List<Polygon>();
            foreach (var side in sides)
            {
                tmpSides.Add(Transformations.ScaleSide(basePoint, side, scale, scale, scale));
            }

            sides = tmpSides;
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
            var tmpSides = new List<Polygon>();
            foreach (var side in sides)
            {
                tmpSides.Add(Transformations.ScaleSide(basePoint, side, scaleX, scaleY, scaleZ));
            }

            sides = tmpSides;
        }

        /// <summary>
        /// Scales shape relatevile base point.
        /// </summary>
        /// <param name="basePoint">The point in the space relatively of wich the shape would be scaled.</param>
        /// <param name="rotAngleX">The angle to rotate around X axis.</param>
        /// <param name="rotAngleY">The angle to rotate around Y axis.</param>
        /// <param name="rotAngleZ">The angle to rotate around Z axis.</param>
        public virtual void Rotate(Point3D basePoint, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            sides.Clear();

            var t = new Transformations();

            foreach (var side in initialSides)
            {
                sides.Add(t.RotateSide(basePoint, side, rotAngleX, rotAngleY, rotAngleZ));
            }
        }

        /// <summary>
        /// Moves the shape to specified displacement.
        /// </summary>
        /// <param name="dX">Displacment along X axis.</param>
        /// <param name="dY">Displacment along Y axis.</param>
        /// <param name="dZ">Displacment along Z axis.</param>
        public virtual void Move(float dX, float dY, float dZ)
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.MoveSide(side, dX, dY, dZ));
            }
        }

        #region Projections
        /// <summary>
        /// Projects the shape to xOy plane.
        /// </summary>
        public void XYProjection()
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.XYProjection(side));
            }
        }

        /// <summary>
        /// Projects the shape to yOz plane.
        /// </summary>
        public void YZProjection()
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.YZProjection(side));
            }
        }

        /// <summary>
        /// Projects the shape to xOz plane.
        /// </summary>
        public void XZProjection()
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.XZProjection(side));
            }
        }

        public void AksonometricProjection(double psi, double phi)
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.AksonometricProjection(side, psi, phi));
            }
        }

        public void BevelProjection(double L, double alpha)
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.BevelProjection(side, L, alpha));
            }
        }

        public void PerspectiveProjection(float d)
        {
            sides.Clear();
            foreach (var side in initialSides)
            {
                sides.Add(Transformations.PerspectiveProjection(side, d));
            }
        }
        #endregion

        #endregion

        #region Draw logic
        /// <summary>
        /// Saves current state of the shape at dynamic transformation started.
        /// Relatively this state transformation would be perfomed until mouse up.
        /// </summary>
        public virtual void SaveState()
        {
            initialSides = new List<Polygon>(sides.ToArray());
        }

        /// <summary>
        /// Renders shape in its current state on form graphical context. And also saves current 
        /// state as previous to erase itself later.
        /// </summary>
        /// <param name="g">Graphics of form where the shape should be rendered.</param>
        public virtual void Draw(Graphics g)
        {
            foreach (var side in sides)
            {
                if (side.Verteces.Count < 2)
                    continue;

                if (!side.IsVisible)
                    continue;

                g.DrawPolygon(new Pen(Brushes.Black, 1F), ConvertPoints3DToPontsF(side.Verteces.ToArray()));

                g.FillPolygon(Brushes.BlueViolet, ConvertPoints3DToPontsF(side.Verteces.ToArray()));
            }

            previousState = new List<Polygon>(sides);
        }

        /// <summary>
        /// Overload for DirectX.
        /// </summary>
        /// <param name="device">Draw device(aka your videocard).</param>
        /// <param name="color">Specifies the color for the figure.</param>
        public virtual void Draw(Device device, Color color)
        {
            device.VertexFormat = CustomVertex.TransformedColored.Format;
            // device.SetRenderState(RenderStates.CullMode, true);

            foreach (var side in sides)
            {
                //if (!side.IsVisible)
                //    continue;

                foreach (var edge in side.Edges)
                {
                    device.DrawUserPrimitives(PrimitiveType.LineList, 1, ConvertEdgeToTransformedColored(edge, Color.Black));
                }
                device.DrawUserPrimitives(PrimitiveType.TriangleStrip, 1, ConvertSideToTransformedColored(side, color));
            }
        }

        /// <summary>
        /// Erases the shape according its previous state.
        /// </summary>
        /// <param name="g">Graphics of form where the shape should be rendered.</param>
        public virtual void Erase(Graphics g)
        {
            foreach (var side in previousState)
            {
                g.FillPolygon(Brushes.White, ConvertPoints3DToPontsF(side.Verteces.ToArray()));
                if (side.Verteces.Count < 2)
                    continue;
                g.DrawPolygon(new Pen(Brushes.White, 2F), ConvertPoints3DToPontsF(side.Verteces.ToArray()));
            }
        }
        #endregion

        #region Auxiliary Methods
        private static PointF[] ConvertPoints3DToPontsF(Point3D[] points3D)
        {
            var pointsF = new PointF[points3D.Length];

            for (var i = 0; i < points3D.Length; i++)
            {
                pointsF[i] = points3D[i];
            }

            return pointsF;
        }

        protected static CustomVertex.TransformedColored[] ConvertEdgeToTransformedColored(Edge edge, Color color)
        {
            var verts = new CustomVertex.TransformedColored[2];

            verts[0].X = edge.Vertex1.X;
            verts[0].Y = edge.Vertex1.Y;
            verts[0].Z = edge.Vertex1.Z;
            verts[0].Color = color.ToArgb();

            verts[1].X = edge.Vertex2.X;
            verts[1].Y = edge.Vertex2.Y;
            verts[1].Z = edge.Vertex2.Z;
            verts[1].Color = color.ToArgb();

            return verts;
        }

        protected static CustomVertex.TransformedColored[] ConvertSideToTransformedColored(Polygon polygon, Color color)
        {
            var verts = new CustomVertex.TransformedColored[3];
            if (polygon.Verteces.Count < 3)
                return verts;

            verts[0].X = polygon.Verteces[0].X;
            verts[0].Y = polygon.Verteces[0].Y;
            verts[0].Z = polygon.Verteces[0].Z;
            verts[0].Color = color.ToArgb();

            verts[1].X = polygon.Verteces[1].X;
            verts[1].Y = polygon.Verteces[1].Y;
            verts[1].Z = polygon.Verteces[1].Z;
            verts[1].Color = color.ToArgb();

            verts[2].X = polygon.Verteces[2].X;
            verts[2].Y = polygon.Verteces[2].Y;
            verts[2].Z = polygon.Verteces[2].Z;
            verts[2].Color = color.ToArgb();

            return verts;
        }
        #endregion
    }
}