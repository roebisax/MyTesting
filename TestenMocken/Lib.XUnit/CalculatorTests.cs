using System.Net.Http.Headers;

namespace Lib.XUnit
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_ShouldBeRight()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            double res = calc.Add(1, 1);

            // Assert
            Assert.Equal(2, res);
        }

        [Fact]
        public void Multiply_ShouldBeRight()
        {

            // Arrange
            Calculator calc = new Calculator();

            // Act
            double res = calc.Multiply(1, 1);

            // Assert
            Assert.Equal(1, res);
        }
    }
}