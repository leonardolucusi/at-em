using Application.DTO.Common;
using FluentValidation;

namespace Application.DTO.Measure.Update;

public record MeasureUpdateDto : IDto
{
    public required int Id { get; set; }
    public required short Height { get; set; }
    public required short Width { get; set; }
    public required short Depth { get; set; }
    public required int Weight { get; set; }
}


public class MeasureUpdateValidator : AbstractValidator<MeasureUpdateDto>{
    public MeasureUpdateValidator()
    {
    }
}