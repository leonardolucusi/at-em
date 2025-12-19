using Application.Command.Interface;
using Application.DTO.Customer.Person.Create;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Customer;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;

namespace Application.Command;

public class CustomerCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IRepository<Person> personBaseRepository,
    IValidator<PersonCreateDto> personCreateValidator,
    ValidationResult validationResult) : ICustomerCommandHandler
{
    public async Task<CommonResponse<PersonCreatedDto>> AddPerson(PersonCreateDto dto,
        CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(personCreateValidator.Validate(dto));
        if (validationResult.Validity is false)
        {
            return new CommonResponse<PersonCreatedDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }
        
        await unitOfWork.BeginTransaction(cancellationToken);

        await personBaseRepository.Add(mapper.Map<Person>(dto), cancellationToken);
        
        await unitOfWork.CommitTransaction(cancellationToken);
        
        validationResult.Add(ValidationCodes.Code.Created, ValidationUtils.ValidOperation_Created(typeof(PersonCreatedDto)), true);
        return new CommonResponse<PersonCreatedDto>()
        {
            Content = mapper.Map<PersonCreatedDto>(dto),
            ValidationResult = validationResult
        };
    }
}