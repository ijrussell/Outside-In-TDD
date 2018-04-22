using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class StatementPrinterShould
    {
        private IConsole _console;
        private StatementPrinter _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _console = Substitute.For<IConsole>();
            _statementPrinter = new StatementPrinter(_console);
        }

        [Test]
        public void PrintHeaderRow()
        {
            _statementPrinter.PrintStatement(new List<Transaction>());

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
        }

        [Test]
        public void PrintDeposit()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(new DateTime(2015, 3, 8), 500)
            };

            _statementPrinter.PrintStatement(transactions);

            _console.Received().PrintLine("DATE | AMOUNT | BALANCE");
            _console.Received().PrintLine("08/03/2015 | 500 | 500");
        }

        [Test]
        public void PrintTransactions()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(new DateTime(2015, 3, 8), 1000),
                new Transaction(new DateTime(2015, 3, 9), -500),
                new Transaction(new DateTime(2015, 3, 10), 1500)
            };

            _statementPrinter.PrintStatement(transactions);

            Received.InOrder(() =>
            {
                _console.PrintLine("DATE | AMOUNT | BALANCE");
                _console.PrintLine("10/03/2015 | 1500 | 2000");
                _console.PrintLine("09/03/2015 | -500 | 500");
                _console.PrintLine("08/03/2015 | 1000 | 1000");
            });
        }
    }
}