using Application.Command.Interface;
using Application.DTO.Product.Create;
using Application.Responses.Common;
using Application.Validation;
using AutoMapper;
using Domain.Product;
using Domain.Validations;
using FluentValidation;
using Infrastructure.Repository.Interface;
using Infrastructure.UnitOfWork;

namespace Application.Command;

public class ProductHandler(
    IUnitOfWork unitOfWork,
    IMapper mapper,
    IRepository<Product> productRepository,
    IValidator<ProductCreateDto> productCreateValidator,
    ValidationResult validationResult) : IProductHandler
{
    public async Task<CommonResponse<ProductCreatedDto>> HandleAdd(ProductCreateDto productCreateDto,
        CancellationToken cancellationToken = default)
    {
        validationResult.GetDataFromFluentValidationResult(productCreateValidator.Validate(productCreateDto));
        if (validationResult.Validity is false)
        {
            return new CommonResponse<ProductCreatedDto>()
            {
                Content = null,
                ValidationResult = validationResult
            };
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        var product = await productRepository.Add(mapper.Map<Product>(productCreateDto), cancellationToken);
        
        await unitOfWork.CommitTransaction(cancellationToken);
        
        validationResult.Add(ValidationCodes.Code.Created, ValidationUtils.ValidOperation_Created(typeof(ProductCreatedDto)), true);
        return new CommonResponse<ProductCreatedDto>()
        {
            Content = mapper.Map<ProductCreatedDto>(product),
            ValidationResult = validationResult
        };
    }
}