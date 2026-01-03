using Application.DTO.Common;
using Application.DTO.Complement.Create;
using Domain.Customer;
using Domain.Utility;
using FluentValidation;

namespace Application.DTO.Customer.Person.Create;

public record PersonCreateDto : IDto
{
    public CustomerType CustomerType { get; set; }
    public string Name { get; set; }
    public string Cpf { get; set; }
    public string Rg { get; set; }
    public ComplementCreateDto? Complement { get; set; }
}

public class PersonCreateDtoValidator : AbstractValidator<PersonCreateDto>
{
    public PersonCreateDtoValidator()
    {
        
    }
}