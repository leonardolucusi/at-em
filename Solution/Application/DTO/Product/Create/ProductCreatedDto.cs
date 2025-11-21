using Application.DTO.Common;

namespace Application.DTO.Product.Create;

public record ProductCreatedDto : IDto
{
    public required int Id { get; set; }
    public required string Name { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
    public required string Manufacturer { get;set; }
    public required double SellingPrice { get; set; }
}