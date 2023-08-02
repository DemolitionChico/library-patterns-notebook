using System.Text.Json.Serialization;

namespace PatternsNotebook.Behavioral.TemplateMethod.ParserExample;

public abstract class TextLoaderAndParser
{
    public ParsedStructure LoadAndParse()
    {
        var data = LoadText();
        var result = ParseText(data);
        return result;
    }

    protected abstract ParsedStructure ParseText(string text);

    protected abstract string LoadText();
}

public abstract record ParsedStructure
{
}