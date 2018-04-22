using System;
using System.Runtime.Remoting;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class ClockShould
    {
        [Test]
        public void ReturnExpectedDate()
        {
            var today = new DateTime(2015, 3, 13);

            var clock = new TestableClock(today);

            var actual = clock.UtcNow;

            Assert.That(actual, Is.EqualTo(today));
        }

    }
}