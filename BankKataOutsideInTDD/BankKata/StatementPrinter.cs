using System.Collections.Generic;

namespace BankKata
{
    public class StatementPrinter : IStatementPrinter
    {
        private readonly IConsole _console;

        public StatementPrinter(IConsole console)
        {
            _console = console;
        }

        public void PrintStatement(List<Transaction> transactions)
        {
            _console.PrintLine("DATE | AMOUNT | BALANCE");

            var lines = new List<PrintLine>();
            var balance = 0;

            foreach (var transaction in transactions)
            {
                balance += transaction.Amount;

                lines.Add(new PrintLine(transaction.CreatedDate, transaction.Amount, balance));
            }

            lines.Reverse();

            foreach (var line in lines)
            {
                _console.PrintLine(line.ToString());
            }
        }


    }
}