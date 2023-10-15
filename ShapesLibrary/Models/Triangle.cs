using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models
{
    public class Triangle : IFigure
    {
        public double Area { get; }
        public double Perimeter { get; }

        public double A { get; }
        public double B { get; }
        public double C { get; }

        public Triangle(double? a, double? b, double? c)
        {
            if (a != null && a > 0 && b != null && b > 0 && c != null && c > 0)
            {
                A = (double)a;
                B = (double)b;
                C = (double)c;
            }
            else
            {
                throw new ArgumentException($"{nameof(Triangle)} has invalid input");
            }
            Area = CalculateArea();
            Perimeter = CalculatePerimeter();
        }

        private double CalculatePerimeter()
        {
            return A + B + C;
        }

        private double CalculateArea()
        {
            // Using Heron's formula we can calculate the area with sides A, B, C
            // Firstly, we need to calculate component p:
            double p = (A + B + C) / 2.0;
            // Now we use the whole formula:
            return Math.Sqrt(p * (p - A) * (p - B) * (p - C));
        }
    }
}
