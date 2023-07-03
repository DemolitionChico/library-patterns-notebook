namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

public interface INotificationStrategy
{
    Task SendNotification(string data);

    public static INotificationStrategy Default => new EmailNotificationService();
}