﻿using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;
using Xunit;

namespace eCommerce.ComputerParts.Shop.UnitTests.ApplicationCore.Specifications;

public class CustomerOrdersWithItemsSpecification
{
    private readonly string _buyerId = "TestBuyerId";
    private Address _shipToAddress = new Address("Street", "City", "OH", "US", "11111");

    [Fact]
    public void ReturnsOrderWithOrderedItem()
    {
        var spec = new eCommerce.ComputerParts.Shop.Core.Specifications.CustomerOrdersWithItemsSpecification(_buyerId);

        var result = spec.Evaluate(GetTestCollection()).FirstOrDefault();

        Assert.NotNull(result);
        Assert.NotNull(result.OrderItems);
        Assert.Equal(1, result.OrderItems.Count);
        Assert.NotNull(result.OrderItems.FirstOrDefault()?.ItemOrdered);
    }

    [Fact]
    public void ReturnsAllOrderWithAllOrderedItem()
    {
        var spec = new eCommerce.ComputerParts.Shop.Core.Specifications.CustomerOrdersWithItemsSpecification(_buyerId);

        var result = spec.Evaluate(GetTestCollection()).ToList();

        Assert.NotNull(result);
        Assert.Equal(2, result.Count);
        Assert.Equal(1, result[0].OrderItems.Count);
        Assert.NotNull(result[0].OrderItems.FirstOrDefault()?.ItemOrdered);
        Assert.Equal(2, result[1].OrderItems.Count);
        Assert.NotNull(result[1].OrderItems.ToList()[0].ItemOrdered);
        Assert.NotNull(result[1].OrderItems.ToList()[1].ItemOrdered);
    }

    public List<Order> GetTestCollection()
    {
        var ordersList = new List<Order>();

        ordersList.Add(new Order(_buyerId, _shipToAddress,
            new List<OrderItem>
            {
                    new OrderItem(new CatalogItemOrdered(1, "Product1", "testurl"), 10.50m, 1)
            }));
        ordersList.Add(new Order(_buyerId, _shipToAddress,
            new List<OrderItem>
            {
                    new OrderItem(new CatalogItemOrdered(2, "Product2", "testurl"), 15.50m, 2),
                    new OrderItem(new CatalogItemOrdered(2, "Product3", "testurl"), 20.50m, 1)
            }));

        return ordersList;
    }
}
