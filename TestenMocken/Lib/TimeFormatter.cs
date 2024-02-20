using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class TimeFormatter
    {
        private readonly ITime _Time;

        public TimeFormatter(ITime time)
        {
            _Time = time;
        }

        public string GetFormattedTime()
        {
            return _Time.ActTime.ToString("HH:mm:ss");
        }
    }
}
