using eCommerce.ComputerParts.Shop.Core.Interfaces;

namespace eCommerce.ComputerParts.Shop.Core.Entities;

public class CatalogType : BaseEntity, IAggregateRoot
{
    public string Type { get; private set; }
    public CatalogType(string type)
    {
        Type = type;
    }
}
