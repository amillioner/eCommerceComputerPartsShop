using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Entities.OrderAggregate;

namespace eCommerce.ComputerParts.Shop.Core.Interfaces;

public interface IOrderService
{
    Task CreateOrderAsync(int basketId, Address shippingAddress);
}
