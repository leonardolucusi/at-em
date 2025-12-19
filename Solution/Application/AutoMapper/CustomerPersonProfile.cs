using Application.DTO.Customer.Person.Create;

using AutoMapper;
using Domain.Customer;

namespace Application.AutoMapper;

public class CustomerPersonProfile : Profile
{
    public CustomerPersonProfile()
    {
        CreateMap<PersonCreateDto, Person>();
        CreateMap<Person, PersonCreatedDto>();
    }
}