using Application.DTO.Measure.Common;
using Application.DTO.Measure.Create;
using Application.DTO.Measure.Read;
using Application.DTO.Product.Create;
using Application.DTO.Product.CreateWithMeasure;
using Application.DTO.Product.Delete;
using Application.DTO.Product.Read;
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
        
        CreateMap<ProductMeasureCreateDto, Product>()
            .ForMember(dest => dest.Measures, opt => opt.Ignore());

        CreateMap<Product, ProductMeasureCreatedDto>();
        CreateMap<MeasureCreateDto, Measure>();

        CreateMap<Product, ProductWithMeasuresDto>();
        CreateMap<Measure, MeasureWithIdDto>();
        
        CreateMap<Measure, MeasureCreatedDto>();
        CreateMap<MeasureCreateDto, Measure>();
        CreateMap<Measure, MeasureDto>();
    }
}
