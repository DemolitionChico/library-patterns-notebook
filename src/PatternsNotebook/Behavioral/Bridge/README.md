## Behavioral patterns / Bridge pattern

The intent of this pattern is to decouple an abstraction from its implementations, so the two cam vary independently.
The implementation isn't permanently bound to the abstraction, abstraction can evolve and be introduced independently.
The implementation is hidden from clients.

The pattern along with the example describes interfaces and composition usage.

### Structure
#### Abstraction
Defines the abstraction interface and holds reference to the implementor
```
public interface IAbstraction
{
    int PerformAbstractOperation();
}
```
#### Refined abstraction
Extends the interface defined by Abstraction
```
public class RefinedAbstraction1: IAbstraction
{
    private IImplementor _implementor;
    public void PerformAbstractOperation() 
    {
       return 1 + _implementor.PerformImplementorOperation(); 
    }
}
public class RefinedAbstraction2: IAbstraction
{
    private IImplementor _implementor;
    public void PerformAbstractOperation() 
    {
       return 2 + _implementor.PerformImplementorOperation();
    }
}
```
#### Implementor
Defines the interface for implementation classes
```
public interface IImplementor
{
    int PerformImplementorOperation();
}
```
#### Concrete Implementor
Implements the Implementor interface and defines it's concrete implementation
```
public class ConcreteImplementor1: IImplementor
{
    public int PerformImplementorOperation() 
    {
        return 11;
    }
}
public class ConcreteImplementor2: IImplementor
{
    public int PerformImplementorOperation() 
    {
        return 22;
    }
}
```
### Included
- Null object pattern demonstration (NoCoupon class)

### Related patterns
- Abstract factory
- Adapter
- Strategy
- State

