﻿using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Core.Entities.BasketAggregate;
using Microsoft.eShopWeb.Web.Pages.Basket;

namespace Microsoft.eShopWeb.Web.Interfaces;

public interface IBasketViewModelService
{
    Task<BasketViewModel> GetOrCreateBasketForUser(string userName);
    Task<int> CountTotalBasketItems(string username);
    Task<BasketViewModel> Map(Basket basket);
}
