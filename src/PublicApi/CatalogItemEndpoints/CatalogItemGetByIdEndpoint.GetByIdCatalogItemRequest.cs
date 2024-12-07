namespace eCommerce.ComputerParts.Shop.Service.CatalogItemEndpoints;

public class GetByIdCatalogItemRequest : BaseRequest
{
    public int CatalogItemId { get; init; }

    public GetByIdCatalogItemRequest(int catalogItemId)
    {
        CatalogItemId = catalogItemId;
    }
}
