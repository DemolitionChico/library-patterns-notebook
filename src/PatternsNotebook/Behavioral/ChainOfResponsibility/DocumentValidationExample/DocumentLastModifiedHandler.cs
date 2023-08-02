using System.ComponentModel.DataAnnotations;

namespace PatternsNotebook.Behavioral.ChainOfResponsibility.DocumentValidationExample;

class DocumentLastModifiedHandler : IHandler<Document>
{
    private IHandler<Document> _successor;

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }

    public void Handle(Document request)
    {
        if (request.LastModified < DateTime.UtcNow.AddDays(-30))
        {
            throw new ValidationException(
                new ValidationResult("Document must be modified in the last 30 days",
                    new List<string> {"LastModified"}),
                null, null);
        }

        _successor?.Handle(request);
    }
}