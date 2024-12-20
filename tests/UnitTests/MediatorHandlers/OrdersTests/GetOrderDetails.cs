﻿using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;
using eCommerce.ComputerParts.Shop.Core.Interfaces;
using eCommerce.ComputerParts.Shop.Core.Specifications;
using Microsoft.eShopWeb.Web.Features.OrderDetails;
using NSubstitute;
using Xunit;

namespace eCommerce.ComputerParts.Shop.UnitTests.MediatorHandlers.OrdersTests;

public class GetOrderDetails
{
    private readonly IReadRepository<Order> _mockOrderRepository = Substitute.For<IReadRepository<Order>>();

    public GetOrderDetails()
    {
        var item = new OrderItem(new CatalogItemOrdered(1, "ProductName", "URI"), 10.00m, 10);
        var address = new Address("", "", "", "", "");
        Order order = new Order("buyerId", address, new List<OrderItem> { item });

        _mockOrderRepository.FirstOrDefaultAsync(Arg.Any<OrderWithItemsByIdSpec>(), default)
            .Returns(order);
    }

    [Fact]
    public async Task NotBeNullIfOrderExists()
    {
        var request = new Microsoft.eShopWeb.Web.Features.OrderDetails.GetOrderDetails("SomeUserName", 0);

        var handler = new GetOrderDetailsHandler(_mockOrderRepository);

        var result = await handler.Handle(request, CancellationToken.None);

        Assert.NotNull(result);
    }
}
