using Core.Entities;

namespace Core.Specifications;

public class TypeListSpecifitcaion : Specification<Product, string>
{
    public TypeListSpecifitcaion()
    {
        AddSelect(x => x.Type);
        ApplyDistinct();
    }
}