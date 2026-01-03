using Application.DTO.Complement.Create;
using Application.DTO.Customer.Person.Create;

using AutoMapper;
using Domain.Customer;

namespace Application.AutoMapper;

public class CustomerPersonProfile : Profile
{
    public CustomerPersonProfile()
    {
        CreateMap<PersonCreateDto, Person>()
            .ForMember(dest => dest.Complement, opt => opt.Ignore());
        CreateMap<Person, PersonCreatedDto>();

        CreateMap<ComplementCreateDto, Complement>()
            .ForMember(dest => dest.CustomerId, opt => opt.Ignore());
        CreateMap<Complement, ComplementCreatedDto>();
    }
}