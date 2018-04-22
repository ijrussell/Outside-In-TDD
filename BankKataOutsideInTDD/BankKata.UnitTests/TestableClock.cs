using System;

namespace BankKata.UnitTests
{
    public class TestableClock : IClock
    {
        public TestableClock(DateTime today)
        {
            UtcNow = today;
        }

        public DateTime UtcNow { get; }
    }
}