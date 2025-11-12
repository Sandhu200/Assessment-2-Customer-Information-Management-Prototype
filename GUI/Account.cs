using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GUI
{
    public abstract class Account
    {
        public int ID { get; }
        public double Balance { get; protected set; }
        public double InterestRate { get; protected set; }
        public double OverdraftLimit { get; protected set; }
        public double FeeForFailedWithdrawal { get; protected set; }

        public Account(int id, double balance)
        {
            ID = id;
            Balance = balance;
        }

        public virtual void Deposit(double amount)
        {
            if (amount > 0)
            {
                Balance += amount;
            }
        }

        public abstract string Withdraw(double amount, Customer customer);
        public abstract string CalculateInterest();

        public override string ToString()
        {
            return $"{this.GetType().Name} {ID}; Balance: ${Balance}";
        }
    }
}
