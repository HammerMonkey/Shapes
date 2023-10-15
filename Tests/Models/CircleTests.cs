namespace Tests.Models
{
    public class CircleTests
    {
        public static IEnumerable<object[]> CircleAreaTestData()
        {
            yield return new object[] { 2.0, Math.PI * 2.0 * 2.0 };
            yield return new object[] { 3.0, Math.PI * 3.0 * 3.0 };
            yield return new object[] { 4.0, Math.PI * 4.0 * 4.0 };
        }

        public static IEnumerable<object[]> CirclePerimeterTestData()
        {
            yield return new object[] { 2.0, Math.PI * 2.0 * 2 };
            yield return new object[] { 4.0, Math.PI * 4.0 * 2 };
            yield return new object[] { 1.0, Math.PI * 1.0 * 2 };
        }

        [Theory]
        [MemberData(nameof(CircleAreaTestData))]
        public void CalculateArea(double a, double expectedArea)
        {
            // Arrange
            var circle = new Circle(a);

            // Act
            var area = circle.Area;

            // Assert
            Assert.Equal(expectedArea, area);
        }

        [Theory]
        [MemberData(nameof(CirclePerimeterTestData))]
        public void CalculatePerimeter(double a, double expectedPerimeter)
        {
            // Arrange
            var circle = new Circle(a);

            // Act
            var perimeter = circle.Perimeter;

            // Assert
            Assert.Equal(expectedPerimeter, perimeter);
        }

        [Fact]
        public void NullableInput()
        {
            //Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Circle(null));
        }

        [Fact]
        public void NegativeInput()
        {
            //Arrange, Act and Assert
            var exception = Assert.Throws<ArgumentException>(() => new Circle(-2.0));
        }
    }
}
