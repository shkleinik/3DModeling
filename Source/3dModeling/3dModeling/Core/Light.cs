//-----------------------------------------------------------------------
// <copyright file="Light.cs" company="Walash Ltd.">
//     Copyright (c) Walash Ltd. All rights reserved.
// </copyright>
// <author>Pavel Shkleinik</author>
//-----------------------------------------------------------------------

using System;
using System.Drawing;

namespace Modeling.Core
{
    using Elements;
    using L = Light;

    public static class Light
    {
        public static Vertex GetNormal(Polygon polygon)
        {
            var vertices = polygon.Verteces;

            var VecA = new Vertex(vertices[1].X - vertices[0].X, vertices[1].Y - vertices[0].Y, vertices[1].Z - vertices[0].Z);
            var VecB = new Vertex(vertices[2].X - vertices[1].X, vertices[2].Y - vertices[1].Y, vertices[2].Z - vertices[1].Z);
            return new Vertex(VecA.Y * VecB.Z - VecA.Z * VecB.Y, VecA.X * VecB.Z - VecA.Z * VecB.X, VecA.X * VecB.Y - VecA.Y * VecB.X);
        }

        public static double GetNormalLength(Vertex normal)
        {
            return Math.Sqrt(Math.Pow(normal.X, 2) + Math.Pow(normal.Y, 2) + Math.Pow(normal.Z, 2));
        }

        public static object GetNormalLength(Polygon polygon)
        {
            var normal = GetNormal(polygon);

            return GetNormalLength(normal);
        }

        public static double GetAngleBetweenNormals(Vertex normal1, Vertex normal2)
        {
            var length1 = GetNormalLength(normal1);
            var length2 = GetNormalLength(normal2);

            if (length1 == 0 || length2 == 0)
                return -1;

            return (normal1.X * normal2.X + normal1.Y * normal2.Y + normal1.Z * normal2.Z) / (length1 * length2);
        }

        public static Color GetHalfToneColorFromBaseAndAngleCosinus(double cosAngle, Color baseColor)
        {
            return Color.FromArgb(
                (int) (baseColor.R*(0.5 + 0.5*cosAngle)),
                (int) (baseColor.G*(0.5 + 0.5*cosAngle)),
                (int) (baseColor.B*(0.5 + 0.5*cosAngle))
                );
        }

        public static Color GetHalfToneColorForPolygon(Polygon polygon, Color baseColor/*, Vertex lightSource*/)
        {
            var lightSource = new Vertex(-1000, 0, 0);
            var normal = GetNormal(polygon);

            var cosBetweenNormals = GetAngleBetweenNormals(normal, lightSource);

            return GetHalfToneColorFromBaseAndAngleCosinus(cosBetweenNormals, baseColor);
        }
    }
}