using Application.DTO.Common;
using FluentValidation;

namespace Application.DTO.Product.CreateWithMeasure;

public record NoProductIdMeasureCreateDto : IDto
{
    public required short Height { get; set; }
    public required short Width { get; set; }
    public required short Depth { get; set; }
    public required int Weight { get; set; }
}

public class NoProductIdMeasureCreateValidator : AbstractValidator<NoProductIdMeasureCreateDto>{
    public NoProductIdMeasureCreateValidator()
    {
    }
}