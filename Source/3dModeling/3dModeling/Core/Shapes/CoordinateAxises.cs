//-----------------------------------------------------------------------
// <copyright file="CoordinateAxises.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

using Microsoft.DirectX.Direct3D;

namespace Modeling.Core.Shapes
{
    using System;
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
        public CoordinateAxises(Point3D bP)
        {
            initialSides = new List<Side>();
            previousState = new List<Side>();
            var edges = new List<Edge>
                        {
                            new Edge(bP, new Point3D(bP.X + AXIS_LENGTH, bP.Y, bP.Z)),
                            new Edge(bP, new Point3D(bP.X, bP.Y - AXIS_LENGTH, bP.Z)),
                            new Edge(bP, new Point3D(bP.X, bP.Y, bP.Z + AXIS_LENGTH))
                        };
            sides.Add(new Side { Edges = edges });
        }
        #endregion

        #region Fields

        private double alpha;
        private double beta;
        private double gamma;

        #endregion

        #region Properties
        /// <summary>
        /// Gets the base point of the coordinate system.
        /// </summary>
        [DataMember]
        public Point3D BasePoint
        {
            get
            {
                return sides[0].Edges[0].Vertex1;
            }
        }

        [DataMember]
        public double Alpha
        { get; set; }
        //    get
        //    {
        //        return alpha;
        //    }
        //    set
        //    {
        //        if (value > 2 * Math.PI)
        //        {
        //            alpha = value - 2 * Math.PI;
        //            return;
        //        }
        //        if (value < -2 * Math.PI)
        //        {
        //            alpha = value + 2 * Math.PI;
        //            return;
        //        }
        //        alpha = value;
        //    }
        //}

        [DataMember]
        public double Beta { get; set; }
        //    get
        //    {
        //        return beta;
        //    }
        //    set
        //    {
        //        if (value > 2 * Math.PI)
        //        {
        //            beta = value - 2 * Math.PI;
        //            return;
        //        }
        //        if (value < -2 * Math.PI)
        //        {
        //            beta = value + 2 * Math.PI;
        //            return;
        //        }
        //        beta = value;
        //    }
        //}

        [DataMember]
        public float Gamma { get; set; }
        #endregion

        #region Base methods overrides
        /// <summary>
        /// Overrides base method Draw to render colored axises instead sided shape.
        /// </summary>
        /// <param name="g">Graphics context from redering form.</param>
        public override void Draw(Graphics g)
        {
            g.DrawLine(new Pen(Color.Blue, 3F), sides[0].Edges[0].Vertex1, sides[0].Edges[0].Vertex2);
            g.DrawLine(new Pen(Color.Red, 3F), sides[0].Edges[1].Vertex1, sides[0].Edges[1].Vertex2);
            g.DrawLine(new Pen(Color.Green, 3F), sides[0].Edges[2].Vertex1, sides[0].Edges[2].Vertex2);

            previousState = new List<Side>(sides);
        }

        public override void Draw(Device device)
        {
            device.VertexFormat = CustomVertex.TransformedColored.Format;
            device.DrawUserPrimitives(PrimitiveType.LineList, 1, ConvertEdgeToTransformedColored(sides[0].Edges[0], Color.Blue));
            device.DrawUserPrimitives(PrimitiveType.LineList, 1, ConvertEdgeToTransformedColored(sides[0].Edges[1], Color.Red));
            device.DrawUserPrimitives(PrimitiveType.LineList, 1, ConvertEdgeToTransformedColored(sides[0].Edges[2], Color.Green));
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="g"></param>
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
            initialSides = new List<Side>(sides.ToArray());
        }

        public override void Scale(Point3D basePoint, float scale)
        {
            base.Scale(basePoint, 1);
        }
        #endregion
    }
}