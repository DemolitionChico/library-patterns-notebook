## Behavioral patterns / State pattern

> State is the condition of something variable

The intent of this pattern is to allow objects to modify their behavior when their state changes.
Example: different states of an order:
- New
- Processing
- Canceled
- Complete
Can a canceled order be edited? Or Can a completed order be canceled?
With this pattern, state transitions and state dependant behaviors are handled in the state objects themselves (encapsulated state-specific behaviors within separate state objects).
Context passes requests through to the underlying state objects to handle them (delegates the execution of the state-specific behaviors to one state object at a time).

Use cases
- When an object's behavior depends on its state and it must change it at runtime (depending on the state)
- Dealing with large conditional statements that depend on the object's state
The pattern substitutes multiple complex conditional statements; they become easier to manage.

### Structure
#### Context 
Defines the interface that is of interest to clients. It maintains the instance of a ConcreteState subclass, that defines the current state.
```
public class Context
{
    public State ContextState { get; set; }

    public Context()
    {
        ContextState = new InitialState();
    }

    public void PerformOperation()
    {
        ContextState.PerformOperation();
    }
}
```
#### State 
Defines an interface for the state of the context. Also, holds a reference to the Context, so that it is able to transition to other states.
```
public abstract class State
{
    protected Context Context { get; init; } = null!;
    
    public abstract void PerformOperation();
}
```
#### ConcreteStates 
Implement behaviors associated with the state of the context.
```
class InitialState : State
{
    public override void PerformOperation()
    {
        // ...
        // some business operations
        // ...
        // and state change if required, according to the flow
        Context.State = new SomeOtherState();
    }
}
```
### Related patterns
- **Flyweight**
- Singleton
- Strategy
- Bridge
