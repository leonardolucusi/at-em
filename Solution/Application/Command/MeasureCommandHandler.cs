using Application.Command.Interface;
using Application.DTO.Measure.Common;
using Application.DTO.Measure.Create;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Product;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;

namespace Application.Command;

public class MeasureCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IValidator<MeasureCreateDto> measureCreateValidator,
    IRepository<Product> productRepository,
    IRepository<Measure> measureRepository,
    ValidationResult validationResult) : IMeasureCommandHandler
{
    public async Task<CommonResponse<MeasureDto>> Create(MeasureCreateDto dto,
        CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(measureCreateValidator.Validate(dto));

        if (validationResult.Validity is false)
        {
            return new CommonResponse<MeasureDto> { Content = null, ValidationResult = validationResult };
        }

        if ((await productRepository.GetById(dto.ProductId, false, cancellationToken) is null))
        {
            validationResult.Add(ValidationCodes.Code.NotFound, ValidationUtils.InvalidOperation_NotFound(), false);
            return new CommonResponse<MeasureDto> { Content = null, ValidationResult = validationResult };
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        var measureEntity = await measureRepository.Add(mapper.Map<Measure>(dto), cancellationToken);

        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Created, 
            ValidationUtils.ValidOperation_Created(typeof(MeasureDto)),true);
        return new CommonResponse<MeasureDto>()
        {
            Content = mapper.Map<MeasureDto>(measureEntity), 
            ValidationResult = validationResult
        };
    }
}