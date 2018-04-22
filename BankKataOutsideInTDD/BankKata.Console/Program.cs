namespace BankKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var transactionStore = new TransactionStore(new Clock());
            var statementPrinter = new StatementPrinter(new DefaultConsole());
            var account = new Account(transactionStore, statementPrinter);

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            System.Console.ReadLine();
        }
    }
}
