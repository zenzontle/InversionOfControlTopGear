using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC
{
    public interface IClock
    {
        DateTime Now { get; }
    }
}
