using Application.Command.Interface;
using Application.DTO.Complement.Create;
using Application.DTO.Customer.Person.Create;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Customer;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;
using Microsoft.Extensions.Logging.Abstractions;

namespace Application.Command;

public class PersonCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IRepository<Person> personBaseRepository,
    IRepository<Complement> complementBaseRepository,
    IValidator<PersonCreateDto> personCreateValidator,
    IValidator<ComplementCreateDto> complementCreateValidator,
    ValidationResult validationResult) : IPersonCommandHandler
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

        if (dto.Complement is not null)
        {
            validationResult.GetDataFromFluentValidationResult(complementCreateValidator.Validate(dto.Complement));
            if (validationResult.Validity is false)
            {
                validationResult.Add(ValidationCodes.Code.UnprocessableEntity,
                    ValidationUtils.InvalidOperation_WrongCredentials(), false);
                return new CommonResponse<PersonCreatedDto>
                {
                    Content = null,
                    ValidationResult = validationResult
                };
            }
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        var personEntity = await personBaseRepository.Add(mapper.Map<Person>(dto), cancellationToken);
        if (dto.Complement is not null)
        {
            await personBaseRepository.Save(cancellationToken);
            var complementEntity = mapper.Map<Complement>(dto.Complement);
            complementEntity.CustomerId = personEntity.Id;
            await complementBaseRepository.Add(complementEntity, cancellationToken);
        }
        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Created,
            ValidationUtils.ValidOperation_Created(typeof(PersonCreatedDto)), true);
        return new CommonResponse<PersonCreatedDto>()
        {
            Content = mapper.Map<PersonCreatedDto>(personEntity),
            ValidationResult = validationResult
        };
    }
}