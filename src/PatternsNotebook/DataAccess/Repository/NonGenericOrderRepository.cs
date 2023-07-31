using PatternsNotebook.DataAccess.Database;

namespace PatternsNotebook.DataAccess.Repository;

public class NonGenericOrderRepository
{
    private readonly ShoppingDbContext _ctx;
    
    public NonGenericOrderRepository(ShoppingDbContext ctx)
    {
        _ctx = ctx;
    }

    public Order GetOrder(Guid id)
    {
        return _ctx.Set<Order>().FirstOrDefault(x => x.Id == id);
    }

    public void AddLineItem(Guid orderId, LineItem lineItem)
    {
        var order = _ctx.Set<Order>().FirstOrDefault(x => x.Id == orderId);
        lineItem.OrderId = orderId;
        _ctx.Add(lineItem);
        order?.LineItems.Add(lineItem);
        _ctx.Update(order);
        _ctx.SaveChanges();
    }

    public void CloseOrder(Guid id)
    {
        var order = _ctx.Set<Order>().FirstOrDefault(x => x.Id == id);
        if (order == null) return;
        order.Status = Order.OrderStatus.Closed;
        _ctx.Update(order);
    }
}