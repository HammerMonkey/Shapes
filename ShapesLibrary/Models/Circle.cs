using ShapesLibrary.Interfaces;

namespace ShapesLibrary.Models
{
    public class Circle : IFigure
    {
        public double Area { get; }
        public double Perimeter { get; }

        public double Radius { get; }

        public Circle(double? radius)
        {
            if (radius == null || radius <= 0)
            {
                throw new ArgumentException($"{nameof(Circle)} has invalid input");
            }

            Radius = (double)radius;
            Area = CalculateArea();
            Perimeter = CalculatePerimeter();
        }

        public override string ToString()
        {
            return $"a = {Radius}, area = {Area}, perimeter";
        }

        private double CalculateArea()
        {
            return Math.PI * Radius * Radius;
        }

        private double CalculatePerimeter()
        {
            return 2 * Math.PI * Radius;
        }
    }
}
