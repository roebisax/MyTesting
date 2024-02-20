using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Time : ITime
    {
        public DateTime ActTime => DateTime.Now;
    }
}
