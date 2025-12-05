using System;
using System.Collections.Generic;
using System.Globalization;
using Talwinder_CLI;

public class Program
{
    public static void Main(string[] args)
    {
        // Set culture to US to get the $ sign right.
        CultureInfo.CurrentCulture = new CultureInfo("en-US", false);

        // We'll create a couple of accounts for the user to play with.
        var customer = new Customer(1, "Test User", "1234567890", false);
        var staffCustomer = new Customer(2, "Test Staff", "0987654321", true);
        
        var accounts = new List<Account>
        {
            new EverydayAccount(1, 500, customer),
            new InvestmentAccount(2, 2000, staffCustomer, 0.05, 10.00),
            new OmniAccount(3, 800, customer, 0.04, 200, 15.00)
        };

        Console.WriteLine("--- Bank Account Management System ---");
        Console.WriteLine("\nHere are the available accounts:");
        
        // Print details for all available accounts
        foreach (var acc in accounts)
        {
            Console.WriteLine($" -> ID: {acc.Id}, Type: {acc.GetType().Name}, Holder: {acc.AccountHolder.Name}, Balance: ${acc.Balance:F2}");
        }

        // 1. Ask user to select an account
        Console.Write("\nPlease enter the ID of the account you want to use: ");
        string accountIdInput = Console.ReadLine();
        if (!int.TryParse(accountIdInput, out int accountId))
        {
            Console.WriteLine("That's not a valid number. Exiting.");
            return;
        }

        Account selectedAccount = null;
        foreach (var acc in accounts)
        {
            if (acc.Id == accountId)
            {
                selectedAccount = acc;
                break; 
            }
        }

        if (selectedAccount == null)
        {
            Console.WriteLine("Sorry, an account with that ID was not found. Exiting.");
            return;
        }

        // 2. Ask user what they want to do
        Console.WriteLine($"\nYou have selected Account ID: {selectedAccount.Id} (Balance: ${selectedAccount.Balance:F2})");
        Console.Write("What would you like to do? (Enter 'deposit' or 'withdraw'): ");
        string choice = Console.ReadLine().Trim().ToLower();

        // 3. Ask for the amount
        Console.Write("Please enter the amount: ");
        string amountInput = Console.ReadLine();
        if (!double.TryParse(amountInput, out double amount) || amount <= 0)
        {
            Console.WriteLine("Invalid amount entered. It must be a positive number. Exiting.");
            return;
        }

        // 4. Perform the action
        Console.WriteLine("\n--- Transaction Result ---");
        if (choice == "deposit")
        {
            selectedAccount.Deposit(amount);
            Console.WriteLine($"Deposit of ${amount:F2} was successful.");
            Console.WriteLine($"New Balance for Account {selectedAccount.Id}: ${selectedAccount.Balance:F2}");
        }
        else if (choice == "withdraw")
        {
            try
            {
                string result = selectedAccount.Withdraw(amount);
                Console.WriteLine(result); // The Withdraw method still returns a formatted string on success.
            }
            catch (FailedWithdrawalException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid choice. Please run the program again and choose 'deposit' or 'withdraw'.");
        }
    }
}