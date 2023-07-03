using PatternsNotebook.Behavioral.Command.CartExample.Repositories.Models;

namespace PatternsNotebook.Behavioral.Command.CartExample.Repositories;

public interface IShoppingCartRepository
{
    void Add(string productArticleId);
    void Remove(string productArticleId);
    LineItem Get(string productArticleId);
    void IncreaseQuantity(string productArticleId, int quantity);
    void DecreaseQuantity(string productArticleId, int quantity);
}