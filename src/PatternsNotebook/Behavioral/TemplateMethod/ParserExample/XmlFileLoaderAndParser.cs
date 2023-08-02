using System.Xml.Schema;
using System.Xml.Serialization;

namespace PatternsNotebook.Behavioral.TemplateMethod.ParserExample;

[XmlType(AnonymousType = true)]
[XmlRoot("catalog", Namespace = "")]
public sealed record XmlData : ParsedStructure
{
    [XmlElement("book", Form = XmlSchemaForm.Unqualified)]
    public List<Book> Catalog { get; set; }
    public override string ToString()
    {
        return string.Join(", ", Catalog.Select(x => x.Title));
    }
}

[XmlType(AnonymousType = true)]
[XmlRoot(Namespace = "", IsNullable = false)]
public sealed record Book
{
    [XmlAttribute("id")]
    public string Id { get; set; }
    [XmlElement("title", Form = XmlSchemaForm.Unqualified)]
    public string Title { get; set; }
    [XmlElement("author", Form = XmlSchemaForm.Unqualified)]
    public string Author { get; set; }
}

class XmlFileLoaderAndParser : TextLoaderAndParser
{
    private readonly string _path;

    public XmlFileLoaderAndParser(string path)
    {
        DirectoryInfo dir = new DirectoryInfo(path);
        _path = dir.FullName;
    }

    protected override ParsedStructure ParseText(string text)
    {
        using var reader = new StringReader(text);
        var serializer = new XmlSerializer(typeof(XmlData));
        var result = serializer.Deserialize(reader);
        return (XmlData) result;
    }

    protected override string LoadText()
    {
        if (!File.Exists(_path))
        {
            throw new InvalidOperationException($"File {_path} not found.");
        }

        string content = File.ReadAllText(_path);
        return content;
    }
}