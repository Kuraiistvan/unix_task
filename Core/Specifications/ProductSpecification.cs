using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Windows.Markup;
using Core.Entities;

namespace Core.Specifications;

public class ProductSpecification : Specification<Product>
{
    public ProductSpecification(ProductParams specParams) : base(x =>
    (string.IsNullOrEmpty(specParams.Search) || x.Name.ToLower().Contains(specParams.Search.ToLower())) &&
    (!specParams.Brands.Any() || specParams.Brands.Contains(x.Brand)) &&
    (!specParams.Types.Any() || specParams.Types.Contains(x.Type)))
    {
        ApplyPaging(specParams.PageSize * (specParams.PageIndex -1), specParams.PageSize);

        if (specParams.minPrice != null && specParams.maxPrice != null)
            AddPriceBetween(x => x.Price >= specParams.minPrice && x.Price <= specParams.maxPrice);

        switch (specParams.Sort)
        {
            case "priceAsc":
                AddOrderBy(x => x.Price);
                break;
            case "priceDesc":
                AddOrderByDesc(x => x.Price);
                break;
            default:
                AddOrderBy(x => x.Name);
                break;
        }
    }
}