namespace PatternsNotebook.Behavioral.Visitor.DiscountExample;

public class Cart
{
    private readonly List<IElement> _items;
    private readonly DiscountVisitor _discountVisitor;
    private readonly SalesVisitor _salesVisitor;

    public Cart(List<IElement> items)
    {
        _items = items;
        _discountVisitor = new DiscountVisitor();
        _salesVisitor = new SalesVisitor();
    }

    public void ApplyDiscount()
    {
        foreach (var item in _items)
        {
            item.Accept(_discountVisitor);
        }
    }

    public void AcceptCart()
    {
        // do some other stuff
        foreach (var item in _items)
        {
            item.Accept(_salesVisitor);
        } 
        _discountVisitor.PrintResults();
        _salesVisitor.PrintResults();
    }
}