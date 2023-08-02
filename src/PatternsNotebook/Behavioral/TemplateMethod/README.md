## Behavioral patterns / Template Method pattern

A template method is a method in a superclass that defines the high level operation steps, where subclasses implement these steps.
This means defining a sequence in a superclass, but allowing details of each steps to vary.
Examples: game or UI framework lifecycle - client is able to implement/extend steps, but has no influence on the lifecycle

### Use cases
- Locking down the process while allowing clients to alter steps of the process
- Generalizing duplication amongst several classes
- Frameworks - create and control extension points for future implementations

### Structure
#### Abstraction
Defines a base class containing the Template Method defining a sequence of operations, which is not supposed to be overwritten,
and simple operations that should be implemented by concrete implementations. 
```
public abstract class Template
{
    public void TemplateMethod() 
    {
        if(!Operation1()) 
        {
            return;
        }
        var result = Operation2();
        Operation3(result);
    }
    protected abstract bool Operation1();
    protected abstract int Operation2();
    protected abstract void Operation1(int input);
}

```
#### Concrete implementation
Define steps in the process. The template method is not supposed to be touched, only the process steps are to be implemented.
Following the "Hollywood principle" ("Don't call us, we'll call you"). 
Instead of driving the operation, the client leaves that for the template method, and only provides details needed for running a particular variant of such operation

### Related patterns
- Factory Method
- Strategy
- Rules engine

### Other useful examples
- Json deserialization
- Xml deserialization