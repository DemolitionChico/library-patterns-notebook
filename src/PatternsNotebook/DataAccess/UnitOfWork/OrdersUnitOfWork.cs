using PatternsNotebook.DataAccess.Database;
using PatternsNotebook.DataAccess.Repository;

namespace PatternsNotebook.DataAccess.UnitOfWork;


// The intent of this pattern is to share a common db context, so that th SaveChanges method is called once
// just after all operations are performed.
// The unit of work is a technical aggregate that collects together repositories that work together business-wise
class OrdersUnitOfWork : IUnitOfWork
{
    private ShoppingDbContext _ctx;

    private IRepository<Product> _productsRepository;
    private IRepository<Order> _ordersRepository;

    #pragma warning disable CS8618
    public OrdersUnitOfWork(ShoppingDbContext ctx)
    {
        _ctx = ctx;
    }
    #pragma warning restore CS8618

    public IRepository<Product> ProductsRepository => _productsRepository ??= new GenericProductRepository(_ctx);

    public IRepository<Order> OrdersRepository => _ordersRepository ??= new GenericOrderRepository(_ctx);

    public void SaveChanges()
    {
        _ctx.SaveChanges();
    }
}