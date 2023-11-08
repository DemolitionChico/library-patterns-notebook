namespace PatternsNotebook.Behavioral.Visitor.DiscountExample;

public abstract class ShopItem
{
    public int Id { get; private set; }
    public decimal Price
    { get; private set; }

    protected ShopItem(int id, decimal price)
    {
        Id = id;
        Price = price;
    }
}

public sealed class Book: ShopItem, IElement
{
    public Book(int id, decimal price) : base(id, price)
    {
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitBook(this);
    }
}

public sealed class Vinyl : ShopItem, IElement
{
    public Vinyl(int id, decimal price) : base(id, price)
    {
    }

    public void Accept(IVisitor visitor)
    {
        visitor.VisitVinyl(this);
    }
}