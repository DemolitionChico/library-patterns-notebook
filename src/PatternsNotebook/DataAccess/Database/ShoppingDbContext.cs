namespace PatternsNotebook.DataAccess.Database;

// This class is just a stub, similar to the Entity Framework DbContext
public class ShoppingDbContext
{
    public IQueryable<Product> Products { get; set; } = new List<Product>().AsQueryable();
    public IQueryable<Customer> Customers { get; set; } = new List<Customer>().AsQueryable();
    public IQueryable<Order> Orders { get; set; } = new List<Order>().AsQueryable();
    public IQueryable<LineItem> LienItems { get; set; } = new List<LineItem>().AsQueryable();
    public T Add<T>(T entity) where T: class
    {
        return entity;
    }

    public IQueryable<T> Set<T>()
    {
        return new List<T>().AsQueryable();
    }

    // Suitable for entities with Id values, not implemented further in this example 
    // public T? Find<T>(Guid id) where T: class
    // {
    //     return Set<T>().FirstOrDefault(x => x.id == id);
    // }

    public T Update<T>(T entity) where T: class
    {
        T item = Set<T>().FirstOrDefault(x => x == entity) ?? Add(entity);
        item = entity;
        return item;
    }

    public void SaveChanges()
    {
        
    }
}