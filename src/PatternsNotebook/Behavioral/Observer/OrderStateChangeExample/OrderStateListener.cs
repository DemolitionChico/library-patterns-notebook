namespace PatternsNotebook.Behavioral.Observer.OrderStateChangeExample;

public abstract class OrderStateListener
{
    public abstract void ReceiveOrderStateUpdate(string number, string state);
}