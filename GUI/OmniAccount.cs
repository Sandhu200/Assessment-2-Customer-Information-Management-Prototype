using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class OmniAccount : Account
    {
        public OmniAccount(int id, double balance, double interestRate, double overdraftLimit, double fee) : base(id, balance)
        {
            InterestRate = interestRate;
            OverdraftLimit = overdraftLimit;
            FeeForFailedWithdrawal = fee;
        }

        public override string Withdraw(double amount, Customer customer)
        {
            if (amount <= Balance + OverdraftLimit)
            {
                Balance -= amount;
                return $"Omni {ID}; Withdrawal Attempt: ${amount}; Transaction Status: Success; Updated Balance: ${Balance};";
            }
            else
            {
                double fee = customer.IsStaff ? FeeForFailedWithdrawal * 0.5 : FeeForFailedWithdrawal;
                Balance -= fee;
                return $"Omni {ID}; Withdrawal Attempt: ${amount}; Transaction Status: Failed; Fee: ${fee}; Updated Balance: ${Balance};";
            }
        }

        public override string CalculateInterest()
        {
            if (Balance > 1000)
            {
                double interest = (Balance - 1000) * InterestRate;
                Balance += interest;
                return $"Omni {ID}; Interest Added: ${interest:F2}; Updated Balance: ${Balance:F2};";
            }
            return $"Omni {ID}; No interest added as balance is not over $1000;";
        }

        public override string ToString()
        {
            return $"Omni {ID}; Interest Rate: {InterestRate:P}; Overdraft Limit: ${OverdraftLimit}; Fee: ${FeeForFailedWithdrawal}; Current Balance: ${Balance:C};";
        }
    }
}
