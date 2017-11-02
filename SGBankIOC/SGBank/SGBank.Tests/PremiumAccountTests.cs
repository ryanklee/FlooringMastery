using NUnit.Framework;
using SGBank.BLL.DepositRules;
using SGBank.BLL.WithdrawRules;
using SGBank.Models;
using SGBank.Models.Interfaces;
using SGBank.Models.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SGBank.Tests
{
    [TestFixture]
    public class PremiumAccountTests
    {
        [Test]
        [TestCase("99999", "Premium Account", 1000, AccountType.Free, 2500, false)]
        [TestCase("99999", "Premium Account", 1000, AccountType.Premium, -1000, false)]
        [TestCase("99999", "Premium Account", 1000, AccountType.Premium, 2500, true)]
        public void PremiumAccountDepositRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IDeposit deposit = new NoLimitDepositRule();
            Account account = new Account
            {
                AccountNumber = accountNumber,
                Balance = balance,
                Name = name,
                Type = accountType
            };

            AccountDepositResponse response = deposit.Deposit(account, amount);

            Assert.AreEqual(expectedResult, response.Success);
        }

        [Test]
        [TestCase("99999", "Premium Account", 1000, AccountType.Free, -100, false)]
        [TestCase("99999", "Premium Account", 1000, AccountType.Premium, 500, false)]
        [TestCase("99999", "Premium Account", 1000, AccountType.Premium, -2000, false)]
        [TestCase("99999", "Premium Account", 1000, AccountType.Premium, -50, true)]
        [TestCase("99999", "Premium Account", 1000, AccountType.Premium, -1500, true)]
        public void BasicAccountWithdrawRuleTest(string accountNumber, string name, decimal balance, AccountType accountType, decimal amount, bool expectedResult)
        {
            IWithdraw withdraw = new PremiumAccountWithdrawRule();
            Account account = new Account
            {
                AccountNumber = accountNumber,
                Name = name,
                Balance = balance,
                Type = accountType
            };

            AccountWithdrawResponse response = withdraw.Withdraw(account, amount);

            Assert.AreEqual(expectedResult, response.Success);

        }
    }
}
