namespace PatternsNotebook.Behavioral.Observer.OrderStateChangeExample;

public abstract class OrderStateNotifier
{
    private readonly List<OrderStateListener> _observers = new ();

    public void AddObserver(OrderStateListener observer)
    {
        _observers.Add(observer);
    }

    public void RemoveObserver(OrderStateListener observer)
    {
        _observers.Remove(observer);
    }

    protected void Notify(string number, string status)
    {
        foreach (var observer in _observers)
        {
            observer.ReceiveOrderStateUpdate(number, status);
        }
    }
}