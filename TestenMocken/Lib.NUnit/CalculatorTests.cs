namespace Lib.NUnit
{
    public class CalculatorTests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void Add_ShouldBeRight()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            double res = calc.Add(1, 1);


            // Assert
            Assert.That(res, Is.EqualTo(2));
        }

        [Test]
        public void Multiply_ShouldBeRight()
        {

            // Arrange
            Calculator calc = new Calculator();

            // Act
            double res = calc.Multiply(1, 1);

            // Assert
            Assert.That(res, Is.EqualTo(1));
        }
    }
}