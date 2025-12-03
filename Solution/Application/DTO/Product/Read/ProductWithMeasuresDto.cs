using Application.DTO.Common;
using Application.DTO.Measure.Read;

namespace Application.DTO.Product.Read;

public record ProductWithMeasuresDto : IDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Manufacturer { get;set; }
    public required double SellingPrice { get; set; }
    public IEnumerable<MeasureWithIdDto>? MeasuresDto { get; set; }
}