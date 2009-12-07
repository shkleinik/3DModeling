//-----------------------------------------------------------------------
// <copyright file="Cone.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core.Shapes
{
    using Elements;

    /// <summary>
    /// Class for cone.
    /// </summary>
    public class Cone : Pyramid
    {
        #region Constants
        /// <summary>
        /// Specifies level of approximation for the cone (number of sides with wich circle will be replaced).
        /// </summary>
        private const int APPORXIMATION_LEVEL = 500;
        #endregion

        #region Constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Cone"/> class. Use this class to create new instances.
        /// </summary>
        /// <param name="basePoint">Specifies the basepoint from what the pyramid will be built.</param>
        /// <param name="radius">Specifies radius of cone bottom circle.</param>
        /// <param name="height">Specifies pyramids height.</param>
        public Cone(Vertex basePoint, float radius, float height)
            : base(basePoint, APPORXIMATION_LEVEL, radius, height)
        {
        }

        /// <summary>
        /// Prevents a default instance of the <see cref="Cone"/> class from being created.
        /// Initializes a new instance of the <see cref="Cone"/> class. Parametless constructor is required for normal serialization.
        /// </summary>
        private Cone()
        {
        }
        #endregion
    }
}