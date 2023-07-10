## Behavioral patterns / Specification pattern

The intent of this pattern is to encapsulate a domain knowledge into a single unit, to be reused in various scenarios.
Common use cases:
- Validation
- Retrieving data from the database
- Creation of new objects
The specification object is intended to be able to check whether a given object meets defined domain criteria.

### Dos and don'ts
#### When not to use this pattern
- Don't use the pattern unless you meet at least two of these criteria:
  1. Database / search queries
  2. In-memory validation
  3. Object creation
- Don't use this pattern in very simple applications, as the maintenance cost is already low, and the benefits don't justifying the investment.
- 
#### Anti patterns
- Always use concrete implementations for specifications, don't use generic ones. Generic specifications are non descriptive, and the usage for the client is more complicated.
- Don't expose `IQueryable` interface as a return type from the database just for making query filters easier. Use `ToExpression()` solution instead.
- Don't introduce `ISpecification` interface with the same content as the abstract class, just for the sake of having an interface. This adds no value whatsoever. **#YAGNI**
- Avoid parametrized specifications if not required (not always possible).

#### What to do
- Use strongly typed specifications for better encapsulation.
- Make specifications as precise and specific as possible (eg.: instead of having one specification, like parametrized `MovieMpaaRatingBetweenSpec`, consider splitting it into `MovieForKidsSpec` and `AdultsOnlySpec`).
- Make specifications immutable

#### Objects creation
As stated by Martin Fowler and Eric Evans:
> A way to describe what an object might do, without explaining the details of how the object does it, but in such a way that a candidate might be built to fulfill the requirement

This is used to find a candidate among the list of candidates. This is rarely used subset of In-memory validation.


### Structure
#### Specification definition
A common definition contains `IsSatisfiedBy` method. For the C# definition definition, it is useful to extend it by adding `ToExpression` method, so that the specification can be further used for database queries.
```
public abstract class Specification<T>
{
    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }
    
    public abstract Expression<Func<T, bool>> ToExpression();
}
```
To be able to chain specifications easily, it is useful to place `And()`, `Or()` and `Not()` methods in the specification. 
Below example shows how to implement the `And` part, others work in the same way. You can find them in the code example. 
```
    public Specification<T> And(Specification<T> specification)
    {
        return new AndSpecification<T>(this, specification);
    }
```
The simple example above can be further optimised to prevent unnecessary database queries (see code examples).

The `AndSpecification` implementation used above:
```
internal sealed class AndSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public AndSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T,bool>> left = _left.ToExpression();
        Expression<Func<T, bool>> right = _right.ToExpression();

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(left.Body, right.Body);
        body = (BinaryExpression) new ParameterReplacer(parameter).Visit(body);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}
```

### Other useful examples
- Combining lambda expressions