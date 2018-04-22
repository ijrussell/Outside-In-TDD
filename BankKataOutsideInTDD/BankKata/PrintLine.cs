using System;

namespace BankKata
{
    public class PrintLine
    {
        public DateTime CreatedDate { get; }
        public int Amount { get; }
        public int Balance { get; }

        public PrintLine(DateTime createdDate, int amount, int balance)
        {
            CreatedDate = createdDate;
            Amount = amount;
            Balance = balance;
        }

        public override string ToString()
        {
            return CreatedDate.ToShortDateString() + " | " + Amount + " | " + Balance;
        }
    }
}