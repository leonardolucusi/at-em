using Application.DTO.Measure.Create;
using Application.DTO.Product.Create;
using Application.DTO.Product.CreateWithMeasure;
using Application.DTO.Product.Update;
using AutoMapper;
using Domain.Product;

namespace Application.AutoMapper;

public class ProductProfile : Profile
{
    public ProductProfile()
    {
        CreateMap<ProductCreateDto, Product>();
        CreateMap<Product, ProductCreatedDto>();
        
        CreateMap<ProductUpdateDto, Product>();
        CreateMap<Product, ProductUpdatedDto>();
        
        CreateMap<ProductMeasureCreateDto, Product>().ForMember(dest => dest.Measures, opt => opt.Ignore());
        
        CreateMap<Product, ProductMeasureCreatedDto>().ForMember(dest => dest.Measures, opt => opt.Ignore());
        CreateMap<MeasureCreateDto, Measure>();
    }
}