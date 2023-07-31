using PatternsNotebook.DataAccess.Database;

namespace PatternsNotebook.DataAccess.Repository;

public class GenericProductRepository: GenericRepository<Product>
{
    public GenericProductRepository(ShoppingDbContext ctx) : base(ctx)
    {
    }

    // Possibly restrict what the client is able to update 
    public override Product Update(Product entity)
    {
        var product = ctx.Products.Single(p => p.Id == entity.Id);

        if (product is null)
        {
            product = Add(entity);
        }

        product.Name = entity.Name;
        product.Price = entity.Price;

        return base.Update(product);
    }
}