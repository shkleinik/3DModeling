using Modeling.Core.Elements;

namespace Modeling.Core.Shapes
{
    public class Cone : Pyramid
    {
        private const int ApporximationLevel = 15;

        public Cone(Point3D basePoint, float radius, float height) : base(basePoint, ApporximationLevel, radius, height) { }
    }
}