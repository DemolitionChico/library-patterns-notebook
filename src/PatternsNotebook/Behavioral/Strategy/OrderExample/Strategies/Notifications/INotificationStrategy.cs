namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

public interface INotificationStrategy
{
    void SendNotification(string data);

    public static INotificationStrategy Default => new EmailNotificationService();
}