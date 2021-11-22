using System;

namespace Shapes
{
    public struct Triangle : IShape
    {
        private readonly double a, b, c;

        private static string ArgExcMessage(double val) => $"Значение \"{val}\" не может быть использовано в качестве стороны треугольника.";

        public Triangle(double a, double b, double c)
        {
            if (!double.IsFinite(a))
                throw new ArgumentException(ArgExcMessage(a));

            if (!double.IsFinite(b))
                throw new ArgumentException(ArgExcMessage(b));

            if (!double.IsFinite(c))
                throw new ArgumentException(ArgExcMessage(c));

            a = Math.Abs(a);
            b = Math.Abs(b);
            c = Math.Abs(c);

            if (!TriangleExist(a, b, c))
                throw new ArgumentException($"Не существует треугольника со сторонами ({a}, {b} и {c}).");

            this.a = a;
            this.b = b;
            this.c = c;
        }

        public double GetArea()
        {
            double p = (a + b + c) / 2;
            double area = Math.Sqrt(p * (p - a) * (p - b) * (p - c));

            if (double.IsInfinity(area))
                throw new OverflowException();

            return area;
        }

        public bool IsRight(double delta = 0)
        {
            if (a > b && a > c)
                return CheckRight(a, b, c, delta);

            if (b > a && b > c)
                return CheckRight(b, a, c, delta);

            if (c > a && c > b)
                return CheckRight(c, b, a, delta);

            return false;
        }

        private static bool CheckRight(double hyp, double cat1, double cat2, double delta)
        {
            double sqrt = Math.Sqrt(cat1 * cat1 + cat2 * cat2);
            return Math.Abs(hyp - sqrt) <= delta;
        }
        private static bool TriangleExist(double a, double b, double c)
        {
            if (a > b && a > c)
                return a <= b + c;

            if (b > a && b > c)
                return b <= a + c;

            if (c > a && c > b)
                return c <= b + a;

            return true;
        }
    }
}
