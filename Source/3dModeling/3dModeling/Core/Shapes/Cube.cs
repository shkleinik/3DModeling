//-----------------------------------------------------------------------
// <copyright file="Cube.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using System;
    using Elements;

    /// <summary>
    /// Class for cube.
    /// </summary>
    public class Cube : Prizm
    {
        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Cube"/> class. Use this class to create new instances.
        /// </summary>
        /// <param name="basePoint">It is bottom, left and closest pint of cube</param>
        /// <param name="edgeLength">The length of one of the edges</param>
        public Cube(Vertex basePoint, float edgeLength)
            : base(basePoint, 4, (float)(edgeLength / Math.Sqrt(2.0F)), edgeLength)
        {
            EdgeLength = edgeLength;
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Cube"/> class from being created. Parametless constructor is required for normal serialization.
        /// </summary>
        private Cube()
        {
        }
        #endregion

        #region Properties
        /// <summary>
        /// Gets or sets cubes edge length.
        /// </summary>
        public float EdgeLength { get; set; }
        #endregion
    }
}
