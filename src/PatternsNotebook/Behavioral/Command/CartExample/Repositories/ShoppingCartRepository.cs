using PatternsNotebook.Behavioral.Command.CartExample.Repositories.Models;

namespace PatternsNotebook.Behavioral.Command.CartExample.Repositories;

public class ShoppingCartRepository : IShoppingCartRepository
{
    private readonly Dictionary<string, LineItem> _lineItems = new Dictionary<string, LineItem>();

    public void Add(string productArticleId)
    {
        Add(productArticleId, 1);
    }

    public void Remove(string productArticleId)
    {
        _lineItems.Remove(productArticleId);
    }

    public LineItem Get(string productArticleId)
    {
        if (!_lineItems.TryGetValue(productArticleId, out var item))
        {
            throw new InvalidOperationException("Trying to reference an inexisting line item.");
        }

        return item;
    }

    public void IncreaseQuantity(string productArticleId, int quantity)
    {
        if (!_lineItems.TryGetValue(productArticleId, out var item))
        {
            Add(productArticleId, quantity);
            return;
        }

        item.Quantity += quantity;
    }

    public void DecreaseQuantity(string productArticleId, int quantity)
    {
        if (!_lineItems.TryGetValue(productArticleId, out var item))
        {
            throw new InvalidOperationException("Trying to reference an inexisting line item.");
        }

        if (--item.Quantity <= 0)
        {
            _lineItems.Remove(productArticleId);
        }
    }
    
    private void Add(string productArticleId, int quantity)
    {
        _lineItems.Add(productArticleId, new LineItem { Quantity = quantity});
    }

    public void Print()
    {
        Console.WriteLine("-------Shopping cart------");
        foreach (var key in _lineItems.Keys)
        {
            Console.WriteLine("{0,20}{1,6}", key, _lineItems[key].Quantity);
        }
        Console.WriteLine("--------------------------");
        Console.WriteLine();
    }
}