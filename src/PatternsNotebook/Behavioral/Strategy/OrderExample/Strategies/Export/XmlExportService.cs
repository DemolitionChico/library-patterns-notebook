using System.Xml.Serialization;

namespace PatternsNotebook.Behavioral.Strategy.OrderExample.Strategies.Export;

public class XmlExportService : IExportStrategy
{
    public void Export(Order order)
    {
        XmlSerializer serializer = new XmlSerializer(typeof(Order));
        string serializedOrder = null;
        using (var writer = new StringWriter())
        {
            serializer.Serialize(writer, order);
            serializedOrder = writer.ToString();
        }
        Console.WriteLine(serializedOrder);
    }
}