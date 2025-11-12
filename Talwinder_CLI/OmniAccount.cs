// --- Omni Account ---
// A fancy account with overdraft and special interest rules.
public class OmniAccount : Account
{
    public double InterestRate { get; set; }
    public double OverdraftLimit { get; set; }
    public double FailedTransactionFee { get; set; }

    public OmniAccount(int id, double initialBalance, Customer accountHolder, double interestRate, double overdraftLimit, double failedFee)
        : base(id, initialBalance, accountHolder)
    {
        InterestRate = interestRate;
        OverdraftLimit = overdraftLimit;
        FailedTransactionFee = failedFee;
    }

    public override string Withdraw(double amount)
    {
        // Can withdraw up to balance + overdraft limit.
        if (amount <= Balance + OverdraftLimit)
        {
            Balance -= amount;
            return $"Omni {Id}; Withdrawal Successful; Updated Balance: ${Balance:F2};";
        }
        else
        {
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
            return $"Omni {Id}; Withdrawal Attempt: ${amount:F2}; Transaction Status: Failed; Fee: ${fee:F2}; Updated Balance: ${Balance:F2};";
        }
    }

    // Interest is only added if the balance is over $1000.
    public string CalculateAndAddInterest()
    {
        if (Balance > 1000)
        {
            // Interest is calculated on the amount *over* $1000
            double interestToAdd = (Balance - 1000) * InterestRate;
            Balance += interestToAdd;
            return $"Omni {Id}; Interest Added: ${interestToAdd:F2}; Updated Balance: ${Balance:F2};";
        }
        return $"Omni {Id}; No interest added as balance is not over $1000.";
    }

    public override string GetAccountDetails()
    {
        return $"Omni {Id}; Interest Rate: {InterestRate:P0}; Overdraft Limit: ${OverdraftLimit:F2}; Fee: ${FailedTransactionFee:F2}; Current Balance: ${Balance:F2};";
    }
}
