namespace PatternsNotebook.Behavioral.State.BankAccountExample.States;

class GoldState : BankAccountState
{
    public GoldState(BankAccount bankAccount, decimal balance)
    {
        BankAccount = bankAccount;
        Balance = balance;
    }

    public override void Deposit(decimal amount)
    {
        Console.WriteLine($"GoldState, depositing {amount}, + 10% bonus: {amount/10}");
        Balance += amount * 1.1m;
    }

    public override void Withdraw(decimal amount)
    {
        Console.WriteLine($"GoldState, withdrawing {amount} from {Balance}");
        Balance -= amount;
        if (Balance is < 1000 and >= 0)
        {
            BankAccount.BankAccountState = new RegularState(Balance, BankAccount);
        }

        if (Balance < 0)
        {
            BankAccount.BankAccountState = new OverDrawnState(Balance, BankAccount);
        }
    }
}