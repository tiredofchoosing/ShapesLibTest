using System;

namespace Shapes
{
    public struct Circle : IShape
    {
        private readonly double radius;
        
        public Circle(double radius)
        {
            if (!double.IsFinite(radius))
                throw new ArgumentException($"Значение {radius} не может быть использовано в качестве радиуса.");

            this.radius = Math.Abs(radius);
        }

        public double GetArea()
        {
            double area = Math.PI * radius * radius;

            if (double.IsInfinity(area))
                throw new OverflowException();

            return area;
        }
    }
}
