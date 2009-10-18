﻿using System;
using System.Collections.Generic;
using Modeling.Core.Elements;

namespace Modeling.Core
{
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
        public Edge RotateEdge(Point3D basePoint, Edge edge, double angleX, double angleY, double angleZ)
        {
            var v1 = RotateVertex(basePoint, edge.Vertex1, angleX, angleY, angleZ);
            var v2 = RotateVertex(basePoint, edge.Vertex2, angleX, angleY, angleZ);
            return new Edge(v1, v2);
        }
        /// <summary>
        /// Rotates gived coordinates relatively current base point
        /// </summary>
        /// <param name="basePoint">The Point relative wich vertexes will rotate.</param>
        /// <param name="vertexes">Coordinates of vertexes wich you want to rotate.</param>
        /// <param name="rotAngleY"></param>
        /// <param name="rotAngleZ">Rotation angle in radians.</param>
        /// <param name="rotAngleX"></param>
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

        private static Point3D XYProjection(Point3D p)
        {
            return new Point3D(p.X, p.Y, 0);
        }

        private static Point3D YZProjection(Point3D p)
        {
            return new Point3D(0, p.Y, p.Z);
        }

        private static Point3D XZProjection(Point3D p)
        {
            return new Point3D(p.X, 0, p.Z);
        }
        #endregion
    }
}
