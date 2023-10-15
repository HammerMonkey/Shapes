using ShapesLibrary.Interfaces;
using ShapesLibrary.Models;
using System.Text;

namespace ShapesLibrary.Services
{
    public class FigureExporter
    {
        public static void SaveFigures(IEnumerable<IFigure> figureList, string directory)
        {
            ExportFigures(figureList, directory);
        }

        public static List<(string name, string description)> CreateFigureDescription(IEnumerable<IFigure> figureList)
        {
            return ExportFigures(figureList, null);
        }

        public static void SaveFigureDescription(string filePath, List<(string name, string description)> figureDescription)
        {
            foreach (var figure in figureDescription)
            {
                File.WriteAllText(Path.Combine(filePath, $"{figure.name}.txt"), figure.description);
            }
        }

        private static List<(string name, string description)> ExportFigures(IEnumerable<IFigure> figureList, string? directory)
        {
            var figureTypes = new List<string>
            {
            FigureType.Circle,
            FigureType.Rectangle,
            FigureType.Triangle
            };

            var figureDescriptions = new List<(string name, string description)>();

            foreach (string figureType in figureTypes)
            {
                var sortedFigureList = figureList
                    .Where(figure => figure.GetType().Name == figureType)
                    .ToList() ?? new List<IFigure>();

                var contentBuilder = new StringBuilder();
                contentBuilder.AppendLine(figureType);
                contentBuilder.AppendLine($"Number of records: {sortedFigureList.Count}");

                foreach (IFigure shape in sortedFigureList)
                {
                    contentBuilder.AppendLine(GetProperties(shape));
                }

                figureDescriptions.Add((figureType, contentBuilder.ToString()));

                if (directory != null)
                {
                    string filePath = Path.Combine(directory, $"{figureType}.txt");
                    File.WriteAllText(filePath, contentBuilder.ToString());
                }
            }

            return figureDescriptions;
        }

        private static string GetProperties(IFigure figure)
        {
            var areaRounded = Math.Round(figure.Area, 2);
            var perimeterRounded = Math.Round(figure.Perimeter, 2);

            return figure switch
            {
                Circle circle => $"a = {circle.Radius}, area = {areaRounded}, perimeter = {perimeterRounded}",
                Rectangle rectangle => $"a = {rectangle.A}, b = {rectangle.B}, area = {areaRounded}, perimeter = {perimeterRounded}",
                Triangle triangle => $"a = {triangle.A}, b = {triangle.B}, c = {triangle.C}, area = {areaRounded}, perimeter = {perimeterRounded}",
                _ => string.Empty,
            };
        }
    }
}
