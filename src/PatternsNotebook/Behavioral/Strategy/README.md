## Behavioral patterns / Strategy pattern

The intent of this pattern is to define a family of algorithms, encapsulate each and make them interchangeable. Strategy separates different algorithms from clients that use them.

### Structure
#### Strategy definition
A common strategy interface implemented by different strategy with a similar purpose. A strategy interface defines how to work with a given strategy.
```
public interface IStrategy<in T>
{
    void Execute(T input);
}
```
#### Context
A context has a reference to a strategy and invokes it. A base context class common between strategies. This base class exists to show two different context variations.
```
public abstract class Context
{
    public string Property { get; set; }
}
```
1. Context variant with an internal strategy set from the outside, by the caller.
```
public class ContextWithInternalExecutor : Context
{
    private IStrategy<Context> Strategy { get; init; }
    
    public ContextWithInternalExecutor(IStrategy<Context> strategy)
    {
        Strategy = strategy;
    }
    
    public void ExecuteStrategy()
    {
        Strategy.Execute(this);
    }
}
```
2. Context variant with the strategy provided in the call, by the caller.
```
public class ContextWithExternalExecutor : Context
{
    public void ExecuteStrategy(IStrategy<Context> strategy)
    {
        strategy.Execute(this);
    }
}
```
#### Concrete strategy implementations:
```
public class ConcreteStrategyA : IStrategy<Context>
{
    public void Execute(Context input)
    {
        Console.WriteLine("Concrete implementation of the strategy: A");
        Console.WriteLine(input.Property);
    }
}

public class ConcreteStrategyB : IStrategy<Context>
{
    public void Execute(Context input)
    {
        Console.WriteLine("Concrete implementation of the strategy: B");
        Console.WriteLine(input.Property.ToUpper());
    }
}

public class ConcreteStrategyC : IStrategy<Context>
{
    public void Execute(Context input)
    {
        Console.WriteLine("Concrete implementation of the strategy: C");
        Console.WriteLine(input.Property.Reverse());
    }
}
```
#### Usage
```
ContextWithInternalExecutor ctx = new ContextWithInternalExecutor(new ConcreteStrategyA());
ctx.ExecuteStrategy();
```
or
```
ContextWithExternalExecutor ctx = new ContextWithExternalExecutor();
IStrategy<Context> strategy = new ConcreteStrategyA();
ctx.ExecuteStrategy(strategy);
```

### Related patterns
- **Flyweight**
- Bridge
- State
- Template method

### Other useful examples
- Json serialization
- Xml serialization
- Sending emails (mailtrap)
- Sending Slack messages via webhooks