using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Entities.BasketAggregate;
using eCommerce.ComputerParts.Shop.Core.Services;
using eCommerce.ComputerParts.Shop.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.eShopWeb.UnitTests.Builders;
using Xunit;

namespace Microsoft.eShopWeb.IntegrationTests.Repositories.BasketRepositoryTests;

public class SetQuantities
{
    private readonly CatalogContext _catalogContext;
    private readonly CatalogRepository<Basket> _basketRepository;
    private readonly BasketBuilder BasketBuilder = new BasketBuilder();

    public SetQuantities()
    {
        var dbOptions = new DbContextOptionsBuilder<CatalogContext>()
            .UseInMemoryDatabase(databaseName: "TestCatalog")
            .Options;
        _catalogContext = new CatalogContext(dbOptions);
        _basketRepository = new CatalogRepository<Basket>(_catalogContext);
    }

    [Fact]
    public async Task RemoveEmptyQuantities()
    {
        var basket = BasketBuilder.WithOneBasketItem();
        var basketService = new BasketService(_basketRepository, null);
        await _basketRepository.AddAsync(basket);
        _catalogContext.SaveChanges();

        await basketService.SetQuantities(BasketBuilder.BasketId, new Dictionary<string, int>() { { BasketBuilder.BasketId.ToString(), 0 } });

        Assert.Equal(0, basket.Items.Count);
    }
}
