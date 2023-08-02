namespace PatternsNotebook.Behavioral.ChainOfResponsibility.DocumentValidationExample;

public interface IHandler<T> where T : class
{
    IHandler<T> SetSuccessor(IHandler<T> successor);
    void Handle(T request);
}