using Application.DTO.Common;

namespace Application.DTO.Measure.Delete;

public record MeasureDeletedDto : IDto
{
    public required int ProductId { get; set; }
    public required int Id { get; set; }
    public required short Height { get; set; }
    public required short Width { get; set; }
    public required short Depth { get; set; }
    public required int Weight { get; set; }
}