using AutoMapper;
using eCommerce.ComputerParts.Shop.Core.Entities;
using eCommerce.ComputerParts.Shop.Service.CatalogBrandEndpoints;
using eCommerce.ComputerParts.Shop.Service.CatalogItemEndpoints;
using eCommerce.ComputerParts.Shop.Service.CatalogTypeEndpoints;

namespace eCommerce.ComputerParts.Shop.Service;

public class MappingProfile : Profile
{
    public MappingProfile()
    {
        CreateMap<CatalogItem, CatalogItemDto>();
        CreateMap<CatalogType, CatalogTypeDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Type));
        CreateMap<CatalogBrand, CatalogBrandDto>()
            .ForMember(dto => dto.Name, options => options.MapFrom(src => src.Brand));
    }
}
