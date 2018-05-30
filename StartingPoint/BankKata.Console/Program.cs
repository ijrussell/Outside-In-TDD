namespace BankKata.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var account = new Account();

            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            System.Console.ReadLine();
        }
    }
}
