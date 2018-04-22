using System;
using System.Collections.Generic;

namespace BankKata
{
    public class TransactionStore : ITransactionStore
    {
        private readonly IClock _clock;
        private readonly List<Transaction> transactions;

        public TransactionStore(IClock clock)
        {
            _clock = clock;
            transactions = new List<Transaction>();
        }

        public void AddTransaction(int amount)
        {
            transactions.Add(new Transaction(_clock.UtcNow, amount));
        }

        public List<Transaction> AllTransactions()
        {
            return transactions;
        }
    }
}