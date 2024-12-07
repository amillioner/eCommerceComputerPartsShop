using eCommerce.ComputerParts.Shop.Core.Interfaces;

namespace eCommerce.ComputerParts.Shop.Core.Entities;

public class CatalogBrand : BaseEntity, IAggregateRoot
{
    public string Brand { get; private set; }
    public CatalogBrand(string brand)
    {
        Brand = brand;
    }
}
