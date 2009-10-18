using System;

namespace Modeling.Core.Elements
{
    [Serializable]
    public class Edge
    {
        #region Properties
        public Point3D Vertex1 { get; set; }
        public Point3D Vertex2 { get; set; }
        #endregion

        #region Constructors
        private Edge() { }

        public Edge(Point3D v1, Point3D v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
        }
        #endregion

    }
}