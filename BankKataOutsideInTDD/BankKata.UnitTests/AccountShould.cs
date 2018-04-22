using System;
using System.Collections.Generic;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class AccountShould
    {
        private Account _account;
        private ITransactionStore _transactionStore;
        private IStatementPrinter _statementPrinter;

        [SetUp]
        public void Setup()
        {
            _transactionStore = Substitute.For<ITransactionStore>();
            _statementPrinter = Substitute.For<IStatementPrinter>();
            _account = new Account(_transactionStore, _statementPrinter);
        }

        [Test]
        public void StoreADepositTransaction()
        {
            const int amount = 1000;

            _account.Deposit(amount);

            _transactionStore.Received().AddTransaction(amount);
        }

        [Test]
        public void StoreAWithdrawlTransaction()
        {
            const int amount = 1000;

            _account.Withdraw(amount);

            _transactionStore.Received().AddTransaction(-amount);
        }

        [Test]
        public void PrintAStatement()
        {
            var transactions = new List<Transaction>
            {
                new Transaction(new DateTime(2014, 1, 1), 1000),
                new Transaction(new DateTime(2014, 1, 2), -500),
                new Transaction(new DateTime(2014, 1, 4), 1500)
            };

            _transactionStore.AllTransactions().Returns(transactions);

            _account.PrintStatement();

            _statementPrinter.Received().PrintStatement(transactions);
        }
    }
}
