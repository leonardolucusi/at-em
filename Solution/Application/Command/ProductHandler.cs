using Application.Command.Interface;
using Application.DTO.Product.Create;
using Application.ResponseUtility;
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
    public async Task<Response> HandleAdd(ProductCreateDto productCreateDto,
        CancellationToken cancellationToken = default)
    {
        validationResult.ApplyFluentValidationResult(productCreateValidator.Validate(productCreateDto));
        if (validationResult.Validity is false)
        {
            return new Response()
            {
                Content = null,
                ValidationResult = validationResult
            };
        }

        await unitOfWork.BeginTransaction(cancellationToken);

        var product = await productRepository.Add(mapper.Map<Product>(productCreateDto), cancellationToken);
        
        await unitOfWork.CommitTransaction(cancellationToken);
        
        validationResult.Add(ValidationCodes.Code.Created, ValidationUtils.ValidOperation_Created(typeof(ProductCreatedDto)), true);
        return new Response()
        {
            Content = mapper.Map<ProductCreatedDto>(product),
            ValidationResult = validationResult
        };
    }
}