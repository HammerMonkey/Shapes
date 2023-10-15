using ShapesLibrary.Interfaces;

namespace Tests.Services
{
    public class FigureExporterTests
    {
        [Fact]
        public void CreateFigureDescription_ShouldCreateFigureDescriptions()
        {
            // Arrange
            var figureList = new List<IFigure>
            {
                new Circle(5.0),
                new Rectangle(3.0, 4.0),
                new Triangle(3.0, 4.0, 5.0),
            };

            // Act
            var figureDescriptions = FigureExporter.CreateFigureDescription(figureList);

            // Assert
            Assert.NotEmpty(figureDescriptions);
            Assert.Equal(3, figureDescriptions.Count);
        }
    }
}
