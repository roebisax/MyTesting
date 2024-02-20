using Moq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib.NUnit
{
    internal class TimeFormatterTests
    {

        [Test]
        public void GetFormattedTime_ShouldBeRight()
        {
            // Arrange
            var timeMock = new Mock<ITime>();
            timeMock.Setup(t => t.ActTime).Returns(new DateTime(2000, 1, 1, 8, 12, 20));

            TimeFormatter timeFormatter = new TimeFormatter(timeMock.Object);

            // Act 
            string res = timeFormatter.GetFormattedTime();

            // Assert
            Assert.That(res, Is.EqualTo("08:12:20"));
        }
    }
}
