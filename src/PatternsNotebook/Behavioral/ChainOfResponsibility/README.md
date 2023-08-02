## Behavioral patterns / Chain of Responsibility pattern

The intent is to decouple the sender of the request from its receiver and making it possible for more than one object to handle the request.
It's done by chaining receivers and passing the request along the chain until it's handled.

### Use cases
- More than one object may handle a request and/or the handler is not known beforehand
- Issuing a request to several or one of several handler without  specifying the receiver explicitly
- When set of objects that handle the request are specified dynamically

### Structure
#### Handler
Defines an abstraction for objects that handle the request and set the next handler in the pipeline (optionally)
```
public interface IHandler<T>
{
    void Handle(T request);
    IHandler<T> SetSuccessor(IHandler<T> successor);
}

```
#### Concrete handler
Handles the request if possible. Can access the successor and potentially pass the request on

#### Client
Initiates the request to a concrete handler object

### Related patterns
- Mediator
- Observer
- Command
- Composite
