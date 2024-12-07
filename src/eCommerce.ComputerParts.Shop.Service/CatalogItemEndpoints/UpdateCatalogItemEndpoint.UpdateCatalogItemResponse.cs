using System;

namespace eCommerce.ComputerParts.Shop.Service.CatalogItemEndpoints;

public class UpdateCatalogItemResponse : BaseResponse
{
    public UpdateCatalogItemResponse(Guid correlationId) : base(correlationId)
    {
    }

    public UpdateCatalogItemResponse()
    {
    }

    public CatalogItemDto CatalogItem { get; set; }
}
