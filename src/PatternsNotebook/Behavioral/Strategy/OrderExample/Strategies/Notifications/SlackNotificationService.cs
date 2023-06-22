using System.Collections.Specialized;
using System.Net;
using System.Text;
using System.Text.Json;

namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

public class SlackNotificationService : INotificationStrategy
{
    private readonly string _incomingWebHook;

    public SlackNotificationService()
    {
        // this should be loaded from an actual configuration
        _incomingWebHook = "";
    }

    public void SendNotification(string data)
    {
        string payload = JsonSerializer.Serialize(new {text = data});
        using (WebClient client = new WebClient())
        {
            NameValueCollection config = new NameValueCollection();
            config["payload"] = payload;
	
            // in a real implementation it should be made async 
            var response = client.UploadValues(_incomingWebHook, "POST", config);
            string responseText = new UTF8Encoding().GetString(response);
            
            Console.WriteLine($"Message sent ({responseText})");
        }
    }
}