using System.Linq.Expressions;
using PatternsNotebook.DataAccess.Database;

namespace PatternsNotebook.DataAccess.Repository;

public abstract class GenericRepository<T>
    : IRepository<T> where T: class
{
    protected ShoppingDbContext ctx;

    public GenericRepository(ShoppingDbContext ctx)
    {
        this.ctx = ctx;
    }
    
    public virtual T Add(T entity)
    {
        return ctx.Add(entity);
    }

    public virtual IEnumerable<T> All()
    {
        return ctx.Set<T>().ToList();
    }

    public virtual IEnumerable<T> Find(Expression<Func<T, bool>> predicate)
    {
        return ctx.Set<T>().Where(predicate).ToList();
    }

    // public virtual T? Get(Guid id)
    // {
    //     return ctx.Find<T>(id);
    // }
    
    public virtual T Update(T entity)
    {
        return ctx.Update<T>(entity);
    }

    public virtual void SaveChanges()
    {
        ctx.SaveChanges();
    }
}