using Ardalis.Specification;
using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;

namespace eCommerce.ComputerParts.Shop.Core.Specifications;

public class OrderWithItemsByIdSpec : Specification<Order>
{
    public OrderWithItemsByIdSpec(int orderId)
    {
        Query
            .Where(order => order.Id == orderId)
            .Include(o => o.OrderItems)
            .ThenInclude(i => i.ItemOrdered);
    }
}
