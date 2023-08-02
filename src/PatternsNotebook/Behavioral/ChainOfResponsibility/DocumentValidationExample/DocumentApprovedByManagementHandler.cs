using System.ComponentModel.DataAnnotations;

namespace PatternsNotebook.Behavioral.ChainOfResponsibility.DocumentValidationExample;

class DocumentApprovedByManagementHandler : IHandler<Document>
{
    private IHandler<Document> _successor;

    public IHandler<Document> SetSuccessor(IHandler<Document> successor)
    {
        _successor = successor;
        return successor;
    }

    public void Handle(Document request)
    {
        if (!request.ApprovedByManagement)
        {
            throw new ValidationException(
                new ValidationResult("Document must be approved by management",
                    new List<string> {"ApprovedByManagement "}),
                null, null);
        }

        _successor?.Handle(request);
    }
}