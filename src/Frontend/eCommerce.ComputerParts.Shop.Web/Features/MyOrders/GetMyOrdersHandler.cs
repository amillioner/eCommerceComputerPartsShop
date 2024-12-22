﻿using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;
using eCommerce.ComputerParts.Shop.Core.Interfaces;
using eCommerce.ComputerParts.Shop.Core.Specifications;
using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.MyOrders;

public class GetMyOrdersHandler : IRequestHandler<GetMyOrders, IEnumerable<OrderViewModel>>
{
    private readonly IReadRepository<Order> _orderRepository;

    public GetMyOrdersHandler(IReadRepository<Order> orderRepository)
    {
        _orderRepository = orderRepository;
    }

    public async Task<IEnumerable<OrderViewModel>> Handle(GetMyOrders request,
        CancellationToken cancellationToken)
    {
        var specification = new CustomerOrdersSpecification(request.UserName);
        var orders = await _orderRepository.ListAsync(specification, cancellationToken);

        return orders.Select(o => new OrderViewModel
        {
            OrderDate = o.OrderDate, OrderNumber = o.Id, ShippingAddress = o.ShipToAddress, Total = o.Total()
        });
    }
}
