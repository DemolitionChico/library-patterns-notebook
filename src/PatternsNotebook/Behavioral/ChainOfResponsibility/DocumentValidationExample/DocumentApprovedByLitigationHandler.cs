using System.ComponentModel.DataAnnotations;

namespace PatternsNotebook.Behavioral.ChainOfResponsibility.DocumentValidationExample;

class DocumentApprovedByLitigationHandler : IHandler<Document>
{
    private IHandler<Document> _successor;

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }

    public void Handle(Document request)
    {
        if (!request.ApprovedByLitigation)
        {
            throw new ValidationException(
                new ValidationResult("Document must be approved by litigation",
                    new List<string> {"ApprovedByLitigation"}),
                null, null);
        }

        _successor?.Handle(request);
    }
}