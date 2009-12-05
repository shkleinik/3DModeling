//-----------------------------------------------------------------------
// <copyright file="Cylinder.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using Elements;

    /// <summary>
    /// Class for cylinder.
    /// </summary>
    public class Cylinder : Prizm
    {
        #region Constants
        /// <summary>
        /// Specifies the approximation level(number of sides).
        /// </summary>
        private const int APPORXIMATION_LEVEL = 50;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Cylinder"/> class. Use this class to create new instances.
        /// </summary>
        /// <param name="basePoint">It is bottom center point.</param>
        /// <param name="radius">The radius of bottom or top circle.</param>
        /// <param name="height">Cylinder height.</param>
        public Cylinder(Vertex basePoint, float radius, float height)
            : base(basePoint, APPORXIMATION_LEVEL, radius, height)
        {
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Cylinder"/> class from being created. Parametless constructor is required for normal serialization.
        /// </summary>
        private Cylinder()
        {
        }
        #endregion
    }
}
