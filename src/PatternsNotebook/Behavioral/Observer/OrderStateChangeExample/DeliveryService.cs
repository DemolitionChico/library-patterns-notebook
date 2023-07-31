namespace PatternsNotebook.Behavioral.Observer.OrderStateChangeExample;

class DeliveryService : OrderStateListener
{
    public override void ReceiveOrderStateUpdate(string number, string state)
    {
        Console.WriteLine(state switch
        {
            OrderStates.Processing => $"Shipping label prepared for {number} ({state})",
            OrderStates.Sent => $"Shipment ready for {number} ({state})",
            _ => $"State change not relevant ({state})"
        });
    }
}