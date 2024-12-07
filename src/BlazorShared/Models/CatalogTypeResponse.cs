using System.Collections.Generic;
using System.Text.Json.Serialization;
using eCommerce.ComputerParts.Shop.Web.Shared.Interfaces;

namespace eCommerce.ComputerParts.Shop.Web.Shared.Models;

public class CatalogTypeResponse : ILookupDataResponse<CatalogType>
{

    [JsonPropertyName("CatalogTypes")]
    public List<CatalogType> List { get; set; } = new List<CatalogType>();
}
