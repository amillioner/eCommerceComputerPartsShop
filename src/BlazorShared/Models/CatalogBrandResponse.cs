using System.Collections.Generic;
using System.Text.Json.Serialization;
using eCommerce.ComputerParts.Shop.Web.Shared.Interfaces;

namespace eCommerce.ComputerParts.Shop.Web.Shared.Models;

public class CatalogBrandResponse : ILookupDataResponse<CatalogBrand>
{
    [JsonPropertyName("CatalogBrands")]
    public List<CatalogBrand> List { get; set; } = new List<CatalogBrand>();
}
