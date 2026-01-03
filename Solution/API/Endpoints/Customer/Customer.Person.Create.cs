using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Customer.Person.Create;

namespace API.Endpoints.Customer;

partial class CustomerGroup
{
    private static async Task<IResult> CreateCustomerPerson(
        PersonCreateDto personCreateDto,
        IPersonCommandHandler personCommandHandler,
        CancellationToken cancellationToken)
    {
        var response = await personCommandHandler.AddPerson(personCreateDto, cancellationToken);
        return Result.From(response, response.Content);
    }
}