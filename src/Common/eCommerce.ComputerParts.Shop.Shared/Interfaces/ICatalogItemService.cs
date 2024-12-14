using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Shared.Models;

namespace eCommerce.ComputerParts.Shop.Shared.Interfaces;

public interface ICatalogItemService
{
    Task<CatalogItem> Create(CreateCatalogItemRequest catalogItem);
    Task<CatalogItem> Edit(CatalogItem catalogItem);
    Task<string> Delete(int id);
    Task<CatalogItem> GetById(int id);
    Task<List<CatalogItem>> ListPaged(int pageSize);
    Task<List<CatalogItem>> List();
}
