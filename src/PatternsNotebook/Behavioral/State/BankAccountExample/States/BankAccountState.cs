namespace PatternsNotebook.Behavioral.State.BankAccountExample.States;

public abstract class BankAccountState
{
    protected BankAccount BankAccount { get; init; } = null!;
    
    public decimal Balance { get; protected set; }

    public abstract void Deposit(decimal amount);
    public abstract void Withdraw(decimal amount);
}