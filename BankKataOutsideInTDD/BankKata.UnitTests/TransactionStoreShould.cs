using System;
using NSubstitute;
using NUnit.Framework;

namespace BankKata.UnitTests
{
    [TestFixture]
    public class TransactionStoreShould
    {
        private TransactionStore _transactionStore;
        private IClock _clock;

        [SetUp]
        public void Setup()
        {
            _clock = Substitute.For<IClock>();
            _transactionStore = new TransactionStore(_clock);
        }

        [Test]
        public void HaveNoTransactionsOnCreation()
        {
            var transactions = _transactionStore.AllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(0));
        }

        [Test]
        public void HandleADeposit()
        {
            const int amount = 100;
            var today = new DateTime(2018, 2, 4);

            _clock.UtcNow.Returns(today);

            _transactionStore.AddTransaction(amount);

            var transactions = _transactionStore.AllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0].Amount, Is.EqualTo(amount));
            Assert.That(transactions[0].CreatedDate, Is.EqualTo(today));
        }

        [Test]
        public void HandleAWithdrawl()
        {
            const int amount = 100;
            var today = new DateTime(2018, 2, 4);

            _clock.UtcNow.Returns(today);

            _transactionStore.AddTransaction(-amount);

            var transactions = _transactionStore.AllTransactions();

            Assert.That(transactions.Count, Is.EqualTo(1));
            Assert.That(transactions[0].Amount, Is.EqualTo(-amount));
            Assert.That(transactions[0].CreatedDate, Is.EqualTo(today));
        }
    }
}