using Talwinder_CLI;

// --- Investment Account ---
// An account for investing, has interest but no overdraft.
public class InvestmentAccount : Account
{
    public double InterestRate { get; set; } // e.g., 0.04 for 4%
    public double FailedTransactionFee { get; set; }

    public InvestmentAccount(int id, double initialBalance, Customer accountHolder, double interestRate, double failedFee)
        : base(id, initialBalance, accountHolder)
    {
        InterestRate = interestRate;
        FailedTransactionFee = failedFee;
    }

    public override string Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return $"Investment {Id}; Withdrawal Successful; Updated Balance: ${Balance:F2};";
        }
        else
        {
            // Apply a fee for the failed attempt.
            double fee;
            if (AccountHolder.IsStaff)
            {
                fee = FailedTransactionFee / 2;
            }
            else
            {
                fee = FailedTransactionFee;
            }
            Balance -= fee;
            throw new FailedWithdrawalException($"Investment {Id}; Withdrawal Attempt: ${amount:F2}; Transaction Status: Failed; Fee: ${fee:F2}; Updated Balance: ${Balance:F2};");
        }
    }

    // Calculates interest on the entire balance.
    public string CalculateAndAddInterest()
    {
        double interestToAdd = Balance * InterestRate;
        Balance += interestToAdd;
        return $"Investment {Id}; Interest Added: ${interestToAdd:F2}; Updated Balance: ${Balance:F2};";
    }

    public override string GetAccountDetails()
    {
        return $"Investment {Id}; Interest Rate: {InterestRate:P0}; Fee: ${FailedTransactionFee:F2}; Current Balance: ${Balance:F2};";
    }
}
