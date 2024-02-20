namespace Lib.MsTest
{
    [TestClass]
    public class CalculatorTests
    {
        [TestMethod]
        public void Add_ShoudBeRight()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            double res = calc.Add(1, 1);

            // Assert
            Assert.AreEqual(2, res);
        }

        [TestMethod]
        public void Multiplay_ShouldBeRight()
        {
            // Arrange
            Calculator calc = new Calculator();

            // Act
            double res = calc.Multiply(1, 1);

            // Assert
            Assert.AreEqual(1, res);
        }
    }
}