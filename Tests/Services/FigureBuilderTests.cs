using ShapesLibrary.Models.XmlModels;

namespace Tests.Services
{
    public class FigureBuilderTests
    {
        [Fact]
        public void BuildFigures_ShouldBuildCircle()
        {
            // Arrange
            var shapes = new Shapes { ShapesList = new List<Shape> { new Shape { Type = FigureType.Circle, A = 5.0 } } };

            // Act
            IEnumerable<ShapesLibrary.Interfaces.IFigure> figures = FigureBuilder.BuildFigures(shapes);

            // Assert
            Assert.Single(figures); // Ensure one figure is created
            var circle = figures.First() as Circle;
            Assert.NotNull(circle);
            Assert.Equal(5.0, circle.Radius);
        }

        [Fact]
        public void BuildFigures_ShouldBuildRectangle()
        {
            // Arrange
            var shapes = new Shapes { ShapesList = new List<Shape> { new Shape { Type = FigureType.Rectangle, A = 3.0, B = 4.0 } } };

            // Act
            var figures = FigureBuilder.BuildFigures(shapes);

            // Assert
            Assert.Single(figures);
            var rectangle = figures.First() as Rectangle;
            Assert.NotNull(rectangle);
            Assert.Equal(3.0, rectangle.A);
            Assert.Equal(4.0, rectangle.B);
        }

        [Fact]
        public void BuildFigures_ShouldBuildTriangle()
        {
            // Arrange
            var shapes = new Shapes { ShapesList = new List<Shape> { new Shape { Type = FigureType.Triangle, A = 3.0, B = 4.0, C = 5.0 } } };

            // Act
            var figures = FigureBuilder.BuildFigures(shapes);

            // Assert
            Assert.Single(figures);
            Assert.IsType<Triangle>(figures.First());
            var triangle = (Triangle)figures.First();
            Assert.Equal(3.0, triangle.A);
            Assert.Equal(4.0, triangle.B);
            Assert.Equal(5.0, triangle.C);
        }

        [Fact]
        public void BuildFigures_ShouldSkipInvalidShape()
        {
            // Arrange
            var shapes = new Shapes { ShapesList = new List<Shape> { new Shape { Type = "InvalidType" } } };

            // Act
            var figures = FigureBuilder.BuildFigures(shapes);

            // Assert
            Assert.Empty(figures);
        }

        [Fact]
        public void BuildFigures_ShouldThrowErrorWhenSideIsNull()
        {
            // Arrange
            var shapes = new Shapes { ShapesList = new List<Shape> { new Shape { Type = FigureType.Triangle, A = 3.0, B = 4.0, C = null } } };

            // Act and Assert
            Assert.Throws<ArgumentException>(() => FigureBuilder.BuildFigures(shapes));
        }
    }
}
