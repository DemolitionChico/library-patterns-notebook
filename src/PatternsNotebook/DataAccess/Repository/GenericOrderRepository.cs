using System.Linq.Expressions;
using PatternsNotebook.DataAccess.Database;

namespace PatternsNotebook.DataAccess.Repository;

public class GenericOrderRepository: GenericRepository<Order>
{
    public GenericOrderRepository(ShoppingDbContext ctx) : base(ctx)
    {
    }

    public override IEnumerable<Order> Find(Expression<Func<Order, bool>> predicate)
    {
        // For Entity Framework applications, you should use Include() method.
        // The idea is that the LineItems repository is not necessary, as th Order layer is the one we should use 
        // for communication.
        // Solution below is suboptimal, as it introduces N + 1 requests problem,
        // but it's memory only lookup and not the real database app (most ORMs have a way of solving N + 1 problem) 
        List<Order> orders = ctx.Orders.Where(predicate).ToList();
        orders.Select(o =>
        {
            var lineItems = ctx.LienItems.Where(i => i.OrderId == o.Id);
            o.LineItems = lineItems.ToList();
            return o;
        });
        return orders;
    }

    public override Order Update(Order order)
    {
        // The same as above - for EntityFramework you should use Include() method
        var lineItems = order.LineItems;
        foreach (var lineItem in lineItems)
        {
            ctx.Update(lineItem);
        }
        return base.Update(order);
    }
}