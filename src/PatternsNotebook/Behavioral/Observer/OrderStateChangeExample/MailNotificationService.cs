namespace PatternsNotebook.Behavioral.Observer.OrderStateChangeExample;

class MailNotificationService : OrderStateListener
{
    public override void ReceiveOrderStateUpdate(string number, string state)
    {
        Console.WriteLine($"Mail notification sent: order {number} changed status to {state}");
    }
}