﻿using System.Threading.Tasks;
using Ardalis.GuardClauses;
using eCommerce.ComputerParts.Shop.Core.Entities;
using eCommerce.ComputerParts.Shop.Core.Interfaces;
using Microsoft.eShopWeb.Web.Interfaces;
using Microsoft.eShopWeb.Web.ViewModels;

namespace Microsoft.eShopWeb.Web.Services;

public class CatalogItemViewModelService : ICatalogItemViewModelService
{
    private readonly IRepository<CatalogItem> _catalogItemRepository;

    public CatalogItemViewModelService(IRepository<CatalogItem> catalogItemRepository)
    {
        _catalogItemRepository = catalogItemRepository;
    }

    public async Task UpdateCatalogItem(CatalogItemViewModel viewModel)
    {
        var existingCatalogItem = await _catalogItemRepository.GetByIdAsync(viewModel.Id);

        Guard.Against.Null(existingCatalogItem, nameof(existingCatalogItem));

        CatalogItem.CatalogItemDetails details = new(viewModel.Name, existingCatalogItem.Description, viewModel.Price);
        existingCatalogItem.UpdateDetails(details);
        await _catalogItemRepository.UpdateAsync(existingCatalogItem);
    }
}
