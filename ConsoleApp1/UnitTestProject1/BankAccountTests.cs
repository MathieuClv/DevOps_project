using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 10.00;
            double debitAmount = 6.50;
            double expected = 3.50;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }

        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act and assert
            Assert.ThrowsException<System.ArgumentOutOfRangeException>(() => account.Debit(debitAmount));
        }

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 100.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (System.ArgumentOutOfRangeException e)
            {
                // Assert
                StringAssert.Contains(e.Message, BankAccount.DebitAmountExceedsBalanceMessage);
            }
        }

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 10.00;
            double creditAmount = 15.00;
            double expected = 25.00;
            BankAccount account = new BankAccount("Mr. Bryan Walton", beginningBalance);

            // Act
            account.Credit(creditAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not credited correctly");
        }

        [TestMethod]
        public void Getting_TheNameOf_BankAccount()
        {
            // Arrange
            string nameAccount = "Mathieu CLAVERIE";
            double initBalance = 12.00;
            string expected = "Mathieu CLAVERIE";
            BankAccount bAccount = new BankAccount(nameAccount, initBalance);

            // Act
            string customerName = bAccount.CustomerName;

            // Assert
            string actual = customerName;
            Assert.AreEqual(expected, actual, "Account not named correctly");
        }

        [TestMethod]
        public void Getting_TheBalanceOf_BankAccount()
        {
            // Arrange
            double expected = 12.00;
            BankAccount bAccount = new BankAccount("Mathieu CLAVERIE", 12.00);

            // Act
            double customerBalance = bAccount.Balance;

            // Assert
            double actual = customerBalance;
            Assert.AreEqual(expected, actual, "Balance not set correctly");
        }

        [TestMethod]
        public void TheType_OfCustomerNameIn_BankAccount()
        {
            // Arrange
            double initBalance = 12.00;
            BankAccount bAccount = new BankAccount("Mathieu CLAVERIE", initBalance);

            // Assert
            Assert.AreEqual(typeof(string), bAccount.CustomerName.GetType(), "Type of the customer name not correct");
        }
        [TestMethod]
        public void TheType_OfBalanceIn_BankAccount()
        {
            // Arrange
            string nameAccount = "Mathieu CLAVERIE";
            BankAccount bAccount = new BankAccount(nameAccount, 12.00);

            // Assert
            Assert.AreEqual(typeof(double), bAccount.Balance.GetType(), "Type of the balance not correct");
        }
    }
}
