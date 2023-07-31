using PatternsNotebook.DataAccess.Database;
using PatternsNotebook.DataAccess.Repository;

namespace PatternsNotebook.DataAccess.UnitOfWork;

public interface IUnitOfWork
{
    IRepository<Product> ProductsRepository { get; }
    IRepository<Order> OrdersRepository { get; }

    void SaveChanges();
}