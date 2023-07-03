using PatternsNotebook.Behavioral.Command.CartExample.Repositories.Models;

namespace PatternsNotebook.Behavioral.Command.CartExample.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly Dictionary<string, Product> _products = new Dictionary<string, Product>()
    {
        {"001", new Product("001", 5)},
        {"002", new Product("002", 1)},
        {"003", new Product("003", 0)}
    };

    public void DecreaseStockBy(string productArticleId, int quantity)
    {
        if (!_products.TryGetValue(productArticleId, out var product))
        {
            throw new InvalidOperationException("Trying to reference an inexisting product.");
        }

        product.Quantity -= quantity;
    }

    public int GetStockFor(string productArticleId)
    {
        if (!_products.TryGetValue(productArticleId, out var product))
        {
            throw new InvalidOperationException("Trying to reference an inexisting product.");
        }

        return product.Quantity;
    }

    public void IncreaseStockBy(string productArticleId, int quantity)
    {
        if (!_products.TryGetValue(productArticleId, out var product))
        {
            throw new InvalidOperationException("Trying to reference an inexisting product.");
        }

        product.Quantity += quantity;
    }
}