using System.Text.Json;

namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Export;

public class JsonExportService : IExportStrategy
{
    public void Export(Order order)
    {
        string jsonOrder = JsonSerializer.Serialize(order, new JsonSerializerOptions { WriteIndented = true });
        Console.WriteLine(jsonOrder);
    }
}