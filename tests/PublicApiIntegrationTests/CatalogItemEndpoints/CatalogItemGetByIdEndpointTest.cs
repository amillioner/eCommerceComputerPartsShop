using System.Net;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Extensions;
using eCommerce.ComputerParts.Shop.Service.CatalogItemEndpoints;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace PublicApiIntegrationTests.CatalogItemEndpoints;

[TestClass]
public class CatalogItemGetByIdEndpointTest
{
    [TestMethod]
    public async Task ReturnsItemGivenValidId()
    {
        var response = await ProgramTest.NewClient.GetAsync("api/catalog-items/5");
        response.EnsureSuccessStatusCode();
        var stringResponse = await response.Content.ReadAsStringAsync();
        var model = stringResponse.FromJson<GetByIdCatalogItemResponse>();

        Assert.AreEqual(5, model!.CatalogItem.Id);
        Assert.AreEqual("G.SKILL Flare X Series 64GB (2 x 32GB) 288-Pin PC RAM DDR5 6000", model.CatalogItem.Name);
    }

    [TestMethod]
    public async Task ReturnsNotFoundGivenInvalidId()
    {
        var response = await ProgramTest.NewClient.GetAsync("api/catalog-items/0");

        Assert.AreEqual(HttpStatusCode.NotFound, response.StatusCode);
    }
}
