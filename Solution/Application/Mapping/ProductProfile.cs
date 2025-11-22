using Application.DTO.Product.Create;
using Application.DTO.Product.Update;
using AutoMapper;
using Domain.Product;

namespace Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductCreatedDto>();
        
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<Product, ProductUpdatedDto>();
    }
}