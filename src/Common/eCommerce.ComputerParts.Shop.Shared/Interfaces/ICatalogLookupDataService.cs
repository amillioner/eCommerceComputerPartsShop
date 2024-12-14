using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Shared.Models;

namespace eCommerce.ComputerParts.Shop.Shared.Interfaces;

public interface ICatalogLookupDataService<TLookupData> where TLookupData : LookupData
{
    Task<List<TLookupData>> List();
}
