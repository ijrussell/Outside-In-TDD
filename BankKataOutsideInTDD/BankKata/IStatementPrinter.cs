using System.Collections.Generic;

namespace BankKata
{
    public interface IStatementPrinter
    {
        void PrintStatement(List<Transaction> transactions);
    }
}