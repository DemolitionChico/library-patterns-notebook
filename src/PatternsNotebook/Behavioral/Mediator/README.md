## Behavioral patterns / Mediator pattern

This pattern encapsulates the way objects interact with each other, avoiding objects referring directly to each other and promotes loose coupling.
The pattern simplifies many-to-many relationships and makes it one-to-many. The downside of that is centralization, which makes the mediator a monolith.

### Use cases
- A set of objects communicate in well-defined but complex ways, otherwise resulting in difficult to define dependencies and references
- An object refers to and communicates with many other objects, so it's difficult to reuse
- Distributed behavior without multiple subclasses 

### Structure
#### Mediator
Defines an abstraction for the way colleagues communicate
```
public abstract class Mediator
{
    private List<Colleague> _colleagues = new List<Colleague>();

    public abstract void Send(string message, Colleague sender);
    
    public void Register(Colleague colleague) 
    {
        colleague.SetMediator(this);
        _colleagues.Add(colleague);
    }
}

```
##### Variation - creating colleagues from within a mediator
```
public abstract class Mediator
{
    ...
    public T CreateColleague<T>() where T: Colleague, new()
    {
        var c = new T();
        c.SetMediator(this);
        _colleagues.Add(c);
        return c;
    }
    ...
}
```
#### Concrete Mediator
Implements communication between colleagues
```
public class ConcreteMediator: Mediator
{
    public override void Send(string message, Colleague sender)
    {
        _colleagues.Where(c => c != sender).ToList().ForEach(c => c.HandleNotification(message));
    }
}
```
#### Colleague
Defines an abstraction for communication with the mediator, only communicating with the mediator
```
public abstract class Colleague
{
    protected Mediator _mediator;
    
    public Colleague()
    {
    }
    
    public virtual void Send(string message)
    {
        _mediator.Send(message, this);
    }
    
    public void SetMediator(Mediator mediator)
    {
        _mediator = mediator;
    }
    
    public abstract void HandleNotification(string message);
}
```
#### Concrete Colleague
Receives and handles messages from the mediator
```
public class Colleague1: Colleague 
{
    public Colleague1(Mediator mediator) : base(mediator)
    { }
    
    public override void HandleNotification(string message) 
    {
        Console.WriteLine($"Colleague1 receives message: {message}"); 
    }
}
public class Colleague2: Colleague 
{
    public Colleague2(Mediator mediator) : base(mediator)
    { }
    
    public override void HandleNotification(string message) 
    {
        Console.WriteLine($"Colleague2 receives message: {message}"); 
    }
}
```


### Related patterns
- Observer
- Command
- Chain of Responsibility
