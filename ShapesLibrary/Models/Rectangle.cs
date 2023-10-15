using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models
{
    public class Rectangle : IFigure
    {
        public double Area { get; }
        public double Perimeter { get; }

        public double A { get; }
        public double B { get; }

        public Rectangle(double? a, double? b)
        {
            if (a != null && a > 0 && b != null && b > 0)
            {
                A = (double)a;
                B = (double)b;
            }
            else
            {
                throw new ArgumentException($"{nameof(Rectangle)} has invalid input");
            }

            Area = CalculateArea();
            Perimeter = CalculatePerimeter();
        }

        private double CalculateArea()
        {
            return A * B;
        }

        private double CalculatePerimeter()
        {
            return 2 * (A + B);
        }
    }
}
