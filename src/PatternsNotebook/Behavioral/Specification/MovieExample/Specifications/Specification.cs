using System.Linq.Expressions;

namespace PatternsNotebook.Behavioral.Specification.MovieExample.Specifications;

public abstract class Specification<T>
{
    // Null Object Pattern Example
    public static readonly Specification<T> All = new IdentitySpecification<T>();
    
    public bool IsSatisfiedBy(T entity)
    {
        Func<T, bool> predicate = ToExpression().Compile();
        return predicate(entity);
    }

    public abstract Expression<Func<T, bool>> ToExpression();

    public Specification<T> And(Specification<T> specification)
    {
        // This logical optimization reduces expression complexity, since all is always true.
        // Otherwise an additional logical operation would be executed.
        // This would be especially visible when constructing database queries - EXPRESSION and 1=1
        if (this == All)
            return specification;
        if (specification == All)
            return this;
        return new AndSpecification<T>(this, specification);
    }
    
    public Specification<T> Or(Specification<T> specification)
    {
        // This logical optimization reduces expression complexity, since all is always true.
        // Otherwise an additional logical operation would be executed.
        // This would be especially visible when constructing database queries - EXPRESSION and 1=1
        if (this == All || specification == All)
            return All;
        
        return new OrSpecification<T>(this, specification);
    }
    
    public Specification<T> Not()
    {
        return new NotSpecification<T>(this);
    }
}

// Null Object Pattern Example
internal sealed class IdentitySpecification<T> : Specification<T>
{
    public override Expression<Func<T, bool>> ToExpression()
    {
        return x => true;
    }
}

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

        // TODO: examine below, it is supposed to be sufficient
        // BinaryExpression and = Expression.AndAlso(left.Body, right.Body);
        // return Expression.Lambda<Func<T, bool>>(and, left.Parameters.Single());

        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.AndAlso(left.Body, right.Body);
        body = (BinaryExpression) new ParameterReplacer(parameter).Visit(body);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}

internal sealed class OrSpecification<T> : Specification<T>
{
    private readonly Specification<T> _left;
    private readonly Specification<T> _right;

    public OrSpecification(Specification<T> left, Specification<T> right)
    {
        _left = left;
        _right = right;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T,bool>> left = _left.ToExpression();
        Expression<Func<T, bool>> right = _right.ToExpression();

        // TODO: examine below, it is supposed to be sufficient
        // BinaryExpression or = Expression.OrElse(left.Body, right.Body);
        // return Expression.Lambda<Func<T, bool>>(or, left.Parameters.Single());
        
        var parameter = Expression.Parameter(typeof(T));
        var body = Expression.OrElse(left.Body, right.Body);
        body = (BinaryExpression) new ParameterReplacer(parameter).Visit(body);
        return Expression.Lambda<Func<T, bool>>(body, parameter);
    }
}

internal sealed class NotSpecification<T> : Specification<T>
{
    private readonly Specification<T> _expression;

    public NotSpecification(Specification<T> expression)
    {
        _expression = expression;
    }

    public override Expression<Func<T, bool>> ToExpression()
    {
        Expression<Func<T,bool>> expression = _expression.ToExpression();

        UnaryExpression not = Expression.Not(expression.Body);
        return Expression.Lambda<Func<T, bool>>(not, expression.Parameters.Single());
    }
}

/// <summary>
/// Technical solution for combining lambda expressions
/// </summary>
internal class ParameterReplacer : ExpressionVisitor {
    private readonly ParameterExpression _parameter;

    protected override Expression VisitParameter(ParameterExpression node) {
        return base.VisitParameter(_parameter);
    }

    internal ParameterReplacer(ParameterExpression parameter) {
        _parameter = parameter;
    }
}
