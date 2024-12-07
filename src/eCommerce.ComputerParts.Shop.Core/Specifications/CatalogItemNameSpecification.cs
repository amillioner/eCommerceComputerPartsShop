using Ardalis.Specification;
using eCommerce.ComputerParts.Shop.Core.Entities;

namespace eCommerce.ComputerParts.Shop.Core.Specifications;

public class CatalogItemNameSpecification : Specification<CatalogItem>
{
    public CatalogItemNameSpecification(string catalogItemName)
    {
        Query.Where(item => catalogItemName == item.Name);
    }
}
