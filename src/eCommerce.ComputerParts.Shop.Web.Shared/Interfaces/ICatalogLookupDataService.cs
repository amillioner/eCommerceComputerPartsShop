using System.Collections.Generic;
using System.Threading.Tasks;
using eCommerce.ComputerParts.Shop.Web.Shared.Models;

namespace eCommerce.ComputerParts.Shop.Web.Shared.Interfaces;

public interface ICatalogLookupDataService<TLookupData> where TLookupData : LookupData
{
    Task<List<TLookupData>> List();
}
