using System.Collections.Generic;
using eCommerce.ComputerParts.Shop.Web.Shared.Models;

namespace eCommerce.ComputerParts.Shop.Web.Shared.Interfaces;

public interface ILookupDataResponse<TLookupData> where TLookupData : LookupData
{
    List<TLookupData> List { get; set; }
}
