using System.Net;
using System.Net.Mail;

namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Notifications;

public class EmailNotificationService : INotificationStrategy
{
    private readonly string _host;
    private readonly int _port;
    private readonly string _userName;
    private readonly string _userPass;
    private readonly string _fromAddr;
    private readonly string _toAddr;
    
    const string SUBJECT_MSG = "Mail notification";

    public EmailNotificationService()
    {
        // this should be loaded from an actual configuration
        _host = "sandbox.smtp.mailtrap.io";
        _port = 0;
        _userName = "";
        _userPass = "";
        _fromAddr = "from@example.com";
        _toAddr = "to@example.com";
    }
    
    public async Task SendNotification(string data)
    {
        var client = new SmtpClient(_host, _port)
        {
            Credentials = new NetworkCredential(_userName, _userPass),
            EnableSsl = true
        };
        await client.SendMailAsync(_fromAddr, _toAddr, SUBJECT_MSG, data);
    }
}