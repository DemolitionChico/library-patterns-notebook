using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.Json;

namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

public class SlackNotificationService : INotificationStrategy
{
    private readonly Uri _incomingWebHook;

    public SlackNotificationService()
    {
        // this should be loaded from an actual configuration
        _incomingWebHook = new Uri("", UriKind.Absolute);
    }

    public async Task SendNotification(string data)
    {
        string payload = JsonSerializer.Serialize(new {text = data});
        var postParams = new Dictionary<string, string>()
        {
            {"payload", payload}
        };

        using HttpClient client = new HttpClient();
        using var postContent = new FormUrlEncodedContent(postParams);
        using var response = await client.PostAsync(_incomingWebHook, postContent);
        response.EnsureSuccessStatusCode();
        using HttpContent content = response.Content;
        string responseText = await content.ReadAsStringAsync();
        Console.WriteLine($"Message sent ({responseText})");
    }
}