namespace PatternsNotebook.Behavioral.Visitor.DiscountExample;

public class VisitorCartExample: ExampleBase
{
    protected override void Execute()
    {
        var itemsList = new List<IElement>
        {
            new Book(1, 19.99m),
            new Book(2, 49.00m),
            new Book(3, 99.99m),
            new Book(4, 109.00m),
            new Vinyl(5, 9.99m),
            new Vinyl(6, 59.00m),
            new Vinyl(7, 89.99m),
            new Vinyl(8, 299.00m)
        };

        var cart = new Cart(itemsList);
        cart.ApplyDiscount();
        cart.AcceptCart();
    }
}