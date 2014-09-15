using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC
{
    public class SystemClock : IClock
    {
        public DateTime Now
        {
            get { return DateTime.Now; }
        }
    }
}
