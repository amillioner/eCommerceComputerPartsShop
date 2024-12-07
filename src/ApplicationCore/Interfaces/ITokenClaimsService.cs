using System.Threading.Tasks;

namespace eCommerce.ComputerParts.Shop.Core.Interfaces;

public interface ITokenClaimsService
{
    Task<string> GetTokenAsync(string userName);
}
