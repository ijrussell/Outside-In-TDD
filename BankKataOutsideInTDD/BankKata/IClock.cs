using System;

namespace BankKata
{
    public interface IClock
    {
        DateTime UtcNow { get; }
    }
}