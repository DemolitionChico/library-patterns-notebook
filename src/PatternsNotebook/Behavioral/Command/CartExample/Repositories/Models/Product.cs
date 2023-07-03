namespace PatternsNotebook.Behavioral.Command.CartExample.Repositories.Models;

public class Product
{
    public Product(string articleId, int quantity)
    {
        ArticleId = articleId;
        Quantity = quantity;
    }

    public string ArticleId { get; init; }
    public int Quantity { get; set; }
}