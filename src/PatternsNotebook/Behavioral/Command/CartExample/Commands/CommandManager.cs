namespace PatternsNotebook.Behavioral.Command.CartExample.Commands;

public class CommandManager
{
    private readonly Stack<ICommand> _commands = new Stack<ICommand>();

    public void Invoke(ICommand command)
    {
        if (command.CanExecute())
        {
            _commands.Push(command);
            command.Execute();
        }
    }

    public void Undo()
    {
        while (_commands.Count > 0)
        {
            var command = _commands.Pop();
            command.Undo();
        }
    }
}