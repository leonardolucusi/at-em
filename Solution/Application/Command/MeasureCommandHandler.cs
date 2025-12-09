using Application.Command.Interface;
using Application.DTO.Measure.Common;
using Application.DTO.Measure.Create;
using Application.DTO.Measure.Delete;
using Application.DTO.Measure.Update;
using Application.DTOs.Validator;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Product;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;
using Infrastructure.Utility;

namespace Application.Command;

public class MeasureCommandHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IRepository<Product> productRepository,
    IRepository<Measure> measureBaseRepository,
    IMeasureRepository measureRepository,
    IValidator<MeasureCreateDto> measureCreateValidator,
    IValidator<MeasureUpdateDto> measureUpdateValidator,
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

        var measureEntity = await measureBaseRepository.Add(mapper.Map<Measure>(dto), cancellationToken);

        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Created, 
            ValidationUtils.ValidOperation_Created(typeof(MeasureDto)),true);
        return new CommonResponse<MeasureDto>()
        {
            Content = mapper.Map<MeasureDto>(measureEntity), 
            ValidationResult = validationResult
        };
    }
    
    public async Task<CommonResponse<MeasureUpdatedDto>> UpdateMeasureById(MeasureUpdateDto dto,
        CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(measureUpdateValidator.Validate(dto));
        
        if (validationResult.Validity is false)
        {
            return new CommonResponse<MeasureUpdatedDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }
        
        await unitOfWork.BeginTransaction(cancellationToken);
        
        var measureEntity = await measureBaseRepository.GetById(dto.Id, false, cancellationToken);
        
        if (measureEntity is null)
        {
            validationResult.Add(ValidationCodes.Code.NotFound, ValidationUtils.InvalidOperation_NotFound(), false);
            return new CommonResponse<MeasureUpdatedDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }
        
        await measureBaseRepository.Update(mapper.Map(dto, measureEntity), cancellationToken);
        
        await unitOfWork.CommitTransaction(cancellationToken);

        validationResult.Add(ValidationCodes.Code.Ok, ValidationUtils.ValidOperation_Ok(), true);
        return new CommonResponse<MeasureUpdatedDto>
        {
            Content = mapper.Map<MeasureUpdatedDto>(measureEntity),
            ValidationResult = validationResult
        };
    }

    public async Task<CommonResponse<MeasureDeletedDto>> DeleteById(int id,
        CancellationToken cancellationToken = default)
    {
        var response = new CommonResponse<MeasureDeletedDto>();

        if (!ValidatorExtensions.IsValidId(id, out var measureIdErrors))
        {
            response.Content = null;

            measureIdErrors?.ForEach(x =>
            {
                validationResult.Add(ValidationCodes.CodesDictionary[x.ErrorCode], x.ErrorMessage, false);
                response.ValidationResult = validationResult;
            });

            return response;
        }

        await unitOfWork.BeginTransaction(cancellationToken);
        
        var measure = await measureBaseRepository.DeleteById(id, cancellationToken);

        if (measure == DeleteResult.NotFound)
        {
            validationResult.Add(ValidationCodes.Code.NotFound, ValidationUtils.InvalidOperation_NotFound(), false);
            response.Content = null;
            response.ValidationResult = validationResult;
            return response;
        }
        
        await unitOfWork.CommitTransaction(cancellationToken);
        
        validationResult.Add(ValidationCodes.Code.Ok, ValidationUtils.ValidOperation_Ok(), true);
        response.ValidationResult = validationResult;
        return response;
    }

}