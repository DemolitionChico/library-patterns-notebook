namespace PatternsNotebook.Behavioral.Visitor.DiscountExample;

public interface IVisitor
{
    void VisitBook(Book book);
    void VisitVinyl(Vinyl vinyl);
}

public interface IElement
{
    void Accept(IVisitor visitor);
}

public class DiscountVisitor : IVisitor
{
    private const decimal DiscountOnBooks = 0.1m;
    private const decimal FixedDiscountedPriceOnVinyls = 0.1m;

    // aggregate data
    private int _discountedVinylsCounter = 0;
    public decimal TotalSavings { get; private set; }
    
    public void VisitBook(Book book)
    {
        // only give a discount if the book costs more than 20.00$
        if (book.Price > 20)
        {
            var discountedPrice = book.Price * (1m - DiscountOnBooks);
            Console.WriteLine($"Discount ${Math.Round(book.Price - discountedPrice, 2)} on book {book.Id}");
            TotalSavings += book.Price - discountedPrice;
        }
        else
        {
            Console.WriteLine($"No discount on book {book.Id}");
        }
    }

    public void VisitVinyl(Vinyl vinyl)
    {
        _discountedVinylsCounter++;
        // set a fixed price on every third vinyl
        if (_discountedVinylsCounter % 3 == 0)
        {
            var discountedPrice = FixedDiscountedPriceOnVinyls;
            _discountedVinylsCounter = 0;
            Console.WriteLine($"Discount ${Math.Round(vinyl.Price - discountedPrice, 2)} on vinyl {vinyl.Id}");
            TotalSavings += vinyl.Price - discountedPrice;
        }
        else
        {
            Console.WriteLine($"No discount on book vinyl {vinyl.Id}");   
        }
    }
    
    public void PrintResults()
    {
        Console.WriteLine($"Total savings on this order: {Math.Round(TotalSavings, 2)}");
    }
}

public class SalesVisitor : IVisitor
{
    private int _booksSold;
    private int _vinylsSold;
    public void VisitBook(Book book)
    {
        _booksSold++;
    }

    public void VisitVinyl(Vinyl vinyl)
    {
        _vinylsSold++;
    }

    public void PrintResults()
    {
        Console.WriteLine($"Store sold {_booksSold} books and {_vinylsSold} vinyls today.");
    }
}