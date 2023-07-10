namespace PatternsNotebook.Behavioral.State.BankAccountExample.States;

class OverDrawnState : BankAccountState
{
    public OverDrawnState(decimal balance, BankAccount bankAccount)
    {
        Balance = balance;
        BankAccount = bankAccount;
    }
    
    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"OverDrawnState, depositing {amount}");
        Balance += amount;
        if (Balance > 0)
        {
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"OverDrawnState, can't withdraw");
    }
}