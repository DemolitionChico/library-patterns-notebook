using PatternsNotebook.Behavioral.State.BankAccountExample.States;

namespace PatternsNotebook.Behavioral.State.BankAccountExample;

public class BankAccount
{
    public BankAccountState BankAccountState { get; set; }
    public decimal Balance => BankAccountState.Balance;

    public BankAccount(decimal balance)
    {
        BankAccountState = new RegularState(balance, this);
    }

    public void Deposit(decimal amount)
    {
        BankAccountState.Deposit(amount);
    }

    public void Withdraw(decimal amount)
    {
        BankAccountState.Withdraw(amount);
    }
}