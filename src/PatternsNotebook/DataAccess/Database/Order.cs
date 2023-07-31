namespace PatternsNotebook.DataAccess.Database;

public class Order
{
    public Guid Id { get; set; }
    public List<LineItem> LineItems { get; set; }
    public OrderStatus Status { get; set; }

    public enum OrderStatus
    {
        Open = 1,
        Closed
    }

    public Order()
    {
        LineItems = new List<LineItem>();
    }
}