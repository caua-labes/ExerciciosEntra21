using Microsoft.VisualStudio.TestTools.UnitTesting;
using AulaTestes.NET;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AulaTestes.NET.Tests
{
    [TestClass()]
    public class AccountTests
    {

        [TestMethod()]
        public void StoreTest()
        {
            Account account = new Account();
            account.m_balance = 10.0;
            account.Withdraw(9.0);
            double valor_esperado = 1.0;
            Assert.AreEqual(valor_esperado, account.m_balance);
        }

        [TestMethod()]
        public void WithdrawTest()
        {
            Account account = new Account();
            account.m_balance = 10.0;
            account.Withdraw(9.0);
            double valor_esperado = 1.0;
            Assert.AreEqual(valor_esperado, account.m_balance);
        }

        [TestMethod()]

        public void WithdrawTestThrowException()
        {
            Console.ReadLine();
            Account account = new();
            account.m_balance = 10.0;
            double valor_esperado = 1.0;
            account.Withdraw(9.0);

            ArgumentException exception = Assert.ThrowsException<ArgumentException>(() => account.Withdraw(2.0));
            Assert.AreEqual("ola mundo", exception.Message);
        }
    }
}