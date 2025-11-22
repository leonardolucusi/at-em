using Application.DTO.Common;
using FluentValidation;

namespace Application.DTO.Product.Update;

public record ProductUpdateDto : IDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Manufacturer { get;set; }
    public required double SellingPrice { get; set; }
}

public class ProductUpdateValidator : AbstractValidator<ProductUpdateDto>
{
    public ProductUpdateValidator()
    {
        
    }
}