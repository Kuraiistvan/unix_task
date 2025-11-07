using Core.Entities;
using Core.Interfaces;

namespace Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    public void AddProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public void DeleteProduct(Product product)
    {
        throw new NotImplementedException();
    }

    public Task<Product> GetProductAsync(int id)
    {
        throw new NotImplementedException();
    }

    public Task<IReadOnlyList<Product>> GetProductsAsync()
    {
        throw new NotImplementedException();
    }

    public bool ProductExist(int id)
    {
        throw new NotImplementedException();
    }

    public Task<bool> SaveChangesAsyns()
    {
        throw new NotImplementedException();
    }

    public void UpdateProduct(Product product)
    {
        throw new NotImplementedException();
    }
}