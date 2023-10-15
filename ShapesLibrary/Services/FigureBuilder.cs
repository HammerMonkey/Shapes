using ShapesLibrary.Interfaces;
using ShapesLibrary.Models;
using ShapesLibrary.Models.XmlModels;

namespace ShapesLibrary.Services
{
    public class FigureBuilder
    {
        public static IEnumerable<IFigure> BuildFigures(Shapes shapes)
        {
            var figureList = new List<IFigure>();

            foreach (var shape in shapes.ShapesList ?? new List<Shape>())
            {
                IFigure newFigure;

                switch (shape.Type)
                {
                    case FigureType.Circle:
                        newFigure = new Circle(shape.A);
                        break;
                    case FigureType.Rectangle:
                        newFigure = new Rectangle(shape.A, shape.B);
                        break;
                    case FigureType.Triangle:
                        newFigure = new Triangle(shape.A, shape.B, shape.C);
                        break;
                    default:
                        continue;
                }

                figureList.Add(newFigure);
            }
            return figureList;
        }
    }
}
