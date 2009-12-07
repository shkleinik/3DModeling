//-----------------------------------------------------------------------
// <copyright file="CoordinateAxises.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

using Microsoft.DirectX.Direct3D;

namespace Modeling.Core.Shapes
{
    using System.Collections.Generic;
    using System.Drawing;
    using System.Runtime.Serialization;
    using Elements;

    /// <summary>
    /// Class for coordinate axises. Used to definition of coordinate system base point.
    /// </summary>
    public class CoordinateAxises : BaseShape
    {
        #region Constatnts
        /// <summary>
        /// Defines length of the axis.
        /// </summary>
        private const int AXIS_LENGTH = 30;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="CoordinateAxises"/> class. Parametless constructor is required for normal serialization.
        /// </summary>
        public CoordinateAxises()
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="CoordinateAxises"/> class.
        /// </summary>
        /// <param name="bP">Base point to create coordinate axises.</param>
        public CoordinateAxises(Vertex bP)
        {
            initialSides = new List<Polygon>();
            previousState = new List<Polygon>();
            var verteces = new List<Vertex>
                        {
                            bP,
                            new Vertex(bP.X + AXIS_LENGTH, bP.Y, bP.Z),
                            new Vertex(bP.X, bP.Y - AXIS_LENGTH, bP.Z),
                            new Vertex(bP.X, bP.Y, bP.Z + AXIS_LENGTH)
                        };
            sides.Add(new Polygon { Verteces = verteces });
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets the base point of the coordinate system.
        /// </summary>
        [DataMember]
        public Vertex BasePoint
        {
            get
            {
                return sides[0].Edges[0].Vertex1;
            }
        }
        #endregion

        #region Base methods overrides
        /// <summary>
        /// Overrides base method Draw to render colored axises instead sided shape.
        /// </summary>
        /// <param name="g">Graphics context from redering form.</param>
        /// <param name="lightSource">Location of the sun :) </param>
        /// <param name="color">Specifies the base color of the shape.</param>
        /// <param name="fill"> Determines if polygons would be filled with<see cref="color"/>.</param>
        /// <param name="drawEdges">Determines if polygons would be drawn.</param>
        public override void Draw(Graphics g, Vertex lightSource, Color color, bool fill, bool drawEdges)
        {
            g.DrawLine(new Pen(Color.Blue, 3F), sides[0].Verteces[0], sides[0].Verteces[1]);
            g.DrawLine(new Pen(Color.Red, 3F), sides[0].Verteces[0], sides[0].Verteces[2]);
            g.DrawLine(new Pen(Color.Green, 3F), sides[0].Verteces[0], sides[0].Verteces[3]);

            previousState = new List<Polygon>(sides);
        }

        public override void Draw(Device device, Vertex lightSource, Color color, bool fill, bool drawEdges)
        {
            device.VertexFormat = CustomVertex.TransformedColored.Format;
            device.DrawUserPrimitives(PrimitiveType.LineList, 1, GetTransformedColoredFromVerteces(sides[0].Verteces[0], sides[0].Verteces[1], Color.Blue));
            device.DrawUserPrimitives(PrimitiveType.LineList, 1, GetTransformedColoredFromVerteces(sides[0].Verteces[0], sides[0].Verteces[2], Color.Red));
            device.DrawUserPrimitives(PrimitiveType.LineList, 1, GetTransformedColoredFromVerteces(sides[0].Verteces[0], sides[0].Verteces[3], Color.Green));
        }

        public override void Erase(Graphics g)
        {
            if (previousState.Count == 0)
                return;

            foreach (var edge in previousState[0].Edges)
            {
                g.DrawLine(new Pen(Color.White, 3F), edge.Vertex1, edge.Vertex2);
            }
        }

        public override void SaveState()
        {
            initialSides = new List<Polygon>(sides.ToArray());
        }

        public override void Scale(Vertex basePoint, float scale)
        {
            base.Scale(basePoint, 1);
        }
        #endregion

        #region Auxiliary Methods
        private static CustomVertex.TransformedColored[] GetTransformedColoredFromVerteces(Vertex Vertex1, Vertex Vertex2, Color color)
        {
            var verts = new CustomVertex.TransformedColored[2];

            verts[0].X = Vertex1.X;
            verts[0].Y = Vertex1.Y;
            verts[0].Z = Vertex1.Z;
            verts[0].Color = color.ToArgb();

            verts[1].X = Vertex2.X;
            verts[1].Y = Vertex2.Y;
            verts[1].Z = Vertex2.Z;
            verts[1].Color = color.ToArgb();

            return verts;
        }
        #endregion
    }
}