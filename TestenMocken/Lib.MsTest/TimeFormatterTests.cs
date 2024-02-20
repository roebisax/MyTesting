using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.MsTest
{
    [TestClass]
    public class TimeFormatterTests
    {

        [TestMethod]
        public void GetFormattedTime_ShouldBeRight()
        {
            // Arrange
            var timeMock = new Mock<ITime>();
            timeMock.Setup(t => t.ActTime).Returns(new DateTime(2000,1,1,8,12,20));

            TimeFormatter timeFormatter = new TimeFormatter(timeMock.Object);

            // Act 
            string res = timeFormatter.GetFormattedTime();

            // Assert
            Assert.AreEqual("08:12:20", res);
        }
    }
}
