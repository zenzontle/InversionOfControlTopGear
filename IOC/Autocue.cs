using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace IOC.App
{
    public class Autocue
    {
        public static string YoureWrongMessage = "You're wrong!";
        private readonly IClock _clock;

        public Autocue(IClock clock)
        {
            _clock = clock;
        }

        public string GetSomethingIntelligent()
        {
            DateTime now = _clock.Now;

            if (now.DayOfWeek == DayOfWeek.Tuesday)
            {
                if (now.Hour >= 18 && now.Hour < 20)
                {
                    return "Good evening!";
                }
                else if (now.Hour >= 20)
                {
                    return "Get out of the way!";
                }
            }
            else
            {
                return YoureWrongMessage;
            }
            return YoureWrongMessage;
        }
    }
}
