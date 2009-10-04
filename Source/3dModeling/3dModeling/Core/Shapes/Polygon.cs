using System.Collections.Generic;
using System.Drawing;
using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    class Polygon : BaseShape
    {
        //    public List<Point3D> Vertexes;
        //    private List<Point3D> initialVertexes;

        //    #region Implementation of BaseShape

        //    public void Scale(Point3D basePoint, float scale)
        //    {
        //        Vertexes = Transformations.ScaleVertexes(basePoint, Vertexes, scale);
        //    }

        //    public void Rotate(Point3D basePoint, double rotAngleX, double rotAngleY, double rotAngleZ)
        //    {
        //        throw new System.NotImplementedException();
        //    }

        //    public void Move(float dX, float dY, float dZ)
        //    {
        //        Vertexes = Transformations.MoveVertexes(initialVertexes, dX, dY, dZ);
        //    }

        //    public void Draw(Graphics g)
        //    {
        //        if (Vertexes == null)
        //            return;
        //        if (Vertexes.Count < 2)
        //            return;

        //        var PolygonPen = new Pen(Color.Black, 3);
        //        var vertexes2D = new List<PointF>();
        //        foreach (var vertex in Vertexes)
        //        {
        //            vertexes2D.Add(vertex);
        //        }
        //        g.DrawPolygon(PolygonPen, vertexes2D.ToArray());
        //    }

        //    public void SaveState()
        //    {
        //        initialVertexes = Vertexes;
        //    }

        //    #endregion
    }
}