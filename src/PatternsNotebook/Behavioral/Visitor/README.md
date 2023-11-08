## Behavioral patterns / Visitor pattern

The definition: "[Visitor] represents an operation to be performed on the elements of an object structure without changing the classes of the elements on which it [the visitor] operates.".
That means new behaviors can be added to an existing hierarchies without changing the underlying classes. 
These behaviors can be class-specific or they can be disconnected from the type hierarchy as long as they operate on classes that are "visitable".

### Pros
1. This pattern makes adding new operations easy, without changing the existing object structure.
2. A visitor can accumulate info about objects it visits.
3. A visitor gathers related operations together.

### Cons
1. Adding a new concrete element might be harder, as you'd need to adjust all the related visitors.
2. Visitor might require breaking encapsulation - it can require access to the data that might normally be hidden. 

### Use cases
- When your object structure contains multiple unrelated objects, and you want to perform the same/similar operation on these objects. Objects interfaces differ, and the operation depends on the data within concrete classes
- When your objects structure does not change often, but you'd often define new operations over the structure
- When you have similar classes and you'd like to perform an operation on some of them, but not all. This way you don't have to pollute unrelated classes with these operations.

### Structure
#### Visitor abstraction
Define an abstraction for performed operation (visit method), usually separate methods for different kinds of objects.
```
public interface IVisitor
{
    void VisistConcreteElementA(ConcreteElementA elemA);
    void VisistConcreteElementB(ConcreteElementB elemB);
}
```
alternatively:
```
public interface IVisitor
{
    void Visit(IElement element);
}
```
#### Concrete visitors
Define an actual operation logic. They can also contain an aggregate state, that accumulates when applying visitor to objects (see the Object structure). That kind of state can be useful for callers (like for example a total amount of discount given).
```
public class ConcreteVisitor1: IVisitor
{
    void VisistConcreteElementA(ConcreteElementA elemA)
    {
    }
    void VisistConcreteElementB(ConcreteElementB elemB)
    {
    }
}
public class ConcreteVisitor2: IVisitor
{
    public void VisistConcreteElementA(ConcreteElementA elemA)
    {
    }
    public void VisistConcreteElementB(ConcreteElementB elemB)
    {
    }
}
```
alternatively (with alternative IVisitor)
````
public class ConcreteVisitor: IVisitor
{
    void Visit(IElement element)
    {
        // check the concrete element type
        // apply behavios based on that type 
    }
}
````
#### Element abstraction
Elements define an Accept method, that take visitor (the operation) as a parameter.
```
public interface IElement
{
    void Accept(IVisitor visitor);
}
```
#### Concrete elements
```
public class ConcreteElementA: IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementA(this);
    }
    public void OperationA();
}
public class ConcreteElementB: IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.VisitConcreteElementB(this);
    }
    public void OperationB();
}
```
alternatively (with alternative IVisitor)
````
public class ConcreteElementA: IElement
{
    public void Accept(IVisitor visitor)
    {
        visitor.Visit(this);
    }
    public void OperationA();
}
````
### OBJECT STRUCTURE
The object structure is an abstraction layer of the app, which should be the only access point to the visitor pattern in the calling code. Usually, if present, it enumerates visitable elements (IElement objects) and applies operations defined by the visitor.

### Related patterns
- Composite
- Iterator (when used to traverse potentially complex data structure to apply visitors)
