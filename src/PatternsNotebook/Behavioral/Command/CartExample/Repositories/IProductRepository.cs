namespace PatternsNotebook.Behavioral.Command.CartExample.Repositories;

public interface IProductRepository
{
    void DecreaseStockBy(string productArticleId, int quantity);
    int GetStockFor(string productArticleId);
    void IncreaseStockBy(string productArticleId, int quantity);
}