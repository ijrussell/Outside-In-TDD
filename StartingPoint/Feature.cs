﻿using System;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.AcceptanceTests
{
    [TestFixture]
    public class PrintStatementFeature
    {
        private IConsole console;
        private Account account;

        [SetUp]
        public void Setup()
        {
            console = Substitute.For<IConsole>();
            account = new Account();
        }

        [Test]
        public void PrintStatementContainingAllTransactions()
        {
            account.Deposit(1000);
            account.Withdraw(100);
            account.Deposit(500);

            account.PrintStatement();

            Received.InOrder(() => {
                console.PrintLine("DATE | AMOUNT | BALANCE");
                console.PrintLine("04/04/2018 | 500 | 1400");
                console.PrintLine("02/04/2018 | -100 | 900");
                console.PrintLine("01/04/2018 | 1000 | 1000");
            });
        }
    }
}
