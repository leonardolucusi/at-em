using Application.DTO.Measure.Common;
using Application.DTOs.Validator;
using Application.Query.Interface;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Product;
using Domain.Validations;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;

namespace Application.Query;

public class MeasureQueryHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IRepository<Measure> measureBaseRepository,
    IMeasureRepository measureRepository,
    ValidationResult validationResult) : IMeasureQueryHandler
{
    public async Task<CommonListResponse<IEnumerable<MeasureDto>>> GetMeasuresByProductId(int id,
        CancellationToken cancellationToken = default)
    {
        var response = new CommonListResponse<IEnumerable<MeasureDto>>();

        if (!ValidatorExtensions.IsValidId(id, out var productIdErrors))
        {
            response.Content = null;

            productIdErrors?.ForEach(x =>
            {
                validationResult.Add(ValidationCodes.CodesDictionary[x.ErrorCode], x.ErrorMessage, false);
                response.ValidationResult = validationResult;
            });

            return response;
        }
        
        var measures = await measureRepository.GetMeasuresByProductId(id, cancellationToken);
        if (!measures.Any())
        {
            validationResult.Add(ValidationCodes.Code.NotFound, ValidationUtils.InvalidOperation_NotFound(), false);
            response.Content = null;
            response.ValidationResult = validationResult;
            return response;
        }
        
        var result = mapper.Map<IEnumerable<MeasureDto>>(measures);
        
        validationResult.Add(ValidationCodes.Code.Ok, ValidationUtils.ValidOperation_Ok(), true);
        response.Content = result;
        response.ValidationResult = validationResult;
        return response;

    }
}