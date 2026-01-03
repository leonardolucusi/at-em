using Application.DTO.Common;
using FluentValidation;

namespace Application.DTO.Complement.Create;

public record ComplementCreateDto : IDto
{
    public string CustomerId { get; set; }
    public string Address { get; set; }
    public string AddressComplement { get; set; }
    public string District { get; set; }
    public string Country { get; set; }
    public string State { get; set; }
    public string City { get; set; }
    public string FederalUnit { get; set; }
    public string ZipCode { get; set; }
    public string Telephone { get; set; }
    public string Cellphone { get; set; }
    public string Email { get; set; }
    public string ContactName { get; set; }
    public bool IsActive { get; set; }
}

public class ComplementCreateValidator : AbstractValidator<ComplementCreateDto>
{
    public ComplementCreateValidator()
    {
        
    }
}