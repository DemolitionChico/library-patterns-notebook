## Behavioral patterns / Observer pattern

The intent is to set a one-to-many dependency relationship between objects, so that when one object gets updated, all it's dependencies get notified and updated automatically. 

### Structure
#### Observer
Defines an abstraction for objects that are supposed to be notified about the update (listen to the subject updates)
```
public abstract class Observer
{
    public abstract void Update();
}

```
#### Subject
Defines an abstraction for an object that notifies it's dependencies when updated. 
Subject knows all its observers and is able to attach and detach them
```
public abstract class Subject
{
    public abstract void Attach(Observer observer);
    public abstract void Detach(Observer observer);
    public abstract void Notify();
}

```
#### Concrete Subject 
Stores its state, which is of interest to Concrete observers, and sends notifications to its observer once its state changes


### Related patterns
- Mediator
- Command
- Chain of Responsibility
