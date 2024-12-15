using MediatR;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Features.OrderDetails;

public class GetOrderDetails : IRequest<OrderDetailViewModel>
{
    public GetOrderDetails(string userName, int orderId)
    {
        UserName = userName;
        OrderId = orderId;
    }

    public string UserName { get; set; }
    public int OrderId { get; set; }
}
