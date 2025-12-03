using Application.DTO.Common;

namespace Application.DTO.Measure.Read;

public record MeasureWithIdDto : IDto
{
    public required int Id { get; set; }
    public required int ProductId { get; set; }
    public required short Height { get; set; }
    public required short Width { get; set; }
    public required short Depth { get; set; }
    public required int Weight { get; set; }
}