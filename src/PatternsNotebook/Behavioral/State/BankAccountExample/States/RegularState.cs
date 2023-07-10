namespace PatternsNotebook.Behavioral.State.BankAccountExample.States;

class RegularState : BankAccountState
{
    public RegularState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }
    
    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"RegularState, depositing {amount}");
        Balance += amount;
        if (Balance >= 1000)
        {
            BankAccount.BankAccountState = new GoldState(BankAccount, Balance);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"RegularState, withdrawing {amount}");
        Balance -= amount;
        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverDrawnState(Balance, BankAccount);
        }
    }
}