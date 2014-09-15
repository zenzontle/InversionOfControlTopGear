using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IOC.App
{
    public class Megaphone
    {
        public void Shout(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message.ToUpperInvariant());
        }
    }
}
