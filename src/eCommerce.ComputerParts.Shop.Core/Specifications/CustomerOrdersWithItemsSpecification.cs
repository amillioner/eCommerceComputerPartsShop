﻿using Ardalis.Specification;
using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;

namespace eCommerce.ComputerParts.Shop.Core.Specifications;

public class CustomerOrdersWithItemsSpecification : Specification<Order>
{
    public CustomerOrdersWithItemsSpecification(string buyerId)
    {
        Query.Where(o => o.BuyerId == buyerId)
            .Include(o => o.OrderItems)
                .ThenInclude(i => i.ItemOrdered);
    }
}