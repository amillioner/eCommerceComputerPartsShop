using System.Collections.Generic;
using eCommerce.ComputerParts.Shop.Shared.Models;

namespace eCommerce.ComputerParts.Shop.Shared.Interfaces;

public interface ILookupDataResponse<TLookupData> where TLookupData : LookupData
{
    List<TLookupData> List { get; set; }
}
