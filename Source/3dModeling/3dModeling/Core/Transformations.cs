//-----------------------------------------------------------------------
// <copyright file="Transformations.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

namespace Modeling.Core
{
    using System;
    using System.Collections.Generic;
    using Elements;

    /// <summary>
    /// All math for transformations is run here.
    /// </summary>
    class Transformations
    {
        #region Fields
        private float sX;
        private float cX;

        private float sY;
        private float cY;

        private float sZ;
        private float cZ;
        #endregion

        #region Rotation
        /// <summary>
        /// Rotates gived polygon relatively current base point
        /// </summary>
        /// <param name="basePoint">The Point relative wich polygon will rotate.</param>
        /// <param name="polygon">Side to be rotated.</param>
        /// <param name="angleX">The rotation angle around X-axis.</param>
        /// <param name="angleY">The rotation angle around Y-axis.</param>
        /// <param name="angleZ">The rotation angle around Z-axis.</param>
        /// <returns>Rotated polygon.</returns>
        public Polygon RotateSide(Point3D basePoint, Polygon polygon, double angleX, double angleY, double angleZ)
        {
            var rotatedEdges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                rotatedEdges.Add(RotateEdge(basePoint, edge, angleX, angleY, angleZ));
            }

            return new Polygon { Edges = rotatedEdges };
        }

        public Edge RotateEdge(Point3D basePoint, Edge edge, double angleX, double angleY, double angleZ)
        {
            var v1 = RotateVertex(basePoint, edge.Vertex1, angleX, angleY, angleZ);
            var v2 = RotateVertex(basePoint, edge.Vertex2, angleX, angleY, angleZ);
            return new Edge(v1, v2);
        }
        /// <summary>
        /// Rotates gived edge relatively current base point
        /// </summary>
        /// <param name="basePoint">The Point relative wich vertexes will rotate.</param>
        /// <param name="vertexes">Coordinates of vertexes wich you want to rotate.</param>
        /// <param name="rotAngleX">The rotation angle around X-axis.</param>
        /// <param name="rotAngleY">The rotation angle around Y-axis.</param>
        /// <param name="rotAngleZ">The rotation angle around Z-axis.</param>
        /// <returns>List of vertexes rotated relatively base point.</returns>
        public List<Point3D> RotateVertexes(Point3D basePoint, List<Point3D> vertexes, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            var rotatedVertexes = new List<Point3D>();
            foreach (var vertex in vertexes)
            {
                var vert = RotateVertex(basePoint, vertex, rotAngleX, rotAngleY, rotAngleZ);
                rotatedVertexes.Add(vert);
            }

            return rotatedVertexes;
        }
        /// <summary>
        /// Rotates gived vertex relatively current base point
        /// </summary>
        /// <param name="basePoint">The Point relatively of wich vertex will be rotated.</param>
        /// <param name="vertex">Vertex to rotate</param>
        /// <param name="rotAngleX">The rotation angle around X-axis.</param>
        /// <param name="rotAngleY">The rotation angle around Y-axis.</param>
        /// <param name="rotAngleZ">The rotation angle around Z-axis.</param>
        /// <returns>Rotated vertex.</returns>
        private Point3D RotateVertex(Point3D basePoint, Point3D vertex, double rotAngleX, double rotAngleY, double rotAngleZ)
        {
            sX = (float)Math.Sin(rotAngleX);
            cX = (float)Math.Cos(rotAngleX);

            sY = (float)Math.Sin(rotAngleY);
            cY = (float)Math.Cos(rotAngleY);

            sZ = (float)Math.Sin(rotAngleZ);
            cZ = (float)Math.Cos(rotAngleZ);

            var x = RotateX(basePoint, vertex);
            var y = RotateY(basePoint, vertex);
            var z = RotateZ(basePoint, vertex);
            return new Point3D(x, y, z);

        }

        private float RotateX(Point3D bP, Point3D p)
        {
            return p.X * (cX * cZ + sX * sY * sZ) + p.Y * (-sX * cZ + cX * sY * sZ) + p.Z * cY * sZ + cZ * (-bP.X * cX + bP.Y * sX) + ((-bP.X * sX - bP.Y * cX) * sY - bP.Z * cY) * sZ + bP.X;
            //return p.X*(cX*cZ + sX*sY*sZ) + p.Y*(-sX*cY + cX*sY*sZ) + p.Z*cY*sZ;
        }

        private float RotateY(Point3D bP, Point3D p)
        {
            return p.X * sX * cY + p.Y * cX * cY - p.Z * sY + cY * (-bP.X * sX - bP.Y * cX) + bP.Z * sY + bP.Y;
            //return p.X*sX*cY + p.Y*cX*cY - p.Z*sY;
        }

        private float RotateZ(Point3D bP, Point3D p)
        {
            return p.X * (-cX * sZ + sX * sY * cZ) + p.Y * (sX * sZ + cX * sY * cZ) + p.Z * cY * cZ + sZ * (bP.X * cX - bP.Y * sX) + ((-bP.X * sX - bP.Y * cX) * sY - bP.Z * cY) + bP.Z;
            //return p.X*(-cX*sZ + sX*sY*cZ) + p.Y*(sX*sZ + cX*sY*cZ) + p.Z*cY*cZ;
        }
        #endregion

        #region Scale
        public static Polygon ScaleSide(Point3D basePoint, Polygon polygon, float scaleX, float scaleY, float scaleZ)
        {
            var scaledEdges = new List<Edge>();
            foreach (var edge in polygon.Edges)
            {
                scaledEdges.Add(ScaleEdge(basePoint, edge, scaleX, scaleY, scaleZ));
            }
            return new Polygon { Edges = scaledEdges };
        }

        public static Edge ScaleEdge(Point3D basePoint, Edge edge, float scale)
        {
            var v1 = ScaleVertex(basePoint, edge.Vertex1, scale);
            var v2 = ScaleVertex(basePoint, edge.Vertex2, scale);
            return new Edge(v1, v2);
        }

        public static Edge ScaleEdge(Point3D basePoint, Edge edge, float scaleX, float scaleY, float scaleZ)
        {
            var v1 = ScaleVertex(basePoint, edge.Vertex1, scaleX, scaleY, scaleZ);
            var v2 = ScaleVertex(basePoint, edge.Vertex2, scaleX, scaleY, scaleZ);
            return new Edge(v1, v2);
        }

        public static Point3D ScaleVertex(Point3D basePoint, Point3D vertex, float scale)
        {
            var x = ScaleX(basePoint, vertex, scale);
            var y = ScaleY(basePoint, vertex, scale);
            var z = ScaleZ(basePoint, vertex, scale);

            return new Point3D(x, y, z);
        }

        public static Point3D ScaleVertex(Point3D basePoint, Point3D vertex, float scaleX, float scaleY, float scaleZ)
        {
            var x = ScaleX(basePoint, vertex, scaleX);
            var y = ScaleY(basePoint, vertex, scaleY);
            var z = ScaleZ(basePoint, vertex, scaleZ);

            return new Point3D(x, y, z);
        }

        public static List<Point3D> ScaleVertexes(Point3D basePoint, List<Point3D> vertexesCoordinates, float scale)
        {
            var scaledVertexes = new List<Point3D>();

            foreach (var vertex in vertexesCoordinates)
            {
                var x = ScaleX(basePoint, vertex, scale);
                var y = ScaleY(basePoint, vertex, scale);
                var z = ScaleZ(basePoint, vertex, scale);
                scaledVertexes.Add(new Point3D(x, y, z));
            }
            return scaledVertexes;
        }

        private static float ScaleX(Point3D basePoint, Point3D point, float scale)
        {
            return (point.X * scale + 1 * (basePoint.X * (1 - scale)));
        }

        private static float ScaleY(Point3D basePoint, Point3D point, float scale)
        {
            return (point.Y * scale + 1 * (basePoint.Y * (1 - scale)));
        }

        private static float ScaleZ(Point3D basePoint, Point3D point, float scale)
        {
            return (point.Z * scale + 1 * (basePoint.Z * (1 - scale)));
        }
        #endregion

        #region Move
        public static Polygon MoveSide(Polygon polygon, float dX, float dY, float dZ)
        {
            var movedEdges = new List<Edge>();
            foreach (var edge in polygon.Edges)
            {
                movedEdges.Add(MoveEdge(edge, dX, dY, dZ));
            }
            return new Polygon { Edges = movedEdges };
        }

        public static Edge MoveEdge(Edge edge, float dX, float dY, float dZ)
        {
            return new Edge(MoveXYZ(edge.Vertex1, dX, dY, dZ), MoveXYZ(edge.Vertex2, dX, dY, dZ));
        }

        public static List<Point3D> MoveVertexes(List<Point3D> vertexesCoordinates, float dX, float dY, float dZ)
        {
            var movedVertexes = new List<Point3D>();
            foreach (var vertex in vertexesCoordinates)
            {
                movedVertexes.Add(MoveXYZ(vertex, dX, dY, dZ));
            }
            return movedVertexes;
        }

        private static Point3D MoveXYZ(Point3D point, float dX, float dY, float dZ)
        {
            var pointNew = new Point3D(point.X + dX, point.Y - dY, point.Z + dZ);
            return pointNew;
        }
        #endregion

        #region Projections
        public static Polygon XYProjection(Polygon polygon)
        {
            var edges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                edges.Add(new Edge(XYProjection(edge.Vertex1), XYProjection(edge.Vertex2)));
            }
            return new Polygon { Edges = edges };
        }

        public static Polygon YZProjection(Polygon polygon)
        {
            var edges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                edges.Add(new Edge(YZProjection(edge.Vertex1), YZProjection(edge.Vertex2)));
            }
            return new Polygon { Edges = edges };
        }

        public static Polygon XZProjection(Polygon polygon)
        {
            var edges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                edges.Add(new Edge(XZProjection(edge.Vertex1), XZProjection(edge.Vertex2)));
            }
            return new Polygon { Edges = edges };
        }

        public static Polygon AksonometricProjection(Polygon polygon, double psi, double phi)
        {
            var edges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                edges.Add(new Edge(AksonometricProjection(edge.Vertex1, psi, phi), AksonometricProjection(edge.Vertex2, psi, phi)));
            }
            return new Polygon { Edges = edges };
        }

        public static Polygon BevelProjection(Polygon polygon, double L, double alpha)
        {
            var edges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                edges.Add(new Edge(BevelProjection(edge.Vertex1, L, alpha), BevelProjection(edge.Vertex2, L, alpha)));
            }
            return new Polygon { Edges = edges };
        }

        public static Polygon PerspectiveProjection(Polygon polygon, float d)
        {
            var edges = new List<Edge>();

            foreach (var edge in polygon.Edges)
            {
                edges.Add(new Edge(PerspectiveProjection(edge.Vertex1, d), PerspectiveProjection(edge.Vertex2, d)));
            }
            //return new Polygon { Edges = edges };


            var initialVerteces = polygon.Verteces;
            var newVerteces = new List<Point3D>();
            foreach (var vertex in initialVerteces)
            {
                newVerteces.Add(PerspectiveProjection(vertex, d));
            }

            return new Polygon { Verteces = newVerteces, Edges = edges };
        }

        public static Edge XYProjection(Edge edge)
        {
            return new Edge(XYProjection(edge.Vertex1), XYProjection(edge.Vertex2));
        }

        public static Edge YZProjection(Edge edge)
        {
            return new Edge(YZProjection(edge.Vertex1), YZProjection(edge.Vertex2));
        }

        public static Edge XZProjection(Edge edge)
        {
            return new Edge(XZProjection(edge.Vertex1), XZProjection(edge.Vertex2));
        }

        public static Edge AksonometricProjection(Edge edge, double psi, double phi)
        {
            return new Edge(AksonometricProjection(edge.Vertex1, psi, phi), AksonometricProjection(edge.Vertex2, psi, phi));
        }

        public static Edge BevelProjection(Edge edge, double L, double alpha)
        {
            return new Edge(BevelProjection(edge.Vertex1, L, alpha), BevelProjection(edge.Vertex2, L, alpha));
        }

        public static Edge PerspectiveProjection(Edge edge, float d)
        {
            return new Edge(PerspectiveProjection(edge.Vertex1, d), PerspectiveProjection(edge.Vertex2, d));
        }

        private static Point3D XYProjection(Point3D p)
        {
            return new Point3D(p.X, p.Y, p.Z);
        }

        private static Point3D YZProjection(Point3D p)
        {
            return new Point3D(p.Z, p.Y, p.X);
        }

        private static Point3D XZProjection(Point3D p)
        {
            return new Point3D(p.X, p.Z, p.Y);
        }

        private static Point3D AksonometricProjection(Point3D p, double psi, double phi)
        {
            var buf = MultiplyPointAndMatrix(p, GetAksonometricMatrix(psi, phi));

            return new Point3D(buf.X, buf.Y, p.Z);
        }

        private static Point3D BevelProjection(Point3D p, double L, double alpha)
        {
            var buf = MultiplyPointAndMatrix(p, GetBevelMatrix(L, alpha));

            return new Point3D(buf.X, buf.Y, p.Z);
        }

        private static Point3D PerspectiveProjection(Point3D p, float d)
        {
            // return new Point3D(p.X / (p.Z / d) + 500, p.Y / (p.Z / d) + 350, d);
            return new Point3D(p.X / ((p.Z / d) + 1), (p.Y / (p.Z / d) + 1), d);
            //return new Point3D(p.X / ((p.Z * d) + 1), (p.Y / (p.Z * d) + 1), d);
            // return new Point3D(p.X / (d * p.Z + 1) + 500, p.Y / (d * p.Z + 1) + 350, p.Z / (d * p.Z + 1));
            // return new Point3D(p.X , p.Y , 1 / d);
            // return MultiplyPointAndMatrix(p, GetPerspectiveMatrix(20 * Math.PI / 180, 30 * Math.PI / 180, 400, 1));
        }
        #endregion

        #region Math part
        private static Point3D MultiplyPointAndMatrix(Point3D point, double[,] matrix)
        {
            var pointMatrix = new double[] { point.X, point.Y, point.Z, 1 };

            var result = new double[matrix.GetLength(1)];

            for (var i = 0; i < matrix.GetLength(1); i++)
            {
                for (var k = 0; k < matrix.GetLength(1); k++)
                {
                    result[i] += pointMatrix[k] * matrix[k, i];
                }
            }

            return new Point3D((float)result[0], (float)result[1], (float)result[2]);
        }

        private static double[,] GetAksonometricMatrix(double psi, double phi)
        {
            var R = new double[4, 4];

            R[0, 0] = Math.Cos(psi); R[0, 1] = Math.Sin(phi) * Math.Sin(psi); R[0, 2] = 0; R[0, 3] = 0;

            R[1, 0] = 0; R[1, 1] = Math.Cos(phi); R[1, 2] = 0; R[1, 3] = 0;

            R[2, 0] = Math.Sin(psi); R[2, 1] = -1 * Math.Sin(phi) * Math.Cos(psi); R[2, 2] = 0; R[2, 3] = 0;

            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            return R;
        }

        private static double[,] GetBevelMatrix(double L, double alpha)
        {
            var R = new double[4, 4];

            R[0, 0] = 1; R[0, 1] = 0; R[0, 2] = 0; R[0, 3] = 0;

            R[1, 0] = 0; R[1, 1] = 1; R[1, 2] = 0; R[1, 3] = 0;

            R[2, 0] = L * Math.Cos(alpha); R[2, 1] = L * Math.Sin(alpha); R[2, 2] = 0; R[2, 3] = 0;

            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = 0; R[3, 3] = 1;

            return R;
        }

        private static double[,] GetPerspectiveMatrix(double tetta, double phi, double d, double r)
        {
            var R = new double[4, 4];

            //R[0, 0] = Math.Cos(tetta); R[0, 1] = -Math.Cos(phi) * Math.Sin(tetta); R[0, 2] = -Math.Sin(phi) * Math.Sin(tetta); R[0, 3] = 0;
            //R[1, 0] = Math.Sin(tetta); R[1, 1] = Math.Cos(phi) * Math.Cos(tetta); R[1, 2] = Math.Sin(phi) * Math.Cos(tetta); R[1, 3] = 0;
            //R[2, 0] = 0; R[2, 1] = Math.Sin(phi); R[2, 2] = -Math.Cos(phi); R[2, 3] = 0;
            //R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = r; R[3, 3] = 1;

            R[0, 0] = -Math.Sin(tetta); R[0, 1] = -Math.Cos(phi) * Math.Cos(tetta); R[0, 2] = -Math.Sin(phi) * Math.Cos(tetta); R[0, 3] = 0;
            R[1, 0] = Math.Cos(tetta); R[1, 1] = -Math.Cos(phi) * Math.Sin(tetta); R[1, 2] = -Math.Sin(phi) * Math.Sin(tetta); R[1, 3] = 0;
            R[2, 0] = 0; R[2, 1] = Math.Sin(phi); R[2, 2] = -Math.Cos(phi); R[2, 3] = 1/ d;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = r; R[3, 3] = 1;


            return R;
        }
        #endregion
    }
}
