using API.Endpoints.Validation;
using Application.Command.Interface;
using Application.DTO.Customer.Person.Create;

namespace API.Endpoints.Customer;

partial class CustomerGroup
{
    private static async Task<IResult> CreateCustomerPerson(
        PersonCreateDto personCreateDto,
        ICustomerCommandHandler customerCommandHandler,
        CancellationToken cancellationToken)
    {
        var response = await customerCommandHandler.AddPerson(personCreateDto, cancellationToken);
        return Result.From(response, response.Content);
    }
}