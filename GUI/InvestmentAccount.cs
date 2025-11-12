using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class InvestmentAccount : Account
    {
        public InvestmentAccount(int id, double balance, double interestRate, double fee) : base(id, balance)
        {
            InterestRate = interestRate;
            OverdraftLimit = 0;
            FeeForFailedWithdrawal = fee;
        }

        public override string Withdraw(double amount, Customer customer)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return $"Investment {ID}; Withdrawal Attempt: ${amount}; Transaction Status: Success; Updated Balance: ${Balance};";
            }
            else
            {
                double fee = customer.IsStaff ? FeeForFailedWithdrawal * 0.5 : FeeForFailedWithdrawal;
                Balance -= fee;
                return $"Investment {ID}; Withdrawal Attempt: ${amount}; Transaction Status: Failed; Fee: ${fee}; Updated Balance: ${Balance};";
            }
        }

        public override string CalculateInterest()
        {
            double interest = Balance * InterestRate;
            Balance += interest;
            return $"Investment {ID}; Interest Added: ${interest:F2}; Updated Balance: ${Balance:F2};";
        }
    }
}
