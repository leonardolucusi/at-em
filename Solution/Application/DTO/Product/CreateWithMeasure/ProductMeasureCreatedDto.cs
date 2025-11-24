using Application.DTO.Common;
using Application.DTO.Measure.Create;

namespace Application.DTO.Product.CreateWithMeasure;

public record ProductMeasureCreatedDto : IDto
{
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Manufacturer { get;set; }
    public required double SellingPrice { get; set; }
    public IEnumerable<MeasureCreatedDto>? Measures { get; set; }
}