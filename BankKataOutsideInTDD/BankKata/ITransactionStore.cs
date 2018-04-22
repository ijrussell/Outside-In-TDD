using System.Collections.Generic;

namespace BankKata
{
    public interface ITransactionStore
    {
        void AddTransaction(int amount);
        List<Transaction> AllTransactions();
    }
}