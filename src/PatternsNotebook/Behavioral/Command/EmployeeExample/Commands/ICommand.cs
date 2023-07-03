namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Commands;

public interface ICommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}