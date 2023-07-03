namespace PatternsNotebook.Behavioral.Command.CartExample.Commands;

public interface ICommand
{
    void Execute();
    bool CanExecute();
    void Undo();
}