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
        public Polygon RotatePolygon(Vertex basePoint, Polygon polygon, double angleX, double angleY, double angleZ)
        {
            var rotatedVerteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                rotatedVerteces.Add(RotateVertex(basePoint, vertex, angleX, angleY, angleZ));
            }

            return new Polygon { Verteces = rotatedVerteces };
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
        private Vertex RotateVertex(Vertex basePoint, Vertex vertex, double rotAngleX, double rotAngleY, double rotAngleZ)
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
            return new Vertex(x, y, z);

        }

        private float RotateX(Vertex bP, Vertex p)
        {
            return p.X * (cX * cZ + sX * sY * sZ) + p.Y * (-sX * cZ + cX * sY * sZ) + p.Z * cY * sZ + cZ * (-bP.X * cX + bP.Y * sX) + ((-bP.X * sX - bP.Y * cX) * sY - bP.Z * cY) * sZ + bP.X;
            //return p.X*(cX*cZ + sX*sY*sZ) + p.Y*(-sX*cY + cX*sY*sZ) + p.Z*cY*sZ;
        }

        private float RotateY(Vertex bP, Vertex p)
        {
            return p.X * sX * cY + p.Y * cX * cY - p.Z * sY + cY * (-bP.X * sX - bP.Y * cX) + bP.Z * sY + bP.Y;
            //return p.X*sX*cY + p.Y*cX*cY - p.Z*sY;
        }

        private float RotateZ(Vertex bP, Vertex p)
        {
            return p.X * (-cX * sZ + sX * sY * cZ) + p.Y * (sX * sZ + cX * sY * cZ) + p.Z * cY * cZ + sZ * (bP.X * cX - bP.Y * sX) + ((-bP.X * sX - bP.Y * cX) * sY - bP.Z * cY) + bP.Z;
            //return p.X*(-cX*sZ + sX*sY*cZ) + p.Y*(sX*sZ + cX*sY*cZ) + p.Z*cY*cZ;
        }
        #endregion

        #region Scale
        public static Polygon ScalePolygon(Vertex basePoint, Polygon polygon, float scaleX, float scaleY, float scaleZ)
        {
            var scaledVerteces = new List<Vertex>();
            foreach (var vertex in polygon.Verteces)
            {
                scaledVerteces.Add(ScaleVertex(basePoint, vertex, scaleX, scaleY, scaleZ));
            }
            return new Polygon { Verteces = scaledVerteces };
        }

        public static Vertex ScaleVertex(Vertex basePoint, Vertex vertex, float scaleX, float scaleY, float scaleZ)
        {
            var x = ScaleX(basePoint, vertex, scaleX);
            var y = ScaleY(basePoint, vertex, scaleY);
            var z = ScaleZ(basePoint, vertex, scaleZ);

            return new Vertex(x, y, z);
        }

        private static float ScaleX(Vertex basePoint, Vertex point, float scale)
        {
            return (point.X * scale + 1 * (basePoint.X * (1 - scale)));
        }

        private static float ScaleY(Vertex basePoint, Vertex point, float scale)
        {
            return (point.Y * scale + 1 * (basePoint.Y * (1 - scale)));
        }

        private static float ScaleZ(Vertex basePoint, Vertex point, float scale)
        {
            return (point.Z * scale + 1 * (basePoint.Z * (1 - scale)));
        }
        #endregion

        #region Move
        public static Polygon MovePolygon(Polygon polygon, float dX, float dY, float dZ)
        {
            var movedVerteces = new List<Vertex>();
            foreach (var vertex in polygon.Verteces)
            {
                movedVerteces.Add(MoveVertex(vertex, dX, dY, dZ));
            }
            return new Polygon { Verteces = movedVerteces };
        }

        private static Vertex MoveVertex(Vertex point, float dX, float dY, float dZ)
        {
            var pointNew = new Vertex(point.X + dX, point.Y - dY, point.Z + dZ);
            return pointNew;
        }
        #endregion

        #region Projections
        public static Polygon XYProjection(Polygon polygon)
        {
            var verteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                verteces.Add(XYProjection(vertex));
            }
            return new Polygon { Verteces = verteces };
        }

        public static Polygon YZProjection(Polygon polygon)
        {
            var verteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                verteces.Add(YZProjection(vertex));
            }
            return new Polygon { Verteces = verteces };
        }

        public static Polygon XZProjection(Polygon polygon)
        {
            var verteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                verteces.Add(XZProjection(vertex));
            }
            return new Polygon { Verteces = verteces };
        }

        public static Polygon AksonometricProjection(Polygon polygon, double psi, double phi)
        {
            var verteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                verteces.Add(AksonometricProjection(vertex, psi, phi));
            }
            return new Polygon { Verteces = verteces };
        }

        public static Polygon BevelProjection(Polygon polygon, double L, double alpha)
        {
            var verteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                verteces.Add(BevelProjection(vertex, L, alpha));
            }
            return new Polygon { Verteces = verteces };
        }

        public static Polygon PerspectiveProjection(Polygon polygon, float d)
        {
            //var edges = new List<Edge>();

            //foreach (var edge in polygon.Edges)
            //{
            //    edges.Add(new Edge(PerspectiveProjection(edge.Vertex1, d), PerspectiveProjection(edge.Vertex2, d)));
            //}

            var verteces = new List<Vertex>();

            foreach (var vertex in polygon.Verteces)
            {
                verteces.Add(PerspectiveProjection(vertex, d));
            }

            return new Polygon { Verteces = verteces };
        }

        private static Vertex XYProjection(Vertex p)
        {
            return new Vertex(p.X, p.Y, p.Z);
        }

        private static Vertex YZProjection(Vertex p)
        {
            return new Vertex(p.Z, p.Y, p.X);
        }

        private static Vertex XZProjection(Vertex p)
        {
            return new Vertex(p.X, p.Z, p.Y);
        }

        private static Vertex AksonometricProjection(Vertex p, double psi, double phi)
        {
            var buf = MultiplyPointAndMatrix(p, GetAksonometricMatrix(psi, phi));

            return new Vertex(buf.X, buf.Y, p.Z);
        }

        private static Vertex BevelProjection(Vertex p, double L, double alpha)
        {
            var buf = MultiplyPointAndMatrix(p, GetBevelMatrix(L, alpha));

            return new Vertex(buf.X, buf.Y, p.Z);
        }

        private static Vertex PerspectiveProjection(Vertex p, float d)
        {
            // return new Point3D(p.X / (p.Z / d) + 500, p.Y / (p.Z / d) + 350, d);
            return new Vertex(p.X / ((p.Z / d) + 1), (p.Y / (p.Z / d) + 1), d);
            //return new Point3D(p.X / ((p.Z * d) + 1), (p.Y / (p.Z * d) + 1), d);
            // return new Point3D(p.X / (d * p.Z + 1) + 500, p.Y / (d * p.Z + 1) + 350, p.Z / (d * p.Z + 1));
            // return new Point3D(p.X , p.Y , 1 / d);
            // return MultiplyPointAndMatrix(p, GetPerspectiveMatrix(20 * Math.PI / 180, 30 * Math.PI / 180, 400, 1));
        }
        #endregion

        #region Math part
        private static Vertex MultiplyPointAndMatrix(Vertex point, double[,] matrix)
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

            return new Vertex((float)result[0], (float)result[1], (float)result[2]);
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
            R[2, 0] = 0; R[2, 1] = Math.Sin(phi); R[2, 2] = -Math.Cos(phi); R[2, 3] = 1 / d;
            R[3, 0] = 0; R[3, 1] = 0; R[3, 2] = r; R[3, 3] = 1;


            return R;
        }
        #endregion
    }
}