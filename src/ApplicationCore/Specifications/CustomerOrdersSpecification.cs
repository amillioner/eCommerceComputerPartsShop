using Ardalis.Specification;
using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;

namespace eCommerce.ComputerParts.Shop.Core.Specifications;

public class CustomerOrdersSpecification : Specification<Order>
{
    public CustomerOrdersSpecification(string buyerId)
    {
        Query.Where(o => o.BuyerId == buyerId)
            .Include(o => o.OrderItems);
    }
}
