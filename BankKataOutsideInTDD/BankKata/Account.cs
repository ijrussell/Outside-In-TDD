namespace BankKata
{
    public class Account
    {
        private readonly ITransactionStore _transactionStore;
        private readonly IStatementPrinter _statementPrinter;

        public Account(ITransactionStore transactionStore, IStatementPrinter statementPrinter)
        {
            _transactionStore = transactionStore;
            _statementPrinter = statementPrinter;
        }

        public void Deposit(int amount)
        {
            _transactionStore.AddTransaction(amount);
        }

        public void Withdraw(int amount)
        {
            _transactionStore.AddTransaction(-amount);
        }

        public void PrintStatement()
        {
            var transactions = _transactionStore.AllTransactions();
            _statementPrinter.PrintStatement(transactions);
        }
    }
}