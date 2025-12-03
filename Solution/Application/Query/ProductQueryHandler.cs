using Application.DTO.Measure.Read;
using Application.DTO.Product.Read;
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

public class ProductQueryHandler(
    IMapper mapper,
    IUnitOfWork unitOfWork,
    IRepository<Product> productRepository,
    IMeasureRepository measureRepository,
    ValidationResult validationResult) : IProductQueryHandler
{
    public async Task<CommonResponse<ProductWithMeasuresDto>> GetById(int id, CancellationToken cancellationToken = default)
    {
        var response = new CommonResponse<ProductWithMeasuresDto>();

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
        
        var product = await productRepository.GetById(id, true, cancellationToken);
        if (product is null)
        {
            validationResult.Add(ValidationCodes.Code.NotFound, ValidationUtils.InvalidOperation_NotFound(), false);
            return new CommonResponse<ProductWithMeasuresDto>
            {
                Content = null,
                ValidationResult = validationResult
            };
        }
        
        var measures = await measureRepository.GetMeasuresByProductId(id, cancellationToken);

        var productMeasures = mapper.Map<ProductWithMeasuresDto>(product);
        
        productMeasures.MeasuresDto = measures.Select(mapper.Map<MeasureWithIdDto>);

        validationResult.Add(ValidationCodes.Code.Ok, ValidationUtils.ValidOperation_Ok(), true);
        return new CommonResponse<ProductWithMeasuresDto>
        {
            Content = productMeasures,
            ValidationResult = validationResult
        };
    }
}