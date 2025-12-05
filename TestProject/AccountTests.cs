using Microsoft.VisualStudio.TestTools.UnitTesting;
using Talwinder_CLI; // Assuming Talwinder_CLI is the namespace for your account classes

namespace TestProject
{
    [TestClass]
    public class AccountTests
    {
        // Helper method to create a customer for testing
        private Customer CreateTestCustomer(bool isStaff = false)
        {
            return new Customer(1, "Test Customer", "1234567890", isStaff);
        }

        [TestMethod]
        public void Deposit_PositiveAmount_IncreasesBalance()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new EverydayAccount(1, 100.0, customer);
            double depositAmount = 50.0;
            double expectedBalance = 150.0;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should increase by the deposited amount.");
        }

        [TestMethod]
        public void Deposit_ZeroAmount_BalanceRemainsUnchanged()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new EverydayAccount(1, 100.0, customer);
            double depositAmount = 0.0;
            double expectedBalance = 100.0;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should remain unchanged for zero deposit.");
        }

        [TestMethod]
        public void Deposit_NegativeAmount_BalanceRemainsUnchanged()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new EverydayAccount(1, 100.0, customer);
            double depositAmount = -50.0;
            double expectedBalance = 100.0;

            // Act
            account.Deposit(depositAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should remain unchanged for negative deposit.");
        }

        [TestMethod]
        public void EverydayAccount_Withdraw_Successful()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new EverydayAccount(1, 100.0, customer);
            double withdrawAmount = 50.0;
            double expectedBalance = 50.0;

            // Act
            string result = account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should decrease after successful withdrawal.");
            StringAssert.Contains(result, "Withdrawal Successful", "Result message should indicate success.");
        }

        [TestMethod]
        public void EverydayAccount_Withdraw_InsufficientFunds_ThrowsFailedWithdrawalException()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new EverydayAccount(1, 100.0, customer);
            double withdrawAmount = 150.0;

            // Act & Assert
            Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                account.Withdraw(withdrawAmount);
            }, "FailedWithdrawalException should be thrown for insufficient funds.");
        }

        [TestMethod]
        public void InvestmentAccount_Withdraw_Successful()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new InvestmentAccount(1, 200.0, customer, 0.05, 10.0);
            double withdrawAmount = 50.0;
            double expectedBalance = 150.0;

            // Act
            string result = account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should decrease after successful withdrawal.");
            StringAssert.Contains(result, "Withdrawal Successful", "Result message should indicate success.");
        }

        [TestMethod]
        public void InvestmentAccount_Withdraw_InsufficientFunds_AppliesFee_ThrowsFailedWithdrawalException()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new InvestmentAccount(1, 100.0, customer, 0.05, 10.0);
            double withdrawAmount = 150.0;
            double expectedBalanceAfterFee = 100.0 - 10.0; // Initial balance - fee

            // Act & Assert
            var ex = Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                account.Withdraw(withdrawAmount);
            }, "FailedWithdrawalException should be thrown for insufficient funds.");

            Assert.AreEqual(expectedBalanceAfterFee, account.Balance, "Balance should reflect fee after failed withdrawal.");
            StringAssert.Contains(ex.Message, "Transaction Status: Failed", "Exception message should indicate failure.");
            StringAssert.Contains(ex.Message, "Fee: $10.00", "Exception message should mention the fee.");
        }

        [TestMethod]
        public void InvestmentAccount_Withdraw_InsufficientFunds_Staff_AppliesHalfFee_ThrowsFailedWithdrawalException()
        {
            // Arrange
            var staffCustomer = CreateTestCustomer(isStaff: true);
            var account = new InvestmentAccount(1, 100.0, staffCustomer, 0.05, 10.0);
            double withdrawAmount = 150.0;
            double expectedBalanceAfterFee = 100.0 - (10.0 / 2); // Initial balance - half fee

            // Act & Assert
            var ex = Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                account.Withdraw(withdrawAmount);
            }, "FailedWithdrawalException should be thrown for insufficient funds for staff.");

            Assert.AreEqual(expectedBalanceAfterFee, account.Balance, "Balance should reflect half fee after failed withdrawal for staff.");
            StringAssert.Contains(ex.Message, "Transaction Status: Failed", "Exception message should indicate failure.");
            StringAssert.Contains(ex.Message, "Fee: $5.00", "Exception message should mention the half fee.");
        }

        [TestMethod]
        public void InvestmentAccount_CalculateAndAddInterest_IncreasesBalance()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new InvestmentAccount(1, 1000.0, customer, 0.05, 10.0); // 5% interest
            double expectedInterest = 1000.0 * 0.05;
            double expectedBalance = 1000.0 + expectedInterest;

            // Act
            string result = account.CalculateAndAddInterest();

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should increase by the calculated interest.");
            StringAssert.Contains(result, $"Interest Added: ${expectedInterest:F2}", "Result message should indicate interest added.");
        }

        [TestMethod]
        public void OmniAccount_Withdraw_SuccessfulWithinOverdraft()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new OmniAccount(1, 100.0, customer, 0.02, 50.0, 15.0); // Overdraft limit 50
            double withdrawAmount = 120.0; // 100 (balance) - 120 = -20 (within -50 overdraft)
            double expectedBalance = -20.0;

            // Act
            string result = account.Withdraw(withdrawAmount);

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should decrease and go into overdraft.");
            StringAssert.Contains(result, "Withdrawal Successful", "Result message should indicate success.");
        }

        [TestMethod]
        public void OmniAccount_Withdraw_InsufficientFundsBeyondOverdraft_AppliesFee_ThrowsFailedWithdrawalException()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new OmniAccount(1, 100.0, customer, 0.02, 50.0, 15.0); // Overdraft limit 50
            double withdrawAmount = 160.0; // 100 (balance) - 160 = -60 (beyond -50 overdraft)
            double expectedBalanceAfterFee = 100.0 - 15.0; // Initial balance - fee

            // Act & Assert
            var ex = Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                account.Withdraw(withdrawAmount);
            }, "FailedWithdrawalException should be thrown for insufficient funds beyond overdraft.");

            Assert.AreEqual(expectedBalanceAfterFee, account.Balance, "Balance should reflect fee after failed withdrawal.");
            StringAssert.Contains(ex.Message, "Transaction Status: Failed", "Exception message should indicate failure.");
            StringAssert.Contains(ex.Message, "Fee: $15.00", "Exception message should mention the fee.");
        }

        [TestMethod]
        public void OmniAccount_Withdraw_InsufficientFundsBeyondOverdraft_Staff_AppliesHalfFee_ThrowsFailedWithdrawalException()
        {
            // Arrange
            var staffCustomer = CreateTestCustomer(isStaff: true);
            var account = new OmniAccount(1, 100.0, staffCustomer, 0.02, 50.0, 15.0); // Overdraft limit 50
            double withdrawAmount = 160.0; // 100 (balance) - 160 = -60 (beyond -50 overdraft)
            double expectedBalanceAfterFee = 100.0 - (15.0 / 2); // Initial balance - half fee

            // Act & Assert
            var ex = Assert.ThrowsException<FailedWithdrawalException>(() =>
            {
                account.Withdraw(withdrawAmount);
            }, "FailedWithdrawalException should be thrown for insufficient funds beyond overdraft for staff.");

            Assert.AreEqual(expectedBalanceAfterFee, account.Balance, "Balance should reflect half fee after failed withdrawal for staff.");
            StringAssert.Contains(ex.Message, "Transaction Status: Failed", "Exception message should indicate failure.");
            StringAssert.Contains(ex.Message, "Fee: $7.50", "Exception message should mention the half fee.");
        }

        [TestMethod]
        public void OmniAccount_CalculateAndAddInterest_BalanceOver1000_IncreasesBalance()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new OmniAccount(1, 1500.0, customer, 0.02, 50.0, 15.0); // 2% interest
            double expectedInterest = (1500.0 - 1000.0) * 0.02;
            double expectedBalance = 1500.0 + expectedInterest;

            // Act
            string result = account.CalculateAndAddInterest();

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should increase by calculated interest for balance over $1000.");
            StringAssert.Contains(result, $"Interest Added: ${expectedInterest:F2}", "Result message should indicate interest added.");
        }

        [TestMethod]
        public void OmniAccount_CalculateAndAddInterest_BalanceUnderOrEqual1000_NoInterestAdded()
        {
            // Arrange
            var customer = CreateTestCustomer();
            var account = new OmniAccount(1, 900.0, customer, 0.02, 50.0, 15.0);
            double expectedBalance = 900.0;

            // Act
            string result = account.CalculateAndAddInterest();

            // Assert
            Assert.AreEqual(expectedBalance, account.Balance, "Balance should remain unchanged for balance under $1000.");
            StringAssert.Contains(result, "No interest added", "Result message should indicate no interest added.");
        }
    }
}
