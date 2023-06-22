## Behavioral patterns / Singleton pattern

The intent is for a class to only ever have one instance. The class itself is designed to enforce this requirement. This is usually used when sharing resources - eg. filesystem access or access to a shared network service, or, when the class creation cost is high enough so that it is reasonable to only create an instance once.

### Structure
#### Definition
A single class with a private constructor, private instance and a property exposing the only way to reference that instance.
```
public sealed class Singleton
{
    private Singleton _instance;
    static Singleton Instance => _instance;
    
    private Singleton() 
    {
        _instance = new Singleton();
    }
}
```
Above is the concept description. For detailed info of different singleton variants, take a look at code examples.

### Why is Singleton considered an anti-pattern
1. It's difficult to test due to shared state
2. Doesn't follow Separation of Concerns 
3. Doesn't follow Single Responsibility - manages logic and lifecycle
4. Doesn't follow DRY - implementing more singletons would enforce implementing the same lifecycle management
5. There are better alternatives
   - Static classes (can't implement interfaces, can't be passed as arguments, can't be assigned, do not support polymorphism, can't have state, can't be serialized)

In C# apps, usually there is no need to create a singleton - IoC Containers can be used to enforce a single instance of the regular class.