using System.Collections.Generic;
using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.MyOrders;

public class GetMyOrders : IRequest<IEnumerable<OrderViewModel>>
{
    public GetMyOrders(string userName)
    {
        UserName = userName;
    }

    public string UserName { get; set; }
}
