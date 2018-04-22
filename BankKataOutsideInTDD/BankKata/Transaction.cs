using System;

namespace BankKata
{
    public class Transaction
    {
        public Transaction(DateTime createdDate, int amount)
        {
            CreatedDate = createdDate;
            Amount = amount;
        }

        public DateTime CreatedDate { get; }
        public int Amount { get; }
    }
}