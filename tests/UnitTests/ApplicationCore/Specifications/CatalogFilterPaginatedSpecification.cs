﻿using eCommerce.ComputerParts.Shop.Core.Entities;
using Xunit;

namespace eCommerce.ComputerParts.Shop.UnitTests.ApplicationCore.Specifications;

public class CatalogFilterPaginatedSpecification
{
    [Fact]
    public void ReturnsAllCatalogItems()
    {
        var spec = new eCommerce.ComputerParts.Shop.Core.Specifications.CatalogFilterPaginatedSpecification(0, 10, null, null);

        var result = spec.Evaluate(GetTestCollection());

        Assert.NotNull(result);
        Assert.Equal(4, result.ToList().Count);
    }

    [Fact]
    public void Returns2CatalogItemsWithSameBrandAndTypeId()
    {
        var spec = new eCommerce.ComputerParts.Shop.Core.Specifications.CatalogFilterPaginatedSpecification(0, 10, 1, 1);

        var result = spec.Evaluate(GetTestCollection()).ToList();

        Assert.NotNull(result);
        Assert.Equal(2, result.ToList().Count);
    }

    private List<CatalogItem> GetTestCollection()
    {
        var catalogItemList = new List<CatalogItem>();

        catalogItemList.Add(new CatalogItem(1, 1, "Item 1", "Item 1", 1.00m, "TestUri1"));
        catalogItemList.Add(new CatalogItem(1, 1, "Item 1.5", "Item 1.5", 1.50m, "TestUri1"));
        catalogItemList.Add(new CatalogItem(2, 2, "Item 2", "Item 2", 2.00m, "TestUri2"));
        catalogItemList.Add(new CatalogItem(3, 3, "Item 3", "Item 3", 3.00m, "TestUri3"));

        return catalogItemList;
    }
}
