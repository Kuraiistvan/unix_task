using System.Text;
using Core.Entities;
using Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Data;

public class ProductRepository : IProductRepository
{
    private readonly StoreContext context;

    public int PageSize { get; set; } = 5;

    public ProductRepository(StoreContext context)
    {
        this.context = context;
    }
    
    public void AddProduct(Product product)
    {
        context.Products.Add(product);
    }

    public void DeleteProduct(Product product)
    {
        context.Products.Remove(product);
    }

    public async Task<Product?> GetProductAsync(int id)
    {
        return await context.Products.FindAsync(id);
    }

    public async Task<IReadOnlyList<string>> GetProductBrandsAsync()
    {
        return await context.Products.Select(x => x.Brand)
        .Distinct()
        .ToListAsync();
    }

    public async Task<IReadOnlyList<string>> GetProductTypesAsync()
    {
        return await context.Products.Select(x => x.Type)
        .Distinct()
        .ToListAsync();
    }

    public async Task<IReadOnlyList<Product>> GetProductsByPriceRange(decimal? minPrice, decimal? maxPrice)
    {
        if (minPrice == null) minPrice = context.Products.OrderBy(x => x.Price).FirstOrDefault().Price;
        if (maxPrice == null) maxPrice = context.Products.OrderBy(x => x.Price).LastOrDefault().Price;

        return await context.Products.Where(x => x.Price >= minPrice && x.Price <= maxPrice).ToListAsync();
    }

    public async Task<IReadOnlyList<Product>> GetProductsAsync(string? brand, string? type, string? sort, string? search, int? page)
    {
        var query = context.Products.AsQueryable();
        int skipSize = page ?? 0 * PageSize;

        if (!string.IsNullOrEmpty(brand))
            query = query.Where(x => x.Brand == brand);
        if (!string.IsNullOrEmpty(type))
            query = query.Where(x => x.Type == type);
        if (!string.IsNullOrEmpty(search))
            query = query.Where(x => x.Name.ToLower().Contains(search.ToLower()));

        query = sort switch
        {
            "priceAsc" => query.OrderByDescending(x => x.Price),
            "priceDesc" => query.OrderByDescending(x => x.Price),
            _ => query.OrderBy(x => x.Name)
        };

        return await query.Skip(skipSize).Take(PageSize).ToListAsync();
    }

    public bool ProductExist(int id)
    {
        return context.Products.Any(x => x.Id == id);
    }

    public async Task<bool> SaveChangesAsync()
    {
        return await context.SaveChangesAsync() > 0;
    }

    public void UpdateProduct(Product product)
    {
        context.Entry(product).State = EntityState.Modified;
    }
}