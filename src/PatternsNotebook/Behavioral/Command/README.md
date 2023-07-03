## Behavioral patterns / Command pattern

Also called an Actional Transaction Pattern.

The intent of this pattern is to encapsulate requests with objects. This approach lets you parameterize, queue or undo requests. Commands can also be assembled into a composite command.

The pattern adds an extra layer of abstraction in order not to communicate technical classes directly (for example repositories).

### Structure
#### Command
Holds instructions and references to what it needs.
```
public interface ICommand
{
    bool CanExecute();
    void Execute();
    void Undo();
}
```
Concrete command (command implementation) defines a binding between a Receiver and action. 

It implements `Execute()` by invoking the corresponding operations on Receiver
```
...
// receiver
private readonly IItemsRepository _itemsRepository;

public void Execute()
{
    // _receiver.PerformAction();
    _itemsRepository.RemoveAll();
}
...
```
#### Receiver
Is what the command will execute.
```
public class ItemsRepository
{
    public void RemoveItems()
    {
        ...
    } 
}
```
#### Invoker
Invoker asks Command to cary out a request, for example a button.
```
public class CommandManager
{
    public void Invoke(ICommand command)
    {
        ...
        command.Invoke();
    }
}
```
#### Client
Creates the concrete command and sets its receiver.
```
...
public void HandleClick()
{
    var receiver = GetItemsRepository();
    var command = new PerformActionCommand(data, receiver);
    _commandManager.Invoke(command);
}
...
```

### Related patterns
- Composite
- Memento
- Prototype
- Chain of responsibility
- Mediator
- Observer

### Other useful examples
- String formatting