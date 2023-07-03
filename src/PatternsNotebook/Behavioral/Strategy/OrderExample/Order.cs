using System.Xml.Serialization;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Export;
using PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

namespace PatternsNotebook.Behavioral.Strategy.OrderExample;

public class Order
{
    public string Customer { get; init; }
    public int Amount { get; init; }
    public string ItemName { get; init; }
    public string? Description { get; init; }
    [XmlIgnore] private INotificationStrategy NotificationStrategy { get; init; }
    
    public Order(string customer, int amount, string itemName, bool chatNotificationsEnabled, string? description)
    {
        Customer = customer;
        Amount = amount;
        ItemName = itemName;
        Description = description;
        NotificationStrategy =
            chatNotificationsEnabled ? new SlackNotificationService() : INotificationStrategy.Default;
    }
    
    /// <summary>
    /// Private constructor - parameterless is needed for the XmlSerializer.
    /// </summary>
    ///
    #pragma warning disable CS8618
    private Order()
    {
        
    }
    #pragma warning restore CS8618
    
    public void Export(IExportStrategy exportService)
    {
        if (exportService is null)
        {
            Console.WriteLine("No exporter has been provided.");
            return;
        }
        exportService.Export(this);
    }

    public async Task NotifyWhenReady()
    {
        if (NotificationStrategy is null)
        {
            Console.WriteLine("No notification service provided.");
            return;
        }
        await NotificationStrategy.SendNotification($"Ordered {ItemName} x {Amount}");
    }
}