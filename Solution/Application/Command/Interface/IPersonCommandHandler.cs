using Application.DTO.Customer.Person.Create;
using Application.Responses.Common;

namespace Application.Command.Interface;

public interface IPersonCommandHandler
{
    public Task<CommonResponse<PersonCreatedDto>> AddPerson(PersonCreateDto dto,
        CancellationToken cancellationToken = default);
}