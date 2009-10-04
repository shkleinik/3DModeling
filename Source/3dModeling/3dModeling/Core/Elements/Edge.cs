namespace Modeling.Core.Elements
{
    public class Edge
    {

        public Edge(Point3D v1, Point3D v2)
        {
            Vertex1 = v1;
            Vertex2 = v2;
        }

        public Point3D Vertex1 { get; set; }
        public Point3D Vertex2 { get; set; }
    }
}