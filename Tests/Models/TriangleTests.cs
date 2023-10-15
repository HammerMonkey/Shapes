namespace Tests.Models
{
    public class TriangleTests
    {
        public static IEnumerable<object[]> TriangleAreaTestData()
        {
            yield return new object[] { 3, 4, 5, 6 };
            yield return new object[] { 1.5, 2, 2.5, 1.5 };
            yield return new object[] { 6, 8, 10, 24 };
        }

        public static IEnumerable<object[]> TrianglePerimeterTestData()
        {
            yield return new object[] { 3, 4, 5, 12 };
            yield return new object[] { 1.5, 2, 2.5, 6 };
            yield return new object[] { 6, 8, 10, 24 };
        }

        [Theory]
        [MemberData(nameof(TriangleAreaTestData))]
        public void CalculateArea(double a, double b, double c, double expectedArea)
        {
            // Arrange
            var triangle = new Triangle(a, b, c);

            // Act
            var area = triangle.Area;

            // Assert
            Assert.Equal(expectedArea, area);
        }

        [Theory]
        [MemberData(nameof(TrianglePerimeterTestData))]
        public void CalculatePerimeter(double a, double b, double c, double expectedPerimeter)
        {
            // Arrange
            var triangle = new Triangle(a, b, c);

            // Act
            var perimeter = triangle.Perimeter;

            // Assert
            Assert.Equal(expectedPerimeter, perimeter);
        }

        [Fact]
        public void NullableInput()
        {
            //Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(5.0, 3.0, null));
        }

        [Fact]
        public void NegativeInput()
        {
            //Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Triangle(1.2, 2.0, -2.0));
        }
    }
}
