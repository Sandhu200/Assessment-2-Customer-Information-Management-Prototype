using Talwinder_CLI;

// --- Everyday Account ---
// The most basic account.
public class EverydayAccount : Account
{
    public EverydayAccount(int id, double initialBalance, Customer accountHolder)
        : base(id, initialBalance, accountHolder)
    {
    }

    // No fees, no overdraft. Just a simple withdrawal.
    public override string Withdraw(double amount)
    {
        if (amount <= Balance)
        {
            Balance -= amount;
            return $"Everyday {Id}; Withdrawal Successful; Updated Balance: ${Balance:F2};";
        }
        else
        {
            // No fee for failed transactions on this account type.
            throw new FailedWithdrawalException($"Everyday {Id}; Withdrawal Attempt: ${amount:F2}; Transaction Status: Failed; Updated Balance: ${Balance:F2};");
        }
    }

    public override string GetAccountDetails()
    {
        return $"Everyday {Id}; Current Balance: ${Balance:F2};";
    }
}
