using Application.DTO.Common;
using Application.DTO.Complement.Create;
using Domain.Utility;

namespace Application.DTO.Customer.Person.Create;

public record PersonCreatedDto : IDto
{
    public int Id { get; set; }
    public CustomerType CustomerType { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public ComplementCreatedDto? Complement { get; set; }
}
