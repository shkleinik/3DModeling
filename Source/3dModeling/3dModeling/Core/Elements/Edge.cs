//-----------------------------------------------------------------------
// <copyright file="Edge.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------


namespace Modeling.Core.Elements
{
    using System;

    [Serializable]
    public class Edge
    {
        #region Properties
        public Vertex Vertex1 { get; set; }
        public Vertex Vertex2 { get; set; }
        #endregion

        #region Constructors
        private Edge() { }

        public Edge(Vertex v1, Vertex v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
        }
        #endregion

    }
}