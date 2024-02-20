using System.Reflection;
using System.Runtime.CompilerServices;

[assembly: InternalsVisibleTo("Lib.NUnit")]
[assembly: InternalsVisibleTo("Lib.MsTest")]
[assembly: InternalsVisibleTo("Lib.XUnit")]
namespace Lib
{

    
    internal class Calculator
    {
        public double Add(double x, double y)
        {
            return x + y;
        }

        internal double Multiply(double x, double y)
        {
            return x * y;
        }
    }
}
