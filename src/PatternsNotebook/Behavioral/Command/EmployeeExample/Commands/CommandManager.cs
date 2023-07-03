namespace PatternsNotebook.Behavioral.Command.EmployeeExample.Commands;

/// <summary>
/// Invoker
/// </summary>
public class CommandManager
{
    private Stack<ICommand> _commands = new();
    
    public void Invoke(ICommand command)
    {
        if(command.CanExecute())
        {
            command.Execute();
            _commands.Push(command);
        }
    }

    public void Undo()
    {
        if (_commands.Any())
        {
            _commands.Pop()?.Undo();
        }
    }
}