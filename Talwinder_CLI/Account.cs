// --- Account Classes ---


public abstract class Account
{
    public int Id { get; set; }
    public double Balance { get; set; } // "protected set" means only this class and its children can change the balance directly.
    public Customer AccountHolder { get; set; }

    // A constructor to create a new account
    public Account(int id, double initialBalance, Customer accountHolder)
    {
        Id = id;
        Balance = initialBalance;
        AccountHolder = accountHolder;
    }

    // A simple deposit method that works for all accounts.
    public void Deposit(double amount)
    {
        if (amount > 0)
        {
            Balance += amount;
        }
    }

    // Abstract methods have to be implemented by the child classes.
    public abstract string Withdraw(double amount);
    public abstract string GetAccountDetails();
}
