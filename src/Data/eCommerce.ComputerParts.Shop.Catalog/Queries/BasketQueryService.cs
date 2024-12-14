using System.Linq;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace eCommerce.ComputerParts.Shop.Catalog.Queries;

public class BasketQueryService : IBasketQueryService
{
    private readonly CatalogContext _dbContext;

    public BasketQueryService(CatalogContext dbContext)
    {
        _dbContext = dbContext;
    }

    /// <summary>
    /// This method performs the sum on the database rather than in memory
    /// </summary>
    /// <param name="username"></param>
    /// <returns></returns>
    public async Task<int> CountTotalBasketItems(string username)
    {
        var totalItems = await _dbContext.Baskets
            .Where(basket => basket.BuyerId == username)
            .SelectMany(item => item.Items)
            .SumAsync(sum => sum.Quantity);

        return totalItems;
    }
}
