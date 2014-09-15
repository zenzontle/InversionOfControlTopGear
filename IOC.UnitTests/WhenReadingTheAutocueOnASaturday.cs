using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IOC.App;
using Shouldly;
using NUnit.Framework;

namespace IOC.UnitTests
{
    [TestFixture]
    public class WhenReadingTheAutocueOnASaturday
    {
        [Test]
        public void TheMessageShouldBeYoureWrong()
        {
            var clock = new SaturdayClock();
            var autocue = new Autocue(clock);

            var message = autocue.GetSomethingIntelligent();

            message.ShouldBe(Autocue.YoureWrongMessage);
        }

        public class SaturdayClock: IClock
        {
            public DateTime Now
            {
                get { return new DateTime(2012, 12, 01, 13, 00, 00); } }
        }
    }
}
