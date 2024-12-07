using System.Linq;
using Ardalis.Specification;
using eCommerce.ComputerParts.Shop.Core.Entities;

namespace eCommerce.ComputerParts.Shop.Core.Specifications;

public class CatalogItemsSpecification : Specification<CatalogItem>
{
    public CatalogItemsSpecification(params int[] ids)
    {
        Query.Where(c => ids.Contains(c.Id));
    }
}
