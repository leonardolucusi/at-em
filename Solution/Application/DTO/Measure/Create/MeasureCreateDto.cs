using Application.DTO.Common;
using FluentValidation;

namespace Application.DTO.Measure.Create;

public record MeasureCreateDto : IDto
{
    public required int ProductId { get; set; }
    public required short Height { get; set; }
    public required short Width { get; set; }
    public required short Depth { get; set; }
    public required int Weight { get; set; }
}

public class MeasureCreateValidator : AbstractValidator<MeasureCreateDto>{
    public MeasureCreateValidator()
    {
        
    }
}