using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public class EverydayAccount : Account
    {
        public EverydayAccount(int id, double balance) : base(id, balance)
        {
            InterestRate = 0;
            OverdraftLimit = 0;
            FeeForFailedWithdrawal = 0;
        }

        public override string Withdraw(double amount, Customer customer)
        {
            if (amount <= Balance)
            {
                Balance -= amount;
                return $"Everyday {ID}; Withdrawal Attempt: ${amount}; Transaction Status: Success; Updated Balance: ${Balance};";
            }
            else
            {
                return $"Everyday {ID}; Withdrawal Attempt: ${amount}; Transaction Status: Failed; Updated Balance: ${Balance};";
            }
        }

        public override string CalculateInterest()
        {
            return $"Everyday {ID}; No interest is applied to this account.;";
        }
    }
}
