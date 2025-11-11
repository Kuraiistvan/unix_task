using Core.Entities;

namespace Core.Specifications;

public class BrandListSpecifitcaion : Specification<Product, string>
{
    public BrandListSpecifitcaion()
    {
        AddSelect(x => x.Brand);
        ApplyDistinct();
    }
}