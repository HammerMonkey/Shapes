namespace Tests.Models
{
    public class RectangleTests
    {
        public static IEnumerable<object[]> RectangleAreaTestData()
        {
            yield return new object[] { 2.0, 3.0, 6.0 };
            yield return new object[] { 4.0, 5.0, 20.0 };
            yield return new object[] { 1.0, 10.0, 10.0 };
        }

        public static IEnumerable<object[]> RectanglePerimeterTestData()
        {
            yield return new object[] { 2.0, 3.0, 10.0 };
            yield return new object[] { 4.0, 5.0, 18.0 };
            yield return new object[] { 1.0, 10.0, 22.0 };
        }

        [Theory]
        [MemberData(nameof(RectangleAreaTestData))]
        public void CalculateArea(double a, double b, double expectedArea)
        {
            // Arrange
            var rectangle = new Rectangle(a, b);

            // Act
            var area = rectangle.Area;

            // Assert
            Assert.Equal(expectedArea, area);
        }

        [Theory]
        [MemberData(nameof(RectanglePerimeterTestData))]
        public void CalculatePerimeter(double a, double b, double expectedPerimeter)
        {
            // Arrange
            var rectangle = new Rectangle(a, b);

            // Act
            var perimeter = rectangle.Perimeter;

            // Assert
            Assert.Equal(expectedPerimeter, perimeter);
        }

        [Fact]
        public void NullableInput()
        {
            //Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Rectangle(2.0, null));
        }

        [Fact]
        public void NegativeInput()
        {
            //Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Rectangle(2.0, -2.0));
        }
    }
}
