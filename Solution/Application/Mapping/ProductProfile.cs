using Application.DTO.Product.Create;
using AutoMapper;
using Domain.Product;

namespace Application.Mapping;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductCreatedDto>();
    }
}