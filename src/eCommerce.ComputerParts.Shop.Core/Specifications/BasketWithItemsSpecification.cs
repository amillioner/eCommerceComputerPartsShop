using Ardalis.Specification;
using eCommerce.ComputerParts.Shop.Core.Entities.BasketAggregate;

namespace eCommerce.ComputerParts.Shop.Core.Specifications;

public sealed class BasketWithItemsSpecification : Specification<Basket>
{
    public BasketWithItemsSpecification(int basketId)
    {
        Query
            .Where(b => b.Id == basketId)
            .Include(b => b.Items);
    }

    public BasketWithItemsSpecification(string buyerId)
    {
        Query
            .Where(b => b.BuyerId == buyerId)
            .Include(b => b.Items);
    }
}
