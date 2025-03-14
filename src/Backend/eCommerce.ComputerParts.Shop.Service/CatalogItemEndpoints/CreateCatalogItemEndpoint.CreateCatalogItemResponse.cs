﻿using System;

namespace eCommerce.ComputerParts.Shop.Service.CatalogItemEndpoints;

public class CreateCatalogItemResponse : BaseResponse
{
    public CreateCatalogItemResponse(Guid correlationId) : base(correlationId)
    {
    }

    public CreateCatalogItemResponse()
    {
    }

    public CatalogItemDto CatalogItem { get; set; }
}
