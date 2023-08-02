using System.ComponentModel.DataAnnotations;

namespace PatternsNotebook.Behavioral.ChainOfResponsibility.DocumentValidationExample;

class DocumentTitleHandler : IHandler<Document>
{
    private IHandler<Document> _successor;

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }

    public void Handle(Document request)
    {
        if (string.IsNullOrEmpty(request.Title))
        {
            throw new ValidationException(new ValidationResult("Title must be filled out", new List<string> {"Title"}),
                null, null);
        }

        _successor?.Handle(request);
    }
}