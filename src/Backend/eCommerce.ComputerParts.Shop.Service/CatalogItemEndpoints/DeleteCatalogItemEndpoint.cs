﻿using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Entities;
using eCommerce.ComputerParts.Shop.Core.Interfaces;
using eCommerce.ComputerParts.Shop.Shared.Authorization;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;
using MinimalApi.Endpoint;

namespace eCommerce.ComputerParts.Shop.Service.CatalogItemEndpoints;

/// <summary>
/// Deletes a Catalog Item
/// </summary>
public class DeleteCatalogItemEndpoint : IEndpoint<IResult, DeleteCatalogItemRequest, IRepository<CatalogItem>>
{
    public void AddRoute(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/catalog-items/{catalogItemId}",
            [Authorize(Roles = Constants.Roles.ADMINISTRATORS, AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)] async
            (int catalogItemId, IRepository<CatalogItem> itemRepository) =>
            {
                return await HandleAsync(new DeleteCatalogItemRequest(catalogItemId), itemRepository);
            })
            .Produces<DeleteCatalogItemResponse>()
            .WithTags("CatalogItemEndpoints");
    }

    public async Task<IResult> HandleAsync(DeleteCatalogItemRequest request, IRepository<CatalogItem> itemRepository)
    {
        var response = new DeleteCatalogItemResponse(request.CorrelationId());

        var itemToDelete = await itemRepository.GetByIdAsync(request.CatalogItemId);
        if (itemToDelete is null)
            return Results.NotFound();

        await itemRepository.DeleteAsync(itemToDelete);

        return Results.Ok(response);
    }
}
