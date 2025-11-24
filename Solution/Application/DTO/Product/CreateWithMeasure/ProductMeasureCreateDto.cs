using Application.DTO.Common;
using FluentValidation;

namespace Application.DTO.Product.CreateWithMeasure;

public record ProductMeasureCreateDto : IDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Manufacturer { get;set; }
    public required double SellingPrice { get; set; }
    public List<NoProductIdMeasureCreateDto>? Measures { get; set; }
}

public class ProductMeasureCreateValidator : AbstractValidator<ProductMeasureCreateDto>
{
    public ProductMeasureCreateValidator()
    {
    }
}