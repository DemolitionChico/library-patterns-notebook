namespace PatternsNotebook.Behavioral.Observer.OrderStateChangeExample;

public class StateNotifyingOrder: OrderStateNotifier
{
    private readonly string _number;
    private string _status;
    
    public StateNotifyingOrder()
    {
        _number = Guid.NewGuid().ToString();
        _status = OrderStates.New;
    }

    public void SettlePayment()
    {
        _status = OrderStates.Paid;
        Notify(_number, _status);
    }

    public void StartProcessing()
    {
        _status = OrderStates.Processing;
        Notify(_number, _status);
    }

    public void Send()
    {
        _status = OrderStates.Sent;
        Notify(_number, _status);
    }
}

public static class OrderStates
{
    public const string New = "NEW";
    public const string Paid = "PAID";
    public const string Processing = "PROCESSING";
    public const string Sent = "SENT";
}