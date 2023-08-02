using System.Net;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace PatternsNotebook.Behavioral.TemplateMethod.ParserExample;

public sealed record ParsedProduct : ParsedStructure
{
    [JsonPropertyName("title")]
    public string Title { get; set; }
    [JsonPropertyName("category")]
    public string Category { get; set; }
}

class JsonWebProductLoaderAndParser : TextLoaderAndParser
{
    private readonly string _url;

    public JsonWebProductLoaderAndParser(string url)
    {
        _url = url;
    }

    protected override ParsedStructure ParseText(string data)
    {
        ParsedProduct result = JsonSerializer.Deserialize<ParsedProduct>(data);
        return result;
    }

    protected override string LoadText()
    {
        using var webclient = new WebClient();
        var json = webclient.DownloadString(_url);
        return json;
    }
}