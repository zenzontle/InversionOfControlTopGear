using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using IOC;

namespace IOC.App
{
    public class Clarkson : IDisposable
    {
        private readonly Autocue _autocue;
        private readonly Megaphone _megaphone;
        private readonly Glasses _glasses;

        public Clarkson(Autocue autocue, Megaphone megaphone, Glasses glasses)
        {
            _autocue = autocue;
            _megaphone = megaphone;
            _glasses = glasses;
        }

        public void ShoutSomething()
        {
            var message = _autocue.GetSomethingIntelligent();
            var readableMessage = _glasses.Magnify(message);
            _megaphone.Shout(message);
        }

        public void Dispose()
        {
            _megaphone.Shout("On that bombshell...");
        }
    }
}
